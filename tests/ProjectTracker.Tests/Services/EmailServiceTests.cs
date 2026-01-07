using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using ProjectTracker.Business.Services;
using Xunit;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// EmailService için birim testleri
    /// SMTP bağımlılığı nedeniyle sadece yapılandırma ve template testleri
    /// </summary>
    public class EmailServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly EmailService _emailService;

        public EmailServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            
            // Default configuration setup
            _mockConfiguration.Setup(c => c["Email:SmtpHost"]).Returns("smtp.test.com");
            _mockConfiguration.Setup(c => c["Email:SmtpPort"]).Returns("587");
            _mockConfiguration.Setup(c => c["Email:Username"]).Returns("test@test.com");
            _mockConfiguration.Setup(c => c["Email:Password"]).Returns("password");
            _mockConfiguration.Setup(c => c["Email:FromEmail"]).Returns("noreply@test.com");
            _mockConfiguration.Setup(c => c["Email:FromName"]).Returns("ProjectTracker");
            _mockConfiguration.Setup(c => c["Email:EnableSsl"]).Returns("true");
            _mockConfiguration.Setup(c => c["Email:Enabled"]).Returns("false"); // Disabled for tests
            _mockConfiguration.Setup(c => c["AppSettings:InvitationBaseUrl"]).Returns("https://test.com/invite");

            _emailService = new EmailService(_mockConfiguration.Object);
        }

        #region SendTaskAssignmentEmailAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task SendTaskAssignmentEmailAsync_WhenDisabled_ShouldNotThrow()
        {
            // Arrange
            var toEmail = "user@test.com";
            var toName = "Test User";
            var taskName = "Test Task";
            var projectName = "Test Project";
            var assignedBy = "Admin";
            var dueDate = DateTime.Now.AddDays(7);
            var description = "Test description";

            // Act
            var act = async () => await _emailService.SendTaskAssignmentEmailAsync(
                toEmail, toName, taskName, projectName, assignedBy, dueDate, description);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async System.Threading.Tasks.Task SendTaskAssignmentEmailAsync_WithNullDueDate_ShouldNotThrow()
        {
            // Arrange
            var toEmail = "user@test.com";
            var toName = "Test User";
            var taskName = "Test Task";
            var projectName = "Test Project";
            var assignedBy = "Admin";

            // Act
            var act = async () => await _emailService.SendTaskAssignmentEmailAsync(
                toEmail, toName, taskName, projectName, assignedBy, null, null);

            // Assert
            await act.Should().NotThrowAsync();
        }

        #endregion

        #region SendTeamInvitationEmailAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task SendTeamInvitationEmailAsync_WhenDisabled_ShouldNotThrow()
        {
            // Arrange
            var toEmail = "user@test.com";
            var teamName = "Test Team";
            var invitedByName = "Admin";
            var role = "Developer";
            var token = "test-token-123";
            var expiresAt = DateTime.Now.AddDays(7);

            // Act
            var act = async () => await _emailService.SendTeamInvitationEmailAsync(
                toEmail, teamName, invitedByName, role, token, expiresAt);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async System.Threading.Tasks.Task SendTeamInvitationEmailAsync_WithValidData_ShouldNotThrow()
        {
            // Arrange
            var toEmail = "newuser@test.com";
            var teamName = "Development Team";
            var invitedByName = "Project Manager";
            var role = "Admin";
            var token = Guid.NewGuid().ToString();
            var expiresAt = DateTime.Now.AddDays(14);

            // Act
            var act = async () => await _emailService.SendTeamInvitationEmailAsync(
                toEmail, teamName, invitedByName, role, token, expiresAt);

            // Assert
            await act.Should().NotThrowAsync();
        }

        #endregion

        #region SendTaskStatusUpdateEmailAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task SendTaskStatusUpdateEmailAsync_WhenDisabled_ShouldNotThrow()
        {
            // Arrange
            var toEmail = "user@test.com";
            var toName = "Test User";
            var taskName = "Test Task";
            var projectName = "Test Project";
            var oldStatus = "Pending";
            var newStatus = "InProgress";

            // Act
            var act = async () => await _emailService.SendTaskStatusUpdateEmailAsync(
                toEmail, toName, taskName, projectName, oldStatus, newStatus);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Theory]
        [InlineData("Pending", "InProgress")]
        [InlineData("InProgress", "Completed")]
        [InlineData("Pending", "Blocked")]
        [InlineData("InProgress", "Cancelled")]
        public async System.Threading.Tasks.Task SendTaskStatusUpdateEmailAsync_WithVariousStatuses_ShouldNotThrow(
            string oldStatus, string newStatus)
        {
            // Arrange
            var toEmail = "user@test.com";
            var toName = "Test User";
            var taskName = "Test Task";
            var projectName = "Test Project";

            // Act
            var act = async () => await _emailService.SendTaskStatusUpdateEmailAsync(
                toEmail, toName, taskName, projectName, oldStatus, newStatus);

            // Assert
            await act.Should().NotThrowAsync();
        }

        #endregion

        #region SendEmailAsync Tests

        [Fact]
        public async System.Threading.Tasks.Task SendEmailAsync_WhenDisabled_ShouldNotThrow()
        {
            // Arrange
            var toEmail = "user@test.com";
            var subject = "Test Subject";
            var htmlBody = "<html><body>Test</body></html>";

            // Act
            var act = async () => await _emailService.SendEmailAsync(toEmail, subject, htmlBody);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async System.Threading.Tasks.Task SendEmailAsync_WithEmptyCredentials_ShouldNotThrow()
        {
            // Arrange - Create service with empty credentials
            var mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(c => c["Email:Enabled"]).Returns("true");
            mockConfig.Setup(c => c["Email:Username"]).Returns("");
            mockConfig.Setup(c => c["Email:Password"]).Returns("");
            
            var service = new EmailService(mockConfig.Object);

            // Act
            var act = async () => await service.SendEmailAsync("test@test.com", "Subject", "Body");

            // Assert
            await act.Should().NotThrowAsync();
        }

        #endregion

        #region Configuration Tests

        [Fact]
        public void EmailService_WithDefaultConfiguration_ShouldInitialize()
        {
            // Arrange
            var mockConfig = new Mock<IConfiguration>();
            // No configuration values set - should use defaults

            // Act
            var service = new EmailService(mockConfig.Object);

            // Assert
            service.Should().NotBeNull();
        }

        [Fact]
        public void EmailService_WithCustomConfiguration_ShouldInitialize()
        {
            // Arrange
            var mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(c => c["Email:SmtpHost"]).Returns("custom.smtp.com");
            mockConfig.Setup(c => c["Email:SmtpPort"]).Returns("465");
            mockConfig.Setup(c => c["Email:EnableSsl"]).Returns("false");
            mockConfig.Setup(c => c["Email:Enabled"]).Returns("true");

            // Act
            var service = new EmailService(mockConfig.Object);

            // Assert
            service.Should().NotBeNull();
        }

        #endregion
    }
}
