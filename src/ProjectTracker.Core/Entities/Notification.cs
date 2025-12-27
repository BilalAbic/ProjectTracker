namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a notification sent to a user
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Primary key - Unique identifier for the notification
        /// </summary>
        public int NotificationId { get; set; }

        /// <summary>
        /// Foreign key - User who receives this notification
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Notification title
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Notification message content
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Type of notification (Info, Warning, Error, Success)
        /// </summary>
        public string Type { get; set; } = "Info";

        /// <summary>
        /// Has the user read this notification?
        /// </summary>
        public bool IsRead { get; set; } = false;

        /// <summary>
        /// When was this notification created?
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Navigation property - User who receives this notification
        /// </summary>
        public virtual User User { get; set; } = null!;
    }
}