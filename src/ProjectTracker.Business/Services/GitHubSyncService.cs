using Octokit;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using System.Text.RegularExpressions;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// Service for syncing GitHub repository data
    /// Uses Octokit.net for GitHub API communication
    /// </summary>
    public class GitHubSyncService : IGitHubSyncService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenPoolService _tokenPoolService;
        private readonly ITaskMatchingService _taskMatchingService;

        public GitHubSyncService(
            IUnitOfWork unitOfWork,
            ITokenPoolService tokenPoolService,
            ITaskMatchingService taskMatchingService)
        {
            _unitOfWork = unitOfWork;
            _tokenPoolService = tokenPoolService;
            _taskMatchingService = taskMatchingService;
        }

        /// <inheritdoc/>
        public async Task<SyncResultDto> SyncRepositoryAsync(int projectId)
        {
            var result = new SyncResultDto { SyncedAt = DateTime.Now };

            try
            {
                // Get repository
                var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
                if (repo == null)
                {
                    result.Message = "No GitHub repository linked to this project.";
                    return result;
                }

                // Get token
                var token = await _tokenPoolService.GetBestTokenAsync();
                if (string.IsNullOrEmpty(token))
                {
                    result.Message = "No GitHub tokens available. Please add a token in settings.";
                    return result;
                }

                // Validate repo info
                if (string.IsNullOrWhiteSpace(repo.RepoOwner) || string.IsNullOrWhiteSpace(repo.RepoName))
                {
                    result.Message = $"Invalid repository info. Owner: '{repo.RepoOwner}', Name: '{repo.RepoName}'";
                    return result;
                }

                // Update sync status
                await _unitOfWork.GitRepositories.UpdateSyncStatusAsync(repo.GitRepositoryId, "Syncing");
                await _unitOfWork.SaveChangesAsync();

                // Create GitHub client
                var client = CreateGitHubClient(token);

                // Fetch commits
                var (newCount, updatedCount, matchedCount) = await FetchCommitsAsync(client, repo);

                // Update repository stats
                await UpdateRepositoryStatsAsync(client, repo);

                // Update sync status
                await _unitOfWork.GitRepositories.UpdateSyncStatusAsync(repo.GitRepositoryId, "Completed", DateTime.Now);
                await _unitOfWork.SaveChangesAsync();

                result.Success = true;
                result.NewCommitsCount = newCount;
                result.UpdatedCommitsCount = updatedCount;
                result.MatchedTasksCount = matchedCount;
                result.Message = $"Sync completed. {newCount} new commits, {matchedCount} matched to tasks.";
            }
            catch (Exception ex)
            {
                result.Message = $"Sync failed: {ex.Message}";
                
                // Update sync status to failed
                var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
                if (repo != null)
                {
                    await _unitOfWork.GitRepositories.UpdateSyncStatusAsync(repo.GitRepositoryId, "Failed");
                    await _unitOfWork.SaveChangesAsync();
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GitRepositoryDto> LinkRepositoryAsync(int projectId, string repoUrl)
        {
            // Parse repo URL
            var (owner, name) = ParseRepoUrl(repoUrl);
            
            // Debug: Log parsed values
            System.Diagnostics.Debug.WriteLine($"[GitHubSync] Input URL: {repoUrl}");
            System.Diagnostics.Debug.WriteLine($"[GitHubSync] Parsed Owner: '{owner}', Name: '{name}'");
            
            if (string.IsNullOrEmpty(owner) || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"Invalid GitHub repository URL. Could not parse owner/name from: {repoUrl}");
            }

            // Check if already linked - DELETE and recreate to avoid update issues
            var existing = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            if (existing != null)
            {
                System.Diagnostics.Debug.WriteLine($"[GitHubSync] Removing existing repo: {existing.RepoOwner}/{existing.RepoName}");
                _unitOfWork.GitRepositories.Remove(existing);
                await _unitOfWork.SaveChangesAsync();
            }

            // Create repository record
            var repo = new GitRepository
            {
                ProjectId = projectId,
                RepoUrl = repoUrl,
                RepoOwner = owner,
                RepoName = name,
                SyncStatus = "Pending",
                CreatedAt = DateTime.Now
            };

            await _unitOfWork.GitRepositories.AddAsync(repo);
            await _unitOfWork.SaveChangesAsync();
            
            System.Diagnostics.Debug.WriteLine($"[GitHubSync] Created new repo: {owner}/{name}");

            return MapToDto(repo);
        }

        /// <inheritdoc/>
        public async Task<bool> UnlinkRepositoryAsync(int projectId)
        {
            var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            if (repo == null)
                return false;

            _unitOfWork.GitRepositories.Remove(repo);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc/>
        public async Task<GitRepositoryDto?> GetRepositoryAsync(int projectId)
        {
            var repo = await _unitOfWork.GitRepositories.GetByProjectIdAsync(projectId);
            return repo != null ? MapToDto(repo) : null;
        }

        #region Private Methods

        private static GitHubClient CreateGitHubClient(string token)
        {
            var client = new GitHubClient(new ProductHeaderValue("ProjectTracker"));
            client.Credentials = new Credentials(token);
            return client;
        }

        private async Task<(int NewCount, int UpdatedCount, int MatchedCount)> FetchCommitsAsync(
            GitHubClient client, GitRepository repo)
        {
            int newCount = 0, updatedCount = 0, matchedCount = 0;

            try
            {
                // First, get repo info to ensure we have the default branch
                if (string.IsNullOrEmpty(repo.DefaultBranch))
                {
                    var ghRepo = await client.Repository.Get(repo.RepoOwner, repo.RepoName);
                    repo.DefaultBranch = ghRepo.DefaultBranch;
                    _unitOfWork.GitRepositories.Update(repo);
                    await _unitOfWork.SaveChangesAsync();
                }

                var commitRequest = new CommitRequest();
                if (!string.IsNullOrEmpty(repo.DefaultBranch))
                {
                    commitRequest.Sha = repo.DefaultBranch;
                }

                var commits = await client.Repository.Commit.GetAll(repo.RepoOwner, repo.RepoName,
                    commitRequest,
                    new ApiOptions { PageCount = 5, PageSize = 100 }); // Last 500 commits max

                foreach (var ghCommit in commits)
                {
                    // Check if commit already exists
                    var exists = await _unitOfWork.GitCommits.ExistsByShaAsync(repo.GitRepositoryId, ghCommit.Sha);
                    
                    if (!exists)
                    {
                        // Get detailed commit info
                        var detailedCommit = await client.Repository.Commit.Get(repo.RepoOwner, repo.RepoName, ghCommit.Sha);

                        var commit = new GitCommit
                        {
                            GitRepositoryId = repo.GitRepositoryId,
                            Sha = ghCommit.Sha,
                            Message = ghCommit.Commit.Message,
                            AuthorName = ghCommit.Commit.Author?.Name,
                            AuthorEmail = ghCommit.Commit.Author?.Email,
                            AuthorGitHubUsername = ghCommit.Author?.Login,
                            AuthorAvatarUrl = ghCommit.Author?.AvatarUrl,
                            CommitDate = ghCommit.Commit.Author?.Date.DateTime ?? DateTime.Now,
                            Additions = detailedCommit.Stats?.Additions ?? 0,
                            Deletions = detailedCommit.Stats?.Deletions ?? 0,
                            ChangedFilesCount = detailedCommit.Files?.Count ?? 0,
                            CreatedAt = DateTime.Now
                        };

                        // Match to task
                        var (taskId, _, score) = await _taskMatchingService.FindBestMatchAsync(
                            repo.ProjectId, commit.Message ?? "");
                        
                        if (taskId.HasValue)
                        {
                            commit.LinkedTaskId = taskId;
                            commit.MatchScore = score;
                            matchedCount++;
                        }

                        await _unitOfWork.GitCommits.AddAsync(commit);
                        await _unitOfWork.SaveChangesAsync();

                        // Add file changes
                        if (detailedCommit.Files != null)
                        {
                            foreach (var file in detailedCommit.Files)
                            {
                                var fileChange = new GitFileChange
                                {
                                    GitCommitId = commit.GitCommitId,
                                    FileName = file.Filename,
                                    FileExtension = Path.GetExtension(file.Filename),
                                    Status = file.Status,
                                    Additions = file.Additions,
                                    Deletions = file.Deletions
                                };
                                await _unitOfWork.GitFileChanges.AddAsync(fileChange);
                            }
                            await _unitOfWork.SaveChangesAsync();
                        }

                        newCount++;
                    }
                }
            }
            catch (RateLimitExceededException)
            {
                throw new Exception("GitHub API rate limit exceeded. Please try again later.");
            }
            catch (NotFoundException ex)
            {
                throw new Exception($"Repository not found: {repo.RepoOwner}/{repo.RepoName}. Please check the repository URL. Details: {ex.Message}");
            }
            catch (AuthorizationException ex)
            {
                throw new Exception($"GitHub authorization failed. Token may be invalid or expired. Details: {ex.Message}");
            }

            return (newCount, updatedCount, matchedCount);
        }

        private async System.Threading.Tasks.Task UpdateRepositoryStatsAsync(GitHubClient client, GitRepository repo)
        {
            try
            {
                var ghRepo = await client.Repository.Get(repo.RepoOwner, repo.RepoName);
                
                repo.DefaultBranch = ghRepo.DefaultBranch;
                repo.IsPrivate = ghRepo.Private;
                repo.OpenIssues = ghRepo.OpenIssuesCount;

                // Get contributor count
                try
                {
                    var contributors = await client.Repository.GetAllContributors(repo.RepoOwner, repo.RepoName);
                    repo.TotalContributors = contributors.Count;
                }
                catch { /* Ignore */ }

                // Get branch count
                try
                {
                    var branches = await client.Repository.Branch.GetAll(repo.RepoOwner, repo.RepoName);
                    repo.TotalBranches = branches.Count;
                }
                catch { /* Ignore */ }

                // Update commit count from local DB
                var commitCount = await _unitOfWork.GitCommits.CountAsync(c => c.GitRepositoryId == repo.GitRepositoryId);
                repo.TotalCommits = commitCount;

                _unitOfWork.GitRepositories.Update(repo);
            }
            catch { /* Ignore stats update errors */ }
        }

        private static (string Owner, string Name) ParseRepoUrl(string url)
        {
            // Handle various GitHub URL formats
            // https://github.com/owner/repo
            // https://github.com/owner/repo.git
            // https://github.com/owner/repo/
            // git@github.com:owner/repo.git

            if (string.IsNullOrWhiteSpace(url))
                return (string.Empty, string.Empty);

            // Clean the URL
            url = url.Trim();
            
            // Remove trailing slash
            url = url.TrimEnd('/');
            
            // Remove .git suffix
            if (url.EndsWith(".git", StringComparison.OrdinalIgnoreCase))
                url = url[..^4];

            var patterns = new[]
            {
                @"github\.com[/:](?<owner>[^/]+)/(?<name>[^/]+)$",
                @"github\.com[/:](?<owner>[^/]+)/(?<name>.+)$"
            };

            foreach (var pattern in patterns)
            {
                var match = Regex.Match(url, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    var owner = match.Groups["owner"].Value.Trim();
                    var name = match.Groups["name"].Value.Trim();
                    
                    // Remove any query string or fragment
                    if (name.Contains('?'))
                        name = name.Split('?')[0];
                    if (name.Contains('#'))
                        name = name.Split('#')[0];
                    
                    return (owner, name);
                }
            }

            return (string.Empty, string.Empty);
        }

        private static GitRepositoryDto MapToDto(GitRepository repo)
        {
            return new GitRepositoryDto
            {
                GitRepositoryId = repo.GitRepositoryId,
                ProjectId = repo.ProjectId,
                RepoUrl = repo.RepoUrl,
                RepoOwner = repo.RepoOwner,
                RepoName = repo.RepoName,
                DefaultBranch = repo.DefaultBranch,
                IsPrivate = repo.IsPrivate,
                LastSyncAt = repo.LastSyncAt,
                SyncStatus = repo.SyncStatus,
                TotalCommits = repo.TotalCommits,
                TotalBranches = repo.TotalBranches,
                TotalContributors = repo.TotalContributors,
                OpenIssues = repo.OpenIssues
            };
        }

        #endregion
    }
}
