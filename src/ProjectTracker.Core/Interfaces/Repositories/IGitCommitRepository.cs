using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces.Repositories
{
    /// <summary>
    /// Repository interface for Git Commit operations
    /// </summary>
    public interface IGitCommitRepository : IRepository<GitCommit>
    {
        /// <summary>
        /// Get commits by repository ID
        /// </summary>
        Task<IEnumerable<GitCommit>> GetByRepositoryIdAsync(int repositoryId);

        /// <summary>
        /// Get commits by repository ID with file changes
        /// </summary>
        Task<IEnumerable<GitCommit>> GetByRepositoryIdWithFilesAsync(int repositoryId);

        /// <summary>
        /// Get commits linked to a specific task
        /// </summary>
        Task<IEnumerable<GitCommit>> GetByTaskIdAsync(int taskId);

        /// <summary>
        /// Get commits by author GitHub username
        /// </summary>
        Task<IEnumerable<GitCommit>> GetByAuthorAsync(int repositoryId, string authorUsername);

        /// <summary>
        /// Get commits within date range
        /// </summary>
        Task<IEnumerable<GitCommit>> GetByDateRangeAsync(int repositoryId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Check if commit SHA already exists in repository
        /// </summary>
        Task<bool> ExistsByShaAsync(int repositoryId, string sha);

        /// <summary>
        /// Get leaderboard data (commits grouped by author)
        /// </summary>
        Task<IEnumerable<(string Author, string? AvatarUrl, int CommitCount, int Additions, int Deletions)>> GetLeaderboardAsync(int repositoryId);

        /// <summary>
        /// Get punch card data (commits grouped by day of week and hour)
        /// </summary>
        Task<IEnumerable<(int DayOfWeek, int Hour, int Count)>> GetPunchCardDataAsync(int repositoryId);
    }
}
