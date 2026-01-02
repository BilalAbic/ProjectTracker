using ProjectTracker.Core.Enums;
using System.Collections.Generic;

namespace ProjectTracker.Business.DTOs.Statistics
{
    /// <summary>
    /// Task statistics data transfer object
    /// Provides aggregated statistics about tasks
    /// </summary>
    public class TaskStatisticsDto
    {
        /// <summary>
        /// Total number of tasks
        /// </summary>
        public int TotalTasks { get; set; }
        
        /// <summary>
        /// Number of completed tasks
        /// </summary>
        public int CompletedTasks { get; set; }
        
        /// <summary>
        /// Number of tasks in progress
        /// </summary>
        public int InProgressTasks { get; set; }
        
        /// <summary>
        /// Number of tasks to do
        /// </summary>
        public int TodoTasks { get; set; }
        
        /// <summary>
        /// Number of overdue tasks
        /// </summary>
        public int OverdueTasks { get; set; }
        
        /// <summary>
        /// Task count grouped by priority
        /// </summary>
        public Dictionary<Priority, int> TasksByPriority { get; set; } = new Dictionary<Priority, int>();
    }
}
