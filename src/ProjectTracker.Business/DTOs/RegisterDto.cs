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
        
        /// <summary>
        /// Invitation token (if registering via invitation)
        /// If null/empty, user will be assigned Pending role
        /// </summary>
        public string? InvitationToken { get; set; }
        
        /// <summary>
        /// Role ID - will be determined by service based on invitation
        /// Default: 4 (Pending) if no invitation token
        /// </summary>
        public int RoleId { get; set; } = 4; // Default: Pending
    }
}
