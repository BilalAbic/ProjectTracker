using System;

namespace ProjectTracker.Business.DTOs.Statistics
{
    /// <summary>
    /// Trend data point for time-series charts
    /// Represents task activity for a single day
    /// </summary>
    public class TrendDataDto
    {
        /// <summary>
        /// Date of the data point
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Number of tasks completed on this date
        /// </summary>
        public int CompletedTasks { get; set; }
        
        /// <summary>
        /// Number of tasks created on this date
        /// </summary>
        public int CreatedTasks { get; set; }
    }
}
