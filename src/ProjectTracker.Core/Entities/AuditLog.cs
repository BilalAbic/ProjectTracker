namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents an audit log entry for tracking system changes
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// Primary key - Unique identifier
        /// </summary>
        public int LogId { get; set; }

        /// <summary>
        /// Which table was affected? (e.g., "Users", "Projects")
        /// </summary>
        public string TableName { get; set; } = string.Empty;

        /// <summary>
        /// Which record was affected? (e.g., UserId = 5)
        /// </summary>
        public int RecordId { get; set; }

        /// <summary>
        /// What action was performed? (Create, Update, Delete)
        /// </summary>
        public string Action { get; set; } = string.Empty;

        /// <summary>
        /// Old values (before change) - JSON format
        /// </summary>
        public string? OldValues { get; set; }

        /// <summary>
        /// New values (after change) - JSON format
        /// </summary>
        public string? NewValues { get; set; }

        /// <summary>
        /// Who performed this action? (UserId)
        /// </summary>
        public int? PerformedByUserId { get; set; }

        /// <summary>
        /// When did this action occur?
        /// </summary>
        public DateTime PerformedAt { get; set; } = DateTime.Now;
    }
}