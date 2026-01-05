using AutoMapper;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using ProjectTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// Invitation service implementation - handles team invitation business logic
    /// </summary>
    public class InvitationService : IInvitationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IEmailService _emailService;

        public InvitationService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ICurrentUserService currentUserService,
            IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _emailService = emailService;
        }
        
        /// <summary>
        /// Get current user ID from session
        /// </summary>
        private int CurrentUserId => _currentUserService.CurrentUserId;

        /// <summary>
        /// Send team invitation
        /// </summary>
        public async Task<TeamInvitationDto> SendInvitationAsync(TeamInvitationDto invitationDto)
        {
            // System Admin can invite to any team
            if (!_currentUserService.IsAdmin)
            {
                // Check if user has permission to invite (team owner or team admin)
                var member = await _unitOfWork.TeamMembers
                    .FirstOrDefaultAsync(tm => tm.TeamId == invitationDto.TeamId 
                        && tm.UserId == CurrentUserId 
                        && tm.IsActive);

                if (member == null || (member.Role != TeamRole.Owner && member.Role != TeamRole.Admin))
                    throw new UnauthorizedAccessException("You don't have permission to send invitations");
            }

            // Check if user already exists and is already a member
            var existingUser = await _unitOfWork.Users
                .FirstOrDefaultAsync(u => u.Email == invitationDto.Email);
            
            if (existingUser != null)
            {
                var existingMember = await _unitOfWork.TeamMembers
                    .FirstOrDefaultAsync(tm => tm.TeamId == invitationDto.TeamId 
                        && tm.UserId == existingUser.UserId 
                        && tm.IsActive);

                if (existingMember != null)
                    throw new InvalidOperationException("User is already a member of this team");
            }

            // Check if there's already a pending invitation
            var pendingInvitation = await _unitOfWork.TeamInvitations
                .FirstOrDefaultAsync(ti => ti.TeamId == invitationDto.TeamId 
                    && ti.Email == invitationDto.Email 
                    && ti.Status == InvitationStatus.Pending
                    && ti.ExpiresAt > DateTime.Now);

            if (pendingInvitation != null)
                throw new InvalidOperationException("There is already a pending invitation for this email");

            // Get team and inviter info for email
            var team = await _unitOfWork.Teams.GetByIdAsync(invitationDto.TeamId);
            var inviter = await _unitOfWork.Users.GetByIdAsync(CurrentUserId);

            // Create invitation
            var invitation = new ProjectTracker.Core.Entities.TeamInvitation
            {
                TeamId = invitationDto.TeamId,
                Email = invitationDto.Email,
                InvitedByUserId = CurrentUserId,
                ProposedRole = invitationDto.ProposedRole,
                Status = InvitationStatus.Pending,
                Token = GenerateInvitationToken(),
                SentAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(7) // 7 days expiration
            };

            await _unitOfWork.TeamInvitations.AddAsync(invitation);
            await _unitOfWork.SaveChangesAsync();

            // Send invitation email (fire-and-forget)
            _ = System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    await _emailService.SendTeamInvitationEmailAsync(
                        toEmail: invitation.Email,
                        teamName: team?.TeamName ?? "Unknown Team",
                        invitedByName: inviter?.FullName ?? "Team Admin",
                        role: invitation.ProposedRole.ToString(),
                        invitationToken: invitation.Token,
                        expiresAt: invitation.ExpiresAt
                    );
                    System.Diagnostics.Debug.WriteLine($"✅ Invitation email sent to {invitation.Email}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Invitation email failed: {ex.Message}");
                }
            });

            return await GetInvitationDto(invitation);
        }

        /// <summary>
        /// Get all invitations for a team
        /// </summary>
        public async Task<IEnumerable<TeamInvitationDto>> GetTeamInvitationsAsync(int teamId)
        {
            var invitations = await _unitOfWork.TeamInvitations
                .FindAsync(ti => ti.TeamId == teamId);

            var dtos = new List<TeamInvitationDto>();
            foreach (var invitation in invitations)
            {
                dtos.Add(await GetInvitationDto(invitation));
            }

            return dtos;
        }

        /// <summary>
        /// Get pending invitations for a user by email
        /// </summary>
        public async Task<IEnumerable<TeamInvitationDto>> GetUserPendingInvitationsAsync(string email)
        {
            var invitations = await _unitOfWork.TeamInvitations
                .FindAsync(ti => ti.Email == email 
                    && ti.Status == InvitationStatus.Pending
                    && ti.ExpiresAt > DateTime.Now);

            var dtos = new List<TeamInvitationDto>();
            foreach (var invitation in invitations.OrderByDescending(i => i.SentAt))
            {
                dtos.Add(await GetInvitationDto(invitation));
            }

            return dtos;
        }

        /// <summary>
        /// Resend invitation
        /// </summary>
        public async Task<bool> ResendInvitationAsync(int invitationId)
        {
            var invitation = await _unitOfWork.TeamInvitations.GetByIdAsync(invitationId);
            if (invitation == null)
                return false;

            // System Admin can resend any invitation
            if (!_currentUserService.IsAdmin)
            {
                // Check permission
                var member = await _unitOfWork.TeamMembers
                    .FirstOrDefaultAsync(tm => tm.TeamId == invitation.TeamId 
                        && tm.UserId == CurrentUserId 
                        && tm.IsActive);

                if (member == null || (member.Role != TeamRole.Owner && member.Role != TeamRole.Admin))
                    throw new UnauthorizedAccessException("You don't have permission to resend invitations");
            }

            if (invitation.Status != InvitationStatus.Pending)
                throw new InvalidOperationException("Can only resend pending invitations");

            // Update invitation
            invitation.Token = GenerateInvitationToken();
            invitation.SentAt = DateTime.Now;
            invitation.ExpiresAt = DateTime.Now.AddDays(7);

            _unitOfWork.TeamInvitations.Update(invitation);
            await _unitOfWork.SaveChangesAsync();

            // TODO: Send email notification

            return true;
        }

        /// <summary>
        /// Cancel invitation
        /// </summary>
        public async Task<bool> CancelInvitationAsync(int invitationId)
        {
            var invitation = await _unitOfWork.TeamInvitations.GetByIdAsync(invitationId);
            if (invitation == null)
                return false;

            // System Admin can cancel any invitation
            if (!_currentUserService.IsAdmin)
            {
                // Check permission
                var member = await _unitOfWork.TeamMembers
                    .FirstOrDefaultAsync(tm => tm.TeamId == invitation.TeamId 
                        && tm.UserId == CurrentUserId 
                        && tm.IsActive);

                if (member == null || (member.Role != TeamRole.Owner && member.Role != TeamRole.Admin))
                    throw new UnauthorizedAccessException("You don't have permission to cancel invitations");
            }

            if (invitation.Status != InvitationStatus.Pending)
                throw new InvalidOperationException("Can only cancel pending invitations");

            invitation.Status = InvitationStatus.Cancelled;
            invitation.RespondedAt = DateTime.Now;

            _unitOfWork.TeamInvitations.Update(invitation);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Accept invitation using token
        /// </summary>
        public async Task<bool> AcceptInvitationAsync(string token)
        {
            var invitation = await _unitOfWork.TeamInvitations
                .FirstOrDefaultAsync(ti => ti.Token == token);

            if (invitation == null)
                throw new InvalidOperationException("Invalid invitation token");

            if (invitation.Status != InvitationStatus.Pending)
                throw new InvalidOperationException("Invitation is no longer pending");

            if (invitation.ExpiresAt < DateTime.Now)
                throw new InvalidOperationException("Invitation has expired");

            // Find user by email
            var user = await _unitOfWork.Users
                .FirstOrDefaultAsync(u => u.Email == invitation.Email);

            if (user == null)
                throw new InvalidOperationException("User not found. Please register first.");

            // Check if already a member
            var existingMember = await _unitOfWork.TeamMembers
                .FirstOrDefaultAsync(tm => tm.TeamId == invitation.TeamId 
                    && tm.UserId == user.UserId 
                    && tm.IsActive);

            if (existingMember != null)
                throw new InvalidOperationException("You are already a member of this team");

            // Add user as team member
            var teamMember = new ProjectTracker.Core.Entities.TeamMember
            {
                TeamId = invitation.TeamId,
                UserId = user.UserId,
                Role = invitation.ProposedRole,
                JoinedAt = DateTime.Now,
                IsActive = true
            };

            await _unitOfWork.TeamMembers.AddAsync(teamMember);

            // Update invitation status
            invitation.Status = InvitationStatus.Accepted;
            invitation.RespondedAt = DateTime.Now;

            _unitOfWork.TeamInvitations.Update(invitation);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Decline invitation using token
        /// </summary>
        public async Task<bool> DeclineInvitationAsync(string token)
        {
            var invitation = await _unitOfWork.TeamInvitations
                .FirstOrDefaultAsync(ti => ti.Token == token);

            if (invitation == null)
                throw new InvalidOperationException("Invalid invitation token");

            if (invitation.Status != InvitationStatus.Pending)
                throw new InvalidOperationException("Invitation is no longer pending");

            // Update invitation status
            invitation.Status = InvitationStatus.Declined;
            invitation.RespondedAt = DateTime.Now;

            _unitOfWork.TeamInvitations.Update(invitation);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        // ========================
        // PRIVATE HELPER METHODS
        // ========================

        /// <summary>
        /// Generate unique invitation token
        /// </summary>
        private string GenerateInvitationToken()
        {
            return Guid.NewGuid().ToString("N") + DateTime.Now.Ticks.ToString("x");
        }

        /// <summary>
        /// Convert TeamInvitation entity to DTO
        /// </summary>
        private async Task<TeamInvitationDto> GetInvitationDto(ProjectTracker.Core.Entities.TeamInvitation invitation)
        {
            var team = await _unitOfWork.Teams.GetByIdAsync(invitation.TeamId);
            var invitedBy = await _unitOfWork.Users.GetByIdAsync(invitation.InvitedByUserId);

            return new TeamInvitationDto
            {
                InvitationId = invitation.InvitationId,
                TeamId = invitation.TeamId,
                TeamName = team?.TeamName ?? "Unknown",
                Email = invitation.Email,
                InvitedByUserId = invitation.InvitedByUserId,
                InvitedByName = invitedBy?.FullName ?? "Unknown",
                ProposedRole = invitation.ProposedRole,
                Status = invitation.Status,
                StatusName = invitation.Status.ToString(),
                SentAt = invitation.SentAt,
                ExpiresAt = invitation.ExpiresAt
            };
        }
    }
}
