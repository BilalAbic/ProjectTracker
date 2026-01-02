namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// DTO for displaying recent activities in dashboard
    /// </summary>
    public class ActivityDto
    {
        public int LogId { get; set; }
        
        /// <summary>
        /// User who performed the action
        /// </summary>
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        
        /// <summary>
        /// Action type: TaskCompleted, TaskAssigned, ProjectCreated, etc.
        /// </summary>
        public string ActionType { get; set; } = string.Empty;
        
        /// <summary>
        /// Human-readable action description
        /// Example: "completed task", "assigned task to", "created project"
        /// </summary>
        public string ActionDescription { get; set; } = string.Empty;
        
        /// <summary>
        /// Target entity name (Task name, Project name, etc.)
        /// </summary>
        public string TargetName { get; set; } = string.Empty;
        
        /// <summary>
        /// Related project name (if applicable)
        /// </summary>
        public string? ProjectName { get; set; }
        
        /// <summary>
        /// Related team ID (for filtering)
        /// </summary>
        public int? TeamId { get; set; }
        
        /// <summary>
        /// When the action occurred
        /// </summary>
        public DateTime PerformedAt { get; set; }
        
        /// <summary>
        /// Icon for UI display
        /// </summary>
        public string Icon { get; set; } = "📝";
        
        /// <summary>
        /// Relative time string: "2 minutes ago", "1 hour ago"
        /// </summary>
        public string RelativeTime => GetRelativeTime();
        
        private string GetRelativeTime()
        {
            var diff = DateTime.Now - PerformedAt;
            if (diff.TotalMinutes < 1) return "just now";
            if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes} min ago";
            if (diff.TotalHours < 24) return $"{(int)diff.TotalHours} hours ago";
            if (diff.TotalDays < 7) return $"{(int)diff.TotalDays} days ago";
            return PerformedAt.ToString("dd MMM yyyy");
        }
    }
}
