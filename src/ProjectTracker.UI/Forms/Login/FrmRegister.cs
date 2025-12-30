using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Login
{
    /// <summary>
    /// User registration form with dark-themed modern design
    /// </summary>
    public partial class FrmRegister : XtraForm
    {
        private readonly IUserService _userService;
        private bool _isDragging;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        /// <summary>
        /// Constructor with dependency injection
        /// </summary>
        public FrmRegister(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        /// <summary>
        /// Parameterless constructor for Designer
        /// </summary>
        public FrmRegister() : this(null) { }

        /// <summary>
        /// Form load event - set focus to username field
        /// </summary>
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
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
                    XtraMessageBox.Show("Service not available", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var registerDto = new RegisterDto
                {
                    Username = txtUsername.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text,
                    ConfirmPassword = txtConfirmPassword.Text,
                    RoleId = 3  // Always Developer role
                };

                this.Cursor = Cursors.WaitCursor;
                btnRegister.Enabled = false;

                var result = await _userService.RegisterAsync(registerDto);

                XtraMessageBox.Show(
                    $"Registration successful!\n\nWelcome, {result.FullName}!\nYou can now login with your credentials.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                NavigateToLogin();
            }
            catch (FluentValidation.ValidationException vex)
            {
                var errors = string.Join("\n", vex.Errors.Select(e => $"• {e.ErrorMessage}"));
                XtraMessageBox.Show($"Validation Errors:\n\n{errors}", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Registration failed:\n\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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