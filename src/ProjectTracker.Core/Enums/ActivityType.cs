namespace ProjectTracker.Core.Enums
{
    /// <summary>
    /// Types of activities that can be logged
    /// </summary>
    public enum ActivityType
    {
        // Task Activities
        TaskCreated,
        TaskUpdated,
        TaskCompleted,
        TaskAssigned,
        TaskUnassigned,
        TaskDeleted,
        TaskStatusChanged,
        TaskPriorityChanged,
        
        // Project Activities
        ProjectCreated,
        ProjectUpdated,
        ProjectCompleted,
        ProjectDeleted,
        ProjectStatusChanged,
        
        // Team Activities
        TeamCreated,
        TeamUpdated,
        TeamDeleted,
        MemberAdded,
        MemberRemoved,
        MemberRoleChanged,
        
        // Comment Activities
        CommentAdded,
        CommentDeleted
    }
}
