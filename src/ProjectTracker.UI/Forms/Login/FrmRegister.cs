using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.UI.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Login
{
    /// <summary>
    /// User registration form with dark-themed modern design
    /// Updated: 02/01/2026 - Added invitation token support for role-based registration
    /// </summary>
    public partial class FrmRegister : XtraForm
    {
        private readonly IUserService _userService;
        private bool _isDragging;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        
        /// <summary>
        /// Invitation token (if user is registering via invitation link)
        /// </summary>
        private string? _invitationToken;

        /// <summary>
        /// Constructor with dependency injection
        /// </summary>
        public FrmRegister(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }
        
        /// <summary>
        /// Constructor with invitation token
        /// </summary>
        public FrmRegister(IUserService userService, string invitationToken) : this(userService)
        {
            _invitationToken = invitationToken;
        }

        /// <summary>
        /// Parameterless constructor for Designer
        /// </summary>
        public FrmRegister() : this(null) { }
        
        /// <summary>
        /// Set invitation token (can be called before showing form)
        /// </summary>
        public void SetInvitationToken(string token)
        {
            _invitationToken = token;
        }

        /// <summary>
        /// Form load event - set focus to username field
        /// </summary>
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            
            // Enter key support for all text fields
            txtUsername.KeyDown += TxtInput_KeyDown;
            txtFullName.KeyDown += TxtInput_KeyDown;
            txtEmail.KeyDown += TxtInput_KeyDown;
            txtPassword.KeyDown += TxtInput_KeyDown;
            txtConfirmPassword.KeyDown += TxtInput_KeyDown;
        }

        /// <summary>
        /// Handles Enter key press to trigger registration
        /// </summary>
        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnRegister_Click(sender, e);
            }
        }

        /// <summary>
        /// Register button click event
        /// </summary>
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userService == null)
                {
                    FormStyleHelper.ShowError("Service not available");
                    return;
                }

                var registerDto = new RegisterDto
                {
                    Username = txtUsername.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text,
                    ConfirmPassword = txtConfirmPassword.Text,
                    InvitationToken = _invitationToken // Will be null if no invitation
                    // RoleId will be determined by service based on invitation token
                };

                this.Cursor = Cursors.WaitCursor;
                btnRegister.Enabled = false;

                var result = await _userService.RegisterAsync(registerDto);

                FormStyleHelper.ShowSuccess($"Registration successful!\n\nWelcome, {result.FullName}!\nYou can now login with your credentials.");

                NavigateToLogin();
            }
            catch (FluentValidation.ValidationException vex)
            {
                var errors = string.Join("\n", vex.Errors.Select(e => $"• {e.ErrorMessage}"));
                FormStyleHelper.ShowWarning($"Validation Errors:\n\n{errors}");
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Registration failed:\n\n{ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnRegister.Enabled = true;
            }
        }

        /// <summary>
        /// Back to Login button click
        /// </summary>
        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            NavigateToLogin();
        }

        /// <summary>
        /// Close button click
        /// </summary>
        private void btnClose_Click(object sender, EventArgs clickArgs)
        {
            Application.Exit();
        }

        /// <summary>
        /// Navigate to Login form
        /// </summary>
        private void NavigateToLogin()
        {
            var loginForm = Program.ServiceProvider.GetRequiredService<FrmLogin>();
            loginForm.Show();
            this.Hide();
        }

        #region Form Dragging

        private void FrmRegister_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragCursorPoint = Cursor.Position;
                _dragFormPoint = this.Location;
            }
        }

        private void FrmRegister_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(diff));
            }
        }

        private void FrmRegister_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        #endregion
    }
}