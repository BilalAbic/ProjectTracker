using Octokit;
using GitHubAnalyzerTest.Models;

namespace GitHubAnalyzerTest.Services;

/// <summary>
/// GitHub Senkronizasyon Servisi
/// Repository verilerini çeker ve yerel cache'e kaydeder
/// </summary>
public class GitHubSyncService
{
    private readonly TokenPoolService _tokenPool;
    private readonly TaskMatchingService _taskMatcher;
    private GitHubClient? _client;
    private GitHubToken? _currentToken;

    public GitHubSyncService(TokenPoolService tokenPool, TaskMatchingService taskMatcher)
    {
        _tokenPool = tokenPool;
        _taskMatcher = taskMatcher;
    }

    /// <summary>
    /// GitHub client'ı en uygun token ile hazırlar
    /// </summary>
    private async Task<GitHubClient?> GetClientAsync()
    {
        _currentToken = _tokenPool.GetBestAvailableToken();
        
        if (_currentToken == null)
        {
            Console.WriteLine("   ⚠️ Havuzda kullanılabilir token yok!");
            return null;
        }

        _client = new GitHubClient(new ProductHeaderValue("ProjectTracker-Test"));
        _client.Credentials = new Credentials(_currentToken.Token);
        
        Console.WriteLine($"   🔑 Token kullanılıyor: {_currentToken.GitHubUsername} (Limit: {_currentToken.RateLimitRemaining})");
        
        return _client;
    }

    /// <summary>
    /// API çağrısı sonrası rate limit'i günceller
    /// </summary>
    private void UpdateRateLimit()
    {
        if (_client != null && _currentToken != null)
        {
            var apiInfo = _client.GetLastApiInfo();
            if (apiInfo?.RateLimit != null)
            {
                _tokenPool.UpdateTokenRateLimit(
                    _currentToken.TokenId,
                    apiInfo.RateLimit.Remaining,
                    apiInfo.RateLimit.Reset.DateTime);
            }
        }
    }

    /// <summary>
    /// Repository URL'sini parse eder
    /// </summary>
    public (string owner, string repo)? ParseRepoUrl(string repoUrl)
    {
        try
        {
            repoUrl = repoUrl.Trim().Trim('"').Trim('\'').TrimEnd('/').Replace(".git", "");
            
            if (repoUrl.Contains("github.com/"))
            {
                var parts = repoUrl.Split("github.com/")[1].Split('/');
                if (parts.Length >= 2)
                {
                    return (parts[0], parts[1]);
                }
            }
        }
        catch { }
        
        return null;
    }

    /// <summary>
    /// Repository'yi senkronize eder
    /// </summary>
    public async Task<SyncResultDto> SyncRepositoryAsync(GitRepository repo, List<ProjectTask> tasks)
    {
        var result = new SyncResultDto
        {
            GitRepoId = repo.GitRepoId,
            StartedAt = DateTime.Now
        };

        try
        {
            Console.WriteLine($"\n🔄 Senkronizasyon başlıyor: {repo.RepoOwner}/{repo.RepoName}");
            repo.SyncStatus = "Syncing";

            var client = await GetClientAsync();
            if (client == null)
            {
                result.Success = false;
                result.ErrorMessage = "Kullanılabilir token yok";
                return result;
            }

            // 1. Repository bilgilerini al
            Console.WriteLine("   📊 Repository bilgileri alınıyor...");
            var ghRepo = await client.Repository.Get(repo.RepoOwner, repo.RepoName);
            UpdateRateLimit();
            
            repo.OpenIssues = ghRepo.OpenIssuesCount;
            repo.DefaultBranch = ghRepo.DefaultBranch;
            repo.IsPrivate = ghRepo.Private;

            // 2. Branch sayısını al
            var branches = await client.Repository.Branch.GetAll(repo.RepoOwner, repo.RepoName);
            UpdateRateLimit();
            repo.TotalBranches = branches.Count;
            result.BranchCount = branches.Count;

            // 3. Commit'leri çek
            Console.WriteLine("   📝 Commit'ler alınıyor...");
            var commits = await FetchCommitsAsync(client, repo);
            result.NewCommits = commits.Count;
            result.TotalCommits = commits.Count;

            // 4. Contributor sayısını hesapla
            repo.TotalContributors = commits
                .Where(c => !string.IsNullOrEmpty(c.AuthorGitHubUsername))
                .Select(c => c.AuthorGitHubUsername)
                .Distinct()
                .Count();

            // 5. Task-Commit eşleştirmesi
            if (tasks.Any())
            {
                Console.WriteLine("   🔗 Task-Commit eşleştirmesi yapılıyor...");
                var matches = _taskMatcher.MatchCommitsToTasks(commits, tasks);
                result.LinkedTasks = matches.Count;
                
                // Task'lara commit'leri bağla
                foreach (var task in tasks)
                {
                    task.LinkedCommits = commits
                        .Where(c => c.LinkedTaskId == task.TaskId)
                        .ToList();
                }
            }

            // 6. Günlük istatistikleri hesapla
            Console.WriteLine("   📈 İstatistikler hesaplanıyor...");
            repo.DailyStats = CalculateDailyStats(commits);

            // Başarılı
            repo.Commits = commits;
            repo.TotalCommits = commits.Count;
            repo.LastSyncAt = DateTime.Now;
            repo.SyncStatus = "Completed";
            
            result.Success = true;
            result.CompletedAt = DateTime.Now;
            
            Console.WriteLine($"   ✅ Senkronizasyon tamamlandı! ({result.Duration.TotalSeconds:F1}s)");
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.ErrorMessage = ex.Message;
            repo.SyncStatus = "Failed";
            Console.WriteLine($"   ❌ Hata: {ex.Message}");
        }

        return result;
    }

    /// <summary>
    /// Commit'leri çeker
    /// </summary>
    private async Task<List<GitCommit>> FetchCommitsAsync(GitHubClient client, GitRepository repo, int maxCommits = 100)
    {
        var commits = new List<GitCommit>();
        var commitId = 1;

        try
        {
            var options = new ApiOptions { PageSize = 100, PageCount = 1 };
            var ghCommits = await client.Repository.Commit.GetAll(repo.RepoOwner, repo.RepoName, options);
            UpdateRateLimit();

            foreach (var ghCommit in ghCommits.Take(maxCommits))
            {
                var commit = new GitCommit
                {
                    GitCommitId = commitId++,
                    GitRepoId = repo.GitRepoId,
                    Sha = ghCommit.Sha,
                    Message = ghCommit.Commit.Message,
                    AuthorName = ghCommit.Commit.Author?.Name,
                    AuthorEmail = ghCommit.Commit.Author?.Email,
                    AuthorGitHubUsername = ghCommit.Author?.Login,
                    AuthorAvatarUrl = ghCommit.Author?.AvatarUrl,
                    CommitDate = ghCommit.Commit.Author?.Date.DateTime ?? DateTime.MinValue
                };

                // Commit detaylarını al (additions/deletions)
                try
                {
                    var detail = await client.Repository.Commit.Get(repo.RepoOwner, repo.RepoName, ghCommit.Sha);
                    UpdateRateLimit();
                    
                    commit.Additions = detail.Stats?.Additions ?? 0;
                    commit.Deletions = detail.Stats?.Deletions ?? 0;
                    commit.ChangedFiles = detail.Files?.Count ?? 0;

                    // Dosya değişikliklerini kaydet
                    if (detail.Files != null)
                    {
                        commit.FileChanges = detail.Files.Select(f => new GitFileChange
                        {
                            GitCommitId = commit.GitCommitId,
                            FileName = f.Filename,
                            FileExtension = Path.GetExtension(f.Filename),
                            Status = f.Status,
                            Additions = f.Additions,
                            Deletions = f.Deletions
                        }).ToList();
                    }
                }
                catch
                {
                    // Detay alınamazsa devam et
                }

                commits.Add(commit);
                
                // Rate limit kontrolü
                if (_currentToken?.RateLimitRemaining < 10)
                {
                    Console.WriteLine("   ⚠️ Rate limit düşük, durduruluyor...");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ⚠️ Commit çekme hatası: {ex.Message}");
        }

        return commits;
    }

    /// <summary>
    /// Günlük istatistikleri hesaplar
    /// </summary>
    private List<GitDailyStat> CalculateDailyStats(List<GitCommit> commits)
    {
        return commits
            .GroupBy(c => c.CommitDate.Date)
            .Select(g => new GitDailyStat
            {
                StatDate = g.Key,
                CommitCount = g.Count(),
                TotalAdditions = g.Sum(c => c.Additions),
                TotalDeletions = g.Sum(c => c.Deletions),
                UniqueContributors = g.Select(c => c.AuthorGitHubUsername).Distinct().Count()
            })
            .OrderBy(s => s.StatDate)
            .ToList();
    }

    /// <summary>
    /// Repository sağlık durumunu döndürür
    /// </summary>
    public RepoHealthDto GetRepositoryHealth(GitRepository repo)
    {
        var lastCommit = repo.Commits.OrderByDescending(c => c.CommitDate).FirstOrDefault();
        
        return new RepoHealthDto
        {
            TotalCommits = repo.TotalCommits,
            LastCommitDate = lastCommit?.CommitDate,
            LastCommitAgo = lastCommit != null ? GetTimeAgo(lastCommit.CommitDate) : "Bilinmiyor",
            OpenIssues = repo.OpenIssues,
            OpenPullRequests = repo.OpenPullRequests,
            ActiveBranches = repo.TotalBranches,
            TotalContributors = repo.TotalContributors,
            TotalAdditions = repo.Commits.Sum(c => c.Additions),
            TotalDeletions = repo.Commits.Sum(c => c.Deletions),
            SyncStatus = repo.SyncStatus,
            LastSyncAt = repo.LastSyncAt
        };
    }

    /// <summary>
    /// Geliştirici liderlik tablosunu döndürür
    /// </summary>
    public List<DeveloperStatsDto> GetDeveloperLeaderboard(GitRepository repo)
    {
        var totalCommits = repo.Commits.Count;
        var rank = 1;

        return repo.Commits
            .Where(c => !string.IsNullOrEmpty(c.AuthorGitHubUsername))
            .GroupBy(c => c.AuthorGitHubUsername)
            .Select(g =>
            {
                var commits = g.ToList();
                var dates = commits.Select(c => c.CommitDate).OrderBy(d => d).ToList();
                var activeDays = dates.Any() ? (int)(dates.Last() - dates.First()).TotalDays + 1 : 0;

                return new DeveloperStatsDto
                {
                    GitHubUsername = g.Key!,
                    AvatarUrl = commits.FirstOrDefault()?.AuthorAvatarUrl,
                    TotalCommits = commits.Count,
                    TotalAdditions = commits.Sum(c => c.Additions),
                    TotalDeletions = commits.Sum(c => c.Deletions),
                    ContributionPercentage = totalCommits > 0 ? Math.Round((double)commits.Count / totalCommits * 100, 1) : 0,
                    FirstCommitDate = dates.FirstOrDefault(),
                    LastCommitDate = dates.LastOrDefault(),
                    ActiveDays = activeDays,
                    AverageCommitsPerDay = activeDays > 0 ? Math.Round((double)commits.Count / activeDays, 2) : 0
                };
            })
            .OrderByDescending(d => d.TotalCommits)
            .Select(d => { d.Rank = rank++; return d; })
            .ToList();
    }

    /// <summary>
    /// Punch Card (Heatmap) verisi döndürür
    /// </summary>
    public List<PunchCardCell> GetPunchCard(GitRepository repo)
    {
        var cells = new List<PunchCardCell>();
        var commitsByDayHour = repo.Commits
            .GroupBy(c => (c.CommitDate.DayOfWeek, c.CommitDate.Hour))
            .ToDictionary(g => g.Key, g => g.Count());

        var maxCommits = commitsByDayHour.Values.DefaultIfEmpty(0).Max();

        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            for (int hour = 0; hour < 24; hour++)
            {
                var count = commitsByDayHour.GetValueOrDefault((day, hour), 0);
                cells.Add(new PunchCardCell
                {
                    Day = day,
                    Hour = hour,
                    CommitCount = count,
                    Intensity = maxCommits > 0 ? (double)count / maxCommits : 0
                });
            }
        }

        return cells;
    }

    /// <summary>
    /// Hotspot dosyalarını döndürür
    /// </summary>
    public List<HotspotDto> GetHotspots(GitRepository repo, int top = 10)
    {
        return repo.Commits
            .SelectMany(c => c.FileChanges)
            .GroupBy(f => f.FileName)
            .Select(g => new HotspotDto
            {
                FileName = g.Key,
                FileExtension = g.First().FileExtension,
                ChangeCount = g.Count(),
                TotalAdditions = g.Sum(f => f.Additions),
                TotalDeletions = g.Sum(f => f.Deletions),
                LastModified = repo.Commits
                    .Where(c => c.FileChanges.Any(f => f.FileName == g.Key))
                    .Max(c => c.CommitDate),
                RiskLevel = g.Count() > 20 ? "High" : g.Count() > 10 ? "Medium" : "Low"
            })
            .OrderByDescending(h => h.ChangeCount)
            .Take(top)
            .ToList();
    }

    /// <summary>
    /// Commit trend verisi döndürür
    /// </summary>
    public List<CommitTrendDto> GetCommitTrend(GitRepository repo, int days = 30)
    {
        var startDate = DateTime.Now.AddDays(-days).Date;
        var cumulative = 0;

        return Enumerable.Range(0, days)
            .Select(i => startDate.AddDays(i))
            .Select(date =>
            {
                var count = repo.Commits.Count(c => c.CommitDate.Date == date);
                cumulative += count;
                return new CommitTrendDto
                {
                    Date = date,
                    CommitCount = count,
                    CumulativeCommits = cumulative
                };
            })
            .ToList();
    }

    private string GetTimeAgo(DateTime date)
    {
        var span = DateTime.Now - date;
        if (span.TotalMinutes < 60) return $"{(int)span.TotalMinutes} dakika önce";
        if (span.TotalHours < 24) return $"{(int)span.TotalHours} saat önce";
        if (span.TotalDays < 7) return $"{(int)span.TotalDays} gün önce";
        if (span.TotalDays < 30) return $"{(int)(span.TotalDays / 7)} hafta önce";
        return $"{(int)(span.TotalDays / 30)} ay önce";
    }
}
