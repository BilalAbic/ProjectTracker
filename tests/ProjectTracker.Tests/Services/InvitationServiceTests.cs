using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;
using ProjectTracker.Core.Interfaces;
using System.Linq.Expressions;
using SystemTask = System.Threading.Tasks.Task;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// InvitationService Unit Tests
    /// </summary>
    public class InvitationServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;
        private readonly Mock<IEmailService> _mockEmailService;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly InvitationService _invitationService;

        public InvitationServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _mockEmailService = new Mock<IEmailService>();
            _mockConfiguration = new Mock<IConfiguration>();

            _mockCurrentUserService.Setup(c => c.CurrentUserId).Returns(1);
            _mockCurrentUserService.Setup(c => c.IsAdmin).Returns(false);

            // Setup configuration
            _mockConfiguration.Setup(c => c["RemoteApi:BaseUrl"]).Returns("https://test.com/api");

            _invitationService = new InvitationService(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockCurrentUserService.Object,
                _mockEmailService.Object,
                _mockConfiguration.Object
            );
        }

        #region SendInvitation Tests

        [Fact]
        public async System.Threading.Tasks.Task SendInvitationAsync_ValidRequest_CreatesInvitation()
        {
            // Arrange
            var invitationDto = new TeamInvitationDto
            {
                TeamId = 1,
                Email = "newuser@test.com",
                ProposedRole = TeamRole.Developer
            };

            var ownerMember = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Owner,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(ownerMember);

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((User?)null);

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync((TeamInvitation?)null);

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(new Team { TeamId = 1, TeamName = "Test Team" });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Inviter" });

            _mockUnitOfWork.Setup(u => u.TeamInvitations.AddAsync(It.IsAny<TeamInvitation>())).ReturnsAsync((TeamInvitation ti) => ti);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _invitationService.SendInvitationAsync(invitationDto);

            // Assert
            result.Should().NotBeNull();
            _mockUnitOfWork.Verify(u => u.TeamInvitations.AddAsync(It.IsAny<TeamInvitation>()), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task SendInvitationAsync_NoPermission_ThrowsUnauthorized()
        {
            // Arrange
            var invitationDto = new TeamInvitationDto
            {
                TeamId = 1,
                Email = "newuser@test.com",
                ProposedRole = TeamRole.Developer
            };

            var memberWithNoPermission = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Developer,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(memberWithNoPermission);

            // Act & Assert
            await Assert.ThrowsAsync<UnauthorizedAccessException>(
                () => _invitationService.SendInvitationAsync(invitationDto));
        }

        [Fact]
        public async System.Threading.Tasks.Task SendInvitationAsync_UserAlreadyMember_ThrowsException()
        {
            // Arrange
            var invitationDto = new TeamInvitationDto
            {
                TeamId = 1,
                Email = "existing@test.com",
                ProposedRole = TeamRole.Developer
            };

            var ownerMember = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Owner,
                IsActive = true
            };

            var existingUser = new User { UserId = 2, Email = "existing@test.com" };
            var existingMember = new TeamMember { TeamMemberId = 2, TeamId = 1, UserId = 2, IsActive = true };

            _mockUnitOfWork.SetupSequence(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(ownerMember)
                .ReturnsAsync(existingMember);

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(existingUser);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _invitationService.SendInvitationAsync(invitationDto));
        }

        [Fact]
        public async System.Threading.Tasks.Task SendInvitationAsync_PendingInvitationExists_ThrowsException()
        {
            // Arrange
            var invitationDto = new TeamInvitationDto
            {
                TeamId = 1,
                Email = "pending@test.com",
                ProposedRole = TeamRole.Developer
            };

            var ownerMember = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Owner,
                IsActive = true
            };

            var pendingInvitation = new TeamInvitation
            {
                InvitationId = 1,
                TeamId = 1,
                Email = "pending@test.com",
                Status = InvitationStatus.Pending,
                ExpiresAt = DateTime.Now.AddDays(7)
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(ownerMember);

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((User?)null);

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync(pendingInvitation);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _invitationService.SendInvitationAsync(invitationDto));
        }

        #endregion

        #region AcceptInvitation Tests

        [Fact]
        public async System.Threading.Tasks.Task AcceptInvitationAsync_ValidToken_AcceptsInvitation()
        {
            // Arrange
            var invitation = new TeamInvitation
            {
                InvitationId = 1,
                TeamId = 1,
                Email = "user@test.com",
                Token = "valid-token",
                Status = InvitationStatus.Pending,
                ProposedRole = TeamRole.Developer,
                ExpiresAt = DateTime.Now.AddDays(7)
            };

            var user = new User { UserId = 2, Email = "user@test.com" };

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync(invitation);

            _mockUnitOfWork.Setup(u => u.TeamInvitations.GetByIdAsync(1))
                .ReturnsAsync(invitation);

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            _mockUnitOfWork.SetupSequence(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync((TeamMember?)null);

            _mockUnitOfWork.Setup(u => u.TeamMembers.AddAsync(It.IsAny<TeamMember>())).ReturnsAsync((TeamMember tm) => tm);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _invitationService.AcceptInvitationAsync("valid-token");

            // Assert
            result.Should().BeTrue();
            invitation.Status.Should().Be(InvitationStatus.Accepted);
            _mockUnitOfWork.Verify(u => u.TeamMembers.AddAsync(It.IsAny<TeamMember>()), Times.Once);
        }

        [Fact]
        public async System.Threading.Tasks.Task AcceptInvitationAsync_InvalidToken_ThrowsException()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync((TeamInvitation?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _invitationService.AcceptInvitationAsync("invalid-token"));
        }

        [Fact]
        public async System.Threading.Tasks.Task AcceptInvitationAsync_ExpiredInvitation_ThrowsException()
        {
            // Arrange
            var expiredInvitation = new TeamInvitation
            {
                InvitationId = 1,
                TeamId = 1,
                Email = "user@test.com",
                Status = InvitationStatus.Pending,
                ExpiresAt = DateTime.Now.AddDays(-1) // Expired
            };

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync(expiredInvitation);

            _mockUnitOfWork.Setup(u => u.TeamInvitations.GetByIdAsync(1))
                .ReturnsAsync(expiredInvitation);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _invitationService.AcceptInvitationAsync("expired-token"));
        }

        [Fact]
        public async System.Threading.Tasks.Task AcceptInvitationAsync_UserNotRegistered_ThrowsException()
        {
            // Arrange
            var invitation = new TeamInvitation
            {
                InvitationId = 1,
                TeamId = 1,
                Email = "unregistered@test.com",
                Status = InvitationStatus.Pending,
                ExpiresAt = DateTime.Now.AddDays(7)
            };

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync(invitation);

            _mockUnitOfWork.Setup(u => u.TeamInvitations.GetByIdAsync(1))
                .ReturnsAsync(invitation);

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((User?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _invitationService.AcceptInvitationAsync("token"));
        }

        #endregion

        #region DeclineInvitation Tests

        [Fact]
        public async System.Threading.Tasks.Task DeclineInvitationAsync_ValidToken_DeclinesInvitation()
        {
            // Arrange
            var invitation = new TeamInvitation
            {
                InvitationId = 1,
                TeamId = 1,
                Email = "user@test.com",
                Token = "valid-token",
                Status = InvitationStatus.Pending,
                ExpiresAt = DateTime.Now.AddDays(7)
            };

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync(invitation);

            _mockUnitOfWork.Setup(u => u.TeamInvitations.GetByIdAsync(1))
                .ReturnsAsync(invitation);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _invitationService.DeclineInvitationAsync("valid-token");

            // Assert
            result.Should().BeTrue();
            invitation.Status.Should().Be(InvitationStatus.Declined);
        }

        [Fact]
        public async System.Threading.Tasks.Task DeclineInvitationAsync_AlreadyAccepted_ThrowsException()
        {
            // Arrange
            var acceptedInvitation = new TeamInvitation
            {
                InvitationId = 1,
                TeamId = 1,
                Email = "user@test.com",
                Status = InvitationStatus.Accepted
            };

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync(acceptedInvitation);

            _mockUnitOfWork.Setup(u => u.TeamInvitations.GetByIdAsync(1))
                .ReturnsAsync(acceptedInvitation);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _invitationService.DeclineInvitationAsync("token"));
        }

        #endregion

        #region CancelInvitation Tests

        [Fact]
        public async System.Threading.Tasks.Task CancelInvitationAsync_ValidRequest_CancelsInvitation()
        {
            // Arrange
            var invitation = new TeamInvitation
            {
                InvitationId = 1,
                TeamId = 1,
                Email = "user@test.com",
                Status = InvitationStatus.Pending
            };

            var ownerMember = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Owner,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.TeamInvitations.GetByIdAsync(1))
                .ReturnsAsync(invitation);

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(ownerMember);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _invitationService.CancelInvitationAsync(1);

            // Assert
            result.Should().BeTrue();
            invitation.Status.Should().Be(InvitationStatus.Cancelled);
        }

        [Fact]
        public async System.Threading.Tasks.Task CancelInvitationAsync_NonExisting_ReturnsFalse()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.TeamInvitations.GetByIdAsync(999))
                .ReturnsAsync((TeamInvitation?)null);

            // Act
            var result = await _invitationService.CancelInvitationAsync(999);

            // Assert
            result.Should().BeFalse();
        }

        #endregion

        #region GetInvitations Tests

        [Fact]
        public async System.Threading.Tasks.Task GetTeamInvitationsAsync_ReturnsInvitations()
        {
            // Arrange
            var invitations = new List<TeamInvitation>
            {
                new() { InvitationId = 1, TeamId = 1, Email = "user1@test.com", InvitedByUserId = 1 },
                new() { InvitationId = 2, TeamId = 1, Email = "user2@test.com", InvitedByUserId = 1 }
            };

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FindAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync(invitations);

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(new Team { TeamId = 1, TeamName = "Test Team" });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Inviter" });

            // Act
            var result = await _invitationService.GetTeamInvitationsAsync(1);

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetUserPendingInvitationsAsync_ReturnsPendingInvitations()
        {
            // Arrange
            var invitations = new List<TeamInvitation>
            {
                new() { InvitationId = 1, TeamId = 1, Email = "user@test.com", Status = InvitationStatus.Pending, InvitedByUserId = 1, SentAt = DateTime.Now }
            };

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FindAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync(invitations);

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(new Team { TeamId = 1, TeamName = "Test Team" });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Inviter" });

            // Act
            var result = await _invitationService.GetUserPendingInvitationsAsync("user@test.com");

            // Assert
            result.Should().HaveCount(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetByTokenAsync_ValidToken_ReturnsInvitation()
        {
            // Arrange
            var invitation = new TeamInvitation
            {
                InvitationId = 1,
                TeamId = 1,
                Email = "user@test.com",
                Token = "valid-token",
                InvitedByUserId = 1
            };

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync(invitation);

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(new Team { TeamId = 1, TeamName = "Test Team" });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Inviter" });

            // Act
            var result = await _invitationService.GetByTokenAsync("valid-token");

            // Assert
            result.Should().NotBeNull();
            result!.Token.Should().Be("valid-token");
        }

        [Fact]
        public async System.Threading.Tasks.Task GetByTokenAsync_InvalidToken_ReturnsNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync((TeamInvitation?)null);

            // Act
            var result = await _invitationService.GetByTokenAsync("invalid-token");

            // Assert
            result.Should().BeNull();
        }

        #endregion
    }
}



