using System;
using System.Collections.Generic;

namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a team/workspace in the system
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Team name
        /// </summary>
        public string TeamName { get; set; } = string.Empty;

        /// <summary>
        /// Team description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// User who created this team (Team Owner)
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Is team active
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Team creation date
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Last update date
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public virtual User Owner { get; set; } = null!;
        public virtual ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        public virtual ICollection<TeamInvitation> Invitations { get; set; } = new List<TeamInvitation>();
    }
}
