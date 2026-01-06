using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.UI.Helpers;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Login
{
    /// <summary>
    /// Modern login form with split-panel design
    /// Provides user authentication functionality
    /// Created by: Developer, 18/12/2024
    /// Updated: 31/12/2024 - Modern Slate Blue Theme Applied
    /// </summary>
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        // Private fields
        private readonly IUserService _userService;

        // Form dragging fields (Drag to move)
        private bool _dragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        /// <summary>
        /// Initializes a new instance of the FrmLogin class
        /// </summary>
        /// <param name="userService">User service for authentication</param>
        public FrmLogin(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        /// <summary>
        /// Handles form load event, sets initial focus
        /// </summary>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            
            // Enter key support for login
            txtUsername.KeyDown += TxtInput_KeyDown;
            txtPassword.KeyDown += TxtInput_KeyDown;
        }

        /// <summary>
        /// Handles Enter key press to trigger login
        /// </summary>
        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin_Click(sender, e);
            }
        }


        /// <summary>
        /// Handles close button click event
        /// Closes the login form
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles cancel button click event
        /// Exits the application
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles login button click event
        /// Validates credentials and authenticates user
        /// </summary>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate username
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    FormStyleHelper.ShowWarning("Please enter username");
                    txtUsername.Focus();
                    return;
                }

                // Validate password
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    FormStyleHelper.ShowWarning("Please enter password");
                    txtPassword.Focus();
                    return;
                }

                // Show loading state
                this.Cursor = Cursors.WaitCursor;
                btnLogin.Enabled = false;

                // Attempt login
                var loginDto = new LoginDto
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text
                };

                var user = await _userService.LoginAsync(loginDto);

                if (user != null)
                {
                    // Set session
                    SessionManager.Login(user);

                    // Login successful
                    this.Hide();

                    // Role-based navigation
                    if (SessionManager.IsPending)
                    {
                        // Pending users go to waitlist form
                        var waitlistForm = Program.ServiceProvider
                            .GetRequiredService<Forms.Login.FrmPendingWaitlist>();
                        waitlistForm.Show();
                        waitlistForm.FormClosed += (s, args) => Application.Exit();
                    }
                    else
                    {
                        // Other roles go to Dashboard
                        var dashboard = Program.ServiceProvider
                            .GetRequiredService<Forms.Dashboard.FrmDashboard>();
                        dashboard.Show();
                        dashboard.FormClosed += (s, args) => Application.Exit();
                    }
                }
                else
                {
                    // Login failed
                    FormStyleHelper.ShowError("Invalid username or password");

                    // Clear password and reset focus
                    txtPassword.Text = string.Empty;
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                FormStyleHelper.ShowError($"Error: {ex.Message}");
            }
            finally
            {
                // Reset UI state
                this.Cursor = Cursors.Default;
                btnLogin.Enabled = true;
            }
        }

        /// <summary>
        /// Handles form mouse down event for drag-to-move functionality
        /// </summary>
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = this.Location;
        }

        /// <summary>
        /// Handles form mouse move event for drag-to-move functionality
        /// </summary>
        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(diff));
            }
        }

        /// <summary>
        /// Handles form mouse up event for drag-to-move functionality
        /// </summary>
        private void FrmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        /// <summary>
        /// Handles register link click event
        /// Navigates to registration form
        /// </summary>
        private void lblRegisterLink_Click(object sender, EventArgs e)
        {
            var registerForm = Program.ServiceProvider.GetRequiredService<FrmRegister>();
            registerForm.Show();
            this.Hide();
        }

    }
}