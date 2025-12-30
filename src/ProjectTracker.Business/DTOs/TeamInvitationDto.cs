using System;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for TeamInvitation entity
    /// </summary>
    public class TeamInvitationDto
    {
        /// <summary>
        /// Invitation identifier
        /// </summary>
        public int InvitationId { get; set; }

        /// <summary>
        /// Team identifier
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Team name
        /// </summary>
        public string TeamName { get; set; } = string.Empty;

        /// <summary>
        /// Invitee email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// User ID who sent the invitation
        /// </summary>
        public int InvitedByUserId { get; set; }

        /// <summary>
        /// Name of user who sent the invitation
        /// </summary>
        public string InvitedByName { get; set; } = string.Empty;

        /// <summary>
        /// Proposed role for invitee
        /// </summary>
        public TeamRole ProposedRole { get; set; }

        /// <summary>
        /// Invitation status
        /// </summary>
        public InvitationStatus Status { get; set; }

        /// <summary>
        /// Status name (string representation)
        /// </summary>
        public string StatusName { get; set; } = string.Empty;

        /// <summary>
        /// Unique invitation token for acceptance link
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Invitation sent date
        /// </summary>
        public DateTime SentAt { get; set; }

        /// <summary>
        /// Invitation expiration date
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Is invitation expired (computed property)
        /// </summary>
        public bool IsExpired => DateTime.Now > ExpiresAt;
    }
}
