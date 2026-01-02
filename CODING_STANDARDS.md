# PROJECT TRACKER - CODING STANDARDS

Bu dokümanda ProjectTracker projesi için kullanılan kod standartları belirtilmiştir.

**Son Güncelleme:** 2 Ocak 2026

---

## 📋 İÇİNDEKİLER

1. [Genel Standartlar](#-genel-standartlar)
2. [İsimlendirme Kuralları](#-isimlendirme-kuralları)
3. [Color Palette](#-color-palette)
4. [Form İsimlendirmeleri](#-form-isimlendirmeleri)
5. [DevExpress Kontrol İsimlendirmeleri](#-devexpress-kontrol-isimlendirmeleri)
6. [Service Katmanı Standartları](#-service-katmanı-standartları)
7. [Mesaj Kutusu Kullanımı](#-mesaj-kutusu-kullanımı)
8. [Async/Await Kuralları](#-asyncawait-kuralları)
9. [Exception Handling](#-exception-handling)
10. [Veritabanı Standartları](#-veritabanı-standartları)

---

## 🎯 GENEL STANDARTLAR

### Proje Yapısı

```
ProjectTracker/
├── ProjectTracker.Core/        → Domain Layer (Entities, Enums, Interfaces)
├── ProjectTracker.Data/        → Data Access Layer (Context, Repositories, Migrations)
├── ProjectTracker.Business/    → Business Logic Layer (Services, DTOs, Validators)
├── ProjectTracker.UI/          → Presentation Layer (Forms, Helpers)
└── ProjectTracker.Tests/       → Unit Tests
```

### Katman Bağımlılıkları

```
UI → Business → Data → Core
     ↓
   Core (tüm katmanlar Core'a bağımlı olabilir)
```

---

## 📝 İSİMLENDİRME KURALLARI

### Class İsimleri
- **PascalCase** kullanılır

```csharp
✅ DOĞRU:
public class ProjectService { }
public class TeamMemberDto { }
public class AuditLogService { }

❌ YANLIŞ:
public class projectService { }
public class teamMemberDTO { }
```

### Method İsimleri
- **PascalCase** kullanılır
- Async metodlar **Async** suffix alır

```csharp
✅ DOĞRU:
public async Task<ProjectDto> GetProjectByIdAsync(int projectId)
public void CalculateRiskScore()
public async Task LoadTeamsAsync()

❌ YANLIŞ:
public async Task<ProjectDto> getProject(int id)
public void calc()
```

### Property İsimleri
- **PascalCase** kullanılır

```csharp
✅ DOĞRU:
public string ProjectName { get; set; }
public int TeamId { get; set; }
public bool IsActive { get; set; }

❌ YANLIŞ:
public string projectName { get; set; }
public int team_id { get; set; }
```

### Private Değişkenler
- **_** (underscore) ile başlar
- **camelCase** kullanılır

```csharp
✅ DOĞRU:
private readonly IProjectService _projectService;
private readonly ITeamService _teamService;
private List<ProjectDto> _allProjects;
private bool _isEditMode;

❌ YANLIŞ:
private IProjectService projectService;
private List<ProjectDto> AllProjects;
```

### Parametreler ve Local Değişkenler
- **camelCase** kullanılır

```csharp
✅ DOĞRU:
public void UpdateProject(int projectId, string projectName)
var filteredTasks = tasks.Where(t => t.Status == "Active");
int completionPercentage = CalculateCompletion();

❌ YANLIŞ:
public void UpdateProject(int ProjectId, string project_name)
var FilteredTasks = tasks.Where(t => t.Status == "Active");
```

---

## 🎨 COLOR PALETTE

### Renk Yönetimi

Proje genelinde tutarlı renk kullanımı için `ColorPalette.cs` helper class kullanılır:

```csharp
using ProjectTracker.UI.Helpers;

// ✅ DOĞRU - ColorPalette kullan
this.BackColor = ColorPalette.BackgroundDeepNavy;
panel.BackColor = ColorPalette.BackgroundSlateDark;
btnSave.Appearance.BackColor = ColorPalette.AccentRoyalBlue;
lblTitle.ForeColor = ColorPalette.TextPrimary;

// ❌ YANLIŞ - Hardcoded renk kullanma
this.BackColor = Color.FromArgb(26, 31, 38);
panel.BackColor = Color.FromArgb(36, 43, 61);
```

### Ana Renk Kategorileri

#### Background Colors
| Renk | Hex | Kullanım |
|------|-----|----------|
| `BackgroundDeepNavy` | #1A1F26 | Form arka planları |
| `BackgroundSlateDark` | #242B3D | Kart ve paneller |
| `BackgroundSlateMedium` | #1E2A3A | Input kontrolları |
| `BorderSlate` | #334155 | Border ve ayırıcılar |

#### Accent Colors
| Renk | Hex | Kullanım |
|------|-----|----------|
| `AccentRoyalBlue` | #5B8DEF | Primary butonlar |
| `AccentSkyBlue` | #7BA8F7 | Hover durumları |

#### Semantic Colors
| Renk | Hex | Kullanım |
|------|-----|----------|
| `SuccessGreen` | #22C55E | Başarılı işlemler |
| `WarningOrange` | #F59E0B | Uyarılar |
| `DangerRed` | #EF4444 | Hatalar, silme |
| `InfoBlue` | #3B82F6 | Bilgi mesajları |

#### Text Colors
| Renk | Hex | Kullanım |
|------|-----|----------|
| `TextPrimary` | #F8FAFC | Başlıklar |
| `TextSecondary` | #CBD5E1 | Label'lar |
| `TextMuted` | #64748B | Disabled |

### Helper Methods

```csharp
// Priority rengi
Color priorityColor = ColorPalette.GetPriorityColor(Priority.High);

// Status rengi
Color statusColor = ColorPalette.GetStatusColor(ProjectStatus.Active);
```

---

## 🖼️ FORM İSİMLENDİRMELERİ

### Form Class İsimleri
- **Frm** prefix kullanılır

```csharp
✅ DOĞRU:
public partial class FrmLogin : XtraForm
public partial class FrmDashboard : XtraForm
public partial class FrmPendingWaitlist : XtraForm
public partial class FrmMessage : XtraForm

❌ YANLIŞ:
public partial class LoginForm : XtraForm
public partial class Dashboard : XtraForm
```

### UserControl Class İsimleri
- **Prefix kullanılmaz**
- **Content** veya **Control** suffix kullanılır

```csharp
✅ DOĞRU:
public partial class DashboardContent : UserControl      // Liste/Ana içerik
public partial class ProjectsContent : UserControl       // Liste içeriği
public partial class ProjectDetailControl : UserControl  // Detay/Edit formu
public partial class TasksContent : UserControl          // Liste + Kanban
public partial class ReportsContent : UserControl        // Raporlar

❌ YANLIŞ:
public partial class FrmProjectsContent : UserControl    // UserControl'de Frm kullanma
public partial class ucProjects : UserControl            // Anlaşılmaz kısaltma
```

---

## 🎨 DEVEXPRESS KONTROL İSİMLENDİRMELERİ

### Standart Prefix'ler

| Kontrol Tipi | Prefix | Örnek |
|--------------|--------|-------|
| SimpleButton | btn | `btnSave`, `btnCancel`, `btnDelete` |
| TextEdit | txt | `txtProjectName`, `txtSearch` |
| MemoEdit | memo | `memoDescription` |
| DateEdit | date | `dateStartDate`, `dateEndDate` |
| LookUpEdit | lue | `lueManager`, `lueTeam` |
| ComboBoxEdit | cmb | `cmbStatus`, `cmbPriority`, `cmbProjectFilter` |
| GridControl | grd | `grdProjects`, `grdTasks` |
| GridView | gridView | `gridView1` |
| CheckEdit | chk | `chkIsActive` |
| SpinEdit | spin | `spinBudget` |
| LabelControl | lbl | `lblTitle`, `lblSubtitle` |
| PanelControl | pnl | `pnlHeader`, `pnlFilters` |

### Örnek Form Yapısı

```csharp
public partial class ProjectDetailControl : UserControl
{
    // Private fields
    private readonly IProjectService _projectService;
    private readonly ITeamService _teamService;
    private ProjectDto? _currentProject;
    private bool _isEditMode;
    
    // Constructor with DI
    public ProjectDetailControl(IProjectService projectService, ITeamService teamService)
    {
        InitializeComponent();
        _projectService = projectService;
        _teamService = teamService;
        
        SetupEventHandlers();
        SetupForm();
        
        this.Load += async (s, e) => await LoadTeamsAsync();
    }
}
```

---

## 🔧 SERVICE KATMANI STANDARTLARI

### Service Class Yapısı

```csharp
public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuditLogService _auditLogService;
    private readonly ICurrentUserService _currentUserService;

    public ProjectService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuditLogService auditLogService,
        ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _auditLogService = auditLogService;
        _currentUserService = currentUserService;
    }
}
```

### Audit Log Kullanımı

Audit log çağrıları **fire-and-forget** yapılmalıdır (DbContext concurrency hatası önlemek için):

```csharp
// ✅ DOĞRU - Fire-and-forget
await _unitOfWork.SaveChangesAsync();

_ = System.Threading.Tasks.Task.Run(async () =>
{
    try
    {
        await _auditLogService.LogActivityAsync(
            ActivityType.ProjectCreated,
            "Projects",
            project.ProjectId,
            _currentUserService.CurrentUserId,
            teamId: project.TeamId);
    }
    catch { /* Ignore audit log errors */ }
});

// ❌ YANLIŞ - Direkt await
await _unitOfWork.SaveChangesAsync();
await _auditLogService.LogActivityAsync(...); // DbContext hatası verebilir!
```

---

## 💬 MESAJ KUTUSU KULLANIMI

### FormStyleHelper Metodları

**XtraMessageBox.Show() kullanmayın!** Bunun yerine `FormStyleHelper` metodlarını kullanın:

```csharp
using ProjectTracker.UI.Helpers;

// ✅ DOĞRU - FormStyleHelper kullan
FormStyleHelper.ShowSuccess("Project created successfully!");
FormStyleHelper.ShowError($"Error: {ex.Message}");
FormStyleHelper.ShowWarning("You don't have permission.");
FormStyleHelper.ShowInfo("Operation completed.");

if (FormStyleHelper.ShowQuestion("Are you sure you want to delete?"))
{
    await DeleteAsync();
}

// ❌ YANLIŞ - XtraMessageBox kullanma
XtraMessageBox.Show("Success!", "Info", MessageBoxButtons.OK);
MessageBox.Show("Error occurred");
```

### Mevcut Metodlar

| Metod | Kullanım |
|-------|----------|
| `ShowSuccess(message)` | Başarılı işlemler |
| `ShowError(message)` | Hata mesajları |
| `ShowWarning(message)` | Uyarılar |
| `ShowInfo(message)` | Bilgi mesajları |
| `ShowQuestion(message)` | Yes/No sorusu (bool döner) |
| `ShowQuestionWithCancel(message)` | Yes/No/Cancel sorusu |
| `ShowDeleteConfirmation(itemName)` | Silme onayı |
| `ShowSaveConfirmation()` | Kaydetme onayı |

---

## ⚡ ASYNC/AWAIT KURALLARI

### Async Void Metodlar

Async void metodlar **sadece event handler'larda** kullanılmalı ve **mutlaka try-catch** içermelidir:

```csharp
// ✅ DOĞRU
private async void btnSave_Click(object sender, EventArgs e)
{
    try
    {
        await SaveProjectAsync();
        FormStyleHelper.ShowSuccess("Saved!");
    }
    catch (Exception ex)
    {
        FormStyleHelper.ShowError($"Error: {ex.Message}");
    }
}

// ❌ YANLIŞ - Try-catch yok
private async void btnSave_Click(object sender, EventArgs e)
{
    await SaveProjectAsync(); // Exception yakalanmaz!
}
```

### Load Event Kullanımı

Constructor'da fire-and-forget yerine Load event kullanın:

```csharp
// ✅ DOĞRU
public ProjectsContent(IProjectService projectService)
{
    InitializeComponent();
    _projectService = projectService;
    
    this.Load += async (s, e) => await LoadProjectsAsync();
}

// ❌ YANLIŞ - Fire-and-forget
public ProjectsContent(IProjectService projectService)
{
    InitializeComponent();
    _projectService = projectService;
    
    _ = LoadProjectsAsync(); // Hata yakalanmaz!
}
```

---

## 🎯 EXCEPTION HANDLING

### Standart Yapı

```csharp
try
{
    Cursor = Cursors.WaitCursor;
    btnSave.Enabled = false;
    
    await _projectService.CreateProjectAsync(dto);
    
    FormStyleHelper.ShowSuccess("Project created!");
    NavigateBack();
}
catch (ValidationException vex)
{
    FormStyleHelper.ShowWarning($"Validation: {vex.Message}");
}
catch (UnauthorizedAccessException)
{
    FormStyleHelper.ShowWarning("You don't have permission.");
}
catch (Exception ex)
{
    FormStyleHelper.ShowError($"Error: {ex.Message}");
}
finally
{
    Cursor = Cursors.Default;
    btnSave.Enabled = true;
}
```

---

## 🗄️ VERİTABANI STANDARTLARI

### Veritabanı Adı
```
DboProjectTracker
```

### Tablo İsimleri
- **PascalCase** ve **çoğul**

```sql
✅ DOĞRU: Users, Projects, Tasks, Teams, TeamMembers, AuditLogs
❌ YANLIŞ: user, project, task, team_member
```

### Kolon İsimleri
- **PascalCase**

```sql
✅ DOĞRU: ProjectId, ProjectName, TeamId, CreatedAt, IsActive
❌ YANLIŞ: project_id, projectName, created_at
```

### Foreign Key İsimleri
- **[TableName]Id** formatı

```csharp
public int ProjectId { get; set; }  // Projects tablosuna FK
public int TeamId { get; set; }     // Teams tablosuna FK
public int CreatedByUserId { get; set; } // Users tablosuna FK
```

---

## ✅ KOD YAZMA ÖNCESİ KONTROL LİSTESİ

- [ ] Class isimleri PascalCase mi?
- [ ] Method isimleri PascalCase mi?
- [ ] Async metodlar "Async" suffix'i var mı?
- [ ] Private değişkenler _ ile başlıyor mu?
- [ ] ColorPalette kullanılıyor mu (hardcoded renk yok)?
- [ ] FormStyleHelper mesaj metodları kullanılıyor mu?
- [ ] Async void metodlarda try-catch var mı?
- [ ] Audit log fire-and-forget yapılıyor mu?
- [ ] DevExpress kontroller doğru prefix ile mi?
- [ ] XML comments var mı?

---

**Proje:** ProjectTracker - Smart Project Management System  
**Color Theme:** Modern Slate Blue (ColorPalette.cs)
