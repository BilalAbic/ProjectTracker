using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraCharts;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    public partial class GitHubContent : UserControl
    {
        private readonly IGitHubSyncService _syncService;
        private readonly IGitHubAnalyticsService _analyticsService;
        private readonly IProjectService _projectService;
        private readonly ICurrentUserService _currentUserService;
        
        private int? _selectedProjectId;
        private GitRepositoryDto? _currentRepository;

        public GitHubContent(
            IGitHubSyncService syncService,
            IGitHubAnalyticsService analyticsService,
            IProjectService projectService,
            ICurrentUserService currentUserService)
        {
            _syncService = syncService;
            _analyticsService = analyticsService;
            _projectService = projectService;
            _currentUserService = currentUserService;
            
            InitializeComponent();
            SetupGridColumns();
            SetupLeaderboardLayout();
            SetupChart();
            SetupEvents();
            
            // Load projects when control is loaded
            this.Load += async (s, e) => await LoadProjectsAsync();
        }

        protected override async void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && cmbProject.Properties.DataSource == null)
            {
                await LoadProjectsAsync();
            }
        }

        private void SetupGridColumns()
        {
            // Commits columns
            gridViewCommits.Columns.Clear();
            AddColumn(gridViewCommits, "ShortSha", "SHA", 80, 0);
            AddColumn(gridViewCommits, "Message", "Message", 350, 1);
            AddColumn(gridViewCommits, "AuthorName", "Author", 120, 2);
            AddColumn(gridViewCommits, "CommitDate", "Date", 120, 3);
            AddColumn(gridViewCommits, "LinkedTaskName", "Linked Task", 150, 4);

            // Hotspots columns
            gridViewHotspots.Columns.Clear();
            AddColumn(gridViewHotspots, "FileName", "File", 280, 0);
            AddColumn(gridViewHotspots, "ChangeCount", "Changes", 70, 1);
            AddColumn(gridViewHotspots, "TotalAdditions", "+Lines", 70, 2);
            AddColumn(gridViewHotspots, "TotalDeletions", "-Lines", 70, 3);
        }

        private void SetupLeaderboardLayout()
        {
            // Setup LayoutView columns for card display
            layoutViewLeaderboard.Columns.Clear();
            
            var colRank = layoutViewLeaderboard.Columns.AddVisible("Rank");
            colRank.Caption = "Rank";
            
            var colAuthor = layoutViewLeaderboard.Columns.AddVisible("Author");
            colAuthor.Caption = "Developer";
            
            var colCommits = layoutViewLeaderboard.Columns.AddVisible("CommitCount");
            colCommits.Caption = "Commits";
            
            var colAdditions = layoutViewLeaderboard.Columns.AddVisible("Additions");
            colAdditions.Caption = "+Lines";
            
            var colDeletions = layoutViewLeaderboard.Columns.AddVisible("Deletions");
            colDeletions.Caption = "-Lines";
            
            // Card appearance
            layoutViewLeaderboard.CardMinSize = new Size(180, 90);
            layoutViewLeaderboard.OptionsView.ViewMode = LayoutViewMode.Row;
            
            // Custom draw for card styling
            layoutViewLeaderboard.CustomDrawCardFieldValue += LayoutViewLeaderboard_CustomDrawCardFieldValue;
        }

        private void SetupChart()
        {
            // Configure chart appearance for dark theme
            chartCommitTrend.BackColor = Color.FromArgb(36, 43, 61);
            
            // Create Area Series for commit trend
            var series = new Series("Commits", ViewType.Area);
            series.ArgumentDataMember = "Date";
            series.ValueDataMembers.AddRange(new string[] { "CommitCount" });
            series.ArgumentScaleType = ScaleType.DateTime;
            
            // Style the series
            var areaView = (AreaSeriesView)series.View;
            areaView.Color = Color.FromArgb(91, 141, 239);
            areaView.FillStyle.FillMode = FillMode.Solid;
            areaView.Transparency = 150;
            areaView.Border.Color = Color.FromArgb(91, 141, 239);
            areaView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            
            chartCommitTrend.Series.Add(series);
            
            // Configure X-Axis (Date)
            var diagram = chartCommitTrend.Diagram as XYDiagram;
            if (diagram != null)
            {
                diagram.DefaultPane.BackColor = Color.FromArgb(36, 43, 61);
                
                // X-Axis styling
                diagram.AxisX.Label.Font = new Font("Segoe UI", 8F);
                diagram.AxisX.Label.TextColor = Color.FromArgb(148, 163, 184);
                diagram.AxisX.Color = Color.FromArgb(71, 85, 105);
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day;
                diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day;
                diagram.AxisX.Label.Angle = -45;
                
                // Y-Axis styling
                diagram.AxisY.Label.Font = new Font("Segoe UI", 8F);
                diagram.AxisY.Label.TextColor = Color.FromArgb(148, 163, 184);
                diagram.AxisY.Color = Color.FromArgb(71, 85, 105);
                diagram.AxisY.GridLines.Color = Color.FromArgb(51, 65, 85);
                diagram.AxisY.GridLines.LineStyle.DashStyle = DashStyle.Dash;
                diagram.AxisY.WholeRange.Auto = true;
                diagram.AxisY.WholeRange.AlwaysShowZeroLevel = true;
            }
            
            // Hide legend
            chartCommitTrend.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            
            // Configure tooltip
            chartCommitTrend.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;
            series.ToolTipPointPattern = "{A:MMM dd}: {V} commits";
        }

        private void AddColumn(DevExpress.XtraGrid.Views.Grid.GridView view, 
            string fieldName, string caption, int width, int index)
        {
            var col = new GridColumn();
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Width = width;
            col.VisibleIndex = index;
            view.Columns.Add(col);
        }

        private void SetupEvents()
        {
            cmbProject.EditValueChanged += async (s, e) => await OnProjectChangedAsync();
            btnSync.Click += async (s, e) => await SyncRepositoryAsync();
            btnLinkRepo.Click += async (s, e) => await LinkRepositoryAsync();
        }

        private void LayoutViewLeaderboard_CustomDrawCardFieldValue(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Rank")
            {
                var rank = Convert.ToInt32(e.CellValue);
                e.Appearance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                
                switch (rank)
                {
                    case 1:
                        e.Appearance.ForeColor = Color.FromArgb(255, 215, 0); // Gold
                        e.DisplayText = "1st";
                        break;
                    case 2:
                        e.Appearance.ForeColor = Color.FromArgb(192, 192, 192); // Silver
                        e.DisplayText = "2nd";
                        break;
                    case 3:
                        e.Appearance.ForeColor = Color.FromArgb(205, 127, 50); // Bronze
                        e.DisplayText = "3rd";
                        break;
                    default:
                        e.Appearance.ForeColor = ColorPalette.TextMuted;
                        e.DisplayText = $"{rank}th";
                        break;
                }
            }
            else if (e.Column.FieldName == "Additions")
            {
                e.Appearance.ForeColor = Color.FromArgb(34, 197, 94); // Green
                e.DisplayText = $"+{e.CellValue:N0}";
            }
            else if (e.Column.FieldName == "Deletions")
            {
                e.Appearance.ForeColor = Color.FromArgb(239, 68, 68); // Red
                e.DisplayText = $"-{e.CellValue:N0}";
            }
        }

        private async Task LoadProjectsAsync()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("GitHub: LoadProjectsAsync started");
                
                var userId = _currentUserService.CurrentUserId;
                
                IEnumerable<ProjectDto> projects;
                if (_currentUserService.HasManagementAccess)
                {
                    projects = await _projectService.GetAllAsync();
                }
                else
                {
                    projects = await _projectService.GetUserProjectsAsync(userId);
                }
                
                var projectList = projects.ToList();
                
                cmbProject.Properties.DataSource = projectList;
                cmbProject.Properties.DisplayMember = "ProjectName";
                cmbProject.Properties.ValueMember = "ProjectId";
                
                cmbProject.Properties.Columns.Clear();
                var colInfo = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                colInfo.FieldName = "ProjectName";
                colInfo.Caption = "Project";
                cmbProject.Properties.Columns.Add(colInfo);
                
                ShowSelectProjectState();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GitHub ERROR: {ex.Message}");
                FormStyleHelper.ShowError($"Failed to load projects: {ex.Message}");
            }
        }

        private async Task OnProjectChangedAsync()
        {
            if (cmbProject.EditValue == null)
            {
                _selectedProjectId = null;
                ShowSelectProjectState();
                return;
            }

            _selectedProjectId = Convert.ToInt32(cmbProject.EditValue);
            await LoadRepositoryDataAsync();
        }

        private async Task LoadRepositoryDataAsync()
        {
            if (!_selectedProjectId.HasValue) return;

            try
            {
                _currentRepository = await _syncService.GetRepositoryAsync(_selectedProjectId.Value);
                
                if (_currentRepository == null)
                {
                    ShowNoRepoState();
                    return;
                }

                ShowEmptyState(false);
                await LoadAnalyticsAsync();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Failed to load repository: {ex.Message}");
                ShowSelectProjectState();
            }
        }

        private async Task LoadAnalyticsAsync()
        {
            if (!_selectedProjectId.HasValue) return;

            try
            {
                var summary = await _analyticsService.GetAnalyticsSummaryAsync(_selectedProjectId.Value);
                
                if (summary != null)
                {
                    lblCommitsValue.Text = summary.TotalCommits.ToString("N0");
                    lblContributorsValue.Text = summary.TotalContributors.ToString("N0");
                    lblAdditionsValue.Text = $"+{summary.TotalAdditions:N0}";
                    lblMatchedValue.Text = summary.MatchedTasksCount.ToString("N0");
                    grdLeaderboard.DataSource = summary.Leaderboard;
                }

                // Load commits
                var commits = await _analyticsService.GetCommitsAsync(_selectedProjectId.Value, 50);
                grdCommits.DataSource = commits.ToList();

                // Load commit trend for chart
                var trendData = await _analyticsService.GetCommitTrendAsync(_selectedProjectId.Value);
                LoadChartData(trendData.ToList());

                // Load hotspots
                var hotspots = await _analyticsService.GetHotspotsAsync(_selectedProjectId.Value, 10);
                grdHotspots.DataSource = hotspots.ToList();

                if (_currentRepository != null)
                {
                    var lastSync = _currentRepository.LastSyncAt;
                    if (lastSync.HasValue)
                        lblSyncStatus.Text = $"Last sync: {GetRelativeTime(lastSync.Value)}";
                    else
                        lblSyncStatus.Text = "Last sync: Never";
                }
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Failed to load analytics: {ex.Message}");
            }
        }

        private void LoadChartData(List<CommitTrendDto> trendData)
        {
            if (trendData == null || trendData.Count == 0)
            {
                // Show empty chart with message
                chartCommitTrend.Series[0].DataSource = null;
                return;
            }

            // Bind data to chart
            chartCommitTrend.Series[0].DataSource = trendData;
        }

        private async Task SyncRepositoryAsync()
        {
            if (!_selectedProjectId.HasValue)
            {
                FormStyleHelper.ShowWarning("Please select a project first.");
                return;
            }

            if (_currentRepository == null)
            {
                FormStyleHelper.ShowWarning("No repository linked. Please link a repository first.");
                return;
            }

            try
            {
                btnSync.Enabled = false;
                btnSync.Text = "Syncing...";
                lblSyncStatus.Text = "Syncing with GitHub...";

                var result = await _syncService.SyncRepositoryAsync(_selectedProjectId.Value);

                if (result.Success)
                {
                    var msg = $"Sync completed! {result.NewCommitsCount} new commits.";
                    FormStyleHelper.ShowSuccess(msg);
                    await LoadAnalyticsAsync();
                }
                else
                {
                    FormStyleHelper.ShowError($"Sync failed: {result.Message}");
                }
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Sync failed: {ex.Message}");
            }
            finally
            {
                btnSync.Enabled = true;
                btnSync.Text = "Sync Now";
            }
        }

        private async Task LinkRepositoryAsync()
        {
            if (!_selectedProjectId.HasValue)
            {
                FormStyleHelper.ShowWarning("Please select a project first.");
                return;
            }

            var repoUrl = XtraInputBox.Show(
                "Enter the GitHub repository URL:",
                "Link Repository",
                "https://github.com/owner/repo");

            if (string.IsNullOrWhiteSpace(repoUrl)) return;

            if (!repoUrl.StartsWith("https://github.com/"))
            {
                FormStyleHelper.ShowWarning("Invalid GitHub URL format.");
                return;
            }

            try
            {
                btnLinkRepo.Enabled = false;
                btnLinkRepo.Text = "Linking...";

                var repo = await _syncService.LinkRepositoryAsync(_selectedProjectId.Value, repoUrl);
                
                FormStyleHelper.ShowSuccess($"Repository linked: {repo.RepoOwner}/{repo.RepoName}");
                await LoadRepositoryDataAsync();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Failed to link repository: {ex.Message}");
            }
            finally
            {
                btnLinkRepo.Enabled = true;
                btnLinkRepo.Text = "Link Repository";
            }
        }

        private void ShowEmptyState(bool show)
        {
            pnlEmpty.Visible = show;
            pnlMain.Visible = !show;
            btnSync.Enabled = !show;
            
            if (show)
                pnlEmpty.BringToFront();
            else
                pnlMain.BringToFront();
        }

        private void ShowSelectProjectState()
        {
            pnlEmpty.Visible = true;
            pnlMain.Visible = false;
            btnSync.Enabled = false;
            lblEmptyIcon.Text = "";
            lblEmptyTitle.Text = "Select a Project";
            lblEmptyMessage.Text = "Please select a project from the dropdown above to view GitHub analytics.";
            pnlEmpty.BringToFront();
        }

        private void ShowNoRepoState()
        {
            pnlEmpty.Visible = true;
            pnlMain.Visible = false;
            btnSync.Enabled = false;
            lblEmptyIcon.Text = "";
            lblEmptyTitle.Text = "No GitHub Repository Linked";
            lblEmptyMessage.Text = "Click 'Link Repository' to connect a GitHub repository to this project.";
            pnlEmpty.BringToFront();
        }

        private static string GetRelativeTime(DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;
            
            if (timeSpan.TotalMinutes < 1) return "just now";
            if (timeSpan.TotalMinutes < 60) return $"{(int)timeSpan.TotalMinutes}m ago";
            if (timeSpan.TotalHours < 24) return $"{(int)timeSpan.TotalHours}h ago";
            if (timeSpan.TotalDays < 7) return $"{(int)timeSpan.TotalDays}d ago";
            
            return dateTime.ToString("MMM dd, yyyy");
        }
    }
}
