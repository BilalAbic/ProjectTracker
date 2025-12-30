using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
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
                    XtraMessageBox.Show("Please enter username", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                // Validate password
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    XtraMessageBox.Show("Please enter password", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // Login successful
                    this.Hide();

                    // Dashboard Show
                    var dashboard = Program.ServiceProvider
                        .GetRequiredService<Forms.Dashboard.FrmDashboard>();
                    dashboard.Show();

                    // Dashboard kapanınca uygulama kapansın
                    dashboard.FormClosed += (s, args) => Application.Exit();
                }
                else
                {
                    // Login failed
                    XtraMessageBox.Show("Invalid username or password",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // Clear password and reset focus
                    txtPassword.Text = string.Empty;
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                XtraMessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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