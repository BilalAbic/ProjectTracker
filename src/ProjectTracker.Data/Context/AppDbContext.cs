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

        /// <summary>
        /// Teams table - Multi-team workspace support
        /// </summary>
        public DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Team members table - User-Team relationship
        /// </summary>
        public DbSet<TeamMember> TeamMembers { get; set; }

        /// <summary>
        /// Team invitations table - Email-based team invitations
        /// </summary>
        public DbSet<TeamInvitation> TeamInvitations { get; set; }

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
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<TeamMember>().ToTable("TeamMembers");
            modelBuilder.Entity<TeamInvitation>().ToTable("TeamInvitations");

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
                entity.Property(e => e.Priority).IsRequired().HasConversion<string>().HasDefaultValue(Priority.Medium);
                entity.Property(e => e.Status).IsRequired().HasConversion<string>().HasDefaultValue(Core.Enums.TaskStatus.Pending);
                entity.Property(e => e.IsCriticalPath).IsRequired().HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
                
                // Map AssignedToUserId property to AssignedUserId column (migration renamed it)
                entity.Property(e => e.AssignedToUserId).HasColumnName("AssignedUserId");

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

            // ============================================
            // TEAM CONFIGURATION (Phase 5)
            // ============================================
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);
                entity.Property(e => e.TeamName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                // Relationship: Team -> User (Owner)
                entity.HasOne(t => t.Owner)
                    .WithMany(u => u.OwnedTeams)
                    .HasForeignKey(t => t.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relationship: Team -> TeamMember (Members)
                entity.HasMany(t => t.Members)
                    .WithOne(m => m.Team)
                    .HasForeignKey(m => m.TeamId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship: Team -> Project (Projects)
                entity.HasMany(t => t.Projects)
                    .WithOne(p => p.Team)
                    .HasForeignKey(p => p.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relationship: Team -> TeamInvitation (Invitations)
                entity.HasMany(t => t.Invitations)
                    .WithOne(i => i.Team)
                    .HasForeignKey(i => i.TeamId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ============================================
            // TEAM MEMBER CONFIGURATION (Phase 5)
            // ============================================
            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => e.TeamMemberId);
                entity.Property(e => e.Role).IsRequired().HasConversion<string>();
                entity.Property(e => e.IsActive).IsRequired().HasDefaultValue(true);
                entity.Property(e => e.JoinedAt).IsRequired().HasDefaultValueSql("GETDATE()");

                // Relationship: TeamMember -> Team
                entity.HasOne(tm => tm.Team)
                    .WithMany(t => t.Members)
                    .HasForeignKey(tm => tm.TeamId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship: TeamMember -> User
                entity.HasOne(tm => tm.User)
                    .WithMany(u => u.TeamMemberships_New)
                    .HasForeignKey(tm => tm.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Unique constraint: Same user can't be added to same team twice
                entity.HasIndex(e => new { e.TeamId, e.UserId }).IsUnique();
            });

            // ============================================
            // TEAM INVITATION CONFIGURATION (Phase 5)
            // ============================================
            modelBuilder.Entity<TeamInvitation>(entity =>
            {
                entity.HasKey(e => e.InvitationId);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ProposedRole).IsRequired().HasConversion<string>();
                entity.Property(e => e.Status).IsRequired().HasConversion<string>();
                entity.Property(e => e.Token).IsRequired().HasMaxLength(100);
                entity.Property(e => e.SentAt).IsRequired().HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.ExpiresAt).IsRequired();

                // Relationship: TeamInvitation -> Team
                entity.HasOne(ti => ti.Team)
                    .WithMany(t => t.Invitations)
                    .HasForeignKey(ti => ti.TeamId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship: TeamInvitation -> User (InvitedBy)
                entity.HasOne(ti => ti.InvitedBy)
                    .WithMany(u => u.SentInvitations)
                    .HasForeignKey(ti => ti.InvitedByUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Unique index on Token for security
                entity.HasIndex(e => e.Token).IsUnique();

                // Index on Email for faster lookups
                entity.HasIndex(e => e.Email);
            });

            // ============================================
            // SEED DATA
            // ============================================
            
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin", Description = "System Administrator" },
                new Role { RoleId = 2, RoleName = "ProjectManager", Description = "Project Manager" },
                new Role { RoleId = 3, RoleName = "Developer", Description = "Developer" }
            );

            // Seed Users (Password: admin123 hashed with BCrypt)
            // Valid BCrypt hash for "admin123" - DO NOT CHANGE
            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    UserId = 1, 
                    Username = "admin", 
                    PasswordHash = "$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC", // admin123
                    FullName = "Admin User", 
                    Email = "admin@projecttracker.com", 
                    RoleId = 1, 
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1)
                }
            );

            // Seed Teams (must come before Projects due to FK)
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    TeamName = "Default Team",
                    Description = "Auto-created default team for all projects",
                    OwnerId = 1,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1)
                }
            );

            // Seed Projects
            modelBuilder.Entity<Project>().HasData(
                new Project 
                { 
                    ProjectId = 1, 
                    TeamId = 1,
                    ProjectName = "E-Commerce Platform", 
                    Description = "Building a modern e-commerce platform with microservices architecture",
                    Status = "Active",
                    Priority = Priority.High,
                    StartDate = new DateTime(2025, 10, 29),
                    EndDate = new DateTime(2026, 4, 29),
                    Budget = 150000,
                    CompletionPercentage = 35,
                    CreatedByUserId = 1,
                    CreatedAt = new DateTime(2025, 10, 29)
                },
                new Project 
                { 
                    ProjectId = 2, 
                    TeamId = 1,
                    ProjectName = "Mobile Banking App", 
                    Description = "iOS and Android banking application with biometric authentication",
                    Status = "Active",
                    Priority = Priority.Critical,
                    StartDate = new DateTime(2025, 11 , 29),
                    EndDate = new DateTime(2026, 3, 29),
                    Budget = 200000,
                    CompletionPercentage = 20,
                    CreatedByUserId = 1,
                    CreatedAt = new DateTime(2025, 11, 29)
                },
                new Project 
                { 
                    ProjectId = 3, 
                    TeamId = 1,
                    ProjectName = "Internal CRM System", 
                    Description = "Customer relationship management system for internal use",
                    Status = "Planned",
                    Priority = Priority.Medium,
                    StartDate = new DateTime(2026, 1, 13),
                    EndDate = new DateTime(2026, 6, 29),
                    Budget = 80000,
                    CompletionPercentage = 0,
                    CreatedByUserId = 1,
                    CreatedAt = new DateTime(2025, 12, 29)
                }
            );

            // Seed Tasks
            modelBuilder.Entity<Core.Entities.Task>().HasData(
                // E-Commerce Platform Tasks
                new Core.Entities.Task 
                { 
                    TaskId = 1, 
                    ProjectId = 1,
                    AssignedToUserId = 1, // Assigned to admin
                    TaskName = "Design Product Catalog UI", 
                    Description = "Create wireframes and mockups for product listing pages",
                    Priority = Priority.High,
                    Status = Core.Enums.TaskStatus.Completed,
                    StartDate = new DateTime(2025, 10, 29),
                    DueDate = new DateTime(2025, 11, 29),
                    CompletedDate = new DateTime(2025, 12, 4),
                    IsCriticalPath = false,
                    CreatedAt = new DateTime(2025, 10, 29)
                },
                new Core.Entities.Task 
                { 
                    TaskId = 2, 
                    ProjectId = 1,
                    AssignedToUserId = 1, // Assigned to admin
                    TaskName = "Implement Shopping Cart", 
                    Description = "Build shopping cart functionality with session management",
                    Priority = Priority.Critical,
                    Status = Core.Enums.TaskStatus.InProgress,
                    StartDate = new DateTime(2025, 12, 19),
                    DueDate = new DateTime(2026, 1, 3),
                    IsCriticalPath = true,
                    CreatedAt = new DateTime(2025, 12, 19)
                },
                new Core.Entities.Task 
                { 
                    TaskId = 3, 
                    ProjectId = 1, 
                    TaskName = "Setup Payment Gateway", 
                    Description = "Integrate Stripe payment gateway for checkout",
                    Priority = Priority.High,
                    Status = Core.Enums.TaskStatus.Pending,
                    StartDate = new DateTime(2026, 1, 3),
                    DueDate = new DateTime(2026, 1, 13),
                    IsCriticalPath = false,
                    CreatedAt = new DateTime(2025, 12, 29)
                },
                new Core.Entities.Task 
                { 
                    TaskId = 4, 
                    ProjectId = 1, 
                    TaskName = "Performance Testing", 
                    Description = "Load testing for 10000 concurrent users",
                    Priority = Priority.Medium,
                    Status = Core.Enums.TaskStatus.Blocked,
                    StartDate = new DateTime(2025, 12, 29),
                    DueDate = new DateTime(2026, 1, 18),
                    IsCriticalPath = false,
                    CreatedAt = new DateTime(2025, 12, 29)
                },
                
                // Mobile Banking App Tasks
                new Core.Entities.Task 
                { 
                    TaskId = 5, 
                    ProjectId = 2, 
                    TaskName = "Biometric Authentication", 
                    Description = "Implement fingerprint and face recognition",
                    Priority = Priority.Critical,
                    Status = Core.Enums.TaskStatus.InProgress,
                    StartDate = new DateTime(2025, 12, 24),
                    DueDate = new DateTime(2026, 1, 8),
                    IsCriticalPath = true,
                    CreatedAt = new DateTime(2025, 12, 24)
                },
                new Core.Entities.Task 
                { 
                    TaskId = 6, 
                    ProjectId = 2, 
                    TaskName = "Transaction History UI", 
                    Description = "Design and implement transaction history screen",
                    Priority = Priority.High,
                    Status = Core.Enums.TaskStatus.Pending,
                    StartDate = new DateTime(2026, 1, 1),
                    DueDate = new DateTime(2026, 1, 10),
                    IsCriticalPath = false,
                    CreatedAt = new DateTime(2025, 12, 29)
                },
                
                // Internal CRM Tasks
                new Core.Entities.Task 
                { 
                    TaskId = 7, 
                    ProjectId = 3, 
                    TaskName = "Requirements Gathering", 
                    Description = "Meet with stakeholders to gather CRM requirements",
                    Priority = Priority.High,
                    Status = Core.Enums.TaskStatus.Pending,
                    StartDate = new DateTime(2026, 1, 13),
                    DueDate = new DateTime(2026, 1, 18),
                    IsCriticalPath = false,
                    CreatedAt = new DateTime(2025, 12, 29)
                }
            );
        }

        #endregion
    }
}