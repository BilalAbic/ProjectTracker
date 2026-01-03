using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Interfaces;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// Service for GitHub analytics and reporting
    /// Provides leaderboard, punch card, hotspots, and other analytics
    /// </summary>
    public class GitHubAnalyticsService : IGitHubAnalyticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        // File extension to language mapping
        private static readonly Dictionary<string, string> ExtensionToLanguage = new(StringComparer.OrdinalIgnoreCase)
        {
            { ".cs", "C#" },
            { ".js", "JavaScript" },
            { ".ts", "TypeScript" },
            { ".jsx", "React JSX" },
            { ".tsx", "React TSX" },
            { ".py", "Python" },
            { ".java", "Java" },
            { ".cpp", "C++" },
            { ".c", "C" },
            { ".h", "C/C++ Header" },
            { ".html", "HTML" },
            { ".css", "CSS" },
            { ".scss", "SCSS" },
            { ".less", "LESS" },
            { ".json", "JSON" },
            { ".xml", "XML" },
            { ".yaml", "YAML" },
            { ".yml", "YAML" },
            { ".sql", "SQL" },
            { ".md", "Markdown" },
            { ".txt", "Text" },
            { ".sh", "Shell" },
            { ".ps1", "PowerShell" },
            { ".bat", "Batch" },
            { ".rb", "Ruby" },
            { ".php", "PHP" },
            { ".go", "Go" },
            { ".rs", "Rust" },
            { ".swift", "Swift" },
            { ".kt", "Kotlin" },
            { ".vue", "Vue" },
            { ".svelte", "Svelte" }
        };

        private static readonly string[] DayNames = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        public GitHubAnalyticsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc/>
        public async Task<GitHubAnalyticsSummaryDto?> GetAnalyticsSummaryAsync(int projectId)
        {
            var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            if (repo == null)
                return null;

            var commits = (await _unitOfWork.GitCommits.GetByRepositoryIdAsync(repo.GitRepositoryId)).ToList();
            
            if (!commits.Any())
            {
                return new GitHubAnalyticsSummaryDto
                {
                    TotalCommits = 0,
                    TotalContributors = repo.TotalContributors
                };
            }

            var summary = new GitHubAnalyticsSummaryDto
            {
                TotalCommits = commits.Count,
                TotalContributors = commits.Select(c => c.AuthorGitHubUsername).Distinct().Count(),
                TotalAdditions = commits.Sum(c => c.Additions),
                TotalDeletions = commits.Sum(c => c.Deletions),
                FirstCommitDate = commits.Min(c => c.CommitDate),
                LastCommitDate = commits.Max(c => c.CommitDate),
                MatchedTasksCount = commits.Count(c => c.LinkedTaskId.HasValue),
                AverageMatchScore = commits.Where(c => c.LinkedTaskId.HasValue).Select(c => c.MatchScore).DefaultIfEmpty(0).Average()
            };

            // Get leaderboard
            summary.Leaderboard = (await GetLeaderboardAsync(projectId)).Take(5).ToList();

            // Get hotspots
            summary.Hotspots = (await GetHotspotsAsync(projectId, 5)).ToList();

            // Get language distribution
            summary.LanguageDistribution = (await GetLanguageDistributionAsync(projectId)).Take(5).ToList();

            return summary;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitCommitDto>> GetCommitsAsync(int projectId, int? limit = null)
        {
            var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            if (repo == null)
                return Enumerable.Empty<GitCommitDto>();

            var commits = await _unitOfWork.GitCommits.GetByRepositoryIdWithFilesAsync(repo.GitRepositoryId);
            var commitList = limit.HasValue ? commits.Take(limit.Value) : commits;

            return commitList.Select(MapCommitToDto);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GitCommitDto>> GetCommitsByTaskAsync(int taskId)
        {
            var commits = await _unitOfWork.GitCommits.GetByTaskIdAsync(taskId);
            return commits.Select(MapCommitToDto);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LeaderboardEntryDto>> GetLeaderboardAsync(int projectId)
        {
            var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            if (repo == null)
                return Enumerable.Empty<LeaderboardEntryDto>();

            var leaderboard = await _unitOfWork.GitCommits.GetLeaderboardAsync(repo.GitRepositoryId);
            
            int rank = 1;
            return leaderboard.Select(l => new LeaderboardEntryDto
            {
                Rank = rank++,
                Author = l.Author,
                AvatarUrl = l.AvatarUrl,
                CommitCount = l.CommitCount,
                Additions = l.Additions,
                Deletions = l.Deletions
            });
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PunchCardEntryDto>> GetPunchCardAsync(int projectId)
        {
            var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            if (repo == null)
                return Enumerable.Empty<PunchCardEntryDto>();

            var punchCard = await _unitOfWork.GitCommits.GetPunchCardDataAsync(repo.GitRepositoryId);
            
            return punchCard.Select(p => new PunchCardEntryDto
            {
                DayOfWeek = p.DayOfWeek,
                DayName = DayNames[p.DayOfWeek],
                Hour = p.Hour,
                Count = p.Count
            });
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<HotspotDto>> GetHotspotsAsync(int projectId, int top = 10)
        {
            var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            if (repo == null)
                return Enumerable.Empty<HotspotDto>();

            var hotspots = await _unitOfWork.GitFileChanges.GetHotspotsAsync(repo.GitRepositoryId, top);
            
            return hotspots.Select(h => new HotspotDto
            {
                FileName = h.FileName,
                ChangeCount = h.ChangeCount,
                TotalAdditions = h.TotalAdditions,
                TotalDeletions = h.TotalDeletions
            });
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LanguageDistributionDto>> GetLanguageDistributionAsync(int projectId)
        {
            var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            if (repo == null)
                return Enumerable.Empty<LanguageDistributionDto>();

            var distribution = await _unitOfWork.GitFileChanges.GetLanguageDistributionAsync(repo.GitRepositoryId);
            var totalChanges = distribution.Sum(d => d.TotalChanges);

            return distribution.Select(d => new LanguageDistributionDto
            {
                Extension = d.Extension,
                Language = ExtensionToLanguage.TryGetValue(d.Extension, out var lang) ? lang : d.Extension.TrimStart('.').ToUpper(),
                FileCount = d.FileCount,
                TotalChanges = d.TotalChanges,
                Percentage = totalChanges > 0 ? Math.Round((double)d.TotalChanges / totalChanges * 100, 1) : 0
            });
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CommitTrendDto>> GetCommitTrendAsync(int projectId, int days = 30)
        {
            var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            if (repo == null)
                return Enumerable.Empty<CommitTrendDto>();

            var commits = await _unitOfWork.GitCommits.GetByRepositoryIdAsync(repo.GitRepositoryId);
            var startDate = DateTime.Now.Date.AddDays(-days);

            // Group commits by date
            var grouped = commits
                .Where(c => c.CommitDate.Date >= startDate)
                .GroupBy(c => c.CommitDate.Date)
                .ToDictionary(g => g.Key, g => new
                {
                    Count = g.Count(),
                    Additions = g.Sum(c => c.Additions),
                    Deletions = g.Sum(c => c.Deletions)
                });

            // Fill in all days (including days with no commits)
            var result = new List<CommitTrendDto>();
            for (int i = days; i >= 0; i--)
            {
                var date = DateTime.Now.Date.AddDays(-i);
                var data = grouped.TryGetValue(date, out var d) ? d : null;
                result.Add(new CommitTrendDto
                {
                    Date = date,
                    CommitCount = data?.Count ?? 0,
                    Additions = data?.Additions ?? 0,
                    Deletions = data?.Deletions ?? 0
                });
            }

            return result;
        }

        #region Private Methods

        private static GitCommitDto MapCommitToDto(Core.Entities.GitCommit commit)
        {
            return new GitCommitDto
            {
                GitCommitId = commit.GitCommitId,
                GitRepositoryId = commit.GitRepositoryId,
                Sha = commit.Sha,
                Message = commit.Message,
                AuthorName = commit.AuthorName,
                AuthorEmail = commit.AuthorEmail,
                AuthorGitHubUsername = commit.AuthorGitHubUsername,
                AuthorAvatarUrl = commit.AuthorAvatarUrl,
                CommitDate = commit.CommitDate,
                Additions = commit.Additions,
                Deletions = commit.Deletions,
                ChangedFilesCount = commit.ChangedFilesCount,
                LinkedTaskId = commit.LinkedTaskId,
                LinkedTaskName = commit.LinkedTask?.TaskName,
                MatchScore = commit.MatchScore,
                FileChanges = commit.FileChanges?.Select(f => new GitFileChangeDto
                {
                    GitFileChangeId = f.GitFileChangeId,
                    FileName = f.FileName,
                    FileExtension = f.FileExtension,
                    Status = f.Status,
                    Additions = f.Additions,
                    Deletions = f.Deletions
                }).ToList() ?? new List<GitFileChangeDto>()
            };
        }

        #endregion
    }
}
