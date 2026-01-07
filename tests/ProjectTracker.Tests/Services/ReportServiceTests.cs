using Moq;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using System.Linq.Expressions;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;
using CoreTask = ProjectTracker.Core.Entities.Task;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// ReportService Unit Tests
    /// </summary>
    public class ReportServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IAdvancedReportService> _mockAdvancedReportService;
        private readonly ReportService _reportService;

        public ReportServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockAdvancedReportService = new Mock<IAdvancedReportService>();
            _reportService = new ReportService(_mockUnitOfWork.Object, _mockAdvancedReportService.Object);
        }

        #region GetProjectStatistics Tests

        [Fact]
        public async System.Threading.Tasks.Task GetProjectStatisticsAsync_ReturnsCorrectCounts()
        {
            // Arrange
            var projects = new List<Project>
            {
                new() { ProjectId = 1, ProjectName = "Active 1", Status = "Active", CompletionPercentage = 50 },
                new() { ProjectId = 2, ProjectName = "Active 2", Status = "Active", CompletionPercentage = 75 },
                new() { ProjectId = 3, ProjectName = "Completed", Status = "Completed", CompletionPercentage = 100 },
                new() { ProjectId = 4, ProjectName = "OnHold", Status = "OnHold", CompletionPercentage = 25 },
                new() { ProjectId = 5, ProjectName = "Cancelled", Status = "Cancelled", CompletionPercentage = 0 }
            };

            _mockUnitOfWork.Setup(u => u.Projects.GetAllAsync())
                .ReturnsAsync(projects);

            // Act
            var result = await _reportService.GetProjectStatisticsAsync();

            // Assert
            result.TotalProjects.Should().Be(5);
            result.ActiveProjects.Should().Be(2);
            result.CompletedProjects.Should().Be(1);
            result.OnHoldProjects.Should().Be(1);
            result.CancelledProjects.Should().Be(1);
            result.AverageCompletionRate.Should().Be(50); // (50+75+100+25+0)/5 = 50
        }

        [Fact]
        public async System.Threading.Tasks.Task GetProjectStatisticsAsync_WithProjectFilter_ReturnsFilteredStats()
        {
            // Arrange
            var projects = new List<Project>
            {
                new() { ProjectId = 1, ProjectName = "Project 1", Status = "Active", CompletionPercentage = 50 },
                new() { ProjectId = 2, ProjectName = "Project 2", Status = "Completed", CompletionPercentage = 100 },
                new() { ProjectId = 3, ProjectName = "Project 3", Status = "Active", CompletionPercentage = 75 }
            };

            _mockUnitOfWork.Setup(u => u.Projects.GetAllAsync())
                .ReturnsAsync(projects);

            // Act
            var result = await _reportService.GetProjectStatisticsAsync(projectIds: new[] { 1, 2 });

            // Assert
            result.TotalProjects.Should().Be(2);
            result.ActiveProjects.Should().Be(1);
            result.CompletedProjects.Should().Be(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetProjectStatisticsAsync_NoProjects_ReturnsZeros()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Projects.GetAllAsync())
                .ReturnsAsync(new List<Project>());

            // Act
            var result = await _reportService.GetProjectStatisticsAsync();

            // Assert
            result.TotalProjects.Should().Be(0);
            result.ActiveProjects.Should().Be(0);
            result.AverageCompletionRate.Should().Be(0);
        }

        #endregion

        #region GetTaskStatistics Tests

        [Fact]
        public async System.Threading.Tasks.Task GetTaskStatisticsAsync_ReturnsCorrectCounts()
        {
            // Arrange
            var tasks = new List<CoreTask>
            {
                new() { TaskId = 1, TaskName = "Pending 1", Status = TaskStatus.Pending, ProjectId = 1, CreatedAt = DateTime.Now },
                new() { TaskId = 2, TaskName = "Pending 2", Status = TaskStatus.Pending, ProjectId = 1, CreatedAt = DateTime.Now },
                new() { TaskId = 3, TaskName = "InProgress", Status = TaskStatus.InProgress, ProjectId = 1, CreatedAt = DateTime.Now },
                new() { TaskId = 4, TaskName = "Completed", Status = TaskStatus.Completed, ProjectId = 1, CreatedAt = DateTime.Now },
                new() { TaskId = 5, TaskName = "Overdue", Status = TaskStatus.Pending, ProjectId = 1, DueDate = DateTime.Now.AddDays(-5), CreatedAt = DateTime.Now }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.GetAllAsync())
                .ReturnsAsync(tasks);

            // Act
            var result = await _reportService.GetTaskStatisticsAsync();

            // Assert
            result.TotalTasks.Should().Be(5);
            result.TodoTasks.Should().Be(3); // Pending tasks
            result.InProgressTasks.Should().Be(1);
            result.CompletedTasks.Should().Be(1);
            result.OverdueTasks.Should().Be(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetTaskStatisticsAsync_WithProjectFilter_ReturnsFilteredStats()
        {
            // Arrange
            var tasks = new List<CoreTask>
            {
                new() { TaskId = 1, TaskName = "Task 1", Status = TaskStatus.Pending, ProjectId = 1, CreatedAt = DateTime.Now },
                new() { TaskId = 2, TaskName = "Task 2", Status = TaskStatus.Completed, ProjectId = 1, CreatedAt = DateTime.Now },
                new() { TaskId = 3, TaskName = "Task 3", Status = TaskStatus.Pending, ProjectId = 2, CreatedAt = DateTime.Now }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.GetAllAsync())
                .ReturnsAsync(tasks);

            // Act
            var result = await _reportService.GetTaskStatisticsAsync(projectIds: new[] { 1 });

            // Assert
            result.TotalTasks.Should().Be(2);
            result.TodoTasks.Should().Be(1);
            result.CompletedTasks.Should().Be(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetTaskStatisticsAsync_WithDateFilter_ReturnsFilteredStats()
        {
            // Arrange
            var now = DateTime.Now;
            var tasks = new List<CoreTask>
            {
                new() { TaskId = 1, TaskName = "Recent", Status = TaskStatus.Pending, ProjectId = 1, CreatedAt = now },
                new() { TaskId = 2, TaskName = "Old", Status = TaskStatus.Pending, ProjectId = 1, CreatedAt = now.AddDays(-30) },
                new() { TaskId = 3, TaskName = "Completed Recently", Status = TaskStatus.Completed, ProjectId = 1, CreatedAt = now.AddDays(-30), CompletedDate = now }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.GetAllAsync())
                .ReturnsAsync(tasks);

            // Act
            var result = await _reportService.GetTaskStatisticsAsync(
                startDate: now.AddDays(-7),
                endDate: now.AddDays(1));

            // Assert
            result.TotalTasks.Should().Be(2); // Recent + Completed Recently
        }

        [Fact]
        public async System.Threading.Tasks.Task GetTaskStatisticsAsync_NoTasks_ReturnsZeros()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Tasks.GetAllAsync())
                .ReturnsAsync(new List<CoreTask>());

            // Act
            var result = await _reportService.GetTaskStatisticsAsync();

            // Assert
            result.TotalTasks.Should().Be(0);
            result.CompletedTasks.Should().Be(0);
            result.OverdueTasks.Should().Be(0);
        }

        #endregion
    }
}
