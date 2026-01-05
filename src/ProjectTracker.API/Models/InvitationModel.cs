namespace ProjectTracker.API.Models
{
    /// <summary>
    /// Basit davet modeli - Plesk veritabanı için
    /// </summary>
    public class InvitationModel
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public string InvitedByName { get; set; } = string.Empty;
        public string ProposedRole { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime SentAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? RespondedAt { get; set; }
    }

    /// <summary>
    /// WinForms'tan gelen davet oluşturma isteği
    /// </summary>
    public class CreateInvitationRequest
    {
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public string InvitedByName { get; set; } = string.Empty;
        public string ProposedRole { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
