using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class ProjectsContent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new DevExpress.XtraEditors.PanelControl();
            btnNewProject = new DevExpress.XtraEditors.SimpleButton();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            pnlFilters = new DevExpress.XtraEditors.PanelControl();
            btnClearFilters = new DevExpress.XtraEditors.SimpleButton();
            cmbPriorityFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            cmbStatusFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            txtSearch = new DevExpress.XtraEditors.TextEdit();
            pnlGridContainer = new DevExpress.XtraEditors.PanelControl();
            pnlFooter = new DevExpress.XtraEditors.PanelControl();
            btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            lblRecordCount = new DevExpress.XtraEditors.LabelControl();
            grdProjects = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            Status = new DevExpress.XtraGrid.Columns.GridColumn();
            CompletionPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            Priority = new DevExpress.XtraGrid.Columns.GridColumn();
            ManagerName = new DevExpress.XtraGrid.Columns.GridColumn();
            EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            Actions = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFilters).BeginInit();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbPriorityFilter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbStatusFilter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlGridContainer).BeginInit();
            pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFooter).BeginInit();
            pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(btnNewProject);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnNewProject
            // 
            btnNewProject.Appearance.BackColor = Color.FromArgb(91, 141, 239);
            btnNewProject.Appearance.BorderColor = Color.FromArgb(91, 141, 239);
            btnNewProject.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewProject.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            btnNewProject.Appearance.Options.UseBackColor = true;
            btnNewProject.Appearance.Options.UseBorderColor = true;
            btnNewProject.Appearance.Options.UseFont = true;
            btnNewProject.Appearance.Options.UseForeColor = true;
            btnNewProject.Location = new Point(1010, 22);
            btnNewProject.Name = "btnNewProject";
            btnNewProject.Size = new Size(140, 36);
            btnNewProject.TabIndex = 2;
            btnNewProject.Text = "+ New Project";
            btnNewProject.Click += btnNewProject_Click;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.Appearance.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSubtitle.Location = new Point(0, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(320, 22);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage projects in one place";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📁 Projects";
            // 
            // pnlFilters
            // 
            pnlFilters.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlFilters.Appearance.Options.UseBackColor = true;
            pnlFilters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFilters.Controls.Add(btnClearFilters);
            pnlFilters.Controls.Add(cmbPriorityFilter);
            pnlFilters.Controls.Add(cmbStatusFilter);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 80);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(15, 12, 15, 12);
            pnlFilters.Size = new Size(1100, 60);
            pnlFilters.TabIndex = 1;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            btnClearFilters.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnClearFilters.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClearFilters.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnClearFilters.Appearance.Options.UseBackColor = true;
            btnClearFilters.Appearance.Options.UseBorderColor = true;
            btnClearFilters.Appearance.Options.UseFont = true;
            btnClearFilters.Appearance.Options.UseForeColor = true;
            btnClearFilters.Location = new Point(680, 15);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(80, 30);
            btnClearFilters.TabIndex = 3;
            btnClearFilters.Text = "Clear";
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // cmbPriorityFilter
            // 
            cmbPriorityFilter.Location = new Point(505, 15);
            cmbPriorityFilter.Name = "cmbPriorityFilter";
            cmbPriorityFilter.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            cmbPriorityFilter.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            cmbPriorityFilter.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            cmbPriorityFilter.Properties.Appearance.Options.UseBackColor = true;
            cmbPriorityFilter.Properties.Appearance.Options.UseBorderColor = true;
            cmbPriorityFilter.Properties.Appearance.Options.UseForeColor = true;
            cmbPriorityFilter.Properties.AutoHeight = false;
            cmbPriorityFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbPriorityFilter.Properties.Items.AddRange(new object[] { "All Priority", "Critical", "High", "Medium", "Low" });
            cmbPriorityFilter.Properties.NullText = "All Priority";
            cmbPriorityFilter.Size = new Size(160, 30);
            cmbPriorityFilter.TabIndex = 2;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.Location = new Point(330, 15);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            cmbStatusFilter.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            cmbStatusFilter.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            cmbStatusFilter.Properties.Appearance.Options.UseBackColor = true;
            cmbStatusFilter.Properties.Appearance.Options.UseBorderColor = true;
            cmbStatusFilter.Properties.Appearance.Options.UseForeColor = true;
            cmbStatusFilter.Properties.AutoHeight = false;
            cmbStatusFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbStatusFilter.Properties.Items.AddRange(new object[] { "All Status", "Planning", "Active", "On Hold", "Completed", "Cancelled" });
            cmbStatusFilter.Properties.NullText = "All Status";
            cmbStatusFilter.Size = new Size(160, 30);
            cmbStatusFilter.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.EditValue = "";
            txtSearch.Location = new Point(15, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            txtSearch.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtSearch.Properties.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            txtSearch.Properties.Appearance.Options.UseBackColor = true;
            txtSearch.Properties.Appearance.Options.UseBorderColor = true;
            txtSearch.Properties.Appearance.Options.UseForeColor = true;
            txtSearch.Properties.AutoHeight = false;
            txtSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtSearch.Properties.NullText = "🔍 Search projects...";
            txtSearch.Size = new Size(300, 30);
            txtSearch.TabIndex = 0;
            txtSearch.EditValueChanged += txtSearch_EditValueChanged;
            // 
            // pnlGridContainer
            // 
            pnlGridContainer.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlGridContainer.Appearance.Options.UseBackColor = true;
            pnlGridContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlGridContainer.Controls.Add(pnlFooter);
            pnlGridContainer.Controls.Add(grdProjects);
            pnlGridContainer.Dock = DockStyle.Fill;
            pnlGridContainer.Location = new Point(0, 140);
            pnlGridContainer.Name = "pnlGridContainer";
            pnlGridContainer.Padding = new Padding(0, 15, 0, 0);
            pnlGridContainer.Size = new Size(1100, 590);
            pnlGridContainer.TabIndex = 2;
            // 
            // pnlFooter
            // 
            pnlFooter.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlFooter.Appearance.Options.UseBackColor = true;
            pnlFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFooter.Controls.Add(btnRefresh);
            pnlFooter.Controls.Add(lblRecordCount);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 540);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1100, 50);
            pnlFooter.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            btnRefresh.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnRefresh.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnRefresh.Appearance.Options.UseBackColor = true;
            btnRefresh.Appearance.Options.UseBorderColor = true;
            btnRefresh.Appearance.Options.UseFont = true;
            btnRefresh.Appearance.Options.UseForeColor = true;
            btnRefresh.Location = new Point(1060, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Refresh";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecordCount.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblRecordCount.Appearance.Options.UseFont = true;
            lblRecordCount.Appearance.Options.UseForeColor = true;
            lblRecordCount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblRecordCount.Location = new Point(0, 15);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(200, 20);
            lblRecordCount.TabIndex = 0;
            lblRecordCount.Text = "Showing 0 of 0 projects";
            // 
            // grdProjects
            // 
            grdProjects.Dock = DockStyle.Fill;
            grdProjects.Location = new Point(0, 15);
            grdProjects.MainView = gridView1;
            grdProjects.Name = "grdProjects";
            grdProjects.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemProgressBar, repositoryItemButtonEdit });
            grdProjects.Size = new Size(1100, 575);
            grdProjects.TabIndex = 0;
            grdProjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // Scrollbar styling for dark theme
            grdProjects.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            grdProjects.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // gridView1
            // 
            gridView1.Appearance.ColumnFilterButton.BackColor = Color.FromArgb(36, 43, 61);
            gridView1.Appearance.ColumnFilterButton.BorderColor = Color.FromArgb(51, 65, 85);
            gridView1.Appearance.ColumnFilterButton.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            gridView1.Appearance.Empty.BackColor = Color.FromArgb(36, 43, 61);
            gridView1.Appearance.Empty.Font = new Font("Segoe UI", 8.25F);
            gridView1.Appearance.Empty.ForeColor = Color.FromArgb(203, 213, 225);
            gridView1.Appearance.Empty.Options.UseBackColor = true;
            gridView1.Appearance.Empty.Options.UseFont = true;
            gridView1.Appearance.Empty.Options.UseForeColor = true;
            gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridView1.Appearance.FocusedRow.Font = new Font("Segoe UI", 9.5F);
            gridView1.Appearance.FocusedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView1.Appearance.FocusedRow.Options.UseFont = true;
            gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView1.Appearance.FocusedCell.BackColor = Color.FromArgb(51, 65, 85);
            gridView1.Appearance.FocusedCell.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(30, 36, 47);
            gridView1.Appearance.HeaderPanel.BorderColor = Color.FromArgb(30, 36, 47);
            gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(180, 190, 200);
            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HorzLine.BackColor = Color.FromArgb(51, 65, 85);
            gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            gridView1.Appearance.Row.BackColor = Color.FromArgb(36, 43, 61);
            gridView1.Appearance.Row.Font = new Font("Segoe UI", 9.5F);
            gridView1.Appearance.Row.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Appearance.Row.Options.UseForeColor = true;
            gridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridView1.Appearance.SelectedRow.Font = new Font("Segoe UI", 9.5F);
            gridView1.Appearance.SelectedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            gridView1.Appearance.SelectedRow.Options.UseFont = true;
            gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            gridView1.Appearance.VertLine.BackColor = Color.FromArgb(51, 65, 85);
            gridView1.Appearance.VertLine.Options.UseBackColor = true;
            // Hover effect - HotTrack
            gridView1.Appearance.HideSelectionRow.BackColor = Color.FromArgb(45, 55, 72);
            gridView1.Appearance.HideSelectionRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            // OddRow for zebra pattern
            gridView1.Appearance.OddRow.BackColor = Color.FromArgb(32, 39, 52);
            gridView1.Appearance.OddRow.Font = new Font("Segoe UI", 9.5F);
            gridView1.Appearance.OddRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.OddRow.Options.UseBackColor = true;
            gridView1.Appearance.OddRow.Options.UseFont = true;
            gridView1.Appearance.OddRow.Options.UseForeColor = true;
            // EvenRow
            gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(36, 43, 61);
            gridView1.Appearance.EvenRow.Font = new Font("Segoe UI", 9.5F);
            gridView1.Appearance.EvenRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            gridView1.Appearance.EvenRow.Options.UseFont = true;
            gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            // Footer panel styling
            gridView1.Appearance.FooterPanel.BackColor = Color.FromArgb(30, 36, 47);
            gridView1.Appearance.FooterPanel.BorderColor = Color.FromArgb(51, 65, 85);
            gridView1.Appearance.FooterPanel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            gridView1.Appearance.FooterPanel.ForeColor = Color.FromArgb(180, 190, 200);
            gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            gridView1.Appearance.FooterPanel.Options.UseFont = true;
            gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            // Group row styling
            gridView1.Appearance.GroupRow.BackColor = Color.FromArgb(42, 50, 68);
            gridView1.Appearance.GroupRow.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            gridView1.Appearance.GroupRow.ForeColor = Color.FromArgb(91, 141, 239);
            gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            gridView1.Appearance.GroupRow.Options.UseFont = true;
            gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            // Preview row styling
            gridView1.Appearance.Preview.BackColor = Color.FromArgb(30, 36, 47);
            gridView1.Appearance.Preview.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            gridView1.Appearance.Preview.ForeColor = Color.FromArgb(148, 163, 184);
            gridView1.Appearance.Preview.Options.UseBackColor = true;
            gridView1.Appearance.Preview.Options.UseFont = true;
            gridView1.Appearance.Preview.Options.UseForeColor = true;
            gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            gridView1.ColumnPanelRowHeight = 40;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { ProjectName, Status, CompletionPercentage, Priority, ManagerName, EndDate, Actions });
            gridView1.GridControl = grdProjects;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsView.RowAutoHeight = false;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView1.OptionsMenu.EnableColumnMenu = true;
            gridView1.OptionsMenu.EnableFooterMenu = true;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            gridView1.PaintStyleName = "Web";
            gridView1.RowHeight = 36;
            gridView1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll | DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView1.RowClick += gridView1_RowClick;
            gridView1.CustomDrawCell += gridView1_CustomDrawCell;
            // 
            // ProjectName
            // 
            ProjectName.AppearanceCell.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            ProjectName.AppearanceCell.ForeColor = Color.FromArgb(248, 250, 252);
            ProjectName.AppearanceCell.Options.UseFont = true;
            ProjectName.AppearanceCell.Options.UseForeColor = true;
            ProjectName.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            ProjectName.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            ProjectName.AppearanceHeader.Options.UseFont = true;
            ProjectName.AppearanceHeader.Options.UseForeColor = true;
            ProjectName.Caption = "📁 Project Name";
            ProjectName.FieldName = "ProjectName";
            ProjectName.Name = "ProjectName";
            ProjectName.OptionsColumn.AllowEdit = false;
            ProjectName.Visible = true;
            ProjectName.VisibleIndex = 0;
            ProjectName.Width = 310;
            // 
            // Status
            // 
            Status.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Status.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            Status.AppearanceHeader.Options.UseFont = true;
            Status.AppearanceHeader.Options.UseForeColor = true;
            Status.Caption = "⚡   Status";
            Status.FieldName = "Status";
            Status.Name = "Status";
            Status.OptionsColumn.AllowEdit = false;
            Status.Visible = true;
            Status.VisibleIndex = 1;
            Status.Width = 120;
            // 
            // CompletionPercentage
            // 
            CompletionPercentage.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            CompletionPercentage.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            CompletionPercentage.AppearanceHeader.Options.UseFont = true;
            CompletionPercentage.AppearanceHeader.Options.UseForeColor = true;
            CompletionPercentage.Caption = "📊 Progress";
            CompletionPercentage.ColumnEdit = repositoryItemProgressBar;
            CompletionPercentage.FieldName = "CompletionPercentage";
            CompletionPercentage.Name = "CompletionPercentage";
            CompletionPercentage.Visible = true;
            CompletionPercentage.VisibleIndex = 2;
            CompletionPercentage.Width = 141;
            // 
            // repositoryItemProgressBar
            // 
            repositoryItemProgressBar.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            repositoryItemProgressBar.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            repositoryItemProgressBar.Name = "repositoryItemProgressBar";
            repositoryItemProgressBar.ShowTitle = true;
            // 
            // Priority
            // 
            Priority.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            Priority.AppearanceCell.Options.UseFont = true;
            Priority.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Priority.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            Priority.AppearanceHeader.Options.UseFont = true;
            Priority.AppearanceHeader.Options.UseForeColor = true;
            Priority.Caption = "🔥Priority";
            Priority.FieldName = "Priority";
            Priority.Name = "Priority";
            Priority.OptionsColumn.AllowEdit = false;
            Priority.Visible = true;
            Priority.VisibleIndex = 3;
            Priority.Width = 100;
            // 
            // ManagerName
            // 
            ManagerName.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            ManagerName.AppearanceCell.Options.UseFont = true;
            ManagerName.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            ManagerName.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            ManagerName.AppearanceHeader.Options.UseFont = true;
            ManagerName.AppearanceHeader.Options.UseForeColor = true;
            ManagerName.Caption = "👥Team";
            ManagerName.FieldName = "TeamName";
            ManagerName.Name = "ManagerName";
            ManagerName.OptionsColumn.AllowEdit = false;
            ManagerName.Visible = true;
            ManagerName.VisibleIndex = 4;
            ManagerName.Width = 120;
            // 
            // EndDate
            // 
            EndDate.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            EndDate.AppearanceCell.Options.UseFont = true;
            EndDate.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            EndDate.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            EndDate.AppearanceHeader.Options.UseFont = true;
            EndDate.AppearanceHeader.Options.UseForeColor = true;
            EndDate.Caption = "📅 Due Date";
            EndDate.DisplayFormat.FormatString = "dd MMM yyyy";
            EndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            EndDate.FieldName = "EndDate";
            EndDate.Name = "EndDate";
            EndDate.OptionsColumn.AllowEdit = false;
            EndDate.Visible = true;
            EndDate.VisibleIndex = 5;
            EndDate.Width = 110;
            // 
            // Actions
            // 
            Actions.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Actions.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            Actions.AppearanceHeader.Options.UseFont = true;
            Actions.AppearanceHeader.Options.UseForeColor = true;
            Actions.Caption = "⚙  Actions";
            Actions.ColumnEdit = repositoryItemButtonEdit;
            Actions.FieldName = "Actions";
            Actions.Name = "Actions";
            Actions.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            Actions.OptionsFilter.AllowFilter = false;
            Actions.UnboundType = DevExpress.Data.UnboundColumnType.String;
            Actions.Visible = true;
            Actions.VisibleIndex = 6;
            Actions.Width = 85;
            // 
            // repositoryItemButtonEdit
            // 
            repositoryItemButtonEdit.AutoHeight = false;
            repositoryItemButtonEdit.Name = "repositoryItemButtonEdit";
            repositoryItemButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            repositoryItemButtonEdit.Buttons.Clear();
            repositoryItemButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) { 
                    Caption = "✎", 
                    ToolTip = "Edit Project", 
                    Width = 26,
                    Appearance = { ForeColor = Color.FromArgb(91, 141, 239) }
                },
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) { 
                    Caption = "✕", 
                    ToolTip = "Delete Project", 
                    Width = 26,
                    Appearance = { ForeColor = Color.FromArgb(220, 80, 80) }
                }
            });
            // 
            // ProjectsContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 31, 38);
            Controls.Add(pnlGridContainer);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Name = "ProjectsContent";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFilters).EndInit();
            pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cmbPriorityFilter.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbStatusFilter.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlGridContainer).EndInit();
            pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFooter).EndInit();
            pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.SimpleButton btnNewProject;
        private DevExpress.XtraEditors.PanelControl pnlFilters;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStatusFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPriorityFilter;
        private DevExpress.XtraEditors.SimpleButton btnClearFilters;
        private DevExpress.XtraEditors.PanelControl pnlGridContainer;
        private DevExpress.XtraGrid.GridControl grdProjects;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraGrid.Columns.GridColumn CompletionPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn Priority;
        private DevExpress.XtraGrid.Columns.GridColumn ManagerName;
        private DevExpress.XtraGrid.Columns.GridColumn EndDate;
        private DevExpress.XtraGrid.Columns.GridColumn Actions;
        private DevExpress.XtraEditors.PanelControl pnlFooter;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl lblRecordCount;
        
        // Repository Items (moved from .cs file)
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit;
    }
}
