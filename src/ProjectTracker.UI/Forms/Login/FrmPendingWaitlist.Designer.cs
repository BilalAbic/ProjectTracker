using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Login
{
    partial class FrmPendingWaitlist
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
            pnlHeader = new DevExpress.XtraEditors.PanelControl();
            btnClose = new DevExpress.XtraEditors.SimpleButton();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            pnlContent = new DevExpress.XtraEditors.PanelControl();
            lblIcon = new DevExpress.XtraEditors.LabelControl();
            lblWelcome = new DevExpress.XtraEditors.LabelControl();
            lblMessage = new DevExpress.XtraEditors.LabelControl();
            lblDescription = new DevExpress.XtraEditors.LabelControl();
            btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            btnLogout = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlContent).BeginInit();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = FormStyleHelper.PanelBackground;
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(500, 50);
            pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Appearance.BackColor = Color.Transparent;
            btnClose.Appearance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.Appearance.ForeColor = FormStyleHelper.TextLabel;
            btnClose.Appearance.Options.UseBackColor = true;
            btnClose.Appearance.Options.UseFont = true;
            btnClose.Appearance.Options.UseForeColor = true;
            btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnClose.Location = new Point(460, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 30);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = FormStyleHelper.TextWhite;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(118, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Project Tracker";
            // 
            // pnlContent
            // 
            pnlContent.Appearance.BackColor = FormStyleHelper.FormBackground;
            pnlContent.Appearance.Options.UseBackColor = true;
            pnlContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlContent.Controls.Add(lblIcon);
            pnlContent.Controls.Add(lblWelcome);
            pnlContent.Controls.Add(lblMessage);
            pnlContent.Controls.Add(lblDescription);
            pnlContent.Controls.Add(btnRefresh);
            pnlContent.Controls.Add(btnLogout);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 50);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(500, 350);
            pnlContent.TabIndex = 1;
            // 
            // lblIcon
            // 
            lblIcon.Appearance.Font = new Font("Segoe UI", 48F);
            lblIcon.Appearance.ForeColor = FormStyleHelper.AccentBlue;
            lblIcon.Appearance.Options.UseFont = true;
            lblIcon.Appearance.Options.UseForeColor = true;
            lblIcon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblIcon.Location = new Point(200, 30);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(100, 80);
            lblIcon.TabIndex = 0;
            lblIcon.Text = "⏳";
            // 
            // lblWelcome
            // 
            lblWelcome.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblWelcome.Appearance.ForeColor = FormStyleHelper.TextWhite;
            lblWelcome.Appearance.Options.UseFont = true;
            lblWelcome.Appearance.Options.UseForeColor = true;
            lblWelcome.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblWelcome.Location = new Point(20, 120);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(460, 30);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome!";
            lblWelcome.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            // 
            // lblMessage
            // 
            lblMessage.Appearance.Font = new Font("Segoe UI", 11F);
            lblMessage.Appearance.ForeColor = FormStyleHelper.TextLabel;
            lblMessage.Appearance.Options.UseFont = true;
            lblMessage.Appearance.Options.UseForeColor = true;
            lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblMessage.Location = new Point(20, 160);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(460, 30);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "Your account is pending approval";
            lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            // 
            // lblDescription
            // 
            lblDescription.Appearance.Font = new Font("Segoe UI", 9F);
            lblDescription.Appearance.ForeColor = FormStyleHelper.TextPlaceholder;
            lblDescription.Appearance.Options.UseFont = true;
            lblDescription.Appearance.Options.UseForeColor = true;
            lblDescription.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblDescription.Location = new Point(20, 195);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(460, 40);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "An administrator will review your registration request.\r\nYou will be notified once your account is approved.";
            lblDescription.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            // 
            // btnRefresh
            // 
            btnRefresh.Appearance.BackColor = FormStyleHelper.ButtonPrimary;
            btnRefresh.Appearance.BorderColor = FormStyleHelper.ButtonPrimary;
            btnRefresh.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.Appearance.ForeColor = FormStyleHelper.TextWhite;
            btnRefresh.Appearance.Options.UseBackColor = true;
            btnRefresh.Appearance.Options.UseBorderColor = true;
            btnRefresh.Appearance.Options.UseFont = true;
            btnRefresh.Appearance.Options.UseForeColor = true;
            btnRefresh.Location = new Point(150, 260);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(200, 40);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Check Status";
            // 
            // btnLogout
            // 
            btnLogout.Appearance.BackColor = FormStyleHelper.ButtonSecondary;
            btnLogout.Appearance.BorderColor = FormStyleHelper.ButtonSecondary;
            btnLogout.Appearance.Font = new Font("Segoe UI", 9F);
            btnLogout.Appearance.ForeColor = FormStyleHelper.TextLabel;
            btnLogout.Appearance.Options.UseBackColor = true;
            btnLogout.Appearance.Options.UseBorderColor = true;
            btnLogout.Appearance.Options.UseFont = true;
            btnLogout.Appearance.Options.UseForeColor = true;
            btnLogout.Location = new Point(200, 310);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 30);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            // 
            // FrmPendingWaitlist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = FormStyleHelper.FormBackground;
            ClientSize = new Size(500, 400);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPendingWaitlist";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pending Approval";
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlContent).EndInit();
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.PanelControl pnlContent;
        private DevExpress.XtraEditors.LabelControl lblIcon;
        private DevExpress.XtraEditors.LabelControl lblWelcome;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnLogout;
    }
}
