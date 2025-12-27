namespace ProjectTracker.Core.Enums
{
    /// <summary>
    /// Defines the possible states of a task
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// Task is waiting to be started
        /// </summary>
        Pending = 1,

        /// <summary>
        /// Task is currently being worked on
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// Task has been completed
        /// </summary>
        Completed = 3,

        /// <summary>
        /// Task has been cancelled
        /// </summary>
        Cancelled = 4,

        /// <summary>
        /// Task is blocked by dependencies
        /// </summary>
        Blocked = 5
    }
}