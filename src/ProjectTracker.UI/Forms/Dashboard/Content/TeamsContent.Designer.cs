namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class TeamsContent
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
            btnCreateTeam = new DevExpress.XtraEditors.SimpleButton();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            pnlSwitcher = new DevExpress.XtraEditors.PanelControl();
            txtSearch = new DevExpress.XtraEditors.TextEdit();
            lueActiveTeam = new DevExpress.XtraEditors.LookUpEdit();
            lblActiveTeam = new DevExpress.XtraEditors.LabelControl();
            pnlCardsContainer = new DevExpress.XtraEditors.PanelControl();
            flowTeamCards = new FlowLayoutPanel();
            pnlFooter = new DevExpress.XtraEditors.PanelControl();
            btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            lblRecordCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSwitcher).BeginInit();
            pnlSwitcher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueActiveTeam.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlCardsContainer).BeginInit();
            pnlCardsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFooter).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(11, 11, 11);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(btnCreateTeam);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnCreateTeam
            // 
            btnCreateTeam.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            btnCreateTeam.Appearance.BorderColor = Color.FromArgb(255, 77, 0);
            btnCreateTeam.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateTeam.Appearance.ForeColor = Color.White;
            btnCreateTeam.Appearance.Options.UseBackColor = true;
            btnCreateTeam.Appearance.Options.UseBorderColor = true;
            btnCreateTeam.Appearance.Options.UseFont = true;
            btnCreateTeam.Appearance.Options.UseForeColor = true;
            btnCreateTeam.Location = new Point(960, 25);
            btnCreateTeam.Name = "btnCreateTeam";
            btnCreateTeam.Size = new Size(130, 36);
            btnCreateTeam.TabIndex = 2;
            btnCreateTeam.Text = "+ Create Team";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 10F);
            lblSubtitle.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSubtitle.Location = new Point(0, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(500, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage your teams and switch between workspaces";
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
            lblTitle.Text = "🏢 Teams";
            // 
            // pnlSwitcher
            // 
            pnlSwitcher.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            pnlSwitcher.Appearance.Options.UseBackColor = true;
            pnlSwitcher.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlSwitcher.Controls.Add(txtSearch);
            pnlSwitcher.Controls.Add(lueActiveTeam);
            pnlSwitcher.Controls.Add(lblActiveTeam);
            pnlSwitcher.Dock = DockStyle.Top;
            pnlSwitcher.Location = new Point(0, 80);
            pnlSwitcher.Name = "pnlSwitcher";
            pnlSwitcher.Padding = new Padding(15, 12, 15, 12);
            pnlSwitcher.Size = new Size(1100, 60);
            pnlSwitcher.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(780, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            txtSearch.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            txtSearch.Properties.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            txtSearch.Properties.Appearance.Options.UseBackColor = true;
            txtSearch.Properties.Appearance.Options.UseBorderColor = true;
            txtSearch.Properties.Appearance.Options.UseForeColor = true;
            txtSearch.Properties.AutoHeight = false;
            txtSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtSearch.Properties.NullText = "🔍 Search teams...";
            txtSearch.Size = new Size(300, 30);
            txtSearch.TabIndex = 2;
            // 
            // lueActiveTeam
            // 
            lueActiveTeam.Location = new Point(120, 15);
            lueActiveTeam.Name = "lueActiveTeam";
            lueActiveTeam.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            lueActiveTeam.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            lueActiveTeam.Properties.Appearance.ForeColor = Color.White;
            lueActiveTeam.Properties.Appearance.Options.UseBackColor = true;
            lueActiveTeam.Properties.Appearance.Options.UseBorderColor = true;
            lueActiveTeam.Properties.Appearance.Options.UseForeColor = true;
            lueActiveTeam.Properties.AutoHeight = false;
            lueActiveTeam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            lueActiveTeam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueActiveTeam.Properties.DisplayMember = "TeamName";
            lueActiveTeam.Properties.NullText = "Select a team...";
            lueActiveTeam.Properties.ValueMember = "TeamId";
            lueActiveTeam.Size = new Size(300, 30);
            lueActiveTeam.TabIndex = 1;
            // 
            // lblActiveTeam
            // 
            lblActiveTeam.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblActiveTeam.Appearance.ForeColor = Color.White;
            lblActiveTeam.Appearance.Options.UseFont = true;
            lblActiveTeam.Appearance.Options.UseForeColor = true;
            lblActiveTeam.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblActiveTeam.Location = new Point(15, 18);
            lblActiveTeam.Name = "lblActiveTeam";
            lblActiveTeam.Size = new Size(100, 24);
            lblActiveTeam.TabIndex = 0;
            lblActiveTeam.Text = "Active Team:";
            // 
            // pnlCardsContainer
            // 
            pnlCardsContainer.Appearance.BackColor = Color.FromArgb(11, 11, 11);
            pnlCardsContainer.Appearance.Options.UseBackColor = true;
            pnlCardsContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlCardsContainer.Controls.Add(flowTeamCards);
            pnlCardsContainer.Dock = DockStyle.Fill;
            pnlCardsContainer.Location = new Point(0, 140);
            pnlCardsContainer.Name = "pnlCardsContainer";
            pnlCardsContainer.Padding = new Padding(15, 15, 15, 0);
            pnlCardsContainer.Size = new Size(1100, 540);
            pnlCardsContainer.TabIndex = 2;
            // 
            // flowTeamCards
            // 
            flowTeamCards.AutoScroll = true;
            flowTeamCards.BackColor = Color.FromArgb(11, 11, 11);
            flowTeamCards.Location = new Point(15, 15);
            flowTeamCards.Name = "flowTeamCards";
            flowTeamCards.Size = new Size(1070, 590);
            flowTeamCards.TabIndex = 0;
            // 
            // pnlFooter
            // 
            pnlFooter.Appearance.BackColor = Color.FromArgb(11, 11, 11);
            pnlFooter.Appearance.Options.UseBackColor = true;
            pnlFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFooter.Controls.Add(btnRefresh);
            pnlFooter.Controls.Add(lblRecordCount);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 680);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1100, 50);
            pnlFooter.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            btnRefresh.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            btnRefresh.Appearance.Font = new Font("Segoe UI", 9F);
            btnRefresh.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnRefresh.Appearance.Options.UseBackColor = true;
            btnRefresh.Appearance.Options.UseBorderColor = true;
            btnRefresh.Appearance.Options.UseFont = true;
            btnRefresh.Appearance.Options.UseForeColor = true;
            btnRefresh.Location = new Point(1000, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Refresh";
            // 
            // lblRecordCount
            // 
            lblRecordCount.Appearance.Font = new Font("Segoe UI", 9F);
            lblRecordCount.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblRecordCount.Appearance.Options.UseFont = true;
            lblRecordCount.Appearance.Options.UseForeColor = true;
            lblRecordCount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblRecordCount.Location = new Point(15, 15);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(200, 20);
            lblRecordCount.TabIndex = 0;
            lblRecordCount.Text = "Showing 0 of 0 teams";
            // 
            // TeamsContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 11, 11);
            Controls.Add(pnlCardsContainer);
            Controls.Add(pnlFooter);
            Controls.Add(pnlSwitcher);
            Controls.Add(pnlHeader);
            Name = "TeamsContent";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlSwitcher).EndInit();
            pnlSwitcher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtSearch.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueActiveTeam.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlCardsContainer).EndInit();
            pnlCardsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFooter).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.SimpleButton btnCreateTeam;
        private DevExpress.XtraEditors.PanelControl pnlSwitcher;
        private DevExpress.XtraEditors.LabelControl lblActiveTeam;
        private DevExpress.XtraEditors.LookUpEdit lueActiveTeam;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.PanelControl pnlCardsContainer;
        private System.Windows.Forms.FlowLayoutPanel flowTeamCards;
        private DevExpress.XtraEditors.PanelControl pnlFooter;
        private DevExpress.XtraEditors.LabelControl lblRecordCount;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
    }
}
