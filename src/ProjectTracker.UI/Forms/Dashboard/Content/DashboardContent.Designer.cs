using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class DashboardContent
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
            pnlWelcomeHeader = new DevExpress.XtraEditors.PanelControl();
            btnNewProject = new DevExpress.XtraEditors.SimpleButton();
            lblWelcomeSubtitle = new DevExpress.XtraEditors.LabelControl();
            lblWelcomeTitle = new DevExpress.XtraEditors.LabelControl();
            pnlKPIContainer = new DevExpress.XtraEditors.PanelControl();
            pnlCardCompletion = new DevExpress.XtraEditors.PanelControl();
            progressCompletion = new DevExpress.XtraEditors.ProgressBarControl();
            lblCard4Label = new DevExpress.XtraEditors.LabelControl();
            lblCard4Value = new DevExpress.XtraEditors.LabelControl();
            lblCard4Icon = new DevExpress.XtraEditors.LabelControl();
            pnlCardTeam = new DevExpress.XtraEditors.PanelControl();
            lblCard3Trend = new DevExpress.XtraEditors.LabelControl();
            lblCard3Label = new DevExpress.XtraEditors.LabelControl();
            lblCard3Value = new DevExpress.XtraEditors.LabelControl();
            lblCard3Icon = new DevExpress.XtraEditors.LabelControl();
            pnlCardTasks = new DevExpress.XtraEditors.PanelControl();
            lblCard2Trend = new DevExpress.XtraEditors.LabelControl();
            lblCard2Label = new DevExpress.XtraEditors.LabelControl();
            lblCard2Value = new DevExpress.XtraEditors.LabelControl();
            lblCard2Icon = new DevExpress.XtraEditors.LabelControl();
            pnlCardProjects = new DevExpress.XtraEditors.PanelControl();
            lblCard1Trend = new DevExpress.XtraEditors.LabelControl();
            lblCard1Label = new DevExpress.XtraEditors.LabelControl();
            lblCard1Value = new DevExpress.XtraEditors.LabelControl();
            lblCard1Icon = new DevExpress.XtraEditors.LabelControl();
            pnlRecentHeader = new DevExpress.XtraEditors.PanelControl();
            btnViewAllProjects = new DevExpress.XtraEditors.SimpleButton();
            lblRecentTitle = new DevExpress.XtraEditors.LabelControl();
            gridRecentProjects = new DevExpress.XtraGrid.GridControl();
            gridViewRecentProjects = new DevExpress.XtraGrid.Views.Grid.GridView();
            colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            colProgress = new DevExpress.XtraGrid.Columns.GridColumn();
            colManagerName = new DevExpress.XtraGrid.Columns.GridColumn();
            colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            pnlActivitiesHeader = new DevExpress.XtraEditors.PanelControl();
            lblActivitiesTitle = new DevExpress.XtraEditors.LabelControl();
            gridRecentActivities = new DevExpress.XtraGrid.GridControl();
            gridViewRecentActivities = new DevExpress.XtraGrid.Views.Grid.GridView();
            colActivityIcon = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityProject = new DevExpress.XtraGrid.Columns.GridColumn();
            colActivityTime = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)pnlWelcomeHeader).BeginInit();
            pnlWelcomeHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKPIContainer).BeginInit();
            pnlKPIContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardCompletion).BeginInit();
            pnlCardCompletion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)progressCompletion.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlCardTeam).BeginInit();
            pnlCardTeam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardTasks).BeginInit();
            pnlCardTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardProjects).BeginInit();
            pnlCardProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlRecentHeader).BeginInit();
            pnlRecentHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRecentProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRecentProjects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlActivitiesHeader).BeginInit();
            pnlActivitiesHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRecentActivities).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRecentActivities).BeginInit();
            SuspendLayout();
            // 
            // pnlWelcomeHeader
            // 
            pnlWelcomeHeader.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlWelcomeHeader.Appearance.Options.UseBackColor = true;
            pnlWelcomeHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlWelcomeHeader.Controls.Add(btnNewProject);
            pnlWelcomeHeader.Controls.Add(lblWelcomeSubtitle);
            pnlWelcomeHeader.Controls.Add(lblWelcomeTitle);
            pnlWelcomeHeader.Dock = DockStyle.Top;
            pnlWelcomeHeader.Location = new Point(0, 0);
            pnlWelcomeHeader.Name = "pnlWelcomeHeader";
            pnlWelcomeHeader.Size = new Size(1200, 80);
            pnlWelcomeHeader.TabIndex = 0;
            // 
            // btnNewProject
            // 
            btnNewProject.Appearance.BackColor = Color.FromArgb(91, 141, 239);
            btnNewProject.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewProject.Appearance.ForeColor = Color.FromArgb(248, 250, 252);
            btnNewProject.Appearance.Options.UseBackColor = true;
            btnNewProject.Appearance.Options.UseFont = true;
            btnNewProject.Appearance.Options.UseForeColor = true;
            btnNewProject.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            btnNewProject.Location = new Point(1040, 20);
            btnNewProject.Name = "btnNewProject";
            btnNewProject.Size = new Size(140, 36);
            btnNewProject.TabIndex = 2;
            btnNewProject.Text = "+ New Project";
            btnNewProject.Click += btnNewProject_Click;
            // 
            // lblWelcomeSubtitle
            // 
            lblWelcomeSubtitle.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeSubtitle.Appearance.Options.UseFont = true;
            lblWelcomeSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblWelcomeSubtitle.Location = new Point(0, 44);
            lblWelcomeSubtitle.Name = "lblWelcomeSubtitle";
            lblWelcomeSubtitle.Size = new Size(600, 20);
            lblWelcomeSubtitle.TabIndex = 1;
            lblWelcomeSubtitle.Text = "Here's what'shappening with your project today";
            // 
            // lblWelcomeTitle
            // 
            lblWelcomeTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcomeTitle.Appearance.ForeColor = Color.White;
            lblWelcomeTitle.Appearance.Options.UseFont = true;
            lblWelcomeTitle.Appearance.Options.UseForeColor = true;
            lblWelcomeTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblWelcomeTitle.Location = new Point(0, 8);
            lblWelcomeTitle.Name = "lblWelcomeTitle";
            lblWelcomeTitle.Size = new Size(500, 32);
            lblWelcomeTitle.TabIndex = 0;
            lblWelcomeTitle.Text = "Welcome back, Admin!";
            // 
            // pnlKPIContainer
            // 
            pnlKPIContainer.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlKPIContainer.Appearance.Options.UseBackColor = true;
            pnlKPIContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKPIContainer.Controls.Add(pnlCardCompletion);
            pnlKPIContainer.Controls.Add(pnlCardTeam);
            pnlKPIContainer.Controls.Add(pnlCardTasks);
            pnlKPIContainer.Controls.Add(pnlCardProjects);
            pnlKPIContainer.Location = new Point(0, 96);
            pnlKPIContainer.Name = "pnlKPIContainer";
            pnlKPIContainer.Size = new Size(1200, 140);
            pnlKPIContainer.TabIndex = 1;
            // 
            // pnlCardCompletion
            // 
            pnlCardCompletion.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCardCompletion.Appearance.Options.UseBackColor = true;
            pnlCardCompletion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCardCompletion.Controls.Add(progressCompletion);
            pnlCardCompletion.Controls.Add(lblCard4Label);
            pnlCardCompletion.Controls.Add(lblCard4Value);
            pnlCardCompletion.Controls.Add(lblCard4Icon);
            pnlCardCompletion.Location = new Point(888, 0);
            pnlCardCompletion.Name = "pnlCardCompletion";
            pnlCardCompletion.Size = new Size(280, 120);
            pnlCardCompletion.TabIndex = 3;
            // 
            // progressCompletion
            // 
            progressCompletion.Location = new Point(16, 84);
            progressCompletion.Name = "progressCompletion";
            progressCompletion.Properties.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            progressCompletion.Properties.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            progressCompletion.Properties.PercentView = false;
            progressCompletion.Properties.Step = 1;
            progressCompletion.Size = new Size(248, 8);
            progressCompletion.TabIndex = 3;
            // 
            // lblCard4Label
            // 
            lblCard4Label.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard4Label.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblCard4Label.Appearance.Options.UseFont = true;
            lblCard4Label.Appearance.Options.UseForeColor = true;
            lblCard4Label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard4Label.Location = new Point(16, 56);
            lblCard4Label.Name = "lblCard4Label";
            lblCard4Label.Size = new Size(200, 20);
            lblCard4Label.TabIndex = 2;
            lblCard4Label.Text = "Completion Rate";
            // 
            // lblCard4Value
            // 
            lblCard4Value.Appearance.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCard4Value.Appearance.Options.UseFont = true;
            lblCard4Value.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard4Value.Location = new Point(56, 16);
            lblCard4Value.Name = "lblCard4Value";
            lblCard4Value.Size = new Size(100, 32);
            lblCard4Value.TabIndex = 1;
            lblCard4Value.Text = "87%";
            // 
            // lblCard4Icon
            // 
            lblCard4Icon.Appearance.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard4Icon.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            lblCard4Icon.Appearance.Options.UseFont = true;
            lblCard4Icon.Appearance.Options.UseForeColor = true;
            lblCard4Icon.Location = new Point(16, 16);
            lblCard4Icon.Name = "lblCard4Icon";
            lblCard4Icon.Size = new Size(37, 37);
            lblCard4Icon.TabIndex = 0;
            lblCard4Icon.Text = "🎯";
            // 
            // pnlCardTeam
            // 
            pnlCardTeam.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCardTeam.Appearance.Options.UseBackColor = true;
            pnlCardTeam.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCardTeam.Controls.Add(lblCard3Trend);
            pnlCardTeam.Controls.Add(lblCard3Label);
            pnlCardTeam.Controls.Add(lblCard3Value);
            pnlCardTeam.Controls.Add(lblCard3Icon);
            pnlCardTeam.Location = new Point(592, 0);
            pnlCardTeam.Name = "pnlCardTeam";
            pnlCardTeam.Size = new Size(280, 120);
            pnlCardTeam.TabIndex = 2;
            // 
            // lblCard3Trend
            // 
            lblCard3Trend.Appearance.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard3Trend.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblCard3Trend.Appearance.Options.UseFont = true;
            lblCard3Trend.Appearance.Options.UseForeColor = true;
            lblCard3Trend.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard3Trend.Location = new Point(16, 84);
            lblCard3Trend.Name = "lblCard3Trend";
            lblCard3Trend.Size = new Size(150, 18);
            lblCard3Trend.TabIndex = 3;
            lblCard3Trend.Text = "Online: 8";
            // 
            // lblCard3Label
            // 
            lblCard3Label.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard3Label.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblCard3Label.Appearance.Options.UseFont = true;
            lblCard3Label.Appearance.Options.UseForeColor = true;
            lblCard3Label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard3Label.Location = new Point(16, 56);
            lblCard3Label.Name = "lblCard3Label";
            lblCard3Label.Size = new Size(200, 20);
            lblCard3Label.TabIndex = 2;
            lblCard3Label.Text = "Team Members";
            // 
            // lblCard3Value
            // 
            lblCard3Value.Appearance.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCard3Value.Appearance.Options.UseFont = true;
            lblCard3Value.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard3Value.Location = new Point(56, 16);
            lblCard3Value.Name = "lblCard3Value";
            lblCard3Value.Size = new Size(100, 32);
            lblCard3Value.TabIndex = 1;
            lblCard3Value.Text = "12";
            // 
            // lblCard3Icon
            // 
            lblCard3Icon.Appearance.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard3Icon.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            lblCard3Icon.Appearance.Options.UseFont = true;
            lblCard3Icon.Appearance.Options.UseForeColor = true;
            lblCard3Icon.Location = new Point(16, 16);
            lblCard3Icon.Name = "lblCard3Icon";
            lblCard3Icon.Size = new Size(37, 37);
            lblCard3Icon.TabIndex = 0;
            lblCard3Icon.Text = "👥";
            // 
            // pnlCardTasks
            // 
            pnlCardTasks.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCardTasks.Appearance.Options.UseBackColor = true;
            pnlCardTasks.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCardTasks.Controls.Add(lblCard2Trend);
            pnlCardTasks.Controls.Add(lblCard2Label);
            pnlCardTasks.Controls.Add(lblCard2Value);
            pnlCardTasks.Controls.Add(lblCard2Icon);
            pnlCardTasks.Location = new Point(296, 0);
            pnlCardTasks.Name = "pnlCardTasks";
            pnlCardTasks.Size = new Size(280, 120);
            pnlCardTasks.TabIndex = 1;
            // 
            // lblCard2Trend
            // 
            lblCard2Trend.Appearance.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard2Trend.Appearance.ForeColor = Color.FromArgb(16, 185, 129);
            lblCard2Trend.Appearance.Options.UseFont = true;
            lblCard2Trend.Appearance.Options.UseForeColor = true;
            lblCard2Trend.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard2Trend.Location = new Point(16, 84);
            lblCard2Trend.Name = "lblCard2Trend";
            lblCard2Trend.Size = new Size(150, 18);
            lblCard2Trend.TabIndex = 3;
            lblCard2Trend.Text = "↑ +12 this week";
            // 
            // lblCard2Label
            // 
            lblCard2Label.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard2Label.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblCard2Label.Appearance.Options.UseFont = true;
            lblCard2Label.Appearance.Options.UseForeColor = true;
            lblCard2Label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard2Label.Location = new Point(16, 56);
            lblCard2Label.Name = "lblCard2Label";
            lblCard2Label.Size = new Size(200, 20);
            lblCard2Label.TabIndex = 2;
            lblCard2Label.Text = "Active Tasks";
            // 
            // lblCard2Value
            // 
            lblCard2Value.Appearance.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCard2Value.Appearance.Options.UseFont = true;
            lblCard2Value.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard2Value.Location = new Point(56, 16);
            lblCard2Value.Name = "lblCard2Value";
            lblCard2Value.Size = new Size(100, 32);
            lblCard2Value.TabIndex = 1;
            lblCard2Value.Text = "156";
            // 
            // lblCard2Icon
            // 
            lblCard2Icon.Appearance.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard2Icon.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            lblCard2Icon.Appearance.Options.UseFont = true;
            lblCard2Icon.Appearance.Options.UseForeColor = true;
            lblCard2Icon.Location = new Point(16, 16);
            lblCard2Icon.Name = "lblCard2Icon";
            lblCard2Icon.Size = new Size(27, 37);
            lblCard2Icon.TabIndex = 0;
            lblCard2Icon.Text = "✓";
            // 
            // pnlCardProjects
            // 
            pnlCardProjects.Appearance.BackColor = Color.FromArgb(36, 43, 61);
            pnlCardProjects.Appearance.Options.UseBackColor = true;
            pnlCardProjects.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCardProjects.Controls.Add(lblCard1Trend);
            pnlCardProjects.Controls.Add(lblCard1Label);
            pnlCardProjects.Controls.Add(lblCard1Value);
            pnlCardProjects.Controls.Add(lblCard1Icon);
            pnlCardProjects.Location = new Point(0, 0);
            pnlCardProjects.Name = "pnlCardProjects";
            pnlCardProjects.Size = new Size(280, 120);
            pnlCardProjects.TabIndex = 0;
            // 
            // lblCard1Trend
            // 
            lblCard1Trend.Appearance.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard1Trend.Appearance.ForeColor = Color.FromArgb(16, 185, 129);
            lblCard1Trend.Appearance.Options.UseFont = true;
            lblCard1Trend.Appearance.Options.UseForeColor = true;
            lblCard1Trend.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard1Trend.Location = new Point(16, 84);
            lblCard1Trend.Name = "lblCard1Trend";
            lblCard1Trend.Size = new Size(150, 18);
            lblCard1Trend.TabIndex = 3;
            lblCard1Trend.Text = "↑ +3 today";
            // 
            // lblCard1Label
            // 
            lblCard1Label.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard1Label.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblCard1Label.Appearance.Options.UseFont = true;
            lblCard1Label.Appearance.Options.UseForeColor = true;
            lblCard1Label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard1Label.Location = new Point(16, 56);
            lblCard1Label.Name = "lblCard1Label";
            lblCard1Label.Size = new Size(200, 20);
            lblCard1Label.TabIndex = 2;
            lblCard1Label.Text = "Total Projects";
            // 
            // lblCard1Value
            // 
            lblCard1Value.Appearance.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCard1Value.Appearance.Options.UseFont = true;
            lblCard1Value.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblCard1Value.Location = new Point(56, 16);
            lblCard1Value.Name = "lblCard1Value";
            lblCard1Value.Size = new Size(100, 32);
            lblCard1Value.TabIndex = 1;
            lblCard1Value.Text = "24";
            // 
            // lblCard1Icon
            // 
            lblCard1Icon.Appearance.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCard1Icon.Appearance.ForeColor = Color.FromArgb(91, 141, 239);
            lblCard1Icon.Appearance.Options.UseFont = true;
            lblCard1Icon.Appearance.Options.UseForeColor = true;
            lblCard1Icon.Location = new Point(16, 16);
            lblCard1Icon.Name = "lblCard1Icon";
            lblCard1Icon.Size = new Size(37, 37);
            lblCard1Icon.TabIndex = 0;
            lblCard1Icon.Text = "📁";
            // 
            // pnlRecentHeader
            // 
            pnlRecentHeader.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlRecentHeader.Appearance.Options.UseBackColor = true;
            pnlRecentHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlRecentHeader.Controls.Add(btnViewAllProjects);
            pnlRecentHeader.Controls.Add(lblRecentTitle);
            pnlRecentHeader.Location = new Point(0, 252);
            pnlRecentHeader.Name = "pnlRecentHeader";
            pnlRecentHeader.Size = new Size(1200, 40);
            pnlRecentHeader.TabIndex = 2;
            // 
            // btnViewAllProjects
            // 
            btnViewAllProjects.Appearance.BackColor = Color.Transparent;
            btnViewAllProjects.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnViewAllProjects.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnViewAllProjects.Appearance.Options.UseBackColor = true;
            btnViewAllProjects.Appearance.Options.UseBorderColor = true;
            btnViewAllProjects.Appearance.Options.UseForeColor = true;
            btnViewAllProjects.Location = new Point(1080, 6);
            btnViewAllProjects.Name = "btnViewAllProjects";
            btnViewAllProjects.Size = new Size(100, 28);
            btnViewAllProjects.TabIndex = 1;
            btnViewAllProjects.Text = "View All →";
            btnViewAllProjects.Click += btnViewAllProjects_Click;
            // 
            // lblRecentTitle
            // 
            lblRecentTitle.Appearance.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecentTitle.Appearance.Options.UseFont = true;
            lblRecentTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblRecentTitle.Location = new Point(0, 8);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Size = new Size(300, 24);
            lblRecentTitle.TabIndex = 0;
            lblRecentTitle.Text = "📋 Recent Projects";
            // 
            // gridRecentProjects
            // 
            gridRecentProjects.Location = new Point(0, 308);
            gridRecentProjects.MainView = gridViewRecentProjects;
            gridRecentProjects.Name = "gridRecentProjects";
            gridRecentProjects.Size = new Size(1200, 180);
            gridRecentProjects.TabIndex = 3;
            gridRecentProjects.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewRecentProjects });
            // 
            // gridViewRecentProjects
            // 
            gridViewRecentProjects.Appearance.Empty.BackColor = Color.FromArgb(36, 43, 61);
            gridViewRecentProjects.Appearance.Empty.ForeColor = Color.FromArgb(203, 213, 225);
            gridViewRecentProjects.Appearance.Empty.Options.UseBackColor = true;
            gridViewRecentProjects.Appearance.Empty.Options.UseForeColor = true;
            gridViewRecentProjects.Appearance.EvenRow.BackColor = Color.FromArgb(36, 43, 61);
            gridViewRecentProjects.Appearance.EvenRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewRecentProjects.Appearance.EvenRow.Options.UseBackColor = true;
            gridViewRecentProjects.Appearance.EvenRow.Options.UseForeColor = true;
            gridViewRecentProjects.Appearance.FocusedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridViewRecentProjects.Appearance.FocusedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewRecentProjects.Appearance.FocusedRow.Options.UseBackColor = true;
            gridViewRecentProjects.Appearance.FocusedRow.Options.UseForeColor = true;
            gridViewRecentProjects.Appearance.HeaderPanel.BackColor = Color.FromArgb(36, 43, 61);
            gridViewRecentProjects.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridViewRecentProjects.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridViewRecentProjects.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridViewRecentProjects.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewRecentProjects.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewRecentProjects.Appearance.HorzLine.BackColor = Color.FromArgb(51, 65, 85);
            gridViewRecentProjects.Appearance.HorzLine.Options.UseBackColor = true;
            gridViewRecentProjects.Appearance.Row.BackColor = Color.FromArgb(36, 43, 61);
            gridViewRecentProjects.Appearance.Row.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewRecentProjects.Appearance.Row.Options.UseBackColor = true;
            gridViewRecentProjects.Appearance.Row.Options.UseForeColor = true;
            gridViewRecentProjects.Appearance.SelectedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridViewRecentProjects.Appearance.SelectedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewRecentProjects.Appearance.SelectedRow.Options.UseBackColor = true;
            gridViewRecentProjects.Appearance.SelectedRow.Options.UseForeColor = true;
            gridViewRecentProjects.Appearance.VertLine.BackColor = Color.FromArgb(51, 65, 85);
            gridViewRecentProjects.Appearance.VertLine.Options.UseBackColor = true;
            gridViewRecentProjects.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colProjectName, colStatus, colProgress, colManagerName, colDueDate });
            gridViewRecentProjects.GridControl = gridRecentProjects;
            gridViewRecentProjects.Name = "gridViewRecentProjects";
            gridViewRecentProjects.OptionsBehavior.Editable = false;
            gridViewRecentProjects.OptionsCustomization.AllowColumnMoving = false;
            gridViewRecentProjects.OptionsCustomization.AllowFilter = false;
            gridViewRecentProjects.OptionsCustomization.AllowSort = false;
            gridViewRecentProjects.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewRecentProjects.OptionsView.ShowGroupPanel = false;
            gridViewRecentProjects.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            gridViewRecentProjects.OptionsView.ShowIndicator = false;
            gridViewRecentProjects.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            gridViewRecentProjects.DoubleClick += gridViewRecentProjects_DoubleClick;
            // 
            // colProjectName
            // 
            colProjectName.AppearanceCell.ForeColor = Color.White;
            colProjectName.AppearanceCell.Options.UseForeColor = true;
            colProjectName.Caption = "Project Name";
            colProjectName.FieldName = "Name";
            colProjectName.Name = "colProjectName";
            colProjectName.OptionsColumn.AllowEdit = false;
            colProjectName.Visible = true;
            colProjectName.VisibleIndex = 0;
            colProjectName.Width = 300;
            // 
            // colStatus
            // 
            colStatus.Caption = "Status";
            colStatus.FieldName = "Status";
            colStatus.Name = "colStatus";
            colStatus.OptionsColumn.AllowEdit = false;
            colStatus.Visible = true;
            colStatus.VisibleIndex = 1;
            colStatus.Width = 150;
            // 
            // colProgress
            // 
            colProgress.Caption = "Progress";
            colProgress.FieldName = "Progress";
            colProgress.Name = "colProgress";
            colProgress.OptionsColumn.AllowEdit = false;
            colProgress.Visible = true;
            colProgress.VisibleIndex = 2;
            colProgress.Width = 150;
            // 
            // colManagerName
            // 
            colManagerName.Caption = "Manager";
            colManagerName.FieldName = "ManagerName";
            colManagerName.Name = "colManagerName";
            colManagerName.OptionsColumn.AllowEdit = false;
            colManagerName.Visible = true;
            colManagerName.VisibleIndex = 3;
            colManagerName.Width = 200;
            // 
            // colDueDate
            // 
            colDueDate.Caption = "Due Date";
            colDueDate.DisplayFormat.FormatString = "dd MMM yyyy";
            colDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            colDueDate.FieldName = "DueDate";
            colDueDate.Name = "colDueDate";
            colDueDate.OptionsColumn.AllowEdit = false;
            colDueDate.Visible = true;
            colDueDate.VisibleIndex = 4;
            colDueDate.Width = 150;
            // 
            // pnlActivitiesHeader
            // 
            pnlActivitiesHeader.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlActivitiesHeader.Appearance.Options.UseBackColor = true;
            pnlActivitiesHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlActivitiesHeader.Controls.Add(lblActivitiesTitle);
            pnlActivitiesHeader.Location = new Point(0, 500);
            pnlActivitiesHeader.Name = "pnlActivitiesHeader";
            pnlActivitiesHeader.Size = new Size(1200, 40);
            pnlActivitiesHeader.TabIndex = 4;
            // 
            // lblActivitiesTitle
            // 
            lblActivitiesTitle.Appearance.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActivitiesTitle.Appearance.Options.UseFont = true;
            lblActivitiesTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblActivitiesTitle.Location = new Point(0, 8);
            lblActivitiesTitle.Name = "lblActivitiesTitle";
            lblActivitiesTitle.Size = new Size(300, 24);
            lblActivitiesTitle.TabIndex = 0;
            lblActivitiesTitle.Text = "📋 Recent Activities";
            // 
            // gridRecentActivities
            // 
            gridRecentActivities.Location = new Point(0, 548);
            gridRecentActivities.MainView = gridViewRecentActivities;
            gridRecentActivities.Name = "gridRecentActivities";
            gridRecentActivities.Size = new Size(1200, 180);
            gridRecentActivities.TabIndex = 5;
            gridRecentActivities.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewRecentActivities });
            // 
            // gridViewRecentActivities
            // 
            gridViewRecentActivities.Appearance.Empty.BackColor = Color.FromArgb(36, 43, 61);
            gridViewRecentActivities.Appearance.Empty.ForeColor = Color.FromArgb(203, 213, 225);
            gridViewRecentActivities.Appearance.Empty.Options.UseBackColor = true;
            gridViewRecentActivities.Appearance.Empty.Options.UseForeColor = true;
            gridViewRecentActivities.Appearance.EvenRow.BackColor = Color.FromArgb(36, 43, 61);
            gridViewRecentActivities.Appearance.EvenRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewRecentActivities.Appearance.EvenRow.Options.UseBackColor = true;
            gridViewRecentActivities.Appearance.EvenRow.Options.UseForeColor = true;
            gridViewRecentActivities.Appearance.FocusedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridViewRecentActivities.Appearance.FocusedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewRecentActivities.Appearance.FocusedRow.Options.UseBackColor = true;
            gridViewRecentActivities.Appearance.FocusedRow.Options.UseForeColor = true;
            gridViewRecentActivities.Appearance.HeaderPanel.BackColor = Color.FromArgb(36, 43, 61);
            gridViewRecentActivities.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gridViewRecentActivities.Appearance.HeaderPanel.ForeColor = Color.Black;
            gridViewRecentActivities.Appearance.HeaderPanel.Options.UseBackColor = true;
            gridViewRecentActivities.Appearance.HeaderPanel.Options.UseFont = true;
            gridViewRecentActivities.Appearance.HeaderPanel.Options.UseForeColor = true;
            gridViewRecentActivities.Appearance.HorzLine.BackColor = Color.FromArgb(51, 65, 85);
            gridViewRecentActivities.Appearance.HorzLine.Options.UseBackColor = true;
            gridViewRecentActivities.Appearance.Row.BackColor = Color.FromArgb(36, 43, 61);
            gridViewRecentActivities.Appearance.Row.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewRecentActivities.Appearance.Row.Options.UseBackColor = true;
            gridViewRecentActivities.Appearance.Row.Options.UseForeColor = true;
            gridViewRecentActivities.Appearance.SelectedRow.BackColor = Color.FromArgb(51, 65, 85);
            gridViewRecentActivities.Appearance.SelectedRow.ForeColor = Color.FromArgb(248, 250, 252);
            gridViewRecentActivities.Appearance.SelectedRow.Options.UseBackColor = true;
            gridViewRecentActivities.Appearance.SelectedRow.Options.UseForeColor = true;
            gridViewRecentActivities.Appearance.VertLine.BackColor = Color.FromArgb(51, 65, 85);
            gridViewRecentActivities.Appearance.VertLine.Options.UseBackColor = true;
            gridViewRecentActivities.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colActivityIcon, colActivityDescription, colActivityTarget, colActivityProject, colActivityTime });
            gridViewRecentActivities.GridControl = gridRecentActivities;
            gridViewRecentActivities.Name = "gridViewRecentActivities";
            gridViewRecentActivities.OptionsBehavior.Editable = false;
            gridViewRecentActivities.OptionsCustomization.AllowColumnMoving = false;
            gridViewRecentActivities.OptionsCustomization.AllowFilter = false;
            gridViewRecentActivities.OptionsCustomization.AllowSort = false;
            gridViewRecentActivities.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewRecentActivities.OptionsView.ShowGroupPanel = false;
            gridViewRecentActivities.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            gridViewRecentActivities.OptionsView.ShowIndicator = false;
            gridViewRecentActivities.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            // 
            // colActivityIcon
            // 
            colActivityIcon.FieldName = "Icon";
            colActivityIcon.Name = "colActivityIcon";
            colActivityIcon.OptionsColumn.AllowEdit = false;
            colActivityIcon.Visible = true;
            colActivityIcon.VisibleIndex = 0;
            colActivityIcon.Width = 40;
            // 
            // colActivityDescription
            // 
            colActivityDescription.Caption = "Activity";
            colActivityDescription.FieldName = "Description";
            colActivityDescription.Name = "colActivityDescription";
            colActivityDescription.OptionsColumn.AllowEdit = false;
            colActivityDescription.Visible = true;
            colActivityDescription.VisibleIndex = 1;
            colActivityDescription.Width = 350;
            // 
            // colActivityTarget
            // 
            colActivityTarget.Caption = "Target";
            colActivityTarget.FieldName = "Target";
            colActivityTarget.Name = "colActivityTarget";
            colActivityTarget.OptionsColumn.AllowEdit = false;
            colActivityTarget.Visible = true;
            colActivityTarget.VisibleIndex = 2;
            colActivityTarget.Width = 200;
            // 
            // colActivityProject
            // 
            colActivityProject.Caption = "Project";
            colActivityProject.FieldName = "Project";
            colActivityProject.Name = "colActivityProject";
            colActivityProject.OptionsColumn.AllowEdit = false;
            colActivityProject.Visible = true;
            colActivityProject.VisibleIndex = 3;
            colActivityProject.Width = 150;
            // 
            // colActivityTime
            // 
            colActivityTime.Caption = "Time";
            colActivityTime.FieldName = "Time";
            colActivityTime.Name = "colActivityTime";
            colActivityTime.OptionsColumn.AllowEdit = false;
            colActivityTime.Visible = true;
            colActivityTime.VisibleIndex = 4;
            colActivityTime.Width = 100;
            // 
            // DashboardContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 31, 38);
            Controls.Add(gridRecentActivities);
            Controls.Add(pnlActivitiesHeader);
            Controls.Add(gridRecentProjects);
            Controls.Add(pnlRecentHeader);
            Controls.Add(pnlKPIContainer);
            Controls.Add(pnlWelcomeHeader);
            ForeColor = Color.FromArgb(248, 250, 252);
            Name = "DashboardContent";
            Size = new Size(1200, 750);
            ((System.ComponentModel.ISupportInitialize)pnlWelcomeHeader).EndInit();
            pnlWelcomeHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKPIContainer).EndInit();
            pnlKPIContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlCardCompletion).EndInit();
            pnlCardCompletion.ResumeLayout(false);
            pnlCardCompletion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)progressCompletion.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCardTeam).EndInit();
            pnlCardTeam.ResumeLayout(false);
            pnlCardTeam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardTasks).EndInit();
            pnlCardTasks.ResumeLayout(false);
            pnlCardTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlCardProjects).EndInit();
            pnlCardProjects.ResumeLayout(false);
            pnlCardProjects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlRecentHeader).EndInit();
            pnlRecentHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridRecentProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRecentProjects).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlActivitiesHeader).EndInit();
            pnlActivitiesHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridRecentActivities).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewRecentActivities).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlWelcomeHeader;
        private DevExpress.XtraEditors.LabelControl lblWelcomeTitle;
        private DevExpress.XtraEditors.LabelControl lblWelcomeSubtitle;
        private DevExpress.XtraEditors.SimpleButton btnNewProject;
        private DevExpress.XtraEditors.PanelControl pnlKPIContainer;
        private DevExpress.XtraEditors.PanelControl pnlCardProjects;
        private DevExpress.XtraEditors.LabelControl lblCard1Icon;
        private DevExpress.XtraEditors.LabelControl lblCard1Label;
        private DevExpress.XtraEditors.LabelControl lblCard1Value;
        private DevExpress.XtraEditors.LabelControl lblCard1Trend;
        private DevExpress.XtraEditors.PanelControl pnlCardTeam;
        private DevExpress.XtraEditors.LabelControl lblCard3Trend;
        private DevExpress.XtraEditors.LabelControl lblCard3Label;
        private DevExpress.XtraEditors.LabelControl lblCard3Value;
        private DevExpress.XtraEditors.LabelControl lblCard3Icon;
        private DevExpress.XtraEditors.PanelControl pnlCardTasks;
        private DevExpress.XtraEditors.LabelControl lblCard2Trend;
        private DevExpress.XtraEditors.LabelControl lblCard2Label;
        private DevExpress.XtraEditors.LabelControl lblCard2Value;
        private DevExpress.XtraEditors.LabelControl lblCard2Icon;
        private DevExpress.XtraEditors.PanelControl pnlCardCompletion;
        private DevExpress.XtraEditors.LabelControl lblCard4Label;
        private DevExpress.XtraEditors.LabelControl lblCard4Value;
        private DevExpress.XtraEditors.LabelControl lblCard4Icon;
        private DevExpress.XtraEditors.ProgressBarControl progressCompletion;
        private DevExpress.XtraEditors.PanelControl pnlRecentHeader;
        private DevExpress.XtraEditors.LabelControl lblRecentTitle;
        private DevExpress.XtraEditors.SimpleButton btnViewAllProjects;
        private DevExpress.XtraGrid.GridControl gridRecentProjects;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRecentProjects;
        private DevExpress.XtraEditors.PanelControl pnlActivitiesHeader;
        private DevExpress.XtraEditors.LabelControl lblActivitiesTitle;
        private DevExpress.XtraGrid.GridControl gridRecentActivities;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRecentActivities;
        
        // Grid Columns for Recent Projects
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colProgress;
        private DevExpress.XtraGrid.Columns.GridColumn colManagerName;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        
        // Grid Columns for Recent Activities
        private DevExpress.XtraGrid.Columns.GridColumn colActivityIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityTarget;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityProject;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityTime;
    }
}
