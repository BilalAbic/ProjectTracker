using Microsoft.EntityFrameworkCore;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Repositories;
using ProjectTracker.Data.Context;

namespace ProjectTracker.Data.Repositories
{
    /// <summary>
    /// Repository implementation for GitHub Token operations
    /// </summary>
    public class GitHubTokenRepository : Repository<GitHubToken>, IGitHubTokenRepository
    {
        public GitHubTokenRepository(AppDbContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitHubToken>> GetActiveTokensAsync()
        {
            return await _dbSet
                .Where(t => t.IsActive)
                .OrderByDescending(t => t.RateLimitRemaining)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitHubToken>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<GitHubToken?> GetBestAvailableTokenAsync()
        {
            return await _dbSet
                .Where(t => t.IsActive && t.RateLimitRemaining > 0)
                .OrderByDescending(t => t.RateLimitRemaining)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task UpdateRateLimitAsync(int tokenId, int remaining, DateTime? resetAt)
        {
            var token = await _dbSet.FindAsync(tokenId);
            if (token != null)
            {
                token.RateLimitRemaining = remaining;
                token.RateLimitResetAt = resetAt;
                token.LastUsedAt = DateTime.Now;
            }
        }
    }
}
