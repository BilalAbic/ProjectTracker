using Microsoft.EntityFrameworkCore;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Repositories;
using ProjectTracker.Data.Context;

namespace ProjectTracker.Data.Repositories
{
    /// <summary>
    /// Repository implementation for Git Repository operations
    /// </summary>
    public class GitRepositoryRepository : Repository<GitRepository>, IGitRepositoryRepository
    {
        public GitRepositoryRepository(AppDbContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<GitRepository?> GetByProjectIdAsync(int projectId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(r => r.ProjectId == projectId);
        }

        /// <inheritdoc/>
        public async Task<GitRepository?> GetWithCommitsAsync(int repositoryId)
        {
            return await _dbSet
                .Include(r => r.Commits)
                .FirstOrDefaultAsync(r => r.GitRepositoryId == repositoryId);
        }

        /// <inheritdoc/>
        public async Task<GitRepository?> GetWithFullDetailsAsync(int repositoryId)
        {
            return await _dbSet
                .Include(r => r.Commits)
                    .ThenInclude(c => c.FileChanges)
                .Include(r => r.Commits)
                    .ThenInclude(c => c.LinkedTask)
                .FirstOrDefaultAsync(r => r.GitRepositoryId == repositoryId);
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task UpdateSyncStatusAsync(int repositoryId, string status, DateTime? lastSyncAt = null)
        {
            var repo = await _dbSet.FindAsync(repositoryId);
            if (repo != null)
            {
                repo.SyncStatus = status;
                if (lastSyncAt.HasValue)
                {
                    repo.LastSyncAt = lastSyncAt.Value;
                }
            }
        }
    }
}
