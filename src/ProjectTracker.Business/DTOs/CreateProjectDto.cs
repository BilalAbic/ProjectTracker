using ProjectTracker.Core.Enums;

namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// DTO for creating a new project
    /// </summary>
    public class CreateProjectDto
    {
        /// <summary>
        /// Gets or sets the project name
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the project description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the project status
        /// </summary>
        public ProjectStatus Status { get; set; } = ProjectStatus.Planned;

        /// <summary>
        /// Gets or sets the priority
        /// </summary>
        public Priority Priority { get; set; } = Priority.Medium;

        /// <summary>
        /// Gets or sets the budget
        /// </summary>
        public decimal? Budget { get; set; }

        /// <summary>
        /// Gets or sets the creator user ID
        /// </summary>
        public int CreatedByUserId { get; set; }

        /// <summary>
        /// Gets or sets the team ID that owns this project
        /// </summary>
        public int TeamId { get; set; }
    }
}
