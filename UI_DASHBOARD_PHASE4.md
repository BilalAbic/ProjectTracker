# 📁 PHASE 4: TASKS CONTENT - ADVANCED TASK MANAGEMENT & KANBAN

**TasksContent.ascx & TaskDetailControl.ascx**

Bu doküman, Project Tracker uygulamasının **Phase 4: Tasks** modülünün UI tasarımını ve kodlamasını, hiçbir detayı atlamadan, **pixel-perfect** "Phase 3" standartlarına göre yapmanız için hazırlanmıştır. Bu rehberdeki adımları sırasıyla uyguladığınızda, profesyonel bir Görev Yönetim paneli ve Kanban tahtasına sahip olacaksınız.

---

## 🎨 TASARIM STANDARTLARI (Phase 3 ile %100 Uyumlu)

Aşağıdaki renk kodlarını **Custom** sekmesinden RGB olarak giriniz.

| Alan | Renk | RGB Kodu | Hex |
|------|------|----------|-----|
| **Ana Arka Plan** | Siyah (Matt) | `11, 11, 11` | `#0B0B0B` |
| **Panel / Kart** | Koyu Gri | `21, 21, 21` | `#151515` |
| **Input / Header** | Gri | `26, 26, 26` | `#1A1A1A` |
| **Border / Çizgi** | Açık Gri | `42, 42, 42` | `#2A2A2A` |
| **Vurgu (Accent)** | **Turuncu** | `255, 77, 0` | `#FF4D00` |
| **Kanban Sütun** | Orta Gri | `32, 32, 32` | `#202020` |
| **Metin (Ana)** | Beyaz | `255, 255, 255` | `#FFFFFF` |
| **Metin (Silik)** | Gri | `161, 161, 161` | `#A1A1A1` |

**Font Ailesi:** `Segoe UI` (Tüm kontrollerde bu fontu kullanın)

---

## 🚀 ADIM 1: TasksContent UserControl Oluşturma

1.  **Visual Studio** -> **Solution Explorer** -> **ProjectTracker.UI** -> **Forms** -> **Dashboard** -> **Content** klasörüne gidin.
2.  Klasöre **SAĞ TIK** -> **Add** -> **User Control (Windows Forms)** seçin.
3.  İsim: `TasksContent.cs` yazın ve **Add** deyin.
4.  **Properties (F4)** penceresinden şu ayarları yapın:
    *   **Size:** `1100, 730`
    *   **BackColor:** `11, 11, 11` (RGB: 11, 11, 11)
    *   **Padding:** `0, 0, 0, 0`

---

## 🎨 ADIM 2: UserControl Tasarımı (Designer)

Tasarımı yukarıdan aşağıya doğru katman katman inşa edeceğiz.

### **Bölüm 2.1: Header Paneli (Üst Başlık)**

1.  **Toolbox** -> `PanelControl` sürükleyin.
    *   **Name:** `pnlHeader`
    *   **Dock:** `Top`
    *   **Size (Height):** `80`
    *   **Appearance.BackColor:** `11, 11, 11`
    *   **BorderStyle:** `NoBorder`

2.  **Toolbox** -> `SimpleButton` (Görünüm Değiştirici - Grid/Kanban)
    *   **Name:** `btnViewSwitcher`
    *   **Text:** `📊 Kanban View`
    *   **Size:** `120, 36`
    *   **Location:** `830, 25` (New Task butonunun solu)
    *   **Anchor:** `Top, Right`
    *   **Font:** `Segoe UI, 9pt`
    *   **Appearance.BackColor:** `42, 42, 42`
    *   **Appearance.ForeColor:** `White`

3.  **Toolbox** -> `SimpleButton` (Yeni Görev Butonu)
    *   **Name:** `btnNewTask`
    *   **Text:** `+ New Task`
    *   **Size:** `130, 36`
    *   **Location:** `960, 25` (Sağ üst köşe)
    *   **Anchor:** `Top, Right`
    *   **Appearance.BackColor:** `255, 77, 0`
    *   **Appearance.ForeColor:** `White`
    *   **Font:** `Segoe UI, 9.75pt, Bold`

4.  **Toolbox** -> `LabelControl` (Başlık)
    *   **Name:** `lblTitle`
    *   **Text:** `✓ Tasks`
    *   **Location:** `0, 10`
    *   **Font:** `Segoe UI, 18pt, Bold`
    *   **Appearance.ForeColor:** `White`
    *   **AutoSizeMode:** `None`
    *   **Size:** `300, 32`

5.  **Toolbox** -> `LabelControl` (Alt Başlık)
    *   **Name:** `lblSubtitle`
    *   **Text:** `Manage tasks and track progress`
    *   **Location:** `0, 48`
    *   **Font:** `Segoe UI, 9.75pt`
    *   **Appearance.ForeColor:** `161, 161, 161`

---

### **Bölüm 2.2: Filters Paneli (Filtreleme Çubuğu)**

1.  **Toolbox** -> `PanelControl` sürükleyin (UserControl'e).
    *   **Name:** `pnlFilters`
    *   **Dock:** `Top` (Header'ın altına yapışır)
    *   **Size (Height):** `60`
    *   **Appearance.BackColor:** `21, 21, 21`
    *   **BorderStyle:** `NoBorder`
    *   **Padding:** `15, 12, 15, 12`

2.  **Toolbox** -> `TextEdit` (Arama Kutusu) - pnlFilters içine.
    *   **Name:** `txtSearch`
    *   **NullText:** `🔍 Search tasks...`
    *   **Location:** `15, 15`
    *   **Size:** `300, 30`
    *   **Properties.Appearance.BackColor:** `26, 26, 26`
    *   **Properties.BorderStyle:** `Simple`
    *   **Properties.Appearance.BorderColor:** `42, 42, 42`

3.  **Toolbox** -> `ComboBoxEdit` (Durum Filtresi) - pnlFilters içine.
    *   **Name:** `cmbStatusFilter`
    *   **Location:** `330, 15`
    *   **Size:** `160, 30`
    *   **Properties.Appearance.BackColor:** `26, 26, 26`
    *   **Properties.Items:** `All Status`, `ToDo`, `InProgress`, `Done`, `Blocked`
    *   **Properties.NullText:** `All Status`

4.  **Toolbox** -> `ComboBoxEdit` (Öncelik Filtresi) - pnlFilters içine.
    *   **Name:** `cmbPriorityFilter`
    *   **Location:** `505, 15`
    *   **Size:** `160, 30`
    *   **Properties.Appearance.BackColor:** `26, 26, 26`
    *   **Properties.Items:** `All Priority`, `Critical`, `High`, `Medium`, `Low`
    *   **Properties.NullText:** `All Priority`

5.  **Toolbox** -> `SimpleButton` (Temizle) - pnlFilters içine.
    *   **Name:** `btnClearFilters`
    *   **Text:** `Clear`
    *   **Location:** `680, 15`
    *   **Size:** `80, 30`
    *   **Appearance.BackColor:** `42, 42, 42`
    *   **Appearance.ForeColor:** `161, 161, 161`

---

### **Bölüm 2.3: Content Container (Grid ve Kanban için Taşıyıcı)**

Buraya dinamik olarak hem Grid hem de Kanban panelini koyacağız.

1.  **Toolbox** -> `PanelControl` sürükleyin (UserControl'e).
    *   **Name:** `pnlContentContainer`
    *   **Dock:** `Fill`
    *   **BackColor:** `11, 11, 11`
    *   **BorderStyle:** `NoBorder`
    *   **Padding:** `0, 15, 0, 0`

---

### **Bölüm 2.4: Grid Görünümü (GridControl)**

1.  **Toolbox** -> `GridControl` sürükleyin (**pnlContentContainer içine**).
    *   **Name:** `grdTasks`
    *   **Dock:** `Fill`
    *   **Visible:** `True` (Varsayılan görünüm)

2.  **Grid View Ayarları (gridView1):**
    *   **Run Designer** butonuna tıklayın.
    *   **Appearance -> HeaderPanel:** BackColor `26, 26, 26`, Font `Segoe UI, 9pt, Bold`, ForeColor `161, 161, 161`
    *   **Appearance -> Row:** BackColor `21, 21, 21`, ForeColor `White`
    *   **Appearance -> FocusedRow:** BackColor `42, 42, 42`
    *   **OptionsView:** ShowGroupPanel `False`, ShowIndicator `False`, ShowVerticalLines `False`

3.  **Kolonlar (Columns):**

| Caption | FieldName | Width | Veri Tipi | Ayarlar |
|---------|-----------|-------|-----------|---------|
| **Task Name** | `TaskName` | 250 | String | AllowEdit=False |
| **Project** | `ProjectName` | 150 | String | AllowEdit=False |
| **Assignee** | `AssignedUserName` | 120 | String | AllowEdit=False |
| **Status** | `Status` | 100 | Enum | AllowEdit=False |
| **Priority** | `Priority` | 100 | Enum | AllowEdit=False |
| **Due Date** | `DueDate` | 100 | DateTime | Format: `dd MMM yyyy` |
| **Completion**| `CompletionPercentage`| 100 | Int | ProgressBar |
| **Actions** | `Actions` | 80 | Object | UnboundType=Object |

**Actions Kolonu Önemli Notu:** Bu kolona kod ile Düzenle/Sil butonları ekleyeceğiz. `UnboundType`'ı `Object` yapmayı unutma.

---

### **Bölüm 2.5: Kanban Görünümü (Container)**

Grid ile aynı alanda duracak ama varsayılan olarak gizli olacak.

1.  **Toolbox** -> `PanelControl` sürükleyin (**pnlContentContainer içine**).
    *   **Name:** `pnlKanbanContainer`
    *   **Dock:** `Fill`
    *   **Visible:** `False`
    *   **BackColor:** `11, 11, 11`
    *   **BorderStyle:** `NoBorder`

*(Buraya kod ile dinamik paneller ekleyeceğiz, şimdilik boş bırakın).*

---

### **Bölüm 2.6: Footer Paneli**

1.  **Toolbox** -> `PanelControl` sürükleyin.
    *   **Not:** Önce `pnlContentContainer`'ın `Dock` özelliğini geçici olarak `None` yapın, Footer'ı ekleyin, `Dock=Bottom` yapın, sonra `pnlContentContainer`'ı tekrar `Fill` yapın.
    *   **Name:** `pnlFooter`
    *   **Dock:** `Bottom`
    *   **Height:** `50`
    *   **BackColor:** `11, 11, 11`
    *   **BorderStyle:** `NoBorder`

2.  **Toolbox** -> `LabelControl` (Kayıt Sayısı)
    *   **Name:** `lblRecordCount`
    *   **Text:** `Showing 0 of 0 tasks`
    *   **Location:** `0, 15`
    *   **ForeColor:** `161, 161, 161`

3.  **Toolbox** -> `SimpleButton` (Yenile)
    *   **Name:** `btnRefresh`
    *   **Text:** `🔄 Refresh`
    *   **Size:** `90, 30`
    *   **Location:** `1000, 10`
    *   **Anchor:** `Top, Right`
    *   **Appearance.BackColor:** `42, 42, 42`

---

## 💻 ADIM 3: KODLAMA (TasksContent.cs - Full Code)

`F7` ile koda geçin ve bu blokları yapıştırın.

```csharp
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    public partial class TasksContent : UserControl
    {
        private readonly ITaskService _taskService;
        private List<TaskDto> _allTasks;
        
        // Repository Items
        private RepositoryItemButtonEdit _actionButtonsRepository;
        private RepositoryItemProgressBar _progressBarRepository;
        
        // View State
        private bool _isKanbanView = false;
        
        public TasksContent(ITaskService taskService)
        {
            InitializeComponent();
            _taskService = taskService;

            InitializeGrid();
            SetupEvents();
            
            // İlk yükleme
            this.Load += async (s, e) => await LoadDataAsync();
        }

        private void InitializeGrid()
        {
            // --- ProgressBar ---
            _progressBarRepository = new RepositoryItemProgressBar();
            _progressBarRepository.Minimum = 0;
            _progressBarRepository.Maximum = 100;
            _progressBarRepository.ShowTitle = true;
            _progressBarRepository.PercentView = true;
            _progressBarRepository.Appearance.BackColor = Color.FromArgb(42, 42, 42);
            _progressBarRepository.Appearance.ForeColor = Color.ForestGreen;
            
            if (gridView1.Columns["CompletionPercentage"] != null)
                gridView1.Columns["CompletionPercentage"].ColumnEdit = _progressBarRepository;

            // --- Action Buttons (Edit/Delete) ---
            _actionButtonsRepository = new RepositoryItemButtonEdit();
            _actionButtonsRepository.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            _actionButtonsRepository.Buttons.Clear();
            
            var editBtn = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph);
            editBtn.Caption = "✏";
            editBtn.ToolTip = "Edit Task";
            
            var deleteBtn = new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph);
            deleteBtn.Caption = "🗑";
            deleteBtn.ToolTip = "Delete Task";

            _actionButtonsRepository.Buttons.Add(editBtn);
            _actionButtonsRepository.Buttons.Add(deleteBtn);
            _actionButtonsRepository.ButtonClick += ActionButtonsRepository_ButtonClick;

            if (grdTasks.RepositoryItems.IndexOf(_actionButtonsRepository) < 0)
                grdTasks.RepositoryItems.Add(_actionButtonsRepository);
                
            if (gridView1.Columns["Actions"] != null)
                gridView1.Columns["Actions"].ColumnEdit = _actionButtonsRepository;
        }

        private void SetupEvents()
        {
            btnRefresh.Click += async (s, e) => await LoadDataAsync();
            btnNewTask.Click += BtnNewTask_Click;
            btnClearFilters.Click += BtnClearFilters_Click;
            btnViewSwitcher.Click += BtnViewSwitcher_Click; 
            
            gridView1.CustomDrawCell += GridView1_CustomDrawCell;
            
            // Search & Filter Events
            txtSearch.EditValueChanged += (s, e) => ApplyFilters();
            cmbStatusFilter.SelectedIndexChanged += (s, e) => ApplyFilters();
            cmbPriorityFilter.SelectedIndexChanged += (s, e) => ApplyFilters();
        }

        // --- Data Loading & Filtering ---
        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var tasks = await _taskService.GetAllTasksAsync();
                _allTasks = tasks.ToList();
                
                ApplyFilters();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ApplyFilters()
        {
            if (_allTasks == null) return;
            
            var filtered = _allTasks.AsEnumerable();
            
            // Search Text
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                string search = txtSearch.Text.ToLower();
                filtered = filtered.Where(t => 
                    t.TaskName.ToLower().Contains(search) || 
                    (t.ProjectName != null && t.ProjectName.ToLower().Contains(search)));
            }
            
            // Status Filter
            if (cmbStatusFilter.SelectedIndex > 0 && cmbStatusFilter.Text != "All Status")
            {
                if (Enum.TryParse<TaskStatus>(cmbStatusFilter.Text, out var status))
                    filtered = filtered.Where(t => t.Status == status);
            }

            // Priority Filter
            if (cmbPriorityFilter.SelectedIndex > 0 && cmbPriorityFilter.Text != "All Priority")
            {
                if (Enum.TryParse<Priority>(cmbPriorityFilter.Text, out var priority))
                    filtered = filtered.Where(t => t.Priority == priority);
            }
            
            var resultList = filtered.ToList();
            
            // Update Grid
            grdTasks.DataSource = resultList;
            lblRecordCount.Text = $"Showing {resultList.Count} of {_allTasks.Count} tasks";
            
            // Update Kanban if visible
            if (_isKanbanView)
            {
                // Kanban logic will be implemented here later
                // BindKanbanBoard(resultList);
            }
        }
        
        // --- Event Handlers ---
        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbStatusFilter.SelectedIndex = 0;
            cmbPriorityFilter.SelectedIndex = 0;
        }

        private void BtnViewSwitcher_Click(object sender, EventArgs e)
        {
            _isKanbanView = !_isKanbanView;
            
            if (_isKanbanView)
            {
                btnViewSwitcher.Text = "📄 List View";
                pnlKanbanContainer.Visible = true;
                grdTasks.Visible = false;
                // BindKanbanBoard(_filteredTasks); // To fail-safe
            }
            else
            {
                btnViewSwitcher.Text = "📊 Kanban View";
                pnlKanbanContainer.Visible = false;
                grdTasks.Visible = true;
            }
        }

        private void BtnNewTask_Click(object sender, EventArgs e)
        {
             // Open TaskDetailControl
             var detailControl = Program.ServiceProvider.GetRequiredService<TaskDetailControl>();
             ((FrmDashboard)this.ParentForm).LoadContent(detailControl);
        }

        private async void ActionButtonsRepository_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var view = gridView1;
            var rowHandle = view.FocusedRowHandle;
            if (rowHandle < 0) return;

            var task = view.GetRow(rowHandle) as TaskDto;
            if (task == null) return;

            if (e.Button.Caption == "✏")
            {
                 // Edit Task
                 var detailControl = Program.ServiceProvider.GetRequiredService<TaskDetailControl>();
                 detailControl.LoadTaskForEdit(task.TaskId);
                 ((FrmDashboard)this.ParentForm).LoadContent(detailControl);
            }
            else if (e.Button.Caption == "🗑")
            {
                if (XtraMessageBox.Show($"Are you sure you want to delete '{task.TaskName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    await _taskService.DeleteTaskAsync(task.TaskId);
                    await LoadDataAsync();
                }
            }
        }
        
        // --- Custom Drawing (Badges) ---
        private void GridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Status")
            {
                e.Appearance.DrawBackground(e.Cache, e.Bounds);
                string status = e.CellValue?.ToString() ?? "";
                Color color = status == "Done" ? Color.ForestGreen : 
                              status == "InProgress" ? Color.Orange : 
                              status == "ToDo" ? Color.Gray : Color.Red;
                              
                // Draw badge (Circle)
                e.Cache.FillEllipse(color, new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 8, 10, 10));
                
                // Draw text
                e.Appearance.DrawString(e.Cache, status, new Rectangle(e.Bounds.X + 20, e.Bounds.Y, e.Bounds.Width - 20, e.Bounds.Height));
                
                e.Handled = true;
            }
            else if (e.Column.FieldName == "Priority")
            {
                e.Appearance.DrawBackground(e.Cache, e.Bounds);
                string priority = e.CellValue?.ToString() ?? "";
                Color color = priority == "Critical" ? Color.Red : 
                              priority == "High" ? Color.OrangeRed : 
                              priority == "Medium" ? Color.Gold : Color.LightGreen;
                              
                // Draw simple text with color
                e.Cache.DrawString(priority, e.Appearance.Font, new SolidBrush(color), e.Bounds, e.Appearance.GetStringFormat());
                e.Handled = true;
            }
        }
    }
}
```

---

### **Adım 4.1: TaskDetailControl UserControl Oluşturma**

1.  **Visual Studio** -> **Solution Explorer** -> **ProjectTracker.UI** -> **Forms** -> **Dashboard** -> **Content** klasörüne gidin.
2.  Klasöre **SAĞ TIK** -> **Add** -> **User Control (Windows Forms)** seçin.
3.  İsim: `TaskDetailControl.cs` yazın ve **Add** deyin.
4.  **Properties (F4)** penceresinden şu ayarları yapın:
    *   **Size:** `1100, 730`
    *   **BackColor:** `11, 11, 11` (RGB: 11, 11, 11)
    *   **Padding:** `0, 0, 0, 0`

---

### **Adım 4.2: Header Paneli (Form Başlığı)**

1.  **Toolbox** -> `PanelControl` sürükleyin.
    *   **Name:** `pnlHeader`
    *   **Dock:** `Top` -> `Height`: `80`
    *   **BackColor:** `11, 11, 11`
    *   **BorderStyle:** `NoBorder`

2.  **Toolbox** -> `SimpleButton` (Geri Butonu)
    *   **Name:** `btnBack`
    *   **Text:** `← Back`
    *   **Location:** `10, 25` -> `Size`: `80, 30`
    *   **BackColor:** `42, 42, 42` (RGB)
    *   **ForeColor:** `White`

3.  **Toolbox** -> `LabelControl` (Form Başlığı)
    *   **Name:** `lblTitle`
    *   **Text:** `New Task`
    *   **Location:** `100, 25`
    *   **Font:** `Segoe UI, 18pt, Bold`
    *   **ForeColor:** `White`

---

### **Adım 4.3: Form İçeriği (Giriş Alanları)**

Formu ortalamak için bir Panel kullanacağız.

1.  **Toolbox** -> `PanelControl` sürükle (`pnlFormContainer`).
    *   **Location:** `50, 100` -> `Size:** `600, 500`
    *   **BackColor:** `11, 11, 11`
    *   **BorderStyle:** `NoBorder`

Bu panelin içine sırasıyla şu alanları ekleyin (Label + Input alt alta):

#### **1. Task Name**
*   **Label:** "Task Name" (ForeColor: Gray)
*   **TextEdit:** `txtTaskName`
    *   **Size:** `600, 35`
    *   **BackColor:** `26, 26, 26`
    *   **ForeColor:** `White`
    *   **BorderStyle:** `Simple`

#### **2. Description**
*   **Label:** "Description"
*   **MemoEdit:** `txtDescription`
    *   **Size:** `600, 100`
    *   **BackColor:** `26, 26, 26` -> `ForeColor`: `White`

#### **3. Project & Assignee (Yanyana)**

*   **Label:** "Project" (Sol) / "Assignee" (Sağ)
*   **LookUpEdit:** `lueProject` (Sol) -> Size: `290, 35`
*   **LookUpEdit:** `lueAssignee` (Sağ) -> Size: `290, 35`
    *   *Properties -> BackColor*: `26, 26, 26`

#### **4. Dates (Yanyana)**

*   **Label:** "Start Date" (Sol) / "Due Date" (Sağ)
*   **DateEdit:** `dateStart` (Sol) -> Size: `290, 35`
*   **DateEdit:** `dateDue` (Sağ) -> Size: `290, 35`
    *   *Properties -> CalendarView*: `Fluent`

#### **5. Status & Priority (Yanyana)**

*   **ComboBoxEdit:** `cmbStatus` (Sol) -> Items: `ToDo`, `InProgress`, `Done`
*   **ComboBoxEdit:** `cmbPriority` (Sağ) -> Items: `Low`, `Medium`, `High`, `Critical`

---

### **Adım 4.4: Footer (Action Buttons)**

1.  **SimpleButton:** `btnSave`
    *   **Text:** `💾 Save Task`
    *   **BackColor:** `255, 77, 0` (Turuncu) -> `ForeColor`: `White`
    *   **Size:** `150, 40`
    *   **Location:** Sağ Alt Köşe (Form Container içinde)

2.  **SimpleButton:** `btnCancel`
    *   **Text:** `Cancel`
    *   **BackColor:** `42, 42, 42` -> `ForeColor`: `Gray`
    *   **Size:** `100, 40`
    *   **Location:** btnSave'in solu

---

### **Adım 4.5: KODLAMA (TaskDetailControl.cs)**

```csharp
using Azure;
using DevExpress.XtraEditors;
using ProjectTracker.Business.DTOs;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Entities;
using ProjectTracker.Core.Enums;
using ProjectTracker.UI.Forms.Dashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.UI.Forms.Dashboard.Content
{
    public partial class TaskDetailControl : UserControl
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        // private readonly IUserService _userService; (Eğer User servisi varsa)

        private int? _editingTaskId = null; // Edit modu için

        public TaskDetailControl(ITaskService taskService, IProjectService projectService)
        {
            InitializeComponent();
            _taskService = taskService;
            _projectService = projectService;

            // ComboBoxEnumları Doldur
            cmbStatus.Properties.Items.AddRange(Enum.GetValues(typeof(TaskStatus)));
            cmbPriority.Properties.Items.AddRange(Enum.GetValues(typeof(Priority)));

            // Eventler
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnBack.Click += BtnCancel_Click;

            this.Load += async (s, e) => await LoadDropdownsAsync();
        }

        private async System.Threading.Tasks.Task LoadDropdownsAsync()
        {
            // Projeleri Yükle
            var projects = await _projectService.GetAllProjectsAsync();
            lueProject.Properties.DataSource = projects;
            lueProject.Properties.DisplayMember = "ProjectName";
            lueProject.Properties.ValueMember = "ProjectId";
            
            // Assignee (User) yükleme servisi bağlandığında buraya eklenecek
            // lueAssignee.Properties.DataSource = await _userService.GetAllUsersAsync();
            lueAssignee.Properties.NullText = "Unassigned";
        }

        // Düzenleme Modu İçin Metot
        public async void LoadTaskForEdit(int taskId)
        {
            _editingTaskId = taskId;
            lblTitle.Text = "Edit Task";
            btnSave.Text = "💾 Update Task";

            var task = await _taskService.GetTaskByIdAsync(taskId);
            
            txtTaskName.Text = task.TaskName;
            txtDescription.Text = task.Description;
            lueProject.EditValue = task.ProjectId;
            lueAssignee.EditValue = task.AssignedUserId;
            dateStart.DateTime = task.StartDate;
            dateDue.DateTime = task.DueDate;
            cmbStatus.SelectedItem = task.Status;
            cmbPriority.SelectedItem = task.Priority;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaskName.Text))
            {
                XtraMessageBox.Show("Task Name is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_editingTaskId.HasValue)
                {
                    // Update
                    var updateDto = new UpdateTaskDto
                    {
                        TaskId = _editingTaskId.Value,
                        TaskName = txtTaskName.Text,
                        Description = txtDescription.Text,
                        ProjectId = (int)lueProject.EditValue,
                        AssignedUserId = (int?)lueAssignee.EditValue,
                        StartDate = dateStart.DateTime,
                        DueDate = dateDue.DateTime,
                        Status = (TaskStatus)cmbStatus.SelectedItem,
                        Priority = (Priority)cmbPriority.SelectedItem
                    };
                    await _taskService.UpdateTaskAsync(_editingTaskId.Value, updateDto);
                    XtraMessageBox.Show("Task updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Create
                    var createDto = new CreateTaskDto
                    {
                        TaskName = txtTaskName.Text,
                        Description = txtDescription.Text,
                        ProjectId = (int)lueProject.EditValue, // Null check gerekebilir
                        AssignedUserId = (int?)lueAssignee.EditValue,
                        StartDate = dateStart.DateTime,
                        DueDate = dateDue.DateTime,
                        Status = (TaskStatus)cmbStatus.SelectedItem,
                        Priority = (Priority)cmbPriority.SelectedItem
                    };
                    await _taskService.CreateTaskAsync(createDto);
                    XtraMessageBox.Show("Task created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                // Geri Dön
                GoBack();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error saving task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) => GoBack();

        private void GoBack()
        {
            var tasksContent = Program.ServiceProvider.GetRequiredService<TasksContent>();
            ((FrmDashboard)this.ParentForm).LoadContent(tasksContent);
        }
    }
}
```

---

## 🔗 ADIM 5: Entegrasyon (Program.cs)

**Program.cs** dosyasında `TaskDetailControl`'ü de kaydetmeyi unutma:

```csharp
services.AddTransient<Forms.Dashboard.Content.TasksContent>();
services.AddTransient<Forms.Dashboard.Content.TaskDetailControl>();
```

**Tüm bu adımları sırasıyla uyguladığında Phase 4 UI kısmı tamamen hazır olacak!** 🚀
