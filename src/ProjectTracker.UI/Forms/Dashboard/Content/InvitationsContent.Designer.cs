using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class InvitationsContent
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
            btnSendInvitation = new DevExpress.XtraEditors.SimpleButton();
            pnlSendForm = new DevExpress.XtraEditors.PanelControl();
            lblEmail = new DevExpress.XtraEditors.LabelControl();
            txtEmail = new DevExpress.XtraEditors.TextEdit();
            lblRole = new DevExpress.XtraEditors.LabelControl();
            cmbRole = new DevExpress.XtraEditors.ComboBoxEdit();
            btnSend = new DevExpress.XtraEditors.SimpleButton();
            pnlInvitationsList = new DevExpress.XtraEditors.PanelControl();
            flowInvitations = new FlowLayoutPanel();
            pnlFooter = new DevExpress.XtraEditors.PanelControl();
            lblRecordCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSendForm).BeginInit();
            pnlSendForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlInvitationsList).BeginInit();
            pnlInvitationsList.SuspendLayout();
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
            pnlHeader.Controls.Add(btnSendInvitation);
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
            lblTitle.Text = "📧   Team Invitations";
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
            lblSubtitle.Size = new Size(350, 22);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Invite team members via email";
            // 
            // btnSendInvitation
            // 
            btnSendInvitation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSendInvitation.Appearance.BackColor = ColorPalette.AccentRoyalBlue;
            btnSendInvitation.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSendInvitation.Appearance.ForeColor = Color.White;
            btnSendInvitation.Appearance.Options.UseBackColor = true;
            btnSendInvitation.Appearance.Options.UseFont = true;
            btnSendInvitation.Appearance.Options.UseForeColor = true;
            btnSendInvitation.Location = new Point(960, 22);
            btnSendInvitation.Name = "btnSendInvitation";
            btnSendInvitation.Size = new Size(130, 36);
            btnSendInvitation.TabIndex = 2;
            btnSendInvitation.Text = "+ New Invite";
            // 
            // pnlSendForm
            // 
            pnlSendForm.Appearance.BackColor = ColorPalette.BackgroundSlateDark;
            pnlSendForm.Appearance.BorderColor = ColorPalette.BorderSlate;
            pnlSendForm.Appearance.Options.UseBackColor = true;
            pnlSendForm.Appearance.Options.UseBorderColor = true;
            pnlSendForm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlSendForm.Controls.Add(lblEmail);
            pnlSendForm.Controls.Add(txtEmail);
            pnlSendForm.Controls.Add(lblRole);
            pnlSendForm.Controls.Add(cmbRole);
            pnlSendForm.Controls.Add(btnSend);
            pnlSendForm.Dock = DockStyle.Top;
            pnlSendForm.Location = new Point(0, 80);
            pnlSendForm.Name = "pnlSendForm";
            pnlSendForm.Padding = new Padding(20, 15, 20, 15);
            pnlSendForm.Size = new Size(1100, 100);
            pnlSendForm.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.Appearance.Font = new Font("Segoe UI", 9F);
            lblEmail.Appearance.ForeColor = ColorPalette.TextSecondary;
            lblEmail.Appearance.Options.UseFont = true;
            lblEmail.Appearance.Options.UseForeColor = true;
            lblEmail.Location = new Point(20, 15);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(92, 15);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email Address *";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 38);
            txtEmail.Name = "txtEmail";
            txtEmail.Properties.Appearance.BackColor = ColorPalette.BackgroundSlateMedium;
            txtEmail.Properties.Appearance.BorderColor = ColorPalette.BorderSlate;
            txtEmail.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txtEmail.Properties.Appearance.ForeColor = ColorPalette.TextPrimary;
            txtEmail.Properties.Appearance.Options.UseBackColor = true;
            txtEmail.Properties.Appearance.Options.UseBorderColor = true;
            txtEmail.Properties.Appearance.Options.UseFont = true;
            txtEmail.Properties.Appearance.Options.UseForeColor = true;
            txtEmail.Properties.AutoHeight = false;
            txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtEmail.Properties.NullText = "user@example.com";
            txtEmail.Properties.NullValuePrompt = "user@example.com";
            txtEmail.Properties.NullValuePromptShowForEmptyValue = true;
            txtEmail.Size = new Size(400, 36);
            txtEmail.TabIndex = 1;
            // 
            // lblRole
            // 
            lblRole.Appearance.Font = new Font("Segoe UI", 9F);
            lblRole.Appearance.ForeColor = ColorPalette.TextSecondary;
            lblRole.Appearance.Options.UseFont = true;
            lblRole.Appearance.Options.UseForeColor = true;
            lblRole.Location = new Point(440, 15);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(35, 15);
            lblRole.TabIndex = 2;
            lblRole.Text = "Role *";
            // 
            // cmbRole
            // 
            cmbRole.Location = new Point(440, 38);
            cmbRole.Name = "cmbRole";
            cmbRole.Properties.Appearance.BackColor = ColorPalette.BackgroundSlateMedium;
            cmbRole.Properties.Appearance.BorderColor = ColorPalette.BorderSlate;
            cmbRole.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            cmbRole.Properties.Appearance.ForeColor = ColorPalette.TextPrimary;
            cmbRole.Properties.Appearance.Options.UseBackColor = true;
            cmbRole.Properties.Appearance.Options.UseBorderColor = true;
            cmbRole.Properties.Appearance.Options.UseFont = true;
            cmbRole.Properties.Appearance.Options.UseForeColor = true;
            cmbRole.Properties.AutoHeight = false;
            cmbRole.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cmbRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbRole.Properties.Items.AddRange(new object[] { "Project Manager", "Developer", "Observer" });
            cmbRole.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbRole.Size = new Size(250, 36);
            cmbRole.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Appearance.BackColor = ColorPalette.AccentRoyalBlue;
            btnSend.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSend.Appearance.ForeColor = Color.White;
            btnSend.Appearance.Options.UseBackColor = true;
            btnSend.Appearance.Options.UseFont = true;
            btnSend.Appearance.Options.UseForeColor = true;
            btnSend.Location = new Point(710, 38);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(140, 36);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send ✉️";
            // 
            // pnlInvitationsList
            // 
            pnlInvitationsList.Appearance.BackColor = ColorPalette.BackgroundDeepNavy;
            pnlInvitationsList.Appearance.Options.UseBackColor = true;
            pnlInvitationsList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlInvitationsList.Controls.Add(flowInvitations);
            pnlInvitationsList.Dock = DockStyle.Fill;
            pnlInvitationsList.Location = new Point(0, 180);
            pnlInvitationsList.Name = "pnlInvitationsList";
            pnlInvitationsList.Padding = new Padding(0, 15, 0, 0);
            pnlInvitationsList.Size = new Size(1100, 500);
            pnlInvitationsList.TabIndex = 2;
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
            flowInvitations.Size = new Size(1100, 485);
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
            pnlFooter.TabIndex = 3;
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
            lblRecordCount.Text = "Showing 0 pending invitations";
            // 
            // InvitationsContent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorPalette.BackgroundDeepNavy;
            Controls.Add(pnlInvitationsList);
            Controls.Add(pnlFooter);
            Controls.Add(pnlSendForm);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "InvitationsContent";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlSendForm).EndInit();
            pnlSendForm.ResumeLayout(false);
            pnlSendForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlInvitationsList).EndInit();
            pnlInvitationsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFooter).EndInit();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.SimpleButton btnSendInvitation;
        private DevExpress.XtraEditors.PanelControl pnlSendForm;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblRole;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRole;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.PanelControl pnlInvitationsList;
        private FlowLayoutPanel flowInvitations;
        private DevExpress.XtraEditors.PanelControl pnlFooter;
        private DevExpress.XtraEditors.LabelControl lblRecordCount;
    }
}
