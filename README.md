# 📊 PROJECT TRACKER

### Kurumsal Proje Yönetim Sistemi
*C# Windows Forms + DevExpress + Entity Framework Core 8.0 + ASP.NET Core Web API*

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![DevExpress](https://img.shields.io/badge/DevExpress-25.1.7-FF7200?logo=devexpress)](https://www.devexpress.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019+-CC2927?logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](LICENSE.txt)

---

## 📋 İçindekiler

- [Proje Özeti](#-proje-özeti)
- [Canlı Demo & Linkler](#-canlı-demo--linkler)
- [Özellikler](#-özellikler)
- [Ekran Görüntüleri](#-ekran-görüntüleri)
- [Sistem Mimarisi](#-sistem-mimarisi)
- [Teknoloji Stack](#-teknoloji-stack)
- [Veritabanı Tasarımı](#-veritabanı-tasarımı)
- [Proje Yapısı](#-proje-yapısı)
- [Kurulum](#-kurulum)
- [API Dokümantasyonu](#-api-dokümantasyonu)
- [Kullanıcı Rolleri](#-kullanıcı-rolleri)
- [Tasarım Kalıpları](#-tasarım-kalıpları)
- [UI Tema Sistemi](#-ui-tema-sistemi)
- [Sürüm Notları](#-sürüm-notları)
- [Geliştirici](#-geliştirici)

---

## 🎯 Proje Özeti

**Project Tracker**, projelerin planlama, yürütme ve izleme süreçlerini tek bir merkezi yapı altında toplayan, akademik gereksinimleri karşılayan bütünleşik bir yazılım çözümüdür.

### Temel Hedefler
- 📁 Projelerin merkezi yönetimi ve takibi
- ✅ Görevlerin hiyerarşik organizasyonu (ana görev - alt görev)
- 👥 Takım işbirliği ve üye yönetimi
- 📊 Veri odaklı karar destek mekanizmaları
- 🔐 Rol tabanlı yetkilendirme sistemi
- 🐙 GitHub entegrasyonu ile geliştirici performans analizi

### Akademik Gereksinimler
Bu proje **YMH 219 Nesne Tabanlı Programlama** dersi kapsamında geliştirilmiştir:
- ✅ 4 Katmanlı Mimari (N-Tier Architecture)
- ✅ SOLID Prensipleri
- ✅ Repository & Unit of Work Pattern
- ✅ Dependency Injection
- ✅ Akıllı Algoritmalar (Risk Skoru, Task-Commit Eşleştirme)

---

## 🌐 Canlı Demo & Linkler

| Platform | URL | Açıklama |
|----------|-----|----------|
| 🌍 **Web Sitesi** | [pt.bilalabic.com](https://pt.bilalabic.com) | Custom domain ile barındırılan tanıtım sitesi |
| 🔌 **API** | [bilalabic.com/api](https://bilalabic.com/api) | Plesk'te barındırılan ASP.NET Core Web API |
| 📦 **İndirme** | [GitHub Releases](https://github.com/BilalAbic/ProjectTracker/releases/latest) | Windows masaüstü uygulaması |
| 📂 **Kaynak Kod** | [github.com/BilalAbic/ProjectTracker](https://github.com/BilalAbic/ProjectTracker) | Ana repository |
| 🌐 **Web Branch** | [web-github-pages](https://github.com/BilalAbic/ProjectTracker/tree/web-github-pages) | Web sitesi kaynak kodları |

---

## ✨ Özellikler

### 📁 Proje Yönetimi
| Özellik | Açıklama | Durum |
|---------|----------|-------|
| Proje CRUD | Proje oluşturma, düzenleme, silme | ✅ |
| Durum Takibi | Planned, Active, OnHold, Completed, Cancelled | ✅ |
| Önceliklendirme | Low, Medium, High, Critical seviyeleri | ✅ |
| Bütçe Yönetimi | Proje bütçesi ve maliyet takibi | ✅ |
| İlerleme Takibi | Otomatik tamamlanma yüzdesi hesaplama | ✅ |
| Risk Analizi | Akıllı risk skoru algoritması (0-100) | ✅ |
| GitHub Bağlantısı | Repository URL ile entegrasyon | ✅ |

### ✅ Görev Yönetimi
| Özellik | Açıklama | Durum |
|---------|----------|-------|
| Görev CRUD | Görev oluşturma, atama, güncelleme | ✅ |
| Alt Görevler | Hiyerarşik görev yapısı (Parent-Child) | ✅ |
| Kanban Board | Sürükle-bırak ile durum değiştirme | ✅ |
| Grid View | Filtrelenebilir ve sıralanabilir liste | ✅ |
| Zaman Takibi | Tahmini ve gerçek süre karşılaştırması | ✅ |
| Görev Yorumları | Görevlere yorum ekleme | ✅ |
| Kritik Yol | CPM algoritması ile kritik görev belirleme | 🔄 |

### 👥 Takım Yönetimi
| Özellik | Açıklama | Durum |
|---------|----------|-------|
| Takım Oluşturma | Yeni takım/workspace oluşturma | ✅ |
| Üye Yönetimi | Üye ekleme, çıkarma, rol değiştirme | ✅ |
| E-posta Davet | Gmail SMTP ile HTML davet e-postası | ✅ |
| Web Davet Kabul | GitHub Pages üzerinden davet kabul | ✅ |
| Takım Rolleri | Owner, Admin, Member rolleri | ✅ |
| Davet Durumu | Pending, Accepted, Rejected, Expired | ✅ |

### 🐙 GitHub Entegrasyonu
| Özellik | Açıklama | Durum |
|---------|----------|-------|
| Repository Bağlama | Projeye GitHub repo bağlama | ✅ |
| Commit Senkronizasyonu | Commit'leri yerel DB'ye çekme | ✅ |
| Task-Commit Eşleştirme | Akıllı algoritma ile otomatik eşleştirme | ✅ |
| Geliştirici Analizi | Commit sayısı, kod değişiklikleri | ✅ |
| Token Havuzu | Çoklu GitHub token yönetimi | ✅ |
| Rate Limit Yönetimi | API limit takibi ve optimizasyonu | ✅ |

### 📊 Raporlama & Analytics
| Özellik | Açıklama | Durum |
|---------|----------|-------|
| Dashboard KPI'ları | Anlık proje ve görev istatistikleri | ✅ |
| Durum Grafikleri | Pie chart ile durum dağılımı | ✅ |
| Trend Analizi | Zaman bazlı ilerleme grafikleri | ✅ |
| PDF Export | iTextSharp ile rapor oluşturma | ✅ |
| Excel Export | EPPlus ile veri dışa aktarma | ✅ |
| Audit Log | Tüm aktivitelerin kaydı | ✅ |

### 🔐 Güvenlik & Yetkilendirme
| Özellik | Açıklama | Durum |
|---------|----------|-------|
| Rol Tabanlı Erişim | Admin, ProjectManager, Developer, Pending | ✅ |
| Şifre Hashleme | BCrypt algoritması | ✅ |
| Session Yönetimi | Güvenli oturum kontrolü | ✅ |
| Takım Bazlı İzinler | Takım üyeliğine göre veri erişimi | ✅ |

### 🎨 Kullanıcı Arayüzü
| Özellik | Açıklama | Durum |
|---------|----------|-------|
| Modern Dark Theme | Slate Blue renk paleti | ✅ |
| DevExpress Kontrolleri | Profesyonel UI bileşenleri | ✅ |
| Responsive Tasarım | Farklı ekran boyutlarına uyum | ✅ |
| Özel Mesaj Kutusu | Dark-themed, hata kodlu mesajlar | ✅ |
| WCAG 2.1 Uyumlu | Erişilebilirlik standartları | ✅ |

---

## 📸 Ekran Görüntüleri

### Giriş Ekranı
![Login Form](docs/Screenshots/LoginFormLeft.png)

> 📌 **Not:** Daha fazla ekran görüntüsü yakında eklenecektir.

---

## 🏗️ Sistem Mimarisi

### Genel Bakış

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                            KULLANICI ARAYÜZÜ                                │
├─────────────────────────────────────────────────────────────────────────────┤
│  Windows Forms (WinForms)              │  Web Sitesi (GitHub Pages)         │
│  ├── FrmLogin                          │  ├── index.html (Tanıtım)          │
│  ├── FrmRegister                       │  └── accept-invite.html (Davet)    │
│  ├── FrmDashboard                      │                                    │
│  │   ├── DashboardContent              │  Teknoloji:                        │
│  │   ├── ProjectsContent               │  • HTML5 / CSS3 / JavaScript       │
│  │   ├── TasksContent (Kanban/Grid)    │  • Vanilla JS (Framework yok)      │
│  │   ├── TeamsContent                  │  • Responsive Design               │
│  │   ├── ReportsContent                │                                    │
│  │   ├── GitHubContent                 │                                    │
│  │   └── UserSettingsContent           │                                    │
│  └── DevExpress UI Controls            │                                    │
└─────────────────────────────────────────────────────────────────────────────┘
                         │                                    │
                         ▼                                    ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                           BACKEND SERVİSLERİ                                │
├─────────────────────────────────────────────────────────────────────────────┤
│  Business Layer (14 Service)           │  Web API (ASP.NET Core 8.0)        │
│  ├── ProjectService                    │  ├── InvitationsController         │
│  ├── TaskService                       │  │   ├── POST /create              │
│  ├── TeamService                       │  │   ├── GET /validate             │
│  ├── UserService                       │  │   ├── POST /accept              │
│  ├── InvitationService                 │  │   ├── POST /decline             │
│  ├── EmailService (Gmail SMTP)         │  │   └── GET /health               │
│  ├── RemoteInvitationService           │  │                                 │
│  ├── GitHubSyncService                 │  └── Swagger UI (Development)      │
│  ├── GitHubAnalyticsService            │                                    │
│  ├── TokenPoolService                  │  Hosting: Plesk (IIS)              │
│  ├── TaskMatchingService               │  URL: bilalabic.com/api            │
│  ├── ReportService                     │                                    │
│  ├── AuditLogService                   │                                    │
│  └── AdvancedReportService             │                                    │
└─────────────────────────────────────────────────────────────────────────────┘
                         │                                    │
                         ▼                                    ▼
┌─────────────────────────────────────────────────────────────────────────────┐
│                          VERİTABANI KATMANI                                 │
├─────────────────────────────────────────────────────────────────────────────┤
│  Yerel SQL Server                      │  Uzak SQL Server (Plesk)           │
│  ├── 18 Tablo                          │  └── Invitations (tek tablo)       │
│  ├── Entity Framework Core 8.0         │                                    │
│  ├── Code-First Migrations             │  EnsureCreated() ile               │
│  └── Lazy Loading (Proxies)            │  otomatik tablo oluşturma          │
└─────────────────────────────────────────────────────────────────────────────┘
```

### Davet Sistemi Akışı

```
┌──────────────┐     ┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│   WinForms   │────▶│ EmailService │────▶│  Gmail SMTP  │────▶│  Kullanıcı   │
│ Davet Oluştur│     │ (HTML Email) │     │  (Port 587)  │     │  E-postası   │
└──────────────┘     └──────────────┘     └──────────────┘     └──────────────┘
       │                                                              │
       ▼                                                              ▼
┌──────────────┐                                              ┌──────────────┐
│ RemoteApi    │                                              │ GitHub Pages │
│ Service      │                                              │ Web Sitesi   │
│ (HTTP POST)  │                                              │ (pt.bilalabic│
└──────────────┘                                              │    .com)     │
       │                                                      └──────────────┘
       ▼                                                              │
┌──────────────┐     ┌──────────────┐     ┌──────────────┐           │
│  Plesk API   │◀────│  Invitations │◀────│  JavaScript  │◀──────────┘
│  (bilalabic  │     │  Controller  │     │  fetch()     │
│   .com/api)  │     │              │     │              │
└──────────────┘     └──────────────┘     └──────────────┘
```

---

## 💻 Teknoloji Stack

### Framework & Runtime

| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| .NET | 8.0 LTS | Microsoft'un en güncel cross-platform framework'ü |
| ASP.NET Core | 8.0 | Web API framework (Minimal API) |
| Windows Forms | .NET 8.0 | Native Windows masaüstü uygulama framework'ü |
| C# | 12.0 | Modern syntax features (primary constructors, collection expressions) |

### UI Framework

| Teknoloji | Versiyon | Kullanım Alanı |
|-----------|----------|----------------|
| DevExpress WinForms | 25.1.7 | Professional UI controls |
| DevExpress GridControl | 25.1.7 | Data grids, Kanban board |
| DevExpress Charts | 25.1.7 | Pie chart, bar chart, line chart |
| DevExpress Gauges | 25.1.7 | KPI göstergeleri |
| DevExpress XtraEditors | 25.1.7 | TextEdit, DateEdit, ComboBox |

### Database & ORM

| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| SQL Server | 2019+ | RDBMS (Yerel + Plesk) |
| Entity Framework Core | 8.0.0 | ORM (Code-First) |
| EF Core Proxies | 8.0.0 | Lazy Loading desteği |
| EF Core SqlServer | 8.0.0 | SQL Server provider |

### Kütüphaneler

| Kütüphane | Versiyon | Kullanım Amacı |
|-----------|----------|----------------|
| AutoMapper | 12.0.1 | Entity-DTO dönüşümleri |
| FluentValidation | 11.9.0 | İş kuralları doğrulama |
| BCrypt.Net-Next | 4.0.3 | Güvenli şifre hashleme |
| EPPlus | 6.2.4 | Excel dosya oluşturma ve export |
| iTextSharp | 5.5.13.3 | PDF rapor oluşturma |
| Octokit | 9.1.2 | GitHub API client |
| Swashbuckle | 6.5.0 | Swagger/OpenAPI desteği |

### Dependency Injection

| Paket | Versiyon | Açıklama |
|-------|----------|----------|
| Microsoft.Extensions.DependencyInjection | 8.0.1 | IoC Container |
| Microsoft.Extensions.Configuration | 8.0.0 | Yapılandırma yönetimi |
| Microsoft.Extensions.Hosting | 8.0.0 | Host builder ve arka plan servisleri |

---

## 🗄️ Veritabanı Tasarımı

### Entity Relationship Diagram (Özet)

```
┌─────────────┐     ┌─────────────┐     ┌─────────────┐
│    Users    │────▶│    Roles    │     │    Teams    │
│             │     │             │     │             │
│ UserId (PK) │     │ RoleId (PK) │     │ TeamId (PK) │
│ RoleId (FK) │     │ RoleName    │     │ OwnerId(FK) │
│ Username    │     │ Description │     │ TeamName    │
│ PasswordHash│     └─────────────┘     │ Description │
│ FullName    │                         └──────┬──────┘
│ Email       │◀────────────────────────────────┘
│ GitHubUser  │
└──────┬──────┘
       │
       │ 1:N
       ▼
┌─────────────┐     ┌─────────────┐     ┌─────────────┐
│ TeamMembers │     │  Projects   │     │    Tasks    │
│             │     │             │     │             │
│ TeamMemberId│     │ ProjectId   │     │ TaskId (PK) │
│ TeamId (FK) │     │ TeamId (FK) │     │ ProjectId   │
│ UserId (FK) │     │ CreatedBy   │     │ AssignedTo  │
│ Role        │     │ ProjectName │     │ ParentTaskId│
│ JoinedAt    │     │ Description │     │ TaskName    │
└─────────────┘     │ StartDate   │     │ Status      │
                    │ EndDate     │     │ Priority    │
                    │ Budget      │     │ DueDate     │
                    │ Status      │     └─────────────┘
                    │ RiskScore   │
                    │ GitHubRepo  │
                    └─────────────┘
```

### Tablo Listesi (18 Tablo)

| Tablo | Açıklama | İlişkiler |
|-------|----------|-----------|
| **Users** | Kullanıcı bilgileri | → Roles, Teams, Tasks |
| **Roles** | Sistem rolleri (Admin, PM, Dev, Pending) | ← Users |
| **Teams** | Takım/workspace bilgileri | → Users, Projects |
| **TeamMembers** | Takım üyelikleri (M:N) | → Teams, Users |
| **TeamInvitations** | Takım davetleri | → Teams, Users |
| **Projects** | Proje bilgileri | → Teams, Users, Tasks |
| **Tasks** | Görev bilgileri | → Projects, Users |
| **TaskComments** | Görev yorumları | → Tasks, Users |
| **ProjectTeamMembers** | Proje-Kullanıcı ilişkileri | → Projects, Users |
| **ProjectRisks** | Risk kayıtları | → Projects |
| **ProjectSnapshots** | Günlük anlık görüntüler | → Projects |
| **Notifications** | Bildirimler | → Users |
| **TimeEntries** | Zaman kayıtları | → Tasks, Users |
| **AuditLogs** | Denetim kayıtları | → Users, Teams |
| **GitHubTokens** | GitHub token havuzu | → Users |
| **GitRepositories** | GitHub repo bağlantıları | → Projects |
| **GitCommits** | Commit cache | → GitRepositories, Tasks |
| **GitFileChanges** | Dosya değişiklikleri | → GitCommits |

### Enum Tanımları

```csharp
// ProjectStatus
Planned, Active, OnHold, Completed, Cancelled

// TaskStatus
Pending, InProgress, Completed, Blocked

// Priority
Low, Medium, High, Critical

// TeamRole
Owner, Admin, Member

// InvitationStatus
Pending, Accepted, Rejected, Expired

// ActivityType
ProjectCreated, ProjectUpdated, ProjectCompleted, ProjectDeleted,
TaskCreated, TaskAssigned, TaskStatusChanged, TaskCompleted,
TeamCreated, MemberAdded, MemberRemoved, MemberRoleChanged, ...
```

---

## 📁 Proje Yapısı

```
ProjectTracker/
│
├── 📂 src/                                    [Kaynak Kod]
│   │
│   ├── 📂 ProjectTracker.Core/                [Domain Layer - Entity & Interface]
│   │   ├── 📂 Entities/                       [18 Entity Sınıfı]
│   │   │   ├── User.cs                        # Kullanıcı entity
│   │   │   ├── Role.cs                        # Rol entity
│   │   │   ├── Team.cs                        # Takım entity
│   │   │   ├── TeamMember.cs                  # Takım üyeliği
│   │   │   ├── TeamInvitation.cs              # Takım daveti
│   │   │   ├── Project.cs                     # Proje entity
│   │   │   ├── Task.cs                        # Görev entity
│   │   │   ├── TaskComment.cs                 # Görev yorumu
│   │   │   ├── ProjectTeamMember.cs           # Proje-Kullanıcı ilişkisi
│   │   │   ├── ProjectRisk.cs                 # Risk kaydı
│   │   │   ├── ProjectSnapshot.cs             # Günlük snapshot
│   │   │   ├── Notification.cs                # Bildirim
│   │   │   ├── TimeEntry.cs                   # Zaman kaydı
│   │   │   ├── AuditLog.cs                    # Denetim kaydı
│   │   │   ├── GitHubToken.cs                 # GitHub token
│   │   │   ├── GitRepository.cs               # GitHub repo
│   │   │   ├── GitCommit.cs                   # Commit cache
│   │   │   └── GitFileChange.cs               # Dosya değişikliği
│   │   │
│   │   ├── 📂 Enums/                          [7 Enum Tanımı]
│   │   │   ├── ProjectStatus.cs
│   │   │   ├── TaskStatus.cs
│   │   │   ├── Priority.cs
│   │   │   ├── TeamRole.cs
│   │   │   ├── InvitationStatus.cs
│   │   │   ├── ActivityType.cs
│   │   │   └── NotificationType.cs
│   │   │
│   │   └── 📂 Interfaces/                     [Repository Interfaces]
│   │       └── 📂 Repositories/
│   │           ├── IRepository.cs             # Generic repository
│   │           ├── IUnitOfWork.cs             # Unit of Work
│   │           ├── IProjectRepository.cs
│   │           ├── ITaskRepository.cs
│   │           ├── IGitHubTokenRepository.cs
│   │           ├── IGitRepositoryRepository.cs
│   │           ├── IGitCommitRepository.cs
│   │           └── IGitFileChangeRepository.cs
│   │
│   ├── 📂 ProjectTracker.Data/                [Data Access Layer]
│   │   ├── 📂 Context/
│   │   │   ├── AppDbContext.cs                # Ana DbContext (18 DbSet)
│   │   │   └── AppDbContextFactory.cs         # Design-time factory
│   │   │
│   │   ├── 📂 Repositories/                   [Repository Implementations]
│   │   │   ├── Repository.cs                  # Generic repository
│   │   │   ├── ProjectRepository.cs
│   │   │   ├── TaskRepository.cs
│   │   │   ├── GitHubTokenRepository.cs
│   │   │   ├── GitRepositoryRepository.cs
│   │   │   ├── GitCommitRepository.cs
│   │   │   └── GitFileChangeRepository.cs
│   │   │
│   │   ├── 📂 Migrations/                     [EF Core Migrations]
│   │   │   ├── 20251229_AddTeamManagementSystem.cs
│   │   │   ├── 20260101_AddAdvancedAnalyticsTables.cs
│   │   │   ├── 20260102_AddRoleEdit.cs
│   │   │   ├── 20260103_GitHubIntegration.cs
│   │   │   └── AppDbContextModelSnapshot.cs
│   │   │
│   │   └── UnitOfWork.cs                      # Unit of Work implementation
│   │
│   ├── 📂 ProjectTracker.Business/            [Business Logic Layer]
│   │   ├── 📂 DTOs/                           [Data Transfer Objects]
│   │   │   ├── UserDto.cs, LoginDto.cs, RegisterDto.cs
│   │   │   ├── ProjectDto.cs, CreateProjectDto.cs, UpdateProjectDto.cs
│   │   │   ├── TaskDto.cs, CreateTaskDto.cs, UpdateTaskDto.cs
│   │   │   ├── TeamDto.cs, CreateTeamDto.cs, UpdateTeamDto.cs
│   │   │   ├── TeamMemberDto.cs, TeamInvitationDto.cs
│   │   │   ├── GitHubDtos.cs                  # GitHub related DTOs
│   │   │   ├── ActivityDto.cs, RoleDto.cs
│   │   │   └── 📂 Analytics/                  # Analitik DTOs
│   │   │       ├── BurndownChartDto.cs
│   │   │       ├── VelocityDto.cs
│   │   │       ├── EarnedValueDto.cs
│   │   │       └── FinancialOverviewDto.cs
│   │   │
│   │   ├── 📂 Interfaces/                     [Service Interfaces]
│   │   │   ├── 📂 Services/
│   │   │   │   ├── IUserService.cs
│   │   │   │   ├── IProjectService.cs
│   │   │   │   ├── ITaskService.cs
│   │   │   │   ├── ITeamService.cs
│   │   │   │   ├── IInvitationService.cs
│   │   │   │   ├── IEmailService.cs
│   │   │   │   ├── IAuditLogService.cs
│   │   │   │   └── ICurrentUserService.cs
│   │   │   ├── IReportService.cs
│   │   │   ├── IAdvancedReportService.cs
│   │   │   └── IGitHubService.cs
│   │   │
│   │   ├── 📂 Services/                       [14 Service Implementation]
│   │   │   ├── UserService.cs                 # Kullanıcı işlemleri
│   │   │   ├── ProjectService.cs              # Proje CRUD + Risk hesaplama
│   │   │   ├── TaskService.cs                 # Görev CRUD + Kanban
│   │   │   ├── TeamService.cs                 # Takım yönetimi
│   │   │   ├── InvitationService.cs           # Davet yönetimi
│   │   │   ├── EmailService.cs                # Gmail SMTP (HTML templates)
│   │   │   ├── RemoteInvitationService.cs     # API'ye davet gönderimi
│   │   │   ├── AuditLogService.cs             # Aktivite kaydı
│   │   │   ├── ReportService.cs               # PDF/Excel export
│   │   │   ├── AdvancedReportService.cs       # Gelişmiş analitik
│   │   │   ├── GitHubSyncService.cs           # GitHub senkronizasyonu
│   │   │   ├── GitHubAnalyticsService.cs      # GitHub analizi
│   │   │   ├── TokenPoolService.cs            # Token havuzu yönetimi
│   │   │   └── TaskMatchingService.cs         # Task-Commit eşleştirme
│   │   │
│   │   ├── 📂 Validators/                     [FluentValidation Rules]
│   │   │   ├── LoginValidator.cs
│   │   │   ├── RegisterValidator.cs
│   │   │   └── ProjectValidator.cs
│   │   │
│   │   ├── 📂 Mappings/
│   │   │   └── MappingProfile.cs              # AutoMapper profili
│   │   │
│   │   └── 📂 BackgroundServices/
│   │       └── SnapshotBackgroundService.cs   # Günlük snapshot servisi
│   │
│   ├── 📂 ProjectTracker.UI/                  [Presentation Layer - WinForms]
│   │   ├── 📂 Forms/
│   │   │   ├── 📂 Login/
│   │   │   │   ├── FrmLogin.cs                # Giriş formu
│   │   │   │   ├── FrmRegister.cs             # Kayıt formu
│   │   │   │   └── FrmPendingWaitlist.cs      # Onay bekleme ekranı
│   │   │   │
│   │   │   ├── 📂 Dashboard/
│   │   │   │   ├── FrmDashboard.cs            # Ana dashboard (sidebar + content)
│   │   │   │   └── 📂 Content/                [12 UserControl]
│   │   │   │       ├── DashboardContent.cs    # Ana sayfa KPI'ları
│   │   │   │       ├── ProjectsContent.cs     # Proje listesi
│   │   │   │       ├── ProjectDetailControl.cs# Proje detayı
│   │   │   │       ├── TasksContent.cs        # Görev listesi (Kanban/Grid)
│   │   │   │       ├── TaskDetailControl.cs   # Görev detayı
│   │   │   │       ├── TeamsContent.cs        # Takım listesi
│   │   │   │       ├── TeamDetailControl.cs   # Takım detayı
│   │   │   │       ├── TeamMembersContent.cs  # Üye yönetimi
│   │   │   │       ├── InvitationsContent.cs  # Davet yönetimi
│   │   │   │       ├── MyInvitationsContent.cs# Gelen davetler
│   │   │   │       ├── ReportsContent.cs      # Raporlar
│   │   │   │       ├── GitHubContent.cs       # GitHub analytics
│   │   │   │       └── UserSettingsContent.cs # Kullanıcı ayarları
│   │   │   │
│   │   │   └── 📂 Common/
│   │   │       └── FrmMessage.cs              # Özel mesaj kutusu
│   │   │
│   │   ├── 📂 Helpers/
│   │   │   ├── ColorPalette.cs                # Renk paleti (Slate Blue Theme)
│   │   │   ├── FormStyleHelper.cs             # Form stil yardımcıları
│   │   │   ├── SessionManager.cs              # Oturum yönetimi
│   │   │   └── CurrentUserService.cs          # Mevcut kullanıcı servisi
│   │   │
│   │   ├── 📂 Resources/
│   │   │   └── LoginFormLeft.png              # Login ekranı görseli
│   │   │
│   │   ├── Program.cs                         # DI Container yapılandırması
│   │   └── appsettings.example.json           # Örnek yapılandırma
│   │
│   └── 📂 ProjectTracker.API/                 [Web API Layer]
│       ├── 📂 Controllers/
│       │   └── InvitationsController.cs       # Davet API endpoint'leri
│       │
│       ├── 📂 Data/
│       │   └── InvitationDbContext.cs         # Sadece Invitations için DbContext
│       │
│       ├── 📂 Models/
│       │   └── InvitationModel.cs             # API model
│       │
│       ├── Program.cs                         # Minimal API yapılandırması
│       ├── appsettings.json
│       └── appsettings.Production.json
│
├── 📂 tests/
│   └── 📂 ProjectTracker.Tests/               [Unit Test Projesi]
│
├── 📂 docs/                                   [GitHub Pages + Dokümantasyon]
│   ├── index.html                             # Tanıtım sayfası
│   ├── accept-invite.html                     # Davet kabul sayfası
│   ├── CNAME                                  # pt.bilalabic.com
│   ├── 📂 css/
│   ├── 📂 js/
│   │   └── config.js                          # API URL yapılandırması
│   ├── 📂 UML/
│   ├── 📂 Screenshots/
│   └── 📂 Reports/
│
├── 📂 web/                                    [Web Sitesi - Geliştirme]
│   ├── index.html
│   ├── accept-invite.html
│   ├── 📂 css/
│   └── 📂 js/
│
├── 📂 bank/                                   [Geliştirme Notları]
│   ├── GITHUB_INTEGRATION_README.md
│   ├── GITHUB_INTEGRATION_ROADMAP.md
│   ├── PROJE_TANITIM_RAPORU.md
│   └── ... (diğer phase dokümanları)
│
├── 📂 SeedDataScript/
│   ├── seed.sql                               # Başlangıç verileri
│   ├── add_pending_role.sql                   # Pending rol ekleme
│   └── plesk_invitations_table.sql            # Plesk DB scripti
│
├── 📂 publish/
│   └── 📂 api/                                # API publish çıktısı
│
├── ProjectTracker.sln                         # Solution dosyası
├── README.md                                  # Bu dosya
├── CODING_STANDARDS.md                        # Kod standartları
├── TEKNOLOJI_KARARLARI.md                     # Teknoloji kararları
└── LICENSE.txt                                # Apache 2.0 Lisansı
```

---

## 🛠️ Kurulum

### Gereksinimler

| Gereksinim | Minimum Versiyon | Açıklama |
|------------|------------------|----------|
| Windows | 10/11 (64-bit) | İşletim sistemi |
| Visual Studio | 2022 (17.8+) | IDE |
| .NET SDK | 8.0 | Runtime ve SDK |
| SQL Server | 2019+ | Veritabanı (Express yeterli) |
| DevExpress | 25.1.7 | UI kontrolleri (Trial veya Full) |

### Adım Adım Kurulum

#### 1. Repository'yi Klonla
```bash
git clone https://github.com/BilalAbic/ProjectTracker.git
cd ProjectTracker
```

#### 2. NuGet Paketlerini Geri Yükle
```bash
dotnet restore
```

#### 3. Veritabanını Oluştur
```sql
-- SQL Server Management Studio'da çalıştır
CREATE DATABASE DboProjectTracker;
```

#### 4. appsettings.json Yapılandır
```bash
# Örnek dosyayı kopyala
copy src\ProjectTracker.UI\appsettings.example.json src\ProjectTracker.UI\appsettings.json
```

Dosyayı düzenle:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DboProjectTracker;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Email": {
    "Enabled": true,
    "SmtpHost": "smtp.gmail.com",
    "SmtpPort": 587,
    "Username": "your-email@gmail.com",
    "Password": "your-app-password",
    "FromEmail": "your-email@gmail.com",
    "FromName": "ProjectTracker",
    "EnableSsl": true
  },
  "RemoteApi": {
    "Enabled": true,
    "BaseUrl": "https://bilalabic.com/api"
  },
  "AppSettings": {
    "InvitationBaseUrl": "https://pt.bilalabic.com/accept-invite.html"
  }
}
```

#### 5. Migration'ları Uygula
```bash
dotnet ef database update --project src/ProjectTracker.Data --startup-project src/ProjectTracker.UI
```

#### 6. Seed Data Ekle (Opsiyonel)
```bash
# SQL Server Management Studio'da SeedDataScript/seed.sql dosyasını çalıştır
```

#### 7. Projeyi Çalıştır
```bash
dotnet run --project src/ProjectTracker.UI
```

### Gmail App Password Oluşturma

E-posta davet sistemi için Gmail App Password gereklidir:

1. [Google Hesabı](https://myaccount.google.com/) → Güvenlik
2. 2 Adımlı Doğrulama'yı aktif et
3. Uygulama Şifreleri → Yeni şifre oluştur
4. 16 karakterlik şifreyi `appsettings.json`'a yapıştır

---

## 🔌 API Dokümantasyonu

### Genel Bilgiler

| Özellik | Değer |
|---------|-------|
| **Framework** | ASP.NET Core 8.0 Minimal API |
| **Hosting** | Plesk (Windows Server + IIS) |
| **Production URL** | https://bilalabic.com/api |
| **Swagger** | Development ortamında aktif |

### Endpoints

| Method | Endpoint | Açıklama | Request Body |
|--------|----------|----------|--------------|
| `GET` | `/` | API bilgi | - |
| `GET` | `/ping` | Sağlık kontrolü (DB gerektirmez) | - |
| `GET` | `/api/invitations/health` | DB sağlık kontrolü | - |
| `GET` | `/api/invitations/validate?token=xxx` | Davet doğrulama | - |
| `POST` | `/api/invitations/create` | Davet oluşturma | `CreateInvitationRequest` |
| `POST` | `/api/invitations/accept` | Davet kabul | `AcceptInvitationRequest` |
| `POST` | `/api/invitations/decline` | Davet reddetme | `DeclineInvitationRequest` |

### Request/Response Örnekleri

#### Davet Doğrulama
```http
GET /api/invitations/validate?token=abc123def456
```

```json
// Response (200 OK)
{
  "isValid": true,
  "teamName": "Development Team",
  "invitedBy": "Bilal Abiç",
  "proposedRole": "Developer",
  "expiresAt": "2026-01-12T00:00:00",
  "email": "user@example.com"
}
```

#### Davet Oluşturma
```http
POST /api/invitations/create
Content-Type: application/json

{
  "email": "newuser@example.com",
  "teamName": "Development Team",
  "invitedByName": "Bilal Abiç",
  "proposedRole": "Developer",
  "expiresAt": "2026-01-12T00:00:00"
}
```

```json
// Response (200 OK)
{
  "success": true,
  "token": "abc123def456",
  "message": "Invitation created successfully"
}
```

#### Davet Kabul
```http
POST /api/invitations/accept
Content-Type: application/json

{
  "token": "abc123def456"
}
```

```json
// Response (200 OK)
{
  "success": true,
  "message": "Davet kabul edildi!",
  "email": "user@example.com"
}
```

### API Deployment (Plesk)

```bash
# 1. API'yi publish et
dotnet publish src/ProjectTracker.API -c Release -o publish/api

# 2. publish/api/ içeriğini Plesk'e yükle
# 3. .NET Core ayarlarını yapılandır
# 4. appsettings.Production.json dosyasını düzenle
```

---

## 👥 Kullanıcı Rolleri

### Sistem Rolleri

| Rol | Açıklama | Yetkiler |
|-----|----------|----------|
| **Admin** | Sistem yöneticisi | Tüm yetkiler, kullanıcı yönetimi, sistem ayarları, audit log |
| **ProjectManager** | Proje yöneticisi | Proje CRUD, görev atama, takım yönetimi, raporlar |
| **Developer** | Geliştirici | Atanan görevleri güncelleme, yorum yazma, kendi istatistikleri |
| **Pending** | Onay bekleyen | Sisteme erişim yok, admin onayı bekliyor |

### Takım Rolleri

| Rol | Açıklama | Yetkiler |
|-----|----------|----------|
| **Owner** | Takım sahibi | Takımı silme, tüm üye yetkileri |
| **Admin** | Takım yöneticisi | Üye ekleme/çıkarma, rol değiştirme |
| **Member** | Takım üyesi | Projelere erişim, görev güncelleme |

### Yetki Matrisi

| İşlem | Admin | PM | Developer | Pending |
|-------|-------|-----|-----------|---------|
| Kullanıcı Yönetimi | ✅ | ❌ | ❌ | ❌ |
| Proje Oluşturma | ✅ | ✅ | ❌ | ❌ |
| Proje Düzenleme | ✅ | ✅ | ❌ | ❌ |
| Görev Oluşturma | ✅ | ✅ | ❌ | ❌ |
| Görev Güncelleme | ✅ | ✅ | ✅* | ❌ |
| Takım Oluşturma | ✅ | ✅ | ❌ | ❌ |
| Raporları Görme | ✅ | ✅ | ✅* | ❌ |
| Audit Log | ✅ | ❌ | ❌ | ❌ |

*Sadece atanan görevler ve üyesi olduğu takımlar için

---

## 🎨 Tasarım Kalıpları

### Uygulanan Kalıplar

| Pattern | Katman | Açıklama |
|---------|--------|----------|
| **Repository Pattern** | Data | Veri erişim mantığının soyutlanması |
| **Unit of Work** | Data | Transaction yönetimi, toplu kaydetme |
| **Dependency Injection** | Tüm | Gevşek bağlı (loosely coupled) mimari |
| **DTO Pattern** | Business | Katmanlar arası veri transferi |
| **Service Layer** | Business | İş mantığının merkezi yönetimi |
| **Singleton** | UI | Session ve configuration yönetimi |
| **Factory** | Data | DbContext factory (design-time) |
| **Observer** | UI | Event-driven UI güncellemeleri |

### Kod Örnekleri

#### Repository Pattern
```csharp
public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
```

#### Unit of Work
```csharp
public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Project> Projects { get; }
    IRepository<Task> Tasks { get; }
    IRepository<Team> Teams { get; }
    // ... diğer repository'ler
    
    Task<int> SaveChangesAsync();
}
```

#### Dependency Injection (Program.cs)
```csharp
// Services
services.AddScoped<IUserService, UserService>();
services.AddScoped<IProjectService, ProjectService>();
services.AddScoped<ITaskService, TaskService>();
services.AddScoped<ITeamService, TeamService>();
services.AddScoped<IEmailService, EmailService>();
services.AddScoped<IGitHubSyncService, GitHubSyncService>();

// Validators
services.AddValidatorsFromAssemblyContaining<LoginValidator>();

// AutoMapper
services.AddAutoMapper(typeof(MappingProfile));
```

---

## 🎨 UI Tema Sistemi

### Renk Paleti (Slate Blue Theme)

```csharp
// Background Colors
BackgroundDeepNavy    = #1A1F26  // Ana arka plan
BackgroundSlateDark   = #242B3D  // Panel, sidebar
BackgroundSlateMedium = #1E2A3A  // Modal, elevated panels
BackgroundSlateLight  = #2A3F5F  // Input controls
BorderSlate           = #334155  // Borders, separators

// Accent Colors
AccentRoyalBlue = #5B8DEF  // Primary buttons, CTAs
AccentSkyBlue   = #7BA8F7  // Hover states
AccentLightBlue = #8ABAFC  // Links, active tabs
AccentBlueGlow  = #4A6FD4  // Pressed/active state

// Semantic Colors
SuccessGreen  = #10B981  // Completed, success
WarningOrange = #F97316  // Pending, warnings
WarningAmber  = #FBB034  // In-progress
DangerRed     = #EF4444  // Errors, cancelled

// Text Colors
TextPrimary   = #F8FAFC  // Headings (AAA contrast)
TextSecondary = #CBD5E1  // Descriptions (AA contrast)
TextTertiary  = #94A3B8  // Placeholders
TextMuted     = #64748B  // Disabled
```

### Kullanım Örneği
```csharp
// Panel arka planı
panel.BackColor = ColorPalette.BackgroundSlateDark;

// Başlık metni
label.ForeColor = ColorPalette.TextPrimary;

// Primary buton
button.BackColor = ColorPalette.AccentRoyalBlue;

// Durum rengi
var statusColor = ColorPalette.GetProjectStatusColor(project.Status);
```

---

## 🚀 Sürüm Notları

### v1.1.0 (5 Ocak 2026) - Web API & Davet Sistemi

#### Yeni Özellikler
- ✅ ASP.NET Core 8.0 Web API - Davet yönetimi için RESTful API
- ✅ GitHub Pages Web Sitesi - Tanıtım ve davet kabul sayfası
- ✅ Gmail SMTP Entegrasyonu - HTML template ile e-posta gönderimi
- ✅ Çift Veritabanı Mimarisi - Yerel + Uzak (Plesk) DB desteği
- ✅ RemoteInvitationService - WinForms'tan API'ye davet gönderimi
- ✅ Custom Domain - pt.bilalabic.com

#### Teknik Detaylar
- Minimal API pattern kullanımı
- CORS desteği (AllowAll policy)
- EnsureCreated() ile otomatik tablo oluşturma
- Fire-and-forget async pattern

### v1.0.0 (3 Ocak 2026) - İlk Sürüm

#### Temel Özellikler
- ✅ Proje, görev, takım yönetimi
- ✅ GitHub entegrasyonu (Octokit)
- ✅ Rol tabanlı yetkilendirme
- ✅ Audit log sistemi
- ✅ DevExpress UI (Dark Theme)
- ✅ PDF/Excel export
- ✅ Kanban board

---

## 📚 Ek Dokümantasyon

| Dosya | Açıklama |
|-------|----------|
| [CODING_STANDARDS.md](CODING_STANDARDS.md) | Kod standartları ve best practices |
| [TEKNOLOJI_KARARLARI.md](TEKNOLOJI_KARARLARI.md) | Teknoloji seçim kararları |
| [bank/GITHUB_INTEGRATION_README.md](bank/GITHUB_INTEGRATION_README.md) | GitHub entegrasyonu teknik tasarım |
| [bank/GITHUB_INTEGRATION_ROADMAP.md](bank/GITHUB_INTEGRATION_ROADMAP.md) | GitHub entegrasyonu yol haritası |
| [bank/PROJE_TANITIM_RAPORU.md](bank/PROJE_TANITIM_RAPORU.md) | Akademik proje tanıtım raporu |

---

## 👨‍💻 Geliştirici

| | |
|---|---|
| **Proje** | YMH 219 Nesne Tabanlı Programlama |
| **Dönem** | 2024-2025 Güz |
| **Üniversite** | Fırat Üniversitesi - Teknoloji Fakültesi |
| **Bölüm** | Yazılım Mühendisliği |
| **Geliştirici** | Bilal Abiç |
| **GitHub** | [@BilalAbic](https://github.com/BilalAbic) |

---

## 📄 Lisans

Bu proje [Apache License 2.0](LICENSE.txt) altında lisanslanmıştır.

---

**📌 Güncel Durum:** Phase 8 (Web API & Davet Sistemi) tamamlandı  
**📈 İlerleme:** ~85%  
**📅 Son Güncelleme:** 6 Ocak 2026

---

<div align="center">

🚀 **Happy Coding!**

Made with ❤️ by [Bilal Abiç](https://github.com/BilalAbic)

</div>
