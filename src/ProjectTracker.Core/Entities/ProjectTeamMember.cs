namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a team member assigned to a project (Many-to-Many relationship)
    /// </summary>
    public class ProjectTeamMember
    {
        /// <summary>
        /// Primary key - Unique identifier
        /// </summary>
        public int TeamMemberId { get; set; }

        /// <summary>
        /// Foreign key - Project
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Foreign key - User (team member)
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Role in this specific project (e.g., "Developer", "Tester")
        /// </summary>
        public string? ProjectRole { get; set; }

        /// <summary>
        /// When was this member added to the project?
        /// </summary>
        public DateTime JoinedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Navigation property - Project
        /// </summary>
        public virtual Project Project { get; set; } = null!;

        /// <summary>
        /// Navigation property - User (team member)
        /// </summary>
        public virtual User User { get; set; } = null!;
    }
}