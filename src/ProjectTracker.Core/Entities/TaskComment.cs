namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a comment on a task
    /// </summary>
    public class TaskComment
    {
        /// <summary>
        /// Primary key - Unique identifier for the comment
        /// </summary>
        public int CommentId { get; set; }

        /// <summary>
        /// Foreign key - Task this comment belongs to
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Foreign key - User who created this comment
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Comment text content
        /// </summary>
        public string CommentText { get; set; } = string.Empty;

        /// <summary>
        /// When was this comment created?
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Navigation property - Task this comment belongs to
        /// </summary>
        public virtual Task Task { get; set; } = null!;

        /// <summary>
        /// Navigation property - User who created this comment
        /// </summary>
        public virtual User User { get; set; } = null!;
    }
}