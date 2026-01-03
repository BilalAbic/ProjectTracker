using ProjectTracker.Core.Enums;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a task within a project
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Primary key - Unique identifier for the task
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Foreign key - Project this task belongs to
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Foreign key - User assigned to this task (nullable)
        /// </summary>
        public int? AssignedToUserId { get; set; }

        /// <summary>
        /// Foreign key - Parent task for subtasks (nullable)
        /// </summary>
        public int? ParentTaskId { get; set; }

        /// <summary>
        /// Name/title of the task
        /// </summary>
        public string TaskName { get; set; } = string.Empty;

        /// <summary>
        /// Detailed description of what needs to be done
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Priority level (Low, Medium, High, Critical)
        /// </summary>
        public Priority Priority { get; set; } = Priority.Medium;

        /// <summary>
        /// Current status (ToDo, InProgress, Done, Blocked)
        /// </summary>
        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        /// <summary>
        /// Estimated duration in hours
        /// </summary>
        public int? EstimatedHours { get; set; }

        /// <summary>
        /// Actual time spent in hours
        /// </summary>
        public int? ActualHours { get; set; }

        /// <summary>
        /// Task start date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Task due date
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// When was this task completed?
        /// </summary>
        public DateTime? CompletedDate { get; set; }

        /// <summary>
        /// Is this task on the critical path? (CPM Algorithm)
        /// </summary>
        public bool IsCriticalPath { get; set; } = false;

        /// <summary>
        /// When was this task created?
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Navigation property - Project this task belongs to
        /// </summary>
        public virtual Project Project { get; set; } = null!;

        /// <summary>
        /// Navigation property - User assigned to this task
        /// </summary>
        public virtual User? AssignedToUser { get; set; }

        /// <summary>
        /// Navigation property - Comments on this task
        /// </summary>
        public virtual ICollection<TaskComment> Comments { get; set; } = new List<TaskComment>();

        /// <summary>
        /// Navigation property - Time entries logged for this task
        /// </summary>
        public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();

        /// <summary>
        /// Navigation property - GitHub commits linked to this task
        /// </summary>
        public virtual ICollection<GitCommit> LinkedCommits { get; set; } = new List<GitCommit>();
    }
}