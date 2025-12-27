namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for Login
    /// </summary>
    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}