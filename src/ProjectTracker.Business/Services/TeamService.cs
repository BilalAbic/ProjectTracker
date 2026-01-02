using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    /// Team service implementation - handles team business logic
    /// </summary>
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAuditLogService _auditLogService;

        public TeamService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ICurrentUserService currentUserService,
            IAuditLogService auditLogService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _auditLogService = auditLogService;
        }
        
        /// <summary>
        /// Get current user ID from session
        /// </summary>
        private int CurrentUserId => _currentUserService.CurrentUserId;

        /// <summary>
        /// Get all teams in the system (Admin only)
        /// </summary>
        public async Task<IEnumerable<TeamDto>> GetAllTeamsAsync()
        {
            var teams = await _unitOfWork.Teams.FindAsync(t => t.IsActive);

            var teamDtos = new List<TeamDto>();
            foreach (var team in teams)
            {
                var owner = await _unitOfWork.Users.GetByIdAsync(team.OwnerId);
                var memberCount = await _unitOfWork.TeamMembers
                    .CountAsync(tm => tm.TeamId == team.TeamId && tm.IsActive);
                var projectCount = await _unitOfWork.Projects
                    .CountAsync(p => p.TeamId == team.TeamId);

                teamDtos.Add(new TeamDto
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    Description = team.Description,
                    OwnerId = team.OwnerId,
                    OwnerName = owner?.FullName ?? "Unknown",
                    MemberCount = memberCount,
                    ProjectCount = projectCount,
                    IsActive = team.IsActive,
                    CreatedAt = team.CreatedAt
                });
            }

            return teamDtos;
        }

        /// <summary>
        /// Get all teams for the current user
        /// </summary>
        public async Task<IEnumerable<TeamDto>> GetUserTeamsAsync()
        {
            // Get teams where user is owner or member
            var userTeams = await _unitOfWork.TeamMembers
                .FindAsync(tm => tm.UserId == CurrentUserId && tm.IsActive);

            var teamIds = userTeams.Select(tm => tm.TeamId).ToList();

            var teams = await _unitOfWork.Teams
                .FindAsync(t => teamIds.Contains(t.TeamId) && t.IsActive);

            var teamDtos = new List<TeamDto>();
            foreach (var team in teams)
            {
                var owner = await _unitOfWork.Users.GetByIdAsync(team.OwnerId);
                var memberCount = await _unitOfWork.TeamMembers
                    .CountAsync(tm => tm.TeamId == team.TeamId && tm.IsActive);
                var projectCount = await _unitOfWork.Projects
                    .CountAsync(p => p.TeamId == team.TeamId);

                teamDtos.Add(new TeamDto
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    Description = team.Description,
                    OwnerId = team.OwnerId,
                    OwnerName = owner?.FullName ?? "Unknown",
                    MemberCount = memberCount,
                    ProjectCount = projectCount,
                    IsActive = team.IsActive,
                    CreatedAt = team.CreatedAt
                });
            }

            return teamDtos;
        }

        /// <summary>
        /// Get the active team for the current user
        /// </summary>
        public async Task<TeamDto?> GetActiveTeamAsync()
        {
            // TODO: Implement user preferences to store active team
            // For now, return the first team
            var teams = await GetUserTeamsAsync();
            return teams.FirstOrDefault();
        }

        /// <summary>
        /// Get team by ID
        /// </summary>
        public async Task<TeamDto?> GetTeamByIdAsync(int teamId)
        {
            var team = await _unitOfWork.Teams.GetByIdAsync(teamId);
            if (team == null)
                return null;

            var owner = await _unitOfWork.Users.GetByIdAsync(team.OwnerId);
            var memberCount = await _unitOfWork.TeamMembers
                .CountAsync(tm => tm.TeamId == team.TeamId && tm.IsActive);
            var projectCount = await _unitOfWork.Projects
                .CountAsync(p => p.TeamId == team.TeamId);

            return new TeamDto
            {
                TeamId = team.TeamId,
                TeamName = team.TeamName,
                Description = team.Description,
                OwnerId = team.OwnerId,
                OwnerName = owner?.FullName ?? "Unknown",
                MemberCount = memberCount,
                ProjectCount = projectCount,
                IsActive = team.IsActive,
                CreatedAt = team.CreatedAt
            };
        }

        /// <summary>
        /// Create new team
        /// </summary>
        public async Task<TeamDto> CreateTeamAsync(CreateTeamDto createDto)
        {
            // Create team entity
            var team = new ProjectTracker.Core.Entities.Team
            {
                TeamName = createDto.TeamName,
                Description = createDto.Description,
                OwnerId = CurrentUserId,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.Teams.AddAsync(team);
            await _unitOfWork.SaveChangesAsync();

            // Add owner as team member with Owner role
            var ownerMember = new ProjectTracker.Core.Entities.TeamMember
            {
                TeamId = team.TeamId,
                UserId = CurrentUserId,
                Role = TeamRole.Owner,
                JoinedAt = DateTime.Now,
                IsActive = true
            };

            await _unitOfWork.TeamMembers.AddAsync(ownerMember);
            await _unitOfWork.SaveChangesAsync();

            // Log activity (fire-and-forget)
            var teamId = team.TeamId;
            _ = System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    await _auditLogService.LogActivityAsync(
                        ActivityType.TeamCreated,
                        "Teams",
                        teamId,
                        CurrentUserId,
                        teamId: teamId);
                }
                catch { /* Ignore */ }
            });

            return await GetTeamByIdAsync(team.TeamId) ?? new TeamDto { TeamId = team.TeamId, TeamName = team.TeamName };
        }

        /// <summary>
        /// Update team
        /// </summary>
        public async Task<TeamDto> UpdateTeamAsync(UpdateTeamDto updateDto)
        {
            var team = await _unitOfWork.Teams.GetByIdAsync(updateDto.TeamId);
            if (team == null)
                throw new InvalidOperationException("Team not found");

            // Check if user has permission (owner or admin)
            var member = await _unitOfWork.TeamMembers
                .FirstOrDefaultAsync(tm => tm.TeamId == updateDto.TeamId 
                    && tm.UserId == CurrentUserId 
                    && tm.IsActive);

            if (member == null || (member.Role != TeamRole.Owner && member.Role != TeamRole.Admin))
                throw new UnauthorizedAccessException("You don't have permission to update this team");

            team.TeamName = updateDto.TeamName;
            team.Description = updateDto.Description;
            team.UpdatedAt = DateTime.Now;

            _unitOfWork.Teams.Update(team);
            await _unitOfWork.SaveChangesAsync();

            // Log activity (fire-and-forget)
            var teamId = team.TeamId;
            _ = System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    await _auditLogService.LogActivityAsync(
                        ActivityType.TeamUpdated,
                        "Teams",
                        teamId,
                        CurrentUserId,
                        teamId: teamId);
                }
                catch { /* Ignore */ }
            });

            return await GetTeamByIdAsync(team.TeamId) ?? new TeamDto { TeamId = team.TeamId, TeamName = team.TeamName };
        }

        /// <summary>
        /// Delete team (soft delete)
        /// </summary>
        public async Task<bool> DeleteTeamAsync(int teamId)
        {
            var team = await _unitOfWork.Teams.GetByIdAsync(teamId);
            if (team == null)
                return false;

            // Only owner can delete team
            if (team.OwnerId != CurrentUserId)
                throw new UnauthorizedAccessException("Only team owner can delete the team");

            team.IsActive = false;
            team.UpdatedAt = DateTime.Now;

            _unitOfWork.Teams.Update(team);
            await _unitOfWork.SaveChangesAsync();

            // Log activity (fire-and-forget)
            _ = System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    await _auditLogService.LogActivityAsync(
                        ActivityType.TeamDeleted,
                        "Teams",
                        teamId,
                        CurrentUserId,
                        teamId: teamId);
                }
                catch { /* Ignore */ }
            });

            return true;
        }

        /// <summary>
        /// Set active team for the current user
        /// </summary>
        public async Task SetActiveTeamAsync(int teamId)
        {
            // Verify user is member of this team
            var member = await _unitOfWork.TeamMembers
                .FirstOrDefaultAsync(tm => tm.TeamId == teamId 
                    && tm.UserId == CurrentUserId 
                    && tm.IsActive);

            if (member == null)
                throw new InvalidOperationException("You are not a member of this team");

            // TODO: Store active team in user preferences table
            // For now, this is a placeholder
        }

        /// <summary>
        /// Get all members of a team
        /// </summary>
        public async Task<IEnumerable<TeamMemberDto>> GetTeamMembersAsync(int teamId)
        {
            var members = await _unitOfWork.TeamMembers
                .FindAsync(tm => tm.TeamId == teamId && tm.IsActive);

            var memberDtos = new List<TeamMemberDto>();
            foreach (var member in members)
            {
                var user = await _unitOfWork.Users.GetByIdAsync(member.UserId);
                if (user != null)
                {
                    memberDtos.Add(new TeamMemberDto
                    {
                        TeamMemberId = member.TeamMemberId,
                        TeamId = member.TeamId,
                        UserId = member.UserId,
                        UserName = user.FullName,
                        Email = user.Email,
                        Role = member.Role,
                        RoleName = member.Role.ToString(),
                        JoinedAt = member.JoinedAt,
                        IsActive = member.IsActive
                    });
                }
            }

            return memberDtos;
        }

        /// <summary>
        /// Update member role
        /// </summary>
        public async Task<bool> UpdateMemberRoleAsync(int teamMemberId, TeamRole newRole)
        {
            var member = await _unitOfWork.TeamMembers.GetByIdAsync(teamMemberId);
            if (member == null)
                return false;

            // Check if current user has permission (owner or admin)
            var currentUserMember = await _unitOfWork.TeamMembers
                .FirstOrDefaultAsync(tm => tm.TeamId == member.TeamId 
                    && tm.UserId == CurrentUserId 
                    && tm.IsActive);

            if (currentUserMember == null || (currentUserMember.Role != TeamRole.Owner && currentUserMember.Role != TeamRole.Admin))
                throw new UnauthorizedAccessException("You don't have permission to update member roles");

            // Owner cannot be changed
            if (member.Role == TeamRole.Owner)
                throw new InvalidOperationException("Cannot change owner role");

            var oldRole = member.Role;
            var teamId = member.TeamId;
            member.Role = newRole;
            _unitOfWork.TeamMembers.Update(member);
            await _unitOfWork.SaveChangesAsync();

            // Log activity (fire-and-forget)
            _ = System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    await _auditLogService.LogActivityAsync(
                        ActivityType.MemberRoleChanged,
                        "Teams",
                        teamId,
                        CurrentUserId,
                        oldValues: oldRole.ToString(),
                        newValues: newRole.ToString(),
                        teamId: teamId);
                }
                catch { /* Ignore */ }
            });

            return true;
        }

        /// <summary>
        /// Remove member from team
        /// </summary>
        public async Task<bool> RemoveMemberAsync(int teamMemberId)
        {
            var member = await _unitOfWork.TeamMembers.GetByIdAsync(teamMemberId);
            if (member == null)
                return false;

            // Check if current user has permission (owner or admin)
            var currentUserMember = await _unitOfWork.TeamMembers
                .FirstOrDefaultAsync(tm => tm.TeamId == member.TeamId 
                    && tm.UserId == CurrentUserId 
                    && tm.IsActive);

            if (currentUserMember == null || (currentUserMember.Role != TeamRole.Owner && currentUserMember.Role != TeamRole.Admin))
                throw new UnauthorizedAccessException("You don't have permission to remove members");

            // Owner cannot be removed
            if (member.Role == TeamRole.Owner)
                throw new InvalidOperationException("Cannot remove team owner");

            var teamId = member.TeamId;
            member.IsActive = false;
            _unitOfWork.TeamMembers.Update(member);
            await _unitOfWork.SaveChangesAsync();

            // Log activity (fire-and-forget)
            _ = System.Threading.Tasks.Task.Run(async () =>
            {
                try
                {
                    await _auditLogService.LogActivityAsync(
                        ActivityType.MemberRemoved,
                        "Teams",
                        teamId,
                        CurrentUserId,
                        teamId: teamId);
                }
                catch { /* Ignore */ }
            });

            return true;
        }
    }
}
