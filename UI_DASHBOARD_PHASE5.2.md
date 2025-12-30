# 📁 PHASE 5.2: TEAM CREATION & SETTINGS

**TeamDetailControl.ascx - Team Creation & Management Form**

**Süre:** 3-4 saat  
**Zorluk:** İleri Düzey

---

## 🎯 BU PHASE'DE NE YAPACAĞIZ?

```
✅ TeamDetailControl.ascx - Team oluşturma/düzenleme formu
✅ Team bilgileri (Name, Description)
✅ Team ownership
✅ Delete team confirmation
✅ Validation
✅ Real data integration (ITeamService)
```

---

## 🎨 TASARIM DETAYLARI

### **Team Detail Form Layout:**

```
┌──────────────────────────────────────────────────────────────────┐
│ [← Back]  🏢 Create Team                                   [✕]  │
├──────────────────────────────────────────────────────────────────┤
│                                                                   │
│  ┌────────────────────── TEAM INFORMATION ───────────────────┐   │
│  │                                                            │   │
│  │  Team Name *                                               │   │
│  │  ┌──────────────────────────────────────────────────────┐ │   │
│  │  │ Enter team name...                                    │ │   │
│  │  └──────────────────────────────────────────────────────┘ │   │
│  │                                                            │   │
│  │  Description                                               │   │
│  │  ┌──────────────────────────────────────────────────────┐ │   │
│  │  │                                                        │ │   │
│  │  │ Enter team description...                             │ │   │
│  │  │                                                        │ │   │
│  │  └──────────────────────────────────────────────────────┘ │   │
│  │                                                            │   │
│  └────────────────────────────────────────────────────────────┘   │
│                                                                   │
│  ┌──────────────────── TEAM STATISTICS ─────────────────────┐    │
│  │                                                           │    │
│  │  📊 Team Overview:                                        │    │
│  │  • Members: 12                                            │    │
│  │  • Active Projects: 5                                     │    │
│  │  • Created: 15 Jan 2024                                   │    │
│  │  • Owner: John Doe                                        │    │
│  │                                                           │    │
│  └───────────────────────────────────────────────────────────┘    │
│                                                                   │
│                              ┌─────────┐  ┌─────────────────────┐│
│                              │ Cancel  │  │ 💾 Save Team        ││
│                              └─────────┘  └─────────────────────┘│
│                                                                   │
│  [Edit modda: 🗑️ Delete Team]                                    │
└──────────────────────────────────────────────────────────────────┘
```

### **Color Scheme:**

| Element | RGB | Hex |
|---------|-----|-----|
| Background | `11, 11, 11` | #0B0B0B |
| Panel | `21, 21, 21` | #151515 |
| Input | `26, 26, 26` | #1A1A1A |
| Border | `42, 42, 42` | #2A2A2A |
| Orange | `255, 77, 0` | #FF4D00 |
| Red (Delete) | `255, 77, 77` | #FF4D4D |
| White | `255, 255, 255` | #FFFFFF |
| Gray | `161, 161, 161` | #A1A1A1 |

---

## 🚀 ADIM 1: UserControl Oluştur

```
Solution Explorer → Forms/Dashboard/Content → Add → User Control
İsim: TeamDetailControl.cs
```

### **Properties:**

| Property | Değer |
|----------|-------|
| **(Name)** | `TeamDetailControl` |
| **Size** | `1100, 730` |
| **BackColor** | `11, 11, 11` |
| **Padding** | `0, 0, 0, 0` |

---

## 🎨 ADIM 2: Header

### **2.1 Header Panel**

| Property | Değer |
|----------|-------|
| **(Name)** | `pnlHeader` |
| **Dock** | `Top` |
| **Height** | `80` |
| **BackColor** | `11, 11, 11` |
| **BorderStyle** | `NoBorder` |

### **2.2 Back Button**

| Property | Değer |
|----------|-------|
| **(Name)** | `btnBack` |
| **Text** | `← Back` |
| **Location** | `10, 25` |
| **Size** | `80, 30` |
| **Font** | `Segoe UI, 9pt` |
| **Appearance.BackColor** | `42, 42, 42` |
| **Appearance.ForeColor** | `255, 255, 255` |

### **2.3 Title Label**

| Property | Değer |
|----------|-------|
| **(Name)** | `lblTitle` |
| **Text** | `🏢 Create Team` |
| **Location** | `100, 25` |
| **Font** | `Segoe UI, 18pt, Bold` |
| **Appearance.ForeColor** | `255, 255, 255` |

---

## 📋 ADIM 3: Team Information Group

### **3.1 Group Control**

| Property | Değer |
|----------|-------|
| **(Name)** | `grpTeamInfo` |
| **Text** | `TEAM INFORMATION` |
| **Location** | `50, 100` |
| **Size** | `1000, 200` |
| **Appearance.BackColor** | `21, 21, 21` |

### **3.2 Team Name**

**Label:**

| Property | Değer |
|----------|-------|
| **(Name)** | `lblTeamName` |
| **Text** | `Team Name *` |
| **Location** | `20, 40` |
| **Font** | `Segoe UI, 9pt` |
| **Appearance.ForeColor** | `161, 161, 161` |

**TextEdit:**

| Property | Değer |
|----------|-------|
| **(Name)** | `txtTeamName` |
| **Location** | `20, 65` |
| **Size** | `960, 30` |
| **Properties.NullText** | `Enter team name...` |
| **Properties.Appearance.BackColor** | `26, 26, 26` |
| **Properties.Appearance.ForeColor** | `255, 255, 255` |

### **3.3 Description**

**Label:**

| Property | Değer |
|----------|-------|
| **(Name)** | `lblDescription` |
| **Text** | `Description` |
| **Location** | `20, 110` |

**MemoEdit:**

| Property | Değer |
|----------|-------|
| **(Name)** | `txtDescription` |
| **Location** | `20, 135` |
| **Size** | `960, 80` |
| **Properties.NullText** | `Enter team description...` |
| **Properties.Appearance.BackColor** | `26, 26, 26` |
| **Properties.Appearance.ForeColor** | `255, 255, 255` |

---

## 📊 ADIM 4: Statistics Group (Edit Mode)

### **4.1 Group Control**

| Property | Değer |
|----------|-------|
| **(Name)** | `grpStatistics` |
| **Text** | `TEAM STATISTICS` |
| **Location** | `50, 320` |
| **Size** | `1000, 150` |
| **Visible** | `False` (Sadece edit modda göster) |

### **4.2 Stats Label**

| Property | Değer |
|----------|-------|
| **(Name)** | `lblStats` |
| **Text** | `📊 Team Overview:\n• Members: 0\n• Active Projects: 0\n• Created: N/A\n• Owner: N/A` |
| **Location** | `20, 40` |
| **Size** | `960, 90` |
| **Font** | `Segoe UI, 9pt` |
| **Appearance.ForeColor** | `161, 161, 161` |

---

## 🎬 ADIM 5: Footer Actions

### **5.1 Cancel Button**

| Property | Değer |
|----------|-------|
| **(Name)** | `btnCancel` |
| **Text** | `Cancel` |
| **Location** | `820, 660` |
| **Size** | `100, 40` |
| **Appearance.BackColor** | `42, 42, 42` |
| **Appearance.ForeColor** | `161, 161, 161` |

### **5.2 Save Button**

| Property | Değer |
|----------|-------|
| **(Name)** | `btnSave` |
| **Text** | `💾 Save Team` |
| **Location** | `930, 660` |
| **Size** | `150, 40` |
| **Appearance.BackColor** | `255, 77, 0` |
| **Appearance.ForeColor** | `255, 255, 255` |

### **5.3 Delete Button (Edit Mode)**

| Property | Değer |
|----------|-------|
| **(Name)** | `btnDelete` |
| **Text** | `🗑️ Delete Team` |
| **Location** | `50, 660` |
| **Size** | `130, 40` |
| **Visible** | `False` |
| **Appearance.BackColor** | `255, 77, 77` |
| **Appearance.ForeColor** | `255, 255, 255` |

---

## 💻 ADIM 6: Code-Behind

```csharp
using DevExpress.XtraEditors;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.UI.Forms.Dashboard;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    /// <summary>
    /// Team detail control - Create/Edit team
    /// </summary>
    public partial class TeamDetailControl : UserControl
    {
        #region Fields
        
        private readonly ITeamService _teamService;
        private int? _editingTeamId = null;
        
        #endregion
        
        #region Constructor
        
        public TeamDetailControl(ITeamService teamService)
        {
            InitializeComponent();
            _teamService = teamService;
            SetupEventHandlers();
        }
        
        public TeamDetailControl()
        {
            InitializeComponent();
        }
        
        #endregion
        
        #region Setup
        
        private void SetupEventHandlers()
        {
            btnBack.Click += BtnBack_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnDelete.Click += BtnDelete_Click;
        }
        
        #endregion
        
        #region Public Methods
        
        public async void LoadTeamForEdit(int teamId)
        {
            try
            {
                _editingTeamId = teamId;
                lblTitle.Text = "🏢 Edit Team";
                btnSave.Text = "💾 Update Team";
                grpStatistics.Visible = true;
                btnDelete.Visible = true;
                
                var team = await _teamService.GetTeamByIdAsync(teamId);
                if (team != null)
                {
                    txtTeamName.Text = team.TeamName;
                    txtDescription.Text = team.Description;
                    
                    lblStats.Text = $"📊 Team Overview:\n" +
                        $"• Members: {team.MemberCount}\n" +
                        $"• Active Projects: {team.ProjectCount}\n" +
                        $"• Created: {team.CreatedAt:dd MMM yyyy}\n" +
                        $"• Owner: {team.OwnerName}";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading team: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion
        
        #region Validation
        
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                XtraMessageBox.Show("Team name is required", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeamName.Focus();
                return false;
            }
            
            if (txtTeamName.Text.Length < 3)
            {
                XtraMessageBox.Show("Team name must be at least 3 characters", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeamName.Focus();
                return false;
            }
            
            return true;
        }
        
        #endregion
        
        #region Event Handlers
        
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;
            
            try
            {
                Cursor = Cursors.WaitCursor;
                
                var teamDto = new TeamDto
                {
                    TeamId = _editingTeamId ?? 0,
                    TeamName = txtTeamName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };
                
                if (_editingTeamId.HasValue)
                {
                    await _teamService.UpdateTeamAsync(teamDto);
                    XtraMessageBox.Show("Team updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _teamService.CreateTeamAsync(teamDto);
                    XtraMessageBox.Show("Team created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                GoBackToTeamsList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error saving team: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "Are you sure? Any unsaved changes will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
                GoBackToTeamsList();
        }
        
        private void BtnBack_Click(object sender, EventArgs e)
        {
            BtnCancel_Click(sender, e);
        }
        
        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(
                "Are you sure you want to delete this team?\n\n" +
                "WARNING: This will also delete all projects and tasks associated with this team!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    await _teamService.DeleteTeamAsync(_editingTeamId.Value);
                    
                    XtraMessageBox.Show("Team deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    GoBackToTeamsList();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Error deleting team: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        
        private void GoBackToTeamsList()
        {
            var teamsContent = Program.ServiceProvider.GetRequiredService<TeamsContent>();
            ((FrmDashboard)this.ParentForm).LoadContent(teamsContent);
        }
        
        #endregion
    }
}
```

---

## ✅ TEST

1. [ ] Create mode çalışıyor mu?
2. [ ] Edit mode doğru yükleniyor mu?
3. [ ] Validation çalışıyor mu?
4. [ ] Save işlemi başarılı mı?
5. [ ] Delete confirmation gösteriliyor mu?

---

**Hazırlayan:** AI Assistant  
**Tarih:** 29 Aralık 2024  
**Phase:** 5.2 - Team Creation & Settings
