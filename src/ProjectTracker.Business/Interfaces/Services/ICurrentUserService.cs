namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// Interface for accessing current user information
    /// Implemented by UI layer to provide session data to business services
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Current logged-in user's ID
        /// </summary>
        int CurrentUserId { get; }
        
        /// <summary>
        /// Current logged-in user's role ID
        /// </summary>
        int CurrentRoleId { get; }
        
        /// <summary>
        /// Check if user is logged in
        /// </summary>
        bool IsLoggedIn { get; }
        
        /// <summary>
        /// Check if current user is Admin
        /// </summary>
        bool IsAdmin { get; }
        
        /// <summary>
        /// Check if current user is Project Manager
        /// </summary>
        bool IsProjectManager { get; }
        
        /// <summary>
        /// Check if current user has management access (Admin or ProjectManager)
        /// </summary>
        bool HasManagementAccess { get; }
    }
}
