using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;
using ProjectTracker.Core.Interfaces;
using System.Linq.Expressions;
using SystemTask = System.Threading.Tasks.Task;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// ProjectService Unit Tests
    /// </summary>
    public class ProjectServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IValidator<ProjectDto>> _mockValidator;
        private readonly Mock<IAuditLogService> _mockAuditLogService;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;
        private readonly ProjectService _projectService;

        public ProjectServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockValidator = new Mock<IValidator<ProjectDto>>();
            _mockAuditLogService = new Mock<IAuditLogService>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();

            _mockCurrentUserService.Setup(c => c.CurrentUserId).Returns(1);

            _projectService = new ProjectService(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockValidator.Object,
                _mockAuditLogService.Object,
                _mockCurrentUserService.Object
            );
        }

        #region GetProject Tests

        [Fact]
        public async System.Threading.Tasks.Task GetProjectByIdAsync_ExistingProject_ReturnsProjectDto()
        {
            // Arrange
            var project = new Project
            {
                ProjectId = 1,
                ProjectName = "Test Project",
                Status = "Active"
            };
            var expectedDto = new ProjectDto
            {
                ProjectId = 1,
                ProjectName = "Test Project"
            };

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(project);

            _mockMapper.Setup(m => m.Map<ProjectDto>(project))
                .Returns(expectedDto);

            // Act
            var result = await _projectService.GetProjectByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result!.ProjectId.Should().Be(1);
            result.ProjectName.Should().Be("Test Project");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetProjectByIdAsync_NonExistingProject_ReturnsNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(999))
                .ReturnsAsync((Project?)null);

            // Act
            var result = await _projectService.GetProjectByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAllAsync_ReturnsAllProjects()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project { ProjectId = 1, ProjectName = "Project 1" },
                new Project { ProjectId = 2, ProjectName = "Project 2" }
            };
            var expectedDtos = new List<ProjectDto>
            {
                new ProjectDto { ProjectId = 1, ProjectName = "Project 1" },
                new ProjectDto { ProjectId = 2, ProjectName = "Project 2" }
            };

            _mockUnitOfWork.Setup(u => u.Projects.GetAllAsync())
                .ReturnsAsync(projects);

            _mockMapper.Setup(m => m.Map<IEnumerable<ProjectDto>>(projects))
                .Returns(expectedDtos);

            // Act
            var result = await _projectService.GetAllAsync();

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetActiveProjectsAsync_ReturnsOnlyActiveProjects()
        {
            // Arrange
            var activeProjects = new List<Project>
            {
                new Project { ProjectId = 1, ProjectName = "Active Project", Status = "Active" }
            };
            var expectedDtos = new List<ProjectDto>
            {
                new ProjectDto { ProjectId = 1, ProjectName = "Active Project" }
            };

            _mockUnitOfWork.Setup(u => u.Projects.FindAsync(It.IsAny<Expression<Func<Project, bool>>>()))
                .ReturnsAsync(activeProjects);

            _mockMapper.Setup(m => m.Map<IEnumerable<ProjectDto>>(activeProjects))
                .Returns(expectedDtos);

            // Act
            var result = await _projectService.GetActiveProjectsAsync();

            // Assert
            result.Should().HaveCount(1);
        }

        #endregion

        #region CreateProject Tests

        [Fact]
        public async System.Threading.Tasks.Task CreateProjectAsync_ValidDto_CreatesProject()
        {
            // Arrange
            var createDto = new CreateProjectDto
            {
                ProjectName = "New Project",
                Description = "Test Description",
                StartDate = DateTime.Now,
                Status = ProjectStatus.Planned,
                Priority = Priority.Medium,
                CreatedByUserId = 1,
                TeamId = 1
            };

            var expectedDto = new ProjectDto
            {
                ProjectId = 1,
                ProjectName = "New Project"
            };

            _mockUnitOfWork.Setup(u => u.Projects.AddAsync(It.IsAny<Project>())).ReturnsAsync((Project p) => p);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockMapper.Setup(m => m.Map<ProjectDto>(It.IsAny<Project>()))
                .Returns(expectedDto);

            // Act
            var result = await _projectService.CreateProjectAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            result.ProjectName.Should().Be("New Project");
            _mockUnitOfWork.Verify(u => u.Projects.AddAsync(It.IsAny<Project>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        #endregion

        #region UpdateProject Tests

        [Fact]
        public async System.Threading.Tasks.Task UpdateProjectAsync_ExistingProject_UpdatesProject()
        {
            // Arrange
            var existingProject = new Project
            {
                ProjectId = 1,
                ProjectName = "Old Name",
                Status = "Planned"
            };

            var updateDto = new UpdateProjectDto
            {
                ProjectName = "Updated Name",
                Description = "Updated Description",
                StartDate = DateTime.Now,
                Status = ProjectStatus.Active,
                Priority = Priority.High,
                TeamId = 1
            };

            var expectedDto = new ProjectDto
            {
                ProjectId = 1,
                ProjectName = "Updated Name"
            };

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(existingProject);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockMapper.Setup(m => m.Map<ProjectDto>(It.IsAny<Project>()))
                .Returns(expectedDto);

            // Act
            var result = await _projectService.UpdateProjectAsync(1, updateDto);

            // Assert
            result.Should().NotBeNull();
            result.ProjectName.Should().Be("Updated Name");
            existingProject.ProjectName.Should().Be("Updated Name");
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateProjectAsync_NonExistingProject_ThrowsException()
        {
            // Arrange
            var updateDto = new UpdateProjectDto { ProjectName = "Test" };

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(999))
                .ReturnsAsync((Project?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _projectService.UpdateProjectAsync(999, updateDto));
        }

        #endregion

        #region DeleteProject Tests

        [Fact]
        public async System.Threading.Tasks.Task DeleteProjectAsync_ExistingProject_ReturnsTrue()
        {
            // Arrange
            var project = new Project { ProjectId = 1, ProjectName = "Test", TeamId = 1 };

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(project);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _projectService.DeleteProjectAsync(1);

            // Assert
            result.Should().BeTrue();
            _mockUnitOfWork.Verify(u => u.Projects.Remove(project), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteProjectAsync_NonExistingProject_ReturnsFalse()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(999))
                .ReturnsAsync((Project?)null);

            // Act
            var result = await _projectService.DeleteProjectAsync(999);

            // Assert
            result.Should().BeFalse();
        }

        #endregion

        #region Risk Calculation Tests

        [Fact]
        public async System.Threading.Tasks.Task CalculateProjectRiskAsync_ProjectBehindSchedule_ReturnsHighRisk()
        {
            // Arrange
            var project = new Project
            {
                ProjectId = 1,
                StartDate = DateTime.Now.AddDays(-30),
                EndDate = DateTime.Now.AddDays(30),
                CompletionPercentage = 10 // Only 10% complete at 50% time
            };

            var tasks = new List<ProjectTracker.Core.Entities.Task>
            {
                new() { TaskId = 1, ProjectId = 1, Status = TaskStatus.Pending },
                new() { TaskId = 2, ProjectId = 1, Status = TaskStatus.Pending }
            };

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(project);

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<ProjectTracker.Core.Entities.Task, bool>>>()))
                .ReturnsAsync(tasks);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _projectService.CalculateProjectRiskAsync(1);

            // Assert
            result.Should().BeGreaterThan(0);
        }

        [Fact]
        public async System.Threading.Tasks.Task CalculateProjectRiskAsync_NonExistingProject_ReturnsZero()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(999))
                .ReturnsAsync((Project?)null);

            // Act
            var result = await _projectService.CalculateProjectRiskAsync(999);

            // Assert
            result.Should().Be(0);
        }

        #endregion

        #region Completion Percentage Tests

        [Fact]
        public async System.Threading.Tasks.Task UpdateProjectCompletionAsync_AllTasksCompleted_Sets100Percent()
        {
            // Arrange
            var project = new Project { ProjectId = 1, CompletionPercentage = 0 };
            var tasks = new List<ProjectTracker.Core.Entities.Task>
            {
                new() { TaskId = 1, ProjectId = 1, Status = TaskStatus.Completed },
                new() { TaskId = 2, ProjectId = 1, Status = TaskStatus.Completed }
            };

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(project);

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<ProjectTracker.Core.Entities.Task, bool>>>()))
                .ReturnsAsync(tasks);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            await _projectService.UpdateProjectCompletionAsync(1);

            // Assert
            project.CompletionPercentage.Should().Be(100);
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateProjectCompletionAsync_NoTasks_SetsZeroPercent()
        {
            // Arrange
            var project = new Project { ProjectId = 1, CompletionPercentage = 50 };
            var tasks = new List<ProjectTracker.Core.Entities.Task>();

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(project);

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<ProjectTracker.Core.Entities.Task, bool>>>()))
                .ReturnsAsync(tasks);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            await _projectService.UpdateProjectCompletionAsync(1);

            // Assert
            project.CompletionPercentage.Should().Be(0);
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateProjectCompletionAsync_HalfTasksCompleted_Sets50Percent()
        {
            // Arrange
            var project = new Project { ProjectId = 1, CompletionPercentage = 0 };
            var tasks = new List<ProjectTracker.Core.Entities.Task>
            {
                new() { TaskId = 1, ProjectId = 1, Status = TaskStatus.Completed },
                new() { TaskId = 2, ProjectId = 1, Status = TaskStatus.Pending }
            };

            _mockUnitOfWork.Setup(u => u.Projects.GetByIdAsync(1))
                .ReturnsAsync(project);

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<ProjectTracker.Core.Entities.Task, bool>>>()))
                .ReturnsAsync(tasks);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            await _projectService.UpdateProjectCompletionAsync(1);

            // Assert
            project.CompletionPercentage.Should().Be(50);
        }

        #endregion
    }
}


