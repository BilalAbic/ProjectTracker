using Moq;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;
using ProjectTracker.Core.Interfaces;
using System.Linq.Expressions;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// AuditLogService Unit Tests
    /// </summary>
    public class AuditLogServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly AuditLogService _auditLogService;

        public AuditLogServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _auditLogService = new AuditLogService(_mockUnitOfWork.Object);
        }

        #region LogActivity Tests

        [Fact]
        public async System.Threading.Tasks.Task LogActivityAsync_ValidData_CreatesLog()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.AuditLogs.AddAsync(It.IsAny<AuditLog>()))
                .ReturnsAsync((AuditLog log) => log);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            await _auditLogService.LogActivityAsync(
                ActivityType.TaskCreated,
                "Tasks",
                1,
                1,
                teamId: 1);

            // Assert
            _mockUnitOfWork.Verify(u => u.AuditLogs.AddAsync(It.IsAny<AuditLog>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task LogActivityAsync_WithOldAndNewValues_CreatesLog()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.AuditLogs.AddAsync(It.IsAny<AuditLog>()))
                .ReturnsAsync((AuditLog log) => log);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            await _auditLogService.LogActivityAsync(
                ActivityType.TaskStatusChanged,
                "Tasks",
                1,
                1,
                oldValues: "Pending",
                newValues: "Completed");

            // Assert
            _mockUnitOfWork.Verify(u => u.AuditLogs.AddAsync(
                It.Is<AuditLog>(l => l.OldValues == "Pending")), Times.Once);
        }

        #endregion

        #region GetAllRecentActivities Tests

        [Fact]
        public async System.Threading.Tasks.Task GetAllRecentActivitiesAsync_ReturnsActivities()
        {
            // Arrange
            var logs = new List<AuditLog>
            {
                new() { LogId = 1, TableName = "Tasks", RecordId = 1, Action = "TaskCreated", PerformedAt = DateTime.Now, PerformedByUserId = 1 },
                new() { LogId = 2, TableName = "Projects", RecordId = 1, Action = "ProjectCreated", PerformedAt = DateTime.Now.AddMinutes(-5), PerformedByUserId = 1 }
            };

            _mockUnitOfWork.Setup(u => u.AuditLogs.GetAllAsync())
                .ReturnsAsync(logs);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Test User" });

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(1))
                .ReturnsAsync(new ProjectTracker.Core.Entities.Task { TaskId = 1, TaskName = "Test Task", ProjectId = 1 });

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(new Project { ProjectId = 1, ProjectName = "Test Project", TeamId = 1 });

            // Act
            var result = await _auditLogService.GetAllRecentActivitiesAsync(10);

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAllRecentActivitiesAsync_LimitsCount()
        {
            // Arrange
            var logs = Enumerable.Range(1, 50).Select(i => new AuditLog
            {
                LogId = i,
                TableName = "Tasks",
                RecordId = i,
                Action = "TaskCreated",
                PerformedAt = DateTime.Now.AddMinutes(-i),
                PerformedByUserId = 1
            }).ToList();

            _mockUnitOfWork.Setup(u => u.AuditLogs.GetAllAsync())
                .ReturnsAsync(logs);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new User { UserId = 1, FullName = "Test User" });

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new ProjectTracker.Core.Entities.Task { TaskId = 1, TaskName = "Test Task", ProjectId = 1 });

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Project { ProjectId = 1, ProjectName = "Test Project" });

            // Act
            var result = await _auditLogService.GetAllRecentActivitiesAsync(20);

            // Assert
            result.Should().HaveCount(20);
        }

        #endregion

        #region GetUserRecentActivities Tests

        [Fact]
        public async System.Threading.Tasks.Task GetUserRecentActivitiesAsync_AdminUser_ReturnsAllActivities()
        {
            // Arrange
            var logs = new List<AuditLog>
            {
                new() { LogId = 1, TableName = "Tasks", RecordId = 1, Action = "TaskCreated", PerformedAt = DateTime.Now, PerformedByUserId = 1 }
            };

            _mockUnitOfWork.Setup(u => u.AuditLogs.GetAllAsync())
                .ReturnsAsync(logs);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Admin" });

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(1))
                .ReturnsAsync(new ProjectTracker.Core.Entities.Task { TaskId = 1, TaskName = "Test Task", ProjectId = 1 });

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(new Project { ProjectId = 1, ProjectName = "Test Project" });

            // Act
            var result = await _auditLogService.GetUserRecentActivitiesAsync(1, isAdmin: true, count: 10);

            // Assert
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetUserRecentActivitiesAsync_RegularUser_ReturnsTeamActivities()
        {
            // Arrange
            var teamMembers = new List<TeamMember>
            {
                new() { TeamMemberId = 1, TeamId = 1, UserId = 1, IsActive = true }
            };

            var projects = new List<Project>
            {
                new() { ProjectId = 1, TeamId = 1, ProjectName = "Team Project" }
            };

            var tasks = new List<ProjectTracker.Core.Entities.Task>
            {
                new() { TaskId = 1, ProjectId = 1, TaskName = "Team Task" }
            };

            var logs = new List<AuditLog>
            {
                new() { LogId = 1, TableName = "Tasks", RecordId = 1, Action = "TaskCreated", PerformedAt = DateTime.Now, PerformedByUserId = 1 }
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.FindAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(teamMembers);

            _mockUnitOfWork.Setup(u => u.Projects.FindAsync(It.IsAny<Expression<Func<Project, bool>>>()))
                .ReturnsAsync(projects);

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<ProjectTracker.Core.Entities.Task, bool>>>()))
                .ReturnsAsync(tasks);

            _mockUnitOfWork.Setup(u => u.AuditLogs.GetAllAsync())
                .ReturnsAsync(logs);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "User" });

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(1))
                .ReturnsAsync(tasks[0]);

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(projects[0]);

            // Act
            var result = await _auditLogService.GetUserRecentActivitiesAsync(1, isAdmin: false, count: 10);

            // Assert
            result.Should().NotBeEmpty();
        }

        #endregion

        #region GetProjectActivities Tests

        [Fact]
        public async System.Threading.Tasks.Task GetProjectActivitiesAsync_ReturnsProjectActivities()
        {
            // Arrange
            var tasks = new List<ProjectTracker.Core.Entities.Task>
            {
                new() { TaskId = 1, ProjectId = 1, TaskName = "Task 1" },
                new() { TaskId = 2, ProjectId = 1, TaskName = "Task 2" }
            };

            var logs = new List<AuditLog>
            {
                new() { LogId = 1, TableName = "Projects", RecordId = 1, Action = "ProjectCreated", PerformedAt = DateTime.Now, PerformedByUserId = 1 },
                new() { LogId = 2, TableName = "Tasks", RecordId = 1, Action = "TaskCreated", PerformedAt = DateTime.Now, PerformedByUserId = 1 }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<ProjectTracker.Core.Entities.Task, bool>>>()))
                .ReturnsAsync(tasks);

            _mockUnitOfWork.Setup(u => u.AuditLogs.GetAllAsync())
                .ReturnsAsync(logs);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "User" });

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(new Project { ProjectId = 1, ProjectName = "Test Project", TeamId = 1 });

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(1))
                .ReturnsAsync(tasks[0]);

            // Act
            var result = await _auditLogService.GetProjectActivitiesAsync(1, 50);

            // Assert
            result.Should().HaveCount(2);
        }

        #endregion

        #region GetTaskActivities Tests

        [Fact]
        public async System.Threading.Tasks.Task GetTaskActivitiesAsync_ReturnsTaskActivities()
        {
            // Arrange
            var logs = new List<AuditLog>
            {
                new() { LogId = 1, TableName = "Tasks", RecordId = 1, Action = "TaskCreated", PerformedAt = DateTime.Now, PerformedByUserId = 1 },
                new() { LogId = 2, TableName = "Tasks", RecordId = 1, Action = "TaskStatusChanged", PerformedAt = DateTime.Now.AddMinutes(-5), PerformedByUserId = 1 }
            };

            _mockUnitOfWork.Setup(u => u.AuditLogs.GetAllAsync())
                .ReturnsAsync(logs);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "User" });

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(1))
                .ReturnsAsync(new ProjectTracker.Core.Entities.Task { TaskId = 1, TaskName = "Test Task", ProjectId = 1 });

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(new Project { ProjectId = 1, ProjectName = "Test Project" });

            // Act
            var result = await _auditLogService.GetTaskActivitiesAsync(1, 20);

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetTaskActivitiesAsync_NoActivities_ReturnsEmpty()
        {
            // Arrange
            var logs = new List<AuditLog>
            {
                new() { LogId = 1, TableName = "Tasks", RecordId = 999, Action = "TaskCreated", PerformedAt = DateTime.Now, PerformedByUserId = 1 }
            };

            _mockUnitOfWork.Setup(u => u.AuditLogs.GetAllAsync())
                .ReturnsAsync(logs);

            // Act
            var result = await _auditLogService.GetTaskActivitiesAsync(1, 20);

            // Assert
            result.Should().BeEmpty();
        }

        #endregion
    }
}
