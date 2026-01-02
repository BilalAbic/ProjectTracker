using ProjectTracker.Core.Enums;

namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// DTO for updating an existing project
    /// </summary>
    public class UpdateProjectDto
    {
        /// <summary>
        /// Gets or sets the project ID
        /// </summary>
        public int ProjectId { get; set; }

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
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the priority
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// Gets or sets the budget
        /// </summary>
        public decimal? Budget { get; set; }

        /// <summary>
        /// Gets or sets the team ID that owns this project
        /// </summary>
        public int TeamId { get; set; }
    }
}
