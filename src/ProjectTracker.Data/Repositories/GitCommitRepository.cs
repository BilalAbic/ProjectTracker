using Microsoft.EntityFrameworkCore;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Repositories;
using ProjectTracker.Data.Context;

namespace ProjectTracker.Data.Repositories
{
    /// <summary>
    /// Repository implementation for Git Commit operations
    /// </summary>
    public class GitCommitRepository : Repository<GitCommit>, IGitCommitRepository
    {
        public GitCommitRepository(AppDbContext context) : base(context)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitCommit>> GetByRepositoryIdAsync(int repositoryId)
        {
            return await _dbSet
                .Where(c => c.GitRepositoryId == repositoryId)
                .OrderByDescending(c => c.CommitDate)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitCommit>> GetByRepositoryIdWithFilesAsync(int repositoryId)
        {
            return await _dbSet
                .Include(c => c.FileChanges)
                .Where(c => c.GitRepositoryId == repositoryId)
                .OrderByDescending(c => c.CommitDate)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitCommit>> GetByTaskIdAsync(int taskId)
        {
            return await _dbSet
                .Include(c => c.FileChanges)
                .Where(c => c.LinkedTaskId == taskId)
                .OrderByDescending(c => c.CommitDate)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitCommit>> GetByAuthorAsync(int repositoryId, string authorUsername)
        {
            return await _dbSet
                .Where(c => c.GitRepositoryId == repositoryId && c.AuthorGitHubUsername == authorUsername)
                .OrderByDescending(c => c.CommitDate)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitCommit>> GetByDateRangeAsync(int repositoryId, DateTime startDate, DateTime endDate)
        {
            return await _dbSet
                .Where(c => c.GitRepositoryId == repositoryId && c.CommitDate >= startDate && c.CommitDate <= endDate)
                .OrderByDescending(c => c.CommitDate)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> ExistsByShaAsync(int repositoryId, string sha)
        {
            return await _dbSet.AnyAsync(c => c.GitRepositoryId == repositoryId && c.Sha == sha);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<(string Author, string? AvatarUrl, int CommitCount, int Additions, int Deletions)>> GetLeaderboardAsync(int repositoryId)
        {
            var result = await _dbSet
                .Where(c => c.GitRepositoryId == repositoryId && c.AuthorGitHubUsername != null)
                .GroupBy(c => new { c.AuthorGitHubUsername, c.AuthorAvatarUrl })
                .Select(g => new
                {
                    Author = g.Key.AuthorGitHubUsername!,
                    AvatarUrl = g.Key.AuthorAvatarUrl,
                    CommitCount = g.Count(),
                    Additions = g.Sum(c => c.Additions),
                    Deletions = g.Sum(c => c.Deletions)
                })
                .OrderByDescending(x => x.CommitCount)
                .ToListAsync();

            return result.Select(x => (x.Author, x.AvatarUrl, x.CommitCount, x.Additions, x.Deletions));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<(int DayOfWeek, int Hour, int Count)>> GetPunchCardDataAsync(int repositoryId)
        {
            var commits = await _dbSet
                .Where(c => c.GitRepositoryId == repositoryId)
                .Select(c => c.CommitDate)
                .ToListAsync();

            var result = commits
                .GroupBy(d => new { DayOfWeek = (int)d.DayOfWeek, Hour = d.Hour })
                .Select(g => (g.Key.DayOfWeek, g.Key.Hour, g.Count()))
                .OrderBy(x => x.DayOfWeek)
                .ThenBy(x => x.Hour)
                .ToList();

            return result;
        }
    }
}
