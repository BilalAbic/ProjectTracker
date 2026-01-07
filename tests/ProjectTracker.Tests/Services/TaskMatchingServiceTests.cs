using Moq;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using System.Linq.Expressions;
using CoreTask = ProjectTracker.Core.Entities.Task;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// TaskMatchingService Unit Tests
    /// </summary>
    public class TaskMatchingServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly TaskMatchingService _taskMatchingService;

        public TaskMatchingServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _taskMatchingService = new TaskMatchingService(_mockUnitOfWork.Object);
        }

        #region FindBestMatch Tests

        [Fact]
        public async System.Threading.Tasks.Task FindBestMatchAsync_ExactMatch_ReturnsHighScore()
        {
            // Arrange
            var tasks = new List<CoreTask>
            {
                new() { TaskId = 1, ProjectId = 1, TaskName = "Fix login bug" },
                new() { TaskId = 2, ProjectId = 1, TaskName = "Add user profile" },
                new() { TaskId = 3, ProjectId = 1, TaskName = "Update dashboard" }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<CoreTask, bool>>>()))
                .ReturnsAsync(tasks);

            // Act
            var (taskId, taskName, score) = await _taskMatchingService.FindBestMatchAsync(1, "Fix login bug issue");

            // Assert
            taskId.Should().Be(1);
            taskName.Should().Be("Fix login bug");
            score.Should().BeGreaterThan(30); // Above threshold
        }

        [Fact]
        public async System.Threading.Tasks.Task FindBestMatchAsync_PartialMatch_ReturnsMatch()
        {
            // Arrange
            var tasks = new List<CoreTask>
            {
                new() { TaskId = 1, ProjectId = 1, TaskName = "Implement authentication" },
                new() { TaskId = 2, ProjectId = 1, TaskName = "Create user registration" }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<CoreTask, bool>>>()))
                .ReturnsAsync(tasks);

            // Act
            var (taskId, taskName, score) = await _taskMatchingService.FindBestMatchAsync(1, "Added auth feature");

            // Assert
            taskId.Should().Be(1); // Should match "authentication" with "auth"
            score.Should().BeGreaterThan(0);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindBestMatchAsync_NoMatch_ReturnsNull()
        {
            // Arrange
            var tasks = new List<CoreTask>
            {
                new() { TaskId = 1, ProjectId = 1, TaskName = "Fix login bug" },
                new() { TaskId = 2, ProjectId = 1, TaskName = "Add user profile" }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<CoreTask, bool>>>()))
                .ReturnsAsync(tasks);

            // Act
            var (taskId, taskName, score) = await _taskMatchingService.FindBestMatchAsync(1, "xyz abc 123");

            // Assert
            taskId.Should().BeNull();
            taskName.Should().BeNull();
            score.Should().Be(0);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindBestMatchAsync_EmptyCommitMessage_ReturnsNull()
        {
            // Arrange & Act
            var (taskId, taskName, score) = await _taskMatchingService.FindBestMatchAsync(1, "");

            // Assert
            taskId.Should().BeNull();
            score.Should().Be(0);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindBestMatchAsync_NoTasks_ReturnsNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<CoreTask, bool>>>()))
                .ReturnsAsync(new List<CoreTask>());

            // Act
            var (taskId, taskName, score) = await _taskMatchingService.FindBestMatchAsync(1, "Fix bug");

            // Assert
            taskId.Should().BeNull();
            score.Should().Be(0);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindBestMatchAsync_KeywordWeighting_PrioritizesActionWords()
        {
            // Arrange
            var tasks = new List<CoreTask>
            {
                new() { TaskId = 1, ProjectId = 1, TaskName = "Fix critical bug" },
                new() { TaskId = 2, ProjectId = 1, TaskName = "Review code" }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<CoreTask, bool>>>()))
                .ReturnsAsync(tasks);

            // Act - "fix" and "bug" are high-weight keywords
            var (taskId, taskName, score) = await _taskMatchingService.FindBestMatchAsync(1, "Fixed the bug");

            // Assert
            taskId.Should().Be(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task FindBestMatchAsync_MatchesDescription_WhenNameDoesntMatch()
        {
            // Arrange
            var tasks = new List<CoreTask>
            {
                new() { TaskId = 1, ProjectId = 1, TaskName = "Task 1", Description = "Fix authentication issue" },
                new() { TaskId = 2, ProjectId = 1, TaskName = "Task 2", Description = "Update UI" }
            };

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<CoreTask, bool>>>()))
                .ReturnsAsync(tasks);

            // Act
            var (taskId, taskName, score) = await _taskMatchingService.FindBestMatchAsync(1, "Fixed auth bug");

            // Assert
            taskId.Should().Be(1);
        }

        #endregion

        #region RematchAllCommits Tests

        [Fact]
        public async System.Threading.Tasks.Task RematchAllCommitsAsync_MatchesCommits_ReturnsCount()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1 };
            var commits = new List<GitCommit>
            {
                new() { GitCommitId = 1, GitRepositoryId = 1, Message = "Fix login bug" },
                new() { GitCommitId = 2, GitRepositoryId = 1, Message = "Add feature" }
            };
            var tasks = new List<CoreTask>
            {
                new() { TaskId = 1, ProjectId = 1, TaskName = "Fix login bug" }
            };

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitCommits.GetByRepositoryIdAsync(1))
                .ReturnsAsync(commits);

            _mockUnitOfWork.Setup(u => u.Tasks.FindAsync(It.IsAny<Expression<Func<CoreTask, bool>>>()))
                .ReturnsAsync(tasks);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _taskMatchingService.RematchAllCommitsAsync(1);

            // Assert
            result.Should().BeGreaterThanOrEqualTo(0);
        }

        [Fact]
        public async System.Threading.Tasks.Task RematchAllCommitsAsync_RepoNotFound_ReturnsZero()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByIdAsync(999))
                .ReturnsAsync((GitRepository?)null);

            // Act
            var result = await _taskMatchingService.RematchAllCommitsAsync(999);

            // Assert
            result.Should().Be(0);
        }

        #endregion
    }
}
