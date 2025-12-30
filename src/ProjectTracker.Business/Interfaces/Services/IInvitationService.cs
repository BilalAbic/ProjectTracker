using ProjectTracker.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// Invitation service interface - handles team invitation business logic
    /// </summary>
    public interface IInvitationService
    {
        /// <summary>
        /// Send team invitation
        /// </summary>
        Task<TeamInvitationDto> SendInvitationAsync(TeamInvitationDto invitationDto);

        /// <summary>
        /// Get all invitations for a team
        /// </summary>
        Task<IEnumerable<TeamInvitationDto>> GetTeamInvitationsAsync(int teamId);

        /// <summary>
        /// Resend invitation
        /// </summary>
        Task<bool> ResendInvitationAsync(int invitationId);

        /// <summary>
        /// Cancel invitation
        /// </summary>
        Task<bool> CancelInvitationAsync(int invitationId);

        /// <summary>
        /// Accept invitation using token
        /// </summary>
        Task<bool> AcceptInvitationAsync(string token);

        /// <summary>
        /// Decline invitation using token
        /// </summary>
        Task<bool> DeclineInvitationAsync(string token);
    }
}
