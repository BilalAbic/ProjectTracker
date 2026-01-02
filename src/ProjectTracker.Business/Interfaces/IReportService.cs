using ProjectTracker.Business.DTOs.Statistics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// Service interface for reporting and analytics
    /// Provides methods for generating statistics and exporting reports
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Get aggregated project statistics
        /// </summary>
        /// <param name="startDate">Optional start date filter</param>
        /// <param name="endDate">Optional end date filter</param>
        /// <param name="projectIds">Optional project IDs to filter (for role-based filtering)</param>
        /// <returns>Project statistics DTO</returns>
        Task<ProjectStatisticsDto> GetProjectStatisticsAsync(DateTime? startDate = null, DateTime? endDate = null, IEnumerable<int>? projectIds = null);
        
        /// <summary>
        /// Get aggregated task statistics
        /// </summary>
        /// <param name="startDate">Optional start date filter</param>
        /// <param name="endDate">Optional end date filter</param>
        /// <param name="projectIds">Optional project IDs to filter (for role-based filtering)</param>
        /// <returns>Task statistics DTO</returns>
        Task<TaskStatisticsDto> GetTaskStatisticsAsync(DateTime? startDate = null, DateTime? endDate = null, IEnumerable<int>? projectIds = null);
        
        /// <summary>
        /// Get completion trend data for the specified number of days
        /// </summary>
        /// <param name="days">Number of days to retrieve (default: 30)</param>
        /// <param name="projectIds">Optional project IDs to filter (for role-based filtering)</param>
        /// <returns>Collection of trend data points</returns>
        Task<IEnumerable<TrendDataDto>> GetCompletionTrendAsync(int days = 30, IEnumerable<int>? projectIds = null);
        
        /// <summary>
        /// Export current report data to PDF format
        /// </summary>
        /// <returns>PDF file as byte array</returns>
        Task<byte[]> ExportReportToPdfAsync();
        
        /// <summary>
        /// Export current report data to Excel format
        /// </summary>
        /// <returns>Excel file as byte array</returns>
        Task<byte[]> ExportReportToExcelAsync();
    }
}
