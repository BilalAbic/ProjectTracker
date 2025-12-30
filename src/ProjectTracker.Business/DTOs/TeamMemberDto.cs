using System;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for TeamMember entity
    /// </summary>
    public class TeamMemberDto
    {
        /// <summary>
        /// Team member identifier
        /// </summary>
        public int TeamMemberId { get; set; }

        /// <summary>
        /// Team identifier
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// User full name
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// User email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Team role (enum)
        /// </summary>
        public TeamRole Role { get; set; }

        /// <summary>
        /// Team role name (string representation)
        /// </summary>
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// Join date
        /// </summary>
        public DateTime JoinedAt { get; set; }

        /// <summary>
        /// Is active member
        /// </summary>
        public bool IsActive { get; set; }
    }
}
