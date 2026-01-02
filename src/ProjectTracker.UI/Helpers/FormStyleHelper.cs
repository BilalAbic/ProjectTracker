using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProjectTracker.UI.Forms.Common;

namespace ProjectTracker.UI.Helpers
{
    /// <summary>
    /// Helper class for applying consistent modern dark theme styling to form controls
    /// </summary>
    public static class FormStyleHelper
    {
        #region Color Constants
        
        // Background colors
        public static readonly Color FormBackground = Color.FromArgb(26, 31, 38);      // #1A1F26
        public static readonly Color PanelBackground = Color.FromArgb(36, 43, 61);     // #242B3D
        public static readonly Color InputBackground = Color.FromArgb(30, 42, 58);     // #1E2A3A
        public static readonly Color InputBorder = Color.FromArgb(51, 65, 85);         // #334155
        
        // Text colors
        public static readonly Color TextWhite = Color.FromArgb(248, 250, 252);        // #F8FAFC
        public static readonly Color TextLabel = Color.FromArgb(203, 213, 225);        // #CBD5E1
        public static readonly Color TextPlaceholder = Color.FromArgb(148, 163, 184);  // #94A3B8
        
        // Button colors
        public static readonly Color ButtonPrimary = Color.FromArgb(91, 141, 239);     // #5B8DEF
        public static readonly Color ButtonSecondary = Color.FromArgb(51, 65, 85);     // #334155
        public static readonly Color ButtonDanger = Color.FromArgb(239, 68, 68);       // #EF4444
        
        // Accent
        public static readonly Color AccentBlue = Color.FromArgb(91, 141, 239);        // #5B8DEF
        
        // Message colors (from ColorPalette)
        public static readonly Color SuccessGreen = Color.FromArgb(16, 185, 129);      // #10B981
        public static readonly Color WarningOrange = Color.FromArgb(249, 115, 22);     // #F97316
        public static readonly Color InfoBlue = Color.FromArgb(91, 141, 239);          // #5B8DEF
        public static readonly Color ErrorRed = Color.FromArgb(239, 68, 68);           // #EF4444
        
        #endregion

        #region TextEdit Styling
        
        /// <summary>
        /// Apply modern dark theme to TextEdit control
        /// </summary>
        public static void ApplyTextEditStyle(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.BackColor = InputBackground;
            textEdit.Properties.Appearance.BorderColor = InputBorder;
            textEdit.Properties.Appearance.ForeColor = TextWhite;
            textEdit.Properties.Appearance.Options.UseBackColor = true;
            textEdit.Properties.Appearance.Options.UseBorderColor = true;
            textEdit.Properties.Appearance.Options.UseForeColor = true;
            textEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        }

        /// <summary>
        /// Apply modern dark theme to MemoEdit control
        /// </summary>
        public static void ApplyMemoEditStyle(MemoEdit memoEdit)
        {
            memoEdit.Properties.Appearance.BackColor = InputBackground;
            memoEdit.Properties.Appearance.BorderColor = InputBorder;
            memoEdit.Properties.Appearance.ForeColor = TextWhite;
            memoEdit.Properties.Appearance.Options.UseBackColor = true;
            memoEdit.Properties.Appearance.Options.UseBorderColor = true;
            memoEdit.Properties.Appearance.Options.UseForeColor = true;
            memoEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        }

        #endregion

        #region ComboBox/LookUpEdit Styling

        /// <summary>
        /// Apply modern dark theme to ComboBoxEdit control
        /// </summary>
        public static void ApplyComboBoxStyle(ComboBoxEdit comboBox)
        {
            comboBox.Properties.Appearance.BackColor = InputBackground;
            comboBox.Properties.Appearance.BorderColor = InputBorder;
            comboBox.Properties.Appearance.ForeColor = TextWhite;
            comboBox.Properties.Appearance.Options.UseBackColor = true;
            comboBox.Properties.Appearance.Options.UseBorderColor = true;
            comboBox.Properties.Appearance.Options.UseForeColor = true;
            comboBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        }

        /// <summary>
        /// Apply modern dark theme to LookUpEdit control
        /// </summary>
        public static void ApplyLookUpEditStyle(LookUpEdit lookUpEdit)
        {
            lookUpEdit.Properties.Appearance.BackColor = InputBackground;
            lookUpEdit.Properties.Appearance.BorderColor = InputBorder;
            lookUpEdit.Properties.Appearance.ForeColor = TextWhite;
            lookUpEdit.Properties.Appearance.Options.UseBackColor = true;
            lookUpEdit.Properties.Appearance.Options.UseBorderColor = true;
            lookUpEdit.Properties.Appearance.Options.UseForeColor = true;
            lookUpEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        }

        #endregion

        #region DateEdit Styling

        /// <summary>
        /// Apply modern dark theme to DateEdit control
        /// </summary>
        public static void ApplyDateEditStyle(DateEdit dateEdit)
        {
            dateEdit.Properties.Appearance.BackColor = InputBackground;
            dateEdit.Properties.Appearance.BorderColor = InputBorder;
            dateEdit.Properties.Appearance.ForeColor = TextWhite;
            dateEdit.Properties.Appearance.Options.UseBackColor = true;
            dateEdit.Properties.Appearance.Options.UseBorderColor = true;
            dateEdit.Properties.Appearance.Options.UseForeColor = true;
            dateEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        }

        #endregion

        #region SpinEdit Styling

        /// <summary>
        /// Apply modern dark theme to SpinEdit control
        /// </summary>
        public static void ApplySpinEditStyle(SpinEdit spinEdit)
        {
            spinEdit.Properties.Appearance.BackColor = InputBackground;
            spinEdit.Properties.Appearance.BorderColor = InputBorder;
            spinEdit.Properties.Appearance.ForeColor = TextWhite;
            spinEdit.Properties.Appearance.Options.UseBackColor = true;
            spinEdit.Properties.Appearance.Options.UseBorderColor = true;
            spinEdit.Properties.Appearance.Options.UseForeColor = true;
            spinEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        }

        #endregion

        #region Button Styling

        /// <summary>
        /// Apply primary button style (blue accent)
        /// </summary>
        public static void ApplyPrimaryButtonStyle(SimpleButton button)
        {
            button.Appearance.BackColor = ButtonPrimary;
            button.Appearance.BorderColor = ButtonPrimary;
            button.Appearance.ForeColor = TextWhite;
            button.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseBorderColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseFont = true;
        }

        /// <summary>
        /// Apply secondary button style (slate gray)
        /// </summary>
        public static void ApplySecondaryButtonStyle(SimpleButton button)
        {
            button.Appearance.BackColor = ButtonSecondary;
            button.Appearance.BorderColor = ButtonSecondary;
            button.Appearance.ForeColor = TextLabel;
            button.Appearance.Font = new Font("Segoe UI", 9.75F);
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseBorderColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseFont = true;
        }

        /// <summary>
        /// Apply danger button style (red)
        /// </summary>
        public static void ApplyDangerButtonStyle(SimpleButton button)
        {
            button.Appearance.BackColor = ButtonDanger;
            button.Appearance.BorderColor = ButtonDanger;
            button.Appearance.ForeColor = TextWhite;
            button.Appearance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseBorderColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseFont = true;
        }

        #endregion

        #region Label Styling

        /// <summary>
        /// Apply label style for form field labels
        /// </summary>
        public static void ApplyLabelStyle(LabelControl label)
        {
            label.Appearance.ForeColor = TextLabel;
            label.Appearance.Font = new Font("Segoe UI", 9F);
            label.Appearance.Options.UseForeColor = true;
            label.Appearance.Options.UseFont = true;
        }

        /// <summary>
        /// Apply title style for section headers
        /// </summary>
        public static void ApplyTitleStyle(LabelControl label)
        {
            label.Appearance.ForeColor = TextWhite;
            label.Appearance.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label.Appearance.Options.UseForeColor = true;
            label.Appearance.Options.UseFont = true;
        }

        /// <summary>
        /// Apply subtitle style
        /// </summary>
        public static void ApplySubtitleStyle(LabelControl label)
        {
            label.Appearance.ForeColor = TextLabel;
            label.Appearance.Font = new Font("Segoe UI", 9.75F);
            label.Appearance.Options.UseForeColor = true;
            label.Appearance.Options.UseFont = true;
        }

        #endregion

        #region Panel/GroupControl Styling

        /// <summary>
        /// Apply header panel style
        /// </summary>
        public static void ApplyHeaderPanelStyle(PanelControl panel)
        {
            panel.Appearance.BackColor = FormBackground;
            panel.Appearance.Options.UseBackColor = true;
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }

        /// <summary>
        /// Apply form panel style
        /// </summary>
        public static void ApplyFormPanelStyle(PanelControl panel)
        {
            panel.Appearance.BackColor = PanelBackground;
            panel.Appearance.Options.UseBackColor = true;
            panel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
        }

        /// <summary>
        /// Apply group control style
        /// </summary>
        public static void ApplyGroupControlStyle(GroupControl groupControl)
        {
            groupControl.Appearance.BackColor = FormBackground;
            groupControl.Appearance.Options.UseBackColor = true;
            groupControl.AppearanceCaption.ForeColor = AccentBlue;
            groupControl.AppearanceCaption.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupControl.AppearanceCaption.Options.UseForeColor = true;
            groupControl.AppearanceCaption.Options.UseFont = true;
            groupControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        }

        #endregion

        #region Message Box Methods

        /// <summary>
        /// Mesaj türleri
        /// </summary>
        public enum MessageType
        {
            Success,
            Warning,
            Error,
            Info,
            Question
        }

        /// <summary>
        /// Shows a success message
        /// </summary>
        public static void ShowSuccess(string message, string title = "Success")
        {
            FrmMessage.Show(message, title, MessageBoxButtons.OK, MessageType.Success);
        }

        /// <summary>
        /// Shows a warning message
        /// </summary>
        public static void ShowWarning(string message, string title = "Warning")
        {
            FrmMessage.Show(message, title, MessageBoxButtons.OK, MessageType.Warning);
        }

        /// <summary>
        /// Shows an error message
        /// </summary>
        public static void ShowError(string message, string title = "Error")
        {
            FrmMessage.Show(message, title, MessageBoxButtons.OK, MessageType.Error);
        }

        /// <summary>
        /// Shows an info message
        /// </summary>
        public static void ShowInfo(string message, string title = "Information")
        {
            FrmMessage.Show(message, title, MessageBoxButtons.OK, MessageType.Info);
        }

        /// <summary>
        /// Shows a confirmation question (Yes/No)
        /// </summary>
        public static bool ShowQuestion(string message, string title = "Confirm")
        {
            var result = FrmMessage.Show(message, title, MessageBoxButtons.YesNo, MessageType.Question);
            return result == DialogResult.Yes;
        }

        /// <summary>
        /// Shows a confirmation question (Yes/No/Cancel)
        /// </summary>
        public static DialogResult ShowQuestionWithCancel(string message, string title = "Confirm")
        {
            return FrmMessage.Show(message, title, MessageBoxButtons.YesNoCancel, MessageType.Question);
        }

        /// <summary>
        /// Shows a delete confirmation dialog
        /// </summary>
        public static bool ShowDeleteConfirmation(string itemName = "this item")
        {
            return ShowQuestion(
                $"Are you sure you want to delete {itemName}?\nThis action cannot be undone.",
                "Delete Confirmation");
        }

        /// <summary>
        /// Shows a save confirmation dialog
        /// </summary>
        public static DialogResult ShowSaveConfirmation(string itemName = "changes")
        {
            return ShowQuestionWithCancel(
                $"You have unsaved {itemName}. Do you want to save?",
                "Save");
        }

        /// <summary>
        /// Mesaj türüne göre renk döndürür
        /// </summary>
        public static Color GetMessageColor(MessageType type)
        {
            return type switch
            {
                MessageType.Success => SuccessGreen,
                MessageType.Warning => WarningOrange,
                MessageType.Error => ErrorRed,
                MessageType.Info => InfoBlue,
                MessageType.Question => InfoBlue,
                _ => TextWhite
            };
        }

        /// <summary>
        /// Mesaj türüne göre ikon döndürür
        /// </summary>
        public static MessageBoxIcon GetMessageIcon(MessageType type)
        {
            return type switch
            {
                MessageType.Success => MessageBoxIcon.Information,
                MessageType.Warning => MessageBoxIcon.Warning,
                MessageType.Error => MessageBoxIcon.Error,
                MessageType.Info => MessageBoxIcon.Information,
                MessageType.Question => MessageBoxIcon.Question,
                _ => MessageBoxIcon.None
            };
        }

        #endregion

        #region Inline Message Panel

        /// <summary>
        /// Form içi mesaj paneli oluşturur (toast benzeri)
        /// </summary>
        public static PanelControl CreateMessagePanel(Control parent, string message, MessageType type)
        {
            var panel = new PanelControl
            {
                Height = 45,
                Dock = DockStyle.Top,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            };

            var accentColor = GetMessageColor(type);
            panel.Appearance.BackColor = Color.FromArgb(40, accentColor.R, accentColor.G, accentColor.B);
            panel.Appearance.Options.UseBackColor = true;

            // Sol kenar accent çizgisi
            var accentBar = new PanelControl
            {
                Width = 4,
                Dock = DockStyle.Left,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            };
            accentBar.Appearance.BackColor = accentColor;
            accentBar.Appearance.Options.UseBackColor = true;

            // Mesaj label
            var label = new LabelControl
            {
                Text = message,
                AutoSizeMode = LabelAutoSizeMode.None,
                Dock = DockStyle.Fill,
                Padding = new Padding(12, 0, 0, 0)
            };
            label.Appearance.ForeColor = TextWhite;
            label.Appearance.Font = new Font("Segoe UI", 9.75F);
            label.Appearance.Options.UseForeColor = true;
            label.Appearance.Options.UseFont = true;
            label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

            // Kapatma butonu
            var closeButton = new SimpleButton
            {
                Text = "✕",
                Width = 30,
                Dock = DockStyle.Right,
                Cursor = Cursors.Hand
            };
            closeButton.Appearance.BackColor = Color.Transparent;
            closeButton.Appearance.BorderColor = Color.Transparent;
            closeButton.Appearance.ForeColor = TextLabel;
            closeButton.Appearance.Options.UseBackColor = true;
            closeButton.Appearance.Options.UseBorderColor = true;
            closeButton.Appearance.Options.UseForeColor = true;
            closeButton.Click += (s, e) =>
            {
                panel.Visible = false;
                parent.Controls.Remove(panel);
                panel.Dispose();
            };

            panel.Controls.Add(label);
            panel.Controls.Add(accentBar);
            panel.Controls.Add(closeButton);

            return panel;
        }

        /// <summary>
        /// Form içi başarı mesajı gösterir
        /// </summary>
        public static void ShowInlineSuccess(Control parent, string message)
        {
            var panel = CreateMessagePanel(parent, message, MessageType.Success);
            parent.Controls.Add(panel);
            panel.BringToFront();
        }

        /// <summary>
        /// Form içi hata mesajı gösterir
        /// </summary>
        public static void ShowInlineError(Control parent, string message)
        {
            var panel = CreateMessagePanel(parent, message, MessageType.Error);
            parent.Controls.Add(panel);
            panel.BringToFront();
        }

        /// <summary>
        /// Form içi uyarı mesajı gösterir
        /// </summary>
        public static void ShowInlineWarning(Control parent, string message)
        {
            var panel = CreateMessagePanel(parent, message, MessageType.Warning);
            parent.Controls.Add(panel);
            panel.BringToFront();
        }

        /// <summary>
        /// Form içi bilgi mesajı gösterir
        /// </summary>
        public static void ShowInlineInfo(Control parent, string message)
        {
            var panel = CreateMessagePanel(parent, message, MessageType.Info);
            parent.Controls.Add(panel);
            panel.BringToFront();
        }

        #endregion
    }
}
