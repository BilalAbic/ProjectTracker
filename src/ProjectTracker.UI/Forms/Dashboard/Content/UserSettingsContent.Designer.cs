using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class UserSettingsContent
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
            pnlHeader = new DevExpress.XtraEditors.PanelControl();
            btnSaveChanges = new DevExpress.XtraEditors.SimpleButton();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            pnlContent = new DevExpress.XtraEditors.PanelControl();
            pnlProfileSection = new DevExpress.XtraEditors.PanelControl();
            lblProfileTitle = new DevExpress.XtraEditors.LabelControl();
            lblFullName = new DevExpress.XtraEditors.LabelControl();
            txtFullName = new DevExpress.XtraEditors.TextEdit();
            lblEmail = new DevExpress.XtraEditors.LabelControl();
            txtEmail = new DevExpress.XtraEditors.TextEdit();
            lblDepartment = new DevExpress.XtraEditors.LabelControl();
            txtDepartment = new DevExpress.XtraEditors.TextEdit();
            pnlGitHubSection = new DevExpress.XtraEditors.PanelControl();
            lblGitHubTitle = new DevExpress.XtraEditors.LabelControl();
            lblGitHubUsername = new DevExpress.XtraEditors.LabelControl();
            txtGitHubUsername = new DevExpress.XtraEditors.TextEdit();
            lblGitHubToken = new DevExpress.XtraEditors.LabelControl();
            txtGitHubToken = new DevExpress.XtraEditors.TextEdit();
            btnToggleToken = new DevExpress.XtraEditors.SimpleButton();
            lblTokenStatus = new DevExpress.XtraEditors.LabelControl();
            btnValidateToken = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlContent).BeginInit();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlProfileSection).BeginInit();
            pnlProfileSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlGitHubSection).BeginInit();
            pnlGitHubSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDepartment.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGitHubUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGitHubToken.Properties).BeginInit();
            SuspendLayout();
            
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(btnSaveChanges);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveChanges.Appearance.BackColor = Color.FromArgb(91, 141, 239);
            btnSaveChanges.Appearance.BorderColor = Color.FromArgb(91, 141, 239);
            btnSaveChanges.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveChanges.Appearance.ForeColor = Color.White;
            btnSaveChanges.Appearance.Options.UseBackColor = true;
            btnSaveChanges.Appearance.Options.UseBorderColor = true;
            btnSaveChanges.Appearance.Options.UseFont = true;
            btnSaveChanges.Appearance.Options.UseForeColor = true;
            btnSaveChanges.Location = new Point(940, 25);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(145, 36);
            btnSaveChanges.TabIndex = 2;
            btnSaveChanges.Text = "💾 Save Changes";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 10F);
            lblSubtitle.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSubtitle.Location = new Point(0, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(500, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage your profile and GitHub integration settings";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.White;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "⚙️ User Settings";
            // 
            // pnlContent
            // 
            pnlContent.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlContent.Appearance.Options.UseBackColor = true;
            pnlContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlContent.Controls.Add(pnlGitHubSection);
            pnlContent.Controls.Add(pnlProfileSection);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(0, 20, 0, 20);
            pnlContent.Size = new Size(1100, 650);
            pnlContent.TabIndex = 1;
            // 
            // pnlProfileSection
            // 
            pnlProfileSection.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlProfileSection.Appearance.Options.UseBackColor = true;
            pnlProfileSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlProfileSection.Controls.Add(lblProfileTitle);
            pnlProfileSection.Controls.Add(lblFullName);
            pnlProfileSection.Controls.Add(txtFullName);
            pnlProfileSection.Controls.Add(lblEmail);
            pnlProfileSection.Controls.Add(txtEmail);
            pnlProfileSection.Controls.Add(lblDepartment);
            pnlProfileSection.Controls.Add(txtDepartment);
            pnlProfileSection.Location = new Point(0, 20);
            pnlProfileSection.Name = "pnlProfileSection";
            pnlProfileSection.Padding = new Padding(20);
            pnlProfileSection.Size = new Size(600, 200);
            pnlProfileSection.TabIndex = 0;
            // 
            // lblProfileTitle
            // 
            lblProfileTitle.Appearance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblProfileTitle.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            lblProfileTitle.Appearance.Options.UseFont = true;
            lblProfileTitle.Appearance.Options.UseForeColor = true;
            lblProfileTitle.Location = new Point(20, 15);
            lblProfileTitle.Name = "lblProfileTitle";
            lblProfileTitle.Size = new Size(200, 25);
            lblProfileTitle.TabIndex = 0;
            lblProfileTitle.Text = "👤 Profile Information";
            // 
            // lblFullName
            // 
            lblFullName.Appearance.Font = new Font("Segoe UI", 9F);
            lblFullName.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblFullName.Appearance.Options.UseFont = true;
            lblFullName.Appearance.Options.UseForeColor = true;
            lblFullName.Location = new Point(20, 55);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(100, 20);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(140, 52);
            txtFullName.Name = "txtFullName";
            txtFullName.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            txtFullName.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtFullName.Properties.Appearance.ForeColor = Color.White;
            txtFullName.Properties.Appearance.Options.UseBackColor = true;
            txtFullName.Properties.Appearance.Options.UseBorderColor = true;
            txtFullName.Properties.Appearance.Options.UseForeColor = true;
            txtFullName.Properties.AutoHeight = false;
            txtFullName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtFullName.Size = new Size(420, 28);
            txtFullName.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.Appearance.Font = new Font("Segoe UI", 9F);
            lblEmail.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblEmail.Appearance.Options.UseFont = true;
            lblEmail.Appearance.Options.UseForeColor = true;
            lblEmail.Location = new Point(20, 95);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(140, 92);
            txtEmail.Name = "txtEmail";
            txtEmail.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            txtEmail.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtEmail.Properties.Appearance.ForeColor = Color.White;
            txtEmail.Properties.Appearance.Options.UseBackColor = true;
            txtEmail.Properties.Appearance.Options.UseBorderColor = true;
            txtEmail.Properties.Appearance.Options.UseForeColor = true;
            txtEmail.Properties.AutoHeight = false;
            txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtEmail.Size = new Size(420, 28);
            txtEmail.TabIndex = 4;
            // 
            // lblDepartment
            // 
            lblDepartment.Appearance.Font = new Font("Segoe UI", 9F);
            lblDepartment.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblDepartment.Appearance.Options.UseFont = true;
            lblDepartment.Appearance.Options.UseForeColor = true;
            lblDepartment.Location = new Point(20, 135);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(100, 20);
            lblDepartment.TabIndex = 5;
            lblDepartment.Text = "Department:";
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(140, 132);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            txtDepartment.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtDepartment.Properties.Appearance.ForeColor = Color.White;
            txtDepartment.Properties.Appearance.Options.UseBackColor = true;
            txtDepartment.Properties.Appearance.Options.UseBorderColor = true;
            txtDepartment.Properties.Appearance.Options.UseForeColor = true;
            txtDepartment.Properties.AutoHeight = false;
            txtDepartment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtDepartment.Size = new Size(420, 28);
            txtDepartment.TabIndex = 6;
            // 
            // pnlGitHubSection
            // 
            pnlGitHubSection.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlGitHubSection.Appearance.Options.UseBackColor = true;
            pnlGitHubSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlGitHubSection.Controls.Add(lblGitHubTitle);
            pnlGitHubSection.Controls.Add(lblGitHubUsername);
            pnlGitHubSection.Controls.Add(txtGitHubUsername);
            pnlGitHubSection.Controls.Add(lblGitHubToken);
            pnlGitHubSection.Controls.Add(txtGitHubToken);
            pnlGitHubSection.Controls.Add(btnToggleToken);
            pnlGitHubSection.Controls.Add(lblTokenStatus);
            pnlGitHubSection.Controls.Add(btnValidateToken);
            pnlGitHubSection.Location = new Point(0, 240);
            pnlGitHubSection.Name = "pnlGitHubSection";
            pnlGitHubSection.Padding = new Padding(20);
            pnlGitHubSection.Size = new Size(600, 200);
            pnlGitHubSection.TabIndex = 1;
            // 
            // lblGitHubTitle
            // 
            lblGitHubTitle.Appearance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGitHubTitle.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            lblGitHubTitle.Appearance.Options.UseFont = true;
            lblGitHubTitle.Appearance.Options.UseForeColor = true;
            lblGitHubTitle.Location = new Point(20, 15);
            lblGitHubTitle.Name = "lblGitHubTitle";
            lblGitHubTitle.Size = new Size(200, 25);
            lblGitHubTitle.TabIndex = 0;
            lblGitHubTitle.Text = "🔗 GitHub Integration";
            // 
            // lblGitHubUsername
            // 
            lblGitHubUsername.Appearance.Font = new Font("Segoe UI", 9F);
            lblGitHubUsername.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblGitHubUsername.Appearance.Options.UseFont = true;
            lblGitHubUsername.Appearance.Options.UseForeColor = true;
            lblGitHubUsername.Location = new Point(20, 55);
            lblGitHubUsername.Name = "lblGitHubUsername";
            lblGitHubUsername.Size = new Size(110, 20);
            lblGitHubUsername.TabIndex = 1;
            lblGitHubUsername.Text = "GitHub Username:";
            // 
            // txtGitHubUsername
            // 
            txtGitHubUsername.Location = new Point(140, 52);
            txtGitHubUsername.Name = "txtGitHubUsername";
            txtGitHubUsername.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            txtGitHubUsername.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtGitHubUsername.Properties.Appearance.ForeColor = Color.White;
            txtGitHubUsername.Properties.Appearance.Options.UseBackColor = true;
            txtGitHubUsername.Properties.Appearance.Options.UseBorderColor = true;
            txtGitHubUsername.Properties.Appearance.Options.UseForeColor = true;
            txtGitHubUsername.Properties.AutoHeight = false;
            txtGitHubUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtGitHubUsername.Properties.NullText = "Enter your GitHub username";
            txtGitHubUsername.Size = new Size(420, 28);
            txtGitHubUsername.TabIndex = 2;
            // 
            // lblGitHubToken
            // 
            lblGitHubToken.Appearance.Font = new Font("Segoe UI", 9F);
            lblGitHubToken.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblGitHubToken.Appearance.Options.UseFont = true;
            lblGitHubToken.Appearance.Options.UseForeColor = true;
            lblGitHubToken.Location = new Point(20, 95);
            lblGitHubToken.Name = "lblGitHubToken";
            lblGitHubToken.Size = new Size(110, 20);
            lblGitHubToken.TabIndex = 3;
            lblGitHubToken.Text = "GitHub Token:";
            // 
            // txtGitHubToken
            // 
            txtGitHubToken.Location = new Point(140, 92);
            txtGitHubToken.Name = "txtGitHubToken";
            txtGitHubToken.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            txtGitHubToken.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtGitHubToken.Properties.Appearance.ForeColor = Color.White;
            txtGitHubToken.Properties.Appearance.Options.UseBackColor = true;
            txtGitHubToken.Properties.Appearance.Options.UseBorderColor = true;
            txtGitHubToken.Properties.Appearance.Options.UseForeColor = true;
            txtGitHubToken.Properties.AutoHeight = false;
            txtGitHubToken.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtGitHubToken.Properties.NullText = "ghp_xxxxxxxxxxxxxxxxxxxx";
            txtGitHubToken.Properties.UseSystemPasswordChar = true;
            txtGitHubToken.Size = new Size(370, 28);
            txtGitHubToken.TabIndex = 4;
            // 
            // btnToggleToken
            // 
            btnToggleToken.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            btnToggleToken.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnToggleToken.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnToggleToken.Appearance.Options.UseBackColor = true;
            btnToggleToken.Appearance.Options.UseBorderColor = true;
            btnToggleToken.Appearance.Options.UseForeColor = true;
            btnToggleToken.Location = new Point(515, 90);
            btnToggleToken.Name = "btnToggleToken";
            btnToggleToken.Size = new Size(45, 32);
            btnToggleToken.TabIndex = 5;
            btnToggleToken.Text = "👁️";
            // 
            // lblTokenStatus
            // 
            lblTokenStatus.Appearance.Font = new Font("Segoe UI", 9F);
            lblTokenStatus.Appearance.ForeColor = Color.FromArgb(100, 116, 139);
            lblTokenStatus.Appearance.Options.UseFont = true;
            lblTokenStatus.Appearance.Options.UseForeColor = true;
            lblTokenStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTokenStatus.Location = new Point(140, 130);
            lblTokenStatus.Name = "lblTokenStatus";
            lblTokenStatus.Size = new Size(300, 20);
            lblTokenStatus.TabIndex = 6;
            lblTokenStatus.Text = "Token Status: Not configured";
            // 
            // btnValidateToken
            // 
            btnValidateToken.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            btnValidateToken.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnValidateToken.Appearance.Font = new Font("Segoe UI", 9F);
            btnValidateToken.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnValidateToken.Appearance.Options.UseBackColor = true;
            btnValidateToken.Appearance.Options.UseBorderColor = true;
            btnValidateToken.Appearance.Options.UseFont = true;
            btnValidateToken.Appearance.Options.UseForeColor = true;
            btnValidateToken.Location = new Point(460, 127);
            btnValidateToken.Name = "btnValidateToken";
            btnValidateToken.Size = new Size(100, 28);
            btnValidateToken.TabIndex = 7;
            btnValidateToken.Text = "Validate";
            // 
            // UserSettingsContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 31, 38);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Name = "UserSettingsContent";
            Size = new Size(1100, 730);
            
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlContent).EndInit();
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlProfileSection).EndInit();
            pnlProfileSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlGitHubSection).EndInit();
            pnlGitHubSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDepartment.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGitHubUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGitHubToken.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.SimpleButton btnSaveChanges;
        private DevExpress.XtraEditors.PanelControl pnlContent;
        
        // Profile Section
        private DevExpress.XtraEditors.PanelControl pnlProfileSection;
        private DevExpress.XtraEditors.LabelControl lblProfileTitle;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblDepartment;
        private DevExpress.XtraEditors.TextEdit txtDepartment;
        
        // GitHub Section
        private DevExpress.XtraEditors.PanelControl pnlGitHubSection;
        private DevExpress.XtraEditors.LabelControl lblGitHubTitle;
        private DevExpress.XtraEditors.LabelControl lblGitHubUsername;
        private DevExpress.XtraEditors.TextEdit txtGitHubUsername;
        private DevExpress.XtraEditors.LabelControl lblGitHubToken;
        private DevExpress.XtraEditors.TextEdit txtGitHubToken;
        private DevExpress.XtraEditors.SimpleButton btnToggleToken;
        private DevExpress.XtraEditors.LabelControl lblTokenStatus;
        private DevExpress.XtraEditors.SimpleButton btnValidateToken;
    }
}
