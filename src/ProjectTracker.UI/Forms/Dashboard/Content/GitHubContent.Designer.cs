using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class GitHubContent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlMain = new DevExpress.XtraEditors.XtraScrollableControl();
            pnlCommits = new DevExpress.XtraEditors.PanelControl();
            grdCommits = new DevExpress.XtraGrid.GridControl();
            gridViewCommits = new DevExpress.XtraGrid.Views.Grid.GridView();
            lblCommitsTitle = new DevExpress.XtraEditors.LabelControl();
            pnlHotspots = new DevExpress.XtraEditors.PanelControl();
            grdHotspots = new DevExpress.XtraGrid.GridControl();
            gridViewHotspots = new DevExpress.XtraGrid.Views.Grid.GridView();
            lblHotspotsTitle = new DevExpress.XtraEditors.LabelControl();
            pnlCommitTrend = new DevExpress.XtraEditors.PanelControl();
            chartCommitTrend = new DevExpress.XtraCharts.ChartControl();
            lblCommitTrendTitle = new DevExpress.XtraEditors.LabelControl();
            pnlLeaderboard = new DevExpress.XtraEditors.PanelControl();
            grdLeaderboard = new DevExpress.XtraGrid.GridControl();
            layoutViewLeaderboard = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            lblLeaderboardTitle = new DevExpress.XtraEditors.LabelControl();
            pnlSummary = new DevExpress.XtraEditors.PanelControl();
            pnlCardMatched = new DevExpress.XtraEditors.PanelControl();
            lblMatchedValue = new DevExpress.XtraEditors.LabelControl();
            lblMatchedLabel = new DevExpress.XtraEditors.LabelControl();
            pnlCardAdditions = new DevExpress.XtraEditors.PanelControl();
            lblAdditionsValue = new DevExpress.XtraEditors.LabelControl();
            lblAdditionsLabel = new DevExpress.XtraEditors.LabelControl();
            pnlCardContributors = new DevExpress.XtraEditors.PanelControl();
            lblContributorsValue = new DevExpress.XtraEditors.LabelControl();
            lblContributorsLabel = new DevExpress.XtraEditors.LabelControl();
            pnlCardCommits = new DevExpress.XtraEditors.PanelControl();
            lblCommitsValue = new DevExpress.XtraEditors.LabelControl();
            lblCommitsLabel = new DevExpress.XtraEditors.LabelControl();
            pnlHeader = new DevExpress.XtraEditors.PanelControl();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            pnlFilters = new DevExpress.XtraEditors.PanelControl();
            lblSyncStatus = new DevExpress.XtraEditors.LabelControl();
            btnLinkRepo = new DevExpress.XtraEditors.SimpleButton();
            btnSync = new DevExpress.XtraEditors.SimpleButton();
            cmbProject = new DevExpress.XtraEditors.LookUpEdit();
            lblProject = new DevExpress.XtraEditors.LabelControl();
            pnlEmpty = new DevExpress.XtraEditors.PanelControl();
            lblEmptyMessage = new DevExpress.XtraEditors.LabelControl();
            lblEmptyTitle = new DevExpress.XtraEditors.LabelControl();
            lblEmptyIcon = new DevExpress.XtraEditors.LabelControl();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCommits).BeginInit();
            pnlCommits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdCommits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCommits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlHotspots).BeginInit();
            pnlHotspots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdHotspots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewHotspots).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlCommitTrend).BeginInit();
            pnlCommitTrend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCommitTrend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlLeaderboard).BeginInit();
            pnlLeaderboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdLeaderboard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewLeaderboard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlSummary).BeginInit();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardMatched).BeginInit();
            pnlCardMatched.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardAdditions).BeginInit();
            pnlCardAdditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardContributors).BeginInit();
            pnlCardContributors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardCommits).BeginInit();
            pnlCardCommits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFilters).BeginInit();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmpty).BeginInit();
            pnlEmpty.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlMain.Appearance.Options.UseBackColor = true;
            pnlMain.Controls.Add(pnlCommits);
            pnlMain.Controls.Add(pnlHotspots);
            pnlMain.Controls.Add(pnlCommitTrend);
            pnlMain.Controls.Add(pnlLeaderboard);
            pnlMain.Controls.Add(pnlSummary);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 166);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1100, 1050);
            pnlMain.TabIndex = 2;
            pnlMain.Visible = false;
            // 
            // pnlCommits
            // 
            pnlCommits.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCommits.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCommits.Appearance.Options.UseBackColor = true;
            pnlCommits.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCommits.Controls.Add(grdCommits);
            pnlCommits.Controls.Add(lblCommitsTitle);
            pnlCommits.Location = new Point(12, 728);
            pnlCommits.Margin = new Padding(3, 4, 3, 4);
            pnlCommits.Name = "pnlCommits";
            pnlCommits.Padding = new Padding(15, 15, 15, 15);
            pnlCommits.Size = new Size(1080, 280);
            pnlCommits.TabIndex = 5;
            // 
            // grdCommits
            // 
            grdCommits.Dock = DockStyle.Fill;
            grdCommits.EmbeddedNavigator.Margin = new Padding(3, 4, 3, 4);
            grdCommits.Location = new Point(17, 52);
            grdCommits.MainView = gridViewCommits;
            grdCommits.Margin = new Padding(3, 4, 3, 4);
            grdCommits.Name = "grdCommits";
            grdCommits.Size = new Size(1046, 213);
            grdCommits.TabIndex = 1;
            grdCommits.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewCommits });
            grdCommits.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            grdCommits.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // gridViewCommits
            // 
            gridViewCommits.Appearance.ColumnFilterButton.BackColor = Color.FromArgb(36, 43, 61);
            gridViewCommits.Appearance.ColumnFilterButton.BorderColor = Color.FromArgb(51, 65, 85);
            gridViewCommits.Appearance.ColumnFilterButton.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewCommits.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            gridViewCommits.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            gridViewCommits.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            gridViewCommits.Appearance.Empty.BackColor = Color.FromArgb(36, 43, 61);
            gridViewCommits.Appearance.Empty.Font = new Font("Segoe UI", 8.25F);
            gridViewCommits.Appearance.Empty.ForeColor = Color.FromArgb(203, 213, 225);
            gridViewCommits.Appearance.Empty.Options.UseBackColor = true;
            gridViewCommits.Appearance.Empty.Options.UseFont = true;
            gridViewCommits.Appearance.Empty.Options.UseForeColor = true;
            gridViewCommits.Appearance.EvenRow.BackColor = Color.FromArgb(36, 43, 61);
            gridViewCommits.Appearance.EvenRow.Font = new Font("Segoe UI", 9.5F);
            gridViewCommits.Appearance.EvenRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewCommits.Appearance.EvenRow.Options.UseBackColor = true;
            gridViewCommits.Appearance.EvenRow.Options.UseFont = true;
            gridViewCommits.Appearance.EvenRow.Options.UseForeColor = true;
            gridViewCommits.Appearance.OddRow.BackColor = Color.FromArgb(32, 39, 52);
            gridViewCommits.Appearance.OddRow.Font = new Font("Segoe UI", 9.5F);
            gridViewCommits.Appearance.OddRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewCommits.Appearance.OddRow.Options.UseBackColor = true;
            gridViewCommits.Appearance.OddRow.Options.UseFont = true;
            gridViewCommits.Appearance.OddRow.Options.UseForeColor = true;
            gridViewCommits.Appearance.FocusedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridViewCommits.Appearance.FocusedRow.Font = new Font("Segoe UI", 9.5F);
            gridViewCommits.Appearance.FocusedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewCommits.Appearance.FocusedRow.Options.UseBackColor = true;
            gridViewCommits.Appearance.FocusedRow.Options.UseFont = true;
            gridViewCommits.Appearance.FocusedRow.Options.UseForeColor = true;
            gridViewCommits.Appearance.FocusedCell.BackColor = Color.FromArgb(51, 65, 85);
            gridViewCommits.Appearance.FocusedCell.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewCommits.Appearance.FocusedCell.Options.UseBackColor = true;
            gridViewCommits.Appearance.FocusedCell.Options.UseForeColor = true;
            gridViewCommits.Appearance.SelectedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridViewCommits.Appearance.SelectedRow.Font = new Font("Segoe UI", 9.5F);
            gridViewCommits.Appearance.SelectedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewCommits.Appearance.SelectedRow.Options.UseBackColor = true;
            gridViewCommits.Appearance.SelectedRow.Options.UseFont = true;
            gridViewCommits.Appearance.SelectedRow.Options.UseForeColor = true;
            gridViewCommits.Appearance.HideSelectionRow.BackColor = Color.FromArgb(45, 55, 72);
            gridViewCommits.Appearance.HideSelectionRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewCommits.Appearance.HideSelectionRow.Options.UseBackColor = true;
            gridViewCommits.Appearance.HideSelectionRow.Options.UseForeColor = true;
            gridViewCommits.Appearance.HeaderPanel.BackColor = Color.FromArgb(30, 36, 47);
            gridViewCommits.Appearance.HeaderPanel.BorderColor = Color.FromArgb(30, 36, 47);
            gridViewCommits.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gridViewCommits.Appearance.HeaderPanel.ForeColor = Color.FromArgb(180, 190, 200);
            gridViewCommits.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridViewCommits.Appearance.HeaderPanel.Options.UseBorderColor = true;
            gridViewCommits.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewCommits.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewCommits.Appearance.HorzLine.BackColor = Color.FromArgb(51, 65, 85);
            gridViewCommits.Appearance.HorzLine.Options.UseBackColor = true;
            gridViewCommits.Appearance.Row.BackColor = Color.FromArgb(36, 43, 61);
            gridViewCommits.Appearance.Row.Font = new Font("Segoe UI", 9.5F);
            gridViewCommits.Appearance.Row.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewCommits.Appearance.Row.Options.UseBackColor = true;
            gridViewCommits.Appearance.Row.Options.UseFont = true;
            gridViewCommits.Appearance.Row.Options.UseForeColor = true;
            gridViewCommits.Appearance.VertLine.BackColor = Color.FromArgb(51, 65, 85);
            gridViewCommits.Appearance.VertLine.Options.UseBackColor = true;
            gridViewCommits.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            gridViewCommits.ColumnPanelRowHeight = 40;
            gridViewCommits.DetailHeight = 443;
            gridViewCommits.GridControl = grdCommits;
            gridViewCommits.Name = "gridViewCommits";
            gridViewCommits.OptionsBehavior.Editable = false;
            gridViewCommits.OptionsEditForm.PopupEditFormWidth = 914;
            gridViewCommits.OptionsView.EnableAppearanceEvenRow = true;
            gridViewCommits.OptionsView.EnableAppearanceOddRow = true;
            gridViewCommits.OptionsView.ShowGroupPanel = false;
            gridViewCommits.OptionsView.ShowIndicator = false;
            gridViewCommits.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            gridViewCommits.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            gridViewCommits.OptionsSelection.EnableAppearanceFocusedCell = true;
            gridViewCommits.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewCommits.PaintStyleName = "Web";
            gridViewCommits.RowHeight = 38;
            // 
            // lblCommitsTitle
            // 
            lblCommitsTitle.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCommitsTitle.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblCommitsTitle.Appearance.Options.UseFont = true;
            lblCommitsTitle.Appearance.Options.UseForeColor = true;
            lblCommitsTitle.Dock = DockStyle.Top;
            lblCommitsTitle.Location = new Point(17, 19);
            lblCommitsTitle.Margin = new Padding(3, 4, 3, 4);
            lblCommitsTitle.Name = "lblCommitsTitle";
            lblCommitsTitle.Padding = new Padding(0, 0, 0, 13);
            lblCommitsTitle.Size = new Size(115, 33);
            lblCommitsTitle.TabIndex = 0;
            lblCommitsTitle.Text = "Recent Commits";
            // 
            // pnlHotspots
            // 
            pnlHotspots.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlHotspots.Appearance.Options.UseBackColor = true;
            pnlHotspots.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHotspots.Controls.Add(grdHotspots);
            pnlHotspots.Controls.Add(lblHotspotsTitle);
            pnlHotspots.Location = new Point(555, 468);
            pnlHotspots.Margin = new Padding(3, 4, 3, 4);
            pnlHotspots.Name = "pnlHotspots";
            pnlHotspots.Padding = new Padding(17, 19, 17, 19);
            pnlHotspots.Size = new Size(537, 250);
            pnlHotspots.TabIndex = 4;
            // 
            // grdHotspots
            // 
            grdHotspots.Dock = DockStyle.Fill;
            grdHotspots.EmbeddedNavigator.Margin = new Padding(3, 4, 3, 4);
            grdHotspots.Location = new Point(17, 52);
            grdHotspots.MainView = gridViewHotspots;
            grdHotspots.Margin = new Padding(3, 4, 3, 4);
            grdHotspots.Name = "grdHotspots";
            grdHotspots.Size = new Size(503, 179);
            grdHotspots.TabIndex = 1;
            grdHotspots.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewHotspots });
            grdHotspots.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            grdHotspots.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // gridViewHotspots
            // 
            gridViewHotspots.Appearance.ColumnFilterButton.BackColor = Color.FromArgb(36, 43, 61);
            gridViewHotspots.Appearance.ColumnFilterButton.BorderColor = Color.FromArgb(51, 65, 85);
            gridViewHotspots.Appearance.ColumnFilterButton.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewHotspots.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            gridViewHotspots.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            gridViewHotspots.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            gridViewHotspots.Appearance.Empty.BackColor = Color.FromArgb(36, 43, 61);
            gridViewHotspots.Appearance.Empty.Font = new Font("Segoe UI", 8.25F);
            gridViewHotspots.Appearance.Empty.ForeColor = Color.FromArgb(203, 213, 225);
            gridViewHotspots.Appearance.Empty.Options.UseBackColor = true;
            gridViewHotspots.Appearance.Empty.Options.UseFont = true;
            gridViewHotspots.Appearance.Empty.Options.UseForeColor = true;
            gridViewHotspots.Appearance.EvenRow.BackColor = Color.FromArgb(36, 43, 61);
            gridViewHotspots.Appearance.EvenRow.Font = new Font("Segoe UI", 9.5F);
            gridViewHotspots.Appearance.EvenRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewHotspots.Appearance.EvenRow.Options.UseBackColor = true;
            gridViewHotspots.Appearance.EvenRow.Options.UseFont = true;
            gridViewHotspots.Appearance.EvenRow.Options.UseForeColor = true;
            gridViewHotspots.Appearance.OddRow.BackColor = Color.FromArgb(32, 39, 52);
            gridViewHotspots.Appearance.OddRow.Font = new Font("Segoe UI", 9.5F);
            gridViewHotspots.Appearance.OddRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewHotspots.Appearance.OddRow.Options.UseBackColor = true;
            gridViewHotspots.Appearance.OddRow.Options.UseFont = true;
            gridViewHotspots.Appearance.OddRow.Options.UseForeColor = true;
            gridViewHotspots.Appearance.FocusedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridViewHotspots.Appearance.FocusedRow.Font = new Font("Segoe UI", 9.5F);
            gridViewHotspots.Appearance.FocusedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewHotspots.Appearance.FocusedRow.Options.UseBackColor = true;
            gridViewHotspots.Appearance.FocusedRow.Options.UseFont = true;
            gridViewHotspots.Appearance.FocusedRow.Options.UseForeColor = true;
            gridViewHotspots.Appearance.FocusedCell.BackColor = Color.FromArgb(51, 65, 85);
            gridViewHotspots.Appearance.FocusedCell.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewHotspots.Appearance.FocusedCell.Options.UseBackColor = true;
            gridViewHotspots.Appearance.FocusedCell.Options.UseForeColor = true;
            gridViewHotspots.Appearance.SelectedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridViewHotspots.Appearance.SelectedRow.Font = new Font("Segoe UI", 9.5F);
            gridViewHotspots.Appearance.SelectedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewHotspots.Appearance.SelectedRow.Options.UseBackColor = true;
            gridViewHotspots.Appearance.SelectedRow.Options.UseFont = true;
            gridViewHotspots.Appearance.SelectedRow.Options.UseForeColor = true;
            gridViewHotspots.Appearance.HideSelectionRow.BackColor = Color.FromArgb(45, 55, 72);
            gridViewHotspots.Appearance.HideSelectionRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewHotspots.Appearance.HideSelectionRow.Options.UseBackColor = true;
            gridViewHotspots.Appearance.HideSelectionRow.Options.UseForeColor = true;
            gridViewHotspots.Appearance.HeaderPanel.BackColor = Color.FromArgb(30, 36, 47);
            gridViewHotspots.Appearance.HeaderPanel.BorderColor = Color.FromArgb(30, 36, 47);
            gridViewHotspots.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gridViewHotspots.Appearance.HeaderPanel.ForeColor = Color.FromArgb(180, 190, 200);
            gridViewHotspots.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridViewHotspots.Appearance.HeaderPanel.Options.UseBorderColor = true;
            gridViewHotspots.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewHotspots.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewHotspots.Appearance.HorzLine.BackColor = Color.FromArgb(51, 65, 85);
            gridViewHotspots.Appearance.HorzLine.Options.UseBackColor = true;
            gridViewHotspots.Appearance.Row.BackColor = Color.FromArgb(36, 43, 61);
            gridViewHotspots.Appearance.Row.Font = new Font("Segoe UI", 9.5F);
            gridViewHotspots.Appearance.Row.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewHotspots.Appearance.Row.Options.UseBackColor = true;
            gridViewHotspots.Appearance.Row.Options.UseFont = true;
            gridViewHotspots.Appearance.Row.Options.UseForeColor = true;
            gridViewHotspots.Appearance.VertLine.BackColor = Color.FromArgb(51, 65, 85);
            gridViewHotspots.Appearance.VertLine.Options.UseBackColor = true;
            gridViewHotspots.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            gridViewHotspots.ColumnPanelRowHeight = 40;
            gridViewHotspots.DetailHeight = 443;
            gridViewHotspots.GridControl = grdHotspots;
            gridViewHotspots.Name = "gridViewHotspots";
            gridViewHotspots.OptionsBehavior.Editable = false;
            gridViewHotspots.OptionsEditForm.PopupEditFormWidth = 914;
            gridViewHotspots.OptionsView.EnableAppearanceEvenRow = true;
            gridViewHotspots.OptionsView.EnableAppearanceOddRow = true;
            gridViewHotspots.OptionsView.ShowGroupPanel = false;
            gridViewHotspots.OptionsView.ShowIndicator = false;
            gridViewHotspots.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            gridViewHotspots.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            gridViewHotspots.OptionsSelection.EnableAppearanceFocusedCell = true;
            gridViewHotspots.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewHotspots.PaintStyleName = "Web";
            gridViewHotspots.RowHeight = 36;
            // 
            // lblHotspotsTitle
            // 
            lblHotspotsTitle.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHotspotsTitle.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblHotspotsTitle.Appearance.Options.UseFont = true;
            lblHotspotsTitle.Appearance.Options.UseForeColor = true;
            lblHotspotsTitle.Dock = DockStyle.Top;
            lblHotspotsTitle.Location = new Point(17, 19);
            lblHotspotsTitle.Margin = new Padding(3, 4, 3, 4);
            lblHotspotsTitle.Name = "lblHotspotsTitle";
            lblHotspotsTitle.Padding = new Padding(0, 0, 0, 13);
            lblHotspotsTitle.Size = new Size(181, 33);
            lblHotspotsTitle.TabIndex = 0;
            lblHotspotsTitle.Text = "Hotspots (Most Changed)";
            // 
            // pnlCommitTrend
            // 
            pnlCommitTrend.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCommitTrend.Appearance.Options.UseBackColor = true;
            pnlCommitTrend.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCommitTrend.Controls.Add(chartCommitTrend);
            pnlCommitTrend.Controls.Add(lblCommitTrendTitle);
            pnlCommitTrend.Location = new Point(12, 468);
            pnlCommitTrend.Margin = new Padding(3, 4, 3, 4);
            pnlCommitTrend.Name = "pnlCommitTrend";
            pnlCommitTrend.Padding = new Padding(17, 19, 17, 19);
            pnlCommitTrend.Size = new Size(530, 250);
            pnlCommitTrend.TabIndex = 3;
            // 
            // chartCommitTrend
            // 
            chartCommitTrend.Dock = DockStyle.Fill;
            chartCommitTrend.Location = new Point(17, 52);
            chartCommitTrend.Margin = new Padding(3, 4, 3, 4);
            chartCommitTrend.Name = "chartCommitTrend";
            chartCommitTrend.Size = new Size(496, 179);
            chartCommitTrend.TabIndex = 1;
            // 
            // lblCommitTrendTitle
            // 
            lblCommitTrendTitle.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCommitTrendTitle.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblCommitTrendTitle.Appearance.Options.UseFont = true;
            lblCommitTrendTitle.Appearance.Options.UseForeColor = true;
            lblCommitTrendTitle.Dock = DockStyle.Top;
            lblCommitTrendTitle.Location = new Point(17, 19);
            lblCommitTrendTitle.Margin = new Padding(3, 4, 3, 4);
            lblCommitTrendTitle.Name = "lblCommitTrendTitle";
            lblCommitTrendTitle.Padding = new Padding(0, 0, 0, 13);
            lblCommitTrendTitle.Size = new Size(101, 33);
            lblCommitTrendTitle.TabIndex = 0;
            lblCommitTrendTitle.Text = "Commit Trend";
            // 
            // pnlLeaderboard
            // 
            pnlLeaderboard.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlLeaderboard.Appearance.Options.UseBackColor = true;
            pnlLeaderboard.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlLeaderboard.Controls.Add(grdLeaderboard);
            pnlLeaderboard.Controls.Add(lblLeaderboardTitle);
            pnlLeaderboard.Location = new Point(12, 158);
            pnlLeaderboard.Margin = new Padding(3, 4, 3, 4);
            pnlLeaderboard.Name = "pnlLeaderboard";
            pnlLeaderboard.Padding = new Padding(17, 19, 17, 19);
            pnlLeaderboard.Size = new Size(1080, 300);
            pnlLeaderboard.TabIndex = 1;
            // 
            // grdLeaderboard
            // 
            grdLeaderboard.Dock = DockStyle.Fill;
            grdLeaderboard.EmbeddedNavigator.Margin = new Padding(3, 4, 3, 4);
            grdLeaderboard.Location = new Point(17, 52);
            grdLeaderboard.MainView = layoutViewLeaderboard;
            grdLeaderboard.Margin = new Padding(3, 4, 3, 4);
            grdLeaderboard.Name = "grdLeaderboard";
            grdLeaderboard.Size = new Size(1046, 229);
            grdLeaderboard.TabIndex = 1;
            grdLeaderboard.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { layoutViewLeaderboard });
            // 
            // layoutViewLeaderboard
            // 
            layoutViewLeaderboard.Appearance.CardCaption.BackColor = Color.FromArgb(42, 63, 95);
            layoutViewLeaderboard.Appearance.CardCaption.ForeColor = Color.FromArgb(248, 250, 252);
            layoutViewLeaderboard.Appearance.CardCaption.Options.UseBackColor = true;
            layoutViewLeaderboard.Appearance.CardCaption.Options.UseForeColor = true;
            layoutViewLeaderboard.Appearance.FieldCaption.BackColor = Color.FromArgb(30, 42, 58);
            layoutViewLeaderboard.Appearance.FieldCaption.ForeColor = Color.FromArgb(148, 163, 184);
            layoutViewLeaderboard.Appearance.FieldCaption.Options.UseBackColor = true;
            layoutViewLeaderboard.Appearance.FieldCaption.Options.UseForeColor = true;
            layoutViewLeaderboard.Appearance.FieldValue.BackColor = Color.FromArgb(30, 42, 58);
            layoutViewLeaderboard.Appearance.FieldValue.ForeColor = Color.FromArgb(248, 250, 252);
            layoutViewLeaderboard.Appearance.FieldValue.Options.UseBackColor = true;
            layoutViewLeaderboard.Appearance.FieldValue.Options.UseForeColor = true;
            layoutViewLeaderboard.Appearance.ViewBackground.BackColor = Color.FromArgb(36, 43, 61);
            layoutViewLeaderboard.Appearance.ViewBackground.Options.UseBackColor = true;
            layoutViewLeaderboard.Appearance.Card.BackColor = Color.FromArgb(30, 42, 58);
            layoutViewLeaderboard.Appearance.Card.Options.UseBackColor = true;
            layoutViewLeaderboard.CardMinSize = new Size(229, 127);
            layoutViewLeaderboard.DetailHeight = 443;
            layoutViewLeaderboard.GridControl = grdLeaderboard;
            layoutViewLeaderboard.Name = "layoutViewLeaderboard";
            layoutViewLeaderboard.OptionsBehavior.Editable = false;
            layoutViewLeaderboard.OptionsView.ShowCardExpandButton = false;
            layoutViewLeaderboard.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            layoutViewLeaderboard.OptionsView.ShowHeaderPanel = false;
            layoutViewLeaderboard.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Row;
            // 
            // lblLeaderboardTitle
            // 
            lblLeaderboardTitle.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLeaderboardTitle.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblLeaderboardTitle.Appearance.Options.UseFont = true;
            lblLeaderboardTitle.Appearance.Options.UseForeColor = true;
            lblLeaderboardTitle.Dock = DockStyle.Top;
            lblLeaderboardTitle.Location = new Point(17, 19);
            lblLeaderboardTitle.Margin = new Padding(3, 4, 3, 4);
            lblLeaderboardTitle.Name = "lblLeaderboardTitle";
            lblLeaderboardTitle.Padding = new Padding(0, 0, 0, 13);
            lblLeaderboardTitle.Size = new Size(174, 33);
            lblLeaderboardTitle.TabIndex = 0;
            lblLeaderboardTitle.Text = "Contributor Leaderboard";
            // 
            // pnlSummary
            // 
            pnlSummary.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlSummary.Appearance.Options.UseBackColor = true;
            pnlSummary.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlSummary.Controls.Add(pnlCardMatched);
            pnlSummary.Controls.Add(pnlCardAdditions);
            pnlSummary.Controls.Add(pnlCardContributors);
            pnlSummary.Controls.Add(pnlCardCommits);
            pnlSummary.Location = new Point(0, 0);
            pnlSummary.Margin = new Padding(3, 4, 3, 4);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(1100, 152);
            pnlSummary.TabIndex = 0;
            // 
            // pnlCardMatched
            // 
            pnlCardMatched.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCardMatched.Appearance.Options.UseBackColor = true;
            pnlCardMatched.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCardMatched.Controls.Add(lblMatchedValue);
            pnlCardMatched.Controls.Add(lblMatchedLabel);
            pnlCardMatched.Location = new Point(831, 13);
            pnlCardMatched.Margin = new Padding(3, 4, 3, 4);
            pnlCardMatched.Name = "pnlCardMatched";
            pnlCardMatched.Size = new Size(260, 127);
            pnlCardMatched.TabIndex = 3;
            // 
            // lblMatchedValue
            // 
            lblMatchedValue.Appearance.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblMatchedValue.Appearance.ForeColor = Color.FromArgb(168, 85, 247);
            lblMatchedValue.Appearance.Options.UseFont = true;
            lblMatchedValue.Appearance.Options.UseForeColor = true;
            lblMatchedValue.Location = new Point(23, 15);
            lblMatchedValue.Margin = new Padding(3, 4, 3, 4);
            lblMatchedValue.Name = "lblMatchedValue";
            lblMatchedValue.Size = new Size(20, 47);
            lblMatchedValue.TabIndex = 0;
            lblMatchedValue.Text = "0";
            // 
            // lblMatchedLabel
            // 
            lblMatchedLabel.Appearance.Font = new Font("Segoe UI", 9F);
            lblMatchedLabel.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
            lblMatchedLabel.Appearance.Options.UseFont = true;
            lblMatchedLabel.Appearance.Options.UseForeColor = true;
            lblMatchedLabel.Location = new Point(23, 86);
            lblMatchedLabel.Margin = new Padding(3, 4, 3, 4);
            lblMatchedLabel.Name = "lblMatchedLabel";
            lblMatchedLabel.Size = new Size(79, 15);
            lblMatchedLabel.TabIndex = 1;
            lblMatchedLabel.Text = "Matched Tasks";
            // 
            // pnlCardAdditions
            // 
            pnlCardAdditions.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCardAdditions.Appearance.Options.UseBackColor = true;
            pnlCardAdditions.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCardAdditions.Controls.Add(lblAdditionsValue);
            pnlCardAdditions.Controls.Add(lblAdditionsLabel);
            pnlCardAdditions.Location = new Point(558, 13);
            pnlCardAdditions.Margin = new Padding(3, 4, 3, 4);
            pnlCardAdditions.Name = "pnlCardAdditions";
            pnlCardAdditions.Size = new Size(260, 127);
            pnlCardAdditions.TabIndex = 2;
            // 
            // lblAdditionsValue
            // 
            lblAdditionsValue.Appearance.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblAdditionsValue.Appearance.ForeColor = Color.FromArgb(249, 115, 22);
            lblAdditionsValue.Appearance.Options.UseFont = true;
            lblAdditionsValue.Appearance.Options.UseForeColor = true;
            lblAdditionsValue.Location = new Point(23, 15);
            lblAdditionsValue.Margin = new Padding(3, 4, 3, 4);
            lblAdditionsValue.Name = "lblAdditionsValue";
            lblAdditionsValue.Size = new Size(45, 47);
            lblAdditionsValue.TabIndex = 0;
            lblAdditionsValue.Text = "+0";
            // 
            // lblAdditionsLabel
            // 
            lblAdditionsLabel.Appearance.Font = new Font("Segoe UI", 9F);
            lblAdditionsLabel.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
            lblAdditionsLabel.Appearance.Options.UseFont = true;
            lblAdditionsLabel.Appearance.Options.UseForeColor = true;
            lblAdditionsLabel.Location = new Point(23, 86);
            lblAdditionsLabel.Margin = new Padding(3, 4, 3, 4);
            lblAdditionsLabel.Name = "lblAdditionsLabel";
            lblAdditionsLabel.Size = new Size(65, 15);
            lblAdditionsLabel.TabIndex = 1;
            lblAdditionsLabel.Text = "Lines Added";
            // 
            // pnlCardContributors
            // 
            pnlCardContributors.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCardContributors.Appearance.Options.UseBackColor = true;
            pnlCardContributors.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCardContributors.Controls.Add(lblContributorsValue);
            pnlCardContributors.Controls.Add(lblContributorsLabel);
            pnlCardContributors.Location = new Point(285, 13);
            pnlCardContributors.Margin = new Padding(3, 4, 3, 4);
            pnlCardContributors.Name = "pnlCardContributors";
            pnlCardContributors.Size = new Size(260, 127);
            pnlCardContributors.TabIndex = 1;
            // 
            // lblContributorsValue
            // 
            lblContributorsValue.Appearance.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblContributorsValue.Appearance.ForeColor = Color.FromArgb(16, 185, 129);
            lblContributorsValue.Appearance.Options.UseFont = true;
            lblContributorsValue.Appearance.Options.UseForeColor = true;
            lblContributorsValue.Location = new Point(23, 15);
            lblContributorsValue.Margin = new Padding(3, 4, 3, 4);
            lblContributorsValue.Name = "lblContributorsValue";
            lblContributorsValue.Size = new Size(20, 47);
            lblContributorsValue.TabIndex = 0;
            lblContributorsValue.Text = "0";
            // 
            // lblContributorsLabel
            // 
            lblContributorsLabel.Appearance.Font = new Font("Segoe UI", 9F);
            lblContributorsLabel.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
            lblContributorsLabel.Appearance.Options.UseFont = true;
            lblContributorsLabel.Appearance.Options.UseForeColor = true;
            lblContributorsLabel.Location = new Point(23, 86);
            lblContributorsLabel.Margin = new Padding(3, 4, 3, 4);
            lblContributorsLabel.Name = "lblContributorsLabel";
            lblContributorsLabel.Size = new Size(67, 15);
            lblContributorsLabel.TabIndex = 1;
            lblContributorsLabel.Text = "Contributors";
            // 
            // pnlCardCommits
            // 
            pnlCardCommits.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCardCommits.Appearance.Options.UseBackColor = true;
            pnlCardCommits.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCardCommits.Controls.Add(lblCommitsValue);
            pnlCardCommits.Controls.Add(lblCommitsLabel);
            pnlCardCommits.Location = new Point(12, 13);
            pnlCardCommits.Margin = new Padding(3, 4, 3, 4);
            pnlCardCommits.Name = "pnlCardCommits";
            pnlCardCommits.Size = new Size(260, 127);
            pnlCardCommits.TabIndex = 0;
            // 
            // lblCommitsValue
            // 
            lblCommitsValue.Appearance.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblCommitsValue.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            lblCommitsValue.Appearance.Options.UseFont = true;
            lblCommitsValue.Appearance.Options.UseForeColor = true;
            lblCommitsValue.Location = new Point(23, 15);
            lblCommitsValue.Margin = new Padding(3, 4, 3, 4);
            lblCommitsValue.Name = "lblCommitsValue";
            lblCommitsValue.Size = new Size(20, 47);
            lblCommitsValue.TabIndex = 0;
            lblCommitsValue.Text = "0";
            // 
            // lblCommitsLabel
            // 
            lblCommitsLabel.Appearance.Font = new Font("Segoe UI", 9F);
            lblCommitsLabel.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
            lblCommitsLabel.Appearance.Options.UseFont = true;
            lblCommitsLabel.Appearance.Options.UseForeColor = true;
            lblCommitsLabel.Location = new Point(23, 86);
            lblCommitsLabel.Margin = new Padding(3, 4, 3, 4);
            lblCommitsLabel.Name = "lblCommitsLabel";
            lblCommitsLabel.Size = new Size(79, 15);
            lblCommitsLabel.TabIndex = 1;
            lblCommitsLabel.Text = "Total Commits";
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1437, 89);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 9F);
            lblSubtitle.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.Location = new Point(17, 57);
            lblSubtitle.Margin = new Padding(3, 4, 3, 4);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(217, 15);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Repository insights and commit analytics";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new Point(17, 13);
            lblTitle.Margin = new Padding(3, 4, 3, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(166, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GitHub Analytics";
            // 
            // pnlFilters
            // 
            pnlFilters.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlFilters.Appearance.Options.UseBackColor = true;
            pnlFilters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFilters.Controls.Add(lblSyncStatus);
            pnlFilters.Controls.Add(btnLinkRepo);
            pnlFilters.Controls.Add(btnSync);
            pnlFilters.Controls.Add(cmbProject);
            pnlFilters.Controls.Add(lblProject);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 89);
            pnlFilters.Margin = new Padding(3, 4, 3, 4);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(17, 13, 17, 13);
            pnlFilters.Size = new Size(1437, 77);
            pnlFilters.TabIndex = 1;
            // 
            // lblSyncStatus
            // 
            lblSyncStatus.Appearance.Font = new Font("Segoe UI", 9F);
            lblSyncStatus.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
            lblSyncStatus.Appearance.Options.UseFont = true;
            lblSyncStatus.Appearance.Options.UseForeColor = true;
            lblSyncStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSyncStatus.Location = new Point(709, 25);
            lblSyncStatus.Margin = new Padding(3, 4, 3, 4);
            lblSyncStatus.Name = "lblSyncStatus";
            lblSyncStatus.Size = new Size(457, 25);
            lblSyncStatus.TabIndex = 4;
            lblSyncStatus.Text = "Last sync: Never";
            // 
            // btnLinkRepo
            // 
            btnLinkRepo.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            btnLinkRepo.Appearance.Font = new Font("Segoe UI", 9F);
            btnLinkRepo.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnLinkRepo.Appearance.Options.UseBackColor = true;
            btnLinkRepo.Appearance.Options.UseFont = true;
            btnLinkRepo.Appearance.Options.UseForeColor = true;
            btnLinkRepo.Location = new Point(560, 15);
            btnLinkRepo.Margin = new Padding(3, 4, 3, 4);
            btnLinkRepo.Name = "btnLinkRepo";
            btnLinkRepo.Size = new Size(137, 46);
            btnLinkRepo.TabIndex = 3;
            btnLinkRepo.Text = "Link Repository";
            // 
            // btnSync
            // 
            btnSync.Appearance.BackColor = Color.FromArgb(91, 141, 239);
            btnSync.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSync.Appearance.ForeColor = Color.White;
            btnSync.Appearance.Options.UseBackColor = true;
            btnSync.Appearance.Options.UseFont = true;
            btnSync.Appearance.Options.UseForeColor = true;
            btnSync.Location = new Point(434, 15);
            btnSync.Margin = new Padding(3, 4, 3, 4);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(114, 46);
            btnSync.TabIndex = 2;
            btnSync.Text = "Sync Now";
            // 
            // cmbProject
            // 
            cmbProject.Location = new Point(80, 19);
            cmbProject.Margin = new Padding(3, 4, 3, 4);
            cmbProject.Name = "cmbProject";
            cmbProject.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            cmbProject.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            cmbProject.Properties.Appearance.Options.UseBackColor = true;
            cmbProject.Properties.Appearance.Options.UseForeColor = true;
            cmbProject.Properties.AutoHeight = false;
            cmbProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbProject.Properties.NullText = "Select a project...";
            cmbProject.Properties.PopupSizeable = false;
            cmbProject.Size = new Size(331, 38);
            cmbProject.TabIndex = 1;
            // 
            // lblProject
            // 
            lblProject.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProject.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblProject.Appearance.Options.UseFont = true;
            lblProject.Appearance.Options.UseForeColor = true;
            lblProject.Location = new Point(17, 28);
            lblProject.Margin = new Padding(3, 4, 3, 4);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(43, 15);
            lblProject.TabIndex = 0;
            lblProject.Text = "Project:";
            // 
            // pnlEmpty
            // 
            pnlEmpty.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlEmpty.Appearance.Options.UseBackColor = true;
            pnlEmpty.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlEmpty.Controls.Add(lblEmptyMessage);
            pnlEmpty.Controls.Add(lblEmptyTitle);
            pnlEmpty.Controls.Add(lblEmptyIcon);
            pnlEmpty.Dock = DockStyle.Fill;
            pnlEmpty.Location = new Point(0, 166);
            pnlEmpty.Margin = new Padding(3, 4, 3, 4);
            pnlEmpty.Name = "pnlEmpty";
            pnlEmpty.Size = new Size(1437, 1013);
            pnlEmpty.TabIndex = 3;
            // 
            // lblEmptyMessage
            // 
            lblEmptyMessage.Anchor = AnchorStyles.None;
            lblEmptyMessage.Appearance.Font = new Font("Segoe UI", 10F);
            lblEmptyMessage.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmptyMessage.Appearance.Options.UseFont = true;
            lblEmptyMessage.Appearance.Options.UseForeColor = true;
            lblEmptyMessage.Appearance.Options.UseTextOptions = true;
            lblEmptyMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblEmptyMessage.Location = new Point(327, 498);
            lblEmptyMessage.Margin = new Padding(3, 4, 3, 4);
            lblEmptyMessage.Name = "lblEmptyMessage";
            lblEmptyMessage.Size = new Size(784, 65);
            lblEmptyMessage.TabIndex = 2;
            lblEmptyMessage.Text = "Please select a project from the dropdown above to view GitHub analytics.";
            // 
            // lblEmptyTitle
            // 
            lblEmptyTitle.Anchor = AnchorStyles.None;
            lblEmptyTitle.Appearance.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblEmptyTitle.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblEmptyTitle.Appearance.Options.UseFont = true;
            lblEmptyTitle.Appearance.Options.UseForeColor = true;
            lblEmptyTitle.Appearance.Options.UseTextOptions = true;
            lblEmptyTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblEmptyTitle.Location = new Point(392, 433);
            lblEmptyTitle.Margin = new Padding(3, 4, 3, 4);
            lblEmptyTitle.Name = "lblEmptyTitle";
            lblEmptyTitle.Size = new Size(653, 48);
            lblEmptyTitle.TabIndex = 1;
            lblEmptyTitle.Text = "Select a Project";
            // 
            // lblEmptyIcon
            // 
            lblEmptyIcon.Anchor = AnchorStyles.None;
            lblEmptyIcon.Appearance.Font = new Font("Segoe UI", 48F);
            lblEmptyIcon.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmptyIcon.Appearance.Options.UseFont = true;
            lblEmptyIcon.Appearance.Options.UseForeColor = true;
            lblEmptyIcon.Appearance.Options.UseTextOptions = true;
            lblEmptyIcon.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblEmptyIcon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblEmptyIcon.Location = new Point(587, 289);
            lblEmptyIcon.Margin = new Padding(3, 4, 3, 4);
            lblEmptyIcon.Name = "lblEmptyIcon";
            lblEmptyIcon.Size = new Size(262, 128);
            lblEmptyIcon.TabIndex = 0;
            // 
            // GitHubContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 31, 38);
            Controls.Add(pnlEmpty);
            Controls.Add(pnlMain);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GitHubContent";
            Size = new Size(1100, 1050);
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlCommits).EndInit();
            pnlCommits.ResumeLayout(false);
            pnlCommits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdCommits).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewCommits).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlHotspots).EndInit();
            pnlHotspots.ResumeLayout(false);
            pnlHotspots.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdHotspots).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewHotspots).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCommitTrend).EndInit();
            pnlCommitTrend.ResumeLayout(false);
            pnlCommitTrend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartCommitTrend).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlLeaderboard).EndInit();
            pnlLeaderboard.ResumeLayout(false);
            pnlLeaderboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grdLeaderboard).EndInit();
            ((System.ComponentModel.ISupportInitialize)layoutViewLeaderboard).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlSummary).EndInit();
            pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlCardMatched).EndInit();
            pnlCardMatched.ResumeLayout(false);
            pnlCardMatched.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardAdditions).EndInit();
            pnlCardAdditions.ResumeLayout(false);
            pnlCardAdditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardContributors).EndInit();
            pnlCardContributors.ResumeLayout(false);
            pnlCardContributors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardCommits).EndInit();
            pnlCardCommits.ResumeLayout(false);
            pnlCardCommits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFilters).EndInit();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlEmpty).EndInit();
            pnlEmpty.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Header
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        
        // Filters
        private DevExpress.XtraEditors.PanelControl pnlFilters;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.LookUpEdit cmbProject;
        private DevExpress.XtraEditors.SimpleButton btnSync;
        private DevExpress.XtraEditors.SimpleButton btnLinkRepo;
        private DevExpress.XtraEditors.LabelControl lblSyncStatus;
        
        // Main scrollable container
        private DevExpress.XtraEditors.XtraScrollableControl pnlMain;
        
        // Summary Cards
        private DevExpress.XtraEditors.PanelControl pnlSummary;
        private DevExpress.XtraEditors.PanelControl pnlCardCommits;
        private DevExpress.XtraEditors.LabelControl lblCommitsValue;
        private DevExpress.XtraEditors.LabelControl lblCommitsLabel;
        private DevExpress.XtraEditors.PanelControl pnlCardContributors;
        private DevExpress.XtraEditors.LabelControl lblContributorsValue;
        private DevExpress.XtraEditors.LabelControl lblContributorsLabel;
        private DevExpress.XtraEditors.PanelControl pnlCardAdditions;
        private DevExpress.XtraEditors.LabelControl lblAdditionsValue;
        private DevExpress.XtraEditors.LabelControl lblAdditionsLabel;
        private DevExpress.XtraEditors.PanelControl pnlCardMatched;
        private DevExpress.XtraEditors.LabelControl lblMatchedValue;
        private DevExpress.XtraEditors.LabelControl lblMatchedLabel;
        
        // Leaderboard with LayoutView (Card style)
        private DevExpress.XtraEditors.PanelControl pnlLeaderboard;
        private DevExpress.XtraEditors.LabelControl lblLeaderboardTitle;
        private DevExpress.XtraGrid.GridControl grdLeaderboard;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutViewLeaderboard;
        
        // Recent Commits
        private DevExpress.XtraEditors.PanelControl pnlCommits;
        private DevExpress.XtraEditors.LabelControl lblCommitsTitle;
        private DevExpress.XtraGrid.GridControl grdCommits;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCommits;
        
        // Commit Trend Chart
        private DevExpress.XtraEditors.PanelControl pnlCommitTrend;
        private DevExpress.XtraEditors.LabelControl lblCommitTrendTitle;
        private DevExpress.XtraCharts.ChartControl chartCommitTrend;
        
        // Hotspots (Most Changed Files)
        private DevExpress.XtraEditors.PanelControl pnlHotspots;
        private DevExpress.XtraEditors.LabelControl lblHotspotsTitle;
        private DevExpress.XtraGrid.GridControl grdHotspots;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHotspots;
        
        // Empty State
        private DevExpress.XtraEditors.PanelControl pnlEmpty;
        private DevExpress.XtraEditors.LabelControl lblEmptyIcon;
        private DevExpress.XtraEditors.LabelControl lblEmptyTitle;
        private DevExpress.XtraEditors.LabelControl lblEmptyMessage;
    }
}
