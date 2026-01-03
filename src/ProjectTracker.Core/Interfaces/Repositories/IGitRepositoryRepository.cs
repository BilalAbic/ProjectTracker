using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces.Repositories
{
    /// <summary>
    /// Repository interface for Git Repository operations
    /// </summary>
    public interface IGitRepositoryRepository : IRepository<GitRepository>
    {
        /// <summary>
        /// Get repository by project ID
        /// </summary>
        Task<GitRepository?> GetByProjectIdAsync(int projectId);

        /// <summary>
        /// Get repository with commits included
        /// </summary>
        Task<GitRepository?> GetWithCommitsAsync(int repositoryId);

        /// <summary>
        /// Get repository with full details (commits + file changes)
        /// </summary>
        Task<GitRepository?> GetWithFullDetailsAsync(int repositoryId);

        /// <summary>
        /// Update sync status
        /// </summary>
        System.Threading.Tasks.Task UpdateSyncStatusAsync(int repositoryId, string status, DateTime? lastSyncAt = null);
    }
}
