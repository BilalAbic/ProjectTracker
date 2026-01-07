using Moq;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using System.Linq.Expressions;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// GitHubAnalyticsService Unit Tests
    /// </summary>
    public class GitHubAnalyticsServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly GitHubAnalyticsService _analyticsService;

        public GitHubAnalyticsServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _analyticsService = new GitHubAnalyticsService(_mockUnitOfWork.Object);
        }

        #region GetAnalyticsSummary Tests

        [Fact]
        public async System.Threading.Tasks.Task GetAnalyticsSummaryAsync_ValidProject_ReturnsSummary()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1, TotalContributors = 3 };
            var commits = new List<GitCommit>
            {
                new() { GitCommitId = 1, AuthorGitHubUsername = "user1", CommitDate = DateTime.Now, Additions = 100, Deletions = 50, LinkedTaskId = 1, MatchScore = 80 },
                new() { GitCommitId = 2, AuthorGitHubUsername = "user2", CommitDate = DateTime.Now.AddDays(-1), Additions = 50, Deletions = 25 }
            };

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitCommits.GetByRepositoryIdAsync(1))
                .ReturnsAsync(commits);

            _mockUnitOfWork.Setup(u => u.GitCommits.GetLeaderboardAsync(1))
                .ReturnsAsync(new List<(string Author, string? AvatarUrl, int CommitCount, int Additions, int Deletions)>());

            _mockUnitOfWork.Setup(u => u.GitFileChanges.GetHotspotsAsync(1, 5))
                .ReturnsAsync(new List<(string FileName, int ChangeCount, int TotalAdditions, int TotalDeletions)>());

            _mockUnitOfWork.Setup(u => u.GitFileChanges.GetLanguageDistributionAsync(1))
                .ReturnsAsync(new List<(string Extension, int FileCount, int TotalChanges)>());

            // Act
            var result = await _analyticsService.GetAnalyticsSummaryAsync(1);

            // Assert
            result.Should().NotBeNull();
            result!.TotalCommits.Should().Be(2);
            result.TotalContributors.Should().Be(2);
            result.TotalAdditions.Should().Be(150);
            result.TotalDeletions.Should().Be(75);
            result.MatchedTasksCount.Should().Be(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAnalyticsSummaryAsync_NoRepo_ReturnsNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(999))
                .ReturnsAsync((GitRepository?)null);

            // Act
            var result = await _analyticsService.GetAnalyticsSummaryAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAnalyticsSummaryAsync_NoCommits_ReturnsEmptySummary()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1, TotalContributors = 0 };

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitCommits.GetByRepositoryIdAsync(1))
                .ReturnsAsync(new List<GitCommit>());

            // Act
            var result = await _analyticsService.GetAnalyticsSummaryAsync(1);

            // Assert
            result.Should().NotBeNull();
            result!.TotalCommits.Should().Be(0);
        }

        #endregion

        #region GetCommits Tests

        [Fact]
        public async System.Threading.Tasks.Task GetCommitsAsync_ReturnsCommits()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1 };
            var commits = new List<GitCommit>
            {
                new() { GitCommitId = 1, Sha = "abc123", Message = "Fix bug", AuthorName = "User", CommitDate = DateTime.Now },
                new() { GitCommitId = 2, Sha = "def456", Message = "Add feature", AuthorName = "User", CommitDate = DateTime.Now }
            };

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitCommits.GetByRepositoryIdWithFilesAsync(1))
                .ReturnsAsync(commits);

            // Act
            var result = await _analyticsService.GetCommitsAsync(1);

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetCommitsAsync_WithLimit_ReturnsLimitedCommits()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1 };
            var commits = Enumerable.Range(1, 20).Select(i => new GitCommit
            {
                GitCommitId = i,
                Sha = $"sha{i}",
                Message = $"Commit {i}",
                CommitDate = DateTime.Now
            }).ToList();

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitCommits.GetByRepositoryIdWithFilesAsync(1))
                .ReturnsAsync(commits);

            // Act
            var result = await _analyticsService.GetCommitsAsync(1, limit: 5);

            // Assert
            result.Should().HaveCount(5);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetCommitsAsync_NoRepo_ReturnsEmpty()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(999))
                .ReturnsAsync((GitRepository?)null);

            // Act
            var result = await _analyticsService.GetCommitsAsync(999);

            // Assert
            result.Should().BeEmpty();
        }

        #endregion

        #region GetCommitsByTask Tests

        [Fact]
        public async System.Threading.Tasks.Task GetCommitsByTaskAsync_ReturnsLinkedCommits()
        {
            // Arrange
            var commits = new List<GitCommit>
            {
                new() { GitCommitId = 1, LinkedTaskId = 1, Message = "Fix task 1" },
                new() { GitCommitId = 2, LinkedTaskId = 1, Message = "Update task 1" }
            };

            _mockUnitOfWork.Setup(u => u.GitCommits.GetByTaskIdAsync(1))
                .ReturnsAsync(commits);

            // Act
            var result = await _analyticsService.GetCommitsByTaskAsync(1);

            // Assert
            result.Should().HaveCount(2);
        }

        #endregion

        #region GetLeaderboard Tests

        [Fact]
        public async System.Threading.Tasks.Task GetLeaderboardAsync_ReturnsRankedContributors()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1 };
            var leaderboard = new List<(string Author, string? AvatarUrl, int CommitCount, int Additions, int Deletions)>
            {
                ("user1", "avatar1.png", 50, 1000, 500),
                ("user2", "avatar2.png", 30, 600, 300),
                ("user3", null, 20, 400, 200)
            };

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitCommits.GetLeaderboardAsync(1))
                .ReturnsAsync(leaderboard);

            // Act
            var result = (await _analyticsService.GetLeaderboardAsync(1)).ToList();

            // Assert
            result.Should().HaveCount(3);
            result[0].Rank.Should().Be(1);
            result[0].Author.Should().Be("user1");
            result[0].CommitCount.Should().Be(50);
            result[1].Rank.Should().Be(2);
            result[2].Rank.Should().Be(3);
        }

        #endregion

        #region GetPunchCard Tests

        [Fact]
        public async System.Threading.Tasks.Task GetPunchCardAsync_ReturnsPunchCardData()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1 };
            var punchCard = new List<(int DayOfWeek, int Hour, int Count)>
            {
                (1, 9, 10),  // Monday 9am
                (1, 14, 15), // Monday 2pm
                (3, 10, 8)   // Wednesday 10am
            };

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitCommits.GetPunchCardDataAsync(1))
                .ReturnsAsync(punchCard);

            // Act
            var result = (await _analyticsService.GetPunchCardAsync(1)).ToList();

            // Assert
            result.Should().HaveCount(3);
            result[0].DayName.Should().Be("Monday");
            result[0].Hour.Should().Be(9);
            result[0].Count.Should().Be(10);
        }

        #endregion

        #region GetHotspots Tests

        [Fact]
        public async System.Threading.Tasks.Task GetHotspotsAsync_ReturnsTopChangedFiles()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1 };
            var hotspots = new List<(string FileName, int ChangeCount, int TotalAdditions, int TotalDeletions)>
            {
                ("src/main.cs", 50, 500, 200),
                ("src/utils.cs", 30, 300, 100)
            };

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitFileChanges.GetHotspotsAsync(1, 10))
                .ReturnsAsync(hotspots);

            // Act
            var result = (await _analyticsService.GetHotspotsAsync(1, 10)).ToList();

            // Assert
            result.Should().HaveCount(2);
            result[0].FileName.Should().Be("src/main.cs");
            result[0].ChangeCount.Should().Be(50);
        }

        #endregion

        #region GetLanguageDistribution Tests

        [Fact]
        public async System.Threading.Tasks.Task GetLanguageDistributionAsync_ReturnsLanguageStats()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1 };
            var distribution = new List<(string Extension, int FileCount, int TotalChanges)>
            {
                (".cs", 100, 5000),
                (".js", 50, 2000),
                (".html", 30, 1000)
            };

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitFileChanges.GetLanguageDistributionAsync(1))
                .ReturnsAsync(distribution);

            // Act
            var result = (await _analyticsService.GetLanguageDistributionAsync(1)).ToList();

            // Assert
            result.Should().HaveCount(3);
            result[0].Extension.Should().Be(".cs");
            result[0].Language.Should().Be("C#");
            result[0].Percentage.Should().BeGreaterThan(0);
        }

        #endregion

        #region GetCommitTrend Tests

        [Fact]
        public async System.Threading.Tasks.Task GetCommitTrendAsync_ReturnsDailyTrend()
        {
            // Arrange
            var repo = new GitRepository { GitRepositoryId = 1, ProjectId = 1 };
            var commits = new List<GitCommit>
            {
                new() { GitCommitId = 1, CommitDate = DateTime.Now, Additions = 100, Deletions = 50 },
                new() { GitCommitId = 2, CommitDate = DateTime.Now, Additions = 50, Deletions = 25 },
                new() { GitCommitId = 3, CommitDate = DateTime.Now.AddDays(-1), Additions = 75, Deletions = 30 }
            };

            _mockUnitOfWork.Setup(u => u.GitRepositories.GetByProjectIdAsync(1))
                .ReturnsAsync(repo);

            _mockUnitOfWork.Setup(u => u.GitCommits.GetByRepositoryIdAsync(1))
                .ReturnsAsync(commits);

            // Act
            var result = (await _analyticsService.GetCommitTrendAsync(1, 7)).ToList();

            // Assert
            result.Should().HaveCount(8); // 7 days + today
            result.Last().CommitCount.Should().Be(2); // Today's commits
        }

        #endregion
    }
}
