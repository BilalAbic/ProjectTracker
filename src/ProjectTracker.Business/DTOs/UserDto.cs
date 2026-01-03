namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for User
    /// </summary>
    public class UserDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Department { get; set; }
        public string? GitHubUsername { get; set; }
        public string? GitHubAvatarUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation - Role Name (not full object)
        public string? RoleName { get; set; }
    }

    /// <summary>
    /// DTO for updating user profile from settings page
    /// </summary>
    public class UpdateUserDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Department { get; set; }
        public string? GitHubUsername { get; set; }
    }
}