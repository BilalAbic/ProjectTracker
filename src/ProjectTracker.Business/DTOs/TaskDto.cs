namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for Task
    /// </summary>
    public class TaskDto
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedToUserId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Priority { get; set; } = "Medium";
        public string Status { get; set; } = "Pending";
        public int? EstimatedHours { get; set; }
        public int? ActualHours { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public bool IsCriticalPath { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public string? ProjectName { get; set; }
        public string? AssignedToUserName { get; set; }
    }
}