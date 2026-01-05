using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class MyInvitationsContent
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
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            pnlContent = new DevExpress.XtraEditors.PanelControl();
            flowInvitations = new FlowLayoutPanel();
            pnlFooter = new DevExpress.XtraEditors.PanelControl();
            lblRecordCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlContent).BeginInit();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFooter).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = ColorPalette.BackgroundDeepNavy;
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = ColorPalette.TextPrimary;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📬   My Invitations";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 10F);
            lblSubtitle.Appearance.ForeColor = ColorPalette.TextTertiary;
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSubtitle.Location = new Point(0, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 22);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Accept or decline team invitations";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Appearance.BackColor = ColorPalette.BorderSlate;
            btnRefresh.Appearance.ForeColor = ColorPalette.TextPrimary;
            btnRefresh.Appearance.Font = new Font("Segoe UI", 9.5F);
            btnRefresh.Appearance.Options.UseBackColor = true;
            btnRefresh.Appearance.Options.UseForeColor = true;
            btnRefresh.Appearance.Options.UseFont = true;
            btnRefresh.Location = new Point(980, 22);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 36);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.Click += async (s, e) => await LoadInvitationsAsync();
            // 
            // pnlContent
            // 
            pnlContent.Appearance.BackColor = ColorPalette.BackgroundDeepNavy;
            pnlContent.Appearance.Options.UseBackColor = true;
            pnlContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlContent.Controls.Add(flowInvitations);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 80);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(0, 15, 0, 0);
            pnlContent.Size = new Size(1100, 600);
            pnlContent.TabIndex = 1;
            // 
            // flowInvitations
            // 
            flowInvitations.AutoScroll = true;
            flowInvitations.BackColor = ColorPalette.BackgroundDeepNavy;
            flowInvitations.Dock = DockStyle.Fill;
            flowInvitations.FlowDirection = FlowDirection.TopDown;
            flowInvitations.Location = new Point(0, 15);
            flowInvitations.Name = "flowInvitations";
            flowInvitations.Padding = new Padding(0, 0, 0, 10);
            flowInvitations.Size = new Size(1100, 585);
            flowInvitations.TabIndex = 0;
            flowInvitations.WrapContents = false;
            // 
            // pnlFooter
            // 
            pnlFooter.Appearance.BackColor = ColorPalette.BackgroundDeepNavy;
            pnlFooter.Appearance.Options.UseBackColor = true;
            pnlFooter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFooter.Controls.Add(lblRecordCount);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 680);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1100, 50);
            pnlFooter.TabIndex = 2;
            // 
            // lblRecordCount
            // 
            lblRecordCount.Appearance.Font = new Font("Segoe UI", 9F);
            lblRecordCount.Appearance.ForeColor = ColorPalette.TextSecondary;
            lblRecordCount.Appearance.Options.UseFont = true;
            lblRecordCount.Appearance.Options.UseForeColor = true;
            lblRecordCount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblRecordCount.Location = new Point(0, 15);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(300, 20);
            lblRecordCount.TabIndex = 0;
            lblRecordCount.Text = "Loading invitations...";
            // 
            // MyInvitationsContent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorPalette.BackgroundDeepNavy;
            Controls.Add(pnlContent);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "MyInvitationsContent";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlContent).EndInit();
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFooter).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl pnlContent;
        private FlowLayoutPanel flowInvitations;
        private DevExpress.XtraEditors.PanelControl pnlFooter;
        private DevExpress.XtraEditors.LabelControl lblRecordCount;
    }
}
