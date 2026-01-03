using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces.Repositories
{
    /// <summary>
    /// Repository interface for GitHub Token operations
    /// </summary>
    public interface IGitHubTokenRepository : IRepository<GitHubToken>
    {
        /// <summary>
        /// Get all active tokens for the token pool
        /// </summary>
        Task<IEnumerable<GitHubToken>> GetActiveTokensAsync();

        /// <summary>
        /// Get tokens by user ID
        /// </summary>
        Task<IEnumerable<GitHubToken>> GetByUserIdAsync(int userId);

        /// <summary>
        /// Get the best available token (highest rate limit remaining)
        /// </summary>
        Task<GitHubToken?> GetBestAvailableTokenAsync();

        /// <summary>
        /// Update token rate limit info after API call
        /// </summary>
        System.Threading.Tasks.Task UpdateRateLimitAsync(int tokenId, int remaining, DateTime? resetAt);
    }
}
