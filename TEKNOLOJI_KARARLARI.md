# TEKNOLOJİ KARARLARI VE PROJE AYRINTILARI

Bu dokümanda ProjectTracker projesi için alınan teknoloji kararları ve proje detayları belirtilmiştir.

**Son Güncelleme:** 2 Ocak 2026

---

## 📋 İÇİNDEKİLER

1. [Teknoloji Stack](#-teknoloji-stack)
2. [Mimari Yaklaşım](#-mimari-yaklaşım)
3. [Proje Yapısı](#-proje-yapısı)
4. [Veritabanı Yapısı](#-veritabanı-yapısı)
5. [Kullanıcı Rolleri](#-kullanıcı-rolleri)
6. [Akıllı Algoritmalar](#-akıllı-algoritmalar)
7. [NuGet Paketleri](#-nuget-paketleri)
8. [UI Standartları](#-ui-standartları)
9. [Güvenlik](#-güvenlik)
10. [Test Stratejisi](#-test-stratejisi)
11. [Geliştirme Takvimi](#-geliştirme-takvimi)
12. [Dokümantasyon Gereksinimleri](#-dokümantasyon-gereksinimleri)
13. [Kurulum Gereksinimleri](#-kurulum-gereksinimleri)

---

## 🛠️ TEKNOLOJİ STACK

### Framework & Runtime

| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| **.NET** | 8.0 | Son versiyon framework, LTS desteği |
| **Windows Forms** | - | Native Windows UI framework |
| **C#** | 12.0 | Modern syntax features (primary constructors, collection expressions) |

### UI Framework

| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| **DevExpress WinForms** | 25.1.7 | Professional UI controls (Lisanslı) |
| - GridControl | - | Data grids, Kanban board |
| - XtraCharts | - | Grafikler ve gauge'lar |
| - XtraEditors | - | Input controls (TextEdit, LookUpEdit, etc.) |
| - XtraScheduler | - | Gantt Chart (planlanan) |

### Database & ORM

| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| **SQL Server** | 2019+ | Microsoft SQL Server RDBMS |
| **Entity Framework Core** | 8.0 | ORM (Code-First yaklaşımı) |
| - SqlServer Provider | 8.0 | SQL Server bağlantısı |
| - Tools | 8.0 | Migration araçları |

### Libraries & Packages

| Kütüphane | Versiyon | Kullanım |
|-----------|----------|----------|
| **AutoMapper** | 12.0.1 | Entity-DTO mapping |
| **FluentValidation** | 12.1.1 | Validation rules |
| **Microsoft.Extensions.DependencyInjection** | 8.0 | IoC Container |
| **Microsoft.Extensions.Configuration** | 8.0 | Configuration management |
| **iTextSharp** | 5.5.13.3 | PDF export |
| **BouncyCastle** | 1.8.9 | PDF şifreleme desteği |
| **Octokit** | 13.0.1 | GitHub API client |

---

## 🏗️ MİMARİ YAKLAŞIM

### Katmanlı Mimari (4 Katman)

```
┌─────────────────────────────────────────────────────────┐
│            PRESENTATION LAYER (UI)                      │
│        Windows Forms + DevExpress Controls              │
│  • Forms: FrmLogin, FrmDashboard, FrmPendingWaitlist   │
│  • UserControls: 12 Content/Detail kontrolü             │
│  • Helpers: ColorPalette, FormStyleHelper, Session      │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│            BUSINESS LAYER                               │
│        Services + DTOs + Validation + Algorithms        │
│  • 12 Service (Project, Task, Team, GitHub, etc.)       │
│  • 20+ DTO (Create/Update/View varyantları)            │
│  • AuditLogService, AdvancedReportService              │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│            DATA ACCESS LAYER                            │
│        Repository Pattern + Unit of Work + EF Core      │
│  • Generic Repository<T>                                │
│  • UnitOfWork (18 Repository)                          │
│  • 5+ Migration                                         │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│            CORE LAYER (Domain)                          │
│        Entities + Enums + Interfaces                    │
│  • 18 Entity sınıfı                                    │
│  • 7 Enum tanımı                                       │
│  • Repository & UoW Interfaces                         │
└─────────────────────────────────────────────────────────┘
```

### Katman Bağımlılıkları

```
UI → Business → Data → Core
     ↓
   Core (tüm katmanlar Core'a bağımlı olabilir)
```

### Design Patterns

| Pattern | Kullanım Yeri | Açıklama |
|---------|---------------|----------|
| **Repository Pattern** | Data Layer | Veri erişim soyutlaması |
| **Unit of Work** | Data Layer | Transaction yönetimi |
| **Dependency Injection** | Tüm katmanlar | Loose coupling |
| **DTO Pattern** | Business Layer | Katmanlar arası veri transferi |
| **Service Pattern** | Business Layer | İş mantığı kapsülleme |
| **Singleton** | UI Layer | SessionManager |

---

## 📁 PROJE YAPISI

```
ProjectTracker/
│
├── src/
│   ├── ProjectTracker.Core/              [Domain Layer]
│   │   ├── Entities/                     [18 Entity sınıfı]
│   │   │   ├── User.cs                   - Kullanıcı entity
│   │   │   ├── Role.cs                   - Rol entity
│   │   │   ├── Project.cs                - Proje entity (TeamId FK)
│   │   │   ├── Task.cs                   - Görev entity (parent-child)
│   │   │   ├── Team.cs                   - Takım entity
│   │   │   ├── TeamMember.cs             - Takım üyesi entity
│   │   │   ├── TeamInvitation.cs         - Davet entity
│   │   │   ├── AuditLog.cs               - Aktivite log entity
│   │   │   ├── ProjectSnapshot.cs        - Burndown snapshot
│   │   │   ├── TimeEntry.cs              - Zaman takibi
│   │   │   ├── TaskComment.cs            - Görev yorumları
│   │   │   ├── ProjectTeamMember.cs      - Proje-Kullanıcı ilişkisi
│   │   │   ├── ProjectRisk.cs            - Risk kayıtları
│   │   │   ├── Notification.cs           - Bildirimler
│   │   │   ├── GitHubToken.cs            - GitHub API token havuzu
│   │   │   ├── GitRepository.cs          - Bağlı GitHub repository'leri
│   │   │   ├── GitCommit.cs              - Commit geçmişi
│   │   │   └── GitFileChange.cs          - Dosya değişiklikleri
│   │   ├── Enums/                        [7 Enum tanımı]
│   │   │   ├── ProjectStatus.cs          - NotStarted, Active, OnHold, Completed, Cancelled
│   │   │   ├── TaskStatus.cs             - Todo, InProgress, Review, Done
│   │   │   ├── Priority.cs               - Low, Medium, High, Critical
│   │   │   ├── TeamRole.cs               - Owner, Admin, Member
│   │   │   ├── ActivityType.cs           - CRUD aktivite tipleri
│   │   │   ├── InvitationStatus.cs       - Pending, Accepted, Rejected, Expired
│   │   │   └── RiskLevel.cs              - Low, Medium, High
│   │   └── Interfaces/                   [Repository & UoW Interfaces]
│   │       ├── IRepository.cs            - Generic repository interface
│   │       ├── IProjectRepository.cs     - Proje özel metodlar
│   │       ├── ITaskRepository.cs        - Görev özel metodlar
│   │       └── IUnitOfWork.cs            - Unit of Work interface
│   │
│   ├── ProjectTracker.Data/              [Data Access Layer]
│   │   ├── Context/
│   │   │   ├── AppDbContext.cs           - EF Core DbContext
│   │   │   └── AppDbContextFactory.cs    - Design-time factory
│   │   ├── Repositories/
│   │   │   ├── Repository.cs             - Generic Repository<T>
│   │   │   ├── ProjectRepository.cs      - Proje repository
│   │   │   └── TaskRepository.cs         - Görev repository
│   │   ├── UnitOfWork.cs                 - UoW implementasyonu
│   │   └── Migrations/                   [EF Core Migrations]
│   │
│   ├── ProjectTracker.Business/          [Business Logic Layer]
│   │   ├── Services/                     [12 Service]
│   │   │   ├── ProjectService.cs         - Proje CRUD + iş mantığı
│   │   │   ├── TaskService.cs            - Görev CRUD + iş mantığı
│   │   │   ├── TeamService.cs            - Takım yönetimi
│   │   │   ├── UserService.cs            - Kullanıcı işlemleri
│   │   │   ├── InvitationService.cs      - Davet sistemi
│   │   │   ├── AuditLogService.cs        - Aktivite loglama
│   │   │   ├── ReportService.cs          - Temel raporlar
│   │   │   ├── AdvancedReportService.cs  - Gelişmiş analitik
│   │   │   ├── TokenPoolService.cs       - GitHub token havuzu yönetimi
│   │   │   ├── TaskMatchingService.cs    - Commit-Task eşleştirme algoritması
│   │   │   ├── GitHubSyncService.cs      - Repository senkronizasyonu
│   │   │   └── GitHubAnalyticsService.cs - GitHub istatistikleri
│   │   ├── DTOs/                         [20+ DTO]
│   │   │   ├── ProjectDto.cs, CreateProjectDto.cs, UpdateProjectDto.cs
│   │   │   ├── TaskDto.cs, CreateTaskDto.cs, UpdateTaskDto.cs
│   │   │   ├── TeamDto.cs, TeamMemberDto.cs, TeamInvitationDto.cs
│   │   │   ├── UserDto.cs, CreateUserDto.cs
│   │   │   ├── ActivityDto.cs            - Audit log DTO
│   │   │   ├── Statistics/               - İstatistik DTO'ları
│   │   │   └── Analytics/                - Analitik DTO'ları
│   │   ├── Interfaces/                   [Service Interfaces]
│   │   │   └── Services/
│   │   │       ├── IProjectService.cs
│   │   │       ├── ITaskService.cs
│   │   │       ├── ITeamService.cs
│   │   │       ├── IUserService.cs
│   │   │       ├── IAuditLogService.cs
│   │   │       ├── ICurrentUserService.cs
│   │   │       └── IReportService.cs
│   │   ├── Validators/                   [FluentValidation]
│   │   │   ├── CreateProjectValidator.cs
│   │   │   ├── CreateTaskValidator.cs
│   │   │   └── CreateUserValidator.cs
│   │   ├── Mappings/                     [AutoMapper]
│   │   │   └── MappingProfile.cs         - Entity-DTO mappings
│   │   └── BackgroundServices/           [Arka plan servisleri]
│   │
│   └── ProjectTracker.UI/                [Presentation Layer]
│       ├── Forms/
│       │   ├── Common/
│       │   │   └── FrmMessage.cs         - Özel mesaj kutusu (dark theme)
│       │   ├── Login/
│       │   │   ├── FrmLogin.cs           - Giriş ekranı
│       │   │   ├── FrmRegister.cs        - Kayıt ekranı
│       │   │   └── FrmPendingWaitlist.cs - Pending rol bekleme ekranı
│       │   └── Dashboard/
│       │       ├── FrmDashboard.cs       - Ana dashboard (sidebar + content)
│       │       └── Content/              [12 UserControl]
│       │           ├── DashboardContent.cs      - KPI'lar, grafikler
│       │           ├── ProjectsContent.cs       - Proje listesi
│       │           ├── ProjectDetailControl.cs  - Proje detay/edit + Task paneli
│       │           ├── TasksContent.cs          - Görev listesi + Kanban
│       │           ├── TaskDetailControl.cs     - Görev detay/edit + Commit paneli
│       │           ├── TeamsContent.cs          - Takım listesi
│       │           ├── TeamDetailControl.cs     - Takım detay/edit
│       │           ├── TeamMembersContent.cs    - Takım üyeleri
│       │           ├── InvitationsContent.cs    - Davetler
│       │           ├── ReportsContent.cs        - Raporlar
│       │           ├── GitHubContent.cs         - GitHub Analytics ekranı
│       │           └── UserSettingsContent.cs   - Kullanıcı ayarları
│       ├── Helpers/
│       │   ├── ColorPalette.cs           - Renk yönetimi (Modern Slate Blue)
│       │   ├── FormStyleHelper.cs        - Mesaj kutuları, stil yardımcıları
│       │   ├── SessionManager.cs         - Oturum yönetimi (Singleton)
│       │   └── CurrentUserService.cs     - DI için kullanıcı servisi
│       ├── appsettings.json              - Connection string, ayarlar
│       └── Program.cs                    - DI Container, uygulama başlatma
│
├── tests/
│   └── ProjectTracker.Tests/             [Unit Tests]
│       ├── Services/                     - Service testleri
│       └── Validators/                   - Validation testleri
│
├── GitHubAnalyzerTest/                   [GitHub API Test Projesi]
│   ├── Services/
│   │   ├── TokenPoolService.cs           - Token havuzu test
│   │   ├── TaskMatchingService.cs        - Eşleştirme algoritması test
│   │   └── GitHubSyncService.cs          - Senkronizasyon test
│   ├── Models/
│   │   └── GitHubModels.cs               - Test modelleri
│   └── Program.cs                        - Test runner
│
├── docs/
│   ├── UML/                              [UML Diyagramları]
│   ├── Screenshots/                      [Ekran Görüntüleri]
│   └── Reports/                          [Proje Raporları]
│
├── SeedDataScript/
│   ├── seed.sql                          - Test verileri
│   └── add_pending_role.sql              - Pending rol script
│
└── bank/                                 [Geliştirme notları ve dökümanlar]
```

---

## 🗄️ VERİTABANI YAPISI

### Veritabanı Bilgileri

| Özellik | Değer |
|---------|-------|
| **Veritabanı Adı** | DboProjectTracker |
| **RDBMS** | SQL Server 2019+ |
| **ORM** | Entity Framework Core 8.0 |
| **Yaklaşım** | Code-First |
| **Tablo Sayısı** | 18 |

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

### Tablolar (18 Tablo)

| # | Tablo | Açıklama | Önemli Kolonlar |
|---|-------|----------|-----------------|
| 1 | **Users** | Sistem kullanıcıları | UserId, Username, Email, PasswordHash, RoleId |
| 2 | **Roles** | Kullanıcı rolleri | RoleId, RoleName (Admin, ProjectManager, Developer, Pending) |
| 3 | **Projects** | Projeler | ProjectId, ProjectName, TeamId, Status, StartDate, EndDate |
| 4 | **Tasks** | Görevler | TaskId, ProjectId, AssignedUserId, ParentTaskId, Status, Priority |
| 5 | **Teams** | Takımlar | TeamId, TeamName, CreatedByUserId |
| 6 | **TeamMembers** | Takım üyeleri | TeamMemberId, TeamId, UserId, TeamRole |
| 7 | **TeamInvitations** | Takım davetleri | InvitationId, TeamId, InvitedUserId, Status |
| 8 | **ProjectTeamMembers** | Proje ekip üyeleri | ProjectId, UserId |
| 9 | **TaskComments** | Görev yorumları | CommentId, TaskId, UserId, Content |
| 10 | **ProjectRisks** | Proje riskleri | RiskId, ProjectId, RiskScore, RiskLevel |
| 11 | **ProjectSnapshots** | Burndown snapshot | SnapshotId, ProjectId, CompletedTasks, TotalTasks |
| 12 | **TimeEntries** | Zaman takibi | TimeEntryId, TaskId, UserId, Hours |
| 13 | **AuditLogs** | Aktivite logları | AuditLogId, ActivityType, EntityName, EntityId, UserId |
| 14 | **Notifications** | Bildirimler | NotificationId, UserId, Message, IsRead |
| 15 | **GitHubTokens** | GitHub API token havuzu | GitHubTokenId, UserId, Token, RateLimitRemaining |
| 16 | **GitRepositories** | Bağlı GitHub repo'ları | GitRepositoryId, ProjectId, RepoUrl, RepoOwner, RepoName |
| 17 | **GitCommits** | Commit geçmişi | GitCommitId, GitRepositoryId, Sha, Message, AuthorName, LinkedTaskId |
| 18 | **GitFileChanges** | Dosya değişiklikleri | GitFileChangeId, GitCommitId, FileName, Additions, Deletions |

### İsimlendirme Kuralları

| Öğe | Kural | Örnek |
|-----|-------|-------|
| Tablo | PascalCase, Çoğul | Users, Projects, Tasks |
| Kolon | PascalCase | ProjectId, ProjectName, CreatedAt |
| Primary Key | [TableName]Id | ProjectId, TaskId, UserId |
| Foreign Key | [ReferencedTable]Id | TeamId, AssignedUserId |

---

## 👥 KULLANICI ROLLERİ

### Rol Tanımları

| Rol | Açıklama | Sistem Erişimi |
|-----|----------|----------------|
| **Admin** | Sistem yöneticisi | Tam erişim |
| **ProjectManager** | Proje yöneticisi | Proje ve takım yönetimi |
| **Developer** | Geliştirici | Atanan görevler |
| **Pending** | Onay bekleyen | Bekleme ekranı |

### Yetki Matrisi

| Özellik | Admin | ProjectManager | Developer | Pending |
|---------|-------|----------------|-----------|---------|
| Kullanıcı Yönetimi | ✅ | ❌ | ❌ | ❌ |
| Tüm Projeleri Görme | ✅ | ❌ | ❌ | ❌ |
| Proje Oluşturma | ✅ | ✅ | ❌ | ❌ |
| Proje Düzenleme | ✅ | ✅ (kendi) | ❌ | ❌ |
| Proje Silme | ✅ | ✅ (kendi) | ❌ | ❌ |
| Görev Oluşturma | ✅ | ✅ | ❌ | ❌ |
| Görev Güncelleme | ✅ | ✅ | ✅ (atanan) | ❌ |
| Takım Oluşturma | ✅ | ✅ | ❌ | ❌ |
| Takım Üyesi Ekleme | ✅ | ✅ (kendi takımı) | ❌ | ❌ |
| Raporları Görme | ✅ | ✅ | ✅ (kendi) | ❌ |
| Dashboard | ✅ | ✅ | ✅ | ❌ |

### Pending Rol Akışı

```
Kayıt → Pending Rol Atanır → FrmPendingWaitlist Gösterilir → Admin Onayı → Developer/PM Rolü
```

---

## 🧠 AKILLI ALGORİTMALAR (Akademik Gereksinim)

### 1. Ağırlıklı Risk Skoru Hesaplama

**Amaç:** Projelerin gecikme riskini hesaplamak

**Formül:**
```
RiskSkoru = (GörevSayısı × 0.3) + 
            ((100 - TamamlanmaOranı) × 0.4) + 
            ((1 / TakımBüyüklüğü) × 0.2) + 
            (BütçeKullanımOranı × 0.3)
```

**Sonuç Değerlendirmesi:**
| Skor Aralığı | Risk Seviyesi | Renk |
|--------------|---------------|------|
| 0-40 | Düşük Risk | 🟢 Yeşil |
| 41-70 | Orta Risk | 🟡 Sarı |
| 71-100 | Yüksek Risk | 🔴 Kırmızı |

**Risk Faktörleri:**
- Görev sayısı çok → Risk artar
- Tamamlanma oranı düşük → Risk artar
- Takım büyük → Risk azalır
- Bütçe aşımı var → Risk artar

### 2. Kritik Yol Analizi (CPM - Critical Path Method)

**Amaç:** Hangi görevlerin projenin süresini doğrudan etkilediğini bulmak

**Algoritma Adımları:**
1. **Forward Pass:** Her görev için en erken başlangıç/bitiş zamanını hesapla
2. **Backward Pass:** Her görev için en geç başlangıç/bitiş zamanını hesapla
3. **Slack Time (Gevşeklik):** `Slack = En Geç Başlangıç - En Erken Başlangıç`
4. **Kritik Görevler:** Slack = 0 olan görevler
5. **Kritik Yol:** Kritik görevlerin zinciri

**Çıktılar:**
- Projenin minimum tamamlanma süresi
- Hangi görevlerin kesinlikle zamanında bitmesi gerektiği
- Gantt Chart'ta kritik görevleri kırmızı renkte gösterme

### 3. Task-Commit Eşleştirme Algoritması (GitHub Entegrasyonu)

**Amaç:** GitHub commit'lerini otomatik olarak ilgili task'lara bağlamak

**Formül:**
```
EşleşmeSkoru = (TaskAdıBenzerliği × 0.4) + 
               (AnahtarKelimeEşleşmesi × 0.3) + 
               (TaskIDEşleşmesi × 0.3)
```

**Algoritma Adımları:**
1. **Task ID Pattern Arama:** Commit mesajında #123, TASK-123, [123] gibi pattern'ler aranır
2. **Kelime Benzerliği:** Task adındaki kelimeler commit mesajında aranır
3. **Levenshtein Distance:** Task adı ile commit mesajı arasındaki benzerlik hesaplanır
4. **Skor Hesaplama:** Tüm faktörler ağırlıklı olarak toplanır
5. **Eşik Kontrolü:** Skor > 0.3 ise eşleşme kabul edilir

**Örnek:**
```
Task: "Login Bug Fix"
Commit: "Fixed login validation bug #42"

TaskIDEşleşmesi: 0.0 (ID eşleşmedi)
AnahtarKelimeEşleşmesi: 0.67 ("login", "bug", "fix" kelimelerinden 2'si eşleşti)
TaskAdıBenzerliği: 0.45 (Levenshtein distance)

Toplam Skor: (0.45 × 0.4) + (0.67 × 0.3) + (0.0 × 0.3) = 0.38 ✅ Eşleşme!
```

### 4. Akıllı Öneri Sistemi (Planlanan)

**Amaç:** Kullanıcıya proaktif öneriler sunmak

**Örnek Öneriler:**
- "Bu projedeki en riskli 3 görev: ..."
- "Ahmet'in iş yükü %150, görevleri yeniden dağıtın"
- "Proje %75 olasılıkla 15 gün gecikecek"
- "Kritik yolda 2 görev var, öncelik verin"

---

## 📦 NUGET PAKETLERİ

### Core Projesi
```xml
<!-- Paket gerekmez - sadece POCO sınıflar -->
```

### Data Projesi
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
```

### Business Projesi
```xml
<PackageReference Include="AutoMapper" Version="12.0.1" />
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
<PackageReference Include="FluentValidation" Version="12.1.1" />
<PackageReference Include="FluentValidation.DependencyInjectionExtensions" Version="12.1.1" />
<PackageReference Include="Octokit" Version="13.0.1" />
```

### UI Projesi
```xml
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration" Version="8.0.0" />
<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="8.0.0" />
<PackageReference Include="iTextSharp" Version="5.5.13.3" />
<PackageReference Include="BouncyCastle" Version="1.8.9" />

<!-- DevExpress 25.1.7 (Lisanslı) -->
<PackageReference Include="DevExpress.Data" Version="25.1.7" />
<PackageReference Include="DevExpress.Utils" Version="25.1.7" />
<PackageReference Include="DevExpress.XtraEditors" Version="25.1.7" />
<PackageReference Include="DevExpress.XtraGrid" Version="25.1.7" />
<PackageReference Include="DevExpress.XtraCharts" Version="25.1.7" />
```

### Test Projesi
```xml
<PackageReference Include="xunit" Version="2.6.2" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.5.4" />
<PackageReference Include="Moq" Version="4.20.70" />
<PackageReference Include="FluentAssertions" Version="6.12.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="8.0.0" />
```

---

## 🎨 UI STANDARTLARI

### Modern Slate Blue Theme

Proje genelinde tutarlı renk kullanımı için `ColorPalette.cs` helper class kullanılır.

### Renk Paleti

#### Background Colors
| Renk | Hex | RGB | Kullanım |
|------|-----|-----|----------|
| BackgroundDeepNavy | #1A1F26 | 26, 31, 38 | Form arka planları |
| BackgroundSlateDark | #242B3D | 36, 43, 61 | Kart ve paneller |
| BackgroundSlateMedium | #1E2A3A | 30, 42, 58 | Input kontrolları |
| BorderSlate | #334155 | 51, 65, 85 | Border ve ayırıcılar |

#### Accent Colors
| Renk | Hex | RGB | Kullanım |
|------|-----|-----|----------|
| AccentRoyalBlue | #5B8DEF | 91, 141, 239 | Primary butonlar |
| AccentSkyBlue | #7BA8F7 | 123, 168, 247 | Hover durumları |

#### Semantic Colors
| Renk | Hex | RGB | Kullanım |
|------|-----|-----|----------|
| SuccessGreen | #22C55E | 34, 197, 94 | Başarılı işlemler |
| WarningOrange | #F59E0B | 245, 158, 11 | Uyarılar |
| DangerRed | #EF4444 | 239, 68, 68 | Hatalar, silme |
| InfoBlue | #3B82F6 | 59, 130, 246 | Bilgi mesajları |

#### Text Colors
| Renk | Hex | RGB | Kullanım |
|------|-----|-----|----------|
| TextPrimary | #F8FAFC | 248, 250, 252 | Başlıklar |
| TextSecondary | #CBD5E1 | 203, 213, 225 | Label'lar |
| TextMuted | #64748B | 100, 116, 139 | Disabled |

### Form İsimlendirme

| Tip | Prefix/Suffix | Örnek |
|-----|---------------|-------|
| Form | Frm | FrmLogin, FrmDashboard, FrmMessage |
| UserControl (Liste) | Content | ProjectsContent, TasksContent |
| UserControl (Detay) | Control | ProjectDetailControl, TaskDetailControl |

### DevExpress Kontrol İsimlendirme

| Kontrol | Prefix | Örnek |
|---------|--------|-------|
| SimpleButton | btn | btnSave, btnCancel, btnDelete |
| TextEdit | txt | txtProjectName, txtSearch |
| MemoEdit | memo | memoDescription |
| DateEdit | date | dateStartDate, dateEndDate |
| LookUpEdit | lue | lueManager, lueTeam |
| ComboBoxEdit | cmb | cmbStatus, cmbPriority, cmbProjectFilter |
| GridControl | grd | grdProjects, grdTasks |
| GridView | gridView | gridView1 |
| CheckEdit | chk | chkIsActive |
| SpinEdit | spin | spinBudget |
| LabelControl | lbl | lblTitle, lblSubtitle |
| PanelControl | pnl | pnlHeader, pnlFilters |

### Özel Mesaj Kutusu (FrmMessage)

Dark-themed özel mesaj kutusu sistemi:

| Tip | Accent Bar Rengi | Kullanım |
|-----|------------------|----------|
| Success | Yeşil (#22C55E) | Başarılı işlemler |
| Error | Kırmızı (#EF4444) | Hata mesajları |
| Warning | Turuncu (#F59E0B) | Uyarılar |
| Info | Mavi (#3B82F6) | Bilgi mesajları |
| Question | Mavi (#5B8DEF) | Yes/No soruları |

**Kullanım:**
```csharp
FormStyleHelper.ShowSuccess("Project created successfully!");
FormStyleHelper.ShowError($"Error: {ex.Message}");
FormStyleHelper.ShowWarning("You don't have permission.");

if (FormStyleHelper.ShowQuestion("Are you sure you want to delete?"))
{
    await DeleteAsync();
}
```

---

## 🔐 GÜVENLİK

### Güvenlik Önlemleri

| Önlem | Açıklama | Uygulama |
|-------|----------|----------|
| **Şifre Hashleme** | SHA256 algoritması | UserService.HashPassword() |
| **Session Yönetimi** | Singleton SessionManager | Oturum bilgileri bellekte |
| **Rol Tabanlı Yetkilendirme** | 4 rol seviyesi | Her işlemde rol kontrolü |
| **SQL Injection Koruması** | EF Core parametreli sorgular | LINQ queries |
| **Audit Logging** | Tüm CRUD işlemleri loglanır | AuditLogService |

### Şifre Hashleme

```csharp
public static string HashPassword(string password)
{
    using var sha256 = SHA256.Create();
    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    return Convert.ToBase64String(hashedBytes);
}
```

### Session Yönetimi

```csharp
// Giriş sonrası
SessionManager.Instance.SetCurrentUser(user);

// Kullanım
var currentUser = SessionManager.Instance.CurrentUser;
var isAdmin = SessionManager.Instance.IsAdmin;
```

---

## 🧪 TEST STRATEJİSİ

### Unit Test Kapsamı

| Katman | Test Edilecek | Framework |
|--------|---------------|-----------|
| Business | Service metodları | xUnit + Moq |
| Business | Validation kuralları | FluentValidation |
| Business | Algoritma metodları | xUnit |
| Data | Repository metodları | InMemory DB |

### Test Senaryoları

#### Proje Testleri
- Proje oluşturma (başarılı/başarısız)
- Proje güncelleme (yetki kontrolü)
- Proje silme (cascade delete)
- Proje listeleme (rol bazlı filtreleme)

#### Görev Testleri
- Görev atama (geçerli/geçersiz kullanıcı)
- Görev durumu güncelleme
- Alt görev oluşturma
- Kanban sürükle-bırak

#### Algoritma Testleri
- Risk skoru hesaplama (farklı senaryolar)
- Kritik yol analizi (basit/karmaşık proje)

#### Kullanıcı Testleri
- Kullanıcı girişi (doğru/yanlış şifre)
- Kayıt (email/username unique kontrolü)
- Rol değişikliği

---

## 📅 GELİŞTİRME TAKVİMİ

### Tamamlanan Phase'ler

| Phase | Süre | Durum | Detay |
|-------|------|-------|-------|
| Phase 1 | 2 gün | ✅ | Login & Auth (FrmLogin, FrmRegister, Session) |
| Phase 2 | 2 gün | ✅ | Dashboard Layout (FrmDashboard, Sidebar, Top bar) |
| Phase 3 | 3 gün | ✅ | Projects Content (CRUD, Filters, Team seçimi) |
| Phase 4 | 3 gün | ✅ | Tasks Content (Grid & Kanban, Drag-drop, Proje filtresi) |
| Phase 5 | 3 gün | ✅ | Team Management (Teams, Members, Invitations) |
| Phase 6 | 3 gün | ✅ | Reports & Analytics (Charts, PDF/Excel export) |
| Phase 6.5 | 1 gün | ✅ | Rol Sistemi (Pending rol, FrmPendingWaitlist) |
| Phase 6.6 | 1 gün | ✅ | Audit Log (AuditLogService, aktivite takibi) |
| Phase 6.7 | 1 gün | ✅ | UI İyileştirmeleri (FrmMessage, ColorPalette) |
| Phase 7 | 2 gün | ✅ | GitHub Entegrasyonu (Repository bağlama, commit analizi, task eşleştirme) |

### Devam Eden Phase'ler

| Phase | Tahmini Süre | Durum | Kapsam |
|-------|--------------|-------|--------|
| Phase 8 | 2 gün | 🔄 | Gantt Chart (CPM algoritması, kritik yol, timeline) |
| Phase 9 | 2 gün | 🔄 | Settings & Notifications (Ayarlar, bildirim sistemi) |
| Phase 10 | 2 gün | 🔄 | Testing & Refinement (Unit tests, bug fixes) |
| Phase 11 | 2 gün | 🔄 | Documentation (UML diyagramları, raporlar) |

### Genel Zaman Çizelgesi

```
Hafta 1: Temel Altyapı
├── Gün 1-2: Proje kurulumu, veritabanı
├── Gün 3-4: Entity'ler, Repository Pattern
├── Gün 5: Service Layer
└── Gün 6-7: Temel UI formları

Hafta 2: Özellikler ve Tamamlama
├── Gün 8-9: Görev yönetimi, Gantt Chart
├── Gün 10: Kullanıcı/Rol yönetimi
├── Gün 11: Dashboard, Akıllı algoritmalar
├── Gün 12: Raporlar, Bildirimler
└── Gün 13-14: Test, dokümantasyon, son rötuşlar
```

---

## 📚 DOKÜMANTASYON GEREKSİNİMLERİ

### Ara Rapor (Hafta 1 Sonu)

| # | İçerik | Durum |
|---|--------|-------|
| 1 | Proje tanıtımı ve amaç | ✅ |
| 2 | Use Case Diagram | 🔄 |
| 3 | Class Diagram (temel) | 🔄 |
| 4 | ER Diagram | 🔄 |
| 5 | İlk ekran görüntüleri | ✅ |
| 6 | Geliştirme süreci | ✅ |

### Final Rapor (Hafta 2 Sonu)

| # | İçerik | Durum |
|---|--------|-------|
| 1 | Tüm UML diyagramları (Use Case, Class, Activity, Sequence) | 🔄 |
| 2 | Modül açıklamaları | 🔄 |
| 3 | Tüm form ekran görüntüleri | 🔄 |
| 4 | Algoritma açıklamaları (Risk + CPM) | ✅ |
| 5 | Test sonuçları | 🔄 |
| 6 | Kurulum kılavuzu | ✅ |
| 7 | Kullanım kılavuzu | 🔄 |
| 8 | Kaynak kodlar (GitHub linki) | ✅ |

### Proje Dökümanları

| Dosya | Açıklama |
|-------|----------|
| README.MD | Proje tanıtımı, kurulum, yapı |
| CODING_STANDARDS.md | Kod standartları |
| TEKNOLOJI_KARARLARI.md | Teknoloji kararları (bu dosya) |
| bank/*.md | Geliştirme notları |

---

## 🚀 KURULUM GEREKSİNİMLERİ

### Geliştirme Ortamı

| Gereksinim | Minimum | Önerilen |
|------------|---------|----------|
| **İşletim Sistemi** | Windows 10 | Windows 11 |
| **IDE** | Visual Studio 2022 (17.8+) | Visual Studio 2022 Enterprise |
| **Framework** | .NET 8 SDK | .NET 8 SDK |
| **Veritabanı** | SQL Server Express 2019 | SQL Server 2019+ |
| **DB Yönetimi** | - | SQL Server Management Studio 20 |
| **UI Kütüphanesi** | DevExpress 25.1.7 Trial | DevExpress 25.1.7 Lisanslı |
| **RAM** | 8 GB | 16 GB |
| **Disk** | 10 GB | 20 GB |

### Üretim Ortamı

| Gereksinim | Değer |
|------------|-------|
| **İşletim Sistemi** | Windows Server 2019+ veya Windows 10/11 |
| **Runtime** | .NET 8 Runtime |
| **Veritabanı** | SQL Server 2019+ |
| **RAM** | Minimum 4 GB |

### Kurulum Adımları

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
   - Connection string'i güncelle: `src/ProjectTracker.UI/appsettings.json`

4. **Migration'ları uygula:**
   ```bash
   dotnet ef database update --project src/ProjectTracker.Data --startup-project src/ProjectTracker.UI
   ```

5. **Seed data'yı yükle (opsiyonel):**
   ```sql
   -- SeedDataScript/seed.sql dosyasını SQL Server'da çalıştır
   ```

6. **Projeyi çalıştır:**
   ```bash
   dotnet run --project src/ProjectTracker.UI
   ```

### Varsayılan Kullanıcılar

| Kullanıcı | Şifre | Rol |
|-----------|-------|-----|
| admin | admin123 | Admin |
| sarah | sarah123 | ProjectManager |
| mike | mike123 | Developer |

---

## 🎓 AKADEMİK DEĞER

### OOP Prensipleri

| Prensip | Uygulama |
|---------|----------|
| **Encapsulation** | Private fields, public properties |
| **Inheritance** | BaseEntity, Repository<T> |
| **Polymorphism** | Interface implementations |
| **Abstraction** | Service interfaces, Repository pattern |

### Design Patterns

| Pattern | Uygulama Yeri |
|---------|---------------|
| Repository | Data Layer |
| Unit of Work | Data Layer |
| Dependency Injection | Tüm katmanlar |
| DTO | Business Layer |
| Singleton | SessionManager |
| Factory | AppDbContextFactory |

### Yazılım Mühendisliği Yöntemleri

| Yöntem | Uygulama |
|--------|----------|
| Katmanlı Mimari | 4 katmanlı yapı |
| Code-First | EF Core Migrations |
| Validation | FluentValidation |
| Mapping | AutoMapper |
| Logging | AuditLogService |
| Testing | xUnit, Moq |

---

**Proje:** YMH 219 Nesne Tabanlı Programlama  
**Dönem:** 2024-2025  
**Geliştirici:** Bilal Abic  
**GitHub:** [@BilalAbic](https://github.com/BilalAbic)

---

**📌 Güncel Durum:** Phase 7 (GitHub Entegrasyonu) tamamlandı  
**📈 İlerleme:** ~75%  
**📅 Son Güncelleme:** 3 Ocak 2026
