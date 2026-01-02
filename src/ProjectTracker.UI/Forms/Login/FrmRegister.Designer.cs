using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Login
{
    partial class FrmRegister
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
            pnlLeft = new DevExpress.XtraEditors.PanelControl();
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblUsername = new DevExpress.XtraEditors.LabelControl();
            txtUsername = new DevExpress.XtraEditors.TextEdit();
            lblFullName = new DevExpress.XtraEditors.LabelControl();
            txtFullName = new DevExpress.XtraEditors.TextEdit();
            lblEmail = new DevExpress.XtraEditors.LabelControl();
            txtEmail = new DevExpress.XtraEditors.TextEdit();
            lblPassword = new DevExpress.XtraEditors.LabelControl();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            lblConfirmPassword = new DevExpress.XtraEditors.LabelControl();
            txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            btnRegister = new DevExpress.XtraEditors.SimpleButton();
            btnBackToLogin = new DevExpress.XtraEditors.SimpleButton();
            btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)pnlLeft).BeginInit();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtConfirmPassword.Properties).BeginInit();
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
            pictureEdit1.EditValue = Properties.Resources.LoginFormLeft;
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
            lblTitle.Location = new Point(430, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(116, 40);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "SIGN UP";
            // 
            // lblUsername
            // 
            lblUsername.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblUsername.Appearance.Options.UseFont = true;
            lblUsername.Appearance.Options.UseForeColor = true;
            lblUsername.Location = new Point(430, 95);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(56, 15);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(430, 120);
            txtUsername.Name = "txtUsername";
            txtUsername.Properties.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            txtUsername.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtUsername.Properties.Appearance.Font = new Font("Segoe UI", 9F);
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
            txtUsername.Properties.MaxLength = 50;
            txtUsername.Properties.NullText = "Enter username...";
            txtUsername.Properties.NullValuePrompt = "Enter username...";
            txtUsername.Size = new Size(330, 22);
            txtUsername.TabIndex = 0;
            // 
            // lblFullName
            // 
            lblFullName.Appearance.Font = new Font("Segoe UI", 9F);
            lblFullName.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblFullName.Appearance.Options.UseFont = true;
            lblFullName.Appearance.Options.UseForeColor = true;
            lblFullName.Location = new Point(430, 150);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(57, 15);
            lblFullName.TabIndex = 4;
            lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(430, 175);
            txtFullName.Name = "txtFullName";
            txtFullName.Properties.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            txtFullName.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtFullName.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtFullName.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            txtFullName.Properties.Appearance.Options.UseBackColor = true;
            txtFullName.Properties.Appearance.Options.UseBorderColor = true;
            txtFullName.Properties.Appearance.Options.UseFont = true;
            txtFullName.Properties.Appearance.Options.UseForeColor = true;
            txtFullName.Properties.AppearanceFocused.BackColor = Color.FromArgb(30, 42, 58);
            txtFullName.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtFullName.Properties.AppearanceReadOnly.ForeColor = Color.FromArgb(100, 116, 139);
            txtFullName.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtFullName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtFullName.Properties.MaxLength = 100;
            txtFullName.Properties.NullText = "Enter your full name...";
            txtFullName.Properties.NullValuePrompt = "Enter your full name...";
            txtFullName.Size = new Size(330, 22);
            txtFullName.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.Appearance.Font = new Font("Segoe UI", 9F);
            lblEmail.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblEmail.Appearance.Options.UseFont = true;
            lblEmail.Appearance.Options.UseForeColor = true;
            lblEmail.Location = new Point(430, 205);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(32, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(430, 230);
            txtEmail.Name = "txtEmail";
            txtEmail.Properties.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            txtEmail.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtEmail.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtEmail.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            txtEmail.Properties.Appearance.Options.UseBackColor = true;
            txtEmail.Properties.Appearance.Options.UseBorderColor = true;
            txtEmail.Properties.Appearance.Options.UseFont = true;
            txtEmail.Properties.Appearance.Options.UseForeColor = true;
            txtEmail.Properties.AppearanceFocused.BackColor = Color.FromArgb(30, 42, 58);
            txtEmail.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtEmail.Properties.AppearanceReadOnly.ForeColor = Color.FromArgb(100, 116, 139);
            txtEmail.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtEmail.Properties.MaxLength = 100;
            txtEmail.Properties.NullText = "Enter email address...";
            txtEmail.Properties.NullValuePrompt = "Enter email address...";
            txtEmail.Size = new Size(330, 22);
            txtEmail.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.Appearance.Font = new Font("Segoe UI", 9F);
            lblPassword.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblPassword.Appearance.Options.UseFont = true;
            lblPassword.Appearance.Options.UseForeColor = true;
            lblPassword.Location = new Point(430, 260);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(53, 15);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(430, 285);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            txtPassword.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtPassword.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtPassword.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            txtPassword.Properties.Appearance.Options.UseBackColor = true;
            txtPassword.Properties.Appearance.Options.UseBorderColor = true;
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.Appearance.Options.UseForeColor = true;
            txtPassword.Properties.AppearanceFocused.BackColor = Color.FromArgb(30, 42, 58);
            txtPassword.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtPassword.Properties.AppearanceReadOnly.ForeColor = Color.FromArgb(100, 116, 139);
            txtPassword.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtPassword.Properties.MaxLength = 255;
            txtPassword.Properties.NullText = "Enter password...";
            txtPassword.Properties.NullValuePrompt = "Enter password...";
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Size = new Size(330, 22);
            txtPassword.TabIndex = 3;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Appearance.Font = new Font("Segoe UI", 9F);
            lblConfirmPassword.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblConfirmPassword.Appearance.Options.UseFont = true;
            lblConfirmPassword.Appearance.Options.UseForeColor = true;
            lblConfirmPassword.Location = new Point(430, 315);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(100, 15);
            lblConfirmPassword.TabIndex = 10;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(430, 340);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Properties.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            txtConfirmPassword.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtConfirmPassword.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtConfirmPassword.Properties.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            txtConfirmPassword.Properties.Appearance.Options.UseBackColor = true;
            txtConfirmPassword.Properties.Appearance.Options.UseBorderColor = true;
            txtConfirmPassword.Properties.Appearance.Options.UseFont = true;
            txtConfirmPassword.Properties.Appearance.Options.UseForeColor = true;
            txtConfirmPassword.Properties.AppearanceFocused.BackColor = Color.FromArgb(30, 42, 58);
            txtConfirmPassword.Properties.AppearanceFocused.Options.UseBackColor = true;
            txtConfirmPassword.Properties.AppearanceReadOnly.ForeColor = Color.FromArgb(100, 116, 139);
            txtConfirmPassword.Properties.AppearanceReadOnly.Options.UseForeColor = true;
            txtConfirmPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtConfirmPassword.Properties.MaxLength = 255;
            txtConfirmPassword.Properties.NullText = "Confirm password...";
            txtConfirmPassword.Properties.NullValuePrompt = "Confirm password...";
            txtConfirmPassword.Properties.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(330, 22);
            txtConfirmPassword.TabIndex = 4;
            // 
            // btnRegister
            // 
            btnRegister.Appearance.BackColor = Color.FromArgb(91, 141, 239);
            btnRegister.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnRegister.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            btnRegister.Appearance.Options.UseBackColor = true;
            btnRegister.Appearance.Options.UseFont = true;
            btnRegister.Appearance.Options.UseForeColor = true;
            btnRegister.Location = new Point(430, 390);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(330, 40);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "REGISTER";
            btnRegister.Click += btnRegister_Click;
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            btnBackToLogin.Appearance.BorderColor = Color.FromArgb(138, 186, 252);
            btnBackToLogin.Appearance.Font = new Font("Segoe UI", 9F);
            btnBackToLogin.Appearance.ForeColor = Color.FromArgb(138, 186, 252);
            btnBackToLogin.Appearance.Options.UseBackColor = true;
            btnBackToLogin.Appearance.Options.UseBorderColor = true;
            btnBackToLogin.Appearance.Options.UseFont = true;
            btnBackToLogin.Appearance.Options.UseForeColor = true;
            btnBackToLogin.Location = new Point(430, 440);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(330, 30);
            btnBackToLogin.TabIndex = 7;
            btnBackToLogin.Text = "← Back to Login";
            btnBackToLogin.Click += btnBackToLogin_Click;
            // 
            // btnClose
            // 
            btnClose.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            btnClose.Appearance.BorderColor = Color.FromArgb(239, 68, 68);
            btnClose.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
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
            // FrmRegister
            // 
            Appearance.BackColor = Color.FromArgb(26, 31, 38);
            Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            Appearance.Options.UseBackColor = true;
            Appearance.Options.UseForeColor = true;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(btnClose);
            Controls.Add(btnBackToLogin);
            Controls.Add(btnRegister);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Account - ProjectTracker";
            Load += FrmRegister_Load;
            MouseDown += FrmRegister_MouseDown;
            MouseMove += FrmRegister_MouseMove;
            MouseUp += FrmRegister_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pnlLeft).EndInit();
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFullName.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtConfirmPassword.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlLeft;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblUsername;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblConfirmPassword;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.SimpleButton btnRegister;
        private DevExpress.XtraEditors.SimpleButton btnBackToLogin;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}