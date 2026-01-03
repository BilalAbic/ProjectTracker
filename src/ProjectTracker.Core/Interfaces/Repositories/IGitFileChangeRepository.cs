using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces.Repositories
{
    /// <summary>
    /// Repository interface for Git File Change operations
    /// </summary>
    public interface IGitFileChangeRepository : IRepository<GitFileChange>
    {
        /// <summary>
        /// Get file changes by commit ID
        /// </summary>
        Task<IEnumerable<GitFileChange>> GetByCommitIdAsync(int commitId);

        /// <summary>
        /// Get hotspots (most changed files) for a repository
        /// </summary>
        Task<IEnumerable<(string FileName, int ChangeCount, int TotalAdditions, int TotalDeletions)>> GetHotspotsAsync(int repositoryId, int top = 10);

        /// <summary>
        /// Get language distribution (file extensions) for a repository
        /// </summary>
        Task<IEnumerable<(string Extension, int FileCount, int TotalChanges)>> GetLanguageDistributionAsync(int repositoryId);
    }
}
