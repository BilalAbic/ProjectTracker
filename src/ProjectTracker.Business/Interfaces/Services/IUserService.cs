using ProjectTracker.Business.DTOs;

namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// User service interface - manages user operations
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticate user with username and password
        /// </summary>
        Task<UserDto?> LoginAsync(LoginDto loginDto);

        /// <summary>
        /// Get user by ID
        /// </summary>
        Task<UserDto?> GetUserByIdAsync(int userId);

        /// <summary>
        /// Get all users
        /// </summary>
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        /// <summary>
        /// Get all active users
        /// </summary>
        Task<IEnumerable<UserDto>> GetActiveUsersAsync();

        /// <summary>
        /// Create a new user
        /// </summary>
        Task<UserDto> CreateUserAsync(UserDto userDto, string password);

        /// <summary>
        /// Update existing user
        /// </summary>
        Task<UserDto> UpdateUserAsync(UserDto userDto);

        /// <summary>
        /// Deactivate user (soft delete)
        /// </summary>
        Task<bool> DeactivateUserAsync(int userId);

        /// <summary>
        /// Check if username exists
        /// </summary>
        Task<bool> UsernameExistsAsync(string username);

        /// <summary>
        /// Check if email exists
        /// </summary>
        Task<bool> EmailExistsAsync(string email);

        /// <summary>
        /// Register a new user
        /// </summary>
        Task<UserDto> RegisterAsync(RegisterDto registerDto);

        /// <summary>
        /// Get all roles
        /// </summary>
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    }
}