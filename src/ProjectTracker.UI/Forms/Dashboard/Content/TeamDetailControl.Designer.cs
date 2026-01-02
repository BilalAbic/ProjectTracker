using ProjectTracker.UI.Helpers;

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
            pnlHeader.Appearance.BackColor = FormStyleHelper.FormBackground;
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
            btnBack.Appearance.BackColor = FormStyleHelper.ButtonSecondary;
            btnBack.Appearance.BorderColor = FormStyleHelper.ButtonSecondary;
            btnBack.Appearance.Font = new Font("Segoe UI", 9F);
            btnBack.Appearance.ForeColor = FormStyleHelper.TextWhite;
            btnBack.Appearance.Options.UseBackColor = true;
            btnBack.Appearance.Options.UseBorderColor = true;
            btnBack.Appearance.Options.UseFont = true;
            btnBack.Appearance.Options.UseForeColor = true;
            btnBack.Location = new Point(20, 25);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(80, 30);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.Click += btnBack_Click;
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = FormStyleHelper.TextWhite;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(115, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "🏢 Create Team";
            // 
            // grpTeamInfo - Sol Panel
            // 
            grpTeamInfo.Appearance.BackColor = FormStyleHelper.FormBackground;
            grpTeamInfo.Appearance.BorderColor = FormStyleHelper.InputBorder;
            grpTeamInfo.Appearance.Options.UseBackColor = true;
            grpTeamInfo.Appearance.Options.UseBorderColor = true;
            grpTeamInfo.AppearanceCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpTeamInfo.AppearanceCaption.ForeColor = FormStyleHelper.AccentBlue;
            grpTeamInfo.AppearanceCaption.Options.UseFont = true;
            grpTeamInfo.AppearanceCaption.Options.UseForeColor = true;
            grpTeamInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            grpTeamInfo.Controls.Add(lblTeamName);
            grpTeamInfo.Controls.Add(txtTeamName);
            grpTeamInfo.Controls.Add(lblDescription);
            grpTeamInfo.Controls.Add(txtDescription);
            grpTeamInfo.Location = new Point(20, 100);
            grpTeamInfo.Name = "grpTeamInfo";
            grpTeamInfo.Size = new Size(520, 500);
            grpTeamInfo.TabIndex = 1;
            grpTeamInfo.Text = "TEAM INFORMATION";
            // 
            // lblTeamName
            // 
            lblTeamName.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblTeamName.Appearance.ForeColor = FormStyleHelper.TextLabel;
            lblTeamName.Appearance.Options.UseFont = true;
            lblTeamName.Appearance.Options.UseForeColor = true;
            lblTeamName.Location = new Point(20, 45);
            lblTeamName.Name = "lblTeamName";
            lblTeamName.Size = new Size(88, 17);
            lblTeamName.TabIndex = 0;
            lblTeamName.Text = "Team Name *";
            // 
            // txtTeamName
            // 
            txtTeamName.Location = new Point(20, 70);
            txtTeamName.Name = "txtTeamName";
            txtTeamName.Properties.Appearance.BackColor = FormStyleHelper.InputBackground;
            txtTeamName.Properties.Appearance.BorderColor = FormStyleHelper.InputBorder;
            txtTeamName.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txtTeamName.Properties.Appearance.ForeColor = FormStyleHelper.TextWhite;
            txtTeamName.Properties.Appearance.Options.UseBackColor = true;
            txtTeamName.Properties.Appearance.Options.UseBorderColor = true;
            txtTeamName.Properties.Appearance.Options.UseFont = true;
            txtTeamName.Properties.Appearance.Options.UseForeColor = true;
            txtTeamName.Properties.AutoHeight = false;
            txtTeamName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtTeamName.Properties.NullText = "Enter team name...";
            txtTeamName.Size = new Size(480, 36);
            txtTeamName.TabIndex = 1;
            // 
            // lblDescription
            // 
            lblDescription.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblDescription.Appearance.ForeColor = FormStyleHelper.TextLabel;
            lblDescription.Appearance.Options.UseFont = true;
            lblDescription.Appearance.Options.UseForeColor = true;
            lblDescription.Location = new Point(20, 125);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(70, 17);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(20, 150);
            txtDescription.Name = "txtDescription";
            txtDescription.Properties.Appearance.BackColor = FormStyleHelper.InputBackground;
            txtDescription.Properties.Appearance.BorderColor = FormStyleHelper.InputBorder;
            txtDescription.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txtDescription.Properties.Appearance.ForeColor = FormStyleHelper.TextWhite;
            txtDescription.Properties.Appearance.Options.UseBackColor = true;
            txtDescription.Properties.Appearance.Options.UseBorderColor = true;
            txtDescription.Properties.Appearance.Options.UseFont = true;
            txtDescription.Properties.Appearance.Options.UseForeColor = true;
            txtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtDescription.Properties.NullText = "Enter team description...";
            txtDescription.Size = new Size(480, 320);
            txtDescription.TabIndex = 3;
            // 
            // grpStatistics - Sağ Panel (Her zaman görünür)
            // 
            grpStatistics.Appearance.BackColor = FormStyleHelper.FormBackground;
            grpStatistics.Appearance.BorderColor = FormStyleHelper.InputBorder;
            grpStatistics.Appearance.Options.UseBackColor = true;
            grpStatistics.Appearance.Options.UseBorderColor = true;
            grpStatistics.AppearanceCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpStatistics.AppearanceCaption.ForeColor = FormStyleHelper.AccentBlue;
            grpStatistics.AppearanceCaption.Options.UseFont = true;
            grpStatistics.AppearanceCaption.Options.UseForeColor = true;
            grpStatistics.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            grpStatistics.Controls.Add(lblStats);
            grpStatistics.Controls.Add(btnViewMembers);
            grpStatistics.Controls.Add(btnViewInvitations);
            grpStatistics.Location = new Point(560, 100);
            grpStatistics.Name = "grpStatistics";
            grpStatistics.Size = new Size(520, 500);
            grpStatistics.TabIndex = 2;
            grpStatistics.Text = "TEAM STATISTICS";
            // 
            // lblStats
            // 
            lblStats.Appearance.Font = new Font("Segoe UI", 10F);
            lblStats.Appearance.ForeColor = FormStyleHelper.TextLabel;
            lblStats.Appearance.Options.UseFont = true;
            lblStats.Appearance.Options.UseForeColor = true;
            lblStats.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblStats.Location = new Point(20, 45);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(480, 120);
            lblStats.TabIndex = 0;
            lblStats.Text = "📊 Team Overview:\r\n\r\n• Members: 0\r\n• Active Projects: 0\r\n• Created: N/A\r\n• Owner: N/A";
            // 
            // btnViewMembers
            // 
            btnViewMembers.Appearance.BackColor = FormStyleHelper.ButtonSecondary;
            btnViewMembers.Appearance.BorderColor = FormStyleHelper.ButtonSecondary;
            btnViewMembers.Appearance.Font = new Font("Segoe UI", 9.75F);
            btnViewMembers.Appearance.ForeColor = FormStyleHelper.TextWhite;
            btnViewMembers.Appearance.Options.UseBackColor = true;
            btnViewMembers.Appearance.Options.UseBorderColor = true;
            btnViewMembers.Appearance.Options.UseFont = true;
            btnViewMembers.Appearance.Options.UseForeColor = true;
            btnViewMembers.Enabled = false;
            btnViewMembers.Location = new Point(20, 180);
            btnViewMembers.Name = "btnViewMembers";
            btnViewMembers.Size = new Size(230, 40);
            btnViewMembers.TabIndex = 1;
            btnViewMembers.Text = "👥 View Members";
            btnViewMembers.Click += btnViewMembers_Click;
            // 
            // btnViewInvitations
            // 
            btnViewInvitations.Appearance.BackColor = FormStyleHelper.ButtonSecondary;
            btnViewInvitations.Appearance.BorderColor = FormStyleHelper.ButtonSecondary;
            btnViewInvitations.Appearance.Font = new Font("Segoe UI", 9.75F);
            btnViewInvitations.Appearance.ForeColor = FormStyleHelper.TextWhite;
            btnViewInvitations.Appearance.Options.UseBackColor = true;
            btnViewInvitations.Appearance.Options.UseBorderColor = true;
            btnViewInvitations.Appearance.Options.UseFont = true;
            btnViewInvitations.Appearance.Options.UseForeColor = true;
            btnViewInvitations.Enabled = false;
            btnViewInvitations.Location = new Point(270, 180);
            btnViewInvitations.Name = "btnViewInvitations";
            btnViewInvitations.Size = new Size(230, 40);
            btnViewInvitations.TabIndex = 2;
            btnViewInvitations.Text = "📧 View Invitations";
            btnViewInvitations.Click += btnViewInvitations_Click;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.BackColor = FormStyleHelper.ButtonSecondary;
            btnCancel.Appearance.BorderColor = FormStyleHelper.ButtonSecondary;
            btnCancel.Appearance.Font = new Font("Segoe UI", 9.75F);
            btnCancel.Appearance.ForeColor = FormStyleHelper.TextLabel;
            btnCancel.Appearance.Options.UseBackColor = true;
            btnCancel.Appearance.Options.UseBorderColor = true;
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Appearance.Options.UseForeColor = true;
            btnCancel.Location = new Point(820, 620);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Appearance.BackColor = FormStyleHelper.ButtonPrimary;
            btnSave.Appearance.BorderColor = FormStyleHelper.ButtonPrimary;
            btnSave.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSave.Appearance.ForeColor = FormStyleHelper.TextWhite;
            btnSave.Appearance.Options.UseBackColor = true;
            btnSave.Appearance.Options.UseBorderColor = true;
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.Location = new Point(960, 620);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.TabIndex = 4;
            btnSave.Text = "💾 Save Team";
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Appearance.BackColor = FormStyleHelper.ButtonDanger;
            btnDelete.Appearance.BorderColor = FormStyleHelper.ButtonDanger;
            btnDelete.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnDelete.Appearance.ForeColor = FormStyleHelper.TextWhite;
            btnDelete.Appearance.Options.UseBackColor = true;
            btnDelete.Appearance.Options.UseBorderColor = true;
            btnDelete.Appearance.Options.UseFont = true;
            btnDelete.Appearance.Options.UseForeColor = true;
            btnDelete.Location = new Point(20, 620);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 40);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "🗑️ Delete Team";
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // TeamDetailControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = FormStyleHelper.FormBackground;
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(grpStatistics);
            Controls.Add(grpTeamInfo);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "TeamDetailControl";
            Size = new Size(1100, 680);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
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
