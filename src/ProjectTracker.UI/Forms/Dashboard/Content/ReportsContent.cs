using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using ProjectTracker.Business.DTOs.Statistics;
using ProjectTracker.Business.DTOs.Analytics;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using ProjectTracker.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    /// <summary>
    /// Reports and analytics content control
    /// Provides KPI dashboard, statistics, and data visualization
    /// </summary>
    public partial class ReportsContent : UserControl
    {
        #region Fields
        
        private readonly IReportService _reportService;
        private readonly IProjectService _projectService;
        private readonly IAdvancedReportService _advancedReportService;
        
        private ProjectStatisticsDto _projectStats;
        private TaskStatisticsDto _taskStats;
        private IEnumerable<TrendDataDto> _trendData;
        
        // Advanced analytics data
        private List<Business.DTOs.ProjectDto>? _allProjects;
        private int? _selectedProjectId;
        
        #endregion
        
        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of ReportsContent
        /// </summary>
        /// <param name="reportService">Report service instance</param>
        /// <param name="projectService">Project service instance</param>
        /// <param name="advancedReportService">Advanced report service instance</param>
        public ReportsContent(IReportService reportService, IProjectService projectService, IAdvancedReportService advancedReportService)
        {
            InitializeComponent();
            _reportService = reportService;
            _projectService = projectService;
            _advancedReportService = advancedReportService;
            
            ApplyColorPalette();
            SetupEventHandlers();
        }
        
        /// <summary>
        /// Parameterless constructor for Designer
        /// </summary>
        public ReportsContent()
        {
            InitializeComponent();
        }
        
        #endregion
        
        #region Setup Methods
        
        /// <summary>
        /// Apply ColorPalette to all controls with explicit options
        /// </summary>
        private void ApplyColorPalette()
        {
            // Background with explicit options
            this.BackColor = ColorPalette.BackgroundDeepNavy;
            
            pnlHeader.Appearance.BackColor = ColorPalette.BackgroundDeepNavy;
            pnlHeader.Appearance.Options.UseBackColor = true;
            
            pnlFilters.Appearance.BackColor = ColorPalette.BackgroundSlateDark;
            pnlFilters.Appearance.Options.UseBackColor = true;
            
            pnlKPIContainer.Appearance.BackColor = ColorPalette.BackgroundDeepNavy;
            pnlKPIContainer.Appearance.Options.UseBackColor = true;
            
            pnlChartsContainer.Appearance.BackColor = ColorPalette.BackgroundDeepNavy;
            pnlChartsContainer.Appearance.Options.UseBackColor = true;
            
            // Apply dark theme scrollbar styling to charts container only
            ApplyDarkScrollbarStyle();
            
            // Header
            lblTitle.Appearance.ForeColor = ColorPalette.TextPrimary;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.Appearance.ForeColor = ColorPalette.TextSecondary;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            
            // Export buttons with modern styling
            btnExportPdf.Appearance.BackColor = ColorPalette.AccentRoyalBlue;
            btnExportPdf.Appearance.ForeColor = ColorPalette.TextPrimary;
            btnExportPdf.Appearance.Options.UseBackColor = true;
            btnExportPdf.Appearance.Options.UseForeColor = true;
            
            btnExportExcel.Appearance.BackColor = ColorPalette.SuccessGreen;
            btnExportExcel.Appearance.ForeColor = ColorPalette.TextPrimary;
            btnExportExcel.Appearance.Options.UseBackColor = true;
            btnExportExcel.Appearance.Options.UseForeColor = true;
            
            // Filters with proper theming
            lblTo.Appearance.ForeColor = ColorPalette.TextSecondary;
            lblTo.Appearance.Options.UseForeColor = true;
            
            dateStart.Properties.Appearance.BackColor = ColorPalette.BackgroundSlateMedium;
            dateStart.Properties.Appearance.ForeColor = ColorPalette.TextPrimary;
            dateStart.Properties.Appearance.Options.UseBackColor = true;
            dateStart.Properties.Appearance.Options.UseForeColor = true;
            
            dateEnd.Properties.Appearance.BackColor = ColorPalette.BackgroundSlateMedium;
            dateEnd.Properties.Appearance.ForeColor = ColorPalette.TextPrimary;
            dateEnd.Properties.Appearance.Options.UseBackColor = true;
            dateEnd.Properties.Appearance.Options.UseForeColor = true;
            
            cmbProjectFilter.Properties.Appearance.BackColor = ColorPalette.BackgroundSlateMedium;
            cmbProjectFilter.Properties.Appearance.ForeColor = ColorPalette.TextPrimary;
            cmbProjectFilter.Properties.Appearance.Options.UseBackColor = true;
            cmbProjectFilter.Properties.Appearance.Options.UseForeColor = true;
            
            btnApplyFilter.Appearance.BackColor = ColorPalette.AccentRoyalBlue;
            btnApplyFilter.Appearance.ForeColor = ColorPalette.TextPrimary;
            btnApplyFilter.Appearance.Options.UseBackColor = true;
            btnApplyFilter.Appearance.Options.UseForeColor = true;
            
            // KPI Cards with enhanced theming
            ApplyKPICardColors(pnlKPICard1, lblKPI1Value, lblKPI1Title, ColorPalette.AccentRoyalBlue);
            ApplyKPICardColors(pnlKPICard2, lblKPI2Value, lblKPI2Title, ColorPalette.SuccessGreen);
            ApplyKPICardColors(pnlKPICard3, lblKPI3Value, lblKPI3Title, ColorPalette.WarningAmber);
            ApplyKPICardColors(pnlKPICard4, lblKPI4Value, lblKPI4Title, ColorPalette.AccentLightBlue);
        }
        
        /// <summary>
        /// Apply colors to a KPI card
        /// </summary>
        /// <param name="card">Card panel control</param>
        /// <param name="value">Value label control</param>
        /// <param name="title">Title label control</param>
        /// <param name="valueColor">Color for the value</param>
        private void ApplyKPICardColors(PanelControl card, LabelControl value, LabelControl title, Color valueColor)
        {
            card.Appearance.BackColor = ColorPalette.BackgroundSlateDark;
            card.Appearance.BorderColor = ColorPalette.BorderSlate;
            value.Appearance.ForeColor = valueColor;
            title.Appearance.ForeColor = ColorPalette.TextSecondary;
        }
        
        /// <summary>
        /// Apply dark theme scrollbar styling to charts container
        /// </summary>
        private void ApplyDarkScrollbarStyle()
        {
            // Use DevExpress LookAndFeel for dark scrollbar
            pnlChartsContainer.LookAndFeel.UseDefaultLookAndFeel = false;
            pnlChartsContainer.LookAndFeel.SkinName = "Office 2019 Black";
        }
        
        // SuperToolTip controller for help icons
        private DevExpress.Utils.ToolTipController _toolTipController;
        
        /// <summary>
        /// Add help icon with tooltip to a panel
        /// </summary>
        private void AddHelpIcon(Control parent, string title, string helpText, int rightOffset = 10, int topOffset = 5)
        {
            var helpLabel = new LabelControl
            {
                Text = "ⓘ",
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(18, 18),
                Location = new Point(parent.Width - rightOffset - 18, topOffset),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Help
            };
            // Dark blue color for visibility on both dark and light backgrounds
            helpLabel.Appearance.ForeColor = ColorPalette.AccentRoyalBlue;
            helpLabel.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            
            // Create SuperToolTip with dark theme styling
            var superTip = new DevExpress.Utils.SuperToolTip();
            superTip.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            
            // Header with blue color
            var headerItem = new DevExpress.Utils.ToolTipTitleItem();
            headerItem.Text = title;
            headerItem.Appearance.BackColor = Color.FromArgb(45, 55, 72);
            headerItem.Appearance.ForeColor = Color.FromArgb(91, 155, 213);
            headerItem.Appearance.Options.UseBackColor = true;
            headerItem.Appearance.Options.UseForeColor = true;
            headerItem.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerItem.Appearance.Options.UseFont = true;
            
            // Content with white text
            var contentItem = new DevExpress.Utils.ToolTipItem();
            contentItem.Text = helpText;
            contentItem.Appearance.BackColor = Color.FromArgb(45, 55, 72);
            contentItem.Appearance.ForeColor = Color.FromArgb(226, 232, 240);
            contentItem.Appearance.Options.UseBackColor = true;
            contentItem.Appearance.Options.UseForeColor = true;
            
            superTip.Items.Add(headerItem);
            superTip.Items.Add(contentItem);
            
            _toolTipController.SetSuperTip(helpLabel, superTip);
            parent.Controls.Add(helpLabel);
            helpLabel.BringToFront();
        }
        
        /// <summary>
        /// Setup help tooltips for KPI cards
        /// </summary>
        private void SetupKPIHelpTooltips()
        {
            // KPI Card 1: Budget Usage
            AddHelpIcon(pnlKPICard1, "Budget Usage", "Total budget utilization rate.\nSpent / Planned budget percentage.", 8, 5);
            
            // KPI Card 2: Avg Cost Performance
            AddHelpIcon(pnlKPICard2, "Cost Performance Index", "CPI measures cost efficiency.\n≥1.0 = Under budget, <1.0 = Over budget.", 8, 5);
            
            // KPI Card 3: Avg Risk Score
            AddHelpIcon(pnlKPICard3, "Risk Score", "Average risk score (0-100).\n<30 Low, 30-70 Medium, >70 High risk.", 8, 5);
            
            // KPI Card 4: Active Projects
            AddHelpIcon(pnlKPICard4, "Active Projects", "Number of currently active projects.\nExcludes planning and completed.", 8, 5);
        }
        
        /// <summary>
        /// Setup event handlers
        /// </summary>
        private void SetupEventHandlers()
        {
            // Initialize tooltip controller with dark skin
            _toolTipController = new DevExpress.Utils.ToolTipController();
            _toolTipController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            _toolTipController.AutoPopDelay = 8000;
            _toolTipController.InitialDelay = 200;
            _toolTipController.ReshowDelay = 100;
            
            // Setup KPI help icons
            SetupKPIHelpTooltips();
            
            btnApplyFilter.Click += async (s, e) => await LoadDataAsync();
            btnExportPdf.Click += BtnExportPdf_Click;
            btnExportExcel.Click += BtnExportExcel_Click;
            
            // Proje filtresi değiştiğinde otomatik yenile
            cmbProjectFilter.SelectedIndexChanged += async (s, e) => await LoadDataAsync();
            
            // Set default date range (last 30 days)
            dateStart.DateTime = DateTime.Now.AddDays(-30);
            dateEnd.DateTime = DateTime.Now;
            
            // Load data on control load
            this.Load += async (s, e) => await LoadDataAsync();
        }
        
        #endregion
        
        #region Data Loading
        
        // Proje listesi yüklendi mi flag'i
        private bool _projectsLoaded = false;
        // Yükleme devam ediyor mu flag'i (concurrent çağrıları önlemek için)
        private bool _isLoading = false;
        
        /// <summary>
        /// Load statistics data
        /// </summary>
        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            // Eğer zaten yükleme yapılıyorsa, tekrar başlatma
            if (_isLoading) return;
            
            try
            {
                _isLoading = true;
                Cursor = Cursors.WaitCursor;
                
                DateTime? startDate = dateStart.EditValue as DateTime?;
                DateTime? endDate = dateEnd.EditValue as DateTime?;
                
                // ROL BAZLI PROJE LİSTESİ - sadece ilk yüklemede doldur
                if (!_projectsLoaded)
                {
                    if (SessionManager.IsAdmin)
                    {
                        _allProjects = (await _projectService.GetAllAsync()).ToList();
                    }
                    else
                    {
                        // ProjectManager/Developer: Sadece üye oldukları takımlara ait projeler
                        _allProjects = (await _projectService.GetUserProjectsAsync(SessionManager.CurrentUserId)).ToList();
                    }
                    
                    // Proje filtresi dropdown'ını doldur (sadece bir kez)
                    cmbProjectFilter.Properties.Items.Clear();
                    cmbProjectFilter.Properties.Items.Add("All Projects");
                    if (_allProjects != null && _allProjects.Any())
                    {
                        foreach (var project in _allProjects)
                        {
                            cmbProjectFilter.Properties.Items.Add(project.ProjectName);
                        }
                    }
                    cmbProjectFilter.SelectedIndex = 0;
                    _projectsLoaded = true;
                }
                
                // Seçili proje ID'lerini belirle
                List<int>? filterProjectIds = null;
                if (cmbProjectFilter.SelectedIndex > 0 && _allProjects != null)
                {
                    // Tek proje seçili
                    var selectedProjectName = cmbProjectFilter.Text;
                    var selectedProject = _allProjects.FirstOrDefault(p => p.ProjectName == selectedProjectName);
                    if (selectedProject != null)
                    {
                        filterProjectIds = new List<int> { selectedProject.ProjectId };
                        _selectedProjectId = selectedProject.ProjectId;
                    }
                }
                else if (_allProjects != null && _allProjects.Any())
                {
                    // "All Projects" seçili - kullanıcının erişebildiği tüm projeler
                    filterProjectIds = _allProjects.Select(p => p.ProjectId).ToList();
                    _selectedProjectId = null;
                }
                
                // İstatistikleri sırayla al (DbContext thread safety için)
                _projectStats = await _reportService.GetProjectStatisticsAsync(startDate, endDate, filterProjectIds);
                _taskStats = await _reportService.GetTaskStatisticsAsync(startDate, endDate, filterProjectIds);
                _trendData = await _reportService.GetCompletionTrendAsync(30, filterProjectIds);
                
                // Update KPI cards with advanced metrics
                await UpdateKPICardsAsync();
                
                // Create charts
                await CreateAllChartsAsync();
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error loading data: {ex.Message}");
            }
            finally
            {
                _isLoading = false;
                Cursor = Cursors.Default;
            }
        }
        
        /// <summary>
        /// Update KPI card values with advanced analytics
        /// </summary>
        private async System.Threading.Tasks.Task UpdateKPICardsAsync()
        {
            if (_projectStats == null || _taskStats == null || _allProjects == null)
                return;
            
            try
            {
                // Tarih ve proje filtrelerini al
                DateTime? startDate = dateStart.EditValue as DateTime?;
                DateTime? endDate = dateEnd.EditValue as DateTime?;
                var filterProjectIds = _allProjects.Select(p => p.ProjectId).ToList();
                
                // Tek proje seçiliyse sadece o projeyi filtrele
                if (_selectedProjectId.HasValue)
                {
                    filterProjectIds = new List<int> { _selectedProjectId.Value };
                }
                
                // Card 1: Budget Usage (filtrelenmiş projeler ve tarih aralığı için)
                var financialOverview = await _advancedReportService.GetFinancialOverviewAsync(startDate, endDate, filterProjectIds);
                lblKPI1Title.Text = "Budget Usage";
                lblKPI1Value.Text = $"{financialOverview.BudgetUtilizationPercentage:F0}%";
                lblKPI1Icon.Text = "💰";
                
                // Card 2: Average CPI (filtrelenmiş projeler için)
                var portfolioEVM = await _advancedReportService.GetPortfolioEarnedValueAsync(filterProjectIds);
                var avgCPI = portfolioEVM.Any() ? portfolioEVM.Average(e => e.CPI) : 1.0m;
                lblKPI2Title.Text = "Avg Cost Perf.";
                lblKPI2Value.Text = $"{avgCPI:F2}";
                lblKPI2Icon.Text = avgCPI >= 1.0m ? "✅" : "⚠️";
                
                // Card 3: Average Risk Score (filtrelenmiş projeler için)
                var projectsToAnalyze = _selectedProjectId.HasValue 
                    ? _allProjects.Where(p => p.ProjectId == _selectedProjectId.Value).ToList()
                    : _allProjects;
                var avgRisk = projectsToAnalyze.Where(p => p.RiskScore.HasValue).Any() 
                    ? projectsToAnalyze.Where(p => p.RiskScore.HasValue).Average(p => p.RiskScore.Value) 
                    : 0m;
                lblKPI3Title.Text = "Avg Risk Score";
                lblKPI3Value.Text = $"{avgRisk:F0}";
                lblKPI3Icon.Text = avgRisk < 30 ? "🟢" : avgRisk < 70 ? "🟡" : "🔴";
                
                // Card 4: Active Projects (filtrelenmiş projeler için)
                lblKPI4Title.Text = "Active Projects";
                var activeCount = projectsToAnalyze.Count(p => p.Status == Core.Enums.ProjectStatus.Active);
                lblKPI4Value.Text = activeCount.ToString();
                lblKPI4Icon.Text = "⚡";
            }
            catch
            {
                // Fallback to basic metrics
                lblKPI1Value.Text = _projectStats.ActiveProjects.ToString();
                lblKPI1Title.Text = "Active Projects";
                lblKPI2Value.Text = _taskStats.CompletedTasks.ToString();
                lblKPI2Title.Text = "Completed Tasks";
                lblKPI3Value.Text = "N/A";
                lblKPI4Value.Text = $"{_projectStats.AverageCompletionRate:F1}%";
            }
        }
        
        #endregion
        
        #region Chart Creation
        
        // Chart layout constants
        private const int ChartWidth = 510;
        private const int ChartHeight = 350;
        private const int ChartMargin = 20;
        private int _currentChartRow = 0;
        private int _currentChartCol = 0;
        
        /// <summary>
        /// Get next chart position and advance to next slot
        /// </summary>
        private Point GetNextChartPosition()
        {
            int x = ChartMargin + (_currentChartCol * (ChartWidth + ChartMargin));
            int y = ChartMargin + (_currentChartRow * (ChartHeight + ChartMargin));
            
            // Move to next column, wrap to next row if needed
            _currentChartCol++;
            if (_currentChartCol >= 2) // 2 charts per row
            {
                _currentChartCol = 0;
                _currentChartRow++;
            }
            
            return new Point(x, y);
        }
        
        /// <summary>
        /// Create all charts dynamically with advanced analytics
        /// </summary>
        private async System.Threading.Tasks.Task CreateAllChartsAsync()
        {
            // Clear existing charts and reset position
            pnlChartsContainer.Controls.Clear();
            _currentChartRow = 0;
            _currentChartCol = 0;
            
            if (_projectStats != null && _taskStats != null && _trendData != null)
            {
                // Row 1: Basic charts
                CreateProjectStatusChart();
                CreateTasksPriorityChart();
                
                // Row 2: Advanced analytics charts
                await CreateRiskAnalysisChartAsync();
                await CreateEVMDashboardAsync();
                
                // Row 3: Project-specific or trend charts
                if (_selectedProjectId.HasValue)
                {
                    await CreateBurndownChartAsync(_selectedProjectId.Value);
                }
                
                await CreateVelocityTrendChartAsync();
                CreateCompletionTrendChart();
                
                // Update container size for scrolling
                int totalHeight = ChartMargin + ((_currentChartRow + 1) * (ChartHeight + ChartMargin));
                pnlChartsContainer.AutoScrollMinSize = new Size(0, totalHeight);
            }
        }
        
        /// <summary>
        /// Create project status pie chart
        /// </summary>
        private void CreateProjectStatusChart()
        {
            var chartControl = new ChartControl
            {
                Location = GetNextChartPosition(),
                Size = new Size(ChartWidth, ChartHeight),
                BackColor = ColorPalette.BackgroundSlateDark
            };
            
            var series = new Series("Project Status", ViewType.Pie);
            
            // Calculate planning projects
            int planningProjects = _projectStats.TotalProjects - _projectStats.ActiveProjects - 
                _projectStats.CompletedProjects - _projectStats.OnHoldProjects - _projectStats.CancelledProjects;
            
            series.Points.Add(new SeriesPoint("Planning", planningProjects));
            series.Points.Add(new SeriesPoint("Active", _projectStats.ActiveProjects));
            series.Points.Add(new SeriesPoint("Completed", _projectStats.CompletedProjects));
            series.Points.Add(new SeriesPoint("On Hold", _projectStats.OnHoldProjects));
            series.Points.Add(new SeriesPoint("Cancelled", _projectStats.CancelledProjects));
            
            // Apply colors
            series.Points[0].Color = ColorPalette.AccentLightBlue;
            series.Points[1].Color = ColorPalette.WarningAmber;
            series.Points[2].Color = ColorPalette.SuccessGreen;
            series.Points[3].Color = ColorPalette.TextDisabled;
            series.Points[4].Color = ColorPalette.DangerRed;
            
            var pieView = (PieSeriesView)series.View;
            pieView.RuntimeExploding = true;
            pieView.ExplodedDistancePercentage = 10;
            
            chartControl.Series.Add(series);
            
            chartControl.Legend.Visible = true;
            chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            chartControl.Legend.AlignmentVertical = LegendAlignmentVertical.Top;
            chartControl.Legend.TextColor = ColorPalette.TextPrimary;
            chartControl.Legend.BackColor = Color.Transparent;
            chartControl.Legend.Font = new Font("Segoe UI", 9);
            
            var title = new ChartTitle
            {
                Text = "Project Status Distribution",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextColor = ColorPalette.TextPrimary,
                Dock = ChartTitleDockStyle.Top,
                Alignment = StringAlignment.Near
            };
            chartControl.Titles.Add(title);
            chartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            
            pnlChartsContainer.Controls.Add(chartControl);
            
            // Add help icon to chart
            AddHelpIcon(chartControl, "Project Status", "Distribution of projects by status.\nPlanning, Active, Completed, On Hold, Cancelled.", 10, 5);
        }
        
        /// <summary>
        /// Create tasks by priority bar chart
        /// </summary>
        private void CreateTasksPriorityChart()
        {
            var chartControl = new ChartControl
            {
                Location = GetNextChartPosition(),
                Size = new Size(ChartWidth, ChartHeight),
                BackColor = ColorPalette.BackgroundSlateDark
            };
            
            var series = new Series("Tasks by Priority", ViewType.Bar);
            
            series.Points.Add(new SeriesPoint("Critical", 
                _taskStats.TasksByPriority.ContainsKey(Priority.Critical) ? _taskStats.TasksByPriority[Priority.Critical] : 0));
            series.Points.Add(new SeriesPoint("High", 
                _taskStats.TasksByPriority.ContainsKey(Priority.High) ? _taskStats.TasksByPriority[Priority.High] : 0));
            series.Points.Add(new SeriesPoint("Medium", 
                _taskStats.TasksByPriority.ContainsKey(Priority.Medium) ? _taskStats.TasksByPriority[Priority.Medium] : 0));
            series.Points.Add(new SeriesPoint("Low", 
                _taskStats.TasksByPriority.ContainsKey(Priority.Low) ? _taskStats.TasksByPriority[Priority.Low] : 0));
            
            series.Points[0].Color = ColorPalette.DangerRed;
            series.Points[1].Color = ColorPalette.WarningOrange;
            series.Points[2].Color = ColorPalette.WarningAmber;
            series.Points[3].Color = ColorPalette.CategoryBlue;
            
            chartControl.Series.Add(series);
            
            var diagram = (XYDiagram)chartControl.Diagram;
            diagram.AxisX.Label.TextColor = ColorPalette.TextSecondary;
            diagram.AxisX.Label.Font = new Font("Segoe UI", 9);
            diagram.AxisY.Label.TextColor = ColorPalette.TextSecondary;
            diagram.AxisY.Label.Font = new Font("Segoe UI", 9);
            diagram.AxisX.Color = ColorPalette.BorderSlate;
            diagram.AxisY.Color = ColorPalette.BorderSlate;
            diagram.AxisX.GridLines.Visible = false;
            diagram.AxisY.GridLines.Color = ColorPalette.BorderSlate;
            diagram.DefaultPane.BackColor = Color.Transparent;
            
            var title = new ChartTitle
            {
                Text = "Tasks by Priority",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextColor = ColorPalette.TextPrimary,
                Dock = ChartTitleDockStyle.Top,
                Alignment = StringAlignment.Near
            };
            chartControl.Titles.Add(title);
            chartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chartControl.Legend.Visible = false;
            
            pnlChartsContainer.Controls.Add(chartControl);
            
            // Add help icon to chart
            AddHelpIcon(chartControl, "Tasks by Priority", "Task distribution by priority level.\nCritical, High, Medium, Low.", 10, 5);
        }
        
        /// <summary>
        /// Create 30-day completion trend line chart
        /// </summary>
        private void CreateCompletionTrendChart()
        {
            var chartControl = new ChartControl
            {
                Location = GetNextChartPosition(),
                Size = new Size(ChartWidth, ChartHeight),
                BackColor = ColorPalette.BackgroundSlateDark
            };
            
            var series = new Series("Completed Tasks", ViewType.Line);
            
            foreach (var dataPoint in _trendData)
            {
                series.Points.Add(new SeriesPoint(dataPoint.Date.ToString("MMM dd"), dataPoint.CompletedTasks));
            }
            
            var lineView = (LineSeriesView)series.View;
            lineView.Color = ColorPalette.SuccessGreen;
            lineView.LineStyle.Thickness = 3;
            lineView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            lineView.LineMarkerOptions.Size = 8;
            lineView.LineMarkerOptions.Kind = MarkerKind.Circle;
            lineView.LineMarkerOptions.BorderColor = ColorPalette.SuccessGreen;
            
            chartControl.Series.Add(series);
            
            var diagram = (XYDiagram)chartControl.Diagram;
            diagram.EnableAxisXZooming = true;
            diagram.EnableAxisXScrolling = true;
            diagram.AxisX.Label.TextColor = ColorPalette.TextSecondary;
            diagram.AxisX.Label.Font = new Font("Segoe UI", 8);
            diagram.AxisX.Label.Angle = -45;
            diagram.AxisY.Label.TextColor = ColorPalette.TextSecondary;
            diagram.AxisY.Label.Font = new Font("Segoe UI", 9);
            diagram.AxisX.Color = ColorPalette.BorderSlate;
            diagram.AxisY.Color = ColorPalette.BorderSlate;
            diagram.AxisX.GridLines.Visible = false;
            diagram.AxisY.GridLines.Color = ColorPalette.BorderSlate;
            diagram.DefaultPane.BackColor = Color.Transparent;
            
            var title = new ChartTitle
            {
                Text = "30-Day Completion Trend",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextColor = ColorPalette.TextPrimary,
                Dock = ChartTitleDockStyle.Top,
                Alignment = StringAlignment.Near
            };
            chartControl.Titles.Add(title);
            chartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chartControl.Legend.Visible = false;
            
            pnlChartsContainer.Controls.Add(chartControl);
            
            // Add help icon to chart
            AddHelpIcon(chartControl, "Completion Trend", "Tasks completed per day over 30 days.\nShows daily completion rate.", 10, 5);
        }
        
        /// <summary>
        /// Create team productivity bar chart
        /// </summary>
        private void CreateTeamProductivityChart()
        {
            var chartControl = new ChartControl
            {
                Location = GetNextChartPosition(),
                Size = new Size(ChartWidth, ChartHeight),
                BackColor = ColorPalette.BackgroundSlateDark
            };
            
            var series = new Series("Completed Tasks", ViewType.Bar);
            
            // Sample data (will be replaced with real team data when ITeamService integrated)
            series.Points.Add(new SeriesPoint("Product Team", 45));
            series.Points.Add(new SeriesPoint("Marketing Team", 28));
            series.Points.Add(new SeriesPoint("Dev Team", 62));
            
            series.Points[0].Color = ColorPalette.CategoryPurple;
            series.Points[1].Color = ColorPalette.CategoryTeal;
            series.Points[2].Color = ColorPalette.AccentRoyalBlue;
            
            chartControl.Series.Add(series);
            
            var diagram = (XYDiagram)chartControl.Diagram;
            diagram.AxisX.Label.TextColor = ColorPalette.TextSecondary;
            diagram.AxisY.Label.TextColor = ColorPalette.TextSecondary;
            diagram.AxisX.Color = ColorPalette.BorderSlate;
            diagram.AxisY.Color = ColorPalette.BorderSlate;
            diagram.AxisX.GridLines.Visible = false;
            diagram.AxisY.GridLines.Color = ColorPalette.BorderSlate;
            diagram.DefaultPane.BackColor = Color.Transparent;
            
            var title = new ChartTitle
            {
                Text = "Team Productivity (Completed Tasks)",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextColor = ColorPalette.TextPrimary,
                Dock = ChartTitleDockStyle.Top,
                Alignment = StringAlignment.Near
            };
            chartControl.Titles.Add(title);
            chartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            chartControl.Legend.Visible = false;
            
            pnlChartsContainer.Controls.Add(chartControl);
        }
        
        #region Advanced Analytics Charts
        
        /// <summary>
        /// Create Risk Analysis bubble chart - Risk Score vs Completion %
        /// </summary>
        private async System.Threading.Tasks.Task CreateRiskAnalysisChartAsync()
        {
            if (_allProjects == null || !_allProjects.Any()) return;
            
            var chartControl = new ChartControl
            {
                Location = GetNextChartPosition(),
                Size = new Size(ChartWidth, ChartHeight),
                BackColor = ColorPalette.BackgroundSlateDark
            };
            
            var series = new Series("Risk Analysis", ViewType.Point);
            
            // Collect all points first
            var points = new List<SeriesPoint>();
            var colors = new List<System.Drawing.Color>();
            
            foreach (var project in _allProjects.Where(p => p.RiskScore.HasValue))
            {
                var point = new SeriesPoint(project.CompletionPercentage, project.RiskScore.Value);
                point.Tag = project.ProjectName;
                points.Add(point);
                
                // Determine color by risk level
                if (project.RiskScore < 30)
                    colors.Add(ColorPalette.SuccessGreen);
                else if (project.RiskScore < 70)
                    colors.Add(ColorPalette.WarningAmber);
                else
                    colors.Add(ColorPalette.DangerRed);
            }
            
            // Add points and set colors
            for (int i = 0; i < points.Count; i++)
            {
                series.Points.Add(points[i]);
                series.Points[i].Color = colors[i];
            }
            
            var pointView = (PointSeriesView)series.View;
            pointView.PointMarkerOptions.Size = 12;
            pointView.PointMarkerOptions.Kind = MarkerKind.Circle;
            
            chartControl.Series.Add(series);
            
            var diagram = (XYDiagram)chartControl.Diagram;
            diagram.AxisX.Title.Text = "Completion %";
            diagram.AxisX.Title.TextColor = ColorPalette.TextSecondary;
            diagram.AxisY.Title.Text = "Risk Score";
            diagram.AxisY.Title.TextColor = ColorPalette.TextSecondary;
            diagram.AxisX.Label.TextColor = ColorPalette.TextSecondary;
            diagram.AxisY.Label.TextColor = ColorPalette.TextSecondary;
            diagram.AxisX.Color = ColorPalette.BorderSlate;
            diagram.AxisY.Color = ColorPalette.BorderSlate;
            diagram.AxisY.GridLines.Color = ColorPalette.BorderSlate;
            diagram.DefaultPane.BackColor = Color.Transparent;
            
            var title = new ChartTitle
            {
                Text = "Risk Analysis - Project Health",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextColor = ColorPalette.TextPrimary,
                Dock = ChartTitleDockStyle.Top
            };
            chartControl.Titles.Add(title);
            chartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            
            pnlChartsContainer.Controls.Add(chartControl);
            
            // Add help icon to chart
            AddHelpIcon(chartControl, "Risk Analysis", "Risk score vs completion percentage.\nGreen=Low, Yellow=Medium, Red=High.", 10, 5);
        }
        
        /// <summary>
        /// Create EVM Dashboard with portfolio-level metrics
        /// </summary>
        private async System.Threading.Tasks.Task CreateEVMDashboardAsync()
        {
            try
            {
                // Filtrelenmiş proje ID'lerini al
                List<int> filterProjectIds;
                if (_selectedProjectId.HasValue)
                {
                    filterProjectIds = new List<int> { _selectedProjectId.Value };
                }
                else if (_allProjects != null)
                {
                    filterProjectIds = _allProjects.Select(p => p.ProjectId).ToList();
                }
                else
                {
                    return;
                }
                
                var portfolioEVM = await _advancedReportService.GetPortfolioEarnedValueAsync(filterProjectIds);
                if (!portfolioEVM.Any()) return;
                
                var chartControl = new ChartControl
                {
                    Location = GetNextChartPosition(),
                    Size = new Size(ChartWidth, ChartHeight),
                    BackColor = ColorPalette.BackgroundSlateDark
                };
                
                var series = new Series("EVM Metrics", ViewType.Bar);
                
                var avgCPI = portfolioEVM.Average(e => e.CPI);
                var avgSPI = portfolioEVM.Average(e => e.SPI);
                
                series.Points.Add(new SeriesPoint("CPI", avgCPI));
                series.Points.Add(new SeriesPoint("SPI", avgSPI));
                
                // Color coding: Green if >=1, Red if <0.9, Orange between
                series.Points[0].Color = avgCPI >= 1.0m ? ColorPalette.SuccessGreen : 
                                          avgCPI >= 0.9m ? ColorPalette.WarningAmber : ColorPalette.DangerRed;
                series.Points[1].Color = avgSPI >= 1.0m ? ColorPalette.SuccessGreen : 
                                          avgSPI >= 0.9m ? ColorPalette.WarningAmber : ColorPalette.DangerRed;
                
                chartControl.Series.Add(series);
                
                var diagram = (XYDiagram)chartControl.Diagram;
                diagram.AxisX.Label.TextColor = ColorPalette.TextSecondary;
                diagram.AxisY.Label.TextColor = ColorPalette.TextSecondary;
                diagram.AxisX.Color = ColorPalette.BorderSlate;
                diagram.AxisY.Color = ColorPalette.BorderSlate;
                diagram.AxisY.GridLines.Color = ColorPalette.BorderSlate;
                diagram.DefaultPane.BackColor = Color.Transparent;
                
                // Add target line at 1.0
                var constantLine = new ConstantLine("Target", 1.0);
                constantLine.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dash;
                diagram.AxisY.ConstantLines.Add(constantLine);
                
                var title = new ChartTitle
                {
                    Text = "EVM Performance Indicators (Portfolio Avg)",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextColor = ColorPalette.TextPrimary,
                    Dock = ChartTitleDockStyle.Top
                };
                chartControl.Titles.Add(title);
                chartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                chartControl.Legend.Visible = false;
                
                pnlChartsContainer.Controls.Add(chartControl);
                
                // Add help icon to chart
                AddHelpIcon(chartControl, "EVM Indicators", "CPI: Cost performance, SPI: Schedule performance.\n≥1.0 target, <0.9 critical.", 10, 5);
            }
            catch { /* Skip if no EVM data */ }
        }
        
        /// <summary>
        /// Create Burndown Chart for selected project
        /// </summary>
        private async System.Threading.Tasks.Task CreateBurndownChartAsync(int projectId)
        {
            try
            {
                var burndownData = await _advancedReportService.GetProjectBurndownAsync(projectId);
                if (!burndownData.DataPoints.Any()) return;
                
                var chartControl = new ChartControl
                {
                    Location = GetNextChartPosition(),
                    Size = new Size(ChartWidth, ChartHeight),
                    BackColor = ColorPalette.BackgroundSlateDark
                };
                
                // Ideal line
                var idealSeries = new Series("Ideal Burndown", ViewType.Line);
                // Actual line
                var actualSeries = new Series("Actual Burndown", ViewType.Line);
                
                foreach (var dataPoint in burndownData.DataPoints)
                {
                    idealSeries.Points.Add(new SeriesPoint(dataPoint.Date.ToString("MMM dd"), dataPoint.IdealRemainingHours));
                    actualSeries.Points.Add(new SeriesPoint(dataPoint.Date.ToString("MMM dd"), dataPoint.ActualRemainingHours));
                }
                
                var idealView = (LineSeriesView)idealSeries.View;
                idealView.Color = ColorPalette.TextDisabled;
                idealView.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dash;
                idealView.LineStyle.Thickness = 2;
                
                var actualView = (LineSeriesView)actualSeries.View;
                actualView.Color = ColorPalette.AccentRoyalBlue;
                actualView.LineStyle.Thickness = 3;
                actualView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                actualView.LineMarkerOptions.Size = 8;
                
                chartControl.Series.Add(idealSeries);
                chartControl.Series.Add(actualSeries);
                
                var diagram = (XYDiagram)chartControl.Diagram;
                diagram.AxisX.Label.TextColor = ColorPalette.TextSecondary;
                diagram.AxisX.Label.Angle = -45;
                diagram.AxisY.Label.TextColor = ColorPalette.TextSecondary;
                diagram.AxisY.Title.Text = "Remaining Hours";
                diagram.AxisY.Title.TextColor = ColorPalette.TextSecondary;
                diagram.AxisX.Color = ColorPalette.BorderSlate;
                diagram.AxisY.Color = ColorPalette.BorderSlate;
                diagram.AxisY.GridLines.Color = ColorPalette.BorderSlate;
                diagram.DefaultPane.BackColor = Color.Transparent;
                
                var title = new ChartTitle
                {
                    Text = $"Burndown Chart - {burndownData.ProjectName}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextColor = ColorPalette.TextPrimary,
                    Dock = ChartTitleDockStyle.Top
                };
                chartControl.Titles.Add(title);
                chartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                chartControl.Legend.Visible = true;
                chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                chartControl.Legend.TextColor = ColorPalette.TextPrimary;
                chartControl.Legend.BackColor = Color.Transparent;
                
                pnlChartsContainer.Controls.Add(chartControl);
                
                // Add help icon to chart
                AddHelpIcon(chartControl, "Burndown Chart", "Ideal vs actual remaining hours.\nBelow line = good progress.", 10, 5);
            }
            catch { /* Skip if no burndown data */ }
        }
        
        /// <summary>
        /// Create Velocity Trend chart for first active team
        /// </summary>
        private async System.Threading.Tasks.Task CreateVelocityTrendChartAsync()
        {
            try
            {
                // Note: ProjectDto doesn't have TeamId, using first team from database (TeamId=1) as fallback
                // In production, you should query actual team IDs from the team service
                int teamId = 1; // Fallback to first team
                
                var velocityData = await _advancedReportService.GetTeamVelocityAsync(teamId, 8);
                if (!velocityData.WeeklyVelocity.Any()) return;
                
                var chartControl = new ChartControl
                {
                    Location = GetNextChartPosition(),
                    Size = new Size(ChartWidth, ChartHeight),
                    BackColor = ColorPalette.BackgroundSlateDark
                };
                
                var series = new Series("Weekly Velocity", ViewType.Bar);
                var avgLine = new Series("Average", ViewType.Line);
                
                // Add points first, then set colors by index
                foreach (var week in velocityData.WeeklyVelocity)
                {
                    var weekLabel = $"W{week.WeekNumber}";
                    series.Points.Add(new SeriesPoint(weekLabel, week.CompletedHours));
                    avgLine.Points.Add(new SeriesPoint(weekLabel, velocityData.AverageVelocity));
                }
                
                // Set all bar colors to RoyalBlue
                for (int i = 0; i < series.Points.Count; i++)
                {
                    series.Points[i].Color = ColorPalette.AccentRoyalBlue;
                }
                
                var lineView = (LineSeriesView)avgLine.View;
                lineView.Color = ColorPalette.WarningAmber;
                lineView.LineStyle.Thickness = 2;
                lineView.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dash;
                
                chartControl.Series.Add(series);
                chartControl.Series.Add(avgLine);
                
                var diagram = (XYDiagram)chartControl.Diagram;
                diagram.AxisX.Label.TextColor = ColorPalette.TextSecondary;
                diagram.AxisY.Label.TextColor = ColorPalette.TextSecondary;
                diagram.AxisY.Title.Text = "Completed Hours";
                diagram.AxisY.Title.TextColor = ColorPalette.TextSecondary;
                diagram.AxisX.Color = ColorPalette.BorderSlate;
                diagram.AxisY.Color = ColorPalette.BorderSlate;
                diagram.AxisY.GridLines.Color = ColorPalette.BorderSlate;
                diagram.DefaultPane.BackColor = Color.Transparent;
                
                var title = new ChartTitle
                {
                    Text = $"Velocity Trend - {velocityData.TeamName} (Trend: {velocityData.Trend})",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextColor = ColorPalette.TextPrimary,
                    Dock = ChartTitleDockStyle.Top
                };
                chartControl.Titles.Add(title);
                chartControl.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                chartControl.Legend.Visible = true;
                chartControl.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                chartControl.Legend.TextColor = ColorPalette.TextPrimary;
                chartControl.Legend.BackColor = Color.Transparent;
                
                pnlChartsContainer.Controls.Add(chartControl);
                
                // Add help icon to chart
                AddHelpIcon(chartControl, "Velocity Trend", "Weekly completed hours trend.\nCompared with average line.", 10, 5);
            }
            catch { /* Skip if no velocity data */ }
        }
        
        #endregion
        
        #endregion
        
        #region Event Handlers
        
        /// <summary>
        /// Export PDF button clicked
        /// </summary>
        private async void BtnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "PDF Files|*.pdf",
                    Title = "Export Report as PDF",
                    FileName = $"ProjectReport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    
                    // Generate PDF
                    var pdfBytes = await _reportService.ExportReportToPdfAsync();
                    
                    // Save to file
                    File.WriteAllBytes(saveDialog.FileName, pdfBytes);
                    
                    // Success message
                    if (FormStyleHelper.ShowQuestion("PDF report exported successfully!\n\nDo you want to open it?"))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error exporting PDF: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        /// <summary>
        /// Export Excel button clicked
        /// </summary>
        private async void BtnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Export Report as Excel",
                    FileName = $"ProjectData_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };
                
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    
                    // Generate Excel
                    var excelBytes = await _reportService.ExportReportToExcelAsync();
                    
                    // Save to file
                    File.WriteAllBytes(saveDialog.FileName, excelBytes);
                    
                    // Success message
                    if (FormStyleHelper.ShowQuestion("Excel report exported successfully!\n\nDo you want to open it?"))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = saveDialog.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                FormStyleHelper.ShowError($"Error exporting Excel: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        #endregion
    }
}
