using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// Service for managing GitHub token pool
    /// Tokens are pooled from all users for shared API rate limits
    /// </summary>
    public class TokenPoolService : ITokenPoolService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        // Simple encryption key - in production, use Azure Key Vault or similar
        private static readonly byte[] EncryptionKey = Encoding.UTF8.GetBytes("ProjectTracker2025GitHubKey!!");

        public TokenPoolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc/>
        public async Task<string?> GetBestTokenAsync()
        {
            var token = await _unitOfWork.GitHubTokens.GetBestAvailableTokenAsync();
            if (token == null)
                return null;

            return DecryptToken(token.EncryptedToken);
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task UpdateRateLimitAsync(int tokenId, int remaining, DateTime? resetAt)
        {
            await _unitOfWork.GitHubTokens.UpdateRateLimitAsync(tokenId, remaining, resetAt);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitHubTokenDto>> GetUserTokensAsync(int userId)
        {
            var tokens = await _unitOfWork.GitHubTokens.GetByUserIdAsync(userId);
            return tokens.Select(MapToDto);
        }

        /// <inheritdoc/>
        public async Task<GitHubTokenDto> AddTokenAsync(int userId, SaveGitHubTokenDto dto)
        {
            var token = new GitHubToken
            {
                UserId = userId,
                EncryptedToken = EncryptToken(dto.Token),
                GitHubUsername = dto.GitHubUsername,
                RateLimitRemaining = 5000,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.GitHubTokens.AddAsync(token);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(token);
        }

        /// <inheritdoc/>
        public async Task<bool> RemoveTokenAsync(int tokenId, int userId)
        {
            var token = await _unitOfWork.GitHubTokens.GetByIdAsync(tokenId);
            if (token == null || token.UserId != userId)
                return false;

            _unitOfWork.GitHubTokens.Remove(token);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        public async Task<(int TotalTokens, int TotalRateLimit)> GetPoolStatusAsync()
        {
            var tokens = await _unitOfWork.GitHubTokens.GetActiveTokensAsync();
            var tokenList = tokens.ToList();
            return (tokenList.Count, tokenList.Sum(t => t.RateLimitRemaining));
        }

        #region Private Methods

        private static GitHubTokenDto MapToDto(GitHubToken token)
        {
            return new GitHubTokenDto
            {
                GitHubTokenId = token.GitHubTokenId,
                UserId = token.UserId,
                GitHubUsername = token.GitHubUsername,
                RateLimitRemaining = token.RateLimitRemaining,
                RateLimitResetAt = token.RateLimitResetAt,
                IsActive = token.IsActive,
                LastUsedAt = token.LastUsedAt,
                CreatedAt = token.CreatedAt
            };
        }

        private static string EncryptToken(string plainToken)
        {
            // Simple Base64 encoding with XOR - for demo purposes
            // In production, use proper AES encryption with secure key management
            var bytes = Encoding.UTF8.GetBytes(plainToken);
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] ^= EncryptionKey[i % EncryptionKey.Length];
            }
            return Convert.ToBase64String(bytes);
        }

        private static string DecryptToken(string encryptedToken)
        {
            var bytes = Convert.FromBase64String(encryptedToken);
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] ^= EncryptionKey[i % EncryptionKey.Length];
            }
            return Encoding.UTF8.GetString(bytes);
        }

        #endregion
    }
}
