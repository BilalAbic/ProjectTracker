using ProjectTracker.Business.DTOs;

namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// Interface for GitHub Token Pool Service
    /// </summary>
    public interface ITokenPoolService
    {
        /// <summary>
        /// Get the best available token for API calls
        /// </summary>
        Task<string?> GetBestTokenAsync();

        /// <summary>
        /// Update rate limit info after API call
        /// </summary>
        System.Threading.Tasks.Task UpdateRateLimitAsync(int tokenId, int remaining, DateTime? resetAt);

        /// <summary>
        /// Get all tokens for a user
        /// </summary>
        Task<IEnumerable<GitHubTokenDto>> GetUserTokensAsync(int userId);

        /// <summary>
        /// Add a new token for a user
        /// </summary>
        Task<GitHubTokenDto> AddTokenAsync(int userId, SaveGitHubTokenDto dto);

        /// <summary>
        /// Remove a token
        /// </summary>
        Task<bool> RemoveTokenAsync(int tokenId, int userId);

        /// <summary>
        /// Get pool status (total tokens, available capacity)
        /// </summary>
        Task<(int TotalTokens, int TotalRateLimit)> GetPoolStatusAsync();
    }

    /// <summary>
    /// Interface for Task-Commit Matching Service
    /// </summary>
    public interface ITaskMatchingService
    {
        /// <summary>
        /// Find best matching task for a commit message
        /// </summary>
        Task<(int? TaskId, string? TaskName, double Score)> FindBestMatchAsync(int projectId, string commitMessage);

        /// <summary>
        /// Re-match all commits for a repository
        /// </summary>
        Task<int> RematchAllCommitsAsync(int repositoryId);
    }

    /// <summary>
    /// Interface for GitHub Sync Service
    /// </summary>
    public interface IGitHubSyncService
    {
        /// <summary>
        /// Sync repository data from GitHub
        /// </summary>
        Task<SyncResultDto> SyncRepositoryAsync(int projectId);

        /// <summary>
        /// Link a GitHub repository to a project
        /// </summary>
        Task<GitRepositoryDto> LinkRepositoryAsync(int projectId, string repoUrl);

        /// <summary>
        /// Unlink a GitHub repository from a project
        /// </summary>
        Task<bool> UnlinkRepositoryAsync(int projectId);

        /// <summary>
        /// Get repository info for a project
        /// </summary>
        Task<GitRepositoryDto?> GetRepositoryAsync(int projectId);
    }

    /// <summary>
    /// Interface for GitHub Analytics Service
    /// </summary>
    public interface IGitHubAnalyticsService
    {
        /// <summary>
        /// Get analytics summary for a project
        /// </summary>
        Task<GitHubAnalyticsSummaryDto?> GetAnalyticsSummaryAsync(int projectId);

        /// <summary>
        /// Get commits for a project
        /// </summary>
        Task<IEnumerable<GitCommitDto>> GetCommitsAsync(int projectId, int? limit = null);

        /// <summary>
        /// Get commits linked to a specific task
        /// </summary>
        Task<IEnumerable<GitCommitDto>> GetCommitsByTaskAsync(int taskId);

        /// <summary>
        /// Get leaderboard for a project
        /// </summary>
        Task<IEnumerable<LeaderboardEntryDto>> GetLeaderboardAsync(int projectId);

        /// <summary>
        /// Get punch card data for a project
        /// </summary>
        Task<IEnumerable<PunchCardEntryDto>> GetPunchCardAsync(int projectId);

        /// <summary>
        /// Get hotspots (most changed files) for a project
        /// </summary>
        Task<IEnumerable<HotspotDto>> GetHotspotsAsync(int projectId, int top = 10);

        /// <summary>
        /// Get language distribution for a project
        /// </summary>
        Task<IEnumerable<LanguageDistributionDto>> GetLanguageDistributionAsync(int projectId);

        /// <summary>
        /// Get commit trend (daily commit counts) for a project
        /// </summary>
        Task<IEnumerable<CommitTrendDto>> GetCommitTrendAsync(int projectId, int days = 30);
    }
}
