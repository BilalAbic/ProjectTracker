namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a file change within a commit
    /// Used for hotspot analysis and code churn metrics
    /// </summary>
    public class GitFileChange
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int GitFileChangeId { get; set; }

        /// <summary>
        /// Foreign key - Commit this file change belongs to
        /// </summary>
        public int GitCommitId { get; set; }

        /// <summary>
        /// Full file path
        /// Example: src/ProjectTracker.Business/Services/ProjectService.cs
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// File extension (for language analysis)
        /// Example: .cs, .js, .sql
        /// </summary>
        public string? FileExtension { get; set; }

        /// <summary>
        /// Change status: added, modified, deleted, renamed
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Number of lines added in this file
        /// </summary>
        public int Additions { get; set; }

        /// <summary>
        /// Number of lines deleted in this file
        /// </summary>
        public int Deletions { get; set; }

        /// <summary>
        /// Navigation property - Commit
        /// </summary>
        public virtual GitCommit Commit { get; set; } = null!;
    }
}
