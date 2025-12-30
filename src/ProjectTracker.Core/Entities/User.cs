namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a user in the Project Tracker system
    /// </summary>
    public class User
    {
        /// <summary>
        /// Primary key - Unique identifier for the user
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Foreign key - Links to Role table
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Username for login
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Hashed password (never store plain text passwords!)
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// User's full name
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Is the user account active?
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// When was this user created?
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Navigation property - User's role
        /// </summary>
        public virtual Role Role { get; set; } = null!;

        /// <summary>
        /// Navigation property - Projects created by this user
        /// </summary>
        public virtual ICollection<Project> CreatedProjects { get; set; } = new List<Project>();

        /// <summary>
        /// Navigation property - Tasks assigned to this user
        /// </summary>
        public virtual ICollection<Task> AssignedTasks { get; set; } = new List<Task>();

        /// <summary>
        /// Navigation property - Team memberships
        /// </summary>
        public virtual ICollection<ProjectTeamMember> TeamMemberships { get; set; } = new List<ProjectTeamMember>();

        /// <summary>
        /// Navigation property - Notifications for this user
        /// </summary>
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        /// <summary>
        /// Navigation property - Comments created by this user
        /// </summary>
        public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();

        /// <summary>
        /// Navigation property - Teams owned by this user
        /// </summary>
        public virtual ICollection<Team> OwnedTeams { get; set; } = new List<Team>();

        /// <summary>
        /// Navigation property - Team memberships for this user (new team system)
        /// </summary>
        public virtual ICollection<TeamMember> TeamMemberships_New { get; set; } = new List<TeamMember>();

        /// <summary>
        /// Navigation property - Team invitations sent by this user
        /// </summary>
        public virtual ICollection<TeamInvitation> SentInvitations { get; set; } = new List<TeamInvitation>();
    }
}