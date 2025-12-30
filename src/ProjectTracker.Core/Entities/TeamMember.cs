using System;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a user's membership in a team
    /// </summary>
    public class TeamMember
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int TeamMemberId { get; set; }

        /// <summary>
        /// Team ID
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Role in this team (Owner, Admin, Member, Observer)
        /// </summary>
        public TeamRole Role { get; set; } = TeamRole.Developer;

        /// <summary>
        /// Join date
        /// </summary>
        public DateTime JoinedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Is active member
        /// </summary>
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual Team Team { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
