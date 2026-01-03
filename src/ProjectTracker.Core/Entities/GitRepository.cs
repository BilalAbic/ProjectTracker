namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a GitHub repository linked to a ProjectTracker project
    /// Stores cached repository information and sync status
    /// </summary>
    public class GitRepository
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int GitRepositoryId { get; set; }

        /// <summary>
        /// Foreign key - ProjectTracker project this repo is linked to
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Full GitHub repository URL
        /// Example: https://github.com/BilalAbic/ProjectTracker
        /// </summary>
        public string RepoUrl { get; set; } = string.Empty;

        /// <summary>
        /// Repository owner (username or organization)
        /// Example: BilalAbic
        /// </summary>
        public string RepoOwner { get; set; } = string.Empty;

        /// <summary>
        /// Repository name
        /// Example: ProjectTracker
        /// </summary>
        public string RepoName { get; set; } = string.Empty;

        /// <summary>
        /// Default branch name
        /// </summary>
        public string DefaultBranch { get; set; } = "main";

        /// <summary>
        /// Is this a private repository?
        /// </summary>
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Last successful sync timestamp
        /// </summary>
        public DateTime? LastSyncAt { get; set; }

        /// <summary>
        /// Current sync status: Pending, Syncing, Completed, Failed
        /// </summary>
        public string SyncStatus { get; set; } = "Pending";

        /// <summary>
        /// Total number of commits (cached)
        /// </summary>
        public int TotalCommits { get; set; }

        /// <summary>
        /// Total number of branches (cached)
        /// </summary>
        public int TotalBranches { get; set; }

        /// <summary>
        /// Total number of unique contributors (cached)
        /// </summary>
        public int TotalContributors { get; set; }

        /// <summary>
        /// Number of open issues (cached)
        /// </summary>
        public int OpenIssues { get; set; }

        /// <summary>
        /// When was this repository link created?
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Navigation property - Project this repo belongs to
        /// </summary>
        public virtual Project Project { get; set; } = null!;

        /// <summary>
        /// Navigation property - Commits in this repository
        /// </summary>
        public virtual ICollection<GitCommit> Commits { get; set; } = new List<GitCommit>();
    }
}
