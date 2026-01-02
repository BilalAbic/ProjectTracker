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
            pnlHeader.Appearance.BackColor = ColorPalette.BackgroundDeepNavy;
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
            lblTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = ColorPalette.TextPrimary;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(215, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👥 Team Members";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 10F);
            lblSubtitle.Appearance.ForeColor = ColorPalette.TextSecondary;
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.Location = new Point(0, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(229, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage team members and their roles";
            // 
            // pnlFilters
            // 
            pnlFilters.Appearance.BackColor = ColorPalette.BackgroundSlateDark;
            pnlFilters.Appearance.Options.UseBackColor = true;
            pnlFilters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Controls.Add(cmbRoleFilter);
            pnlFilters.Controls.Add(btnClear);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 80);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1100, 60);
            pnlFilters.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(15, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Properties.Appearance.BackColor = ColorPalette.BackgroundSlateMedium;
            txtSearch.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtSearch.Properties.Appearance.ForeColor = ColorPalette.TextPrimary;
            txtSearch.Properties.Appearance.Options.UseBackColor = true;
            txtSearch.Properties.Appearance.Options.UseFont = true;
            txtSearch.Properties.Appearance.Options.UseForeColor = true;
            txtSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtSearch.Properties.NullText = "🔍 Search members...";
            txtSearch.Size = new Size(300, 22);
            txtSearch.TabIndex = 0;
            // 
            // cmbRoleFilter
            // 
            cmbRoleFilter.Location = new Point(330, 15);
            cmbRoleFilter.Name = "cmbRoleFilter";
            cmbRoleFilter.Properties.Appearance.BackColor = ColorPalette.BackgroundSlateMedium;
            cmbRoleFilter.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            cmbRoleFilter.Properties.Appearance.ForeColor = ColorPalette.TextPrimary;
            cmbRoleFilter.Properties.Appearance.Options.UseBackColor = true;
            cmbRoleFilter.Properties.Appearance.Options.UseFont = true;
            cmbRoleFilter.Properties.Appearance.Options.UseForeColor = true;
            cmbRoleFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cmbRoleFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbRoleFilter.Properties.Items.AddRange(new object[] { "All Roles", "Owner", "Admin", "Project Manager", "Developer", "Observer" });
            cmbRoleFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbRoleFilter.Size = new Size(160, 22);
            cmbRoleFilter.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Appearance.BackColor = ColorPalette.BorderSlate;
            btnClear.Appearance.Font = new Font("Segoe UI", 9F);
            btnClear.Appearance.ForeColor = ColorPalette.TextSecondary;
            btnClear.Appearance.Options.UseBackColor = true;
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
            // 
            // grvMembers
            // 
            grvMembers.Appearance.EvenRow.BackColor = ColorPalette.BackgroundSlateDark;
            grvMembers.Appearance.EvenRow.Options.UseBackColor = true;
            grvMembers.Appearance.HeaderPanel.BackColor = ColorPalette.BackgroundSlateDark;
            grvMembers.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grvMembers.Appearance.HeaderPanel.ForeColor = ColorPalette.TextSecondary;
            grvMembers.Appearance.HeaderPanel.Options.UseBackColor = true;
            grvMembers.Appearance.HeaderPanel.Options.UseFont = true;
            grvMembers.Appearance.HeaderPanel.Options.UseForeColor = true;
            grvMembers.Appearance.Row.BackColor = ColorPalette.BackgroundSlateDark;
            grvMembers.Appearance.Row.ForeColor = ColorPalette.TextPrimary;
            grvMembers.Appearance.Row.Options.UseBackColor = true;
            grvMembers.Appearance.Row.Options.UseForeColor = true;
            grvMembers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colInitials, colUserName, colEmail, colRole, colJoinedAt, colActions });
            grvMembers.GridControl = grdMembers;
            grvMembers.Name = "grvMembers";
            grvMembers.OptionsBehavior.Editable = false;
            grvMembers.OptionsView.EnableAppearanceEvenRow = true;
            grvMembers.OptionsView.ShowGroupPanel = false;
            // 
            // colInitials
            // 
            colInitials.FieldName = "Initials";
            colInitials.Name = "colInitials";
            colInitials.UnboundType = DevExpress.Data.UnboundColumnType.String;
            colInitials.Visible = true;
            colInitials.VisibleIndex = 0;
            colInitials.Width = 50;
            // 
            // colUserName
            // 
            colUserName.Caption = "Name";
            colUserName.FieldName = "UserName";
            colUserName.Name = "colUserName";
            colUserName.Visible = true;
            colUserName.VisibleIndex = 1;
            colUserName.Width = 200;
            // 
            // colEmail
            // 
            colEmail.Caption = "Email";
            colEmail.FieldName = "Email";
            colEmail.Name = "colEmail";
            colEmail.Visible = true;
            colEmail.VisibleIndex = 2;
            colEmail.Width = 250;
            // 
            // colRole
            // 
            colRole.Caption = "Role";
            colRole.ColumnEdit = repositoryItemComboBox1;
            colRole.FieldName = "Role";
            colRole.Name = "colRole";
            colRole.Visible = true;
            colRole.VisibleIndex = 3;
            colRole.Width = 150;
            // 
            // repositoryItemComboBox1
            // 
            repositoryItemComboBox1.AutoHeight = false;
            repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            repositoryItemComboBox1.Items.AddRange(new object[] { "Owner", "Admin", "ProjectManager", "Developer", "Observer" });
            repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // colJoinedAt
            // 
            colJoinedAt.Caption = "Joined";
            colJoinedAt.DisplayFormat.FormatString = "dd MMM yyyy";
            colJoinedAt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colJoinedAt.FieldName = "JoinedAt";
            colJoinedAt.Name = "colJoinedAt";
            colJoinedAt.Visible = true;
            colJoinedAt.VisibleIndex = 4;
            colJoinedAt.Width = 120;
            // 
            // colActions
            // 
            colActions.Caption = "Actions";
            colActions.FieldName = "Actions";
            colActions.Name = "colActions";
            colActions.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            colActions.Visible = true;
            colActions.VisibleIndex = 5;
            colActions.Width = 80;
            // 
            // TeamMembersContent
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorPalette.BackgroundDeepNavy;
            Controls.Add(grdMembers);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "TeamMembersContent";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
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
