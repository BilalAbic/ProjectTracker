namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a user role in the system (Admin, ProjectManager, Developer, etc.)
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Primary key - Unique identifier for the role
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Name of the role (e.g., "Admin", "Project Manager")
        /// </summary>
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// Detailed description of the role and its responsibilities
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Navigation property - Users who have this role
        /// </summary>
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
