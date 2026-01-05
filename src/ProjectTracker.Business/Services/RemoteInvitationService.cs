using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// Uzak API'ye davet gönderen servis
    /// WinForms'tan davet oluşturulduğunda hem yerel DB'ye hem uzak API'ye yazar
    /// </summary>
    public class RemoteInvitationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly bool _isEnabled;

        public RemoteInvitationService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = configuration["RemoteApi:BaseUrl"] ?? "https://bilalabic.com/api";
            _isEnabled = bool.Parse(configuration["RemoteApi:Enabled"] ?? "false");
        }

        /// <summary>
        /// Uzak API'ye davet gönder
        /// </summary>
        public async Task<bool> SendInvitationToRemoteAsync(
            string token,
            string email,
            string teamName,
            string invitedByName,
            string proposedRole,
            DateTime expiresAt)
        {
            if (!_isEnabled)
            {
                System.Diagnostics.Debug.WriteLine("📡 Remote API disabled, skipping...");
                return true;
            }

            try
            {
                var payload = new
                {
                    token = token,
                    email = email,
                    teamName = teamName,
                    invitedByName = invitedByName,
                    proposedRole = proposedRole,
                    expiresAt = expiresAt
                };

                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_apiBaseUrl}/invitations/create", content);
                
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"✅ Remote invitation sent: {email}");
                    return true;
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"❌ Remote invitation failed: {error}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Remote API error: {ex.Message}");
                return false;
            }
        }
    }
}
