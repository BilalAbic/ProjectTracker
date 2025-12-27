using Microsoft.EntityFrameworkCore;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;

namespace ProjectTracker.Data.Context
{
    /// <summary>
    /// Main database context for Project Tracker application
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor - accepts DbContextOptions for configuration
        /// </summary>
        /// <param name="options">Database connection options</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSets - Database Tables

        /// <summary>
        /// Roles table
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Users table
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Projects table
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Tasks table
        /// </summary>
        public DbSet<Core.Entities.Task> Tasks { get; set; }

        /// <summary>
        /// Task comments table
        /// </summary>
        public DbSet<TaskComment> TaskComments { get; set; }

        /// <summary>
        /// Notifications table
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }

        /// <summary>
        /// Project team members table (Many-to-Many)
        /// </summary>
        public DbSet<ProjectTeamMember> ProjectTeamMembers { get; set; }

        /// <summary>
        /// Project risks table
        /// </summary>
        public DbSet<ProjectRisk> ProjectRisks { get; set; }

        /// <summary>
        /// Audit logs table
        /// </summary>
        public DbSet<AuditLog> AuditLogs { get; set; }

        #endregion

        #region Model Configuration

        /// <summary>
        /// Configure entity relationships and constraints using Fluent API
        /// </summary>
        /// <param name="modelBuilder">Model builder instance</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table names to match SQL Server naming convention
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Core.Entities.Task>().ToTable("Tasks");
            modelBuilder.Entity<TaskComment>().ToTable("TaskComments");
            modelBuilder.Entity<Notification>().ToTable("Notifications");
            modelBuilder.Entity<ProjectTeamMember>().ToTable("ProjectTeamMembers");
            modelBuilder.Entity<ProjectRisk>().ToTable("ProjectRisks");
            modelBuilder.Entity<AuditLog>().ToTable("AuditLogs");

            // ============================================
            // ROLE CONFIGURATION
            // ============================================
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(e => e.RoleName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(200);
            });

            // ============================================
            // USER CONFIGURATION
            // ============================================
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                // Relationship: User -> Role (Many-to-One)
                entity.HasOne(u => u.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================================
            // PROJECT CONFIGURATION
            // ============================================
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId);
                entity.Property(e => e.ProjectName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50).HasConversion<string>().HasDefaultValue(ProjectStatus.Planned);
                entity.Property(e => e.CompletionPercentage).HasPrecision(5, 2).HasDefaultValue(0);
                entity.Property(e => e.RiskScore).HasPrecision(5, 2);
                entity.Property(e => e.Budget).HasPrecision(18, 2);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                // Relationship: Project -> User (Many-to-One)
                entity.HasOne(p => p.CreatedByUser)
                    .WithMany(u => u.CreatedProjects)
                    .HasForeignKey(p => p.CreatedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================================
            // TASK CONFIGURATION
            // ============================================
            modelBuilder.Entity<Core.Entities.Task>(entity =>
            {
                entity.HasKey(e => e.TaskId);
                entity.Property(e => e.TaskName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Priority).IsRequired().HasMaxLength(20).HasDefaultValue("Medium");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50).HasConversion<string>().HasDefaultValue(ProjectStatus.Planned);
                entity.Property(e => e.IsCriticalPath).IsRequired().HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                // Relationship: Task -> Project (Many-to-One)
                entity.HasOne(t => t.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(t => t.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Task -> User (Many-to-One, nullable)
                entity.HasOne(t => t.AssignedToUser)
                    .WithMany(u => u.AssignedTasks)
                    .HasForeignKey(t => t.AssignedToUserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ============================================
            // TASK COMMENT CONFIGURATION
            // ============================================
            modelBuilder.Entity<TaskComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);
                entity.Property(e => e.CommentText).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                // Relationship: TaskComment -> Task (Many-to-One)
                entity.HasOne(tc => tc.Task)
                    .WithMany(t => t.Comments)
                    .HasForeignKey(tc => tc.TaskId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship: TaskComment -> User (Many-to-One)
                entity.HasOne(tc => tc.User)
                    .WithMany(u => u.TaskComments)
                    .HasForeignKey(tc => tc.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // ============================================
            // NOTIFICATION CONFIGURATION
            // ============================================
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.NotificationId);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Message).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(20).HasDefaultValue("Info");
                entity.Property(e => e.IsRead).IsRequired().HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                // Relationship: Notification -> User (Many-to-One)
                entity.HasOne(n => n.User)
                    .WithMany(u => u.Notifications)
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ============================================
            // PROJECT TEAM MEMBER CONFIGURATION
            // ============================================
            modelBuilder.Entity<ProjectTeamMember>(entity =>
            {
                entity.HasKey(e => e.TeamMemberId);
                entity.Property(e => e.ProjectRole).HasMaxLength(100);
                entity.Property(e => e.JoinedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                // Relationship: ProjectTeamMember -> Project (Many-to-One)
                entity.HasOne(ptm => ptm.Project)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(ptm => ptm.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship: ProjectTeamMember -> User (Many-to-One)
                entity.HasOne(ptm => ptm.User)
                    .WithMany(u => u.TeamMemberships)
                    .HasForeignKey(ptm => ptm.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Unique constraint: Same user can't be added to same project twice
                entity.HasIndex(e => new { e.ProjectId, e.UserId }).IsUnique();
            });

            // ============================================
            // PROJECT RISK CONFIGURATION
            // ============================================
            modelBuilder.Entity<ProjectRisk>(entity =>
            {
                entity.HasKey(e => e.RiskId);
                entity.Property(e => e.RiskScore).IsRequired().HasPrecision(5, 2);
                entity.Property(e => e.RiskLevel).IsRequired().HasMaxLength(20).HasDefaultValue("Medium");
                entity.Property(e => e.RiskFactors).HasMaxLength(1000);
                entity.Property(e => e.Recommendations).HasMaxLength(1000);
                entity.Property(e => e.AnalyzedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                // Relationship: ProjectRisk -> Project (Many-to-One)
                entity.HasOne(pr => pr.Project)
                    .WithMany(p => p.Risks)
                    .HasForeignKey(pr => pr.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ============================================
            // AUDIT LOG CONFIGURATION
            // ============================================
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.LogId);
                entity.Property(e => e.TableName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.RecordId).IsRequired();
                entity.Property(e => e.Action).IsRequired().HasMaxLength(20);
                entity.Property(e => e.PerformedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            });
        }

        #endregion
    }
}