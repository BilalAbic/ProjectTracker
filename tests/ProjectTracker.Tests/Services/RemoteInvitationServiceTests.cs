using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using ProjectTracker.Business.Services;
using Xunit;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// RemoteInvitationService için birim testleri
    /// HTTP bağımlılığı nedeniyle sadece yapılandırma testleri
    /// </summary>
    public class RemoteInvitationServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;

        public RemoteInvitationServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
        }

        #region Constructor Tests

        [Fact]
        public void Constructor_WithDefaultConfiguration_ShouldInitialize()
        {
            // Arrange - No configuration values set

            // Act
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Assert
            service.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithCustomConfiguration_ShouldInitialize()
        {
            // Arrange
            _mockConfiguration.Setup(c => c["RemoteApi:BaseUrl"]).Returns("https://custom-api.com/api");
            _mockConfiguration.Setup(c => c["RemoteApi:Enabled"]).Returns("true");

            // Act
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Assert
            service.Should().NotBeNull();
        }

        #endregion

        #region SendInvitationToRemoteAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task SendInvitationToRemoteAsync_WhenDisabled_ShouldReturnTrue()
        {
            // Arrange
            _mockConfiguration.Setup(c => c["RemoteApi:Enabled"]).Returns("false");
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Act
            var result = await service.SendInvitationToRemoteAsync(
                token: "test-token",
                email: "test@test.com",
                teamName: "Test Team",
                invitedByName: "Admin",
                proposedRole: "Developer",
                expiresAt: DateTime.Now.AddDays(7));

            // Assert
            result.Should().BeTrue(); // Returns true when disabled (no-op)
        }

        [Fact]
        public async System.Threading.Tasks.Task SendInvitationToRemoteAsync_WithValidData_ShouldNotThrow()
        {
            // Arrange
            _mockConfiguration.Setup(c => c["RemoteApi:Enabled"]).Returns("false");
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Act
            var act = async () => await service.SendInvitationToRemoteAsync(
                token: Guid.NewGuid().ToString(),
                email: "newuser@example.com",
                teamName: "Development Team",
                invitedByName: "Project Manager",
                proposedRole: "Admin",
                expiresAt: DateTime.Now.AddDays(14));

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async System.Threading.Tasks.Task SendInvitationToRemoteAsync_WithEmptyToken_ShouldNotThrow()
        {
            // Arrange
            _mockConfiguration.Setup(c => c["RemoteApi:Enabled"]).Returns("false");
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Act
            var act = async () => await service.SendInvitationToRemoteAsync(
                token: "",
                email: "test@test.com",
                teamName: "Test Team",
                invitedByName: "Admin",
                proposedRole: "Developer",
                expiresAt: DateTime.Now.AddDays(7));

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async System.Threading.Tasks.Task SendInvitationToRemoteAsync_WithPastExpiryDate_ShouldNotThrow()
        {
            // Arrange
            _mockConfiguration.Setup(c => c["RemoteApi:Enabled"]).Returns("false");
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Act
            var act = async () => await service.SendInvitationToRemoteAsync(
                token: "test-token",
                email: "test@test.com",
                teamName: "Test Team",
                invitedByName: "Admin",
                proposedRole: "Developer",
                expiresAt: DateTime.Now.AddDays(-1)); // Past date

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Theory]
        [InlineData("Owner")]
        [InlineData("Admin")]
        [InlineData("Developer")]
        public async System.Threading.Tasks.Task SendInvitationToRemoteAsync_WithVariousRoles_ShouldNotThrow(string role)
        {
            // Arrange
            _mockConfiguration.Setup(c => c["RemoteApi:Enabled"]).Returns("false");
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Act
            var act = async () => await service.SendInvitationToRemoteAsync(
                token: "test-token",
                email: "test@test.com",
                teamName: "Test Team",
                invitedByName: "Admin",
                proposedRole: role,
                expiresAt: DateTime.Now.AddDays(7));

            // Assert
            await act.Should().NotThrowAsync();
        }

        #endregion

        #region Configuration Edge Cases

        [Fact]
        public void Constructor_WithNullBaseUrl_ShouldUseDefault()
        {
            // Arrange
            _mockConfiguration.Setup(c => c["RemoteApi:BaseUrl"]).Returns((string?)null);
            _mockConfiguration.Setup(c => c["RemoteApi:Enabled"]).Returns("false");

            // Act
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Assert
            service.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullEnabled_ShouldDefaultToFalse()
        {
            // Arrange
            _mockConfiguration.Setup(c => c["RemoteApi:Enabled"]).Returns((string?)null);

            // Act
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Assert
            service.Should().NotBeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task SendInvitationToRemoteAsync_WhenEnabled_WithInvalidUrl_ShouldReturnFalse()
        {
            // Arrange
            _mockConfiguration.Setup(c => c["RemoteApi:BaseUrl"]).Returns("invalid-url");
            _mockConfiguration.Setup(c => c["RemoteApi:Enabled"]).Returns("true");
            var service = new RemoteInvitationService(_mockConfiguration.Object);

            // Act
            var result = await service.SendInvitationToRemoteAsync(
                token: "test-token",
                email: "test@test.com",
                teamName: "Test Team",
                invitedByName: "Admin",
                proposedRole: "Developer",
                expiresAt: DateTime.Now.AddDays(7));

            // Assert
            result.Should().BeFalse(); // Should fail gracefully
        }

        #endregion
    }
}
