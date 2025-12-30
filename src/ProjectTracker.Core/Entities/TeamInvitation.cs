using System;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents an invitation to join a team
    /// </summary>
    public class TeamInvitation
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int InvitationId { get; set; }

        /// <summary>
        /// Team ID
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Invitee email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// User who sent the invitation
        /// </summary>
        public int InvitedByUserId { get; set; }

        /// <summary>
        /// Proposed role for invitee
        /// </summary>
        public TeamRole ProposedRole { get; set; } = TeamRole.Developer;

        /// <summary>
        /// Invitation status
        /// </summary>
        public InvitationStatus Status { get; set; } = InvitationStatus.Pending;

        /// <summary>
        /// Unique invitation token (for security)
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Invitation sent date
        /// </summary>
        public DateTime SentAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Invitation expiration date
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Response date (accepted/declined)
        /// </summary>
        public DateTime? RespondedAt { get; set; }

        // Navigation Properties
        public virtual Team Team { get; set; } = null!;
        public virtual User InvitedBy { get; set; } = null!;
    }
}
