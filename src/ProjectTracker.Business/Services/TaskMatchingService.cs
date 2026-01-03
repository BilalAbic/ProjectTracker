using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Interfaces;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// Service for matching commits to tasks using name similarity
    /// Uses English-weighted keywords for better matching
    /// </summary>
    public class TaskMatchingService : ITaskMatchingService
    {
        private readonly IUnitOfWork _unitOfWork;

        // English-weighted keywords for commit-task matching
        private static readonly Dictionary<string, double> Keywords = new(StringComparer.OrdinalIgnoreCase)
        {
            // Action keywords (high weight)
            { "fix", 2.0 }, { "fixed", 2.0 }, { "fixes", 2.0 },
            { "add", 1.8 }, { "added", 1.8 }, { "adding", 1.8 },
            { "update", 1.8 }, { "updated", 1.8 }, { "updating", 1.8 },
            { "remove", 1.5 }, { "removed", 1.5 }, { "delete", 1.5 }, { "deleted", 1.5 },
            { "refactor", 1.5 }, { "refactored", 1.5 },
            { "implement", 2.0 }, { "implemented", 2.0 },
            { "create", 1.8 }, { "created", 1.8 },
            
            // Domain keywords (medium weight)
            { "test", 1.3 }, { "tests", 1.3 }, { "testing", 1.3 },
            { "ui", 1.5 }, { "ux", 1.5 }, { "design", 1.3 },
            { "api", 1.5 }, { "endpoint", 1.3 },
            { "auth", 1.5 }, { "login", 1.5 }, { "authentication", 1.5 },
            { "database", 1.3 }, { "db", 1.3 }, { "sql", 1.3 },
            { "docs", 1.0 }, { "documentation", 1.0 },
            { "bug", 1.8 }, { "error", 1.5 }, { "issue", 1.3 },
            { "feature", 1.5 }, { "enhancement", 1.3 },
            
            // Component keywords
            { "service", 1.2 }, { "controller", 1.2 }, { "model", 1.2 },
            { "view", 1.2 }, { "form", 1.2 }, { "page", 1.2 },
            { "component", 1.2 }, { "module", 1.2 }
        };

        // Minimum score threshold for a match
        private const double MinMatchThreshold = 30.0;

        public TaskMatchingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc/>
        public async Task<(int? TaskId, string? TaskName, double Score)> FindBestMatchAsync(int projectId, string commitMessage)
        {
            if (string.IsNullOrWhiteSpace(commitMessage))
                return (null, null, 0);

            var tasks = await _unitOfWork.Tasks.FindAsync(t => t.ProjectId == projectId);
            var taskList = tasks.ToList();

            if (!taskList.Any())
                return (null, null, 0);

            var commitWords = ExtractWords(commitMessage);
            
            int? bestTaskId = null;
            string? bestTaskName = null;
            double bestScore = 0;

            foreach (var task in taskList)
            {
                var taskWords = ExtractWords(task.TaskName);
                var score = CalculateSimilarityScore(commitWords, taskWords);

                // Also check description if available
                if (!string.IsNullOrWhiteSpace(task.Description))
                {
                    var descWords = ExtractWords(task.Description);
                    var descScore = CalculateSimilarityScore(commitWords, descWords) * 0.5; // Lower weight for description
                    score = Math.Max(score, descScore);
                }

                if (score > bestScore)
                {
                    bestScore = score;
                    bestTaskId = task.TaskId;
                    bestTaskName = task.TaskName;
                }
            }

            // Only return match if above threshold
            if (bestScore >= MinMatchThreshold)
            {
                return (bestTaskId, bestTaskName, bestScore);
            }

            return (null, null, 0);
        }

        /// <inheritdoc/>
        public async Task<int> RematchAllCommitsAsync(int repositoryId)
        {
            var repo = await _unitOfWork.GitRepositories.GetByIdAsync(repositoryId);
            if (repo == null)
                return 0;

            var commits = await _unitOfWork.GitCommits.GetByRepositoryIdAsync(repositoryId);
            int matchedCount = 0;

            foreach (var commit in commits)
            {
                var (taskId, _, score) = await FindBestMatchAsync(repo.ProjectId, commit.Message ?? "");
                
                if (taskId.HasValue)
                {
                    commit.LinkedTaskId = taskId;
                    commit.MatchScore = score;
                    _unitOfWork.GitCommits.Update(commit);
                    matchedCount++;
                }
                else if (commit.LinkedTaskId.HasValue)
                {
                    // Clear previous match if no longer valid
                    commit.LinkedTaskId = null;
                    commit.MatchScore = 0;
                    _unitOfWork.GitCommits.Update(commit);
                }
            }

            await _unitOfWork.SaveChangesAsync();
            return matchedCount;
        }

        #region Private Methods

        private static List<string> ExtractWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new List<string>();

            // Split by non-alphanumeric characters
            var words = text
                .ToLowerInvariant()
                .Split(new[] { ' ', '-', '_', '.', ',', ':', ';', '/', '\\', '(', ')', '[', ']', '{', '}', '#', '@', '!', '?', '\n', '\r', '\t' }, 
                       StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w.Length > 1) // Skip single characters
                .Distinct()
                .ToList();

            return words;
        }

        private static double CalculateSimilarityScore(List<string> commitWords, List<string> taskWords)
        {
            if (!commitWords.Any() || !taskWords.Any())
                return 0;

            double totalScore = 0;
            int matchCount = 0;

            foreach (var commitWord in commitWords)
            {
                foreach (var taskWord in taskWords)
                {
                    // Exact match
                    if (commitWord == taskWord)
                    {
                        double weight = Keywords.TryGetValue(commitWord, out var kw) ? kw : 1.0;
                        totalScore += 20 * weight;
                        matchCount++;
                    }
                    // Partial match (one contains the other)
                    else if (commitWord.Contains(taskWord) || taskWord.Contains(commitWord))
                    {
                        double weight = Keywords.TryGetValue(commitWord, out var kw1) ? kw1 : 
                                       (Keywords.TryGetValue(taskWord, out var kw2) ? kw2 : 1.0);
                        totalScore += 10 * weight;
                        matchCount++;
                    }
                    // Levenshtein distance for typos (only for longer words)
                    else if (commitWord.Length > 4 && taskWord.Length > 4)
                    {
                        var distance = LevenshteinDistance(commitWord, taskWord);
                        var maxLen = Math.Max(commitWord.Length, taskWord.Length);
                        var similarity = 1.0 - ((double)distance / maxLen);
                        
                        if (similarity > 0.7) // 70% similar
                        {
                            totalScore += 5 * similarity;
                            matchCount++;
                        }
                    }
                }
            }

            // Normalize by the number of words
            var normalizedScore = matchCount > 0 
                ? totalScore / Math.Max(commitWords.Count, taskWords.Count) * 10 
                : 0;

            return Math.Min(normalizedScore, 100); // Cap at 100
        }

        private static int LevenshteinDistance(string s1, string s2)
        {
            var m = s1.Length;
            var n = s2.Length;
            var d = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++) d[i, 0] = i;
            for (int j = 0; j <= n; j++) d[0, j] = j;

            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= m; i++)
                {
                    var cost = s1[i - 1] == s2[j - 1] ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[m, n];
        }

        #endregion
    }
}
