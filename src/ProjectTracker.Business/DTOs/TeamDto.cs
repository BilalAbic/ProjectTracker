using System;

namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for Team entity
    /// </summary>
    public class TeamDto
    {
        /// <summary>
        /// Team identifier
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
        /// Owner user ID
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Owner full name
        /// </summary>
        public string OwnerName { get; set; } = string.Empty;

        /// <summary>
        /// Number of team members
        /// </summary>
        public int MemberCount { get; set; }

        /// <summary>
        /// Number of projects in this team
        /// </summary>
        public int ProjectCount { get; set; }

        /// <summary>
        /// Is team active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Team creation date
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
