using Microsoft.EntityFrameworkCore.Storage;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using ProjectTracker.Core.Interfaces.Repositories;
using ProjectTracker.Data.Context;
using ProjectTracker.Data.Repositories;

namespace ProjectTracker.Data
{
    /// <summary>
    /// Unit of Work implementation - manages transactions and repositories
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        // Repository fields (private, lazy initialized)
        private IRepository<User>? _users;
        private IRepository<Project>? _projects;
        private IRepository<Core.Entities.Task>? _tasks;
        private IRepository<Role>? _roles;
        private IRepository<TaskComment>? _taskComments;
        private IRepository<Notification>? _notifications;
        private IRepository<ProjectTeamMember>? _projectTeamMembers;
        private IRepository<ProjectRisk>? _projectRisks;
        private IRepository<AuditLog>? _auditLogs;
        private IRepository<Team>? _teams;
        private IRepository<TeamMember>? _teamMembers;
        private IRepository<TeamInvitation>? _teamInvitations;
        private IRepository<TimeEntry>? _timeEntries;
        private IRepository<ProjectSnapshot>? _projectSnapshots;
        private IGitHubTokenRepository? _gitHubTokens;
        private IGitRepositoryRepository? _gitRepositories;
        private IGitCommitRepository? _gitCommits;
        private IGitFileChangeRepository? _gitFileChanges;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        // ============================================
        // REPOSITORY PROPERTIES (Lazy initialization)
        // ============================================

        /// <summary>
        /// Users repository - lazy initialized
        /// </summary>
        public IRepository<User> Users => _users ??= new Repository<User>(_context);

        /// <summary>
        /// Projects repository - lazy initialized
        /// </summary>
        public IRepository<Project> Projects => _projects ??= new Repository<Project>(_context);

        /// <summary>
        /// Tasks repository - lazy initialized
        /// </summary>
        public IRepository<Core.Entities.Task> Tasks => _tasks ??= new Repository<Core.Entities.Task>(_context);

        /// <summary>
        /// Roles repository - lazy initialized
        /// </summary>
        public IRepository<Role> Roles => _roles ??= new Repository<Role>(_context);

        /// <summary>
        /// Task Comments repository - lazy initialized
        /// </summary>
        public IRepository<TaskComment> TaskComments => _taskComments ??= new Repository<TaskComment>(_context);

        /// <summary>
        /// Notifications repository - lazy initialized
        /// </summary>
        public IRepository<Notification> Notifications => _notifications ??= new Repository<Notification>(_context);

        /// <summary>
        /// Project Team Members repository - lazy initialized
        /// </summary>
        public IRepository<ProjectTeamMember> ProjectTeamMembers => _projectTeamMembers ??= new Repository<ProjectTeamMember>(_context);

        /// <summary>
        /// Project Risks repository - lazy initialized
        /// </summary>
        public IRepository<ProjectRisk> ProjectRisks => _projectRisks ??= new Repository<ProjectRisk>(_context);

        /// <summary>
        /// Audit Logs repository - lazy initialized
        /// </summary>
        public IRepository<AuditLog> AuditLogs => _auditLogs ??= new Repository<AuditLog>(_context);

        /// <summary>
        /// Teams repository - lazy initialized
        /// </summary>
        public IRepository<Team> Teams => _teams ??= new Repository<Team>(_context);

        /// <summary>
        /// Team Members repository - lazy initialized
        /// </summary>
        public IRepository<TeamMember> TeamMembers => _teamMembers ??= new Repository<TeamMember>(_context);

        /// <summary>
        /// Team Invitations repository - lazy initialized
        /// </summary>
        public IRepository<TeamInvitation> TeamInvitations => _teamInvitations ??= new Repository<TeamInvitation>(_context);

        /// <summary>
        /// Time Entries repository - lazy initialized (Phase 7)
        /// </summary>
        public IRepository<TimeEntry> TimeEntries => _timeEntries ??= new Repository<TimeEntry>(_context);

        /// <summary>
        /// Project Snapshots repository - lazy initialized (Phase 7)
        /// </summary>
        public IRepository<ProjectSnapshot> ProjectSnapshots => _projectSnapshots ??= new Repository<ProjectSnapshot>(_context);

        /// <summary>
        /// GitHub Tokens repository - lazy initialized (GitHub Integration)
        /// </summary>
        public IGitHubTokenRepository GitHubTokens => _gitHubTokens ??= new GitHubTokenRepository(_context);

        /// <summary>
        /// Git Repositories repository - lazy initialized (GitHub Integration)
        /// </summary>
        public IGitRepositoryRepository GitRepositories => _gitRepositories ??= new GitRepositoryRepository(_context);

        /// <summary>
        /// Git Commits repository - lazy initialized (GitHub Integration)
        /// </summary>
        public IGitCommitRepository GitCommits => _gitCommits ??= new GitCommitRepository(_context);

        /// <summary>
        /// Git File Changes repository - lazy initialized (GitHub Integration)
        /// </summary>
        public IGitFileChangeRepository GitFileChanges => _gitFileChanges ??= new GitFileChangeRepository(_context);

        // ============================================
        // TRANSACTION OPERATIONS
        // ============================================

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async System.Threading.Tasks.Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async System.Threading.Tasks.Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        // ============================================
        // DISPOSE
        // ============================================

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}