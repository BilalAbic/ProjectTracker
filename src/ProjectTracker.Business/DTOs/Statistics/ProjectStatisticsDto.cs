using System;

namespace ProjectTracker.Business.DTOs.Statistics
{
    /// <summary>
    /// Project statistics data transfer object
    /// Provides aggregated statistics about projects
    /// </summary>
    public class ProjectStatisticsDto
    {
        /// <summary>
        /// Total number of projects
        /// </summary>
        public int TotalProjects { get; set; }
        
        /// <summary>
        /// Number of active projects
        /// </summary>
        public int ActiveProjects { get; set; }
        
        /// <summary>
        /// Number of completed projects
        /// </summary>
        public int CompletedProjects { get; set; }
        
        /// <summary>
        /// Number of projects on hold
        /// </summary>
        public int OnHoldProjects { get; set; }
        
        /// <summary>
        /// Number of cancelled projects
        /// </summary>
        public int CancelledProjects { get; set; }
        
        /// <summary>
        /// Average completion rate across all projects (0-100)
        /// </summary>
        public double AverageCompletionRate { get; set; }
    }
}
