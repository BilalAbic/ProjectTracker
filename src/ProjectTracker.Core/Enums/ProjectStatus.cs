namespace ProjectTracker.Core.Enums
{
    /// <summary>
    /// Defines the possible states of a project
    /// </summary>
    public enum ProjectStatus
    {
        /// <summary>
        /// Project is in planning phase
        /// </summary>
        Planned = 1,

        /// <summary>
        /// Project is actively being worked on
        /// </summary>
        Active = 2,

        /// <summary>
        /// Project is temporarily paused
        /// </summary>
        OnHold = 3,

        /// <summary>
        /// Project has been successfully completed
        /// </summary>
        Completed = 4,

        /// <summary>
        /// Project has been cancelled
        /// </summary>
        Cancelled = 5
    }
}