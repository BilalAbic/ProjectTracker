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
            pictureEdit1.EditValue = resources.GetObject("pictureEdit1.EditValue");
            pictureEdit1.Location = new Point(0, 0);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            pictureEdit1.Size = new Size(400, 500);
            pictureEdit1.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlLeft;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
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