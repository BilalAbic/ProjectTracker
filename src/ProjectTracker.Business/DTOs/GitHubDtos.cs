namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// DTO for GitHub Token
    /// </summary>
    public class GitHubTokenDto
    {
        public int GitHubTokenId { get; set; }
        public int UserId { get; set; }
        public string? GitHubUsername { get; set; }
        public int RateLimitRemaining { get; set; }
        public DateTime? RateLimitResetAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastUsedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// DTO for creating/updating GitHub Token
    /// </summary>
    public class SaveGitHubTokenDto
    {
        public string Token { get; set; } = string.Empty;
        public string? GitHubUsername { get; set; }
    }

    /// <summary>
    /// DTO for Git Repository
    /// </summary>
    public class GitRepositoryDto
    {
        public int GitRepositoryId { get; set; }
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
    }

    /// <summary>
    /// DTO for Git Commit
    /// </summary>
    public class GitCommitDto
    {
        public int GitCommitId { get; set; }
        public int GitRepositoryId { get; set; }
        public string Sha { get; set; } = string.Empty;
        public string ShortSha => Sha.Length >= 7 ? Sha[..7] : Sha;
        public string? Message { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorEmail { get; set; }
        public string? AuthorGitHubUsername { get; set; }
        public string? AuthorAvatarUrl { get; set; }
        public DateTime CommitDate { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }
        public int ChangedFilesCount { get; set; }
        public int? LinkedTaskId { get; set; }
        public string? LinkedTaskName { get; set; }
        public double MatchScore { get; set; }
        public List<GitFileChangeDto> FileChanges { get; set; } = new();
    }

    /// <summary>
    /// DTO for Git File Change
    /// </summary>
    public class GitFileChangeDto
    {
        public int GitFileChangeId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string? FileExtension { get; set; }
        public string? Status { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }
    }

    /// <summary>
    /// DTO for Leaderboard entry
    /// </summary>
    public class LeaderboardEntryDto
    {
        public int Rank { get; set; }
        public string Author { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public int CommitCount { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }
        public int NetLines => Additions - Deletions;
    }

    /// <summary>
    /// DTO for Punch Card data
    /// </summary>
    public class PunchCardEntryDto
    {
        public int DayOfWeek { get; set; }
        public string DayName { get; set; } = string.Empty;
        public int Hour { get; set; }
        public int Count { get; set; }
    }

    /// <summary>
    /// DTO for Hotspot (most changed files)
    /// </summary>
    public class HotspotDto
    {
        public string FileName { get; set; } = string.Empty;
        public int ChangeCount { get; set; }
        public int TotalAdditions { get; set; }
        public int TotalDeletions { get; set; }
    }

    /// <summary>
    /// DTO for Language Distribution
    /// </summary>
    public class LanguageDistributionDto
    {
        public string Extension { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public int FileCount { get; set; }
        public int TotalChanges { get; set; }
        public double Percentage { get; set; }
    }

    /// <summary>
    /// DTO for GitHub Analytics Summary
    /// </summary>
    public class GitHubAnalyticsSummaryDto
    {
        public int TotalCommits { get; set; }
        public int TotalContributors { get; set; }
        public int TotalAdditions { get; set; }
        public int TotalDeletions { get; set; }
        public DateTime? LastCommitDate { get; set; }
        public DateTime? FirstCommitDate { get; set; }
        public int MatchedTasksCount { get; set; }
        public double AverageMatchScore { get; set; }
        public List<LeaderboardEntryDto> Leaderboard { get; set; } = new();
        public List<HotspotDto> Hotspots { get; set; } = new();
        public List<LanguageDistributionDto> LanguageDistribution { get; set; } = new();
    }

    /// <summary>
    /// DTO for Sync Result
    /// </summary>
    public class SyncResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int NewCommitsCount { get; set; }
        public int UpdatedCommitsCount { get; set; }
        public int MatchedTasksCount { get; set; }
        public DateTime SyncedAt { get; set; }
    }

    /// <summary>
    /// DTO for Commit Trend (daily commit count)
    /// </summary>
    public class CommitTrendDto
    {
        public DateTime Date { get; set; }
        public int CommitCount { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }
    }
}
