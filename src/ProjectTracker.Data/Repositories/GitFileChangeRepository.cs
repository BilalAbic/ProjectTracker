using Microsoft.EntityFrameworkCore;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Repositories;
using ProjectTracker.Data.Context;

namespace ProjectTracker.Data.Repositories
{
    /// <summary>
    /// Repository implementation for Git File Change operations
    /// </summary>
    public class GitFileChangeRepository : Repository<GitFileChange>, IGitFileChangeRepository
    {
        public GitFileChangeRepository(AppDbContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitFileChange>> GetByCommitIdAsync(int commitId)
        {
            return await _dbSet
                .Where(f => f.GitCommitId == commitId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<(string FileName, int ChangeCount, int TotalAdditions, int TotalDeletions)>> GetHotspotsAsync(int repositoryId, int top = 10)
        {
            var result = await _dbSet
                .Include(f => f.Commit)
                .Where(f => f.Commit.GitRepositoryId == repositoryId)
                .GroupBy(f => f.FileName)
                .Select(g => new
                {
                    FileName = g.Key,
                    ChangeCount = g.Count(),
                    TotalAdditions = g.Sum(f => f.Additions),
                    TotalDeletions = g.Sum(f => f.Deletions)
                })
                .OrderByDescending(x => x.ChangeCount)
                .Take(top)
                .ToListAsync();

            return result.Select(x => (x.FileName, x.ChangeCount, x.TotalAdditions, x.TotalDeletions));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<(string Extension, int FileCount, int TotalChanges)>> GetLanguageDistributionAsync(int repositoryId)
        {
            var result = await _dbSet
                .Include(f => f.Commit)
                .Where(f => f.Commit.GitRepositoryId == repositoryId && f.FileExtension != null)
                .GroupBy(f => f.FileExtension)
                .Select(g => new
                {
                    Extension = g.Key!,
                    FileCount = g.Count(),
                    TotalChanges = g.Sum(f => f.Additions + f.Deletions)
                })
                .OrderByDescending(x => x.FileCount)
                .ToListAsync();

            return result.Select(x => (x.Extension, x.FileCount, x.TotalChanges));
        }
    }
}
