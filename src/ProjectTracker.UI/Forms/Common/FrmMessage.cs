using DevExpress.XtraEditors;
using ProjectTracker.UI.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Common
{
    /// <summary>
    /// Custom dark-themed message box form
    /// </summary>
    public partial class FrmMessage : XtraForm
    {
        private DialogResult _result = DialogResult.None;
        
        public FrmMessage()
        {
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(380, 160);
            this.BackColor = ColorPalette.BackgroundSlateDark;
            this.ShowInTaskbar = false;
            this.KeyPreview = true;
            this.KeyDown += FrmMessage_KeyDown;
            
            this.ResumeLayout(false);
        }
        
        private void FrmMessage_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _result = DialogResult.Cancel;
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                _result = DialogResult.OK;
                this.Close();
            }
        }
        
        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, FormStyleHelper.MessageType type)
        {
            using (var form = new FrmMessage())
            {
                form.BuildUI(message, title, buttons, type);
                form.ShowDialog();
                return form._result;
            }
        }
        
        private void BuildUI(string message, string title, MessageBoxButtons buttons, FormStyleHelper.MessageType type)
        {
            this.Controls.Clear();
            
            var iconColor = FormStyleHelper.GetMessageColor(type);
            
            // Left accent bar
            var accentBar = new Panel
            {
                Width = 4,
                Dock = DockStyle.Left,
                BackColor = iconColor
            };
            this.Controls.Add(accentBar);
            
            // Title
            var lblTitle = new LabelControl
            {
                Text = title,
                Location = new Point(20, 15),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(340, 22)
            };
            lblTitle.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Appearance.ForeColor = ColorPalette.TextPrimary;
            this.Controls.Add(lblTitle);
            
            // Message
            var lblMessage = new LabelControl
            {
                Text = message,
                Location = new Point(20, 45),
                AutoSizeMode = LabelAutoSizeMode.None,
                Size = new Size(340, 55)
            };
            lblMessage.Appearance.Font = new Font("Segoe UI", 9.5F);
            lblMessage.Appearance.ForeColor = ColorPalette.TextSecondary;
            lblMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.Controls.Add(lblMessage);
            
            // Buttons
            CreateButtons(buttons, type);
            
            // Border
            this.Paint += (s, e) =>
            {
                using (var pen = new Pen(ColorPalette.BorderSlate, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
                }
            };
        }
        
        private void CreateButtons(MessageBoxButtons buttons, FormStyleHelper.MessageType type)
        {
            int btnWidth = 80;
            int btnHeight = 32;
            int spacing = 10;
            int y = 115;
            int x = this.Width - 15;
            
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    x -= btnWidth;
                    AddButton("OK", x, y, btnWidth, btnHeight, true, type, DialogResult.OK);
                    break;
                    
                case MessageBoxButtons.OKCancel:
                    x -= btnWidth;
                    AddButton("Cancel", x, y, btnWidth, btnHeight, false, type, DialogResult.Cancel);
                    x -= btnWidth + spacing;
                    AddButton("OK", x, y, btnWidth, btnHeight, true, type, DialogResult.OK);
                    break;
                    
                case MessageBoxButtons.YesNo:
                    x -= btnWidth;
                    AddButton("No", x, y, btnWidth, btnHeight, false, type, DialogResult.No);
                    x -= btnWidth + spacing;
                    AddButton("Yes", x, y, btnWidth, btnHeight, true, type, DialogResult.Yes);
                    break;
                    
                case MessageBoxButtons.YesNoCancel:
                    x -= btnWidth;
                    AddButton("Cancel", x, y, btnWidth, btnHeight, false, type, DialogResult.Cancel);
                    x -= btnWidth + spacing;
                    AddButton("No", x, y, btnWidth, btnHeight, false, type, DialogResult.No);
                    x -= btnWidth + spacing;
                    AddButton("Yes", x, y, btnWidth, btnHeight, true, type, DialogResult.Yes);
                    break;
            }
        }
        
        private void AddButton(string text, int x, int y, int width, int height, bool isPrimary, FormStyleHelper.MessageType type, DialogResult result)
        {
            var btn = new SimpleButton
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Cursor = Cursors.Hand
            };
            
            if (isPrimary)
            {
                var color = FormStyleHelper.GetMessageColor(type);
                btn.Appearance.BackColor = color;
                btn.Appearance.BorderColor = color;
                btn.Appearance.ForeColor = Color.White;
            }
            else
            {
                btn.Appearance.BackColor = ColorPalette.BorderSlate;
                btn.Appearance.BorderColor = ColorPalette.BorderSlate;
                btn.Appearance.ForeColor = ColorPalette.TextSecondary;
            }
            
            btn.Appearance.Font = new Font("Segoe UI", 9F);
            btn.Appearance.Options.UseBackColor = true;
            btn.Appearance.Options.UseBorderColor = true;
            btn.Appearance.Options.UseForeColor = true;
            btn.Appearance.Options.UseFont = true;
            
            btn.Click += (s, e) => { _result = result; this.Close(); };
            this.Controls.Add(btn);
        }
    }
}
