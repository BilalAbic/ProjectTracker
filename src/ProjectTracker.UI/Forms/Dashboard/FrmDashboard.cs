using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Dashboard
{
    public partial class FrmDashboard : DevExpress.XtraEditors.XtraForm
    {
        // Current loaded content
        private UserControl _currentContent;
        private readonly IServiceProvider _serviceProvider;
        // Drag to move fields
        private bool _dragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;

        // Current active button (for indicator animation)
        private SimpleButton _activeButton;

        /// <summary>
        /// Initializes a new instance of the FrmDashboard class
        /// </summary>
        public FrmDashboard(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            // Setup rounded corners for notification badge
            SetupRoundedBadge();

            // Store service provider
            _serviceProvider = serviceProvider;

            // Setup event handlers
            SetupEventHandlers();

            // Load initial content (Dashboard) ← AKTIF ET
            LoadContent(_serviceProvider.GetRequiredService<Content.DashboardContent>());

            // Set dashboard as active
            UpdateSidebarSelection(btnDashboard);
        }

        /// <summary>
        /// Setup rounded corners for notification badge
        /// </summary>
        private void SetupRoundedBadge()
        {
            lblNotificationBadge.Paint += (s, e) =>
            {
                // Draw rounded rectangle
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(Color.FromArgb(255, 77, 0))) // Orange
                {
                    e.Graphics.FillEllipse(brush, 0, 0, 16, 16);
                }

                // Draw text
                using (var textBrush = new SolidBrush(Color.White))
                {
                    var sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    e.Graphics.DrawString(lblNotificationBadge.Text,
                        lblNotificationBadge.Font, textBrush,
                        new RectangleF(0, 0, 16, 16), sf);
                }
            };
        }

        /// <summary>
        /// Setup all event handlers
        /// </summary>
        private void SetupEventHandlers()
        {
            // Close button
            btnClose.Click += (s, e) => Application.Exit();

            // Top bar hover effects
            SetupTopBarHoverEffects();

            // Sidebar navigation
            btnDashboard.Click += btnDashboard_Click;
            btnProjects.Click += btnProjects_Click;
            btnTasks.Click += btnTasks_Click;
            btnTeam.Click += btnTeam_Click;
            btnReports.Click += btnReports_Click;
            btnSettings.Click += btnSettings_Click;

            // Sidebar hover effects
            SetupSidebarHoverEffects();

            // Drag to move
            pnlTopBar.MouseDown += FrmDashboard_MouseDown;
            pnlTopBar.MouseMove += FrmDashboard_MouseMove;
            pnlTopBar.MouseUp += FrmDashboard_MouseUp;

            lblLogo.MouseDown += FrmDashboard_MouseDown;
            lblLogo.MouseMove += FrmDashboard_MouseMove;
            lblLogo.MouseUp += FrmDashboard_MouseUp;

            lblLogoTitle.MouseDown += FrmDashboard_MouseDown;
            lblLogoTitle.MouseMove += FrmDashboard_MouseMove;
            lblLogoTitle.MouseUp += FrmDashboard_MouseUp;

            // Rounded search container
            pnlSearchContainer.Paint += PnlSearchContainer_Paint;
        }

        /// <summary>
        /// Paint rounded search container
        /// </summary>
        private void PnlSearchContainer_Paint(object sender, PaintEventArgs e)
        {
            // Draw rounded rectangle
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(Color.FromArgb(26, 26, 26))) // #1A1A1A
            using (var path = GetRoundedRect(pnlSearchContainer.ClientRectangle, 6))
            {
                e.Graphics.FillPath(brush, path);
            }
        }

        /// <summary>
        /// Get rounded rectangle path
        /// </summary>
        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// Setup hover effects for top bar buttons
        /// </summary>
        private void SetupTopBarHoverEffects()
        {
            // Close button hover (Orange)
            btnClose.MouseEnter += (s, e) =>
                btnClose.Appearance.ForeColor = Color.FromArgb(255, 77, 0); // Orange
            btnClose.MouseLeave += (s, e) =>
                btnClose.Appearance.ForeColor = Color.FromArgb(161, 161, 161); // Gray

            // Notification button hover (White)
            btnNotification.MouseEnter += (s, e) =>
                btnNotification.Appearance.ForeColor = Color.FromArgb(255, 255, 255); // White
            btnNotification.MouseLeave += (s, e) =>
                btnNotification.Appearance.ForeColor = Color.FromArgb(161, 161, 161); // Gray

            // User button hover (White)
            btnUser.MouseEnter += (s, e) =>
            {
                btnUser.Appearance.ForeColor = Color.FromArgb(255, 255, 255); // White
                lblUserArrow.Appearance.ForeColor = Color.FromArgb(255, 255, 255); // White
            };
            btnUser.MouseLeave += (s, e) =>
            {
                btnUser.Appearance.ForeColor = Color.FromArgb(161, 161, 161); // Gray
                lblUserArrow.Appearance.ForeColor = Color.FromArgb(161, 161, 161); // Gray
            };
        }

        /// <summary>
        /// Setup hover effects for sidebar buttons
        /// </summary>
        private void SetupSidebarHoverEffects()
        {
            var sidebarButtons = new[]
            {
                btnDashboard, btnProjects, btnTasks,
                btnTeam, btnReports, btnSettings
            };

            foreach (var btn in sidebarButtons)
            {
                btn.MouseEnter += SidebarButton_MouseEnter;
                btn.MouseLeave += SidebarButton_MouseLeave;
            }
        }

        /// <summary>
        /// Sidebar button hover enter
        /// </summary>
        private void SidebarButton_MouseEnter(object sender, EventArgs e)
        {
            var btn = sender as SimpleButton;
            if (btn == null) return;

            // Don't change color if active (already orange)
            if (btn != _activeButton)
            {
                btn.Appearance.ForeColor = Color.FromArgb(255, 255, 255); // White on hover
            }
        }

        /// <summary>
        /// Sidebar button hover leave
        /// </summary>
        private void SidebarButton_MouseLeave(object sender, EventArgs e)
        {
            var btn = sender as SimpleButton;
            if (btn == null) return;

            // Don't change color if active (keep orange)
            if (btn != _activeButton)
            {
                btn.Appearance.ForeColor = Color.FromArgb(161, 161, 161); // Gray
            }
        }

        /// <summary>
        /// Load UserControl into content panel
        /// </summary>
        public void LoadContent(UserControl content)
        {
            // Clear existing content
            pnlContent.Controls.Clear();

            // Dispose old content
            _currentContent?.Dispose();

            // Load new content
            content.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(content);

            _currentContent = content;
        }

        /// <summary>
        /// Dashboard button click
        /// </summary>
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // LoadContent(new DashboardContent()); // Sonra ekleyeceğiz
            XtraMessageBox.Show("📊 Dashboard - Coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateSidebarSelection(btnDashboard);
        }

        /// <summary>
        /// Projects button click
        /// </summary>
        private void btnProjects_Click(object sender, EventArgs e)
        {
            // LoadContent(new ProjectsContent()); // Sonra ekleyeceğiz
            XtraMessageBox.Show("📁 Projects - Coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateSidebarSelection(btnProjects);
        }

        /// <summary>
        /// Tasks button click
        /// </summary>
        private void btnTasks_Click(object sender, EventArgs e)
        {
            // LoadContent(new TasksContent()); // Sonra ekleyeceğiz
            XtraMessageBox.Show("✓ Tasks - Coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateSidebarSelection(btnTasks);
        }

        /// <summary>
        /// Team button click
        /// </summary>
        private void btnTeam_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("👥 Team - Coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateSidebarSelection(btnTeam);
        }

        /// <summary>
        /// Reports button click
        /// </summary>
        private void btnReports_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("📈 Reports - Coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateSidebarSelection(btnReports);
        }

        /// <summary>
        /// Settings button click
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("⚙ Settings - Coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateSidebarSelection(btnSettings);
        }

        /// <summary>
        /// Update sidebar active state with animated indicator
        /// </summary>
        private void UpdateSidebarSelection(SimpleButton activeButton)
        {
            // Reset all buttons
            foreach (var btn in pnlSidebar.Controls.OfType<SimpleButton>())
            {
                btn.Appearance.ForeColor = Color.FromArgb(161, 161, 161); // Gray
            }

            // Highlight active button
            activeButton.Appearance.ForeColor = Color.FromArgb(255, 77, 0); // Orange
            _activeButton = activeButton;

            // Animate indicator to active button position
            AnimateIndicator(activeButton.Top);
        }

        /// <summary>
        /// Animate active indicator to target position
        /// </summary>
        private void AnimateIndicator(int targetY)
        {
            // Simple animation (можно улучшить с Timer)
            var timer = new System.Windows.Forms.Timer { Interval = 10 };
            var currentY = pnlActiveIndicator.Top;
            var step = (targetY - currentY) / 10;

            timer.Tick += (s, e) =>
            {
                if (Math.Abs(pnlActiveIndicator.Top - targetY) < Math.Abs(step))
                {
                    pnlActiveIndicator.Top = targetY;
                    timer.Stop();
                    timer.Dispose();
                }
                else
                {
                    pnlActiveIndicator.Top += step;
                }
            };

            timer.Start();
        }

        /// <summary>
        /// Mouse down - Start dragging
        /// </summary>
        private void FrmDashboard_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = this.Location;
        }

        /// <summary>
        /// Mouse move - Dragging
        /// </summary>
        private void FrmDashboard_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(diff));
            }
        }

        /// <summary>
        /// Mouse up - Stop dragging
        /// </summary>
        private void FrmDashboard_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }


    }
}