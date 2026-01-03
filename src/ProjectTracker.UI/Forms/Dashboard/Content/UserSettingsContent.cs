using Octokit;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    /// <summary>
    /// User Settings content - Profile and GitHub token management
    /// </summary>
    public partial class UserSettingsContent : UserControl
    {
        private readonly ITokenPoolService _tokenPoolService;
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private bool _isTokenVisible = false;
        private bool _hasExistingToken = false;
        private int? _existingTokenId = null;

        public UserSettingsContent(
            ITokenPoolService tokenPoolService,
            IUserService userService,
            ICurrentUserService currentUserService)
        {
            _tokenPoolService = tokenPoolService;
            _userService = userService;
            _currentUserService = currentUserService;
            
            InitializeComponent();
            SetupControls();
            SetupEvents();
        }

        private void SetupControls()
        {
            // Email is read-only (cannot be changed)
            txtEmail.Properties.ReadOnly = true;
            txtEmail.Properties.Appearance.ForeColor = ColorPalette.TextMuted;
            txtEmail.Properties.Appearance.Options.UseForeColor = true;
        }

        /// <summary>
        /// Load data when control becomes visible
        /// </summary>
        protected override async void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                await LoadDataAsync();
            }
        }

        #region Events

        private void SetupEvents()
        {
            btnToggleToken.Click += BtnToggleToken_Click;
            btnValidateToken.Click += async (s, e) => await ValidateTokenAsync();
            btnSaveChanges.Click += async (s, e) => await SaveChangesAsync();
        }

        private void BtnToggleToken_Click(object? sender, EventArgs e)
        {
            _isTokenVisible = !_isTokenVisible;
            txtGitHubToken.Properties.UseSystemPasswordChar = !_isTokenVisible;
            btnToggleToken.Text = _isTokenVisible ? "🙈" : "👁️";
        }

        #endregion

        #region Data Operations

        private async Task LoadDataAsync()
        {
            try
            {
                var userId = _currentUserService.CurrentUserId;
                
                // Load user profile
                var user = await _userService.GetUserByIdAsync(userId);
                if (user != null)
                {
                    txtFullName.Text = user.FullName ?? string.Empty;
                    txtEmail.Text = user.Email ?? string.Empty;
                    txtDepartment.Text = user.Department ?? string.Empty;
                    txtGitHubUsername.Text = user.GitHubUsername ?? string.Empty;
                }

                // Load existing token
                var tokens = await _tokenPoolService.GetUserTokensAsync(userId);
                var existingToken = tokens.FirstOrDefault();
                
                if (existingToken != null)
                {
                    _hasExistingToken = true;
                    _existingTokenId = existingToken.GitHubTokenId;
                    txtGitHubToken.Text = "••••••••••••••••••••"; // Masked
                    txtGitHubToken.Properties.ReadOnly = true;
                    
                    UpdateTokenStatus(existingToken.RateLimitRemaining, existingToken.IsActive);
                }
                else
                {
                    _hasExistingToken = false;
                    _existingTokenId = null;
                    txtGitHubToken.Text = string.Empty;
                    txtGitHubToken.Properties.ReadOnly = false;
                    lblTokenStatus.Text = "Token Status: Not configured";
                    lblTokenStatus.Appearance.ForeColor = ColorPalette.TextMuted;
                    lblTokenStatus.Appearance.Options.UseForeColor = true;
                }
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Failed to load settings: {ex.Message}");
            }
        }

        private void UpdateTokenStatus(int rateLimit, bool isActive)
        {
            if (!isActive)
            {
                lblTokenStatus.Text = "Token Status: ❌ Inactive";
                lblTokenStatus.Appearance.ForeColor = ColorPalette.DangerRed;
            }
            else if (rateLimit > 1000)
            {
                lblTokenStatus.Text = $"Token Status: ✅ Valid ({rateLimit:N0}/5,000 remaining)";
                lblTokenStatus.Appearance.ForeColor = ColorPalette.SuccessGreen;
            }
            else if (rateLimit > 100)
            {
                lblTokenStatus.Text = $"Token Status: ⚠️ Low ({rateLimit:N0}/5,000 remaining)";
                lblTokenStatus.Appearance.ForeColor = ColorPalette.WarningOrange;
            }
            else
            {
                lblTokenStatus.Text = $"Token Status: ❌ Rate limited ({rateLimit:N0}/5,000 remaining)";
                lblTokenStatus.Appearance.ForeColor = ColorPalette.DangerRed;
            }
            lblTokenStatus.Appearance.Options.UseForeColor = true;
        }

        private async Task ValidateTokenAsync()
        {
            var token = txtGitHubToken.Text?.Trim();
            
            if (string.IsNullOrEmpty(token) || token.StartsWith("••"))
            {
                // If masked, validate existing token
                if (_hasExistingToken)
                {
                    FormStyleHelper.ShowInfo("Token is already configured. Enter a new token to replace it.");
                    return;
                }
                FormStyleHelper.ShowWarning("Please enter a GitHub token to validate.");
                return;
            }

            // Basic format check
            if (!token.StartsWith("ghp_") && !token.StartsWith("github_pat_"))
            {
                FormStyleHelper.ShowWarning("Invalid token format. Token should start with 'ghp_' or 'github_pat_'.");
                return;
            }

            try
            {
                btnValidateToken.Enabled = false;
                btnValidateToken.Text = "Checking...";

                // Test token with GitHub API
                var client = new GitHubClient(new ProductHeaderValue("ProjectTracker"));
                client.Credentials = new Credentials(token);
                
                var user = await client.User.Current();
                var rateLimit = await client.RateLimit.GetRateLimits();
                
                var remaining = rateLimit.Resources.Core.Remaining;
                
                FormStyleHelper.ShowSuccess($"Token is valid! GitHub user: {user.Login}, API calls remaining: {remaining}");
                UpdateTokenStatus(remaining, true);
                
                // Auto-fill username if empty
                if (string.IsNullOrEmpty(txtGitHubUsername.Text))
                {
                    txtGitHubUsername.Text = user.Login;
                }
            }
            catch (AuthorizationException)
            {
                FormStyleHelper.ShowError("Invalid token. Please check your GitHub Personal Access Token.");
                lblTokenStatus.Text = "Token Status: ❌ Invalid token";
                lblTokenStatus.Appearance.ForeColor = ColorPalette.DangerRed;
                lblTokenStatus.Appearance.Options.UseForeColor = true;
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Validation failed: {ex.Message}");
            }
            finally
            {
                btnValidateToken.Enabled = true;
                btnValidateToken.Text = "Validate";
            }
        }

        private async Task SaveChangesAsync()
        {
            var fullName = txtFullName.Text?.Trim();
            var department = txtDepartment.Text?.Trim();
            var gitHubUsername = txtGitHubUsername.Text?.Trim();
            var gitHubToken = txtGitHubToken.Text?.Trim();

            // Validation
            if (string.IsNullOrEmpty(fullName))
            {
                FormStyleHelper.ShowWarning("Full name is required.");
                txtFullName.Focus();
                return;
            }

            try
            {
                btnSaveChanges.Enabled = false;
                btnSaveChanges.Text = "💾 Saving...";

                var userId = _currentUserService.CurrentUserId;

                // Update user profile (email is not updated - read only)
                var updateDto = new UpdateUserDto
                {
                    FullName = fullName,
                    Email = txtEmail.Text ?? string.Empty, // Keep existing email
                    Department = department,
                    GitHubUsername = gitHubUsername
                };

                await _userService.UpdateUserProfileAsync(userId, updateDto);

                // Handle GitHub token
                if (!string.IsNullOrEmpty(gitHubToken) && !gitHubToken.StartsWith("••"))
                {
                    // New token entered
                    if (gitHubToken.StartsWith("ghp_") || gitHubToken.StartsWith("github_pat_"))
                    {
                        // Remove existing token if any
                        if (_hasExistingToken && _existingTokenId.HasValue)
                        {
                            await _tokenPoolService.RemoveTokenAsync(_existingTokenId.Value, userId);
                        }

                        // Add new token
                        var tokenDto = new SaveGitHubTokenDto
                        {
                            Token = gitHubToken,
                            GitHubUsername = gitHubUsername
                        };
                        await _tokenPoolService.AddTokenAsync(userId, tokenDto);
                    }
                }

                FormStyleHelper.ShowSuccess("Settings saved successfully!");
                
                // Reload to refresh token status
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Failed to save settings: {ex.Message}");
            }
            finally
            {
                btnSaveChanges.Enabled = true;
                btnSaveChanges.Text = "💾 Save Changes";
            }
        }

        #endregion
    }
}
