using FluentAssertions;
using Moq;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using ProjectTracker.Core.Interfaces.Repositories;
using System.Linq.Expressions;
using Xunit;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// GitHubSyncService için birim testleri
    /// GitHub API bağımlılığı mock'lanarak test edilir
    /// </summary>
    public class GitHubSyncServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ITokenPoolService> _mockTokenPoolService;
        private readonly Mock<ITaskMatchingService> _mockTaskMatchingService;
        private readonly Mock<IGitRepositoryRepository> _mockGitRepoRepository;
        private readonly Mock<IGitCommitRepository> _mockGitCommitRepository;
        private readonly Mock<IGitFileChangeRepository> _mockGitFileChangeRepository;
        private readonly GitHubSyncService _gitHubSyncService;

        public GitHubSyncServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockTokenPoolService = new Mock<ITokenPoolService>();
            _mockTaskMatchingService = new Mock<ITaskMatchingService>();
            _mockGitRepoRepository = new Mock<IGitRepositoryRepository>();
            _mockGitCommitRepository = new Mock<IGitCommitRepository>();
            _mockGitFileChangeRepository = new Mock<IGitFileChangeRepository>();

            _mockUnitOfWork.Setup(u => u.GitRepositories).Returns(_mockGitRepoRepository.Object);
            _mockUnitOfWork.Setup(u => u.GitCommits).Returns(_mockGitCommitRepository.Object);
            _mockUnitOfWork.Setup(u => u.GitFileChanges).Returns(_mockGitFileChangeRepository.Object);

            _gitHubSyncService = new GitHubSyncService(
                _mockUnitOfWork.Object,
                _mockTokenPoolService.Object,
                _mockTaskMatchingService.Object);
        }

        #region SyncRepositoryAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task SyncRepositoryAsync_WhenNoRepoLinked_ShouldReturnMessage()
        {
            // Arrange
            var projectId = 1;
            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync((GitRepository?)null);

            // Act
            var result = await _gitHubSyncService.SyncRepositoryAsync(projectId);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("No GitHub repository linked");
        }

        [Fact]
        public async System.Threading.Tasks.Task SyncRepositoryAsync_WhenNoTokenAvailable_ShouldReturnMessage()
        {
            // Arrange
            var projectId = 1;
            var repo = new GitRepository
            {
                GitRepositoryId = 1,
                ProjectId = projectId,
                RepoOwner = "owner",
                RepoName = "repo"
            };

            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync(repo);
            _mockTokenPoolService.Setup(t => t.GetBestTokenAsync())
                .ReturnsAsync((string?)null);

            // Act
            var result = await _gitHubSyncService.SyncRepositoryAsync(projectId);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("No GitHub tokens available");
        }

        [Fact]
        public async System.Threading.Tasks.Task SyncRepositoryAsync_WhenInvalidRepoInfo_ShouldReturnMessage()
        {
            // Arrange
            var projectId = 1;
            var repo = new GitRepository
            {
                GitRepositoryId = 1,
                ProjectId = projectId,
                RepoOwner = "",
                RepoName = ""
            };

            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync(repo);
            _mockTokenPoolService.Setup(t => t.GetBestTokenAsync())
                .ReturnsAsync("valid-token");

            // Act
            var result = await _gitHubSyncService.SyncRepositoryAsync(projectId);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Invalid repository info");
        }

        #endregion

        #region LinkRepositoryAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task LinkRepositoryAsync_WithValidUrl_ShouldCreateRepository()
        {
            // Arrange
            var projectId = 1;
            var repoUrl = "https://github.com/testowner/testrepo";

            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync((GitRepository?)null);
            _mockGitRepoRepository.Setup(r => r.AddAsync(It.IsAny<GitRepository>()))
                .ReturnsAsync((GitRepository r) => r);

            // Act
            var result = await _gitHubSyncService.LinkRepositoryAsync(projectId, repoUrl);

            // Assert
            result.Should().NotBeNull();
            result.RepoOwner.Should().Be("testowner");
            result.RepoName.Should().Be("testrepo");
            result.ProjectId.Should().Be(projectId);
            _mockGitRepoRepository.Verify(r => r.AddAsync(It.IsAny<GitRepository>()), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task LinkRepositoryAsync_WithGitSuffix_ShouldParseCorrectly()
        {
            // Arrange
            var projectId = 1;
            var repoUrl = "https://github.com/owner/repo.git";

            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync((GitRepository?)null);
            _mockGitRepoRepository.Setup(r => r.AddAsync(It.IsAny<GitRepository>()))
                .ReturnsAsync((GitRepository r) => r);

            // Act
            var result = await _gitHubSyncService.LinkRepositoryAsync(projectId, repoUrl);

            // Assert
            result.RepoOwner.Should().Be("owner");
            result.RepoName.Should().Be("repo");
        }

        [Fact]
        public async System.Threading.Tasks.Task LinkRepositoryAsync_WithTrailingSlash_ShouldParseCorrectly()
        {
            // Arrange
            var projectId = 1;
            var repoUrl = "https://github.com/owner/repo/";

            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync((GitRepository?)null);
            _mockGitRepoRepository.Setup(r => r.AddAsync(It.IsAny<GitRepository>()))
                .ReturnsAsync((GitRepository r) => r);

            // Act
            var result = await _gitHubSyncService.LinkRepositoryAsync(projectId, repoUrl);

            // Assert
            result.RepoOwner.Should().Be("owner");
            result.RepoName.Should().Be("repo");
        }

        [Fact]
        public async System.Threading.Tasks.Task LinkRepositoryAsync_WhenExistingRepo_ShouldReplaceIt()
        {
            // Arrange
            var projectId = 1;
            var repoUrl = "https://github.com/newowner/newrepo";
            var existingRepo = new GitRepository
            {
                GitRepositoryId = 1,
                ProjectId = projectId,
                RepoOwner = "oldowner",
                RepoName = "oldrepo"
            };

            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync(existingRepo);
            _mockGitRepoRepository.Setup(r => r.AddAsync(It.IsAny<GitRepository>()))
                .ReturnsAsync((GitRepository r) => r);

            // Act
            var result = await _gitHubSyncService.LinkRepositoryAsync(projectId, repoUrl);

            // Assert
            result.RepoOwner.Should().Be("newowner");
            result.RepoName.Should().Be("newrepo");
            _mockGitRepoRepository.Verify(r => r.Remove(existingRepo), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task LinkRepositoryAsync_WithInvalidUrl_ShouldThrowException()
        {
            // Arrange
            var projectId = 1;
            var repoUrl = "invalid-url";

            // Act
            var act = async () => await _gitHubSyncService.LinkRepositoryAsync(projectId, repoUrl);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("*Invalid GitHub repository URL*");
        }

        [Fact]
        public async System.Threading.Tasks.Task LinkRepositoryAsync_WithEmptyUrl_ShouldThrowException()
        {
            // Arrange
            var projectId = 1;
            var repoUrl = "";

            // Act
            var act = async () => await _gitHubSyncService.LinkRepositoryAsync(projectId, repoUrl);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>();
        }

        #endregion

        #region UnlinkRepositoryAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task UnlinkRepositoryAsync_WhenRepoExists_ShouldReturnTrue()
        {
            // Arrange
            var projectId = 1;
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = projectId };

            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync(repo);

            // Act
            var result = await _gitHubSyncService.UnlinkRepositoryAsync(projectId);

            // Assert
            result.Should().BeTrue();
            _mockGitRepoRepository.Verify(r => r.Remove(repo), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task UnlinkRepositoryAsync_WhenNoRepo_ShouldReturnFalse()
        {
            // Arrange
            var projectId = 1;
            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync((GitRepository?)null);

            // Act
            var result = await _gitHubSyncService.UnlinkRepositoryAsync(projectId);

            // Assert
            result.Should().BeFalse();
            _mockGitRepoRepository.Verify(r => r.Remove(It.IsAny<GitRepository>()), Times.Never);
        }

        #endregion

        #region GetRepositoryAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task GetRepositoryAsync_WhenRepoExists_ShouldReturnDto()
        {
            // Arrange
            var projectId = 1;
            var repo = new GitRepository
            {
                GitRepositoryId = 1,
                ProjectId = projectId,
                RepoUrl = "https://github.com/owner/repo",
                RepoOwner = "owner",
                RepoName = "repo",
                DefaultBranch = "main",
                IsPrivate = false,
                TotalCommits = 100,
                SyncStatus = "Completed"
            };

            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync(repo);

            // Act
            var result = await _gitHubSyncService.GetRepositoryAsync(projectId);

            // Assert
            result.Should().NotBeNull();
            result!.RepoOwner.Should().Be("owner");
            result.RepoName.Should().Be("repo");
            result.DefaultBranch.Should().Be("main");
            result.TotalCommits.Should().Be(100);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetRepositoryAsync_WhenNoRepo_ShouldReturnNull()
        {
            // Arrange
            var projectId = 1;
            _mockGitRepoRepository.Setup(r => r.GetByProjectIdAsync(projectId))
                .ReturnsAsync((GitRepository?)null);

            // Act
            var result = await _gitHubSyncService.GetRepositoryAsync(projectId);

            // Assert
            result.Should().BeNull();
        }

        #endregion
    }
}
