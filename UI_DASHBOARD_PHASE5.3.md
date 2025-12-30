# 📁 PHASE 5.3: TEAM INVITATION SYSTEM

**InvitationsContent.ascx - Email Invitation & Management**

**Süre:** 4-5 saat  
**Zorluk:** İleri Düzey

---

## 🎯 BU PHASE'DE NE YAPACAĞIZ?

```
✅ InvitationsContent.ascx - Davet yönetimi
✅ Email ile davet gönderme
✅ Pending invitations listesi
✅ Resend/Cancel invitation
✅ Invitation acceptance (public link)
✅ Token-based security
✅ Email service integration
```

---

## 🎨 TASARIM DETAYLARI

### **Invitations Layout:**

```
┌──────────────────────────────────────────────────────────────────┐
│ 📧 Team Invitations                       [Send Invitation]      │
│ Manage pending and sent invitations                              │
├──────────────────────────────────────────────────────────────────┤
│                                                                   │
│  ┌────────────────────── SEND NEW INVITATION ──────────────────┐ │
│  │                                                              │ │
│  │  Email Address *                    Role *                  │ │
│  │  ┌──────────────────────────┐  ┌───────────────────────┐   │ │
│  │  │ user@example.com         │  │ Developer         ▾   │   │ │
│  │  └──────────────────────────┘  └───────────────────────┘   │ │
│  │                                                [Send ✉️]     │ │
│  └──────────────────────────────────────────────────────────────┘ │
│                                                                   │
│  ┌────────────────────── PENDING INVITATIONS ────────────────┐   │
│  │                                                            │   │
│  │  ╔════════════════════════════════════════════════════╗   │   │
│  │  ║ 📧 john.doe@company.com                            ║   │   │
│  │  ║ Role: Developer                                    ║   │   │
│  │  ║ Sent: 2 days ago • Expires: in 5 days             ║   │   │
│  │  ║ Status: 🟡 Pending                                  ║   │   │
│  │  ║ Invited by: Sarah Miller                          ║   │   │
│  │  ║ [📋 Copy Link] [🔄 Resend] [❌ Cancel]             ║   │   │
│  │  ╚════════════════════════════════════════════════════╝   │   │
│  │                                                            │   │
│  │  ╔════════════════════════════════════════════════════╗   │   │
│  │  ║ 📧 jane.smith@company.com                          ║   │   │
│  │  ║ Role: Project Manager                              ║   │   │
│  │  ║ Sent: 1 week ago • Expired                         ║   │   │
│  │  ║ Status: ⏱️ Expired                                   ║   │   │
│  │  ║ [🔄 Resend] [❌ Cancel]                             ║   │   │
│  │  ╚════════════════════════════════════════════════════╝   │   │
│  │                                                            │   │
│  └────────────────────────────────────────────────────────────┘   │
│                                                                   │
│ Showing 2 pending invitations                     [🔄 Refresh]  │
└──────────────────────────────────────────────────────────────────┘
```

### **Color Scheme:**

| Status | Color | Hex |
|--------|-------|-----|
| Pending | `#FFB800` (Yellow) | 255, 184, 0 |
| Accepted | `#00D084` (Green) | 0, 208, 132 |
| Declined | `#FF4D4D` (Red) | 255, 77, 77 |
| Expired | `#A1A1A1` (Gray) | 161, 161, 161 |

---

## 🚀 ADIM 1: UserControl Oluştur

```
Forms/Dashboard/Content → Add → User Control
İsim: InvitationsContent.cs
```

### **Properties:**

| Property | Değer |
|----------|-------|
| **Size** | `1100, 730` |
| **BackColor** | `11, 11, 11` |

---

## 🎨 ADIM 2: Header

### **2.1 Header Panel**

| Property | Değer |
|----------|-------|
| **(Name)** | `pnlHeader` |
| **Dock** | `Top` |
| **Height** | `80` |

### **2.2 Title Label**

| Property | Değer |
|----------|-------|
| **(Name)** | `lblTitle` |
| **Text** | `📧 Team Invitations` |
| **Location** | `0, 10` |
| **Font** | `Segoe UI, 18pt, Bold` |

### **2.3 Send Button**

| Property | Değer |
|----------|-------|
| **(Name)** | `btnSendInvitation` |
| **Text** | `Send Invitation` |
| **Location** | `950, 25` |
| **Size** | `140, 36` |
| **Appearance.BackColor** | `255, 77, 0` |

---

## 📧 ADIM 3: Send Invitation Form

### **3.1 Form Panel**

| Property | Değer |
|----------|-------|
| **(Name)** | `pnlSendForm` |
| **Location** | `50, 100` |
| **Size** | `1000, 120` |
| **Appearance.BackColor** | `21, 21, 21` |

### **3.2 Email Input**

**Label:**

| Property | Değer |
|----------|-------|
| **(Name)** | `lblEmail` |
| **Text** | `Email Address *` |
| **Location** | `20, 20` |

**TextEdit:**

| Property | Değer |
|----------|-------|
| **(Name)** | `txtEmail` |
| **Location** | `20, 45` |
| **Size** | `450, 30` |
| **Properties.NullText** | `user@example.com` |
| **Properties.Appearance.BackColor** | `26, 26, 26` |

### **3.3 Role Selector**

**Label:**

| Property | Değer |
|----------|-------|
| **(Name)** | `lblRole` |
| **Text** | `Role *` |
| **Location** | `490, 20` |

**ComboBoxEdit:**

| Property | Değer |
|----------|-------|
| **(Name)** | `cmbRole` |
| **Location** | `490, 45` |
| **Size** | `300, 30` |
| **Properties.Items** | `Admin, Project Manager, Developer, Observer` |

### **3.4 Send Button (in form)**

| Property | Değer |
|----------|-------|
| **(Name)** | `btnSend` |
| **Text** | `Send ✉️` |
| **Location** | `810, 45` |
| **Size** | `170, 30` |
| **Appearance.BackColor** | `255, 77, 0` |

---

## 📋 ADIM 4: Invitations List

### **4.1 List Container**

| Property | Değer |
|----------|-------|
| **(Name)** | `pnlInvitationsList` |
| **Location** | `50, 240` |
| **Size** | `1000, 420` |
| **AutoScroll** | `True` |

### **4.2 Flow Layout**

| Property | Değer |
|----------|-------|
| **(Name)** | `flowInvitations` |
| **Dock** | `Fill` |
| **FlowDirection** | `TopDown` |
| **WrapContents** | `False` |

💡 **Not:** Invitation kartları kod ile dinamik oluşturulacak.

---

## 💻 ADIM 5: Code-Behind

```csharp
using DevExpress.XtraEditors;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    public partial class InvitationsContent : UserControl
    {
        #region Fields
        
        private readonly IInvitationService _invitationService;
        private readonly ITeamService _teamService;
        private List<TeamInvitationDto> _invitations;
        
        #endregion
        
        #region Constructor
        
        public InvitationsContent(IInvitationService invitationService, ITeamService teamService)
        {
            InitializeComponent();
            _invitationService = invitationService;
            _teamService = teamService;
            
            LoadRoles();
            LoadInvitationsAsync();
            SetupEventHandlers();
        }
        
        public InvitationsContent()
        {
            InitializeComponent();
        }
        
        #endregion
        
        #region Setup
        
        private void LoadRoles()
        {
            cmbRole.Properties.Items.Clear();
            cmbRole.Properties.Items.AddRange(new object[] {
                "Admin", "Project Manager", "Developer", "Observer"
            });
            cmbRole.SelectedIndex = 2; // Developer
        }
        
        private void SetupEventHandlers()
        {
            btnSend.Click += BtnSend_Click;
            btnSendInvitation.Click += (s, e) => txtEmail.Focus();
        }
        
        #endregion
        
        #region Data Loading
        
        private async void LoadInvitationsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                
                var activeTeam = await _teamService.GetActiveTeamAsync();
                if (activeTeam == null)
                {
                    XtraMessageBox.Show("No active team selected", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                _invitations = (await _invitationService.GetTeamInvitationsAsync(activeTeam.TeamId)).ToList();
                RenderInvitations();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading invitations: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        #endregion
        
        #region Rendering
        
        private void RenderInvitations()
        {
            flowInvitations.Controls.Clear();
            
            var pendingInvitations = _invitations
                .Where(i => i.Status == Core.Enums.InvitationStatus.Pending || i.IsExpired)
                .ToList();
            
            foreach (var invitation in pendingInvitations)
            {
                var card = CreateInvitationCard(invitation);
                flowInvitations.Controls.Add(card);
            }
            
            lblRecordCount.Text = $"Showing {pendingInvitations.Count} pending invitations";
        }
        
        private PanelControl CreateInvitationCard(TeamInvitationDto invitation)
        {
            var card = new PanelControl
            {
                Width = 980,
                Height = 140,
                BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple,
                Margin = new Padding(0, 0, 0, 15)
            };
            card.Appearance.BackColor = Color.FromArgb(21, 21, 21);
            card.Appearance.BorderColor = Color.FromArgb(42, 42, 42);
            
            // Email
            var lblEmail = new LabelControl
            {
                Text = $"📧 {invitation.Email}",
                Location = new Point(15, 15),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(950, 24)
            };
            lblEmail.Appearance.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblEmail.Appearance.ForeColor = Color.White;
            card.Controls.Add(lblEmail);
            
            // Role
            var lblRole = new LabelControl
            {
                Text = $"Role: {invitation.ProposedRole}",
                Location = new Point(15, 45),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(950, 20)
            };
            lblRole.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            card.Controls.Add(lblRole);
            
            // Sent & Expiry
            var daysAgo = (DateTime.Now - invitation.SentAt).Days;
            var expiryInfo = invitation.IsExpired 
                ? "Expired" 
                : $"Expires in {(invitation.ExpiresAt - DateTime.Now).Days} days";
            
            var lblTime = new LabelControl
            {
                Text = $"Sent: {daysAgo} days ago • {expiryInfo}",
                Location = new Point(15, 70),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(950, 20)
            };
            lblTime.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            card.Controls.Add(lblTime);
            
            // Status badge
            var (statusText, statusColor) = GetStatusDisplay(invitation);
            var lblStatus = new LabelControl
            {
                Text = statusText,
                Location = new Point(15, 95),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(200, 20)
            };
            lblStatus.Appearance.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblStatus.Appearance.ForeColor = statusColor;
            card.Controls.Add(lblStatus);
            
            // Invited by
            var lblInvitedBy = new LabelControl
            {
                Text = $"Invited by: {invitation.InvitedByName}",
                Location = new Point(230, 95),
                AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None,
                Size = new Size(300, 20)
            };
            lblInvitedBy.Appearance.ForeColor = Color.FromArgb(161, 161, 161);
            card.Controls.Add(lblInvitedBy);
            
            // Action buttons
            int buttonX = 550;
            
            // Copy Link
            if (!invitation.IsExpired)
            {
                var btnCopy = new SimpleButton
                {
                    Text = "📋 Copy Link",
                    Location = new Point(buttonX, 90),
                    Size = new Size(120, 28)
                };
                btnCopy.Appearance.BackColor = Color.FromArgb(42, 42, 42);
                btnCopy.Click += (s, e) => CopyInvitationLink(invitation.Token);
                card.Controls.Add(btnCopy);
                buttonX += 130;
            }
            
            // Resend
            var btnResend = new SimpleButton
            {
                Text = "🔄 Resend",
                Location = new Point(buttonX, 90),
                Size = new Size(100, 28)
            };
            btnResend.Appearance.BackColor = Color.FromArgb(255, 77, 0);
            btnResend.Click += async (s, e) => await ResendInvitation(invitation.InvitationId);
            card.Controls.Add(btnResend);
            buttonX += 110;
            
            // Cancel
            var btnCancel = new SimpleButton
            {
                Text = "❌ Cancel",
                Location = new Point(buttonX, 90),
                Size = new Size(100, 28)
            };
            btnCancel.Appearance.BackColor = Color.FromArgb(255, 77, 77);
            btnCancel.Click += async (s, e) => await CancelInvitation(invitation.InvitationId);
            card.Controls.Add(btnCancel);
            
            return card;
        }
        
        private (string text, Color color) GetStatusDisplay(TeamInvitationDto invitation)
        {
            if (invitation.IsExpired)
                return ("⏱️ Expired", Color.FromArgb(161, 161, 161));
            
            return invitation.Status switch
            {
                Core.Enums.InvitationStatus.Pending => ("🟡 Pending", Color.FromArgb(255, 184, 0)),
                Core.Enums.InvitationStatus.Accepted => ("✅ Accepted", Color.FromArgb(0, 208, 132)),
                Core.Enums.InvitationStatus.Declined => ("❌ Declined", Color.FromArgb(255, 77, 77)),
                _ => ("❓ Unknown", Color.Gray)
            };
        }
        
        #endregion
        
        #region Actions
        
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            if (!ValidateInvitation())
                return;
            
            try
            {
                Cursor = Cursors.WaitCursor;
                
                var activeTeam = await _teamService.GetActiveTeamAsync();
                var invitationDto = new TeamInvitationDto
                {
                    TeamId = activeTeam.TeamId,
                    Email = txtEmail.Text.Trim(),
                    ProposedRole = (Core.Enums.TeamRole)Enum.Parse(typeof(Core.Enums.TeamRole), cmbRole.Text.Replace(" ", ""))
                };
                
                await _invitationService.SendInvitationAsync(invitationDto);
                
                XtraMessageBox.Show($"Invitation sent to {invitationDto.Email}!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txtEmail.Text = string.Empty;
                LoadInvitationsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error sending invitation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        private void CopyInvitationLink(string token)
        {
            var link = $"https://yourapp.com/accept-invitation?token={token}";
            Clipboard.SetText(link);
            XtraMessageBox.Show("Invitation link copied to clipboard!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private async Task ResendInvitation(int invitationId)
        {
            try
            {
                await _invitationService.ResendInvitationAsync(invitationId);
                XtraMessageBox.Show("Invitation resent successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvitationsAsync();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error resending invitation: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async Task CancelInvitation(int invitationId)
        {
            var result = XtraMessageBox.Show("Cancel this invitation?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    await _invitationService.CancelInvitationAsync(invitationId);
                    XtraMessageBox.Show("Invitation cancelled", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInvitationsAsync();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private bool ValidateInvitation()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                XtraMessageBox.Show("Email is required", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (!txtEmail.Text.Contains("@"))
            {
                XtraMessageBox.Show("Invalid email format", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }
        
        #endregion
    }
}
```

---

## ✅ TEST  

1. [ ] Email davet gönderme çalışıyor mu?
2. [ ] Invitation list yükleniyor mu?
3. [ ] Copy link çalışıyor mu?
4. [ ] Resend çalışıyor mu?
5. [ ] Cancel çalışıyor mu?
6. [ ] Status renkleri doğru mu?

---

**Hazırlayan:** AI Assistant  
**Tarih:** 29 Aralık 2024  
**Phase:** 5.3 - Team Invitation System
