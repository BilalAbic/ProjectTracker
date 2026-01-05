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
        private readonly ITaskService _taskService;
        private readonly ITeamService _teamService;

        /// <summary>
        /// Initializes a new instance of the DashboardContent class
        /// </summary>
        public DashboardContent(
            IProjectService projectService, 
            IUserService userService,
            IAuditLogService auditLogService,
            ITaskService taskService,
            ITeamService teamService)
        {
            InitializeComponent();

            _projectService = projectService;
            _userService = userService;
            _auditLogService = auditLogService;
            _taskService = taskService;
            _teamService = teamService;

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
        /// Load dashboard data from services
        /// </summary>
        private async Task LoadDashboardDataAsync()
        {
            try
            {
                // Rol bazlı veri getirme
                var isAdmin = SessionManager.IsAdmin;
                var currentUserId = SessionManager.CurrentUserId;

                // ===== CARD 1: Projects =====
                IEnumerable<ProjectDto> projects;
                if (isAdmin)
                {
                    // Admin tüm projeleri görür
                    projects = await _projectService.GetAllAsync();
                }
                else
                {
                    // Diğer kullanıcılar sadece kendi projelerini görür
                    projects = await _projectService.GetUserProjectsAsync(currentUserId);
                }
                
                var totalProjects = projects.Count();
                var activeProjects = projects.Count(p => p.Status == ProjectStatus.Active);
                var completedProjects = projects.Count(p => p.Status == ProjectStatus.Completed);
                
                // Bugün eklenen projeler
                var projectsToday = projects.Count(p => p.CreatedAt.Date == DateTime.Today);
                
                lblCard1Value.Text = totalProjects.ToString();
                lblCard1Label.Text = isAdmin ? "Total Projects" : "My Projects";
                lblCard1Trend.Text = projectsToday > 0 ? $"↑ +{projectsToday} today" : "No new today";
                lblCard1Trend.Appearance.ForeColor = projectsToday > 0 ? ColorPalette.SuccessGreen : ColorPalette.TextSecondary;

                // ===== CARD 2: Tasks =====
                IEnumerable<TaskDto> tasks;
                if (isAdmin)
                {
                    // Admin tüm taskları görür
                    tasks = await _taskService.GetAllTasksAsync();
                }
                else
                {
                    // Diğer kullanıcılar sadece kendi tasklarını görür
                    tasks = await _taskService.GetUserTasksAsync(currentUserId);
                }
                
                var activeTasks = tasks.Count(t => 
                    t.Status == "InProgress" || 
                    t.Status == "Pending");
                var completedTasksThisWeek = tasks.Count(t => 
                    t.Status == "Completed" && 
                    t.CompletedDate.HasValue &&
                    t.CompletedDate.Value >= DateTime.Today.AddDays(-7));
                
                lblCard2Value.Text = activeTasks.ToString();
                lblCard2Label.Text = isAdmin ? "Active Tasks" : "My Tasks";
                lblCard2Trend.Text = completedTasksThisWeek > 0 
                    ? $"✓ {completedTasksThisWeek} done this week" 
                    : "No completions";
                lblCard2Trend.Appearance.ForeColor = completedTasksThisWeek > 0 
                    ? ColorPalette.SuccessGreen 
                    : ColorPalette.TextSecondary;

                // ===== CARD 3: Team Members =====
                int totalMembers;
                string teamInfo;
                
                if (isAdmin)
                {
                    // Admin tüm aktif kullanıcıları görür
                    var activeUsers = await _userService.GetActiveUsersAsync();
                    totalMembers = activeUsers.Count();
                    
                    var allTeams = await _teamService.GetAllTeamsAsync();
                    teamInfo = $"{allTeams.Count()} teams";
                    lblCard3Label.Text = "Total Users";
                }
                else
                {
                    // Kullanıcı kendi takım üyelerini görür
                    var userTeams = await _teamService.GetUserTeamsAsync();
                    var teamsCount = userTeams.Count();
                    
                    // Takım üyelerini say
                    totalMembers = 0;
                    foreach (var team in userTeams)
                    {
                        var members = await _teamService.GetTeamMembersAsync(team.TeamId);
                        totalMembers += members.Count();
                    }
                    
                    teamInfo = teamsCount > 0 ? $"In {teamsCount} team(s)" : "No teams";
                    lblCard3Label.Text = "Team Members";
                }
                
                lblCard3Value.Text = totalMembers.ToString();
                lblCard3Trend.Text = teamInfo;
                lblCard3Trend.Appearance.ForeColor = ColorPalette.TextSecondary;

                // ===== CARD 4: Completion Rate =====
                var totalTasks = tasks.Count();
                var completedTasks = tasks.Count(t => t.Status == "Completed");
                var taskCompletionRate = totalTasks > 0
                    ? (int)((double)completedTasks / totalTasks * 100)
                    : 0;
                
                lblCard4Value.Text = $"{taskCompletionRate}%";
                lblCard4Label.Text = isAdmin ? "Overall Completion" : "My Completion";
                progressCompletion.Position = taskCompletionRate;

                // ===== Recent Activities Grid =====
                await LoadRecentActivitiesAsync();

                // Update welcome message with user name
                UpdateWelcomeMessage();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading dashboard data: {ex.Message}");
            }
        }

        /// <summary>
        /// Update welcome message with current user name
        /// </summary>
        private void UpdateWelcomeMessage()
        {
            var userName = SessionManager.CurrentUserFullName;
            if (string.IsNullOrEmpty(userName))
                userName = SessionManager.CurrentUser?.Username ?? "User";
            
            lblWelcomeTitle.Text = $"Welcome back, {userName}!";
            
            var hour = DateTime.Now.Hour;
            string greeting;
            if (hour < 12) greeting = "Good morning";
            else if (hour < 18) greeting = "Good afternoon";
            else greeting = "Good evening";
            
            var roleInfo = SessionManager.IsAdmin ? " (Admin View)" : "";
            lblWelcomeSubtitle.Text = $"{greeting}! Here's what's happening with your projects today.{roleInfo}";
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
