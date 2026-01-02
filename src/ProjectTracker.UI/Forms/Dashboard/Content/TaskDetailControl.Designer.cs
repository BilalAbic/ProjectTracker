using ProjectTracker.UI.Helpers;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class TaskDetailControl
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
            btnBack = new DevExpress.XtraEditors.SimpleButton();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            pnlFormContainer = new DevExpress.XtraEditors.PanelControl();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            cmbPriority = new DevExpress.XtraEditors.ComboBoxEdit();
            lblPriority = new DevExpress.XtraEditors.LabelControl();
            cmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            dateDue = new DevExpress.XtraEditors.DateEdit();
            lblDueDate = new DevExpress.XtraEditors.LabelControl();
            dateStart = new DevExpress.XtraEditors.DateEdit();
            lblStartDate = new DevExpress.XtraEditors.LabelControl();
            lueAssignee = new DevExpress.XtraEditors.LookUpEdit();
            lblAssignee = new DevExpress.XtraEditors.LabelControl();
            lueProject = new DevExpress.XtraEditors.LookUpEdit();
            lblProject = new DevExpress.XtraEditors.LabelControl();
            txtDescription = new DevExpress.XtraEditors.MemoEdit();
            lblDescription = new DevExpress.XtraEditors.LabelControl();
            txtTaskName = new DevExpress.XtraEditors.TextEdit();
            lblTaskName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFormContainer).BeginInit();
            pnlFormContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbPriority.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateDue.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateDue.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateStart.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateStart.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueAssignee.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTaskName.Properties).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            btnBack.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnBack.Appearance.Font = new Font("Segoe UI", 9F);
            btnBack.Appearance.ForeColor = Color.White;
            btnBack.Appearance.Options.UseBackColor = true;
            btnBack.Appearance.Options.UseBorderColor = true;
            btnBack.Appearance.Options.UseFont = true;
            btnBack.Appearance.Options.UseForeColor = true;
            btnBack.Location = new Point(10, 25);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(80, 30);
            btnBack.TabIndex = 1;
            btnBack.Text = "← Back";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = Color.White;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(100, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "New Task";
            // 
            // pnlFormContainer
            // 
            pnlFormContainer.Appearance.BackColor = Color.FromArgb(26, 31, 38);
            pnlFormContainer.Appearance.Options.UseBackColor = true;
            pnlFormContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFormContainer.Controls.Add(btnCancel);
            pnlFormContainer.Controls.Add(btnSave);
            pnlFormContainer.Controls.Add(cmbPriority);
            pnlFormContainer.Controls.Add(lblPriority);
            pnlFormContainer.Controls.Add(cmbStatus);
            pnlFormContainer.Controls.Add(lblStatus);
            pnlFormContainer.Controls.Add(dateDue);
            pnlFormContainer.Controls.Add(lblDueDate);
            pnlFormContainer.Controls.Add(dateStart);
            pnlFormContainer.Controls.Add(lblStartDate);
            pnlFormContainer.Controls.Add(lueAssignee);
            pnlFormContainer.Controls.Add(lblAssignee);
            pnlFormContainer.Controls.Add(lueProject);
            pnlFormContainer.Controls.Add(lblProject);
            pnlFormContainer.Controls.Add(txtDescription);
            pnlFormContainer.Controls.Add(lblDescription);
            pnlFormContainer.Controls.Add(txtTaskName);
            pnlFormContainer.Controls.Add(lblTaskName);
            pnlFormContainer.Location = new Point(50, 100);
            pnlFormContainer.Name = "pnlFormContainer";
            pnlFormContainer.Size = new Size(600, 600);
            pnlFormContainer.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.BackColor = Color.FromArgb(51, 65, 85);
            btnCancel.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            btnCancel.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            btnCancel.Appearance.Options.UseBackColor = true;
            btnCancel.Appearance.Options.UseBorderColor = true;
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Appearance.Options.UseForeColor = true;
            btnCancel.Location = new Point(340, 480);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            // 
            // btnSave
            // 
            btnSave.Appearance.BackColor = Color.FromArgb(91, 141, 239);
            btnSave.Appearance.BorderColor = Color.FromArgb(91, 141, 239);
            btnSave.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSave.Appearance.ForeColor = Color.White;
            btnSave.Appearance.Options.UseBackColor = true;
            btnSave.Appearance.Options.UseBorderColor = true;
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.Location = new Point(450, 480);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 16;
            btnSave.Text = "💾 Save Task";
            // 
            // cmbPriority
            // 
            cmbPriority.Location = new Point(310, 420);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            cmbPriority.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            cmbPriority.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            cmbPriority.Properties.Appearance.ForeColor = Color.White;
            cmbPriority.Properties.Appearance.Options.UseBackColor = true;
            cmbPriority.Properties.Appearance.Options.UseBorderColor = true;
            cmbPriority.Properties.Appearance.Options.UseFont = true;
            cmbPriority.Properties.Appearance.Options.UseForeColor = true;
            cmbPriority.Properties.AutoHeight = false;
            cmbPriority.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cmbPriority.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbPriority.Size = new Size(290, 36);
            cmbPriority.TabIndex = 15;
            // 
            // lblPriority
            // 
            lblPriority.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblPriority.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblPriority.Appearance.Options.UseFont = true;
            lblPriority.Appearance.Options.UseForeColor = true;
            lblPriority.Location = new Point(310, 395);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(44, 17);
            lblPriority.TabIndex = 14;
            lblPriority.Text = "Priority";
            // 
            // cmbStatus
            // 
            cmbStatus.Location = new Point(0, 420);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            cmbStatus.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            cmbStatus.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            cmbStatus.Properties.Appearance.ForeColor = Color.White;
            cmbStatus.Properties.Appearance.Options.UseBackColor = true;
            cmbStatus.Properties.Appearance.Options.UseBorderColor = true;
            cmbStatus.Properties.Appearance.Options.UseFont = true;
            cmbStatus.Properties.Appearance.Options.UseForeColor = true;
            cmbStatus.Properties.AutoHeight = false;
            cmbStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbStatus.Size = new Size(290, 36);
            cmbStatus.TabIndex = 13;
            // 
            // lblStatus
            // 
            lblStatus.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblStatus.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblStatus.Appearance.Options.UseFont = true;
            lblStatus.Appearance.Options.UseForeColor = true;
            lblStatus.Location = new Point(0, 395);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(40, 17);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status";
            // 
            // dateDue
            // 
            dateDue.EditValue = null;
            dateDue.Location = new Point(310, 345);
            dateDue.Name = "dateDue";
            dateDue.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            dateDue.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            dateDue.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            dateDue.Properties.Appearance.ForeColor = Color.White;
            dateDue.Properties.Appearance.Options.UseBackColor = true;
            dateDue.Properties.Appearance.Options.UseBorderColor = true;
            dateDue.Properties.Appearance.Options.UseFont = true;
            dateDue.Properties.Appearance.Options.UseForeColor = true;
            dateDue.Properties.AutoHeight = false;
            dateDue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            dateDue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateDue.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateDue.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            dateDue.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            dateDue.Size = new Size(290, 36);
            dateDue.TabIndex = 11;
            // 
            // lblDueDate
            // 
            lblDueDate.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblDueDate.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblDueDate.Appearance.Options.UseFont = true;
            lblDueDate.Appearance.Options.UseForeColor = true;
            lblDueDate.Location = new Point(310, 320);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(55, 17);
            lblDueDate.TabIndex = 10;
            lblDueDate.Text = "Due Date";
            // 
            // dateStart
            // 
            dateStart.EditValue = null;
            dateStart.Location = new Point(0, 345);
            dateStart.Name = "dateStart";
            dateStart.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            dateStart.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            dateStart.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            dateStart.Properties.Appearance.ForeColor = Color.White;
            dateStart.Properties.Appearance.Options.UseBackColor = true;
            dateStart.Properties.Appearance.Options.UseBorderColor = true;
            dateStart.Properties.Appearance.Options.UseFont = true;
            dateStart.Properties.Appearance.Options.UseForeColor = true;
            dateStart.Properties.AutoHeight = false;
            dateStart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateStart.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            dateStart.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            dateStart.Size = new Size(290, 36);
            dateStart.TabIndex = 9;
            // 
            // lblStartDate
            // 
            lblStartDate.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblStartDate.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblStartDate.Appearance.Options.UseFont = true;
            lblStartDate.Appearance.Options.UseForeColor = true;
            lblStartDate.Location = new Point(0, 320);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(68, 17);
            lblStartDate.TabIndex = 8;
            lblStartDate.Text = "Start Date *";
            // 
            // lueAssignee
            // 
            lueAssignee.Location = new Point(310, 270);
            lueAssignee.Name = "lueAssignee";
            lueAssignee.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            lueAssignee.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            lueAssignee.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            lueAssignee.Properties.Appearance.ForeColor = Color.White;
            lueAssignee.Properties.Appearance.Options.UseBackColor = true;
            lueAssignee.Properties.Appearance.Options.UseBorderColor = true;
            lueAssignee.Properties.Appearance.Options.UseFont = true;
            lueAssignee.Properties.Appearance.Options.UseForeColor = true;
            lueAssignee.Properties.AutoHeight = false;
            lueAssignee.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            lueAssignee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueAssignee.Properties.NullText = "Unassigned";
            lueAssignee.Properties.PopupWidth = 500;
            lueAssignee.Properties.ShowFooter = false;
            lueAssignee.Size = new Size(290, 36);
            lueAssignee.TabIndex = 7;
            // 
            // lblAssignee
            // 
            lblAssignee.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblAssignee.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblAssignee.Appearance.Options.UseFont = true;
            lblAssignee.Appearance.Options.UseForeColor = true;
            lblAssignee.Location = new Point(310, 245);
            lblAssignee.Name = "lblAssignee";
            lblAssignee.Size = new Size(54, 17);
            lblAssignee.TabIndex = 6;
            lblAssignee.Text = "Assignee";
            // 
            // lueProject
            // 
            lueProject.Location = new Point(0, 270);
            lueProject.Name = "lueProject";
            lueProject.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            lueProject.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            lueProject.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            lueProject.Properties.Appearance.ForeColor = Color.White;
            lueProject.Properties.Appearance.Options.UseBackColor = true;
            lueProject.Properties.Appearance.Options.UseBorderColor = true;
            lueProject.Properties.Appearance.Options.UseFont = true;
            lueProject.Properties.Appearance.Options.UseForeColor = true;
            lueProject.Properties.AutoHeight = false;
            lueProject.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            lueProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueProject.Properties.PopupWidth = 600;
            lueProject.Properties.ShowFooter = false;
            lueProject.Size = new Size(290, 36);
            lueProject.TabIndex = 5;
            // 
            // lblProject
            // 
            lblProject.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblProject.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblProject.Appearance.Options.UseFont = true;
            lblProject.Appearance.Options.UseForeColor = true;
            lblProject.Location = new Point(0, 245);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(53, 17);
            lblProject.TabIndex = 4;
            lblProject.Text = "Project *";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(0, 100);
            txtDescription.Name = "txtDescription";
            txtDescription.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            txtDescription.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtDescription.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txtDescription.Properties.Appearance.ForeColor = Color.White;
            txtDescription.Properties.Appearance.Options.UseBackColor = true;
            txtDescription.Properties.Appearance.Options.UseBorderColor = true;
            txtDescription.Properties.Appearance.Options.UseFont = true;
            txtDescription.Properties.Appearance.Options.UseForeColor = true;
            txtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtDescription.Size = new Size(600, 130);
            txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblDescription.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblDescription.Appearance.Options.UseFont = true;
            lblDescription.Appearance.Options.UseForeColor = true;
            lblDescription.Location = new Point(0, 75);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(70, 17);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description";
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(0, 25);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Properties.Appearance.BackColor = Color.FromArgb(30, 42, 58);
            txtTaskName.Properties.Appearance.BorderColor = Color.FromArgb(51, 65, 85);
            txtTaskName.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            txtTaskName.Properties.Appearance.ForeColor = Color.White;
            txtTaskName.Properties.Appearance.Options.UseBackColor = true;
            txtTaskName.Properties.Appearance.Options.UseBorderColor = true;
            txtTaskName.Properties.Appearance.Options.UseFont = true;
            txtTaskName.Properties.Appearance.Options.UseForeColor = true;
            txtTaskName.Properties.AutoHeight = false;
            txtTaskName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtTaskName.Properties.NullText = "Enter task name...";
            txtTaskName.Size = new Size(600, 36);
            txtTaskName.TabIndex = 1;
            // 
            // lblTaskName
            // 
            lblTaskName.Appearance.Font = new Font("Segoe UI", 9.75F);
            lblTaskName.Appearance.ForeColor = Color.FromArgb(203, 213, 225);
            lblTaskName.Appearance.Options.UseFont = true;
            lblTaskName.Appearance.Options.UseForeColor = true;
            lblTaskName.Location = new Point(0, 0);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(75, 17);
            lblTaskName.TabIndex = 0;
            lblTaskName.Text = "Task Name *";
            // 
            // TaskDetailControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 31, 38);
            Controls.Add(pnlFormContainer);
            Controls.Add(pnlHeader);
            Name = "TaskDetailControl";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFormContainer).EndInit();
            pnlFormContainer.ResumeLayout(false);
            pnlFormContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbPriority.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateDue.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateDue.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateStart.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateStart.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueAssignee.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueProject.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTaskName.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.PanelControl pnlFormContainer;
        private DevExpress.XtraEditors.LabelControl lblTaskName;
        private DevExpress.XtraEditors.TextEdit txtTaskName;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.LookUpEdit lueProject;
        private DevExpress.XtraEditors.LabelControl lblAssignee;
        private DevExpress.XtraEditors.LookUpEdit lueAssignee;
        private DevExpress.XtraEditors.LabelControl lblStartDate;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.LabelControl lblDueDate;
        private DevExpress.XtraEditors.DateEdit dateDue;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStatus;
        private DevExpress.XtraEditors.LabelControl lblPriority;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPriority;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
