using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces.Repositories;

namespace ProjectTracker.Core.Interfaces
{
    /// <summary>
    /// Unit of Work pattern - manages transactions and repositories
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        // ============================================
        // REPOSITORY PROPERTIES
        // ============================================

        /// <summary>
        /// Users repository
        /// </summary>
        IRepository<User> Users { get; }

        /// <summary>
        /// Projects repository
        /// </summary>
        IRepository<Project> Projects { get; }

        /// <summary>
        /// Tasks repository
        /// </summary>
        IRepository<Core.Entities.Task> Tasks { get; }

        /// <summary>
        /// Roles repository
        /// </summary>
        IRepository<Role> Roles { get; }

        /// <summary>
        /// Task Comments repository
        /// </summary>
        IRepository<TaskComment> TaskComments { get; }

        /// <summary>
        /// Notifications repository
        /// </summary>
        IRepository<Notification> Notifications { get; }

        /// <summary>
        /// Project Team Members repository
        /// </summary>
        IRepository<ProjectTeamMember> ProjectTeamMembers { get; }

        /// <summary>
        /// Project Risks repository
        /// </summary>
        IRepository<ProjectRisk> ProjectRisks { get; }

        /// <summary>
        /// Audit Logs repository
        /// </summary>
        IRepository<AuditLog> AuditLogs { get; }

        /// <summary>
        /// Teams repository
        /// </summary>
        IRepository<Team> Teams { get; }

        /// <summary>
        /// Team Members repository
        /// </summary>
        IRepository<TeamMember> TeamMembers { get; }

        /// <summary>
        /// Team Invitations repository
        /// </summary>
        IRepository<TeamInvitation> TeamInvitations { get; }

        // ============================================
        // TRANSACTION OPERATIONS
        // ============================================

        /// <summary>
        /// Save all changes to the database (commit transaction)
        /// </summary>
        /// <returns>Number of affected rows</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Begin a database transaction
        /// </summary>
        System.Threading.Tasks.Task BeginTransactionAsync();

        /// <summary>
        /// Commit the current transaction
        /// </summary>
        System.Threading.Tasks.Task CommitTransactionAsync();

        /// <summary>
        /// Rollback the current transaction
        /// </summary>
        System.Threading.Tasks.Task RollbackTransactionAsync();
    }
}