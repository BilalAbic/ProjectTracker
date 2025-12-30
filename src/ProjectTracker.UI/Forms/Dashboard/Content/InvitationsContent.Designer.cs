namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class InvitationsContent
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
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            btnSendInvitation = new DevExpress.XtraEditors.SimpleButton();
            pnlSendForm = new DevExpress.XtraEditors.PanelControl();
            lblEmail = new DevExpress.XtraEditors.LabelControl();
            txtEmail = new DevExpress.XtraEditors.TextEdit();
            lblRole = new DevExpress.XtraEditors.LabelControl();
            cmbRole = new DevExpress.XtraEditors.ComboBoxEdit();
            btnSend = new DevExpress.XtraEditors.SimpleButton();
            pnlInvitationsList = new DevExpress.XtraEditors.PanelControl();
            flowInvitations = new FlowLayoutPanel();
            lblRecordCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSendForm).BeginInit();
            pnlSendForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlInvitationsList).BeginInit();
            pnlInvitationsList.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(11, 11, 11);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnSendInvitation);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(230, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📧 Team Invitations";
            // 
            // btnSendInvitation
            // 
            btnSendInvitation.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            btnSendInvitation.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSendInvitation.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            btnSendInvitation.Appearance.Options.UseBackColor = true;
            btnSendInvitation.Appearance.Options.UseFont = true;
            btnSendInvitation.Appearance.Options.UseForeColor = true;
            btnSendInvitation.Location = new Point(950, 25);
            btnSendInvitation.Name = "btnSendInvitation";
            btnSendInvitation.Size = new Size(140, 36);
            btnSendInvitation.TabIndex = 1;
            btnSendInvitation.Text = "Send Invitation";
            // 
            // pnlSendForm
            // 
            pnlSendForm.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            pnlSendForm.Appearance.Options.UseBackColor = true;
            pnlSendForm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlSendForm.Controls.Add(lblEmail);
            pnlSendForm.Controls.Add(txtEmail);
            pnlSendForm.Controls.Add(lblRole);
            pnlSendForm.Controls.Add(cmbRole);
            pnlSendForm.Controls.Add(btnSend);
            pnlSendForm.Location = new Point(50, 100);
            pnlSendForm.Name = "pnlSendForm";
            pnlSendForm.Size = new Size(1000, 120);
            pnlSendForm.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.Appearance.Font = new Font("Segoe UI", 9F);
            lblEmail.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblEmail.Appearance.Options.UseFont = true;
            lblEmail.Appearance.Options.UseForeColor = true;
            lblEmail.Location = new Point(20, 20);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(82, 15);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email Address *";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 45);
            txtEmail.Name = "txtEmail";
            txtEmail.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            txtEmail.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            txtEmail.Properties.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            txtEmail.Properties.Appearance.Options.UseBackColor = true;
            txtEmail.Properties.Appearance.Options.UseFont = true;
            txtEmail.Properties.Appearance.Options.UseForeColor = true;
            txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtEmail.Properties.NullText = "user@example.com";
            txtEmail.Size = new Size(450, 22);
            txtEmail.TabIndex = 1;
            // 
            // lblRole
            // 
            lblRole.Appearance.Font = new Font("Segoe UI", 9F);
            lblRole.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblRole.Appearance.Options.UseFont = true;
            lblRole.Appearance.Options.UseForeColor = true;
            lblRole.Location = new Point(490, 20);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(31, 15);
            lblRole.TabIndex = 2;
            lblRole.Text = "Role *";
            // 
            // cmbRole
            // 
            cmbRole.Location = new Point(490, 45);
            cmbRole.Name = "cmbRole";
            cmbRole.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            cmbRole.Properties.Appearance.Font = new Font("Segoe UI", 9F);
            cmbRole.Properties.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            cmbRole.Properties.Appearance.Options.UseBackColor = true;
            cmbRole.Properties.Appearance.Options.UseFont = true;
            cmbRole.Properties.Appearance.Options.UseForeColor = true;
            cmbRole.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cmbRole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbRole.Properties.Items.AddRange(new object[] { "Admin", "Project Manager", "Developer", "Observer" });
            cmbRole.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbRole.Size = new Size(300, 22);
            cmbRole.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            btnSend.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSend.Appearance.ForeColor = Color.FromArgb(255, 255, 255);
            btnSend.Appearance.Options.UseBackColor = true;
            btnSend.Appearance.Options.UseFont = true;
            btnSend.Appearance.Options.UseForeColor = true;
            btnSend.Location = new Point(810, 45);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(170, 30);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send ✉️";
            // 
            // pnlInvitationsList
            // 
            pnlInvitationsList.Appearance.BackColor = Color.FromArgb(11, 11, 11);
            pnlInvitationsList.Appearance.Options.UseBackColor = true;
            pnlInvitationsList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlInvitationsList.Controls.Add(flowInvitations);
            pnlInvitationsList.Location = new Point(50, 240);
            pnlInvitationsList.Name = "pnlInvitationsList";
            pnlInvitationsList.Size = new Size(1000, 420);
            pnlInvitationsList.TabIndex = 2;
            // 
            // flowInvitations
            // 
            flowInvitations.BackColor = Color.FromArgb(11, 11, 11);
            flowInvitations.Dock = DockStyle.Fill;
            flowInvitations.FlowDirection = FlowDirection.TopDown;
            flowInvitations.Location = new Point(0, 0);
            flowInvitations.Name = "flowInvitations";
            flowInvitations.Size = new Size(1000, 420);
            flowInvitations.TabIndex = 0;
            flowInvitations.WrapContents = false;
            // 
            // lblRecordCount
            // 
            lblRecordCount.Appearance.Font = new Font("Segoe UI", 9F);
            lblRecordCount.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblRecordCount.Appearance.Options.UseFont = true;
            lblRecordCount.Appearance.Options.UseForeColor = true;
            lblRecordCount.Location = new Point(50, 670);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(160, 15);
            lblRecordCount.TabIndex = 3;
            lblRecordCount.Text = "Showing 0 pending invitations";
            // 
            // InvitationsContent
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 11, 11);
            Controls.Add(lblRecordCount);
            Controls.Add(pnlInvitationsList);
            Controls.Add(pnlSendForm);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "InvitationsContent";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlSendForm).EndInit();
            pnlSendForm.ResumeLayout(false);
            pnlSendForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtEmail.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlInvitationsList).EndInit();
            pnlInvitationsList.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnSendInvitation;
        private DevExpress.XtraEditors.PanelControl pnlSendForm;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblRole;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRole;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.PanelControl pnlInvitationsList;
        private FlowLayoutPanel flowInvitations;
        private DevExpress.XtraEditors.LabelControl lblRecordCount;
    }
}
