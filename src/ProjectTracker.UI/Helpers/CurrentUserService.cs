using ProjectTracker.Business.Interfaces;

namespace ProjectTracker.UI.Helpers
{
    /// <summary>
    /// Implementation of ICurrentUserService that bridges SessionManager to Business layer
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        public int CurrentUserId => SessionManager.CurrentUserId;
        
        public int CurrentRoleId => SessionManager.CurrentRoleId;
        
        public bool IsLoggedIn => SessionManager.IsLoggedIn;
        
        public bool IsAdmin => SessionManager.IsAdmin;
        
        public bool IsProjectManager => SessionManager.IsProjectManager;
        
        public bool HasManagementAccess => SessionManager.HasManagementAccess;
    }
}
