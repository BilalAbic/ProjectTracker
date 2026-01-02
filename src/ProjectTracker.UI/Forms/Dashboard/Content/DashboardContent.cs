using DevExpress.PivotGrid.OLAP.Mdx;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using ProjectTracker.UI.Helpers;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Dashboard content UserControl - Main analytics view
/// Shows KPI cards, recent projects, and quick actions
/// </summary>
namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    public partial class DashboardContent : UserControl
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        private readonly IAuditLogService _auditLogService;

        /// <summary>
        /// Initializes a new instance of the DashboardContent class
        /// </summary>
        public DashboardContent(
            IProjectService projectService, 
            IUserService userService,
            IAuditLogService auditLogService)
        {
            InitializeComponent();

            _projectService = projectService;
            _userService = userService;
            _auditLogService = auditLogService;

            // Setup card shadows
            SetupCardShadows();

            // Setup grid
            SetupGrid();

            // Setup recent activities grid
            SetupRecentActivitiesGrid();

            // Setup event handlers
            SetupEventHandlers();
        }

        /// <summary>
        /// Setup shadow effects for KPI cards
        /// </summary>
        private void SetupCardShadows()
        {
            var cards = new[]
            {
                pnlCardProjects, pnlCardTasks,
                pnlCardTeam, pnlCardCompletion
            };

            foreach (var card in cards)
            {
                card.Paint += Card_Paint;
            }
        }

        /// <summary>
        /// Paint card with rounded corners and shadow
        /// </summary>
        private void Card_Paint(object sender, PaintEventArgs e)
        {
            var panel = sender as PanelControl;
            if (panel == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw rounded rectangle with subtle shadow effect
            using (var path = GetRoundedRect(panel.ClientRectangle, 8))
            using (var brush = new SolidBrush(ColorPalette.BackgroundSlateDark))
            using (var borderPen = new Pen(ColorPalette.BorderSlate, 1))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(borderPen, path);
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
        /// Setup grid columns and appearance
        /// </summary>
        private void SetupGrid()
        {
            // Grid columns are now defined in Designer.cs
            // No additional setup needed
        }

        /// <summary>
        /// Setup event handlers
        /// </summary>
        private void SetupEventHandlers()
        {
            // New Project button
            btnNewProject.Click += btnNewProject_Click;

            // View All button
            btnViewAllProjects.Click += btnViewAllProjects_Click;

            // Grid row double click
            gridViewRecentProjects.DoubleClick += gridViewRecentProjects_DoubleClick;
        }

        /// <summary>
        /// Load dashboard data
        /// </summary>
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.DesignMode)
            {
                await LoadDashboardDataAsync();
            }
        }

        /// <summary>
        /// New Project button click
        /// </summary>
        private void btnNewProject_Click(object sender, EventArgs e)
        {
            // Navigate to Projects page
            var dashboard = this.FindForm() as FrmDashboard;
            dashboard?.LoadContent(Program.ServiceProvider.GetRequiredService<ProjectsContent>());
        }

        /// <summary>
        /// View All button click
        /// </summary>
        private void btnViewAllProjects_Click(object sender, EventArgs e)
        {
            // Navigate to Projects page
            var dashboard = this.FindForm() as FrmDashboard;
            dashboard?.LoadContent(Program.ServiceProvider.GetRequiredService<ProjectsContent>());
        }

        /// <summary>
        /// Grid row double click
        /// </summary>
        private void gridViewRecentProjects_DoubleClick(object sender, EventArgs e)
        {
            var view = gridViewRecentProjects;
            var hitInfo = view.CalcHitInfo(gridRecentProjects.PointToClient(Cursor.Position));

            if (hitInfo.InRow && hitInfo.RowHandle >= 0)
            {
                var project = view.GetRow(hitInfo.RowHandle) as ProjectDto;
                if (project != null)
                {
                    FormStyleHelper.ShowInfo($"Open project: {project.ProjectName}");
                }
            }
        }

        /// <summary>
        /// Load dashboard data from services
        /// </summary>
        private async Task LoadDashboardDataAsync()
        {
            try
            {
                // Get all projects
                var allProjects = await _projectService.GetAllAsync();

                // Calculate KPIs
                var totalProjects = allProjects.Count();
                var activeProjects = allProjects.Count(p => p.Status == ProjectStatus.Active);
                var completedProjects = allProjects.Count(p => p.Status == ProjectStatus.Completed);
                var completionRate = totalProjects > 0
                    ? (int)((double)completedProjects / totalProjects * 100)
                    : 0;

                // Update KPI cards
                lblCard1Value.Text = totalProjects.ToString();
                lblCard2Value.Text = activeProjects.ToString();
                lblCard3Value.Text = "12"; // Hardcoded for now (Team members)
                lblCard4Value.Text = $"{completionRate}%";

                // Update progress bar
                progressCompletion.Position = completionRate;

                // Load recent projects (last 5)
                var recentProjects = allProjects
                    .OrderByDescending(p => p.CreatedAt)
                    .Take(5)
                    .Select(p => new
                    {
                        p.ProjectId,
                        Name = p.ProjectName,
                        Status = p.Status.ToString(),
                        Progress = $"{p.CompletionPercentage}%",
                        ManagerName = "Manager", // TODO: Get from User
                        DueDate = p.EndDate
                    })
                    .ToList();

                gridRecentProjects.DataSource = recentProjects;

                // Load recent activities (ROL BAZLI)
                await LoadRecentActivitiesAsync();

                // Update trends (mock data for now)
                UpdateTrends();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading dashboard data: {ex.Message}");
            }
        }

        /// <summary>
        /// Update trend indicators (mock data)
        /// </summary>
        private void UpdateTrends()
        {
            // Mock trends
            lblCard1Trend.Text = "↑ +3 today";
            lblCard1Trend.Appearance.ForeColor = ColorPalette.SuccessGreen;

            lblCard2Trend.Text = "↑ +12 this week";
            lblCard2Trend.Appearance.ForeColor = ColorPalette.SuccessGreen;

            lblCard3Trend.Text = "Online: 8";
            lblCard3Trend.Appearance.ForeColor = ColorPalette.TextSecondary;
        }

        /// <summary>
        /// Setup recent activities grid columns and appearance
        /// </summary>
        private void SetupRecentActivitiesGrid()
        {
            // Grid columns are now defined in Designer.cs
            // No additional setup needed
        }

        /// <summary>
        /// Load recent activities based on user role
        /// </summary>
        private async Task LoadRecentActivitiesAsync()
        {
            try
            {
                var activities = await _auditLogService.GetUserRecentActivitiesAsync(
                    SessionManager.CurrentUserId,
                    SessionManager.IsAdmin,
                    count: 10);

                var activityList = activities.Select(a => new
                {
                    Icon = a.Icon,
                    Description = $"{a.UserName} {a.ActionDescription}",
                    Target = a.TargetName,
                    Project = a.ProjectName ?? "-",
                    Time = a.RelativeTime
                }).ToList();

                gridRecentActivities.DataSource = activityList;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading activities: {ex.Message}");
            }
        }
    }
}
