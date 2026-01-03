namespace GitHubAnalyzerTest.Models;

// ═══════════════════════════════════════════════════════════════
// TOKEN HAVUZU
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// GitHub Token (Kullanıcı ayarlarından gelecek)
/// </summary>
public class GitHubToken
{
    public int TokenId { get; set; }
    public int UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public string? GitHubUsername { get; set; }
    public int RateLimitRemaining { get; set; } = 5000;
    public DateTime? RateLimitResetAt { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? LastUsedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

/// <summary>
/// Token havuzu durumu
/// </summary>
public class TokenPoolStatus
{
    public int TotalTokens { get; set; }
    public int ActiveTokens { get; set; }
    public int TotalRateLimitRemaining { get; set; }
    public DateTime? NextResetAt { get; set; }
    public List<TokenStatus> Tokens { get; set; } = new();
}

public class TokenStatus
{
    public string GitHubUsername { get; set; } = string.Empty;
    public int RateLimitRemaining { get; set; }
    public DateTime? ResetAt { get; set; }
    public bool IsActive { get; set; }
}

// ═══════════════════════════════════════════════════════════════
// REPOSITORY
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// GitHub Repository bağlantısı
/// </summary>
public class GitRepository
{
    public int GitRepoId { get; set; }
    public int ProjectId { get; set; }
    public string RepoUrl { get; set; } = string.Empty;
    public string RepoOwner { get; set; } = string.Empty;
    public string RepoName { get; set; } = string.Empty;
    public string DefaultBranch { get; set; } = "main";
    public bool IsPrivate { get; set; }
    public DateTime? LastSyncAt { get; set; }
    public string SyncStatus { get; set; } = "Pending";
    public int TotalCommits { get; set; }
    public int TotalBranches { get; set; }
    public int TotalContributors { get; set; }
    public int OpenIssues { get; set; }
    public int OpenPullRequests { get; set; }
    
    // Navigation
    public List<GitCommit> Commits { get; set; } = new();
    public List<GitDailyStat> DailyStats { get; set; } = new();
}

// ═══════════════════════════════════════════════════════════════
// COMMIT
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// GitHub Commit (yerel cache)
/// </summary>
public class GitCommit
{
    public int GitCommitId { get; set; }
    public int GitRepoId { get; set; }
    public string Sha { get; set; } = string.Empty;
    public string ShortSha => Sha.Length >= 7 ? Sha[..7] : Sha;
    public string? Message { get; set; }
    public string? MessageFirstLine => Message?.Split('\n').FirstOrDefault();
    public string? AuthorName { get; set; }
    public string? AuthorEmail { get; set; }
    public string? AuthorGitHubUsername { get; set; }
    public string? AuthorAvatarUrl { get; set; }
    public DateTime CommitDate { get; set; }
    public int Additions { get; set; }
    public int Deletions { get; set; }
    public int ChangedFiles { get; set; }
    
    // Task eşleştirme (Task Name benzerliği ile)
    public int? LinkedTaskId { get; set; }
    public string? LinkedTaskName { get; set; }
    public double MatchScore { get; set; }  // Benzerlik skoru (0-100)
    
    // Dosya değişiklikleri
    public List<GitFileChange> FileChanges { get; set; } = new();
}

/// <summary>
/// Dosya değişikliği
/// </summary>
public class GitFileChange
{
    public int FileChangeId { get; set; }
    public int GitCommitId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string? FileExtension { get; set; }
    public string? Status { get; set; }  // added, modified, deleted, renamed
    public int Additions { get; set; }
    public int Deletions { get; set; }
}

// ═══════════════════════════════════════════════════════════════
// GÜNLÜK İSTATİSTİK
// ═══════════════════════════════════════════════════════════════

public class GitDailyStat
{
    public int StatId { get; set; }
    public int GitRepoId { get; set; }
    public DateTime StatDate { get; set; }
    public int CommitCount { get; set; }
    public int TotalAdditions { get; set; }
    public int TotalDeletions { get; set; }
    public int UniqueContributors { get; set; }
}

// ═══════════════════════════════════════════════════════════════
// PROJE VE GÖREV (ProjectTracker simülasyonu)
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// ProjectTracker Projesi (simülasyon)
/// </summary>
public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? GitHubRepoUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Navigation
    public GitRepository? GitRepository { get; set; }
    public List<ProjectTask> Tasks { get; set; } = new();
}

/// <summary>
/// ProjectTracker Görevi (simülasyon)
/// </summary>
public class ProjectTask
{
    public int TaskId { get; set; }
    public int ProjectId { get; set; }
    public string TaskName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = "Todo";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Eşleşen commit'ler
    public List<GitCommit> LinkedCommits { get; set; } = new();
}

// ═══════════════════════════════════════════════════════════════
// KULLANICI (ProjectTracker simülasyonu)
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// ProjectTracker Kullanıcısı (simülasyon)
/// </summary>
public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string? Email { get; set; }
    
    // GitHub bilgileri (kullanıcı ayarlarından)
    public string? GitHubUsername { get; set; }
    public string? GitHubToken { get; set; }  // Şifrelenmiş olacak gerçek uygulamada
    public string? GitHubAvatarUrl { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

// ═══════════════════════════════════════════════════════════════
// ANALİTİK DTO'LAR
// ═══════════════════════════════════════════════════════════════

/// <summary>
/// Repository sağlık durumu (Dashboard widget'ları)
/// </summary>
public class RepoHealthDto
{
    public int TotalCommits { get; set; }
    public DateTime? LastCommitDate { get; set; }
    public string LastCommitAgo { get; set; } = string.Empty;
    public int OpenIssues { get; set; }
    public int OpenPullRequests { get; set; }
    public int ActiveBranches { get; set; }
    public int TotalContributors { get; set; }
    public int TotalAdditions { get; set; }
    public int TotalDeletions { get; set; }
    public int NetCodeLines => TotalAdditions - TotalDeletions;
    public string SyncStatus { get; set; } = string.Empty;
    public DateTime? LastSyncAt { get; set; }
}

/// <summary>
/// Geliştirici istatistikleri (Leaderboard)
/// </summary>
public class DeveloperStatsDto
{
    public string GitHubUsername { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public int? LinkedUserId { get; set; }
    public string? LinkedUserName { get; set; }
    public int TotalCommits { get; set; }
    public int TotalAdditions { get; set; }
    public int TotalDeletions { get; set; }
    public int NetLines => TotalAdditions - TotalDeletions;
    public double ContributionPercentage { get; set; }
    public DateTime? FirstCommitDate { get; set; }
    public DateTime? LastCommitDate { get; set; }
    public int ActiveDays { get; set; }
    public double AverageCommitsPerDay { get; set; }
    public int Rank { get; set; }
}

/// <summary>
/// Punch Card hücresi (Heatmap)
/// </summary>
public class PunchCardCell
{
    public DayOfWeek Day { get; set; }
    public int Hour { get; set; }
    public int CommitCount { get; set; }
    public double Intensity { get; set; }  // 0-1 arası
}

/// <summary>
/// Commit trend verisi
/// </summary>
public class CommitTrendDto
{
    public DateTime Date { get; set; }
    public int CommitCount { get; set; }
    public int CumulativeCommits { get; set; }
}

/// <summary>
/// Hotspot (sık değişen dosya)
/// </summary>
public class HotspotDto
{
    public string FileName { get; set; } = string.Empty;
    public string? FileExtension { get; set; }
    public int ChangeCount { get; set; }
    public int TotalAdditions { get; set; }
    public int TotalDeletions { get; set; }
    public int UniqueContributors { get; set; }
    public DateTime? LastModified { get; set; }
    public string RiskLevel { get; set; } = "Low";
}

/// <summary>
/// Task-Commit eşleştirme sonucu
/// </summary>
public class TaskCommitMatchDto
{
    public int TaskId { get; set; }
    public string TaskName { get; set; } = string.Empty;
    public string CommitSha { get; set; } = string.Empty;
    public string CommitMessage { get; set; } = string.Empty;
    public double MatchScore { get; set; }
    public string MatchReason { get; set; } = string.Empty;
}

/// <summary>
/// Senkronizasyon sonucu
/// </summary>
public class SyncResultDto
{
    public int GitRepoId { get; set; }
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public TimeSpan Duration => (CompletedAt ?? DateTime.Now) - StartedAt;
    public int NewCommits { get; set; }
    public int TotalCommits { get; set; }
    public int LinkedTasks { get; set; }
    public int BranchCount { get; set; }
}
