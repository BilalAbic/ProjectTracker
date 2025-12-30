namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for user registration
    /// </summary>
    public class RegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public int RoleId { get; set; } = 3; // Default: Developer (RoleId=3)
    }
}
