using ProjectTracker.Business.DTOs.Analytics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// Advanced analytics service interface
    /// Provides burndown, EVM, velocity, and financial reporting capabilities
    /// </summary>
    public interface IAdvancedReportService
    {
        // ====================================
        // BURNDOWN & BURNUP CHARTS
        // ====================================
        
        /// <summary>
        /// Get burndown chart data for a project
        /// Shows ideal vs actual remaining hours trend
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <returns>Burndown chart DTO with daily data points</returns>
        Task<BurndownChartDto> GetProjectBurndownAsync(int projectId);
        
        // ====================================
        // EARNED VALUE MANAGEMENT (EVM)
        // ====================================
        
        /// <summary>
        /// Get EVM analysis for a specific project
        /// Calculates CPI, SPI, CV, SV, EAC metrics
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <returns>Earned Value DTO with all EVM metrics</returns>
        Task<EarnedValueDto> GetEarnedValueAnalysisAsync(int projectId);
        
        /// <summary>
        /// Get EVM analysis for all active projects (portfolio level)
        /// </summary>
        /// <param name="projectIds">Optional project IDs to filter (for role-based filtering)</param>
        /// <returns>List of Earned Value DTOs</returns>
        Task<List<EarnedValueDto>> GetPortfolioEarnedValueAsync(IEnumerable<int>? projectIds = null);
        
        // ====================================
        // VELOCITY TRACKING
        // ====================================
        
        /// <summary>
        /// Get team velocity trend (weekly productivity)
        /// </summary>
        /// <param name="teamId">Team ID</param>
        /// <param name="numberOfWeeks">Number of weeks to analyze (default: 12)</param>
        /// <returns>Velocity DTO with weekly data points</returns>
        Task<VelocityDto> GetTeamVelocityAsync(int teamId, int numberOfWeeks = 12);
        
        /// <summary>
        /// Get velocity for all teams
        /// </summary>
        /// <param name="numberOfWeeks">Number of weeks to analyze</param>
        /// <returns>List of Velocity DTOs for all teams</returns>
        Task<List<VelocityDto>> GetAllTeamsVelocityAsync(int numberOfWeeks = 12);
        
        // ====================================
        // FINANCIAL ANALYTICS
        // ====================================
        
        /// <summary>
        /// Get financial overview for all projects
        /// Portfolio-level budget and cost analysis
        /// </summary>
        /// <param name="startDate">Optional start date filter</param>
        /// <param name="endDate">Optional end date filter</param>
        /// <param name="projectIds">Optional project IDs to filter (for role-based filtering)</param>
        /// <returns>Financial overview DTO</returns>
        Task<FinancialOverviewDto> GetFinancialOverviewAsync(DateTime? startDate = null, DateTime? endDate = null, IEnumerable<int>? projectIds = null);
        
        /// <summary>
        /// Get detailed cost breakdown for a specific project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <returns>Cost breakdown DTO with user, task, and time-based distributions</returns>
        Task<CostBreakdownDto> GetCostBreakdownByProjectAsync(int projectId);
        
        /// <summary>
        /// Get detailed cost breakdown for a specific team
        /// </summary>
        /// <param name="teamId">Team ID</param>
        /// <returns>Cost breakdown DTO for team</returns>
        Task<CostBreakdownDto> GetCostBreakdownByTeamAsync(int teamId);
        
        // ====================================
        // BACKGROUND JOBS & UTILITIES
        // ====================================
        
        /// <summary>
        /// Create daily snapshots for all active projects
        /// Should be called by background job every day at 23:59
        /// </summary>
        /// <returns>Number of snapshots created</returns>
        Task<int> CreateDailySnapshotsAsync();
        
        /// <summary>
        /// Recalculate and update project metrics (ActualCost, etc.)
        /// </summary>
        /// <param name="projectId">Project ID</param>
        Task RecalculateProjectMetricsAsync(int projectId);
    }
}
