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
        private readonly IValidator<RegisterDto> _registerValidator;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<LoginDto> loginValidator,
            IValidator<RegisterDto> registerValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
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
            {
                System.Diagnostics.Debug.WriteLine($"❌ LOGIN: User '{loginDto.Username}' not found");
                return null;
            }

            System.Diagnostics.Debug.WriteLine($"✅ LOGIN: User found - Id:{user.UserId}, Username:{user.Username}");
            System.Diagnostics.Debug.WriteLine($"📝 LOGIN: Password Hash: {user.PasswordHash.Substring(0, 20)}...");
            System.Diagnostics.Debug.WriteLine($"🔑 LOGIN: Input Password: {loginDto.Password}");

            // TEMPORARY: Use plain text for testing (replace hash with "admin123" in DB)
            bool isValidPassword = false;
            
            // Try BCrypt first
            try
            {
                if (user.PasswordHash.StartsWith("$2a$") || user.PasswordHash.StartsWith("$2b$"))
                {
                    System.Diagnostics.Debug.WriteLine($"🔐 LOGIN: Attempting BCrypt verification...");
                    isValidPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
                    System.Diagnostics.Debug.WriteLine($"🔐 LOGIN: BCrypt result: {isValidPassword}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"⚠️  LOGIN: Using plain text comparison (hash doesn't start with $2a$ or $2b$)");
                    // Plain text comparison (TEMPORARY - NOT SECURE!)
                    isValidPassword = user.PasswordHash == loginDto.Password;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ LOGIN: BCrypt exception: {ex.Message}");
                // Fallback to plain text
                isValidPassword = user.PasswordHash == loginDto.Password;
            }
            
            if (!isValidPassword)
            {
                System.Diagnostics.Debug.WriteLine($"❌ LOGIN: Invalid password");
                return null;
            }

            System.Diagnostics.Debug.WriteLine($"✅ LOGIN: Password valid");

            // Check if user is active
            if (!user.IsActive)
            {
                System.Diagnostics.Debug.WriteLine($"❌ LOGIN: User is inactive");
                return null;
            }

            System.Diagnostics.Debug.WriteLine($"✅ LOGIN: User is active - Login successful!");

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

            // Hash password using BCrypt
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

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

        /// <summary>
        /// Register a new user
        /// Handles invitation-based registration and pending user registration
        /// </summary>
        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            // 1. Validate input
            var validationResult = await _registerValidator.ValidateAsync(registerDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // 2. Check username uniqueness
            var existingUser = await _unitOfWork.Users
                .FirstOrDefaultAsync(u => u.Username == registerDto.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            // 3. Check email uniqueness
            existingUser = await _unitOfWork.Users
                .FirstOrDefaultAsync(u => u.Email == registerDto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            // 4. Determine role based on invitation token
            int roleId = 4; // Default: Pending
            Core.Entities.TeamInvitation? invitation = null;
            
            if (!string.IsNullOrEmpty(registerDto.InvitationToken))
            {
                // Check if invitation exists and is valid
                invitation = await _unitOfWork.TeamInvitations
                    .FirstOrDefaultAsync(ti => ti.Token == registerDto.InvitationToken 
                        && ti.Status == Core.Enums.InvitationStatus.Pending
                        && ti.ExpiresAt > DateTime.Now);
                
                if (invitation != null)
                {
                    // Valid invitation - assign Developer role (or based on invitation)
                    roleId = 3; // Developer
                    System.Diagnostics.Debug.WriteLine($"✅ REGISTER: Valid invitation found, assigning Developer role");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"⚠️ REGISTER: Invalid/expired invitation token, assigning Pending role");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"📝 REGISTER: No invitation token, assigning Pending role");
            }

            // 5. Hash password with BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password, 11);

            // 6. Create new user entity
            var user = new User
            {
                Username = registerDto.Username,
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                PasswordHash = hashedPassword,
                RoleId = roleId,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            // 7. Save to database
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            // 8. If invitation was valid, update invitation status and add to team
            if (invitation != null)
            {
                // Add user to team
                var teamMember = new Core.Entities.TeamMember
                {
                    TeamId = invitation.TeamId,
                    UserId = user.UserId,
                    Role = invitation.ProposedRole,
                    JoinedAt = DateTime.Now,
                    IsActive = true
                };
                await _unitOfWork.TeamMembers.AddAsync(teamMember);

                // Update invitation status
                invitation.Status = Core.Enums.InvitationStatus.Accepted;
                invitation.RespondedAt = DateTime.Now;
                _unitOfWork.TeamInvitations.Update(invitation);
                
                await _unitOfWork.SaveChangesAsync();
                System.Diagnostics.Debug.WriteLine($"✅ REGISTER: User added to team {invitation.TeamId}");
            }

            // 9. Return DTO
            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// Get all roles
        /// </summary>
        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _unitOfWork.Roles.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }
    }
}