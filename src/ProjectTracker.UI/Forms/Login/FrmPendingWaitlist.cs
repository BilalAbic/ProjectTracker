using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.UI.Helpers;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Login
{
    /// <summary>
    /// Pending waitlist form - Shown to users awaiting admin approval
    /// </summary>
    public partial class FrmPendingWaitlist : Form
    {
        #region Window Dragging
        
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        
        #endregion

        #region Constructor
        
        public FrmPendingWaitlist()
        {
            InitializeComponent();
            SetupForm();
            SetupEventHandlers();
        }
        
        #endregion

        #region Setup Methods
        
        private void SetupForm()
        {
            // Form settings
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = FormStyleHelper.FormBackground;
            
            // Update user info if available
            if (!string.IsNullOrEmpty(SessionManager.CurrentUserFullName))
            {
                lblWelcome.Text = $"Welcome, {SessionManager.CurrentUserFullName}!";
            }
        }
        
        private void SetupEventHandlers()
        {
            // Close button
            btnClose.Click += BtnClose_Click;
            
            // Logout button
            btnLogout.Click += BtnLogout_Click;
            
            // Refresh button
            btnRefresh.Click += BtnRefresh_Click;
            
            // Window dragging
            pnlHeader.MouseDown += FrmPendingWaitlist_MouseDown;
            pnlHeader.MouseMove += FrmPendingWaitlist_MouseMove;
            pnlHeader.MouseUp += FrmPendingWaitlist_MouseUp;
            
            lblTitle.MouseDown += FrmPendingWaitlist_MouseDown;
            lblTitle.MouseMove += FrmPendingWaitlist_MouseMove;
            lblTitle.MouseUp += FrmPendingWaitlist_MouseUp;
            
            pnlContent.MouseDown += FrmPendingWaitlist_MouseDown;
            pnlContent.MouseMove += FrmPendingWaitlist_MouseMove;
            pnlContent.MouseUp += FrmPendingWaitlist_MouseUp;
        }
        
        #endregion

        #region Event Handlers
        
        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            SessionManager.Logout();
            
            // Get FrmLogin from DI container
            var loginForm = Program.ServiceProvider.GetRequiredService<FrmLogin>();
            loginForm.Show();
            this.Hide();
        }
        
        private async void BtnRefresh_Click(object? sender, EventArgs e)
        {
            try
            {
                btnRefresh.Enabled = false;
                btnRefresh.Text = "Checking...";
                
                // Check if user status has been updated
                // This would typically call a service to check the user's current role
                await System.Threading.Tasks.Task.Delay(1000); // Simulate API call
                
                // For now, just show a message
                FormStyleHelper.ShowInfo("Your account is still pending approval.\nPlease wait for an administrator to review your request.");
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error checking status: {ex.Message}");
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnRefresh.Text = "🔄 Check Status";
            }
        }
        
        #endregion

        #region Window Dragging
        
        private bool _isDragging = false;
        private Point _dragStartPoint;
        
        private void FrmPendingWaitlist_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragStartPoint = e.Location;
            }
        }
        
        private void FrmPendingWaitlist_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(
                    currentScreenPos.X - _dragStartPoint.X,
                    currentScreenPos.Y - _dragStartPoint.Y);
            }
        }
        
        private void FrmPendingWaitlist_MouseUp(object? sender, MouseEventArgs e)
        {
            _isDragging = false;
        }
        
        #endregion
    }
}
