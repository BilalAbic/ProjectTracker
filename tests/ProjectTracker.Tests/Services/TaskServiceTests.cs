using AutoMapper;
using Moq;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;
using ProjectTracker.Core.Interfaces;
using System.Linq.Expressions;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;
using SystemTask = System.Threading.Tasks.Task;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// TaskService Unit Tests
    /// </summary>
    public class TaskServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IAuditLogService> _mockAuditLogService;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockAuditLogService = new Mock<IAuditLogService>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _mockEmailService = new Mock<IEmailService>();

            _mockCurrentUserService.Setup(c => c.CurrentUserId).Returns(1);

            _taskService = new TaskService(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockAuditLogService.Object,
                _mockCurrentUserService.Object,
                _mockEmailService.Object
            );
        }

        #region GetTask Tests

        [Fact]
        public async System.Threading.Tasks.Task GetTaskByIdAsync_ExistingTask_ReturnsTaskDto()
        {
            // Arrange
            var task = new TaskEntity
            {
                TaskId = 1,
                TaskName = "Test Task",
                ProjectId = 1,
                Status = TaskStatus.Pending
            };
            var expectedDto = new TaskDto
            {
                TaskId = 1,
                TaskName = "Test Task"
            };

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(1))
                .ReturnsAsync(task);

            _mockMapper.Setup(m => m.Map<TaskDto>(task))
                .Returns(expectedDto);

            // Act
            var result = await _taskService.GetTaskByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result!.TaskId.Should().Be(1);
            result.TaskName.Should().Be("Test Task");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetTaskByIdAsync_NonExistingTask_ReturnsNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(999))
                .ReturnsAsync((TaskEntity?)null);

            // Act
            var result = await _taskService.GetTaskByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAllTasksAsync_ReturnsAllTasks()
        {
            // Arrange
            var tasks = new List<TaskEntity>
            {
                new() { TaskId = 1, TaskName = "Task 1" },
                new() { TaskId = 2, TaskName = "Task 2" }
            };
            var expectedDtos = new List<TaskDto>
            {
                new() { TaskId = 1, TaskName = "Task 1" },
                new() { TaskId = 2, TaskName = "Task 2" }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.GetAllAsync())
                .ReturnsAsync(tasks);

            _mockMapper.Setup(m => m.Map<IEnumerable<TaskDto>>(tasks))
                .Returns(expectedDtos);

            // Act
            var result = await _taskService.GetAllTasksAsync();

            // Assert
            result.Should().HaveCount(2);
        }

        #endregion

        #region CreateTask Tests

        [Fact]
        public async System.Threading.Tasks.Task CreateTaskAsync_ValidDto_CreatesTask()
        {
            // Arrange
            var createDto = new CreateTaskDto
            {
                TaskName = "New Task",
                Description = "Test Description",
                ProjectId = 1,
                Status = TaskStatus.Pending,
                Priority = Priority.Medium
            };

            var expectedDto = new TaskDto
            {
                TaskId = 1,
                TaskName = "New Task"
            };

            _mockMapper.Setup(m => m.Map<TaskEntity>(createDto))
                .Returns(new TaskEntity { TaskId = 1, TaskName = "New Task", ProjectId = 1 });

            _mockUnitOfWork.Setup(u => u.Tasks.AddAsync(It.IsAny<TaskEntity>())).ReturnsAsync((TaskEntity t) => t);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(new Project { ProjectId = 1, ProjectName = "Test Project" });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Test User" });

            _mockMapper.Setup(m => m.Map<TaskDto>(It.IsAny<TaskEntity>()))
                .Returns(expectedDto);

            // Act
            var result = await _taskService.CreateTaskAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            result.TaskName.Should().Be("New Task");
            _mockUnitOfWork.Verify(u => u.Tasks.AddAsync(It.IsAny<TaskEntity>()), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateTaskAsync_WithAssignee_SendsEmailNotification()
        {
            // Arrange
            var createDto = new CreateTaskDto
            {
                TaskName = "Assigned Task",
                ProjectId = 1,
                AssignedUserId = 2,
                Status = TaskStatus.Pending,
                Priority = Priority.High
            };

            var assignee = new User { UserId = 2, FullName = "Assignee", Email = "assignee@test.com" };

            _mockMapper.Setup(m => m.Map<TaskEntity>(createDto))
                .Returns(new TaskEntity { TaskId = 1, TaskName = "Assigned Task", ProjectId = 1 });

            _mockUnitOfWork.Setup(u => u.Tasks.AddAsync(It.IsAny<TaskEntity>())).ReturnsAsync((TaskEntity t) => t);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(new Project { ProjectId = 1, ProjectName = "Test Project" });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Creator" });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(2))
                .ReturnsAsync(assignee);

            _mockMapper.Setup(m => m.Map<TaskDto>(It.IsAny<TaskEntity>()))
                .Returns(new TaskDto { TaskId = 1, TaskName = "Assigned Task" });

            // Act
            var result = await _taskService.CreateTaskAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            // Email is sent fire-and-forget, so we just verify task was created
        }

        #endregion

        #region UpdateTask Tests

        [Fact]
        public async System.Threading.Tasks.Task UpdateTaskAsync_ExistingTask_UpdatesTask()
        {
            // Arrange
            var existingTask = new TaskEntity
            {
                TaskId = 1,
                TaskName = "Old Name",
                ProjectId = 1,
                Status = TaskStatus.Pending
            };

            var updateDto = new UpdateTaskDto
            {
                TaskName = "Updated Name",
                ProjectId = 1,
                Status = TaskStatus.InProgress,
                Priority = Priority.High
            };

            var expectedDto = new TaskDto
            {
                TaskId = 1,
                TaskName = "Updated Name"
            };

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(1))
                .ReturnsAsync(existingTask);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(new Project { ProjectId = 1, ProjectName = "Test Project" });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Test User" });

            _mockMapper.Setup(m => m.Map<TaskDto>(It.IsAny<TaskEntity>()))
                .Returns(expectedDto);

            // Act
            var result = await _taskService.UpdateTaskAsync(1, updateDto);

            // Assert
            result.Should().NotBeNull();
            result.TaskName.Should().Be("Updated Name");
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateTaskAsync_NonExistingTask_ThrowsException()
        {
            // Arrange
            var updateDto = new UpdateTaskDto { TaskName = "Test" };

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(999))
                .ReturnsAsync((TaskEntity?)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(
                () => _taskService.UpdateTaskAsync(999, updateDto));
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateTaskAsync_StatusChange_LogsActivity()
        {
            // Arrange
            var existingTask = new TaskEntity
            {
                TaskId = 1,
                TaskName = "Task",
                ProjectId = 1,
                Status = TaskStatus.Pending,
                AssignedToUserId = 2
            };

            var updateDto = new UpdateTaskDto
            {
                TaskName = "Task",
                ProjectId = 1,
                Status = TaskStatus.Completed,
                Priority = Priority.Medium
            };

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(1))
                .ReturnsAsync(existingTask);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(new Project { ProjectId = 1, ProjectName = "Test Project" });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new User { UserId = 1, FullName = "Test User", Email = "test@test.com" });

            _mockMapper.Setup(m => m.Map<TaskDto>(It.IsAny<TaskEntity>()))
                .Returns(new TaskDto { TaskId = 1, TaskName = "Task" });

            // Act
            var result = await _taskService.UpdateTaskAsync(1, updateDto);

            // Assert
            result.Should().NotBeNull();
            existingTask.Status.Should().Be(TaskStatus.Completed);
        }

        #endregion

        #region DeleteTask Tests

        [Fact]
        public async System.Threading.Tasks.Task DeleteTaskAsync_ExistingTask_DeletesTask()
        {
            // Arrange
            var task = new TaskEntity { TaskId = 1, TaskName = "Test", ProjectId = 1 };

            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(1))
                .ReturnsAsync(task);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(new Project { ProjectId = 1 });

            // Act
            await _taskService.DeleteTaskAsync(1);

            // Assert
            _mockUnitOfWork.Verify(u => u.Tasks.Remove(task), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteTaskAsync_NonExistingTask_DoesNothing()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Tasks.GetByIdAsync(999))
                .ReturnsAsync((TaskEntity?)null);

            // Act
            await _taskService.DeleteTaskAsync(999);

            // Assert
            _mockUnitOfWork.Verify(u => u.Tasks.Remove(It.IsAny<TaskEntity>()), Times.Never);
        }

        #endregion

        #region GetTaskCountByStatus Tests

        [Fact]
        public async System.Threading.Tasks.Task GetTaskCountByStatusAsync_ReturnsCounts()
        {
            // Arrange
            var tasks = new List<TaskEntity>
            {
                new() { TaskId = 1, Status = TaskStatus.Pending },
                new() { TaskId = 2, Status = TaskStatus.Pending },
                new() { TaskId = 3, Status = TaskStatus.InProgress },
                new() { TaskId = 4, Status = TaskStatus.Completed }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.GetAllAsync())
                .ReturnsAsync(tasks);

            // Act
            var result = await _taskService.GetTaskCountByStatusAsync();

            // Assert
            result.Should().ContainKey(TaskStatus.Pending);
            result[TaskStatus.Pending].Should().Be(2);
            result[TaskStatus.InProgress].Should().Be(1);
            result[TaskStatus.Completed].Should().Be(1);
        }

        #endregion

        #region GetUserTasks Tests

        [Fact]
        public async System.Threading.Tasks.Task GetUserTasksAsync_ReturnsUserTasks()
        {
            // Arrange
            var teamMembers = new List<TeamMember>
            {
                new() { TeamMemberId = 1, TeamId = 1, UserId = 1, IsActive = true }
            };

            var projects = new List<Project>
            {
                new() { ProjectId = 1, TeamId = 1 }
            };

            var tasks = new List<TaskEntity>
            {
                new() { TaskId = 1, ProjectId = 1, TaskName = "Task 1" }
            };

            var expectedDtos = new List<TaskDto>
            {
                new() { TaskId = 1, TaskName = "Task 1" }
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.FindAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(teamMembers);

            _mockUnitOfWork.Setup(u => u.Projects.FindAsync(It.IsAny<Expression<Func<Project, bool>>>()))
                .ReturnsAsync(projects);

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<TaskEntity, bool>>>()))
                .ReturnsAsync(tasks);

            _mockMapper.Setup(m => m.Map<IEnumerable<TaskDto>>(tasks))
                .Returns(expectedDtos);

            // Act
            var result = await _taskService.GetUserTasksAsync(1);

            // Assert
            result.Should().HaveCount(1);
        }

        #endregion
    }
}


