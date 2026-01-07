using FluentAssertions;
using Moq;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using ProjectTracker.Core.Interfaces.Repositories;
using System.Linq.Expressions;
using Xunit;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.Tests.Services
{
    using TaskEntity = ProjectTracker.Core.Entities.Task;
    
    /// <summary>
    /// AdvancedReportService için birim testleri
    /// Burndown, EVM, Velocity ve Finansal raporlama testleri
    /// </summary>
    public class AdvancedReportServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IRepository<Project>> _mockProjectRepository;
        private readonly Mock<IRepository<TaskEntity>> _mockTaskRepository;
        private readonly Mock<IRepository<Team>> _mockTeamRepository;
        private readonly Mock<IRepository<TimeEntry>> _mockTimeEntryRepository;
        private readonly Mock<IRepository<User>> _mockUserRepository;
        private readonly Mock<IRepository<ProjectSnapshot>> _mockSnapshotRepository;
        private readonly AdvancedReportService _advancedReportService;

        public AdvancedReportServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockProjectRepository = new Mock<IRepository<Project>>();
            _mockTaskRepository = new Mock<IRepository<TaskEntity>>();
            _mockTeamRepository = new Mock<IRepository<Team>>();
            _mockTimeEntryRepository = new Mock<IRepository<TimeEntry>>();
            _mockUserRepository = new Mock<IRepository<User>>();
            _mockSnapshotRepository = new Mock<IRepository<ProjectSnapshot>>();

            _mockUnitOfWork.Setup(u => u.Projects).Returns(_mockProjectRepository.Object);
            _mockUnitOfWork.Setup(u => u.Tasks).Returns(_mockTaskRepository.Object);
            _mockUnitOfWork.Setup(u => u.Teams).Returns(_mockTeamRepository.Object);
            _mockUnitOfWork.Setup(u => u.TimeEntries).Returns(_mockTimeEntryRepository.Object);
            _mockUnitOfWork.Setup(u => u.Users).Returns(_mockUserRepository.Object);
            _mockUnitOfWork.Setup(u => u.ProjectSnapshots).Returns(_mockSnapshotRepository.Object);

            _advancedReportService = new AdvancedReportService(_mockUnitOfWork.Object);
        }

        #region GetProjectBurndownAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task GetProjectBurndownAsync_WhenProjectNotFound_ShouldThrowException()
        {
            // Arrange
            var projectId = 999;
            _mockProjectRepository.Setup(r => r.GetByIdAsync(projectId))
                .ReturnsAsync((Project?)null);

            // Act
            var act = async () => await _advancedReportService.GetProjectBurndownAsync(projectId);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"*Project {projectId} not found*");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetProjectBurndownAsync_WithValidProject_ShouldReturnBurndownData()
        {
            // Arrange
            var projectId = 1;
            var project = new Project
            {
                ProjectId = projectId,
                ProjectName = "Test Project",
                StartDate = DateTime.Today.AddDays(-30),
                EndDate = DateTime.Today.AddDays(30),
                TotalPlannedHours = 100
            };

            var tasks = new List<TaskEntity>
            {
                new TaskEntity { TaskId = 1, ProjectId = projectId, Status = TaskStatus.Completed, EstimatedHours = 20 },
                new TaskEntity { TaskId = 2, ProjectId = projectId, Status = TaskStatus.InProgress, EstimatedHours = 30 },
                new TaskEntity { TaskId = 3, ProjectId = projectId, Status = TaskStatus.Pending, EstimatedHours = 50 }
            };

            _mockProjectRepository.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);
            _mockTaskRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TaskEntity, bool>>>()))
                .ReturnsAsync(tasks);
            _mockSnapshotRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<ProjectSnapshot, bool>>>()))
                .ReturnsAsync(new List<ProjectSnapshot>());

            // Act
            var result = await _advancedReportService.GetProjectBurndownAsync(projectId);

            // Assert
            result.Should().NotBeNull();
            result.ProjectId.Should().Be(projectId);
            result.ProjectName.Should().Be("Test Project");
            result.InitialPlannedHours.Should().Be(100);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetProjectBurndownAsync_WithSnapshots_ShouldUseSnapshotData()
        {
            // Arrange
            var projectId = 1;
            var project = new Project
            {
                ProjectId = projectId,
                ProjectName = "Test Project",
                StartDate = DateTime.Today.AddDays(-30),
                EndDate = DateTime.Today.AddDays(30),
                TotalPlannedHours = 100
            };

            var snapshots = new List<ProjectSnapshot>
            {
                new ProjectSnapshot { SnapshotDate = DateTime.Today.AddDays(-7), RemainingHours = 80, IdealRemainingHours = 75, CompletedTasksCount = 2 },
                new ProjectSnapshot { SnapshotDate = DateTime.Today, RemainingHours = 60, IdealRemainingHours = 50, CompletedTasksCount = 4 }
            };

            _mockProjectRepository.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);
            _mockTaskRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TaskEntity, bool>>>()))
                .ReturnsAsync(new List<TaskEntity>());
            _mockSnapshotRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<ProjectSnapshot, bool>>>()))
                .ReturnsAsync(snapshots);

            // Act
            var result = await _advancedReportService.GetProjectBurndownAsync(projectId);

            // Assert
            result.DataPoints.Should().HaveCount(2);
            result.CurrentRemainingHours.Should().Be(60);
        }

        #endregion

        #region GetEarnedValueAnalysisAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task GetEarnedValueAnalysisAsync_WhenProjectNotFound_ShouldThrowException()
        {
            // Arrange
            var projectId = 999;
            _mockProjectRepository.Setup(r => r.GetByIdAsync(projectId))
                .ReturnsAsync((Project?)null);

            // Act
            var act = async () => await _advancedReportService.GetEarnedValueAnalysisAsync(projectId);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"*Project {projectId} not found*");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetEarnedValueAnalysisAsync_WhenNoBudget_ShouldThrowException()
        {
            // Arrange
            var projectId = 1;
            var project = new Project
            {
                ProjectId = projectId,
                ProjectName = "Test Project",
                Budget = null
            };

            _mockProjectRepository.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);

            // Act
            var act = async () => await _advancedReportService.GetEarnedValueAnalysisAsync(projectId);

            // Assert
            await act.Should().ThrowAsync<InvalidOperationException>()
                .WithMessage($"*Project {projectId} has no budget defined*");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetEarnedValueAnalysisAsync_WithValidProject_ShouldCalculateEVM()
        {
            // Arrange
            var projectId = 1;
            var project = new Project
            {
                ProjectId = projectId,
                ProjectName = "Test Project",
                StartDate = DateTime.Today.AddDays(-50),
                EndDate = DateTime.Today.AddDays(50),
                Budget = 100000,
                CompletionPercentage = 50
            };

            _mockProjectRepository.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);
            _mockTimeEntryRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TimeEntry, bool>>>()))
                .ReturnsAsync(new List<TimeEntry>());

            // Act
            var result = await _advancedReportService.GetEarnedValueAnalysisAsync(projectId);

            // Assert
            result.Should().NotBeNull();
            result.ProjectId.Should().Be(projectId);
            result.EarnedValue.Should().Be(50000); // 50% of 100000
        }

        #endregion

        #region GetTeamVelocityAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task GetTeamVelocityAsync_WhenTeamNotFound_ShouldThrowException()
        {
            // Arrange
            var teamId = 999;
            _mockTeamRepository.Setup(r => r.GetByIdAsync(teamId))
                .ReturnsAsync((Team?)null);

            // Act
            var act = async () => await _advancedReportService.GetTeamVelocityAsync(teamId);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"*Team {teamId} not found*");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetTeamVelocityAsync_WithValidTeam_ShouldReturnVelocityData()
        {
            // Arrange
            var teamId = 1;
            var team = new Team { TeamId = teamId, TeamName = "Dev Team" };

            _mockTeamRepository.Setup(r => r.GetByIdAsync(teamId)).ReturnsAsync(team);
            _mockTaskRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TaskEntity, bool>>>()))
                .ReturnsAsync(new List<TaskEntity>());

            // Act
            var result = await _advancedReportService.GetTeamVelocityAsync(teamId);

            // Assert
            result.Should().NotBeNull();
            result.TeamId.Should().Be(teamId);
            result.TeamName.Should().Be("Dev Team");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetTeamVelocityAsync_WithCompletedTasks_ShouldCalculateVelocity()
        {
            // Arrange
            var teamId = 1;
            var team = new Team { TeamId = teamId, TeamName = "Dev Team" };
            var completedTasks = new List<TaskEntity>
            {
                new TaskEntity 
                { 
                    TaskId = 1, 
                    Status = TaskStatus.Completed, 
                    CompletedDate = DateTime.Today.AddDays(-3),
                    EstimatedHours = 8,
                    Project = new Project { TeamId = teamId }
                },
                new TaskEntity 
                { 
                    TaskId = 2, 
                    Status = TaskStatus.Completed, 
                    CompletedDate = DateTime.Today.AddDays(-5),
                    EstimatedHours = 16,
                    Project = new Project { TeamId = teamId }
                }
            };

            _mockTeamRepository.Setup(r => r.GetByIdAsync(teamId)).ReturnsAsync(team);
            _mockTaskRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TaskEntity, bool>>>()))
                .ReturnsAsync(completedTasks);

            // Act
            var result = await _advancedReportService.GetTeamVelocityAsync(teamId, 4);

            // Assert
            result.Should().NotBeNull();
            result.AverageVelocity.Should().BeGreaterThanOrEqualTo(0);
        }

        #endregion

        #region GetFinancialOverviewAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task GetFinancialOverviewAsync_WithNoFilters_ShouldReturnAllProjects()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project { ProjectId = 1, Budget = 50000 },
                new Project { ProjectId = 2, Budget = 75000 }
            };

            _mockProjectRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(projects);
            _mockTimeEntryRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<TimeEntry>());

            // Act
            var result = await _advancedReportService.GetFinancialOverviewAsync();

            // Assert
            result.Should().NotBeNull();
            result.TotalPlannedBudget.Should().Be(125000);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetFinancialOverviewAsync_WithProjectFilter_ShouldFilterProjects()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project { ProjectId = 1, Budget = 50000 },
                new Project { ProjectId = 2, Budget = 75000 },
                new Project { ProjectId = 3, Budget = 100000 }
            };
            var projectIds = new List<int> { 1, 2 };

            _mockProjectRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(projects);
            _mockTimeEntryRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<TimeEntry>());

            // Act
            var result = await _advancedReportService.GetFinancialOverviewAsync(projectIds: projectIds);

            // Assert
            result.TotalPlannedBudget.Should().Be(125000); // Only projects 1 and 2
        }

        [Fact]
        public async System.Threading.Tasks.Task GetFinancialOverviewAsync_WithTimeEntries_ShouldCalculateCosts()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project { ProjectId = 1, Budget = 100000 }
            };

            var timeEntries = new List<TimeEntry>
            {
                new TimeEntry { TimeEntryId = 1, UserId = 1, HoursSpent = 10, IsBillable = true, WorkDate = DateTime.Today, Task = new TaskEntity { ProjectId = 1 } },
                new TimeEntry { TimeEntryId = 2, UserId = 1, HoursSpent = 5, IsBillable = false, WorkDate = DateTime.Today, Task = new TaskEntity { ProjectId = 1 } }
            };

            var user = new User { UserId = 1, HourlyCost = 100 };

            _mockProjectRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(projects);
            _mockTimeEntryRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(timeEntries);
            _mockUserRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _advancedReportService.GetFinancialOverviewAsync();

            // Assert
            result.TotalBillableHours.Should().Be(10);
            result.TotalNonBillableHours.Should().Be(5);
        }

        #endregion

        #region GetCostBreakdownByProjectAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task GetCostBreakdownByProjectAsync_WhenProjectNotFound_ShouldThrowException()
        {
            // Arrange
            var projectId = 999;
            _mockProjectRepository.Setup(r => r.GetByIdAsync(projectId))
                .ReturnsAsync((Project?)null);

            // Act
            var act = async () => await _advancedReportService.GetCostBreakdownByProjectAsync(projectId);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"*Project {projectId} not found*");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetCostBreakdownByProjectAsync_WithValidProject_ShouldReturnBreakdown()
        {
            // Arrange
            var projectId = 1;
            var project = new Project { ProjectId = projectId, ProjectName = "Test Project" };

            _mockProjectRepository.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);
            _mockTimeEntryRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TimeEntry, bool>>>()))
                .ReturnsAsync(new List<TimeEntry>());

            // Act
            var result = await _advancedReportService.GetCostBreakdownByProjectAsync(projectId);

            // Assert
            result.Should().NotBeNull();
            result.EntityId.Should().Be(projectId);
            result.EntityName.Should().Be("Test Project");
            result.BreakdownType.Should().Be("Project");
        }

        #endregion

        #region GetCostBreakdownByTeamAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task GetCostBreakdownByTeamAsync_WhenTeamNotFound_ShouldThrowException()
        {
            // Arrange
            var teamId = 999;
            _mockTeamRepository.Setup(r => r.GetByIdAsync(teamId))
                .ReturnsAsync((Team?)null);

            // Act
            var act = async () => await _advancedReportService.GetCostBreakdownByTeamAsync(teamId);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"*Team {teamId} not found*");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetCostBreakdownByTeamAsync_WithValidTeam_ShouldReturnBreakdown()
        {
            // Arrange
            var teamId = 1;
            var team = new Team { TeamId = teamId, TeamName = "Dev Team" };

            _mockTeamRepository.Setup(r => r.GetByIdAsync(teamId)).ReturnsAsync(team);
            _mockProjectRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<Project, bool>>>()))
                .ReturnsAsync(new List<Project>());
            _mockTimeEntryRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<TimeEntry>());

            // Act
            var result = await _advancedReportService.GetCostBreakdownByTeamAsync(teamId);

            // Assert
            result.Should().NotBeNull();
            result.EntityId.Should().Be(teamId);
            result.EntityName.Should().Be("Dev Team");
            result.BreakdownType.Should().Be("Team");
        }

        #endregion

        #region CreateDailySnapshotsAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task CreateDailySnapshotsAsync_WithActiveProjects_ShouldCreateSnapshots()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project 
                { 
                    ProjectId = 1, 
                    Status = "Active",
                    StartDate = DateTime.Today.AddDays(-30),
                    EndDate = DateTime.Today.AddDays(30)
                }
            };

            _mockProjectRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(projects);
            _mockSnapshotRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<ProjectSnapshot, bool>>>()))
                .ReturnsAsync(new List<ProjectSnapshot>());
            _mockTaskRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TaskEntity, bool>>>()))
                .ReturnsAsync(new List<TaskEntity>());
            _mockTimeEntryRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<TimeEntry, bool>>>()))
                .ReturnsAsync(new List<TimeEntry>());
            _mockSnapshotRepository.Setup(r => r.AddAsync(It.IsAny<ProjectSnapshot>()))
                .ReturnsAsync((ProjectSnapshot s) => s);

            // Act
            var result = await _advancedReportService.CreateDailySnapshotsAsync();

            // Assert
            result.Should().Be(1);
            _mockSnapshotRepository.Verify(r => r.AddAsync(It.IsAny<ProjectSnapshot>()), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateDailySnapshotsAsync_WhenSnapshotExists_ShouldSkip()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project { ProjectId = 1, Status = "Active" }
            };

            var existingSnapshot = new ProjectSnapshot
            {
                ProjectId = 1,
                SnapshotDate = DateTime.Today
            };

            _mockProjectRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(projects);
            _mockSnapshotRepository.Setup(r => r.FindAsync(It.IsAny<Expression<Func<ProjectSnapshot, bool>>>()))
                .ReturnsAsync(new List<ProjectSnapshot> { existingSnapshot });

            // Act
            var result = await _advancedReportService.CreateDailySnapshotsAsync();

            // Assert
            result.Should().Be(0);
            _mockSnapshotRepository.Verify(r => r.AddAsync(It.IsAny<ProjectSnapshot>()), Times.Never);
        }

        #endregion
    }
}
