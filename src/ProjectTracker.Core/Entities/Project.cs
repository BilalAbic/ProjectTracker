namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a project in the system
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Primary key - Unique identifier for the project
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Foreign key - Project creator/owner
        /// </summary>
        public int CreatedByUserId { get; set; }

        /// <summary>
        /// Foreign key - Team that owns this project
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Name of the project
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;

        /// <summary>
        /// Detailed description of the project
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Project start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Expected end date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Project budget (optional)
        /// </summary>
        public decimal? Budget { get; set; }

        /// <summary>
        /// Current status (Planned, Active, OnHold, Completed, Cancelled)
        /// </summary>
        public string Status { get; set; } = "Planned";

        /// <summary>
        /// Project priority level
        /// </summary>
        public Enums.Priority Priority { get; set; } = Enums.Priority.Medium;

        /// <summary>
        /// Completion percentage (0-100)
        /// </summary>
        public decimal CompletionPercentage { get; set; } = 0;

        /// <summary>
        /// Risk score calculated by smart algorithm (0-100)
        /// </summary>
        public decimal? RiskScore { get; set; }

        /// <summary>
        /// Projeye harcanan gerçek maliyet (Actual Cost for EVM)
        /// Calculated from TimeEntry: Sum(HoursSpent * UserHourlyCost)
        /// </summary>
        public decimal ActualCost { get; set; } = 0;

        /// <summary>
        /// Başlangıç toplam planlı saat (Burndown baseline)
        /// Sum of all tasks' EstimatedHours at project start
        /// </summary>
        public decimal? TotalPlannedHours { get; set; }

        /// <summary>
        /// When was this project created?
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Last update timestamp
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        // ═══════════════════════════════════════════════════════════════
        // GitHub Integration Fields
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// GitHub repository URL (optional)
        /// Example: https://github.com/BilalAbic/ProjectTracker
        /// </summary>
        public string? GitHubRepoUrl { get; set; }

        // ═══════════════════════════════════════════════════════════════
        // Navigation Properties
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Navigation property - User who created this project
        /// </summary>
        public virtual User CreatedByUser { get; set; } = null!;

        /// <summary>
        /// Navigation property - Team that owns this project
        /// </summary>
        public virtual Team Team { get; set; } = null!;

        /// <summary>
        /// Navigation property - Tasks in this project
        /// </summary>
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();

        /// <summary>
        /// Navigation property - Team members working on this project
        /// </summary>
        public virtual ICollection<ProjectTeamMember> TeamMembers { get; set; } = new List<ProjectTeamMember>();

        /// <summary>
        /// Navigation property - Risk analysis records
        /// </summary>
        public virtual ICollection<ProjectRisk> Risks { get; set; } = new List<ProjectRisk>();

        /// <summary>
        /// Navigation property - Daily snapshots for trend analysis
        /// </summary>
        public virtual ICollection<ProjectSnapshot> Snapshots { get; set; } = new List<ProjectSnapshot>();

        /// <summary>
        /// Navigation property - Linked GitHub repository
        /// </summary>
        public virtual GitRepository? GitRepository { get; set; }
    }
}