using AutoMapper;
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
    /// TeamService Unit Tests
    /// </summary>
    public class TeamServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ICurrentUserService> _mockCurrentUserService;
        private readonly Mock<IAuditLogService> _mockAuditLogService;
        private readonly TeamService _teamService;

        public TeamServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockCurrentUserService = new Mock<ICurrentUserService>();
            _mockAuditLogService = new Mock<IAuditLogService>();

            _mockCurrentUserService.Setup(c => c.CurrentUserId).Returns(1);

            _teamService = new TeamService(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockCurrentUserService.Object,
                _mockAuditLogService.Object
            );
        }

        #region GetTeam Tests

        [Fact]
        public async System.Threading.Tasks.Task GetTeamByIdAsync_ExistingTeam_ReturnsTeamDto()
        {
            // Arrange
            var team = new Team
            {
                TeamId = 1,
                TeamName = "Test Team",
                OwnerId = 1,
                IsActive = true
            };

            var owner = new User { UserId = 1, FullName = "Owner" };

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(team);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(owner);

            _mockUnitOfWork.Setup(u => u.TeamMembers.CountAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(3);

            _mockUnitOfWork.Setup(u => u.Projects.CountAsync(It.IsAny<Expression<Func<Project, bool>>>()))
                .ReturnsAsync(2);

            // Act
            var result = await _teamService.GetTeamByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result!.TeamId.Should().Be(1);
            result.TeamName.Should().Be("Test Team");
            result.MemberCount.Should().Be(3);
            result.ProjectCount.Should().Be(2);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetTeamByIdAsync_NonExistingTeam_ReturnsNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(999))
                .ReturnsAsync((Team?)null);

            // Act
            var result = await _teamService.GetTeamByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAllTeamsAsync_ReturnsAllActiveTeams()
        {
            // Arrange
            var teams = new List<Team>
            {
                new() { TeamId = 1, TeamName = "Team 1", OwnerId = 1, IsActive = true },
                new() { TeamId = 2, TeamName = "Team 2", OwnerId = 1, IsActive = true }
            };

            _mockUnitOfWork.Setup(u => u.Teams.FindAsync(It.IsAny<Expression<Func<Team, bool>>>()))
                .ReturnsAsync(teams);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new User { UserId = 1, FullName = "Owner" });

            _mockUnitOfWork.Setup(u => u.TeamMembers.CountAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Projects.CountAsync(It.IsAny<Expression<Func<Project, bool>>>()))
                .ReturnsAsync(0);

            // Act
            var result = await _teamService.GetAllTeamsAsync();

            // Assert
            result.Should().HaveCount(2);
        }

        #endregion

        #region CreateTeam Tests

        [Fact]
        public async System.Threading.Tasks.Task CreateTeamAsync_ValidDto_CreatesTeam()
        {
            // Arrange
            var createDto = new CreateTeamDto
            {
                TeamName = "New Team",
                Description = "Test Description"
            };

            _mockUnitOfWork.Setup(u => u.Teams.AddAsync(It.IsAny<Team>())).ReturnsAsync((Team t) => { t.TeamId = 1; return t; });

            _mockUnitOfWork.Setup(u => u.TeamMembers.AddAsync(It.IsAny<TeamMember>())).ReturnsAsync((TeamMember tm) => tm);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(new Team { TeamId = 1, TeamName = "New Team", OwnerId = 1, IsActive = true });

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Owner" });

            _mockUnitOfWork.Setup(u => u.TeamMembers.CountAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Projects.CountAsync(It.IsAny<Expression<Func<Project, bool>>>()))
                .ReturnsAsync(0);

            // Act
            var result = await _teamService.CreateTeamAsync(createDto);

            // Assert
            result.Should().NotBeNull();
            _mockUnitOfWork.Verify(u => u.Teams.AddAsync(It.IsAny<Team>()), Times.Once);
            _mockUnitOfWork.Verify(u => u.TeamMembers.AddAsync(It.IsAny<TeamMember>()), Times.Once);
        }

        #endregion

        #region UpdateTeam Tests

        [Fact]
        public async System.Threading.Tasks.Task UpdateTeamAsync_ExistingTeam_UpdatesTeam()
        {
            // Arrange
            var existingTeam = new Team
            {
                TeamId = 1,
                TeamName = "Old Name",
                OwnerId = 1,
                IsActive = true
            };

            var updateDto = new UpdateTeamDto
            {
                TeamId = 1,
                TeamName = "Updated Name",
                Description = "Updated Description"
            };

            var ownerMember = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Owner,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(existingTeam);

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(ownerMember);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(new User { UserId = 1, FullName = "Owner" });

            _mockUnitOfWork.Setup(u => u.TeamMembers.CountAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(u => u.Projects.CountAsync(It.IsAny<Expression<Func<Project, bool>>>()))
                .ReturnsAsync(0);

            // Act
            var result = await _teamService.UpdateTeamAsync(updateDto);

            // Assert
            result.Should().NotBeNull();
            existingTeam.TeamName.Should().Be("Updated Name");
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateTeamAsync_NonExistingTeam_ThrowsException()
        {
            // Arrange
            var updateDto = new UpdateTeamDto { TeamId = 999, TeamName = "Test" };

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(999))
                .ReturnsAsync((Team?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _teamService.UpdateTeamAsync(updateDto));
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateTeamAsync_NoPermission_ThrowsUnauthorized()
        {
            // Arrange
            var existingTeam = new Team { TeamId = 1, TeamName = "Team", OwnerId = 2, IsActive = true };
            var updateDto = new UpdateTeamDto { TeamId = 1, TeamName = "Updated" };

            var memberWithNoPermission = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Developer,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(existingTeam);

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(memberWithNoPermission);

            // Act & Assert
            await Assert.ThrowsAsync<UnauthorizedAccessException>(
                () => _teamService.UpdateTeamAsync(updateDto));
        }

        #endregion

        #region DeleteTeam Tests

        [Fact]
        public async System.Threading.Tasks.Task DeleteTeamAsync_OwnerDeletes_ReturnsTrue()
        {
            // Arrange
            var team = new Team { TeamId = 1, TeamName = "Test", OwnerId = 1, IsActive = true };

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(team);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _teamService.DeleteTeamAsync(1);

            // Assert
            result.Should().BeTrue();
            team.IsActive.Should().BeFalse();
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteTeamAsync_NonOwner_ThrowsUnauthorized()
        {
            // Arrange
            var team = new Team { TeamId = 1, TeamName = "Test", OwnerId = 2, IsActive = true };

            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(1))
                .ReturnsAsync(team);

            // Act & Assert
            await Assert.ThrowsAsync<UnauthorizedAccessException>(
                () => _teamService.DeleteTeamAsync(1));
        }

        [Fact]
        public async System.Threading.Tasks.Task DeleteTeamAsync_NonExistingTeam_ReturnsFalse()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Teams.GetByIdAsync(999))
                .ReturnsAsync((Team?)null);

            // Act
            var result = await _teamService.DeleteTeamAsync(999);

            // Assert
            result.Should().BeFalse();
        }

        #endregion

        #region TeamMember Tests

        [Fact]
        public async System.Threading.Tasks.Task GetTeamMembersAsync_ReturnsMembers()
        {
            // Arrange
            var members = new List<TeamMember>
            {
                new() { TeamMemberId = 1, TeamId = 1, UserId = 1, Role = TeamRole.Owner, IsActive = true },
                new() { TeamMemberId = 2, TeamId = 1, UserId = 2, Role = TeamRole.Developer, IsActive = true }
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.FindAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(members);

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => new User { UserId = id, FullName = $"User {id}", Email = $"user{id}@test.com" });

            // Act
            var result = await _teamService.GetTeamMembersAsync(1);

            // Assert
            result.Should().HaveCount(2);
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateMemberRoleAsync_ValidRequest_UpdatesRole()
        {
            // Arrange
            var member = new TeamMember
            {
                TeamMemberId = 2,
                TeamId = 1,
                UserId = 2,
                Role = TeamRole.Developer,
                IsActive = true
            };

            var currentUserMember = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Owner,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.GetByIdAsync(2))
                .ReturnsAsync(member);

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(currentUserMember);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _teamService.UpdateMemberRoleAsync(2, TeamRole.Admin);

            // Assert
            result.Should().BeTrue();
            member.Role.Should().Be(TeamRole.Admin);
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateMemberRoleAsync_OwnerRole_ThrowsException()
        {
            // Arrange
            var ownerMember = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Owner,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.GetByIdAsync(1))
                .ReturnsAsync(ownerMember);

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(ownerMember);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _teamService.UpdateMemberRoleAsync(1, TeamRole.Admin));
        }

        [Fact]
        public async System.Threading.Tasks.Task RemoveMemberAsync_ValidRequest_RemovesMember()
        {
            // Arrange
            var member = new TeamMember
            {
                TeamMemberId = 2,
                TeamId = 1,
                UserId = 2,
                Role = TeamRole.Developer,
                IsActive = true
            };

            var currentUserMember = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Owner,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.GetByIdAsync(2))
                .ReturnsAsync(member);

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(currentUserMember);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _teamService.RemoveMemberAsync(2);

            // Assert
            result.Should().BeTrue();
            member.IsActive.Should().BeFalse();
        }

        [Fact]
        public async System.Threading.Tasks.Task RemoveMemberAsync_OwnerMember_ThrowsException()
        {
            // Arrange
            var ownerMember = new TeamMember
            {
                TeamMemberId = 1,
                TeamId = 1,
                UserId = 1,
                Role = TeamRole.Owner,
                IsActive = true
            };

            _mockUnitOfWork.Setup(u => u.TeamMembers.GetByIdAsync(1))
                .ReturnsAsync(ownerMember);

            _mockUnitOfWork.Setup(u => u.TeamMembers.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamMember, bool>>>()))
                .ReturnsAsync(ownerMember);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _teamService.RemoveMemberAsync(1));
        }

        #endregion
    }
}



