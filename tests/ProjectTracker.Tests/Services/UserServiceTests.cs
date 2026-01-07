using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Services;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Interfaces;
using System.Linq.Expressions;
using SystemTask = System.Threading.Tasks.Task;

namespace ProjectTracker.Tests.Services
{
    /// <summary>
    /// UserService Unit Tests
    /// </summary>
    public class UserServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IValidator<LoginDto>> _mockLoginValidator;
        private readonly Mock<IValidator<RegisterDto>> _mockRegisterValidator;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _mockLoginValidator = new Mock<IValidator<LoginDto>>();
            _mockRegisterValidator = new Mock<IValidator<RegisterDto>>();

            _userService = new UserService(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockLoginValidator.Object,
                _mockRegisterValidator.Object
            );
        }

        #region Login Tests

        [Fact]
        public async System.Threading.Tasks.Task LoginAsync_ValidCredentials_ReturnsUserDto()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "testuser", Password = "password123" };
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("password123");
            var user = new User
            {
                UserId = 1,
                Username = "testuser",
                PasswordHash = hashedPassword,
                FullName = "Test User",
                Email = "test@test.com",
                IsActive = true,
                RoleId = 3
            };
            var expectedUserDto = new UserDto
            {
                UserId = 1,
                Username = "testuser",
                FullName = "Test User",
                Email = "test@test.com"
            };

            _mockLoginValidator.Setup(v => v.ValidateAsync(loginDto, default))
                .ReturnsAsync(new ValidationResult());

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            _mockMapper.Setup(m => m.Map<UserDto>(user))
                .Returns(expectedUserDto);

            // Act
            var result = await _userService.LoginAsync(loginDto);

            // Assert
            result.Should().NotBeNull();
            result!.Username.Should().Be("testuser");
            result.UserId.Should().Be(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task LoginAsync_InvalidUsername_ReturnsNull()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "nonexistent", Password = "password123" };

            _mockLoginValidator.Setup(v => v.ValidateAsync(loginDto, default))
                .ReturnsAsync(new ValidationResult());

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _userService.LoginAsync(loginDto);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task LoginAsync_InvalidPassword_ReturnsNull()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "testuser", Password = "wrongpassword" };
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("correctpassword");
            var user = new User
            {
                UserId = 1,
                Username = "testuser",
                PasswordHash = hashedPassword,
                IsActive = true
            };

            _mockLoginValidator.Setup(v => v.ValidateAsync(loginDto, default))
                .ReturnsAsync(new ValidationResult());

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.LoginAsync(loginDto);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task LoginAsync_InactiveUser_ReturnsNull()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "testuser", Password = "password123" };
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword("password123");
            var user = new User
            {
                UserId = 1,
                Username = "testuser",
                PasswordHash = hashedPassword,
                IsActive = false // Inactive user
            };

            _mockLoginValidator.Setup(v => v.ValidateAsync(loginDto, default))
                .ReturnsAsync(new ValidationResult());

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.LoginAsync(loginDto);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task LoginAsync_ValidationFails_ThrowsValidationException()
        {
            // Arrange
            var loginDto = new LoginDto { Username = "", Password = "" };
            var validationFailures = new List<ValidationFailure>
            {
                new ValidationFailure("Username", "Username is required"),
                new ValidationFailure("Password", "Password is required")
            };

            _mockLoginValidator.Setup(v => v.ValidateAsync(loginDto, default))
                .ReturnsAsync(new ValidationResult(validationFailures));

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _userService.LoginAsync(loginDto));
        }

        #endregion

        #region GetUser Tests

        [Fact]
        public async System.Threading.Tasks.Task GetUserByIdAsync_ExistingUser_ReturnsUserDto()
        {
            // Arrange
            var user = new User { UserId = 1, Username = "testuser", FullName = "Test User" };
            var expectedDto = new UserDto { UserId = 1, Username = "testuser", FullName = "Test User" };

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(user);

            _mockMapper.Setup(m => m.Map<UserDto>(user))
                .Returns(expectedDto);

            // Act
            var result = await _userService.GetUserByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result!.UserId.Should().Be(1);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetUserByIdAsync_NonExistingUser_ReturnsNull()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(999))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _userService.GetUserByIdAsync(999);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async System.Threading.Tasks.Task GetAllUsersAsync_ReturnsAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { UserId = 1, Username = "user1" },
                new User { UserId = 2, Username = "user2" }
            };
            var expectedDtos = new List<UserDto>
            {
                new UserDto { UserId = 1, Username = "user1" },
                new UserDto { UserId = 2, Username = "user2" }
            };

            _mockUnitOfWork.Setup(u => u.Users.GetAllAsync())
                .ReturnsAsync(users);

            _mockMapper.Setup(m => m.Map<IEnumerable<UserDto>>(users))
                .Returns(expectedDtos);

            // Act
            var result = await _userService.GetAllUsersAsync();

            // Assert
            result.Should().HaveCount(2);
        }

        #endregion

        #region Username/Email Exists Tests

        [Fact]
        public async System.Threading.Tasks.Task UsernameExistsAsync_ExistingUsername_ReturnsTrue()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Users.AnyAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(true);

            // Act
            var result = await _userService.UsernameExistsAsync("existinguser");

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async System.Threading.Tasks.Task UsernameExistsAsync_NonExistingUsername_ReturnsFalse()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Users.AnyAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(false);

            // Act
            var result = await _userService.UsernameExistsAsync("newuser");

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async System.Threading.Tasks.Task EmailExistsAsync_ExistingEmail_ReturnsTrue()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Users.AnyAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(true);

            // Act
            var result = await _userService.EmailExistsAsync("existing@test.com");

            // Assert
            result.Should().BeTrue();
        }

        #endregion

        #region Register Tests

        [Fact]
        public async System.Threading.Tasks.Task RegisterAsync_ValidData_CreatesUser()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                Username = "newuser",
                FullName = "New User",
                Email = "new@test.com",
                Password = "password123"
            };

            var expectedUserDto = new UserDto
            {
                UserId = 1,
                Username = "newuser",
                FullName = "New User",
                Email = "new@test.com",
                RoleId = 4 // Pending
            };

            _mockRegisterValidator.Setup(v => v.ValidateAsync(registerDto, default))
                .ReturnsAsync(new ValidationResult());

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((User?)null);

            _mockUnitOfWork.Setup(u => u.TeamInvitations.FirstOrDefaultAsync(It.IsAny<Expression<Func<TeamInvitation, bool>>>()))
                .ReturnsAsync((TeamInvitation?)null);

            _mockUnitOfWork.Setup(u => u.Users.AddAsync(It.IsAny<User>())).ReturnsAsync((User u) => u);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            _mockMapper.Setup(m => m.Map<UserDto>(It.IsAny<User>()))
                .Returns(expectedUserDto);

            // Act
            var result = await _userService.RegisterAsync(registerDto);

            // Assert
            result.Should().NotBeNull();
            result.Username.Should().Be("newuser");
            result.RoleId.Should().Be(4); // Pending role
        }

        [Fact]
        public async System.Threading.Tasks.Task RegisterAsync_DuplicateUsername_ThrowsException()
        {
            // Arrange
            var registerDto = new RegisterDto
            {
                Username = "existinguser",
                FullName = "Test",
                Email = "new@test.com",
                Password = "password123"
            };

            var existingUser = new User { UserId = 1, Username = "existinguser" };

            _mockRegisterValidator.Setup(v => v.ValidateAsync(registerDto, default))
                .ReturnsAsync(new ValidationResult());

            _mockUnitOfWork.Setup(u => u.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(existingUser);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _userService.RegisterAsync(registerDto));
        }

        #endregion

        #region Deactivate Tests

        [Fact]
        public async System.Threading.Tasks.Task DeactivateUserAsync_ExistingUser_ReturnsTrue()
        {
            // Arrange
            var user = new User { UserId = 1, IsActive = true };

            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
                .ReturnsAsync(user);

            _mockUnitOfWork.Setup(u => u.SaveChangesAsync())
                .ReturnsAsync(1);

            // Act
            var result = await _userService.DeactivateUserAsync(1);

            // Assert
            result.Should().BeTrue();
            user.IsActive.Should().BeFalse();
        }

        [Fact]
        public async System.Threading.Tasks.Task DeactivateUserAsync_NonExistingUser_ReturnsFalse()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(999))
                .ReturnsAsync((User?)null);

            // Act
            var result = await _userService.DeactivateUserAsync(999);

            // Assert
            result.Should().BeFalse();
        }

        #endregion
    }
}


