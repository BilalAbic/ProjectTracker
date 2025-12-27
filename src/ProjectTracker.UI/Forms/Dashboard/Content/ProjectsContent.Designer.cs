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
            grdProjects = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            Status = new DevExpress.XtraGrid.Columns.GridColumn();
            CompletionPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            Priority = new DevExpress.XtraGrid.Columns.GridColumn();
            ManagerName = new DevExpress.XtraGrid.Columns.GridColumn();
            EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            Actions = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFilters).BeginInit();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbPriorityFilter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbStatusFilter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlGridContainer).BeginInit();
            pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grdProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(11, 11, 11);
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
            btnNewProject.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            btnNewProject.Appearance.BorderColor = Color.FromArgb(255, 77, 0);
            btnNewProject.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewProject.Appearance.ForeColor = Color.White;
            btnNewProject.Appearance.Options.UseBackColor = true;
            btnNewProject.Appearance.Options.UseBorderColor = true;
            btnNewProject.Appearance.Options.UseFont = true;
            btnNewProject.Appearance.Options.UseForeColor = true;
            btnNewProject.Location = new Point(960, 25);
            btnNewProject.Name = "btnNewProject";
            btnNewProject.Size = new Size(130, 36);
            btnNewProject.TabIndex = 2;
            btnNewProject.Text = "+ New Project";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.Appearance.ForeColor = Color.FromArgb(161, 161, 161, 161);
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSubtitle.Location = new Point(0, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(320, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage projects in one place";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Appearance.ForeColor = Color.White;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📁 Projects";
            // 
            // pnlFilters
            // 
            pnlFilters.Appearance.BackColor = Color.FromArgb(21, 21, 21);
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
            btnClearFilters.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            btnClearFilters.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            btnClearFilters.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClearFilters.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
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
            cmbPriorityFilter.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            cmbPriorityFilter.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            cmbPriorityFilter.Properties.Appearance.ForeColor = Color.White;
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
            cmbStatusFilter.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            cmbStatusFilter.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            cmbStatusFilter.Properties.Appearance.ForeColor = Color.White;
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
            txtSearch.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            txtSearch.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            txtSearch.Properties.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            txtSearch.Properties.Appearance.Options.UseBackColor = true;
            txtSearch.Properties.Appearance.Options.UseBorderColor = true;
            txtSearch.Properties.Appearance.Options.UseForeColor = true;
            txtSearch.Properties.AutoHeight = false;
            txtSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtSearch.Properties.NullText = "🔍 Search projects...";
            txtSearch.Size = new Size(300, 30);
            txtSearch.TabIndex = 0;
            // 
            // pnlGridContainer
            // 
            pnlGridContainer.Appearance.BackColor = Color.FromArgb(11, 11, 11);
            pnlGridContainer.Appearance.Options.UseBackColor = true;
            pnlGridContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlGridContainer.Controls.Add(grdProjects);
            pnlGridContainer.Dock = DockStyle.Fill;
            pnlGridContainer.Location = new Point(0, 140);
            pnlGridContainer.Name = "pnlGridContainer";
            pnlGridContainer.Padding = new Padding(0, 15, 0, 0);
            pnlGridContainer.Size = new Size(1100, 590);
            pnlGridContainer.TabIndex = 2;
            // 
            // grdProjects
            // 
            grdProjects.Dock = DockStyle.Fill;
            grdProjects.Location = new Point(0, 15);
            grdProjects.MainView = gridView1;
            grdProjects.Name = "grdProjects";
            grdProjects.Size = new Size(1100, 575);
            grdProjects.TabIndex = 0;
            grdProjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.Appearance.ColumnFilterButton.BackColor = Color.FromArgb(21, 21, 21);
            gridView1.Appearance.ColumnFilterButton.BorderColor = Color.FromArgb(42, 42, 42);
            gridView1.Appearance.ColumnFilterButton.ForeColor = Color.White;
            gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(42, 42, 42);
            gridView1.Appearance.FocusedRow.ForeColor = Color.White;
            gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView1.Appearance.HeaderPanel.BackColor = Color.FromArgb(26, 26, 26);
            gridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gridView1.Appearance.HeaderPanel.ForeColor = Color.FromArgb(161, 161, 161);
            gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridView1.Appearance.HorzLine.BackColor = Color.FromArgb(42, 42, 42);
            gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            gridView1.Appearance.Row.BackColor = Color.FromArgb(21, 21, 21);
            gridView1.Appearance.Row.ForeColor = Color.White;
            gridView1.Appearance.Row.Options.UseBackColor = true;
            gridView1.Appearance.Row.Options.UseForeColor = true;
            gridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(42, 42, 42);
            gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { ProjectName, Status, CompletionPercentage, Priority, ManagerName, EndDate, Actions });
            gridView1.GridControl = grdProjects;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // ProjectName
            // 
            ProjectName.AppearanceCell.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProjectName.AppearanceCell.Options.UseFont = true;
            ProjectName.Caption = "Project Name";
            ProjectName.Name = "ProjectName";
            ProjectName.OptionsColumn.AllowEdit = false;
            ProjectName.Visible = true;
            ProjectName.VisibleIndex = 0;
            ProjectName.Width = 599;
            // 
            // Status
            // 
            Status.Caption = "Status";
            Status.Name = "Status";
            Status.OptionsColumn.AllowEdit = false;
            Status.Visible = true;
            Status.VisibleIndex = 1;
            Status.Width = 69;
            // 
            // CompletionPercentage
            // 
            CompletionPercentage.Caption = "Progress";
            CompletionPercentage.Name = "CompletionPercentage";
            CompletionPercentage.Visible = true;
            CompletionPercentage.VisibleIndex = 2;
            CompletionPercentage.Width = 97;
            // 
            // Priority
            // 
            Priority.Caption = "Priority";
            Priority.Name = "Priority";
            Priority.OptionsColumn.AllowEdit = false;
            Priority.Visible = true;
            Priority.VisibleIndex = 3;
            Priority.Width = 73;
            // 
            // ManagerName
            // 
            ManagerName.Caption = "Manager";
            ManagerName.Name = "ManagerName";
            ManagerName.OptionsColumn.AllowEdit = false;
            ManagerName.Visible = true;
            ManagerName.VisibleIndex = 4;
            ManagerName.Width = 97;
            // 
            // EndDate
            // 
            EndDate.Caption = "Due Date";
            EndDate.DisplayFormat.FormatString = "dd MMM yyyy";
            EndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            EndDate.Name = "EndDate";
            EndDate.OptionsColumn.AllowEdit = false;
            EndDate.Visible = true;
            EndDate.VisibleIndex = 5;
            EndDate.Width = 91;
            // 
            // Actions
            // 
            Actions.FieldName = "Actions";
            Actions.Name = "Actions";
            Actions.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            Actions.OptionsFilter.AllowFilter = false;
            Actions.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            Actions.Visible = true;
            Actions.VisibleIndex = 6;
            Actions.Width = 80;
            // 
            // ProjectsContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 11, 11);
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
            ((System.ComponentModel.ISupportInitialize)grdProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
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
    }
}
