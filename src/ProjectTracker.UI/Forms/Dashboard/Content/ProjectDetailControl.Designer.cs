namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class ProjectDetailControl
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
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            btnBack = new DevExpress.XtraEditors.SimpleButton();
            pnlForm = new DevExpress.XtraEditors.PanelControl();
            btnSave = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            spinBudget = new DevExpress.XtraEditors.SpinEdit();
            lblBudget = new DevExpress.XtraEditors.LabelControl();
            lueManager = new DevExpress.XtraEditors.LookUpEdit();
            lblManager = new DevExpress.XtraEditors.LabelControl();
            cmbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            cmbPriority = new DevExpress.XtraEditors.ComboBoxEdit();
            lblPriority = new DevExpress.XtraEditors.LabelControl();
            dateEndDate = new DevExpress.XtraEditors.DateEdit();
            lblEndDate = new DevExpress.XtraEditors.LabelControl();
            dateStartDate = new DevExpress.XtraEditors.DateEdit();
            lblStartDate = new Label();
            memoDescription = new DevExpress.XtraEditors.MemoEdit();
            lblDescription = new DevExpress.XtraEditors.LabelControl();
            txtProjectName = new DevExpress.XtraEditors.TextEdit();
            lblProjectName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlForm).BeginInit();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spinBudget.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lueManager.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbStatus.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbPriority.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateStartDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memoDescription.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProjectName.Properties).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Appearance.BackColor = Color.FromArgb(11, 11, 11);
            pnlHeader.Appearance.Options.UseBackColor = true;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.Appearance.Options.UseForeColor = true;
            lblSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSubtitle.Location = new Point(100, 55);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(300, 20);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Fill in the project details below";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Appearance.ForeColor = Color.White;
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.Appearance.Options.UseForeColor = true;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(100, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 35);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "📁 New Project";
            // 
            // btnBack
            // 
            btnBack.Appearance.BackColor = Color.Transparent;
            btnBack.Appearance.BorderColor = Color.Transparent;
            btnBack.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            btnBack.Appearance.Options.UseBackColor = true;
            btnBack.Appearance.Options.UseBorderColor = true;
            btnBack.Appearance.Options.UseFont = true;
            btnBack.Appearance.Options.UseForeColor = true;
            btnBack.Location = new Point(0, 25);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(80, 30);
            btnBack.TabIndex = 0;
            btnBack.Text = "← Back";
            btnBack.Click += btnBack_Click;
            // 
            // pnlForm
            // 
            pnlForm.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            pnlForm.Appearance.Options.UseBackColor = true;
            pnlForm.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlForm.Controls.Add(btnSave);
            pnlForm.Controls.Add(btnCancel);
            pnlForm.Controls.Add(spinBudget);
            pnlForm.Controls.Add(lblBudget);
            pnlForm.Controls.Add(lueManager);
            pnlForm.Controls.Add(lblManager);
            pnlForm.Controls.Add(cmbStatus);
            pnlForm.Controls.Add(lblStatus);
            pnlForm.Controls.Add(cmbPriority);
            pnlForm.Controls.Add(lblPriority);
            pnlForm.Controls.Add(dateEndDate);
            pnlForm.Controls.Add(lblEndDate);
            pnlForm.Controls.Add(dateStartDate);
            pnlForm.Controls.Add(lblStartDate);
            pnlForm.Controls.Add(memoDescription);
            pnlForm.Controls.Add(lblDescription);
            pnlForm.Controls.Add(txtProjectName);
            pnlForm.Controls.Add(lblProjectName);
            pnlForm.Location = new Point(0, 80);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(30);
            pnlForm.Size = new Size(600, 550);
            pnlForm.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            btnSave.Appearance.BorderColor = Color.FromArgb(255, 77, 0);
            btnSave.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Appearance.ForeColor = Color.White;
            btnSave.Appearance.Options.UseBackColor = true;
            btnSave.Appearance.Options.UseBorderColor = true;
            btnSave.Appearance.Options.UseFont = true;
            btnSave.Appearance.Options.UseForeColor = true;
            btnSave.Location = new Point(460, 480);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 40);
            btnSave.TabIndex = 17;
            btnSave.Text = "💾 Save Project";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            btnCancel.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            btnCancel.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Appearance.ForeColor = Color.White;
            btnCancel.Appearance.Options.UseBackColor = true;
            btnCancel.Appearance.Options.UseBorderColor = true;
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Appearance.Options.UseForeColor = true;
            btnCancel.Location = new Point(350, 480);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // spinBudget
            // 
            spinBudget.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            spinBudget.Location = new Point(310, 400);
            spinBudget.Name = "spinBudget";
            spinBudget.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            spinBudget.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            spinBudget.Properties.Appearance.ForeColor = Color.White;
            spinBudget.Properties.Appearance.Options.UseBackColor = true;
            spinBudget.Properties.Appearance.Options.UseBorderColor = true;
            spinBudget.Properties.Appearance.Options.UseForeColor = true;
            spinBudget.Properties.AutoHeight = false;
            spinBudget.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            spinBudget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            spinBudget.Properties.DisplayFormat.FormatString = "c2";
            spinBudget.Properties.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            spinBudget.Size = new Size(260, 35);
            spinBudget.TabIndex = 15;
            // 
            // lblBudget
            // 
            lblBudget.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBudget.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblBudget.Appearance.Options.UseFont = true;
            lblBudget.Appearance.Options.UseForeColor = true;
            lblBudget.Location = new Point(310, 375);
            lblBudget.Name = "lblBudget";
            lblBudget.Size = new Size(41, 17);
            lblBudget.TabIndex = 14;
            lblBudget.Text = "Budget";
            // 
            // lueManager
            // 
            lueManager.Location = new Point(30, 400);
            lueManager.Name = "lueManager";
            lueManager.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            lueManager.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            lueManager.Properties.Appearance.ForeColor = Color.White;
            lueManager.Properties.Appearance.Options.UseBackColor = true;
            lueManager.Properties.Appearance.Options.UseBorderColor = true;
            lueManager.Properties.Appearance.Options.UseForeColor = true;
            lueManager.Properties.AutoHeight = false;
            lueManager.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            lueManager.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lueManager.Properties.NullText = "Select manager...";
            lueManager.Size = new Size(260, 35);
            lueManager.TabIndex = 13;
            // 
            // lblManager
            // 
            lblManager.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManager.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblManager.Appearance.Options.UseFont = true;
            lblManager.Appearance.Options.UseForeColor = true;
            lblManager.Location = new Point(30, 375);
            lblManager.Name = "lblManager";
            lblManager.Size = new Size(53, 17);
            lblManager.TabIndex = 12;
            lblManager.Text = "Manager";
            // 
            // cmbStatus
            // 
            cmbStatus.Location = new Point(30, 325);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            cmbStatus.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            cmbStatus.Properties.Appearance.ForeColor = Color.White;
            cmbStatus.Properties.Appearance.Options.UseBackColor = true;
            cmbStatus.Properties.Appearance.Options.UseBorderColor = true;
            cmbStatus.Properties.Appearance.Options.UseForeColor = true;
            cmbStatus.Properties.AutoHeight = false;
            cmbStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cmbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbStatus.Size = new Size(260, 35);
            cmbStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblStatus.Appearance.Options.UseFont = true;
            lblStatus.Appearance.Options.UseForeColor = true;
            lblStatus.Location = new Point(30, 300);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(35, 17);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status";
            // 
            // cmbPriority
            // 
            cmbPriority.Location = new Point(310, 325);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            cmbPriority.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            cmbPriority.Properties.Appearance.ForeColor = Color.White;
            cmbPriority.Properties.Appearance.Options.UseBackColor = true;
            cmbPriority.Properties.Appearance.Options.UseBorderColor = true;
            cmbPriority.Properties.Appearance.Options.UseForeColor = true;
            cmbPriority.Properties.AutoHeight = false;
            cmbPriority.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            cmbPriority.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbPriority.Size = new Size(260, 35);
            cmbPriority.TabIndex = 9;
            // 
            // lblPriority
            // 
            lblPriority.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPriority.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblPriority.Appearance.Options.UseFont = true;
            lblPriority.Appearance.Options.UseForeColor = true;
            lblPriority.Location = new Point(310, 300);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(41, 17);
            lblPriority.TabIndex = 8;
            lblPriority.Text = "Priority";
            // 
            // dateEndDate
            // 
            dateEndDate.EditValue = null;
            dateEndDate.Location = new Point(310, 250);
            dateEndDate.Name = "dateEndDate";
            dateEndDate.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            dateEndDate.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            dateEndDate.Properties.Appearance.ForeColor = Color.White;
            dateEndDate.Properties.Appearance.Options.UseBackColor = true;
            dateEndDate.Properties.Appearance.Options.UseBorderColor = true;
            dateEndDate.Properties.Appearance.Options.UseForeColor = true;
            dateEndDate.Properties.AutoHeight = false;
            dateEndDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            dateEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEndDate.Properties.NullText = "Select date...";
            dateEndDate.Size = new Size(260, 35);
            dateEndDate.TabIndex = 7;
            // 
            // lblEndDate
            // 
            lblEndDate.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEndDate.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblEndDate.Appearance.Options.UseFont = true;
            lblEndDate.Appearance.Options.UseForeColor = true;
            lblEndDate.Location = new Point(310, 225);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(53, 17);
            lblEndDate.TabIndex = 6;
            lblEndDate.Text = "End Date";
            // 
            // dateStartDate
            // 
            dateStartDate.EditValue = null;
            dateStartDate.Location = new Point(30, 250);
            dateStartDate.Name = "dateStartDate";
            dateStartDate.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            dateStartDate.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            dateStartDate.Properties.Appearance.ForeColor = Color.White;
            dateStartDate.Properties.Appearance.Options.UseBackColor = true;
            dateStartDate.Properties.Appearance.Options.UseBorderColor = true;
            dateStartDate.Properties.Appearance.Options.UseForeColor = true;
            dateStartDate.Properties.AutoHeight = false;
            dateStartDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            dateStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateStartDate.Properties.NullText = "Select date...";
            dateStartDate.Size = new Size(260, 35);
            dateStartDate.TabIndex = 5;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStartDate.ForeColor = Color.FromArgb(161, 161, 161);
            lblStartDate.Location = new Point(30, 225);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(75, 17);
            lblStartDate.TabIndex = 4;
            lblStartDate.Text = "Start Date *";
            // 
            // memoDescription
            // 
            memoDescription.Location = new Point(30, 130);
            memoDescription.Name = "memoDescription";
            memoDescription.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            memoDescription.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            memoDescription.Properties.Appearance.ForeColor = Color.White;
            memoDescription.Properties.Appearance.Options.UseBackColor = true;
            memoDescription.Properties.Appearance.Options.UseBorderColor = true;
            memoDescription.Properties.Appearance.Options.UseForeColor = true;
            memoDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            memoDescription.Properties.NullText = "Enter project description...";
            memoDescription.Size = new Size(540, 80);
            memoDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblDescription.Appearance.Options.UseFont = true;
            lblDescription.Appearance.Options.UseForeColor = true;
            lblDescription.Location = new Point(30, 105);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(66, 17);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Description";
            // 
            // txtProjectName
            // 
            txtProjectName.Location = new Point(35, 55);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Properties.Appearance.BackColor = Color.FromArgb(26, 26, 26);
            txtProjectName.Properties.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            txtProjectName.Properties.Appearance.ForeColor = Color.White;
            txtProjectName.Properties.Appearance.Options.UseBackColor = true;
            txtProjectName.Properties.Appearance.Options.UseBorderColor = true;
            txtProjectName.Properties.Appearance.Options.UseForeColor = true;
            txtProjectName.Properties.AutoHeight = false;
            txtProjectName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txtProjectName.Properties.NullText = "Enter project name...";
            txtProjectName.Size = new Size(540, 35);
            txtProjectName.TabIndex = 1;
            // 
            // lblProjectName
            // 
            lblProjectName.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectName.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            lblProjectName.Appearance.Options.UseFont = true;
            lblProjectName.Appearance.Options.UseForeColor = true;
            lblProjectName.Location = new Point(30, 30);
            lblProjectName.Name = "lblProjectName";
            lblProjectName.Size = new Size(88, 17);
            lblProjectName.TabIndex = 0;
            lblProjectName.Text = "Project Name *";
            // 
            // ProjectDetailControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 11, 11);
            Controls.Add(pnlForm);
            Controls.Add(pnlHeader);
            Name = "ProjectDetailControl";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlForm).EndInit();
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)spinBudget.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lueManager.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbStatus.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbPriority.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEndDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEndDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateStartDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateStartDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)memoDescription.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProjectName.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.PanelControl pnlForm;
        private DevExpress.XtraEditors.TextEdit txtProjectName;
        private DevExpress.XtraEditors.LabelControl lblProjectName;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.DateEdit dateStartDate;
        private Label lblStartDate;
        private DevExpress.XtraEditors.DateEdit dateEndDate;
        private DevExpress.XtraEditors.LabelControl lblEndDate;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPriority;
        private DevExpress.XtraEditors.LabelControl lblPriority;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStatus;
        private DevExpress.XtraEditors.SpinEdit spinBudget;
        private DevExpress.XtraEditors.LabelControl lblBudget;
        private DevExpress.XtraEditors.LookUpEdit lueManager;
        private DevExpress.XtraEditors.LabelControl lblManager;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
