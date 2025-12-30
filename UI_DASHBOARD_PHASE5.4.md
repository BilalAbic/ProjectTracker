# 📁 PHASE 5.4: TEAM MEMBERS & ROLE MANAGEMENT

**TeamMembersContent.ascx - Member List & Role Assignment**

**Süre:** 3-4 saat  
**Zorluk:** Orta/İleri Düzey

---

## 🎯 BU PHASE'DE NE YAPACAĞIZ?

```
✅ TeamMembersContent.ascx - Takım üyeleri listesi
✅ Role assignment (dropdown)
✅ Remove member action
✅ Member filtreleme
✅ Permission matrix
✅ Real data integration
```

---

## 🎨 TASARIM DETAYLARI

### **Team Members Layout:**

```
┌──────────────────────────────────────────────────────────────────┐
│ 👥 Team Members - Product Team                                   │
│ Manage team members and their roles                              │
├──────────────────────────────────────────────────────────────────┤
│  🔍 [Search members...]     [All Roles ▾]     [Clear]            │
├──────────────────────────────────────────────────────────────────┤
│                                                                   │
│  ┌─────────────────────────────────────────────────────────────┐ │
│  │ Name            Email              Role          Joined   │  │
│  ├─────────────────────────────────────────────────────────────┤ │
│  │ JD John Doe     john@company.com   [Owner ▾]    Jan 2024  ✓ │ │
│  │ SM Sarah Miller sarah@company.com  [Admin ▾]    Feb 2024  ✏️❌│ │
│  │ BW Bob Wilson   bob@company.com    [Developer ▾] Mar 2024 ✏️❌│ │
│  │ JS Jane Smith   jane@company.com   [Observer ▾]  Apr 2024 ✏️❌│ │
│  └─────────────────────────────────────────────────────────────┘ │
│                                                                   │
│  Showing 4 of 12 members                          [🔄 Refresh]  │
└──────────────────────────────────────────────────────────────────┘
```

### **Role Colors:**

| Role | Color | Hex |
|------|-------|-----|
| Owner | `#0066FF` (Blue) | 0, 102, 255 |
| Admin | `#9B59B6` (Purple) | 155, 89, 182 |
| Project Manager | `#FFB800` (Yellow) | 255, 184, 0 |
| Developer | `#00D084` (Green) | 0, 208, 132 |
| Observer | `#A1A1A1` (Gray) | 161, 161, 161 |

---

## 🚀 ADIM 1: UserControl Oluştur

```
Forms/Dashboard/Content → Add → User Control
İsim: TeamMembersContent.cs
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
| **Text** | `👥 Team Members` |
| **Location** | `0, 10` |
| **Font** | `Segoe UI, 18pt, Bold` |

### **2.3 Subtitle**

| Property | Değer |
|----------|-------|
| **(Name)** | `lblSubtitle` |
| **Text** | `Manage team members and their roles` |
| **Location** | `0, 48` |
| **Font** | `Segoe UI, 10pt` |
| **Appearance.ForeColor** | `161, 161, 161` |

---

## 🔍 ADIM 3: Filter Bar

### **3.1 Filter Panel**

| Property | Değer |
|----------|-------|
| **(Name)** | `pnlFilters` |
| **Dock** | `Top` |
| **Height** | `60` |
| **Appearance.BackColor** | `21, 21, 21` |

### **3.2 Search**

| Property | Değer |
|----------|-------|
| **(Name)** | `txtSearch` |
| **Location** | `15, 15` |
| **Size** | `300, 30` |
| **Properties.NullText** | `🔍 Search members...` |

### **3.3 Role Filter**

| Property | Değer |
|----------|-------|
| **(Name)** | `cmbRoleFilter` |
| **Location** | `330, 15` |
| **Size** | `160, 30` |
| **Properties.Items** | `All Roles, Owner, Admin, Project Manager, Developer, Observer` |

### **3.4 Clear Button**

| Property | Değer |
|----------|-------|
| **(Name)** | `btnClear` |
| **Text** | `Clear` |
| **Location** | `505, 15` |
| **Size** | `80, 30` |

---

## 📊 ADIM 4: Members Grid

### **4.1 Grid Control**

**Toolbox → GridControl → Sürükle:**

| Property | Değer |
|----------|-------|
| **(Name)** | `grdMembers` |
| **Dock** | `Fill` |

### **4.2 Columns:**

**1. Initials:**
- **FieldName:** `Initials`
- **Width:** `50`
- **UnboundType:** `String`

**2. FullName:**
- **FieldName:** `UserName`
- **Caption:** `Name`
- **Width:** `200`

**3. Email:**
- **FieldName:** `Email`
- **Width:** `250`

**4. Role (ComboBox Column):**
- **FieldName:** `Role`
- **Width:** `150`
- **ColumnEdit:** `RepositoryItemComboBox`
- **Items:** `Owner, Admin, ProjectManager, Developer, Observer`

**5. JoinedAt:**
- **FieldName:** `JoinedAt`
- **Caption:** `Joined`
- **Width:** `120`
- **DisplayFormat:** `dd MMM yyyy`

**6. Actions:**
- **FieldName:** `Actions`
- **Width:** `80`
- **UnboundType:** `Object`

---

## 💻 ADIM 5: Code-Behind (Özet)

```csharp
namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    public partial class TeamMembersContent : UserControl
    {
        private readonly ITeamService _teamService;
        private List<TeamMemberDto> _allMembers;
        private List<TeamMemberDto> _filteredMembers;
        private RepositoryItemComboBox _roleComboBox;
        
        public TeamMembersContent(ITeamService teamService)
        {
            InitializeComponent();
            _teamService = teamService;
            
            SetupGrid();
            LoadMembersAsync();
        }
        
        private void SetupGrid()
        {
            // Role ComboBox Repository
            _roleComboBox = new RepositoryItemComboBox();
            _roleComboBox.Items.AddRange(new object[] {
                "Owner", "Admin", "Project Manager", "Developer", "Observer"
            });
            _roleComboBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            _roleComboBox.EditValueChanged += RoleComboBox_EditValueChanged;
            
            colRole.ColumnEdit = _roleComboBox;
            
            // Custom drawing for initials
            gridView1.CustomDrawCell += GridView_CustomDrawCell;
        }
        
        private async void LoadMembersAsync()
        {
            try
            {
                var activeTeam = await _teamService.GetActiveTeamAsync();
                _allMembers = (await _teamService.GetTeamMembersAsync(activeTeam.TeamId)).ToList();
                _filteredMembers = _allMembers.ToList();
                
                grdMembers.DataSource = _filteredMembers;
                UpdateRecordCount();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async void RoleComboBox_EditValueChanged(object sender, EventArgs e)
        {
            // Update member role
            try
            {
                var member = gridView1.GetFocusedRow() as TeamMemberDto;
                if (member != null)
                {
                    var newRole = (string)_roleComboBox.EditValue;
                    member.RoleName = newRole;
                    
                    await _teamService.UpdateMemberRoleAsync(member.TeamMemberId, 
                        (Core.Enums.TeamRole)Enum.Parse(typeof(Core.Enums.TeamRole), newRole.Replace(" ", "")));
                    
                    XtraMessageBox.Show("Role updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error updating role: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void GridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Initials")
            {
                var member = gridView1.GetRow(e.RowHandle) as TeamMemberDto;
                if (member != null)
                {
                    // Draw initials badge
                    e.Handled = true;
                    e.Graphics.FillEllipse(new SolidBrush(GetRoleColor(member.RoleName)), 
                        e.Bounds.X + 10, e.Bounds.Y + 5, 30, 30);
                    
                    var initials = GetInitials(member.UserName);
                    e.Graphics.DrawString(initials, new Font("Segoe UI", 9, FontStyle.Bold),
                        Brushes.White, e.Bounds.X + 15, e.Bounds.Y + 10);
                }
            }
        }
        
        private Color GetRoleColor(string roleName)
        {
            return roleName switch
            {
                "Owner" => Color.FromArgb(0, 102, 255),
                "Admin" => Color.FromArgb(155, 89, 182),
                "Project Manager" => Color.FromArgb(255, 184, 0),
                "Developer" => Color.FromArgb(0, 208, 132),
                "Observer" => Color.FromArgb(161, 161, 161),
                _ => Color.Gray
            };
        }
        
        private string GetInitials(string fullName)
        {
            var parts = fullName.Split(' ');
            if (parts.Length >= 2)
                return $"{parts[0][0]}{parts[1][0]}".ToUpper();
            return fullName.Length >= 2 ? fullName.Substring(0, 2).ToUpper() : fullName.ToUpper();
        }
    }
}
```

---

## ✅ TEST

1. [ ] Member listesi yükleniyor mu?
2. [ ] Role değiştirme çalışıyor mu?
3. [ ] Search filtreleme çalışıyor mu?
4. [ ] Initials badge'leri görünüyor mu?
5. [ ] Role renkleri doğru mu?

---

**Hazırlayan:** AI Assistant  
**Tarih:** 29 Aralık 2024  
**Phase:** 5.4 - Team Members & Role Management
