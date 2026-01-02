namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    partial class ReportsContent
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
            btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            btnExportPdf = new DevExpress.XtraEditors.SimpleButton();
            lblSubtitle = new DevExpress.XtraEditors.LabelControl();
            lblTitle = new DevExpress.XtraEditors.LabelControl();
            pnlFilters = new DevExpress.XtraEditors.PanelControl();
            btnApplyFilter = new DevExpress.XtraEditors.SimpleButton();
            cmbProjectFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            dateEnd = new DevExpress.XtraEditors.DateEdit();
            lblTo = new DevExpress.XtraEditors.LabelControl();
            dateStart = new DevExpress.XtraEditors.DateEdit();
            pnlKPIContainer = new DevExpress.XtraEditors.PanelControl();
            pnlKPICard4 = new DevExpress.XtraEditors.PanelControl();
            lblKPI4Title = new DevExpress.XtraEditors.LabelControl();
            lblKPI4Value = new DevExpress.XtraEditors.LabelControl();
            lblKPI4Icon = new DevExpress.XtraEditors.LabelControl();
            pnlKPICard3 = new DevExpress.XtraEditors.PanelControl();
            lblKPI3Title = new DevExpress.XtraEditors.LabelControl();
            lblKPI3Value = new DevExpress.XtraEditors.LabelControl();
            lblKPI3Icon = new DevExpress.XtraEditors.LabelControl();
            pnlKPICard2 = new DevExpress.XtraEditors.PanelControl();
            lblKPI2Title = new DevExpress.XtraEditors.LabelControl();
            lblKPI2Value = new DevExpress.XtraEditors.LabelControl();
            lblKPI2Icon = new DevExpress.XtraEditors.LabelControl();
            pnlKPICard1 = new DevExpress.XtraEditors.PanelControl();
            lblKPI1Title = new DevExpress.XtraEditors.LabelControl();
            lblKPI1Value = new DevExpress.XtraEditors.LabelControl();
            lblKPI1Icon = new DevExpress.XtraEditors.LabelControl();
            pnlChartsContainer = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)pnlHeader).BeginInit();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlFilters).BeginInit();
            pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbProjectFilter.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEnd.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEnd.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateStart.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateStart.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlKPIContainer).BeginInit();
            pnlKPIContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKPICard4).BeginInit();
            pnlKPICard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKPICard3).BeginInit();
            pnlKPICard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKPICard2).BeginInit();
            pnlKPICard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlKPICard1).BeginInit();
            pnlKPICard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlChartsContainer).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlHeader.Controls.Add(btnExportExcel);
            pnlHeader.Controls.Add(btnExportPdf);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnExportExcel
            // 
            btnExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportExcel.Location = new Point(960, 25);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(130, 36);
            btnExportExcel.TabIndex = 3;
            btnExportExcel.Text = "📊 Export Excel";
            // 
            // btnExportPdf
            // 
            btnExportPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportPdf.Location = new Point(830, 25);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(120, 36);
            btnExportPdf.TabIndex = 2;
            btnExportPdf.Text = "📄 Export PDF";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Appearance.Font = new Font("Segoe UI", 10F);
            lblSubtitle.Appearance.Options.UseFont = true;
            lblSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblSubtitle.Location = new Point(0, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(500, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Track performance and export reports";
            // 
            // lblTitle
            // 
            lblTitle.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Appearance.Options.UseFont = true;
            lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 Reports && Analytics";
            // 
            // pnlFilters
            // 
            pnlFilters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlFilters.Controls.Add(btnApplyFilter);
            pnlFilters.Controls.Add(cmbProjectFilter);
            pnlFilters.Controls.Add(dateEnd);
            pnlFilters.Controls.Add(lblTo);
            pnlFilters.Controls.Add(dateStart);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 80);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(15, 12, 15, 12);
            pnlFilters.Size = new Size(1100, 60);
            pnlFilters.TabIndex = 1;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new Point(590, 12);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(80, 36);
            btnApplyFilter.TabIndex = 4;
            btnApplyFilter.Text = "Apply";
            // 
            // cmbProjectFilter
            // 
            cmbProjectFilter.Location = new Point(370, 12);
            cmbProjectFilter.Name = "cmbProjectFilter";
            cmbProjectFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cmbProjectFilter.Properties.DropDownRows = 10;
            cmbProjectFilter.Properties.NullText = "All Projects";
            cmbProjectFilter.Properties.PopupSizeable = true;
            cmbProjectFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmbProjectFilter.Size = new Size(200, 20);
            cmbProjectFilter.TabIndex = 3;
            // 
            // dateEnd
            // 
            dateEnd.EditValue = null;
            dateEnd.Location = new Point(200, 12);
            dateEnd.Name = "dateEnd";
            dateEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEnd.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            dateEnd.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            dateEnd.Size = new Size(150, 20);
            dateEnd.TabIndex = 2;
            // 
            // lblTo
            // 
            lblTo.Appearance.Font = new Font("Segoe UI", 9F);
            lblTo.Appearance.Options.UseFont = true;
            lblTo.Location = new Point(175, 22);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(11, 15);
            lblTo.TabIndex = 1;
            lblTo.Text = "to";
            // 
            // dateStart
            // 
            dateStart.EditValue = null;
            dateStart.Location = new Point(15, 12);
            dateStart.Name = "dateStart";
            dateStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateStart.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            dateStart.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            dateStart.Size = new Size(150, 20);
            dateStart.TabIndex = 0;
            // 
            // pnlKPIContainer
            // 
            pnlKPIContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlKPIContainer.Controls.Add(pnlKPICard4);
            pnlKPIContainer.Controls.Add(pnlKPICard3);
            pnlKPIContainer.Controls.Add(pnlKPICard2);
            pnlKPIContainer.Controls.Add(pnlKPICard1);
            pnlKPIContainer.Dock = DockStyle.Top;
            pnlKPIContainer.Location = new Point(0, 140);
            pnlKPIContainer.Name = "pnlKPIContainer";
            pnlKPIContainer.Padding = new Padding(15, 15, 15, 0);
            pnlKPIContainer.Size = new Size(1100, 140);
            pnlKPIContainer.TabIndex = 2;
            // 
            // pnlKPICard4
            // 
            pnlKPICard4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKPICard4.Controls.Add(lblKPI4Title);
            pnlKPICard4.Controls.Add(lblKPI4Value);
            pnlKPICard4.Controls.Add(lblKPI4Icon);
            pnlKPICard4.Location = new Point(810, 15);
            pnlKPICard4.Name = "pnlKPICard4";
            pnlKPICard4.Size = new Size(250, 100);
            pnlKPICard4.TabIndex = 3;
            // 
            // lblKPI4Title
            // 
            lblKPI4Title.Appearance.Font = new Font("Segoe UI", 10F);
            lblKPI4Title.Appearance.Options.UseFont = true;
            lblKPI4Title.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI4Title.Location = new Point(15, 70);
            lblKPI4Title.Name = "lblKPI4Title";
            lblKPI4Title.Size = new Size(220, 20);
            lblKPI4Title.TabIndex = 2;
            lblKPI4Title.Text = "Avg Completion Rate";
            // 
            // lblKPI4Value
            // 
            lblKPI4Value.Appearance.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblKPI4Value.Appearance.Options.UseFont = true;
            lblKPI4Value.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI4Value.Location = new Point(70, 15);
            lblKPI4Value.Name = "lblKPI4Value";
            lblKPI4Value.Size = new Size(165, 50);
            lblKPI4Value.TabIndex = 1;
            lblKPI4Value.Text = "0%";
            // 
            // lblKPI4Icon
            // 
            lblKPI4Icon.Appearance.Font = new Font("Segoe UI", 24F);
            lblKPI4Icon.Appearance.Options.UseFont = true;
            lblKPI4Icon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI4Icon.Location = new Point(15, 15);
            lblKPI4Icon.Name = "lblKPI4Icon";
            lblKPI4Icon.Size = new Size(50, 40);
            lblKPI4Icon.TabIndex = 0;
            lblKPI4Icon.Text = "📈";
            // 
            // pnlKPICard3
            // 
            pnlKPICard3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKPICard3.Controls.Add(lblKPI3Title);
            pnlKPICard3.Controls.Add(lblKPI3Value);
            pnlKPICard3.Controls.Add(lblKPI3Icon);
            pnlKPICard3.Location = new Point(545, 15);
            pnlKPICard3.Name = "pnlKPICard3";
            pnlKPICard3.Size = new Size(250, 100);
            pnlKPICard3.TabIndex = 2;
            // 
            // lblKPI3Title
            // 
            lblKPI3Title.Appearance.Font = new Font("Segoe UI", 10F);
            lblKPI3Title.Appearance.Options.UseFont = true;
            lblKPI3Title.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI3Title.Location = new Point(15, 70);
            lblKPI3Title.Name = "lblKPI3Title";
            lblKPI3Title.Size = new Size(220, 20);
            lblKPI3Title.TabIndex = 2;
            lblKPI3Title.Text = "Team Members";
            // 
            // lblKPI3Value
            // 
            lblKPI3Value.Appearance.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblKPI3Value.Appearance.Options.UseFont = true;
            lblKPI3Value.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI3Value.Location = new Point(70, 15);
            lblKPI3Value.Name = "lblKPI3Value";
            lblKPI3Value.Size = new Size(165, 50);
            lblKPI3Value.TabIndex = 1;
            lblKPI3Value.Text = "0";
            // 
            // lblKPI3Icon
            // 
            lblKPI3Icon.Appearance.Font = new Font("Segoe UI", 24F);
            lblKPI3Icon.Appearance.Options.UseFont = true;
            lblKPI3Icon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI3Icon.Location = new Point(15, 15);
            lblKPI3Icon.Name = "lblKPI3Icon";
            lblKPI3Icon.Size = new Size(50, 40);
            lblKPI3Icon.TabIndex = 0;
            lblKPI3Icon.Text = "👥";
            // 
            // pnlKPICard2
            // 
            pnlKPICard2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKPICard2.Controls.Add(lblKPI2Title);
            pnlKPICard2.Controls.Add(lblKPI2Value);
            pnlKPICard2.Controls.Add(lblKPI2Icon);
            pnlKPICard2.Location = new Point(280, 15);
            pnlKPICard2.Name = "pnlKPICard2";
            pnlKPICard2.Size = new Size(250, 100);
            pnlKPICard2.TabIndex = 1;
            // 
            // lblKPI2Title
            // 
            lblKPI2Title.Appearance.Font = new Font("Segoe UI", 10F);
            lblKPI2Title.Appearance.Options.UseFont = true;
            lblKPI2Title.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI2Title.Location = new Point(15, 70);
            lblKPI2Title.Name = "lblKPI2Title";
            lblKPI2Title.Size = new Size(220, 20);
            lblKPI2Title.TabIndex = 2;
            lblKPI2Title.Text = "Completed Tasks";
            // 
            // lblKPI2Value
            // 
            lblKPI2Value.Appearance.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblKPI2Value.Appearance.Options.UseFont = true;
            lblKPI2Value.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI2Value.Location = new Point(70, 15);
            lblKPI2Value.Name = "lblKPI2Value";
            lblKPI2Value.Size = new Size(165, 50);
            lblKPI2Value.TabIndex = 1;
            lblKPI2Value.Text = "0";
            // 
            // lblKPI2Icon
            // 
            lblKPI2Icon.Appearance.Font = new Font("Segoe UI", 24F);
            lblKPI2Icon.Appearance.Options.UseFont = true;
            lblKPI2Icon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI2Icon.Location = new Point(15, 15);
            lblKPI2Icon.Name = "lblKPI2Icon";
            lblKPI2Icon.Size = new Size(50, 40);
            lblKPI2Icon.TabIndex = 0;
            lblKPI2Icon.Text = "✓";
            // 
            // pnlKPICard1
            // 
            pnlKPICard1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlKPICard1.Controls.Add(lblKPI1Title);
            pnlKPICard1.Controls.Add(lblKPI1Value);
            pnlKPICard1.Controls.Add(lblKPI1Icon);
            pnlKPICard1.Location = new Point(15, 15);
            pnlKPICard1.Name = "pnlKPICard1";
            pnlKPICard1.Size = new Size(250, 100);
            pnlKPICard1.TabIndex = 0;
            // 
            // lblKPI1Title
            // 
            lblKPI1Title.Appearance.Font = new Font("Segoe UI", 10F);
            lblKPI1Title.Appearance.Options.UseFont = true;
            lblKPI1Title.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI1Title.Location = new Point(15, 70);
            lblKPI1Title.Name = "lblKPI1Title";
            lblKPI1Title.Size = new Size(220, 20);
            lblKPI1Title.TabIndex = 2;
            lblKPI1Title.Text = "Active Projects";
            // 
            // lblKPI1Value
            // 
            lblKPI1Value.Appearance.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblKPI1Value.Appearance.Options.UseFont = true;
            lblKPI1Value.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI1Value.Location = new Point(70, 15);
            lblKPI1Value.Name = "lblKPI1Value";
            lblKPI1Value.Size = new Size(165, 50);
            lblKPI1Value.TabIndex = 1;
            lblKPI1Value.Text = "0";
            // 
            // lblKPI1Icon
            // 
            lblKPI1Icon.Appearance.Font = new Font("Segoe UI", 24F);
            lblKPI1Icon.Appearance.Options.UseFont = true;
            lblKPI1Icon.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblKPI1Icon.Location = new Point(15, 15);
            lblKPI1Icon.Name = "lblKPI1Icon";
            lblKPI1Icon.Size = new Size(50, 40);
            lblKPI1Icon.TabIndex = 0;
            lblKPI1Icon.Text = "📁";
            // 
            // pnlChartsContainer
            // 
            pnlChartsContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pnlChartsContainer.Dock = DockStyle.Fill;
            pnlChartsContainer.Location = new Point(0, 280);
            pnlChartsContainer.Name = "pnlChartsContainer";
            pnlChartsContainer.Size = new Size(1100, 450);
            pnlChartsContainer.TabIndex = 3;
            // 
            // ReportsContent
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(pnlChartsContainer);
            Controls.Add(pnlKPIContainer);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "ReportsContent";
            Size = new Size(1100, 730);
            ((System.ComponentModel.ISupportInitialize)pnlHeader).EndInit();
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlFilters).EndInit();
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbProjectFilter.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEnd.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEnd.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateStart.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateStart.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlKPIContainer).EndInit();
            pnlKPIContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKPICard4).EndInit();
            pnlKPICard4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKPICard3).EndInit();
            pnlKPICard3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKPICard2).EndInit();
            pnlKPICard2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlKPICard1).EndInit();
            pnlKPICard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlChartsContainer).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtitle;
        private DevExpress.XtraEditors.SimpleButton btnExportPdf;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.PanelControl pnlFilters;
        private DevExpress.XtraEditors.DateEdit dateStart;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.DateEdit dateEnd;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProjectFilter;
        private DevExpress.XtraEditors.SimpleButton btnApplyFilter;
        private DevExpress.XtraEditors.PanelControl pnlKPIContainer;
        private DevExpress.XtraEditors.PanelControl pnlKPICard1;
        private DevExpress.XtraEditors.LabelControl lblKPI1Icon;
        private DevExpress.XtraEditors.LabelControl lblKPI1Value;
        private DevExpress.XtraEditors.LabelControl lblKPI1Title;
        private DevExpress.XtraEditors.PanelControl pnlKPICard2;
        private DevExpress.XtraEditors.LabelControl lblKPI2Title;
        private DevExpress.XtraEditors.LabelControl lblKPI2Value;
        private DevExpress.XtraEditors.LabelControl lblKPI2Icon;
        private DevExpress.XtraEditors.PanelControl pnlKPICard3;
        private DevExpress.XtraEditors.LabelControl lblKPI3Title;
        private DevExpress.XtraEditors.LabelControl lblKPI3Value;
        private DevExpress.XtraEditors.LabelControl lblKPI3Icon;
        private DevExpress.XtraEditors.PanelControl pnlKPICard4;
        private DevExpress.XtraEditors.LabelControl lblKPI4Title;
        private DevExpress.XtraEditors.LabelControl lblKPI4Value;
        private DevExpress.XtraEditors.LabelControl lblKPI4Icon;
        private DevExpress.XtraEditors.PanelControl pnlChartsContainer;
    }
}
