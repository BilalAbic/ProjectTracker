using DevExpress.PivotGrid.OLAP.Mdx;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
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

        /// <summary>
        /// Initializes a new instance of the DashboardContent class
        /// </summary>
        public DashboardContent(IProjectService projectService, IUserService userService)
        {
            InitializeComponent();

            _projectService = projectService;
            _userService = userService;

            // Setup card shadows
            SetupCardShadows();

            // Setup grid
            SetupGrid();

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
            using (var brush = new SolidBrush(Color.FromArgb(21, 21, 21))) // #151515
            using (var borderPen = new Pen(Color.FromArgb(42, 42, 42), 1)) // #2A2A2A
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
            // Clear existing columns
            gridViewRecentProjects.Columns.Clear();

            // Add columns
            gridViewRecentProjects.Columns.AddRange(new[]
            {
                new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "Name",
                    Caption = "Project Name",
                    Visible = true,
                    Width = 300,
                    OptionsColumn = { AllowEdit = false }
                },
                new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "Status",
                    Caption = "Status",
                    Visible = true,
                    Width = 150,
                    OptionsColumn = { AllowEdit = false }
                },
                new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "Progress",
                    Caption = "Progress",
                    Visible = true,
                    Width = 150,
                    OptionsColumn = { AllowEdit = false }
                },
                new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "ManagerName",
                    Caption = "Manager",
                    Visible = true,
                    Width = 200,
                    OptionsColumn = { AllowEdit = false }
                },
                new DevExpress.XtraGrid.Columns.GridColumn
                {
                    FieldName = "DueDate",
                    Caption = "Due Date",
                    Visible = true,
                    Width = 150,
                    DisplayFormat = { FormatType = DevExpress.Utils.FormatType.DateTime, FormatString = "dd MMM yyyy" },
                    OptionsColumn = { AllowEdit = false }
                }
            });

            // Grid options
            gridViewRecentProjects.OptionsBehavior.Editable = false;
            gridViewRecentProjects.OptionsCustomization.AllowColumnMoving = false;
            gridViewRecentProjects.OptionsCustomization.AllowFilter = false;
            gridViewRecentProjects.OptionsCustomization.AllowSort = false;
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
        private void btnNewProject_Click_1(object sender, EventArgs e)
        {
            XtraMessageBox.Show("New Project - Coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// View All button click
        /// </summary>
        private void btnViewAllProjects_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("View All Projects - Coming soon!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    XtraMessageBox.Show($"Open project: {project.ProjectName}", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                // Update trends (mock data for now)
                UpdateTrends();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Update trend indicators (mock data)
        /// </summary>
        private void UpdateTrends()
        {
            // Mock trends
            lblCard1Trend.Text = "↑ +3 today";
            lblCard1Trend.Appearance.ForeColor = Color.FromArgb(0, 208, 132); // Green

            lblCard2Trend.Text = "↑ +12 this week";
            lblCard2Trend.Appearance.ForeColor = Color.FromArgb(0, 208, 132); // Green

            lblCard3Trend.Text = "Online: 8";
            lblCard3Trend.Appearance.ForeColor = Color.FromArgb(161, 161, 161); // Gray
        }
 
    }
}
