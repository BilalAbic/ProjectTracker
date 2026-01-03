namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a GitHub commit cached locally
    /// Used for analytics and task-commit linking
    /// </summary>
    public class GitCommit
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int GitCommitId { get; set; }

        /// <summary>
        /// Foreign key - Repository this commit belongs to
        /// </summary>
        public int GitRepositoryId { get; set; }

        /// <summary>
        /// Git commit SHA (40 characters)
        /// </summary>
        public string Sha { get; set; } = string.Empty;

        /// <summary>
        /// Commit message (full)
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Git author name (from commit)
        /// </summary>
        public string? AuthorName { get; set; }

        /// <summary>
        /// Git author email (from commit)
        /// </summary>
        public string? AuthorEmail { get; set; }

        /// <summary>
        /// GitHub username of the author (if available)
        /// </summary>
        public string? AuthorGitHubUsername { get; set; }

        /// <summary>
        /// GitHub avatar URL of the author
        /// </summary>
        public string? AuthorAvatarUrl { get; set; }

        /// <summary>
        /// When was this commit made?
        /// </summary>
        public DateTime CommitDate { get; set; }

        /// <summary>
        /// Number of lines added
        /// </summary>
        public int Additions { get; set; }

        /// <summary>
        /// Number of lines deleted
        /// </summary>
        public int Deletions { get; set; }

        /// <summary>
        /// Number of files changed
        /// </summary>
        public int ChangedFilesCount { get; set; }

        /// <summary>
        /// Foreign key - Linked task (nullable, auto-matched)
        /// </summary>
        public int? LinkedTaskId { get; set; }

        /// <summary>
        /// Match score for task linking (0-100)
        /// </summary>
        public double MatchScore { get; set; }

        /// <summary>
        /// When was this commit cached?
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Navigation property - Repository
        /// </summary>
        public virtual GitRepository Repository { get; set; } = null!;

        /// <summary>
        /// Navigation property - Linked task (if any)
        /// </summary>
        public virtual Task? LinkedTask { get; set; }

        /// <summary>
        /// Navigation property - File changes in this commit
        /// </summary>
        public virtual ICollection<GitFileChange> FileChanges { get; set; } = new List<GitFileChange>();
    }
}
