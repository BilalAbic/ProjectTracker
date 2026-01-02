# 📊 PROJECT TRACKER

### Enterprise Project Management System
*C# Windows Forms + DevExpress + Entity Framework Core 8.0*

---

## 🎯 Proje Özeti

**Project Tracker**, projelerin planlama, yürütme ve izleme süreçlerini tek bir merkezi yapı altında toplayan, akademik gereksinimleri karşılayan bütünleşik bir yazılım çözümüdür. Modern dark theme UI, DevExpress kontrolleri ve akıllı analiz algoritmaları ile profesyonel proje yönetimi deneyimi sunar.

### ✨ Temel Özellikler

| Özellik | Açıklama | Durum |
|---------|----------|-------|
| 📁 **Proje Yönetimi** | Proje oluşturma, düzenleme, durum takibi, takım ataması | ✅ |
| ✅ **Görev Yönetimi** | Alt görevler, atamalar, Kanban board, ilerleme izleme | ✅ |
| 👥 **Takım Yönetimi** | Takım oluşturma, üye yönetimi, davet sistemi, rol atama | ✅ |
| 🔐 **Rol Tabanlı Yetkilendirme** | Admin, ProjectManager, Developer, Pending rolleri | ✅ |
| �  **Raporlama & Analytics** | Performans grafikleri, durum raporları, PDF/Excel export | ✅ |
| 📝 **Audit Log Sistemi** | Aktivite takibi, değişiklik geçmişi | ✅ |
| 🎨 **Modern Dashboard** | Anlık KPI'lar, interaktif grafikler, dark theme UI | ✅ |
| � **RÖzel Mesaj Kutusu** | Dark-themed, renk kodlu mesaj sistemi | ✅ |
| 📈 **Gantt Chart** | Görsel zaman çizelgesi, kritik yol analizi (CPM) | 🔄 |
| ⚠️ **Risk Analizi** | Ağırlıklı risk skoru, gecikme tahminleri | 🔄 |
| 🔔 **Bildirim Sistemi** | Otomatik uyarılar, deadline hatırlatmaları | 🔄 |

---

## 🏗️ Mimari Yapı

### Katmanlı Mimari (4 Katman)

```
┌─────────────────────────────────────────────────────────┐
│            PRESENTATION LAYER (UI)                      │
│        Windows Forms + DevExpress Controls              │
│  • Forms: FrmLogin, FrmDashboard, FrmPendingWaitlist   │
│  • UserControls: 10 Content/Detail kontrolü             │
│  • Helpers: ColorPalette, FormStyleHelper, Session      │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│            BUSINESS LAYER                               │
│        Services + DTOs + Validation + Algorithms        │
│  • 8 Service (Project, Task, Team, User, Report, etc.) │
│  • 16 DTO (Create/Update/View varyantları)             │
│  • AuditLogService, AdvancedReportService              │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│            DATA ACCESS LAYER                            │
│        Repository Pattern + Unit of Work + EF Core      │
│  • Generic Repository<T>                                │
│  • UnitOfWork (14 Repository)                          │
│  • 4 Migration                                          │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│            DATABASE                                     │
│                SQL Server 2019+                         │
│  • 14 Tablo                                            │
│  • Navigation Properties                                │
│  • Audit Logging                                        │
└─────────────────────────────────────────────────────────┘
```

### 📁 Klasör Yapısı

```
ProjectTracker/
│
├── src/
│   ├── ProjectTracker.Core/              [Domain Layer]
│   │   ├── Entities/                     [14 Entity sınıfı]
│   │   │   ├── User.cs
│   │   │   ├── Role.cs
│   │   │   ├── Project.cs
│   │   │   ├── Task.cs
│   │   │   ├── Team.cs
│   │   │   ├── TeamMember.cs
│   │   │   ├── TeamInvitation.cs
│   │   │   ├── AuditLog.cs
│   │   │   ├── ProjectSnapshot.cs
│   │   │   ├── TimeEntry.cs
│   │   │   └── ...
│   │   ├── Enums/                        [7 Enum tanımı]
│   │   │   ├── ProjectStatus.cs
│   │   │   ├── TaskStatus.cs
│   │   │   ├── Priority.cs
│   │   │   ├── TeamRole.cs
│   │   │   ├── ActivityType.cs
│   │   │   └── ...
│   │   └── Interfaces/                   [Repository & UoW]
│   │
│   ├── ProjectTracker.Data/              [Data Access Layer]
│   │   ├── Context/
│   │   │   ├── AppDbContext.cs
│   │   │   └── AppDbContextFactory.cs
│   │   ├── Repositories/
│   │   │   ├── Repository.cs (Generic)
│   │   │   ├── ProjectRepository.cs
│   │   │   └── TaskRepository.cs
│   │   ├── UnitOfWork.cs
│   │   └── Migrations/                   [4 Migration]
│   │
│   ├── ProjectTracker.Business/          [Business Logic Layer]
│   │   ├── Services/                     [8 Service]
│   │   │   ├── ProjectService.cs
│   │   │   ├── TaskService.cs
│   │   │   ├── TeamService.cs
│   │   │   ├── UserService.cs
│   │   │   ├── InvitationService.cs
│   │   │   ├── AuditLogService.cs
│   │   │   ├── ReportService.cs
│   │   │   └── AdvancedReportService.cs
│   │   ├── DTOs/                         [16 DTO]
│   │   │   ├── ProjectDto.cs, CreateProjectDto.cs, UpdateProjectDto.cs
│   │   │   ├── TaskDto.cs, CreateTaskDto.cs, UpdateTaskDto.cs
│   │   │   ├── TeamDto.cs, TeamMemberDto.cs, TeamInvitationDto.cs
│   │   │   ├── ActivityDto.cs
│   │   │   ├── Statistics/               [İstatistik DTO'ları]
│   │   │   └── Analytics/                [Analitik DTO'ları]
│   │   ├── Interfaces/                   [Service Interfaces]
│   │   │   └── Services/
│   │   │       ├── IProjectService.cs
│   │   │       ├── ITaskService.cs
│   │   │       ├── ITeamService.cs
│   │   │       ├── IAuditLogService.cs
│   │   │       ├── ICurrentUserService.cs
│   │   │       └── ...
│   │   ├── Validators/                   [FluentValidation]
│   │   ├── Mappings/                     [AutoMapper]
│   │   └── BackgroundServices/           [Arka plan servisleri]
│   │
│   └── ProjectTracker.UI/                [Presentation Layer]
│       ├── Forms/
│       │   ├── Common/
│       │   │   └── FrmMessage.cs         [Özel mesaj kutusu]
│       │   ├── Login/
│       │   │   ├── FrmLogin.cs
│       │   │   ├── FrmRegister.cs
│       │   │   └── FrmPendingWaitlist.cs [Pending rol bekleme]
│       │   └── Dashboard/
│       │       ├── FrmDashboard.cs
│       │       └── Content/              [10 UserControl]
│       │           ├── DashboardContent.cs
│       │           ├── ProjectsContent.cs
│       │           ├── ProjectDetailControl.cs
│       │           ├── TasksContent.cs
│       │           ├── TaskDetailControl.cs
│       │           ├── TeamsContent.cs
│       │           ├── TeamDetailControl.cs
│       │           ├── TeamMembersContent.cs
│       │           ├── InvitationsContent.cs
│       │           └── ReportsContent.cs
│       ├── Helpers/
│       │   ├── ColorPalette.cs           [Renk yönetimi]
│       │   ├── FormStyleHelper.cs        [Mesaj kutuları]
│       │   ├── SessionManager.cs         [Oturum yönetimi]
│       │   └── CurrentUserService.cs     [DI için kullanıcı servisi]
│       └── Program.cs                    [DI Container]
│
├── tests/
│   └── ProjectTracker.Tests/             [Unit Tests]
│
├── docs/
│   ├── UML/                              [UML Diyagramları]
│   ├── Screenshots/                      [Ekran Görüntüleri]
│   └── Reports/                          [Proje Raporları]
│
├── SeedDataScript/
│   ├── seed.sql                          [Test verileri]
│   └── add_pending_role.sql              [Pending rol script]
│
└── bank/                                 [Geliştirme notları]
```

---

## 💻 Teknoloji Stack

### Framework & Runtime
| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| .NET | 8.0 | Son versiyon framework |
| Windows Forms | - | Native UI framework |
| C# | 12.0 | Modern syntax features |

### UI Framework
| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| DevExpress WinForms | 25.1.7 | Professional UI controls |
| - GridControl | - | Data grids, Kanban |
| - Charts & Gauges | - | Grafikler |
| - XtraEditors | - | Input controls |

### Database & ORM
| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| SQL Server | 2019+ | RDBMS |
| Entity Framework Core | 8.0 | ORM (Code-First) |

### Libraries
| Kütüphane | Versiyon | Kullanım |
|-----------|----------|----------|
| AutoMapper | 12.0.1 | DTO mapping |
| FluentValidation | 12.1.1 | Validation rules |
| Microsoft.Extensions.DependencyInjection | 8.0 | IoC Container |
| iTextSharp | 5.5.13.3 | PDF export |
| BouncyCastle | 1.8.9 | PDF şifreleme |

---

## 📦 Veritabanı Şeması

### Entity İlişkileri

```
┌──────────┐       ┌──────────┐       ┌──────────┐
│  Roles   │───────│  Users   │───────│  Teams   │
└──────────┘       └────┬─────┘       └────┬─────┘
                        │                   │
         ┌──────────────┼───────────────────┤
         │              │                   │
    ┌────▼────┐    ┌────▼────┐    ┌────────▼────────┐
    │Projects │    │  Tasks  │    │  TeamMembers    │
    │(TeamId) │    │         │    │  TeamInvitations│
    └────┬────┘    └────┬────┘    └─────────────────┘
         │              │
    ┌────▼──────────────▼────────────────┐
    │  ProjectTeamMembers                 │
    │  TaskComments                       │
    │  ProjectRisks                       │
    │  ProjectSnapshots                   │
    │  TimeEntries                        │
    │  AuditLogs                          │
    └─────────────────────────────────────┘
```

### Tablolar (14 tablo)

| # | Tablo | Açıklama |
|---|-------|----------|
| 1 | **Users** | Kullanıcılar |
| 2 | **Roles** | Roller (Admin, ProjectManager, Developer, Pending) |
| 3 | **Projects** | Projeler (TeamId ile takıma bağlı) |
| 4 | **Tasks** | Görevler (parent-child destekli) |
| 5 | **Teams** | Takımlar |
| 6 | **TeamMembers** | Takım üyeleri ve rolleri |
| 7 | **TeamInvitations** | Takım davet sistemi |
| 8 | **ProjectTeamMembers** | Proje ekip üyeleri |
| 9 | **TaskComments** | Görev yorumları |
| 10 | **ProjectRisks** | Proje riskleri |
| 11 | **ProjectSnapshots** | Burndown/Burnup için snapshot |
| 12 | **TimeEntries** | Zaman takibi |
| 13 | **AuditLogs** | Aktivite logları |
| 14 | **Notifications** | Bildirimler |

---

## 👥 Kullanıcı Rolleri ve Yetkileri

| Rol | Yetkiler | Kısıtlamalar |
|-----|----------|--------------|
| **Admin** | • Tüm yetkiler<br>• Kullanıcı yönetimi<br>• Sistem ayarları<br>• Tüm projeleri görme | - |
| **ProjectManager** | • Proje CRUD<br>• Görev atama<br>• Takım yönetimi<br>• Raporlar | Kullanıcı ekleme/silme yapamaz |
| **Developer** | • Atanan görevleri güncelleme<br>• Yorum yazma<br>• Kendi takım projelerini görme | Proje/Task oluşturamaz/silemez |
| **Pending** | • Bekleme ekranı | Onay bekliyor, sisteme erişim yok |

---

## 🎨 UI Tasarımı

### Modern Slate Blue Theme

Proje genelinde tutarlı renk kullanımı için `ColorPalette.cs` helper class kullanılır.

#### Core Background Colors
| Element | Hex | Kullanım |
|---------|-----|----------|
| BackgroundDeepNavy | `#1A1F26` | Form backgrounds |
| BackgroundSlateDark | `#242B3D` | Cards, panels |
| BackgroundSlateMedium | `#1E2A3A` | Input backgrounds |
| BorderSlate | `#334155` | Borders |

#### Accent Colors
| Purpose | Hex | Kullanım |
|---------|-----|----------|
| AccentRoyalBlue | `#5B8DEF` | Primary buttons |
| AccentSkyBlue | `#7BA8F7` | Hover states |
| SuccessGreen | `#22C55E` | Success messages |
| WarningOrange | `#F59E0B` | Warnings |
| DangerRed | `#EF4444` | Errors, delete |

### Özel Mesaj Kutusu Sistemi (FrmMessage)

Dark-themed özel mesaj kutusu:
- **Success**: Yeşil accent bar
- **Error**: Kırmızı accent bar
- **Warning**: Turuncu accent bar
- **Info**: Mavi accent bar

```csharp
// Kullanım
FormStyleHelper.ShowSuccess("İşlem başarılı!");
FormStyleHelper.ShowError("Hata oluştu!");
FormStyleHelper.ShowQuestion("Silmek istediğinize emin misiniz?");
```

---

## 🚀 Geliştirme Roadmap

### ✅ Tamamlanan Phase'ler

| Phase | Durum | Detay |
|-------|-------|-------|
| **Phase 1:** Login & Auth | ✅ | FrmLogin, FrmRegister, Session yönetimi |
| **Phase 2:** Dashboard Layout | ✅ | FrmDashboard, Sidebar, Top bar |
| **Phase 3:** Projects Content | ✅ | ProjectsContent, CRUD, Filters, Team seçimi |
| **Phase 4:** Tasks Content | ✅ | TasksContent, Grid & Kanban, Drag-drop, Proje filtresi |
| **Phase 5:** Team Management | ✅ | TeamsContent, Members, Invitations |
| **Phase 6:** Reports & Analytics | ✅ | ReportsContent, Charts, PDF/Excel export |
| **Phase 6.5:** Rol Sistemi | ✅ | Pending rol, FrmPendingWaitlist, yetki kontrolleri |
| **Phase 6.6:** Audit Log | ✅ | AuditLogService, aktivite takibi |
| **Phase 6.7:** UI İyileştirmeleri | ✅ | FrmMessage, ColorPalette, FormStyleHelper |

### 🔄 Devam Eden Phase'ler

| Phase | Durum | Kapsam |
|-------|-------|--------|
| **Phase 7:** Gantt Chart | 🔄 | CPM algoritması, kritik yol, timeline |
| **Phase 8:** Settings & Notifications | 🔄 | Ayarlar, bildirim sistemi |
| **Phase 9:** Testing & Refinement | 🔄 | Unit tests, bug fixes |
| **Phase 10:** Documentation | 🔄 | UML diyagramları, raporlar |

---

## 🛠️ Kurulum

### Gereksinimler

- **Windows 10/11** (64-bit)
- **Visual Studio 2022** Community veya üzeri
- **SQL Server 2019+** veya SQL Server Express
- **.NET 8.0 SDK**
- **DevExpress License** (Trial veya Full)

### Adımlar

1. **Repository'yi klonla:**
   ```bash
   git clone https://github.com/BilalAbic/ProjectTracker.git
   cd ProjectTracker
   ```

2. **NuGet paketlerini geri yükle:**
   ```bash
   dotnet restore
   ```

3. **Veritabanını oluştur:**
   - SQL Server'da yeni bir database oluştur: `DboProjectTracker`
   - Connection string'i güncelle: `appsettings.json`

4. **Migration'ları uygula:**
   ```bash
   dotnet ef database update --project src/ProjectTracker.Data --startup-project src/ProjectTracker.UI
   ```

5. **Seed data'yı yükle (opsiyonel):**
   ```bash
   # SeedDataScript/seed.sql dosyasını SQL Server'da çalıştır
   ```

6. **Projeyi çalıştır:**
   ```bash
   dotnet run --project src/ProjectTracker.UI
   ```

7. **Varsayılan kullanıcılar:**
   | Kullanıcı | Şifre | Rol |
   |-----------|-------|-----|
   | admin | admin123 | Admin |
   | sarah | sarah123 | ProjectManager |
   | mike | mike123 | Developer |

---

## 🧠 Akıllı Algoritmalar

### 1. Ağırlıklı Risk Skoru Hesaplama

```
RiskSkoru = (GörevSayısı × 0.3) + 
            ((100 - TamamlanmaOranı) × 0.4) + 
            ((1 / TakımBüyüklüğü) × 0.2) + 
            (BütçeKullanımOranı × 0.3)

Sonuç: 0-100 arası risk puanı
• 0-40:   Düşük Risk (🟢)
• 41-70:  Orta Risk (🟡)
• 71-100: Yüksek Risk (🔴)
```

### 2. Kritik Yol Analizi (CPM)

1. **Forward Pass:** En erken başlangıç/bitiş zamanı
2. **Backward Pass:** En geç başlangıç/bitiş zamanı
3. **Slack Time:** `Slack = En Geç - En Erken`
4. **Kritik Görevler:** Slack = 0

---

## 🎓 Akademik Değer

| Gereksinim | Durum | Detay |
|------------|-------|-------|
| OOP Prensipleri | ✅ | Encapsulation, Inheritance, Polymorphism |
| Design Patterns | ✅ | Repository, Unit of Work, DI, DTO |
| Katmanlı Mimari | ✅ | 4 katmanlı yapı |
| Akıllı Algoritma | ✅ | Risk Skoru, CPM |
| Test & Validation | ✅ | FluentValidation, Unit Tests |
| Dokümantasyon | ✅ | XML comments, UML, Raporlar |

---

## 📚 Dokümantasyon

- **[CODING_STANDARDS.md](CODING_STANDARDS.md)** - Kod standartları
- **[TEKNOLOJI_KARARLARI.md](TEKNOLOJI_KARARLARI.md)** - Teknoloji kararları

---

## 👨‍💻 Geliştirici

**Proje:** YMH 219 Nesne Tabanlı Programlama  
**Dönem:** 2024-2025  
**Geliştirici:** Bilal Abic  
**GitHub:** [@BilalAbic](https://github.com/BilalAbic)

---

**📌 Güncel Durum:** Phase 6.7 tamamlandı  
**📈 İlerleme:** ~70%  
**📅 Son Güncelleme:** 2 Ocak 2026

🚀 **Happy Coding!**
