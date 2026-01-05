using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class TasksContent
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
            btnViewSwitcher = new DevExpress.XtraEditors.SimpleButton();
            btnNewTask = new DevExpress.XtraEditors.SimpleButton();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            pnlFilters = new DevExpress.XtraEditors.PanelControl();
            btnClearFilters = new DevExpress.XtraEditors.SimpleButton();
            cmbPriorityFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            cmbProjectFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            txtSearch = new DevExpress.XtraEditors.TextEdit();
            pnlContentContainer = new DevExpress.XtraEditors.PanelControl();
            grdKanban = new DevExpress.XtraGrid.GridControl();
            tileViewKanban = new DevExpress.XtraGrid.Views.Tile.TileView();
            tileViewColumn1 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            tileViewColumn2 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            tileViewColumn3 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            tileViewColumn4 = new DevExpress.XtraGrid.Columns.TileViewColumn();
            grdTasks = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            TaskName = new DevExpress.XtraGrid.Columns.GridColumn();
            ProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            AssignedUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            StatusColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            PriorityColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            DueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            CompletionPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            Actions = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlFooter = new DevExpress.XtraEditors.PanelControl();
            btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            lblRecordCount = new DevExpress.XtraEditors.LabelControl();
            // Repository Items
            repositoryItemProgressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            repositoryItemButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFilters).BeginInit();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbPriorityFilter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbProjectFilter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlContentContainer).BeginInit();
            pnlContentContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdKanban).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tileViewKanban).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdTasks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlFooter).BeginInit();
            pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(btnViewSwitcher);
            pnlHeader.Controls.Add(btnNewTask);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnViewSwitcher
            // 
            btnViewSwitcher.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewSwitcher.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            btnViewSwitcher.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnViewSwitcher.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnViewSwitcher.Appearance.ForeColor = Color.White;
            btnViewSwitcher.Appearance.Options.UseBackColor = true;
            btnViewSwitcher.Appearance.Options.UseBorderColor = true;
            btnViewSwitcher.Appearance.Options.UseFont = true;
            btnViewSwitcher.Appearance.Options.UseForeColor = true;
            btnViewSwitcher.Location = new Point(830, 25);
            btnViewSwitcher.Name = "btnViewSwitcher";
            btnViewSwitcher.Size = new Size(120, 36);
            btnViewSwitcher.TabIndex = 3;
            btnViewSwitcher.Text = "📊 Kanban View";
            // 
            // btnNewTask
            // 
            btnNewTask.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewTask.Appearance.BackColor = Color.FromArgb(91, 141, 239);
            btnNewTask.Appearance.BorderColor = Color.FromArgb(91, 141, 239);
            btnNewTask.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewTask.Appearance.ForeColor = Color.White;
            btnNewTask.Appearance.Options.UseBackColor = true;
            btnNewTask.Appearance.Options.UseBorderColor = true;
            btnNewTask.Appearance.Options.UseFont = true;
            btnNewTask.Appearance.Options.UseForeColor = true;
            btnNewTask.Location = new Point(960, 22);
            btnNewTask.Name = "btnNewTask";
            btnNewTask.Size = new Size(130, 36);
            btnNewTask.TabIndex = 2;
            btnNewTask.Text = "+ New Task";
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
            lblSubtitle.Size = new Size(350, 22);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage tasks and track progress";
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
            lblTitle.Text = "✅   Tasks";
            // 
            // pnlFilters
            // 
            pnlFilters.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlFilters.Appearance.Options.UseBackColor = true;
            pnlFilters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFilters.Controls.Add(btnClearFilters);
            pnlFilters.Controls.Add(cmbPriorityFilter);
            pnlFilters.Controls.Add(cmbProjectFilter);
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
            // 
            // cmbPriorityFilter
            // 
            cmbPriorityFilter.Location = new Point(505, 15);
            cmbPriorityFilter.Name = "cmbPriorityFilter";
            cmbPriorityFilter.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            cmbPriorityFilter.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            cmbPriorityFilter.Properties.Appearance.ForeColor = Color.White;
            cmbPriorityFilter.Properties.Appearance.Options.UseBackColor = true;
            cmbPriorityFilter.Properties.Appearance.Options.UseBorderColor = true;
            cmbPriorityFilter.Properties.Appearance.Options.UseForeColor = true;
            cmbPriorityFilter.Properties.AutoHeight = false;
            cmbPriorityFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cmbPriorityFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbPriorityFilter.Properties.Items.AddRange(new object[] { "All Priority", "Critical", "High", "Medium", "Low" });
            cmbPriorityFilter.Properties.NullText = "All Priority";
            cmbPriorityFilter.Size = new Size(160, 30);
            cmbPriorityFilter.TabIndex = 2;
            // 
            // cmbProjectFilter
            // 
            cmbProjectFilter.Location = new Point(330, 15);
            cmbProjectFilter.Name = "cmbProjectFilter";
            cmbProjectFilter.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            cmbProjectFilter.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            cmbProjectFilter.Properties.Appearance.ForeColor = Color.White;
            cmbProjectFilter.Properties.Appearance.Options.UseBackColor = true;
            cmbProjectFilter.Properties.Appearance.Options.UseBorderColor = true;
            cmbProjectFilter.Properties.Appearance.Options.UseForeColor = true;
            cmbProjectFilter.Properties.AutoHeight = false;
            cmbProjectFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cmbProjectFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbProjectFilter.Properties.NullText = "All Projects";
            cmbProjectFilter.Size = new Size(160, 30);
            cmbProjectFilter.TabIndex = 1;
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
            txtSearch.Properties.NullText = "🔍 Search tasks...";
            txtSearch.Size = new Size(300, 30);
            txtSearch.TabIndex = 0;
            // 
            // pnlContentContainer
            // 
            pnlContentContainer.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlContentContainer.Appearance.Options.UseBackColor = true;
            pnlContentContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlContentContainer.Controls.Add(grdKanban);
            pnlContentContainer.Controls.Add(grdTasks);
            pnlContentContainer.Controls.Add(pnlFooter);
            pnlContentContainer.Dock = DockStyle.Fill;
            pnlContentContainer.Location = new Point(0, 140);
            pnlContentContainer.Name = "pnlContentContainer";
            pnlContentContainer.Padding = new Padding(0, 15, 0, 0);
            pnlContentContainer.Size = new Size(1100, 590);
            pnlContentContainer.TabIndex = 2;
            // 
            // grdKanban
            // 
            grdKanban.Dock = DockStyle.Fill;
            grdKanban.Location = new Point(0, 15);
            grdKanban.MainView = tileViewKanban;
            grdKanban.Name = "grdKanban";
            grdKanban.Size = new Size(1100, 525);
            grdKanban.TabIndex = 3;
            grdKanban.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { tileViewKanban });
            grdKanban.Visible = false;
            // 
            // tileViewKanban
            // 
            tileViewKanban.Appearance.EmptySpace.BackColor = Color.FromArgb(26, 31, 38);
            tileViewKanban.Appearance.EmptySpace.Options.UseBackColor = true;
            tileViewKanban.Appearance.Group.BackColor = Color.FromArgb(26, 31, 38);
            tileViewKanban.Appearance.Group.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            tileViewKanban.Appearance.Group.ForeColor = Color.FromArgb(248, 250, 252);
            tileViewKanban.Appearance.Group.Options.UseBackColor = true;
            tileViewKanban.Appearance.Group.Options.UseFont = true;
            tileViewKanban.Appearance.Group.Options.UseForeColor = true;
            tileViewKanban.Appearance.Group.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            tileViewKanban.Appearance.Group.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tileViewKanban.Appearance.ItemHovered.BackColor = Color.FromArgb(42, 63, 95);
            tileViewKanban.Appearance.ItemHovered.BorderColor = Color.FromArgb(91, 141, 239);
            tileViewKanban.Appearance.ItemHovered.Options.UseBackColor = true;
            tileViewKanban.Appearance.ItemHovered.Options.UseBorderColor = true;
            tileViewKanban.Appearance.ItemNormal.BackColor = Color.FromArgb(30, 42, 58);
            tileViewKanban.Appearance.ItemNormal.BorderColor = Color.FromArgb(51, 65, 85);
            tileViewKanban.Appearance.ItemNormal.ForeColor = Color.White;
            tileViewKanban.Appearance.ItemNormal.Options.UseBackColor = true;
            tileViewKanban.Appearance.ItemNormal.Options.UseBorderColor = true;
            tileViewKanban.Appearance.ItemNormal.Options.UseForeColor = true;
            tileViewKanban.Appearance.ViewCaption.BackColor = Color.FromArgb(26, 31, 38);
            tileViewKanban.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { tileViewColumn1, tileViewColumn2, tileViewColumn3, tileViewColumn4 });
            tileViewKanban.GridControl = grdKanban;
            tileViewKanban.Name = "tileViewKanban";
            tileViewKanban.OptionsDragDrop.AllowDrag = true;
            tileViewKanban.OptionsTiles.ItemSize = new Size(240, 100);
            tileViewKanban.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.Kanban;
            tileViewKanban.OptionsTiles.Padding = new Padding(8);
            // 
            // tileViewColumn1
            // 
            tileViewColumn1.Caption = "tileViewColumn1";
            tileViewColumn1.Name = "tileViewColumn1";
            tileViewColumn1.Visible = true;
            tileViewColumn1.VisibleIndex = 0;
            // 
            // tileViewColumn2
            // 
            tileViewColumn2.Caption = "tileViewColumn2";
            tileViewColumn2.Name = "tileViewColumn2";
            tileViewColumn2.Visible = true;
            tileViewColumn2.VisibleIndex = 1;
            // 
            // tileViewColumn3
            // 
            tileViewColumn3.Caption = "tileViewColumn3";
            tileViewColumn3.Name = "tileViewColumn3";
            tileViewColumn3.Visible = true;
            tileViewColumn3.VisibleIndex = 2;
            // 
            // tileViewColumn4
            // 
            tileViewColumn4.Caption = "tileViewColumn4";
            tileViewColumn4.Name = "tileViewColumn4";
            tileViewColumn4.Visible = true;
            tileViewColumn4.VisibleIndex = 3;
            // 
            // grdTasks
            // 
            grdTasks.Dock = DockStyle.Fill;
            grdTasks.Location = new Point(0, 15);
            grdTasks.MainView = gridView1;
            grdTasks.Name = "grdTasks";
            grdTasks.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemProgressBar, repositoryItemButtonEdit });
            grdTasks.Size = new Size(1100, 525);
            grdTasks.TabIndex = 0;
            grdTasks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // Scrollbar styling for dark theme
            grdTasks.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            grdTasks.LookAndFeel.UseDefaultLookAndFeel = false;
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
            gridView1.Appearance.Empty.ForeColor = Color.FromArgb(203, 213, 225);
            gridView1.Appearance.Empty.Options.UseBackColor = true;
            gridView1.Appearance.Empty.Options.UseForeColor = true;
            gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridView1.Appearance.FocusedRow.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
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
            gridView1.Appearance.Row.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            gridView1.Appearance.Row.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.Row.Options.UseFont = true;
            gridView1.Appearance.Row.Options.UseForeColor = true;
            gridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridView1.Appearance.SelectedRow.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
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
            gridView1.Appearance.OddRow.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            gridView1.Appearance.OddRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridView1.Appearance.OddRow.Options.UseBackColor = true;
            gridView1.Appearance.OddRow.Options.UseFont = true;
            gridView1.Appearance.OddRow.Options.UseForeColor = true;
            // EvenRow
            gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(36, 43, 61);
            gridView1.Appearance.EvenRow.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
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
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { TaskName, ProjectName, AssignedUserName, StatusColumn, PriorityColumn, DueDate, CompletionPercentage, Actions });
            gridView1.GridControl = grdTasks;
            gridView1.Name = "gridView1";
            gridView1.RowHeight = 36;
            gridView1.ColumnPanelRowHeight = 40;
            gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
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
            gridView1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll | DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView1.PaintStyleName = "Web";
            // 
            // TaskName
            // 
            TaskName.AppearanceCell.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            TaskName.AppearanceCell.ForeColor = Color.FromArgb(248, 250, 252);
            TaskName.AppearanceCell.Options.UseFont = true;
            TaskName.AppearanceCell.Options.UseForeColor = true;
            TaskName.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            TaskName.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            TaskName.AppearanceHeader.Options.UseFont = true;
            TaskName.AppearanceHeader.Options.UseForeColor = true;
            TaskName.Caption = "📋 Task Name";
            TaskName.FieldName = "TaskName";
            TaskName.Name = "TaskName";
            TaskName.OptionsColumn.AllowEdit = false;
            TaskName.Visible = true;
            TaskName.VisibleIndex = 0;
            TaskName.Width = 200;
            // 
            // ProjectName
            // 
            ProjectName.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            ProjectName.AppearanceCell.Options.UseFont = true;
            ProjectName.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            ProjectName.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            ProjectName.AppearanceHeader.Options.UseFont = true;
            ProjectName.AppearanceHeader.Options.UseForeColor = true;
            ProjectName.Caption = "📁 Project";
            ProjectName.FieldName = "ProjectName";
            ProjectName.Name = "ProjectName";
            ProjectName.OptionsColumn.AllowEdit = false;
            ProjectName.Visible = true;
            ProjectName.VisibleIndex = 1;
            ProjectName.Width = 130;
            // 
            // AssignedUserName
            // 
            AssignedUserName.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            AssignedUserName.AppearanceCell.Options.UseFont = true;
            AssignedUserName.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            AssignedUserName.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            AssignedUserName.AppearanceHeader.Options.UseFont = true;
            AssignedUserName.AppearanceHeader.Options.UseForeColor = true;
            AssignedUserName.Caption = "👤 Assignee";
            AssignedUserName.FieldName = "AssignedToUserName";
            AssignedUserName.Name = "AssignedUserName";
            AssignedUserName.OptionsColumn.AllowEdit = false;
            AssignedUserName.Visible = true;
            AssignedUserName.VisibleIndex = 2;
            AssignedUserName.Width = 110;
            // 
            // StatusColumn
            // 
            StatusColumn.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            StatusColumn.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            StatusColumn.AppearanceHeader.Options.UseFont = true;
            StatusColumn.AppearanceHeader.Options.UseForeColor = true;
            StatusColumn.Caption = "⚡   Status";
            StatusColumn.FieldName = "Status";
            StatusColumn.Name = "StatusColumn";
            StatusColumn.OptionsColumn.AllowEdit = false;
            StatusColumn.Visible = true;
            StatusColumn.VisibleIndex = 3;
            StatusColumn.Width = 100;
            // 
            // PriorityColumn
            // 
            PriorityColumn.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            PriorityColumn.AppearanceCell.Options.UseFont = true;
            PriorityColumn.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            PriorityColumn.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            PriorityColumn.AppearanceHeader.Options.UseFont = true;
            PriorityColumn.AppearanceHeader.Options.UseForeColor = true;
            PriorityColumn.Caption = "🔥 Priority";
            PriorityColumn.FieldName = "Priority";
            PriorityColumn.Name = "PriorityColumn";
            PriorityColumn.OptionsColumn.AllowEdit = false;
            PriorityColumn.Visible = true;
            PriorityColumn.VisibleIndex = 4;
            PriorityColumn.Width = 90;
            // 
            // DueDate
            // 
            DueDate.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            DueDate.AppearanceCell.Options.UseFont = true;
            DueDate.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            DueDate.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            DueDate.AppearanceHeader.Options.UseFont = true;
            DueDate.AppearanceHeader.Options.UseForeColor = true;
            DueDate.Caption = "📅 Due Date";
            DueDate.DisplayFormat.FormatString = "dd MMM yyyy";
            DueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            DueDate.FieldName = "DueDate";
            DueDate.Name = "DueDate";
            DueDate.OptionsColumn.AllowEdit = false;
            DueDate.Visible = true;
            DueDate.VisibleIndex = 5;
            DueDate.Width = 110;
            // 
            // CompletionPercentage
            // 
            CompletionPercentage.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            CompletionPercentage.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            CompletionPercentage.AppearanceHeader.Options.UseFont = true;
            CompletionPercentage.AppearanceHeader.Options.UseForeColor = true;
            CompletionPercentage.Caption = "📊 Progress";
            CompletionPercentage.FieldName = "CompletionPercentage";
            CompletionPercentage.Name = "CompletionPercentage";
            CompletionPercentage.Visible = true;
            CompletionPercentage.VisibleIndex = 6;
            CompletionPercentage.Width = 100;
            CompletionPercentage.ColumnEdit = repositoryItemProgressBar;
            // 
            // Actions
            // 
            Actions.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Actions.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            Actions.AppearanceHeader.Options.UseFont = true;
            Actions.AppearanceHeader.Options.UseForeColor = true;
            Actions.Caption = "⚙  Actions";
            Actions.FieldName = "Actions";
            Actions.Name = "Actions";
            Actions.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            Actions.OptionsFilter.AllowFilter = false;
            Actions.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            Actions.Visible = true;
            Actions.VisibleIndex = 7;
            Actions.Width = 85;
            Actions.ColumnEdit = repositoryItemButtonEdit;
            // 
            // repositoryItemProgressBar
            // 
            repositoryItemProgressBar.Minimum = 0;
            repositoryItemProgressBar.Maximum = 100;
            repositoryItemProgressBar.ShowTitle = true;
            repositoryItemProgressBar.PercentView = true;
            repositoryItemProgressBar.Name = "repositoryItemProgressBar";
            repositoryItemProgressBar.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            repositoryItemProgressBar.Appearance.ForeColor = Color.FromArgb(34, 197, 94);
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
                    ToolTip = "Edit Task", 
                    Width = 26,
                    Appearance = { ForeColor = Color.FromArgb(91, 141, 239) }
                },
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph) { 
                    Caption = "✕", 
                    ToolTip = "Delete Task", 
                    Width = 26,
                    Appearance = { ForeColor = Color.FromArgb(220, 80, 80) }
                }
            });
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
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            btnRefresh.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnRefresh.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnRefresh.Appearance.Options.UseBackColor = true;
            btnRefresh.Appearance.Options.UseBorderColor = true;
            btnRefresh.Appearance.Options.UseFont = true;
            btnRefresh.Appearance.Options.UseForeColor = true;
            btnRefresh.Location = new Point(1000, 10);
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
            lblRecordCount.Text = "Showing 0 of 0 tasks";
            // 
            // TasksContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 31, 38);
            Controls.Add(pnlContentContainer);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Name = "TasksContent";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFilters).EndInit();
            pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cmbPriorityFilter.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbProjectFilter.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlContentContainer).EndInit();
            pnlContentContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grdKanban).EndInit();
            ((System.ComponentModel.ISupportInitialize)tileViewKanban).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdTasks).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlFooter).EndInit();
            pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemButtonEdit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.SimpleButton btnNewTask;
        private DevExpress.XtraEditors.SimpleButton btnViewSwitcher;
        private DevExpress.XtraEditors.PanelControl pnlFilters;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProjectFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPriorityFilter;
        private DevExpress.XtraEditors.SimpleButton btnClearFilters;
        private DevExpress.XtraEditors.PanelControl pnlContentContainer;
        private DevExpress.XtraGrid.GridControl grdTasks;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn TaskName;
        private DevExpress.XtraGrid.Columns.GridColumn ProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn AssignedUserName;
        private DevExpress.XtraGrid.Columns.GridColumn StatusColumn;
        private DevExpress.XtraGrid.Columns.GridColumn PriorityColumn;
        private DevExpress.XtraGrid.Columns.GridColumn DueDate;
        private DevExpress.XtraGrid.Columns.GridColumn CompletionPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn Actions;
        private DevExpress.XtraGrid.GridControl grdKanban;
        private DevExpress.XtraGrid.Views.Tile.TileView tileViewKanban;
        private DevExpress.XtraEditors.PanelControl pnlFooter;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.LabelControl lblRecordCount;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn2;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn3;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumn4;
        
        // Repository Items (moved from .cs file)
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit;
    }
}
