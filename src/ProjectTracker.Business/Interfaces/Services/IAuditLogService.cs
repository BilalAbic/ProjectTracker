using ProjectTracker.Business.DTOs;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// Service for logging and retrieving activity logs
    /// </summary>
    public interface IAuditLogService
    {
        /// <summary>
        /// Log an activity
        /// </summary>
        System.Threading.Tasks.Task LogActivityAsync(
            ActivityType activityType,
            string tableName,
            int recordId,
            int userId,
            string? oldValues = null,
            string? newValues = null,
            int? teamId = null);
        
        /// <summary>
        /// Get recent activities for admin (all activities)
        /// </summary>
        System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetAllRecentActivitiesAsync(int count = 20);
        
        /// <summary>
        /// Get recent activities for specific teams (for non-admin users)
        /// </summary>
        System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetTeamActivitiesAsync(IEnumerable<int> teamIds, int count = 20);
        
        /// <summary>
        /// Get recent activities for current user based on role
        /// </summary>
        System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetUserRecentActivitiesAsync(int userId, bool isAdmin, int count = 20);
        
        /// <summary>
        /// Get activities for a specific project
        /// </summary>
        System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetProjectActivitiesAsync(int projectId, int count = 50);
        
        /// <summary>
        /// Get activities for a specific task
        /// </summary>
        System.Threading.Tasks.Task<IEnumerable<ActivityDto>> GetTaskActivitiesAsync(int taskId, int count = 20);
    }
}
