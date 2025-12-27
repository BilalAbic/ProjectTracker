using ProjectTracker.Core.Enums;

namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for Project
    /// </summary>
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public int CreatedByUserId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Budget { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Planned;
        public decimal CompletionPercentage { get; set; }
        public decimal? RiskScore { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation - Creator Name
        public string? CreatedByUserName { get; set; }

        // Statistics
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int TeamMemberCount { get; set; }
    }
}