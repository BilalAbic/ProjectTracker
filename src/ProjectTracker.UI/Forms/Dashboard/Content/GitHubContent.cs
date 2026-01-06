using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraCharts;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.UI.Helpers;
using System.IO;

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
            // Commits columns with icons in headers
            gridViewCommits.Columns.Clear();
            AddColumn(gridViewCommits, "ShortSha", "🔗 SHA", 90, 0);
            AddColumn(gridViewCommits, "Message", "💬 Message", 350, 1);
            AddColumn(gridViewCommits, "AuthorName", "👤 Author", 130, 2);
            AddColumn(gridViewCommits, "CommitDate", "📅 Date", 130, 3);
            AddColumn(gridViewCommits, "LinkedTaskName", "✓ Linked Task", 150, 4);
            
            // Custom draw for special columns
            gridViewCommits.CustomDrawCell += GridViewCommits_CustomDrawCell;

            // Hotspots columns with icons
            gridViewHotspots.Columns.Clear();
            AddColumn(gridViewHotspots, "FileName", "📁 File", 280, 0);
            AddColumn(gridViewHotspots, "ChangeCount", "🔄 Changes", 80, 1);
            AddColumn(gridViewHotspots, "TotalAdditions", "➕ Lines", 80, 2);
            AddColumn(gridViewHotspots, "TotalDeletions", "➖ Lines", 80, 3);
            
            // Custom draw for special columns
            gridViewHotspots.CustomDrawCell += GridViewHotspots_CustomDrawCell;
        }

        private void GridViewCommits_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var cellValue = e.CellValue?.ToString() ?? "";

            switch (e.Column.FieldName)
            {
                case "ShortSha":
                    // SHA as code style
                    e.Appearance.Font = new Font("Consolas", 9F);
                    e.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
                    break;
                    
                case "Message":
                    // Commit message - truncate if too long
                    e.Appearance.ForeColor = Color.FromArgb(226, 232, 240);
                    if (cellValue.Length > 60)
                    {
                        e.DisplayText = cellValue.Substring(0, 57) + "...";
                    }
                    break;
                    
                case "AuthorName":
                    // Author name with accent color
                    e.Appearance.ForeColor = Color.FromArgb(16, 185, 129); // Emerald
                    e.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    break;
                    
                case "CommitDate":
                    // Format date nicely
                    if (DateTime.TryParse(cellValue, out var date))
                    {
                        e.DisplayText = date.ToString("dd MMM, HH:mm");
                    }
                    e.Appearance.ForeColor = Color.FromArgb(148, 163, 184);
                    break;
                    
                case "LinkedTaskName":
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        e.Appearance.ForeColor = Color.FromArgb(168, 85, 247); // Purple
                        e.DisplayText = $"✓ {cellValue}";
                    }
                    else
                    {
                        e.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
                        e.DisplayText = "—";
                    }
                    break;
            }
        }

        private void GridViewHotspots_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var cellValue = e.CellValue?.ToString() ?? "";

            switch (e.Column.FieldName)
            {
                case "FileName":
                    // File name with monospace font
                    e.Appearance.Font = new Font("Consolas", 9F);
                    e.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
                    // Truncate long paths
                    if (cellValue.Length > 40)
                    {
                        e.DisplayText = "..." + cellValue.Substring(cellValue.Length - 37);
                    }
                    break;
                    
                case "ChangeCount":
                    e.Appearance.ForeColor = Color.FromArgb(249, 115, 22); // Orange
                    e.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    break;
                    
                case "TotalAdditions":
                    e.Appearance.ForeColor = Color.FromArgb(34, 197, 94); // Green
                    e.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    e.DisplayText = $"+{cellValue}";
                    break;
                    
                case "TotalDeletions":
                    e.Appearance.ForeColor = Color.FromArgb(239, 68, 68); // Red
                    e.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    e.DisplayText = $"-{cellValue}";
                    break;
            }
        }

        private void SetupLeaderboardLayout()
        {
            // We'll use custom panels instead of LayoutView for better styling
            // The grdLeaderboard will be hidden and we'll create custom cards
            grdLeaderboard.Visible = false;
        }

        private void CreateLeaderboardCards(IEnumerable<LeaderboardEntryDto> leaderboard)
        {
            // Clear existing cards (except title)
            var controlsToRemove = pnlLeaderboard.Controls.Cast<Control>()
                .Where(c => c.Name.StartsWith("card_"))
                .ToList();
            
            foreach (var ctrl in controlsToRemove)
            {
                pnlLeaderboard.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            if (leaderboard == null) return;

            var contributors = leaderboard.ToList();
            int cardWidth = 250;
            int cardHeight = 200;
            int spacing = 15;
            int startX = 17;
            int startY = 55;

            for (int i = 0; i < Math.Min(contributors.Count, 4); i++)
            {
                var contributor = contributors[i];
                var card = CreateContributorCard(contributor, i + 1, cardWidth, cardHeight);
                card.Name = $"card_{i}";
                card.Location = new Point(startX + (i * (cardWidth + spacing)), startY);
                pnlLeaderboard.Controls.Add(card);
            }
        }

        private Panel CreateContributorCard(LeaderboardEntryDto contributor, int rank, int width, int height)
        {
            var card = new Panel
            {
                Size = new Size(width, height),
                BackColor = Color.FromArgb(30, 42, 58),
                Padding = new Padding(15)
            };

            // Top border color based on rank
            var topBorder = new Panel
            {
                Size = new Size(width, 3),
                Location = new Point(0, 0),
                BackColor = rank switch
                {
                    1 => Color.FromArgb(255, 193, 7),   // Gold
                    2 => Color.FromArgb(108, 117, 125), // Silver
                    3 => Color.FromArgb(205, 127, 50),  // Bronze
                    _ => Color.FromArgb(71, 85, 105)    // Gray
                }
            };
            card.Controls.Add(topBorder);

            // Rank badge
            var rankBadge = new Label
            {
                Text = rank.ToString(),
                Size = new Size(28, 28),
                Location = new Point(15, 15),
                BackColor = rank switch
                {
                    1 => Color.FromArgb(255, 193, 7),
                    2 => Color.FromArgb(108, 117, 125),
                    3 => Color.FromArgb(205, 127, 50),
                    _ => Color.FromArgb(71, 85, 105)
                },
                ForeColor = rank <= 3 ? Color.FromArgb(26, 31, 38) : Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            // Make it circular-ish
            rankBadge.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, rankBadge.Width - 1, rankBadge.Height - 1);
                rankBadge.Region = new Region(path);
            };
            card.Controls.Add(rankBadge);

            // Username
            var lblUsername = new Label
            {
                Text = contributor.Author ?? "Unknown",
                Location = new Point(50, 15),
                Size = new Size(width - 100, 22),
                ForeColor = Color.FromArgb(248, 250, 252),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                AutoEllipsis = true
            };
            card.Controls.Add(lblUsername);

            // Role label
            var roleText = rank switch
            {
                1 => "TOP CONTRIBUTOR",
                2 => "MAINTAINER",
                3 => "DEVELOPER",
                _ => "CONTRIBUTOR"
            };
            var roleColor = rank switch
            {
                1 => Color.FromArgb(34, 197, 94),  // Green
                2 => Color.FromArgb(59, 130, 246), // Blue
                3 => Color.FromArgb(249, 115, 22), // Orange
                _ => Color.FromArgb(148, 163, 184) // Gray
            };
            var lblRole = new Label
            {
                Text = roleText,
                Location = new Point(50, 38),
                Size = new Size(width - 100, 16),
                ForeColor = roleColor,
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold)
            };
            card.Controls.Add(lblRole);

            // Trophy icon for top 3
            if (rank <= 3)
            {
                var lblTrophy = new Label
                {
                    Text = "🏆",
                    Location = new Point(width - 40, 15),
                    Size = new Size(25, 25),
                    Font = new Font("Segoe UI", 14F),
                    ForeColor = rank switch
                    {
                        1 => Color.FromArgb(255, 193, 7),
                        2 => Color.FromArgb(192, 192, 192),
                        _ => Color.FromArgb(205, 127, 50)
                    }
                };
                card.Controls.Add(lblTrophy);
            }

            // Commit count (big number)
            var lblCommitCount = new Label
            {
                Text = contributor.CommitCount.ToString("N0"),
                Location = new Point(15, 70),
                Size = new Size(100, 40),
                ForeColor = Color.FromArgb(248, 250, 252),
                Font = new Font("Segoe UI", 24F, FontStyle.Bold)
            };
            card.Controls.Add(lblCommitCount);

            var lblCommitLabel = new Label
            {
                Text = "Total Commits",
                Location = new Point(115, 85),
                Size = new Size(100, 20),
                ForeColor = Color.FromArgb(148, 163, 184),
                Font = new Font("Segoe UI", 9F)
            };
            card.Controls.Add(lblCommitLabel);

            // Lines section with separator
            var separator = new Panel
            {
                Size = new Size(width - 30, 1),
                Location = new Point(15, 120),
                BackColor = Color.FromArgb(51, 65, 85)
            };
            card.Controls.Add(separator);

            // + Lines
            var lblPlusLabel = new Label
            {
                Text = "+ LINES",
                Location = new Point(15, 130),
                Size = new Size(80, 15),
                ForeColor = Color.FromArgb(34, 197, 94),
                Font = new Font("Segoe UI", 7F, FontStyle.Bold)
            };
            card.Controls.Add(lblPlusLabel);

            var lblPlusValue = new Label
            {
                Text = $"+{contributor.Additions:N0}",
                Location = new Point(15, 145),
                Size = new Size(100, 25),
                ForeColor = Color.FromArgb(248, 250, 252),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            card.Controls.Add(lblPlusValue);

            // - Lines
            var lblMinusLabel = new Label
            {
                Text = "- LINES",
                Location = new Point(width / 2, 130),
                Size = new Size(80, 15),
                ForeColor = Color.FromArgb(239, 68, 68),
                Font = new Font("Segoe UI", 7F, FontStyle.Bold)
            };
            card.Controls.Add(lblMinusLabel);

            var lblMinusValue = new Label
            {
                Text = $"-{contributor.Deletions:N0}",
                Location = new Point(width / 2, 145),
                Size = new Size(100, 25),
                ForeColor = Color.FromArgb(248, 250, 252),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            card.Controls.Add(lblMinusValue);

            // Record info at bottom
            var lblRecord = new Label
            {
                Text = $"RECORD {rank} OF {Math.Min(4, rank + 3)}",
                Location = new Point(15, height - 25),
                Size = new Size(120, 15),
                ForeColor = Color.FromArgb(100, 116, 139),
                Font = new Font("Segoe UI", 7F)
            };
            card.Controls.Add(lblRecord);

            return card;
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
                    
                    // Create custom leaderboard cards
                    CreateLeaderboardCards(summary.Leaderboard);
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
