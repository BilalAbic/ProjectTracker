using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class TeamMembersContent
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
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            pnlFilters = new DevExpress.XtraEditors.PanelControl();
            txtSearch = new DevExpress.XtraEditors.TextEdit();
            cmbRoleFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            btnClear = new DevExpress.XtraEditors.SimpleButton();
            grdMembers = new DevExpress.XtraGrid.GridControl();
            grvMembers = new DevExpress.XtraGrid.Views.Grid.GridView();
            colInitials = new DevExpress.XtraGrid.Columns.GridColumn();
            colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            colJoinedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            colActions = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFilters).BeginInit();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbRoleFilter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grdMembers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grvMembers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👥 Team Members";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 10F);
            lblSubtitle.Appearance.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSubtitle.Location = new Point(0, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(320, 22);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage team members and their roles";
            // 
            // pnlFilters
            // 
            pnlFilters.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlFilters.Appearance.Options.UseBackColor = true;
            pnlFilters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Controls.Add(cmbRoleFilter);
            pnlFilters.Controls.Add(btnClear);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 80);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(15, 12, 15, 12);
            pnlFilters.Size = new Size(1100, 60);
            pnlFilters.TabIndex = 1;
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
            txtSearch.Properties.NullText = "🔍 Search members...";
            txtSearch.Size = new Size(300, 30);
            txtSearch.TabIndex = 0;
            // 
            // cmbRoleFilter
            // 
            cmbRoleFilter.Location = new Point(330, 15);
            cmbRoleFilter.Name = "cmbRoleFilter";
            cmbRoleFilter.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            cmbRoleFilter.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            cmbRoleFilter.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            cmbRoleFilter.Properties.Appearance.Options.UseBackColor = true;
            cmbRoleFilter.Properties.Appearance.Options.UseBorderColor = true;
            cmbRoleFilter.Properties.Appearance.Options.UseForeColor = true;
            cmbRoleFilter.Properties.AutoHeight = false;
            cmbRoleFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbRoleFilter.Properties.Items.AddRange(new object[] { "All Roles", "Owner", "Admin", "Project Manager", "Developer", "Observer" });
            cmbRoleFilter.Properties.NullText = "All Roles";
            cmbRoleFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbRoleFilter.Size = new Size(160, 30);
            cmbRoleFilter.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            btnClear.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnClear.Appearance.Font = new Font("Segoe UI", 9F);
            btnClear.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnClear.Appearance.Options.UseBackColor = true;
            btnClear.Appearance.Options.UseBorderColor = true;
            btnClear.Appearance.Options.UseFont = true;
            btnClear.Appearance.Options.UseForeColor = true;
            btnClear.Location = new Point(505, 15);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 30);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            // 
            // grdMembers
            // 
            grdMembers.Dock = DockStyle.Fill;
            grdMembers.Location = new Point(0, 140);
            grdMembers.MainView = grvMembers;
            grdMembers.Name = "grdMembers";
            grdMembers.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemComboBox1 });
            grdMembers.Size = new Size(1100, 590);
            grdMembers.TabIndex = 2;
            grdMembers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { grvMembers });
            grdMembers.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            grdMembers.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // grvMembers
            // 
            grvMembers.Appearance.ColumnFilterButton.BackColor = Color.FromArgb(36, 43, 61);
            grvMembers.Appearance.ColumnFilterButton.BorderColor = Color.FromArgb(51, 65, 85);
            grvMembers.Appearance.ColumnFilterButton.ForeColor = Color.FromArgb(248, 250, 252);
            grvMembers.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            grvMembers.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            grvMembers.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            grvMembers.Appearance.Empty.BackColor = Color.FromArgb(36, 43, 61);
            grvMembers.Appearance.Empty.Font = new Font("Segoe UI", 8.25F);
            grvMembers.Appearance.Empty.ForeColor = Color.FromArgb(203, 213, 225);
            grvMembers.Appearance.Empty.Options.UseBackColor = true;
            grvMembers.Appearance.Empty.Options.UseFont = true;
            grvMembers.Appearance.Empty.Options.UseForeColor = true;
            grvMembers.Appearance.FocusedRow.BackColor = Color.FromArgb(51, 65, 85);
            grvMembers.Appearance.FocusedRow.Font = new Font("Segoe UI", 9.5F);
            grvMembers.Appearance.FocusedRow.ForeColor = Color.FromArgb(248, 250, 252);
            grvMembers.Appearance.FocusedRow.Options.UseBackColor = true;
            grvMembers.Appearance.FocusedRow.Options.UseFont = true;
            grvMembers.Appearance.FocusedRow.Options.UseForeColor = true;
            grvMembers.Appearance.FocusedCell.BackColor = Color.FromArgb(51, 65, 85);
            grvMembers.Appearance.FocusedCell.ForeColor = Color.FromArgb(248, 250, 252);
            grvMembers.Appearance.FocusedCell.Options.UseBackColor = true;
            grvMembers.Appearance.FocusedCell.Options.UseForeColor = true;
            grvMembers.Appearance.HeaderPanel.BackColor = Color.FromArgb(30, 36, 47);
            grvMembers.Appearance.HeaderPanel.BorderColor = Color.FromArgb(30, 36, 47);
            grvMembers.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grvMembers.Appearance.HeaderPanel.ForeColor = Color.FromArgb(180, 190, 200);
            grvMembers.Appearance.HeaderPanel.Options.UseBackColor = true;
            grvMembers.Appearance.HeaderPanel.Options.UseBorderColor = true;
            grvMembers.Appearance.HeaderPanel.Options.UseFont = true;
            grvMembers.Appearance.HeaderPanel.Options.UseForeColor = true;
            grvMembers.Appearance.HorzLine.BackColor = Color.FromArgb(51, 65, 85);
            grvMembers.Appearance.HorzLine.Options.UseBackColor = true;
            grvMembers.Appearance.Row.BackColor = Color.FromArgb(36, 43, 61);
            grvMembers.Appearance.Row.Font = new Font("Segoe UI", 9.5F);
            grvMembers.Appearance.Row.ForeColor = Color.FromArgb(248, 250, 252);
            grvMembers.Appearance.Row.Options.UseBackColor = true;
            grvMembers.Appearance.Row.Options.UseFont = true;
            grvMembers.Appearance.Row.Options.UseForeColor = true;
            grvMembers.Appearance.SelectedRow.BackColor = Color.FromArgb(51, 65, 85);
            grvMembers.Appearance.SelectedRow.Font = new Font("Segoe UI", 9.5F);
            grvMembers.Appearance.SelectedRow.ForeColor = Color.FromArgb(248, 250, 252);
            grvMembers.Appearance.SelectedRow.Options.UseBackColor = true;
            grvMembers.Appearance.SelectedRow.Options.UseFont = true;
            grvMembers.Appearance.SelectedRow.Options.UseForeColor = true;
            grvMembers.Appearance.VertLine.BackColor = Color.FromArgb(51, 65, 85);
            grvMembers.Appearance.VertLine.Options.UseBackColor = true;
            grvMembers.Appearance.HideSelectionRow.BackColor = Color.FromArgb(45, 55, 72);
            grvMembers.Appearance.HideSelectionRow.ForeColor = Color.FromArgb(248, 250, 252);
            grvMembers.Appearance.HideSelectionRow.Options.UseBackColor = true;
            grvMembers.Appearance.HideSelectionRow.Options.UseForeColor = true;
            grvMembers.Appearance.OddRow.BackColor = Color.FromArgb(32, 39, 52);
            grvMembers.Appearance.OddRow.Font = new Font("Segoe UI", 9.5F);
            grvMembers.Appearance.OddRow.ForeColor = Color.FromArgb(248, 250, 252);
            grvMembers.Appearance.OddRow.Options.UseBackColor = true;
            grvMembers.Appearance.OddRow.Options.UseFont = true;
            grvMembers.Appearance.OddRow.Options.UseForeColor = true;
            grvMembers.Appearance.EvenRow.BackColor = Color.FromArgb(36, 43, 61);
            grvMembers.Appearance.EvenRow.Font = new Font("Segoe UI", 9.5F);
            grvMembers.Appearance.EvenRow.ForeColor = Color.FromArgb(248, 250, 252);
            grvMembers.Appearance.EvenRow.Options.UseBackColor = true;
            grvMembers.Appearance.EvenRow.Options.UseFont = true;
            grvMembers.Appearance.EvenRow.Options.UseForeColor = true;
            grvMembers.Appearance.FooterPanel.BackColor = Color.FromArgb(30, 36, 47);
            grvMembers.Appearance.FooterPanel.BorderColor = Color.FromArgb(51, 65, 85);
            grvMembers.Appearance.FooterPanel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grvMembers.Appearance.FooterPanel.ForeColor = Color.FromArgb(180, 190, 200);
            grvMembers.Appearance.FooterPanel.Options.UseBackColor = true;
            grvMembers.Appearance.FooterPanel.Options.UseBorderColor = true;
            grvMembers.Appearance.FooterPanel.Options.UseFont = true;
            grvMembers.Appearance.FooterPanel.Options.UseForeColor = true;
            grvMembers.Appearance.GroupRow.BackColor = Color.FromArgb(42, 50, 68);
            grvMembers.Appearance.GroupRow.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grvMembers.Appearance.GroupRow.ForeColor = Color.FromArgb(91, 141, 239);
            grvMembers.Appearance.GroupRow.Options.UseBackColor = true;
            grvMembers.Appearance.GroupRow.Options.UseFont = true;
            grvMembers.Appearance.GroupRow.Options.UseForeColor = true;
            grvMembers.Appearance.Preview.BackColor = Color.FromArgb(30, 36, 47);
            grvMembers.Appearance.Preview.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            grvMembers.Appearance.Preview.ForeColor = Color.FromArgb(148, 163, 184);
            grvMembers.Appearance.Preview.Options.UseBackColor = true;
            grvMembers.Appearance.Preview.Options.UseFont = true;
            grvMembers.Appearance.Preview.Options.UseForeColor = true;
            grvMembers.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            grvMembers.ColumnPanelRowHeight = 40;
            grvMembers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colInitials, colUserName, colEmail, colRole, colJoinedAt, colActions });
            grvMembers.GridControl = grdMembers;
            grvMembers.Name = "grvMembers";
            grvMembers.OptionsView.ShowGroupPanel = false;
            grvMembers.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            grvMembers.OptionsView.ShowIndicator = false;
            grvMembers.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            grvMembers.OptionsView.RowAutoHeight = false;
            grvMembers.OptionsView.EnableAppearanceOddRow = true;
            grvMembers.OptionsView.EnableAppearanceEvenRow = true;
            grvMembers.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem;
            grvMembers.OptionsSelection.EnableAppearanceFocusedCell = true;
            grvMembers.OptionsSelection.EnableAppearanceFocusedRow = true;
            grvMembers.OptionsMenu.EnableColumnMenu = true;
            grvMembers.OptionsMenu.EnableFooterMenu = true;
            grvMembers.OptionsMenu.EnableGroupPanelMenu = false;
            grvMembers.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.True;
            grvMembers.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            grvMembers.PaintStyleName = "Web";
            grvMembers.RowHeight = 36;
            grvMembers.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll | DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            grvMembers.OptionsBehavior.Editable = false;
            // 
            // colInitials
            // 
            colInitials.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            colInitials.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            colInitials.AppearanceHeader.Options.UseFont = true;
            colInitials.AppearanceHeader.Options.UseForeColor = true;
            colInitials.Caption = "";
            colInitials.FieldName = "Initials";
            colInitials.Name = "colInitials";
            colInitials.UnboundType = DevExpress.Data.UnboundColumnType.String;
            colInitials.Visible = true;
            colInitials.VisibleIndex = 0;
            colInitials.Width = 50;
            colInitials.OptionsColumn.AllowEdit = false;
            // 
            // colUserName
            // 
            colUserName.AppearanceCell.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            colUserName.AppearanceCell.ForeColor = Color.FromArgb(248, 250, 252);
            colUserName.AppearanceCell.Options.UseFont = true;
            colUserName.AppearanceCell.Options.UseForeColor = true;
            colUserName.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            colUserName.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            colUserName.AppearanceHeader.Options.UseFont = true;
            colUserName.AppearanceHeader.Options.UseForeColor = true;
            colUserName.Caption = "👤 Name";
            colUserName.FieldName = "UserName";
            colUserName.Name = "colUserName";
            colUserName.Visible = true;
            colUserName.VisibleIndex = 1;
            colUserName.Width = 200;
            colUserName.OptionsColumn.AllowEdit = false;
            // 
            // colEmail
            // 
            colEmail.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            colEmail.AppearanceCell.Options.UseFont = true;
            colEmail.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            colEmail.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            colEmail.AppearanceHeader.Options.UseFont = true;
            colEmail.AppearanceHeader.Options.UseForeColor = true;
            colEmail.Caption = "📧 Email";
            colEmail.FieldName = "Email";
            colEmail.Name = "colEmail";
            colEmail.Visible = true;
            colEmail.VisibleIndex = 2;
            colEmail.Width = 280;
            colEmail.OptionsColumn.AllowEdit = false;
            // 
            // colRole
            // 
            colRole.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            colRole.AppearanceCell.Options.UseFont = true;
            colRole.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            colRole.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            colRole.AppearanceHeader.Options.UseFont = true;
            colRole.AppearanceHeader.Options.UseForeColor = true;
            colRole.Caption = "🔑 Role";
            colRole.ColumnEdit = repositoryItemComboBox1;
            colRole.FieldName = "RoleName";
            colRole.Name = "colRole";
            colRole.Visible = true;
            colRole.VisibleIndex = 3;
            colRole.Width = 150;
            // 
            // repositoryItemComboBox1
            // 
            repositoryItemComboBox1.AutoHeight = false;
            repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox1.Items.AddRange(new object[] { "Owner", "Admin", "Project Manager", "Developer", "Observer" });
            repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colJoinedAt
            // 
            colJoinedAt.AppearanceCell.Font = new Font("Segoe UI", 9.5F);
            colJoinedAt.AppearanceCell.Options.UseFont = true;
            colJoinedAt.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            colJoinedAt.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            colJoinedAt.AppearanceHeader.Options.UseFont = true;
            colJoinedAt.AppearanceHeader.Options.UseForeColor = true;
            colJoinedAt.Caption = "📅 Joined";
            colJoinedAt.DisplayFormat.FormatString = "dd MMM yyyy";
            colJoinedAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colJoinedAt.FieldName = "JoinedAt";
            colJoinedAt.Name = "colJoinedAt";
            colJoinedAt.Visible = true;
            colJoinedAt.VisibleIndex = 4;
            colJoinedAt.Width = 120;
            colJoinedAt.OptionsColumn.AllowEdit = false;
            // 
            // colActions
            // 
            colActions.AppearanceHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            colActions.AppearanceHeader.ForeColor = Color.FromArgb(180, 190, 200);
            colActions.AppearanceHeader.Options.UseFont = true;
            colActions.AppearanceHeader.Options.UseForeColor = true;
            colActions.Caption = "⚙ Actions";
            colActions.FieldName = "Actions";
            colActions.Name = "colActions";
            colActions.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            colActions.Visible = true;
            colActions.VisibleIndex = 5;
            colActions.Width = 80;
            colActions.OptionsColumn.AllowEdit = false;
            // 
            // TeamMembersContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 31, 38);
            Controls.Add(grdMembers);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "TeamMembersContent";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFilters).EndInit();
            pnlFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbRoleFilter.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grdMembers).EndInit();
            ((System.ComponentModel.ISupportInitialize)grvMembers).EndInit();
            ((System.ComponentModel.ISupportInitialize)repositoryItemComboBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.PanelControl pnlFilters;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRoleFilter;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraGrid.GridControl grdMembers;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMembers;
        private DevExpress.XtraGrid.Columns.GridColumn colInitials;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colJoinedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colActions;
    }
}