namespace ProjectTracker.Core.Enums
{
    /// <summary>
    /// Defines priority levels for tasks and projects
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// Low priority - can be done later
        /// </summary>
        Low = 1,

        /// <summary>
        /// Normal priority - standard importance
        /// </summary>
        Medium = 2,

        /// <summary>
        /// High priority - should be done soon
        /// </summary>
        High = 3,

        /// <summary>
        /// Critical priority - urgent, blocking other work
        /// </summary>
        Critical = 4
    }
}