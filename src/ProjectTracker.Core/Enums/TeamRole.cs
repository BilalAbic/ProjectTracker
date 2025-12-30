namespace ProjectTracker.Core.Enums
{
    /// <summary>
    /// Team member roles
    /// </summary>
    public enum TeamRole
    {
        /// <summary>
        /// Team owner - full control
        /// </summary>
        Owner = 1,

        /// <summary>
        /// Team admin - can manage members and settings
        /// </summary>
        Admin = 2,

        /// <summary>
        /// Project manager - can create and manage projects
        /// </summary>
        ProjectManager = 3,

        /// <summary>
        /// Developer - can work on assigned tasks
        /// </summary>
        Developer = 4,

        /// <summary>
        /// Observer - read-only access
        /// </summary>
        Observer = 5
    }
}
