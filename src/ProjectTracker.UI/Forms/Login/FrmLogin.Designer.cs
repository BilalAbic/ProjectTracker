using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Login
{
    partial class FrmLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pnlLeft = new DevExpress.XtraEditors.PanelControl();
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            lblBrandName = new DevExpress.XtraEditors.LabelControl();
            lblSlogan = new DevExpress.XtraEditors.LabelControl();
            lblVersion = new DevExpress.XtraEditors.LabelControl();
            lblDesigner = new DevExpress.XtraEditors.LabelControl();
            lblStats = new DevExpress.XtraEditors.LabelControl();
            lblAcademic = new DevExpress.XtraEditors.LabelControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblUsername = new DevExpress.XtraEditors.LabelControl();
            txtUsername = new DevExpress.XtraEditors.TextEdit();
            lblPassword = new DevExpress.XtraEditors.LabelControl();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            btnLogin = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnClose = new DevExpress.XtraEditors.SimpleButton();
            lblRegisterLink = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)pnlLeft).BeginInit();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            pictureEdit1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlLeft.Controls.Add(pictureEdit1);
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(400, 500);
            pnlLeft.TabIndex = 0;
            // 
            // pictureEdit1
            // 
            pictureEdit1.Controls.Add(lblBrandName);
            pictureEdit1.Controls.Add(lblSlogan);
            pictureEdit1.Controls.Add(lblVersion);
            pictureEdit1.Controls.Add(lblDesigner);
            pictureEdit1.Controls.Add(lblStats);
            pictureEdit1.Controls.Add(lblAcademic);
            pictureEdit1.EditValue = resources.GetObject("pictureEdit1.EditValue");
            pictureEdit1.Location = new Point(0, 0);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            pictureEdit1.Size = new Size(400, 500);
            pictureEdit1.TabIndex = 0;
            // 
            // lblBrandName
            // 
            lblBrandName.Appearance.BackColor = Color.Transparent;
            lblBrandName.Appearance.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBrandName.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            lblBrandName.Appearance.Options.UseBackColor = true;
            lblBrandName.Appearance.Options.UseFont = true;
            lblBrandName.Appearance.Options.UseForeColor = true;
            lblBrandName.Appearance.Options.UseTextOptions = true;
            lblBrandName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblBrandName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblBrandName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lblBrandName.Location = new Point(25, 180);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(350, 50);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "PROJECT TRACKER";
            // 
            // lblSlogan
            // 
            lblSlogan.Appearance.BackColor = Color.Transparent;
            lblSlogan.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblSlogan.Appearance.ForeColor = Color.FromArgb(226, 232, 240);
            lblSlogan.Appearance.Options.UseBackColor = true;
            lblSlogan.Appearance.Options.UseFont = true;
            lblSlogan.Appearance.Options.UseForeColor = true;
            lblSlogan.Appearance.Options.UseTextOptions = true;
            lblSlogan.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblSlogan.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSlogan.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lblSlogan.Location = new Point(25, 230);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(350, 25);
            lblSlogan.TabIndex = 2;
            lblSlogan.Text = "Manage & Analyze Your Projects Easily";
            // 
            // lblVersion
            // 
            lblVersion.Appearance.BackColor = Color.Transparent;
            lblVersion.Appearance.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVersion.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblVersion.Appearance.Options.UseBackColor = true;
            lblVersion.Appearance.Options.UseFont = true;
            lblVersion.Appearance.Options.UseForeColor = true;
            lblVersion.Appearance.Options.UseTextOptions = true;
            lblVersion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblVersion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblVersion.BackColor = Color.Transparent;
            lblVersion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lblVersion.Location = new Point(25, 470);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(60, 20);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "v1.1.0";
            // 
            // lblDesigner
            // 
            lblDesigner.Appearance.BackColor = Color.Transparent;
            lblDesigner.Appearance.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDesigner.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblDesigner.Appearance.Options.UseBackColor = true;
            lblDesigner.Appearance.Options.UseFont = true;
            lblDesigner.Appearance.Options.UseForeColor = true;
            lblDesigner.Appearance.Options.UseTextOptions = true;
            lblDesigner.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            lblDesigner.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblDesigner.BackColor = Color.Transparent;
            lblDesigner.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lblDesigner.Location = new Point(250, 470);
            lblDesigner.Name = "lblDesigner";
            lblDesigner.Size = new Size(125, 20);
            lblDesigner.TabIndex = 4;
            lblDesigner.Text = "by @bilalabic";
            // 
            // lblStats
            // 
            lblStats.Appearance.BackColor = Color.Transparent;
            lblStats.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStats.Appearance.ForeColor = Color.FromArgb(226, 232, 240);
            lblStats.Appearance.Options.UseBackColor = true;
            lblStats.Appearance.Options.UseFont = true;
            lblStats.Appearance.Options.UseForeColor = true;
            lblStats.Appearance.Options.UseTextOptions = true;
            lblStats.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblStats.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblStats.BackColor = Color.Transparent;
            lblStats.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lblStats.Location = new Point(25, 270);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(350, 20);
            lblStats.TabIndex = 5;
            lblStats.Text = "📊 500+ Projects Managed";
            // 
            // lblAcademic
            // 
            lblAcademic.Appearance.BackColor = Color.Transparent;
            lblAcademic.Appearance.Font = new Font("Segoe UI", 7.5F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAcademic.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblAcademic.Appearance.Options.UseBackColor = true;
            lblAcademic.Appearance.Options.UseFont = true;
            lblAcademic.Appearance.Options.UseForeColor = true;
            lblAcademic.Appearance.Options.UseTextOptions = true;
            lblAcademic.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblAcademic.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblAcademic.BackColor = Color.Transparent;
            lblAcademic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lblAcademic.Location = new Point(25, 450);
            lblAcademic.Name = "lblAcademic";
            lblAcademic.Size = new Size(350, 15);
            lblAcademic.TabIndex = 6;
            lblAcademic.Text = "YMH 219 - Object Oriented Programming Project";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.BackColor = Color.Transparent;
            lblTitle.Appearance.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            lblTitle.Appearance.Options.UseBackColor = true;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Appearance.Options.UseTextOptions = true;
            lblTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblTitle.Location = new Point(430, 80);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(109, 40);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "SIGN IN";
            // 
            // lblUsername
            // 
            lblUsername.Appearance.BackColor = Color.Transparent;
            lblUsername.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblUsername.Appearance.Options.UseBackColor = true;
            lblUsername.Appearance.Options.UseFont = true;
            lblUsername.Appearance.Options.UseForeColor = true;
            lblUsername.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblUsername.Location = new Point(430, 145);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 20);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(430, 170);
            txtUsername.Name = "txtUsername";
            txtUsername.Properties.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            txtUsername.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtUsername.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            txtUsername.Properties.Appearance.Options.UseBackColor = true;
            txtUsername.Properties.Appearance.Options.UseBorderColor = true;
            txtUsername.Properties.Appearance.Options.UseFont = true;
            txtUsername.Properties.Appearance.Options.UseForeColor = true;
            txtUsername.Properties.AppearanceFocused.BackColor = Color.FromArgb(30, 42, 58);
            txtUsername.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtUsername.Properties.AppearanceReadOnly.ForeColor = Color.FromArgb(100, 116, 139);
            txtUsername.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtUsername.Properties.NullText = "Enter username...";
            txtUsername.Properties.NullValuePrompt = "Enter username...";
            txtUsername.Size = new Size(330, 22);
            txtUsername.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.Appearance.BackColor = Color.Transparent;
            lblPassword.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblPassword.Appearance.Options.UseBackColor = true;
            lblPassword.Appearance.Options.UseFont = true;
            lblPassword.Appearance.Options.UseForeColor = true;
            lblPassword.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblPassword.Location = new Point(430, 215);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(430, 240);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            txtPassword.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtPassword.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            txtPassword.Properties.Appearance.Options.UseBackColor = true;
            txtPassword.Properties.Appearance.Options.UseBorderColor = true;
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.Appearance.Options.UseForeColor = true;
            txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtPassword.Properties.NullText = "Enter password...";
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Size = new Size(330, 22);
            txtPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Appearance.BackColor = Color.FromArgb(91, 141, 239);
            btnLogin.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            btnLogin.Appearance.Options.UseBackColor = true;
            btnLogin.Appearance.Options.UseFont = true;
            btnLogin.Appearance.Options.UseForeColor = true;
            btnLogin.Location = new Point(430, 295);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(330, 40);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOGIN";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            btnCancel.Appearance.BorderColor = Color.FromArgb(138, 186, 252);
            btnCancel.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Appearance.ForeColor = Color.FromArgb(138, 186, 252);
            btnCancel.Appearance.Options.UseBackColor = true;
            btnCancel.Appearance.Options.UseBorderColor = true;
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Appearance.Options.UseForeColor = true;
            btnCancel.Location = new Point(430, 350);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(330, 35);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "CANCEL";
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClose
            // 
            btnClose.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            btnClose.Appearance.BorderColor = Color.FromArgb(239, 68, 68);
            btnClose.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnClose.Appearance.Options.UseBackColor = true;
            btnClose.Appearance.Options.UseBorderColor = true;
            btnClose.Appearance.Options.UseFont = true;
            btnClose.Appearance.Options.UseForeColor = true;
            btnClose.Location = new Point(765, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(25, 25);
            btnClose.TabIndex = 8;
            btnClose.Text = "✕";
            btnClose.Click += btnClose_Click;
            // 
            // lblRegisterLink
            // 
            lblRegisterLink.Appearance.Font = new Font("Segoe UI", 9F);
            lblRegisterLink.Appearance.ForeColor = Color.FromArgb(138, 186, 252);
            lblRegisterLink.Appearance.Options.UseFont = true;
            lblRegisterLink.Appearance.Options.UseForeColor = true;
            lblRegisterLink.Cursor = Cursors.Hand;
            lblRegisterLink.Location = new Point(434, 400);
            lblRegisterLink.Name = "lblRegisterLink";
            lblRegisterLink.Size = new Size(184, 15);
            lblRegisterLink.TabIndex = 9;
            lblRegisterLink.Text = "Don't have an account? Create one";
            lblRegisterLink.Click += lblRegisterLink_Click;
            // 
            // FrmLogin
            // 
            Appearance.BackColor = Color.FromArgb(26, 31, 38);
            Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            Appearance.Options.UseBackColor = true;
            Appearance.Options.UseForeColor = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(btnClose);
            Controls.Add(btnCancel);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            Controls.Add(pnlLeft);
            Controls.Add(lblRegisterLink);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLogin";
            Load += FrmLogin_Load;
            MouseDown += FrmLogin_MouseDown;
            MouseMove += FrmLogin_MouseMove;
            MouseUp += FrmLogin_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pnlLeft).EndInit();
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            pictureEdit1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlLeft;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl lblBrandName;
        private DevExpress.XtraEditors.LabelControl lblSlogan;
        private DevExpress.XtraEditors.LabelControl lblVersion;
        private DevExpress.XtraEditors.LabelControl lblDesigner;
        private DevExpress.XtraEditors.LabelControl lblStats;
        private DevExpress.XtraEditors.LabelControl lblAcademic;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblUsername;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblRegisterLink;
    }
}