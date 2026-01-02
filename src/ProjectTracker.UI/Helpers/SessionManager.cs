using ProjectTracker.Business.DTOs;

namespace ProjectTracker.UI.Helpers
{
    /// <summary>
    /// Static session manager for tracking logged-in user state
    /// Provides role-based access control helpers
    /// </summary>
    public static class SessionManager
    {
        #region Properties

        /// <summary>
        /// Currently logged-in user
        /// </summary>
        public static UserDto? CurrentUser { get; private set; }

        /// <summary>
        /// Check if user is logged in
        /// </summary>
        public static bool IsLoggedIn => CurrentUser != null;

        /// <summary>
        /// Current user's ID (0 if not logged in)
        /// </summary>
        public static int CurrentUserId => CurrentUser?.UserId ?? 0;

        /// <summary>
        /// Current user's role ID (0 if not logged in)
        /// </summary>
        public static int CurrentRoleId => CurrentUser?.RoleId ?? 0;

        /// <summary>
        /// Current user's role name (empty if not logged in)
        /// </summary>
        public static string CurrentRoleName => CurrentUser?.RoleName ?? string.Empty;

        /// <summary>
        /// Current user's full name (empty if not logged in)
        /// </summary>
        public static string CurrentUserFullName => CurrentUser?.FullName ?? string.Empty;

        /// <summary>
        /// Current user's email (empty if not logged in)
        /// </summary>
        public static string CurrentUserEmail => CurrentUser?.Email ?? string.Empty;

        #endregion

        #region Role Check Properties

        /// <summary>
        /// Check if current user is Admin (RoleId = 1)
        /// </summary>
        public static bool IsAdmin => CurrentRoleId == 1;

        /// <summary>
        /// Check if current user is Project Manager (RoleId = 2)
        /// </summary>
        public static bool IsProjectManager => CurrentRoleId == 2;

        /// <summary>
        /// Check if current user is Developer (RoleId = 3)
        /// </summary>
        public static bool IsDeveloper => CurrentRoleId == 3;

        /// <summary>
        /// Check if current user is Pending (RoleId = 4)
        /// </summary>
        public static bool IsPending => CurrentRoleId == 4;

        /// <summary>
        /// Check if user has management access (Admin or ProjectManager)
        /// </summary>
        public static bool HasManagementAccess => IsAdmin || IsProjectManager;

        /// <summary>
        /// Check if user has full system access (Admin only)
        /// </summary>
        public static bool HasFullAccess => IsAdmin;

        #endregion

        #region Methods

        /// <summary>
        /// Set current user after successful login
        /// </summary>
        /// <param name="user">Logged-in user DTO</param>
        public static void Login(UserDto user)
        {
            CurrentUser = user;
            System.Diagnostics.Debug.WriteLine($"✅ SESSION: User logged in - {user.Username} (Role: {user.RoleName})");
        }

        /// <summary>
        /// Clear current user session (logout)
        /// </summary>
        public static void Logout()
        {
            var username = CurrentUser?.Username ?? "Unknown";
            CurrentUser = null;
            System.Diagnostics.Debug.WriteLine($"🚪 SESSION: User logged out - {username}");
        }

        /// <summary>
        /// Check if current user has specific role
        /// </summary>
        /// <param name="roleId">Role ID to check</param>
        /// <returns>True if user has the specified role</returns>
        public static bool HasRole(int roleId)
        {
            return CurrentRoleId == roleId;
        }

        /// <summary>
        /// Check if current user has any of the specified roles
        /// </summary>
        /// <param name="roleIds">Role IDs to check</param>
        /// <returns>True if user has any of the specified roles</returns>
        public static bool HasAnyRole(params int[] roleIds)
        {
            return roleIds.Contains(CurrentRoleId);
        }

        #endregion
    }
}
