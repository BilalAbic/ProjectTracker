# PROJECT TRACKER - CODING STANDARDS

Bu dokümanda ProjectTracker projesi için kullanacağımız kod standartları belirtilmiştir.

---

## 🎯 GENEL STANDARTLAR

### 1. İsimlendirme Kuralları

#### Class İsimleri
- **PascalCase** kullanılır
- Her kelimenin ilk harfi büyük

```csharp
✅ DOĞRU:
public class ProjectService { }
public class UserRepository { }
public class RiskCalculator { }

❌ YANLIŞ:
public class projectService { }
public class userrepository { }
```

#### Method İsimleri
- **PascalCase** kullanılır
- Açıklayıcı isimler

```csharp
✅ DOĞRU:
public async Task<Project> GetProjectByIdAsync(int projectId)
public void CalculateRiskScore()
public List<Task> GetCriticalPathTasks()

❌ YANLIŞ:
public void getproject()
public void calc()
```

#### Property İsimleri
- **PascalCase** kullanılır

```csharp
✅ DOĞRU:
public string ProjectName { get; set; }
public DateTime StartDate { get; set; }
public bool IsActive { get; set; }
public int CompletionPercentage { get; set; }

❌ YANLIŞ:
public string projectName { get; set; }
public DateTime start_date { get; set; }
```

#### Parametreler
- **camelCase** kullanılır
- İlk kelime küçük, sonraki kelimelerin ilk harfi büyük

```csharp
✅ DOĞRU:
public void UpdateProject(int projectId, string projectName, DateTime startDate)
public void AssignTask(int taskId, int userId)

❌ YANLIŞ:
public void UpdateProject(int ProjectId, string project_name, DateTime StartDate)
```

#### Private Değişkenler
- **_** (underscore) ile başlar
- camelCase kullanılır

```csharp
✅ DOĞRU:
private readonly IProjectRepository _projectRepository;
private readonly IUnitOfWork _unitOfWork;
private decimal _totalBudget;
private int _taskCount;

❌ YANLIŞ:
private IProjectRepository projectRepository;
private IUnitOfWork UnitOfWork;
```

#### Local Değişkenler
- **camelCase** kullanılır

```csharp
✅ DOĞRU:
var projectList = await _projectRepository.GetAllAsync();
int completionPercentage = CalculateCompletion();
string userName = "admin";

❌ YANLIŞ:
var ProjectList = await _projectRepository.GetAllAsync();
int CompletionPercentage = CalculateCompletion();
```

---

## 🖼️ FORM İSİMLENDİRMELERİ

### Form Class İsimleri
- **Frm** prefix kullanılır
- PascalCase

```csharp
✅ DOĞRU:
public partial class FrmLogin : XtraForm
public partial class FrmDashboard : XtraForm
public partial class FrmProjectList : XtraForm
public partial class FrmProjectDetail : XtraForm
public partial class FrmTaskEdit : XtraForm

❌ YANLIŞ:
public partial class LoginForm : XtraForm
public partial class ProjectListForm : XtraForm
```

### UserControl Class İsimleri
- **Prefix kullanılmaz** (Form'lardan farklı)
- PascalCase
- Açıklayıcı isim + "Content" veya "Control" suffix

```csharp
✅ DOĞRU (Gerçek Projeden):
public partial class DashboardContent : UserControl      // Ana dashboard içeriği
public partial class ProjectsContent : UserControl       // Projeler listesi içeriği
public partial class TasksContent : UserControl          // Görevler listesi + Kanban
public partial class ProjectDetailControl : UserControl  // Proje detay formu
public partial class TaskDetailControl : UserControl     // Görev detay formu

❌ YANLIŞ:
public partial class FrmProjectsContent : UserControl    // UserControl'de Frm kullanma
public partial class ucProjects : UserControl            // Anlaşılmaz kısaltma
```

### Form Özellikleri
- **Form boyutu**: Maksimum 770x700 piksel
- **AutoScroll**: true olmalı
- **Text property**: Açıklayıcı ve Türkçe (kullanıcı için)

```csharp
// Form constructor
public FrmProjectList()
{
    InitializeComponent();
    this.AutoScroll = true;
    this.Size = new Size(770, 700);
    this.Text = "Proje Listesi";
}
```

---

## 🎨 DEVEXPRESS KONTROL İSİMLENDİRMELERİ

### Standart Windows Forms Kontrolleri

| Kontrol Tipi | Prefix | Örnek |
|--------------|--------|-------|
| Label | lbl | `lblProjectName`, `lblStartDate` |
| Button | btn | `btnSave`, `btnCancel`, `btnDelete` |
| TextBox | txt | `txtName`, `txtDescription` |
| CheckBox | chk | `chkIsActive`, `chkIsCompleted` |
| RadioButton | rbtn | `rbtnActive`, `rbtnCompleted` |
| ComboBox | cmb | `cmbStatus`, `cmbPriority` |
| DateTimePicker | dtp | `dtpStartDate`, `dtpEndDate` |
| DataGridView | grd | `grdProjects`, `grdTasks` |
| Panel | pnl | `pnlDetails`, `pnlFilters` |
| GroupBox | grp | `grpProjectInfo`, `grpTaskDetails` |

### DevExpress Kontrolleri

| Kontrol Tipi | Prefix | Örnek |
|--------------|--------|-------|
| SimpleButton | btn | `btnSave`, `btnCancel` |
| TextEdit | txt | `txtProjectName`, `txtDescription` |
| MemoEdit | memo | `memoDescription`, `memoNotes` |
| DateEdit | date | `dateStartDate`, `dateEndDate` |
| LookUpEdit | lue | `lueManager`, `lueStatus` |
| GridControl | grd | `grdProjects`, `grdTasks` |
| GridView | grdw | `grdwProjects`, `grdwTasks` |
| CheckEdit | chk | `chkIsActive`, `chkIsCritical` |
| ComboBoxEdit | cmb | `cmbPriority`, `cmbStatus` |
| SpinEdit | spin | `spinPercentage`, `spinHours` |
| ProgressBarControl | pbc | `pbcCompletion`, `pbcProgress` |
| XtraTabControl | xtab | `xtabProject`, `xtabTask` |

### Örnek Form Tasarımı

```csharp
public partial class FrmProjectDetail : DevExpress.XtraEditors.XtraForm
{
    // Private fields (underscore ile)
    private readonly IProjectService _projectService;
    private int _currentProjectId;
    
    // DevExpress Controls (prefix ile)
    private SimpleButton btnSave;
    private SimpleButton btnCancel;
    private TextEdit txtProjectName;
    private TextEdit txtProjectCode;
    private MemoEdit memoDescription;
    private DateEdit dateStartDate;
    private DateEdit dateEndDate;
    private LookUpEdit lueManager;
    private ComboBoxEdit cmbStatus;
    private ComboBoxEdit cmbPriority;
    private SpinEdit spinBudget;
    private CheckEdit chkIsActive;
    
    // Constructor
    public FrmProjectDetail(IProjectService projectService)
    {
        InitializeComponent();
        _projectService = projectService;
    }
    
    // Event Handlers (PascalCase)
    private async void btnSave_Click(object sender, EventArgs e)
    {
        await SaveProjectAsync();
    }
    
    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    
    // Private Methods (PascalCase)
    private async Task SaveProjectAsync()
    {
        try
        {
            var dto = new CreateProjectDto
            {
                ProjectName = txtProjectName.Text,
                ProjectCode = txtProjectCode.Text,
                Description = memoDescription.Text,
                StartDate = dateStartDate.DateTime,
                EndDate = dateEndDate.DateTime,
                ManagerId = (int)lueManager.EditValue
            };
            
            await _projectService.CreateProjectAsync(dto);
            MessageBox.Show("Proje başarıyla kaydedildi.", "Başarılı", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Hata: {ex.Message}", "Hata", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
```

---

## 🔧 SERVICE KATMANI STANDARTLARI

### Service Class İsimleri
- **Service** suffix kullanılır (Modern .NET yaklaşımı)
- PascalCase

```csharp
✅ DOĞRU:
public class ProjectService : IProjectService
public class TaskService : ITaskService
public class UserService : IUserService

❌ YANLIŞ (eski yöntem):
public class SProject : ISProject
public class STask : ISTask
```

### Service Method Yapısı

```csharp
/// <summary>
/// Creates a new project
/// </summary>
/// <param name="dto">Project creation data transfer object</param>
/// <returns>Created project DTO</returns>
public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto)
{
    // Local değişkenler
    string errorMessage = null;
    
    try
    {
        // 1. Validation
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        // 2. Business Logic
        var project = _mapper.Map<Project>(dto);
        project.CreatedDate = DateTime.UtcNow;
        project.CreatedBy = _currentUserId;
        
        // 3. Save
        await _unitOfWork.Projects.AddAsync(project);
        await _unitOfWork.SaveChangesAsync();
        
        // 4. Return
        return _mapper.Map<ProjectDto>(project);
    }
    catch (Exception ex)
    {
        errorMessage = ex.Message;
        // Log the error
        _logger.LogError(ex, "Error creating project");
        throw;
    }
}
```

### Service Kuralları
1. ❌ **Global hata değişkeni tanımlanmamalı**
2. ✅ **Try-catch blokları kullanılmalı**
3. ✅ **Async/await pattern kullanılmalı**
4. ✅ **Dependency Injection ile çalışmalı**
5. ❌ **Class seviyesinde değişken tanımlanmamalı** (sadece readonly field'ler)

---

## 🔌 INTERFACE STANDARTLARI

### Interface İsimleri
- **I** prefix kullanılır
- PascalCase

```csharp
✅ DOĞRU:
public interface IProjectRepository
public interface IProjectService
public interface IUnitOfWork

❌ YANLIŞ:
public interface ProjectRepository
public interface ProjectServiceInterface
```

### Interface Örneği

```csharp
/// <summary>
/// Project service interface
/// </summary>
public interface IProjectService
{
    Task<ProjectDto> GetProjectByIdAsync(int projectId);
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto);
    Task<ProjectDto> UpdateProjectAsync(int projectId, UpdateProjectDto dto);
    Task DeleteProjectAsync(int projectId);
    Task<int> CalculateRiskScoreAsync(int projectId);
}
```

---

## 📝 DOKÜMANTASYON STANDARTLARI

### XML Comments

**Tüm public class, method ve property'ler için XML comment zorunludur:**

```csharp
/// <summary>
/// Represents a project in the system
/// Created by: [Your Name], 17/12/2024
/// </summary>
public class Project : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique project identifier
    /// </summary>
    public int ProjectId { get; set; }
    
    /// <summary>
    /// Gets or sets the project name
    /// </summary>
    public string ProjectName { get; set; }
    
    /// <summary>
    /// Calculates the risk score for this project
    /// </summary>
    /// <returns>Risk score between 0 and 100</returns>
    public int CalculateRiskScore()
    {
        // Implementation
        return 0;
    }
}
```

### Inline Comments

```csharp
// Tek satırlık yorum için
var result = CalculateRisk();

/*
 * Çok satırlı yorum için
 * Created by: Developer Name, 17/12/2024
 * Purpose: Risk calculation for project delays
 * Modified by: Editor Name, 18/12/2024, Added budget factor
 */
```

---

## 🎯 EXCEPTION HANDLING

### Standart Yapı

```csharp
try
{
    // İş mantığı
    await _projectService.CreateProjectAsync(dto);
}
catch (ValidationException vex)
{
    // Validation hataları
    MessageBox.Show($"Validasyon Hatası: {vex.Message}", "Uyarı");
}
catch (Exception ex)
{
    // Genel hatalar
    _logger.LogError(ex, "Unexpected error");
    MessageBox.Show($"Hata: {ex.Message}", "Hata");
}
```

### Exception Değişken İsimleri

```csharp
catch (Exception ex)        // Genel exception
catch (Exception ex1)       // İkinci exception
catch (SqlException sqlEx)  // Özel exception
```

---

## 📊 VERİTABANI STANDARTLARI

### Veritabanı Adı
```
DboProjectTracker ✅
```

### Tablo İsimleri
- **PascalCase** (SQL Server standardı)
- Her kelimenin ilk harfi büyük
- Çoğul

```sql
✅ DOĞRU:
Roles
Users
Projects
Tasks
TaskComments
Notifications

❌ YANLIŞ:
role
user
project
```

### Kolon İsimleri
- **PascalCase**
- Açıklayıcı

```sql
✅ DOĞRU:
ProjectId
ProjectName
StartDate
IsActive
CompletionPercentage

❌ YANLIŞ:
project_id
projectName
start_date
```

---

## 🏗️ PROJE YAPISI

```
ProjectTracker/
├── ProjectTracker.Core/           ✅ Domain Layer
│   ├── Entities/                  (9 sınıf: User, Role, Project, Task, etc.)
│   ├── Enums/                     (4 enum: ProjectStatus, TaskStatus, Priority, NotificationType)
│   └── Interfaces/                (4 arayüz: IRepository, IUnitOfWork, etc.)
│
├── ProjectTracker.Data/           ✅ Data Access Layer
│   ├── Context/                   (AppDbContext + yapılandırma)
│   ├── Repositories/              (3 repository: Generic + özelleştirilmiş)
│   └── Migrations/                (EF Core migrations)
│
├── ProjectTracker.Business/       ✅ Business Logic Layer
│   ├── Services/                  (3 servis: ProjectService, TaskService, UserService)
│   ├── DTOs/                      (8 DTO: Create/Update varyantları)
│   ├── Validators/                (2 validator: FluentValidation kuralları)
│   └── Mappings/                  (AutoMapper profilleri)
│
├── ProjectTracker.UI/             ✅ Presentation Layer  
│   └── Forms/
│       ├── Login/                 (FrmLogin)
│       └── Dashboard/             (FrmDashboard + 5 UserControl)
│           ├── DashboardContent
│           ├── ProjectsContent
│           ├── TasksContent
│           ├── ProjectDetailControl
│           └── TaskDetailControl
│
└── ProjectTracker.Tests/          ✅ Unit Tests
```

---

## ✅ SON KONTROL LİSTESİ

Kod yazmadan önce kontrol et:

- [ ] Class isimleri PascalCase mi?
- [ ] Method isimleri PascalCase mi?
- [ ] Parametreler camelCase mi?
- [ ] Private değişkenler _ ile mi başlıyor?
- [ ] Property'ler PascalCase mi?
- [ ] Interface'ler I ile mi başlıyor?
- [ ] Form isimleri Frm ile mi başlıyor?
- [ ] DevExpress kontroller doğru prefix ile mi?
- [ ] XML comments var mı?
- [ ] Try-catch blokları var mı?
- [ ] Using statements var mı?
- [ ] Async/await doğru kullanılmış mı?

---

**Son Güncelleme**: 29 Aralık 2024
**Proje**: ProjectTracker - Smart Project Management System

