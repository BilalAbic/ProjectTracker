namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class TeamDetailControl
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
            btnBack = new DevExpress.XtraEditors.SimpleButton();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            grpTeamInfo = new DevExpress.XtraEditors.GroupControl();
            lblTeamName = new DevExpress.XtraEditors.LabelControl();
            txtTeamName = new DevExpress.XtraEditors.TextEdit();
            lblDescription = new DevExpress.XtraEditors.LabelControl();
            txtDescription = new DevExpress.XtraEditors.MemoEdit();
            grpStatistics = new DevExpress.XtraEditors.GroupControl();
            lblStats = new DevExpress.XtraEditors.LabelControl();
            btnViewMembers = new DevExpress.XtraEditors.SimpleButton();
            btnViewInvitations = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grpTeamInfo).BeginInit();
            grpTeamInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtTeamName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grpStatistics).BeginInit();
            grpStatistics.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(11, 11, 11);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            btnBack.Appearance.Font = new Font("Segoe UI", 9F);
            btnBack.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            btnBack.Appearance.Options.UseBackColor = true;
            btnBack.Appearance.Options.UseFont = true;
            btnBack.Appearance.Options.UseForeColor = true;
            btnBack.Location = new Point(10, 25);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(80, 30);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.Click += btnBack_Click;
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new Point(100, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(181, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "🏢 Create Team";
            // 
            // grpTeamInfo
            // 
            grpTeamInfo.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            grpTeamInfo.Appearance.Options.UseBackColor = true;
            grpTeamInfo.AppearanceCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpTeamInfo.AppearanceCaption.ForeColor = Color.FromArgb(255, 77, 0);
            grpTeamInfo.AppearanceCaption.Options.UseFont = true;
            grpTeamInfo.AppearanceCaption.Options.UseForeColor = true;
            grpTeamInfo.Controls.Add(lblTeamName);
            grpTeamInfo.Controls.Add(txtTeamName);
            grpTeamInfo.Controls.Add(lblDescription);
            grpTeamInfo.Controls.Add(txtDescription);
            grpTeamInfo.Location = new Point(50, 100);
            grpTeamInfo.Name = "grpTeamInfo";
            grpTeamInfo.Size = new Size(1000, 200);
            grpTeamInfo.TabIndex = 1;
            grpTeamInfo.Text = "TEAM INFORMATION";
            // 
            // lblTeamName
            // 
            lblTeamName.Appearance.Font = new Font("Segoe UI", 9F);
            lblTeamName.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblTeamName.Appearance.Options.UseFont = true;
            lblTeamName.Appearance.Options.UseForeColor = true;
            lblTeamName.Location = new Point(20, 40);
            lblTeamName.Name = "lblTeamName";
            lblTeamName.Size = new Size(73, 15);
            lblTeamName.TabIndex = 0;
            lblTeamName.Text = "Team Name *";
            // 
            // txtTeamName
            // 
            txtTeamName.Location = new Point(20, 65);
            txtTeamName.Name = "txtTeamName";
            txtTeamName.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            txtTeamName.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtTeamName.Properties.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            txtTeamName.Properties.Appearance.Options.UseBackColor = true;
            txtTeamName.Properties.Appearance.Options.UseFont = true;
            txtTeamName.Properties.Appearance.Options.UseForeColor = true;
            txtTeamName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtTeamName.Properties.NullText = "Enter team name...";
            txtTeamName.Size = new Size(960, 22);
            txtTeamName.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.Appearance.Font = new Font("Segoe UI", 9F);
            lblDescription.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblDescription.Appearance.Options.UseFont = true;
            lblDescription.Appearance.Options.UseForeColor = true;
            lblDescription.Location = new Point(20, 110);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(60, 15);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(20, 135);
            txtDescription.Name = "txtDescription";
            txtDescription.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            txtDescription.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtDescription.Properties.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            txtDescription.Properties.Appearance.Options.UseBackColor = true;
            txtDescription.Properties.Appearance.Options.UseFont = true;
            txtDescription.Properties.Appearance.Options.UseForeColor = true;
            txtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtDescription.Properties.NullText = "Enter team description...";
            txtDescription.Size = new Size(960, 50);
            txtDescription.TabIndex = 3;
            // 
            // grpStatistics
            // 
            grpStatistics.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            grpStatistics.Appearance.Options.UseBackColor = true;
            grpStatistics.AppearanceCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpStatistics.AppearanceCaption.ForeColor = Color.FromArgb(255, 77, 0);
            grpStatistics.AppearanceCaption.Options.UseFont = true;
            grpStatistics.AppearanceCaption.Options.UseForeColor = true;
            grpStatistics.Controls.Add(lblStats);
            grpStatistics.Controls.Add(btnViewMembers);
            grpStatistics.Controls.Add(btnViewInvitations);
            grpStatistics.Location = new Point(50, 320);
            grpStatistics.Name = "grpStatistics";
            grpStatistics.Size = new Size(1000, 150);
            grpStatistics.TabIndex = 2;
            grpStatistics.Text = "TEAM STATISTICS";
            grpStatistics.Visible = false;
            // 
            // lblStats
            // 
            lblStats.Appearance.Font = new Font("Segoe UI", 9F);
            lblStats.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblStats.Appearance.Options.UseFont = true;
            lblStats.Appearance.Options.UseForeColor = true;
            lblStats.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblStats.Location = new Point(20, 40);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(960, 90);
            lblStats.TabIndex = 0;
            lblStats.Text = "📊 Team Overview:\n• Members: 0\n• Active Projects: 0\n• Created: N/A\n• Owner: N/A";
            // 
            // btnViewMembers
            // 
            btnViewMembers.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            btnViewMembers.Appearance.Font = new Font("Segoe UI", 9F);
            btnViewMembers.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            btnViewMembers.Appearance.Options.UseBackColor = true;
            btnViewMembers.Appearance.Options.UseFont = true;
            btnViewMembers.Appearance.Options.UseForeColor = true;
            btnViewMembers.Location = new Point(650, 40);
            btnViewMembers.Name = "btnViewMembers";
            btnViewMembers.Size = new Size(150, 32);
            btnViewMembers.TabIndex = 1;
            btnViewMembers.Text = "👥 View Members";
            btnViewMembers.Click += btnViewMembers_Click;
            // 
            // btnViewInvitations
            // 
            btnViewInvitations.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            btnViewInvitations.Appearance.Font = new Font("Segoe UI", 9F);
            btnViewInvitations.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            btnViewInvitations.Appearance.Options.UseBackColor = true;
            btnViewInvitations.Appearance.Options.UseFont = true;
            btnViewInvitations.Appearance.Options.UseForeColor = true;
            btnViewInvitations.Location = new Point(820, 40);
            btnViewInvitations.Name = "btnViewInvitations";
            btnViewInvitations.Size = new Size(160, 32);
            btnViewInvitations.TabIndex = 2;
            btnViewInvitations.Text = "📧 View Invitations";
            btnViewInvitations.Click += btnViewInvitations_Click;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            btnCancel.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCancel.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnCancel.Appearance.Options.UseBackColor = true;
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Appearance.Options.UseForeColor = true;
            btnCancel.Location = new Point(820, 660);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            btnSave.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSave.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            btnSave.Appearance.Options.UseBackColor = true;
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.Location = new Point(930, 660);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 4;
            btnSave.Text = "💾 Save Team";
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Appearance.BackColor = Color.FromArgb(255, 77, 77);
            btnDelete.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDelete.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            btnDelete.Appearance.Options.UseBackColor = true;
            btnDelete.Appearance.Options.UseFont = true;
            btnDelete.Appearance.Options.UseForeColor = true;
            btnDelete.Location = new Point(50, 660);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 40);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "🗑️ Delete Team";
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // TeamDetailControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 11, 11);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(grpStatistics);
            Controls.Add(grpTeamInfo);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "TeamDetailControl";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grpTeamInfo).EndInit();
            grpTeamInfo.ResumeLayout(false);
            grpTeamInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtTeamName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)grpStatistics).EndInit();
            grpStatistics.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.GroupControl grpTeamInfo;
        private DevExpress.XtraEditors.LabelControl lblTeamName;
        private DevExpress.XtraEditors.TextEdit txtTeamName;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.GroupControl grpStatistics;
        private DevExpress.XtraEditors.LabelControl lblStats;
        private DevExpress.XtraEditors.SimpleButton btnViewMembers;
        private DevExpress.XtraEditors.SimpleButton btnViewInvitations;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
