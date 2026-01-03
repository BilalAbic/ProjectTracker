namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a GitHub Personal Access Token stored by a user
    /// Used for GitHub API authentication and rate limit pooling
    /// </summary>
    public class GitHubToken
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int GitHubTokenId { get; set; }

        /// <summary>
        /// Foreign key - User who owns this token
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Encrypted GitHub Personal Access Token
        /// Never store plain text tokens!
        /// </summary>
        public string EncryptedToken { get; set; } = string.Empty;

        /// <summary>
        /// GitHub username associated with this token
        /// </summary>
        public string? GitHubUsername { get; set; }

        /// <summary>
        /// Remaining API calls before rate limit reset
        /// Default: 5000 for authenticated requests
        /// </summary>
        public int RateLimitRemaining { get; set; } = 5000;

        /// <summary>
        /// When the rate limit will reset (UTC)
        /// </summary>
        public DateTime? RateLimitResetAt { get; set; }

        /// <summary>
        /// Is this token active and usable?
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Last time this token was used for an API call
        /// </summary>
        public DateTime? LastUsedAt { get; set; }

        /// <summary>
        /// When was this token added?
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Navigation property - User who owns this token
        /// </summary>
        public virtual User User { get; set; } = null!;
    }
}
