using Moq;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using System.Linq.Expressions;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// TokenPoolService Unit Tests
    /// </summary>
    public class TokenPoolServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly TokenPoolService _tokenPoolService;

        public TokenPoolServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _tokenPoolService = new TokenPoolService(_mockUnitOfWork.Object);
        }

        #region GetBestToken Tests

        [Fact]
        public async System.Threading.Tasks.Task GetBestTokenAsync_TokenExists_ReturnsDecryptedToken()
        {
            // Arrange
            var encryptedToken = EncryptTestToken("ghp_test123");
            var token = new GitHubToken
            {
                GitHubTokenId = 1,
                EncryptedToken = encryptedToken,
                RateLimitRemaining = 5000,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.GitHubTokens.GetBestAvailableTokenAsync())
                .ReturnsAsync(token);

            // Act
            var result = await _tokenPoolService.GetBestTokenAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().Be("ghp_test123");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetBestTokenAsync_NoTokens_ReturnsNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.GitHubTokens.GetBestAvailableTokenAsync())
                .ReturnsAsync((GitHubToken?)null);

            // Act
            var result = await _tokenPoolService.GetBestTokenAsync();

            // Assert
            result.Should().BeNull();
        }

        #endregion

        #region UpdateRateLimit Tests

        [Fact]
        public async System.Threading.Tasks.Task UpdateRateLimitAsync_ValidData_UpdatesToken()
        {
            // Arrange
            var resetAt = DateTime.Now.AddHours(1);

            _mockUnitOfWork.Setup(u => u.GitHubTokens.UpdateRateLimitAsync(1, 4500, resetAt))
                .Returns(System.Threading.Tasks.Task.CompletedTask);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            await _tokenPoolService.UpdateRateLimitAsync(1, 4500, resetAt);

            // Assert
            _mockUnitOfWork.Verify(u => u.GitHubTokens.UpdateRateLimitAsync(1, 4500, resetAt), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        #endregion

        #region GetUserTokens Tests

        [Fact]
        public async System.Threading.Tasks.Task GetUserTokensAsync_ReturnsUserTokens()
        {
            // Arrange
            var tokens = new List<GitHubToken>
            {
                new() { GitHubTokenId = 1, UserId = 1, GitHubUsername = "user1", RateLimitRemaining = 5000, IsActive = true, CreatedAt = DateTime.Now },
                new() { GitHubTokenId = 2, UserId = 1, GitHubUsername = "user1_alt", RateLimitRemaining = 4000, IsActive = true, CreatedAt = DateTime.Now }
            };

            _mockUnitOfWork.Setup(u => u.GitHubTokens.GetByUserIdAsync(1))
                .ReturnsAsync(tokens);

            // Act
            var result = await _tokenPoolService.GetUserTokensAsync(1);

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetUserTokensAsync_NoTokens_ReturnsEmpty()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.GitHubTokens.GetByUserIdAsync(1))
                .ReturnsAsync(new List<GitHubToken>());

            // Act
            var result = await _tokenPoolService.GetUserTokensAsync(1);

            // Assert
            result.Should().BeEmpty();
        }

        #endregion

        #region AddToken Tests

        [Fact]
        public async System.Threading.Tasks.Task AddTokenAsync_ValidData_CreatesToken()
        {
            // Arrange
            var dto = new SaveGitHubTokenDto
            {
                Token = "ghp_newtoken123",
                GitHubUsername = "newuser"
            };

            _mockUnitOfWork.Setup(u => u.GitHubTokens.AddAsync(It.IsAny<GitHubToken>()))
                .ReturnsAsync((GitHubToken t) => { t.GitHubTokenId = 1; return t; });

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _tokenPoolService.AddTokenAsync(1, dto);

            // Assert
            result.Should().NotBeNull();
            result.GitHubUsername.Should().Be("newuser");
            result.RateLimitRemaining.Should().Be(5000);
            result.IsActive.Should().BeTrue();
            _mockUnitOfWork.Verify(u => u.GitHubTokens.AddAsync(It.IsAny<GitHubToken>()), Times.Once);
        }

        #endregion

        #region RemoveToken Tests

        [Fact]
        public async System.Threading.Tasks.Task RemoveTokenAsync_ValidOwner_ReturnsTrue()
        {
            // Arrange
            var token = new GitHubToken { GitHubTokenId = 1, UserId = 1 };

            _mockUnitOfWork.Setup(u => u.GitHubTokens.GetByIdAsync(1))
                .ReturnsAsync(token);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _tokenPoolService.RemoveTokenAsync(1, 1);

            // Assert
            result.Should().BeTrue();
            _mockUnitOfWork.Verify(u => u.GitHubTokens.Remove(token), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task RemoveTokenAsync_WrongOwner_ReturnsFalse()
        {
            // Arrange
            var token = new GitHubToken { GitHubTokenId = 1, UserId = 2 }; // Different user

            _mockUnitOfWork.Setup(u => u.GitHubTokens.GetByIdAsync(1))
                .ReturnsAsync(token);

            // Act
            var result = await _tokenPoolService.RemoveTokenAsync(1, 1);

            // Assert
            result.Should().BeFalse();
            _mockUnitOfWork.Verify(u => u.GitHubTokens.Remove(It.IsAny<GitHubToken>()), Times.Never);
        }

        [Fact]
        public async System.Threading.Tasks.Task RemoveTokenAsync_TokenNotFound_ReturnsFalse()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.GitHubTokens.GetByIdAsync(999))
                .ReturnsAsync((GitHubToken?)null);

            // Act
            var result = await _tokenPoolService.RemoveTokenAsync(999, 1);

            // Assert
            result.Should().BeFalse();
        }

        #endregion

        #region GetPoolStatus Tests

        [Fact]
        public async System.Threading.Tasks.Task GetPoolStatusAsync_ReturnsCorrectStats()
        {
            // Arrange
            var tokens = new List<GitHubToken>
            {
                new() { GitHubTokenId = 1, RateLimitRemaining = 5000, IsActive = true },
                new() { GitHubTokenId = 2, RateLimitRemaining = 3000, IsActive = true },
                new() { GitHubTokenId = 3, RateLimitRemaining = 2000, IsActive = true }
            };

            _mockUnitOfWork.Setup(u => u.GitHubTokens.GetActiveTokensAsync())
                .ReturnsAsync(tokens);

            // Act
            var (totalTokens, totalRateLimit) = await _tokenPoolService.GetPoolStatusAsync();

            // Assert
            totalTokens.Should().Be(3);
            totalRateLimit.Should().Be(10000);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetPoolStatusAsync_NoTokens_ReturnsZeros()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.GitHubTokens.GetActiveTokensAsync())
                .ReturnsAsync(new List<GitHubToken>());

            // Act
            var (totalTokens, totalRateLimit) = await _tokenPoolService.GetPoolStatusAsync();

            // Assert
            totalTokens.Should().Be(0);
            totalRateLimit.Should().Be(0);
        }

        #endregion

        #region Helper Methods

        private static string EncryptTestToken(string plainToken)
        {
            // Same encryption logic as TokenPoolService
            var key = System.Text.Encoding.UTF8.GetBytes("ProjectTracker2025GitHubKey!!");
            var bytes = System.Text.Encoding.UTF8.GetBytes(plainToken);
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] ^= key[i % key.Length];
            }
            return Convert.ToBase64String(bytes);
        }

        #endregion
    }
}
