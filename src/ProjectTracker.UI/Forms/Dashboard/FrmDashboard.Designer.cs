namespace ProjectTracker.UI.Forms.Dashboard
{
    partial class FrmDashboard
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
            pnlTopBar = new DevExpress.XtraEditors.PanelControl();
            btnClose = new DevExpress.XtraEditors.SimpleButton();
            lblUserArrow = new DevExpress.XtraEditors.LabelControl();
            btnUser = new DevExpress.XtraEditors.SimpleButton();
            lblNotificationBadge = new DevExpress.XtraEditors.LabelControl();
            btnNotification = new DevExpress.XtraEditors.SimpleButton();
            pnlSearchContainer = new DevExpress.XtraEditors.PanelControl();
            txtSearch = new DevExpress.XtraEditors.TextEdit();
            lblSearchIcon = new DevExpress.XtraEditors.LabelControl();
            lblLogoTitle = new DevExpress.XtraEditors.LabelControl();
            lblLogo = new DevExpress.XtraEditors.LabelControl();
            pnlTopBarSeparator = new DevExpress.XtraEditors.PanelControl();
            pnlSidebar = new DevExpress.XtraEditors.PanelControl();
            btnSettings = new DevExpress.XtraEditors.SimpleButton();
            btnReports = new DevExpress.XtraEditors.SimpleButton();
            btnTeam = new DevExpress.XtraEditors.SimpleButton();
            btnTasks = new DevExpress.XtraEditors.SimpleButton();
            btnProjects = new DevExpress.XtraEditors.SimpleButton();
            btnDashboard = new DevExpress.XtraEditors.SimpleButton();
            pnlActiveIndicator = new DevExpress.XtraEditors.PanelControl();
            pnlSidebarSeparator = new DevExpress.XtraEditors.PanelControl();
            pnlContent = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)pnlTopBar).BeginInit();
            pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSearchContainer).BeginInit();
            pnlSearchContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlTopBarSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlSidebar).BeginInit();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlActiveIndicator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlSidebarSeparator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlContent).BeginInit();
            SuspendLayout();
            // 
            // pnlTopBar
            // 
            pnlTopBar.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            pnlTopBar.Appearance.Options.UseBackColor = true;
            pnlTopBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlTopBar.Controls.Add(btnClose);
            pnlTopBar.Controls.Add(lblUserArrow);
            pnlTopBar.Controls.Add(btnUser);
            pnlTopBar.Controls.Add(lblNotificationBadge);
            pnlTopBar.Controls.Add(btnNotification);
            pnlTopBar.Controls.Add(pnlSearchContainer);
            pnlTopBar.Controls.Add(lblLogoTitle);
            pnlTopBar.Controls.Add(lblLogo);
            pnlTopBar.Controls.Add(pnlTopBarSeparator);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1280, 56);
            pnlTopBar.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Appearance.BackColor = Color.Transparent;
            btnClose.Appearance.BorderColor = Color.Transparent;
            btnClose.Appearance.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnClose.Appearance.Options.UseBackColor = true;
            btnClose.Appearance.Options.UseBorderColor = true;
            btnClose.Appearance.Options.UseFont = true;
            btnClose.Appearance.Options.UseForeColor = true;
            btnClose.Location = new Point(1240, 13);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(32, 32);
            btnClose.TabIndex = 8;
            btnClose.Text = "✕";
            // 
            // lblUserArrow
            // 
            lblUserArrow.Appearance.BackColor = Color.Transparent;
            lblUserArrow.Appearance.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUserArrow.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblUserArrow.Appearance.Options.UseBackColor = true;
            lblUserArrow.Appearance.Options.UseFont = true;
            lblUserArrow.Appearance.Options.UseForeColor = true;
            lblUserArrow.Appearance.Options.UseTextOptions = true;
            lblUserArrow.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblUserArrow.Location = new Point(1170, 21);
            lblUserArrow.Name = "lblUserArrow";
            lblUserArrow.Size = new Size(8, 12);
            lblUserArrow.TabIndex = 7;
            lblUserArrow.Text = "▼";
            // 
            // btnUser
            // 
            btnUser.Appearance.BackColor = Color.Transparent;
            btnUser.Appearance.BorderColor = Color.Transparent;
            btnUser.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUser.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnUser.Appearance.Options.UseBackColor = true;
            btnUser.Appearance.Options.UseBorderColor = true;
            btnUser.Appearance.Options.UseFont = true;
            btnUser.Appearance.Options.UseForeColor = true;
            btnUser.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnUser.Location = new Point(1070, 13);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(120, 32);
            btnUser.TabIndex = 6;
            btnUser.Text = "👤 Admin";
            // 
            // lblNotificationBadge
            // 
            lblNotificationBadge.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            lblNotificationBadge.Appearance.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotificationBadge.Appearance.Options.UseBackColor = true;
            lblNotificationBadge.Appearance.Options.UseFont = true;
            lblNotificationBadge.Appearance.Options.UseTextOptions = true;
            lblNotificationBadge.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblNotificationBadge.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblNotificationBadge.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            lblNotificationBadge.Location = new Point(1040, 13);
            lblNotificationBadge.Name = "lblNotificationBadge";
            lblNotificationBadge.Size = new Size(16, 16);
            lblNotificationBadge.TabIndex = 5;
            lblNotificationBadge.Text = "3";
            // 
            // btnNotification
            // 
            btnNotification.Appearance.BackColor = Color.Transparent;
            btnNotification.Appearance.BorderColor = Color.Transparent;
            btnNotification.Appearance.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNotification.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnNotification.Appearance.Options.UseBackColor = true;
            btnNotification.Appearance.Options.UseBorderColor = true;
            btnNotification.Appearance.Options.UseFont = true;
            btnNotification.Appearance.Options.UseForeColor = true;
            btnNotification.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnNotification.Location = new Point(1020, 13);
            btnNotification.Name = "btnNotification";
            btnNotification.Size = new Size(32, 32);
            btnNotification.TabIndex = 4;
            btnNotification.Text = "🔔";
            // 
            // pnlSearchContainer
            // 
            pnlSearchContainer.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            pnlSearchContainer.Appearance.Options.UseBackColor = true;
            pnlSearchContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlSearchContainer.Controls.Add(txtSearch);
            pnlSearchContainer.Controls.Add(lblSearchIcon);
            pnlSearchContainer.Location = new Point(400, 12);
            pnlSearchContainer.Name = "pnlSearchContainer";
            pnlSearchContainer.Size = new Size(400, 32);
            pnlSearchContainer.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(40, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            txtSearch.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Properties.Appearance.ForeColor = Color.White;
            txtSearch.Properties.Appearance.Options.UseBackColor = true;
            txtSearch.Properties.Appearance.Options.UseFont = true;
            txtSearch.Properties.Appearance.Options.UseForeColor = true;
            txtSearch.Properties.AutoHeight = false;
            txtSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            txtSearch.Properties.NullText = "Search everywhere..";
            txtSearch.Size = new Size(355, 24);
            txtSearch.TabIndex = 1;
            // 
            // lblSearchIcon
            // 
            lblSearchIcon.Appearance.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSearchIcon.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblSearchIcon.Appearance.Options.UseFont = true;
            lblSearchIcon.Appearance.Options.UseForeColor = true;
            lblSearchIcon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSearchIcon.Location = new Point(12, 6);
            lblSearchIcon.Name = "lblSearchIcon";
            lblSearchIcon.Size = new Size(20, 20);
            lblSearchIcon.TabIndex = 0;
            lblSearchIcon.Text = "🔍︎";
            // 
            // lblLogoTitle
            // 
            lblLogoTitle.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogoTitle.Appearance.Options.UseFont = true;
            lblLogoTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblLogoTitle.Location = new Point(80, 18);
            lblLogoTitle.Name = "lblLogoTitle";
            lblLogoTitle.Size = new Size(150, 20);
            lblLogoTitle.TabIndex = 2;
            lblLogoTitle.Text = "PROJECT TRACKER";
            // 
            // lblLogo
            // 
            lblLogo.Appearance.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogo.Appearance.Options.UseFont = true;
            lblLogo.Appearance.Options.UseTextOptions = true;
            lblLogo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            lblLogo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblLogo.Location = new Point(16, 14);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(60, 28);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "🎯 PT";
            // 
            // pnlTopBarSeparator
            // 
            pnlTopBarSeparator.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            pnlTopBarSeparator.Appearance.Options.UseBackColor = true;
            pnlTopBarSeparator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlTopBarSeparator.Dock = DockStyle.Bottom;
            pnlTopBarSeparator.Location = new Point(0, 55);
            pnlTopBarSeparator.Name = "pnlTopBarSeparator";
            pnlTopBarSeparator.Size = new Size(1280, 1);
            pnlTopBarSeparator.TabIndex = 0;
            // 
            // pnlSidebar
            // 
            pnlSidebar.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            pnlSidebar.Appearance.Options.UseBackColor = true;
            pnlSidebar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnReports);
            pnlSidebar.Controls.Add(btnTeam);
            pnlSidebar.Controls.Add(btnTasks);
            pnlSidebar.Controls.Add(btnProjects);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(pnlActiveIndicator);
            pnlSidebar.Controls.Add(pnlSidebarSeparator);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 56);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(56, 744);
            pnlSidebar.TabIndex = 1;
            // 
            // btnSettings
            // 
            btnSettings.Appearance.BackColor = Color.Transparent;
            btnSettings.Appearance.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSettings.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnSettings.Appearance.Options.UseBackColor = true;
            btnSettings.Appearance.Options.UseFont = true;
            btnSettings.Appearance.Options.UseForeColor = true;
            btnSettings.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnSettings.Location = new Point(8, 700);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(40, 40);
            btnSettings.TabIndex = 7;
            btnSettings.Text = "⚙️";
            // 
            // btnReports
            // 
            btnReports.Appearance.BackColor = Color.Transparent;
            btnReports.Appearance.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReports.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnReports.Appearance.Options.UseBackColor = true;
            btnReports.Appearance.Options.UseFont = true;
            btnReports.Appearance.Options.UseForeColor = true;
            btnReports.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnReports.Location = new Point(8, 280);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(40, 40);
            btnReports.TabIndex = 6;
            btnReports.Text = "📈";
            // 
            // btnTeam
            // 
            btnTeam.Appearance.BackColor = Color.Transparent;
            btnTeam.Appearance.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTeam.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnTeam.Appearance.Options.UseBackColor = true;
            btnTeam.Appearance.Options.UseFont = true;
            btnTeam.Appearance.Options.UseForeColor = true;
            btnTeam.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnTeam.Location = new Point(8, 230);
            btnTeam.Name = "btnTeam";
            btnTeam.Size = new Size(40, 40);
            btnTeam.TabIndex = 5;
            btnTeam.Text = "👥";
            // 
            // btnTasks
            // 
            btnTasks.Appearance.BackColor = Color.Transparent;
            btnTasks.Appearance.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTasks.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnTasks.Appearance.Options.UseBackColor = true;
            btnTasks.Appearance.Options.UseFont = true;
            btnTasks.Appearance.Options.UseForeColor = true;
            btnTasks.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnTasks.Location = new Point(8, 180);
            btnTasks.Name = "btnTasks";
            btnTasks.Size = new Size(40, 40);
            btnTasks.TabIndex = 4;
            btnTasks.Text = "✓";
            // 
            // btnProjects
            // 
            btnProjects.Appearance.BackColor = Color.Transparent;
            btnProjects.Appearance.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProjects.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnProjects.Appearance.Options.UseBackColor = true;
            btnProjects.Appearance.Options.UseFont = true;
            btnProjects.Appearance.Options.UseForeColor = true;
            btnProjects.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnProjects.Location = new Point(8, 130);
            btnProjects.Name = "btnProjects";
            btnProjects.Size = new Size(40, 40);
            btnProjects.TabIndex = 3;
            btnProjects.Text = "📁";
            // 
            // btnDashboard
            // 
            btnDashboard.Appearance.BackColor = Color.Transparent;
            btnDashboard.Appearance.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnDashboard.Appearance.Options.UseBackColor = true;
            btnDashboard.Appearance.Options.UseFont = true;
            btnDashboard.Appearance.Options.UseForeColor = true;
            btnDashboard.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnDashboard.Location = new Point(8, 80);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(40, 40);
            btnDashboard.TabIndex = 2;
            btnDashboard.Text = "📊";
            btnDashboard.Click += btnDashboard_Click_1;
            // 
            // pnlActiveIndicator
            // 
            pnlActiveIndicator.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            pnlActiveIndicator.Appearance.Options.UseBackColor = true;
            pnlActiveIndicator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlActiveIndicator.Location = new Point(0, 80);
            pnlActiveIndicator.Name = "pnlActiveIndicator";
            pnlActiveIndicator.Size = new Size(3, 40);
            pnlActiveIndicator.TabIndex = 1;
            // 
            // pnlSidebarSeparator
            // 
            pnlSidebarSeparator.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            pnlSidebarSeparator.Appearance.Options.UseBackColor = true;
            pnlSidebarSeparator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlSidebarSeparator.Dock = DockStyle.Right;
            pnlSidebarSeparator.Location = new Point(55, 0);
            pnlSidebarSeparator.Name = "pnlSidebarSeparator";
            pnlSidebarSeparator.Size = new Size(1, 744);
            pnlSidebarSeparator.TabIndex = 0;
            // 
            // pnlContent
            // 
            pnlContent.Appearance.BackColor = Color.FromArgb(11, 11, 11);
            pnlContent.Appearance.Options.UseBackColor = true;
            pnlContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(56, 56);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(32);
            pnlContent.Size = new Size(1224, 744);
            pnlContent.TabIndex = 2;
            // 
            // FrmDashboard
            // 
            Appearance.BackColor = Color.FromArgb(11, 11, 11);
            Appearance.ForeColor = Color.White;
            Appearance.Options.UseBackColor = true;
            Appearance.Options.UseFont = true;
            Appearance.Options.UseForeColor = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 800);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlTopBar);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(1024, 600);
            Name = "FrmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Project Tracker - Dashboard";
            ((System.ComponentModel.ISupportInitialize)pnlTopBar).EndInit();
            pnlTopBar.ResumeLayout(false);
            pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSearchContainer).EndInit();
            pnlSearchContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlTopBarSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlSidebar).EndInit();
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlActiveIndicator).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlSidebarSeparator).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlContent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTopBar;
        private DevExpress.XtraEditors.PanelControl pnlTopBarSeparator;
        private DevExpress.XtraEditors.PanelControl pnlSidebar;
        private DevExpress.XtraEditors.PanelControl pnlSidebarSeparator;
        private DevExpress.XtraEditors.PanelControl pnlContent;
        private DevExpress.XtraEditors.LabelControl lblLogo;
        private DevExpress.XtraEditors.LabelControl lblLogoTitle;
        private DevExpress.XtraEditors.PanelControl pnlSearchContainer;
        private DevExpress.XtraEditors.LabelControl lblSearchIcon;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.SimpleButton btnNotification;
        private DevExpress.XtraEditors.LabelControl lblNotificationBadge;
        private DevExpress.XtraEditors.SimpleButton btnUser;
        private DevExpress.XtraEditors.LabelControl lblUserArrow;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.PanelControl pnlActiveIndicator;
        private DevExpress.XtraEditors.SimpleButton btnDashboard;
        private DevExpress.XtraEditors.SimpleButton btnSettings;
        private DevExpress.XtraEditors.SimpleButton btnReports;
        private DevExpress.XtraEditors.SimpleButton btnTeam;
        private DevExpress.XtraEditors.SimpleButton btnTasks;
        private DevExpress.XtraEditors.SimpleButton btnProjects;
    }
}