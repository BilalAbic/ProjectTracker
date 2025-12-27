using AutoMapper;
using FluentValidation;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Core.Entities;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core;
using ProjectTracker.Core.Interfaces;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// User service implementation - handles user business logic
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<LoginDto> _loginValidator;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<LoginDto> loginValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loginValidator = loginValidator;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        public async Task<UserDto?> LoginAsync(LoginDto loginDto)
        {
            // Validate input
            var validationResult = await _loginValidator.ValidateAsync(loginDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Find user by username
            var user = await _unitOfWork.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);

            if (user == null)
                return null;

            // Verify password (simple comparison for MVP - in production use BCrypt/PBKDF2)
            // TODO: Implement proper password hashing
            if (user.PasswordHash != loginDto.Password) // TEMPORARY - should be hashed
                return null;

            // Check if user is active
            if (!user.IsActive)
                return null;

            // Map to DTO and return
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        public async Task<UserDto?> GetUserByIdAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                return null;

            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        /// <summary>
        /// Get all active users
        /// </summary>
        public async Task<IEnumerable<UserDto>> GetActiveUsersAsync()
        {
            var users = await _unitOfWork.Users.FindAsync(u => u.IsActive);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        public async Task<UserDto> CreateUserAsync(UserDto userDto, string password)
        {
            // Check if username exists
            if (await UsernameExistsAsync(userDto.Username))
            {
                throw new InvalidOperationException("Username already exists");
            }

            // Check if email exists
            if (await EmailExistsAsync(userDto.Email))
            {
                throw new InvalidOperationException("Email already exists");
            }

            // Map DTO to Entity
            var user = _mapper.Map<User>(userDto);

            // Hash password (simple for MVP - use BCrypt in production)
            // TODO: Implement proper password hashing
            user.PasswordHash = password; // TEMPORARY

            user.CreatedAt = DateTime.Now;
            user.IsActive = true;

            // Add to repository
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            // Return DTO
            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// Update user
        /// </summary>
        public async Task<UserDto> UpdateUserAsync(UserDto userDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userDto.UserId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            // Update properties
            user.FullName = userDto.FullName;
            user.Email = userDto.Email;
            user.RoleId = userDto.RoleId;
            user.IsActive = userDto.IsActive;

            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// Deactivate user (soft delete)
        /// </summary>
        public async Task<bool> DeactivateUserAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                return false;

            user.IsActive = false;
            _unitOfWork.Users.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Check if username exists
        /// </summary>
        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _unitOfWork.Users.AnyAsync(u => u.Username == username);
        }

        /// <summary>
        /// Check if email exists
        /// </summary>
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _unitOfWork.Users.AnyAsync(u => u.Email == email);
        }
    }
}