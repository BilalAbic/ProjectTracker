# 📊 PROJECT TRACKER

### Enterprise Project Management System
*C# Windows Forms + DevExpress + Entity Framework Core 8.0*

---

## 🎯 Proje Özeti

**Project Tracker**, projelerin planlama, yürütme ve izleme süreçlerini tek bir merkezi yapı altında toplayan, akademik gereksinimleri karşılayan bütünleşik bir yazılım çözümüdür. Modern dark theme UI, DevExpress kontrolleri ve akıllı analiz algoritmaları ile profesyonel proje yönetimi deneyimi sunar.

### ✨ Temel Özellikler

| Özellik | Açıklama |
|---------|----------|
| 📁 **Proje Yönetimi** | Proje oluşturma, düzenleme, durum takibi, önceliklendirme |
| ✅ **Görev Yönetimi** | Alt görevler, atamalar, Kanban board, ilerleme izleme |
| 👥 **Kullanıcı/Rol Yönetimi** | Rol tabanlı yetkilendirme, ekip yönetimi |
| 📈 **Gantt Chart** | Görsel zaman çizelgesi, kritik yol analizi (CPM) |
| ⚠️ **Risk Analizi** | Ağırlıklı risk skoru, gecikme tahminleri |
| 🔔 **Bildirim Sistemi** | Otomatik uyarılar, deadline hatırlatmaları |
| 📊 **Raporlama & Analytics** | Performans grafikleri, durum raporları, PDF/Excel export |
| 🎨 **Modern Dashboard** | Anlık KPI'lar, interaktif grafikler, dark theme UI |

---

## 🏗️ Mimari Yapı

### Katmanlı Mimari (4 Katman)

```
┌─────────────────────────────────────────────────────────┐
│            PRESENTATION LAYER (UI)                      │
│        Windows Forms + DevExpress Controls              │
│  • FrmLogin, FrmDashboard                               │
│  • UserControls (Projects, Tasks, Reports, etc.)        │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│            BUSINESS LAYER                               │
│        Services + DTOs + Validation + Algorithms        │
│  • ProjectService, TaskService, UserService             │
│  • Risk Calculation Algorithm                           │
│  • Critical Path Method (CPM) Algorithm                 │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│            DATA ACCESS LAYER                            │
│        Repository Pattern + Unit of Work + EF Core      │
│  • Generic Repository<T>                                │
│  • UnitOfWork                                           │
│  • Migrations                                           │
└─────────────────────────────────────────────────────────┘
                          ↓
┌─────────────────────────────────────────────────────────┐
│            DATABASE                                     │
│                SQL Server 2019+                         │
│  • 9 Tables (Users, Roles, Projects, Tasks, etc.)      │
│  • Navigation Properties                                │
│  • Audit Logging                                        │
└─────────────────────────────────────────────────────────┘
```

### Klasör Yapısı

```
ProjectTracker/
│
├── src/
│   ├── ProjectTracker.Core/              [Domain Layer]
│   │   ├── Entities/                     [Entity sınıfları]
│   │   │   ├── User.cs
│   │   │   ├── Role.cs
│   │   │   ├── Project.cs
│   │   │   ├── Task.cs
│   │   │   ├── Notification.cs
│   │   │   └── ...
│   │   ├── Enums/                        [Enum tanımları]
│   │   │   ├── ProjectStatus.cs
│   │   │   ├── TaskStatus.cs
│   │   │   └── Priority.cs
│   │   └── Interfaces/                   [Repository & UoW]
│   │
│   ├── ProjectTracker.Data/              [Data Access Layer]
│   │   ├── Context/
│   │   │   └── AppDbContext.cs
│   │   ├── Repositories/
│   │   │   ├── GenericRepository.cs
│   │   │   └── ...
│   │   └── Migrations/
│   │
│   ├── ProjectTracker.Business/          [Business Logic Layer]
│   │   ├── Services/
│   │   │   ├── ProjectService.cs
│   │   │   ├── TaskService.cs
│   │   │   └── ...
│   │   ├── DTOs/
│   │   │   ├── ProjectDto.cs
│   │   │   ├── CreateProjectDto.cs
│   │   │   └── ...
│   │   ├── Validators/                   [FluentValidation]
│   │   └── Mappings/                     [AutoMapper]
│   │
│   └── ProjectTracker.UI/                [Presentation Layer]
│       ├── Forms/
│       │   ├── Login/
│       │   │   └── FrmLogin.cs
│       │   └── Dashboard/
│       │       ├── FrmDashboard.cs
│       │       └── Content/
│       │           ├── DashboardContent.cs
│       │           ├── ProjectsContent.cs
│       │           ├── ProjectDetailControl.cs
│       │           ├── TasksContent.cs
│       │           └── TaskDetailControl.cs
│       └── Program.cs                    [DI Container]
│
└── docs/
    ├── UML/                              [UML Diyagramları]
    ├── Screenshots/                      [Ekran Görüntüleri]
    └── Reports/                          [Proje Raporları]
```

---

## 🧠 Akıllı Algoritmalar (Akademik Gereksinim)

### 1. Ağırlıklı Risk Skoru Hesaplama

**Amaç:** Projelerin gecikme riskini matematiksel olarak hesaplamak

**Formül:**
```
RiskSkoru = (GörevSayısı × 0.3) + 
            ((100 - TamamlanmaOranı) × 0.4) + 
            ((1 / TakımBüyüklüğü) × 0.2) + 
            (BütçeKullanımOranı × 0.3)

Sonuç: 0-100 arası risk puanı
• 0-40:   Düşük Risk (🟢 Yeşil)
• 41-70:  Orta Risk (🟡 Sarı)
• 71-100: Yüksek Risk (🔴 Kırmızı)
```

### 2. Kritik Yol Analizi (CPM - Critical Path Method)

**Amaç:** Projenin minimum tamamlanma süresini ve kritik görevleri belirlemek

**Algoritma Adımları:**
1. **Forward Pass:** Her görev için en erken başlangıç/bitiş zamanını hesapla
2. **Backward Pass:** Her görev için en geç başlangıç/bitiş zamanını hesapla
3. **Slack Time:** `Slack = En Geç Başlangıç - En Erken Başlangıç`
4. **Kritik Görevler:** Slack = 0 olan görevler
5. **Kritik Yol:** Kritik görevlerin zinciri

**Çıktılar:**
- Projenin minimum tamamlanma süresi
- Geciktirilemeyecek görevler
- Gantt Chart'ta kırmızı vurgulama

---

## 🚀 Geliştirme Roadmap

### ✅ Tamamlanan Phase'ler (40%)

| Phase | Durum | Süre | Detay |
|-------|-------|------|-------|
| **Phase 1:** Login & Auth | ✅ Tamamlandı | 2h | [FrmLogin, Session yönetimi] |
| **Phase 2:** Dashboard Layout | ✅ Tamamlandı | 4h | [FrmDashboard, Sidebar, Top bar] |
| **Phase 3:** Projects Content | ✅ Tamamlandı | 5h | [ProjectsContent, CRUD, Filters] |
| **Phase 4:** Tasks Content | ✅ Tamamlandı | 6h | [TasksContent, Grid & Kanban, Drag-drop] |

### ⚪ Planlanan Phase'ler (60%)

| Phase | Durum | Tahmini Süre | Kapsam |
|-------|-------|--------------|--------|
| **Phase 5:** Team Management | ⚪ Planlandı | 4h | Kullanıcı yönetimi, rol atama, ekip listesi |
| **Phase 6:** Reports & Analytics | ⚪ Planlandı | 5h | Charts, istatistikler, PDF/Excel export |
| **Phase 7:** Gantt Chart | ⚪ Planlandı | 6h | ⭐ CPM algoritması, kritik yol, timeline |
| **Phase 8:** Settings & Notifications | ⚪ Planlandı | 4h | Ayarlar, bildirim sistemi, kullanıcı tercihleri |
| **Phase 9:** Testing & Refinement | ⚪ Planlandı | 4h | Unit tests, bug fixes, optimization |
| **Phase 10:** Documentation | ⚪ Planlandı | 5h | ⭐ UML diyagramları, deployment, raporlar |

**Toplam Tahmini Süre:** ~45-50 saat  
**⭐ İşaretli:** Akademik gereksinim içerir

---

## 💻 Teknoloji Stack

### Framework & Runtime
- **.NET 8.0** - Son versiyon framework
- **Windows Forms** - Native UI framework
- **C# 12.0** - Modern syntax features

### UI Framework
- **DevExpress WinForms 25.1.7** - Professional UI controls
  - GridControl (data grids)
  - Charts & Gauges
  - XtraEditors (input controls)
  - Ribbon & Navigation

### Database & ORM
- **SQL Server 2019+** - RDBMS
- **Entity Framework Core 8.0** - ORM
  - Code-First yaklaşım
  - Migrations
  - Navigation properties

### Libraries
- **AutoMapper 12.0.1** - DTO mapping
- **FluentValidation 12.1.1** - Validation rules
- **Microsoft.Extensions.DependencyInjection** - IoC Container

---

## 📦 Veritabanı Şeması

### Entity İlişkileri

```
┌──────────┐       ┌──────────┐
│  Roles   │───┐   │  Users   │
└──────────┘   │   └────┬─────┘
               └────────┘
                    │
         ┌──────────┼──────────┐
         │          │          │
    ┌────▼────┐ ┌───▼────┐ ┌──▼──────────┐
    │Projects │ │ Tasks  │ │Notifications│
    └────┬────┘ └───┬────┘ └─────────────┘
         │          │
    ┌────▼──────────▼────────────────┐
    │  ProjectTeamMembers             │
    │  TaskComments                   │
    │  ProjectRisks                   │
    │  AuditLogs                      │
    └─────────────────────────────────┘
```

### Temel Tablolar (9 tablo)

1. **Users** - Kullanıcılar
2. **Roles** - Roller (Admin, ProjectManager, Developer)
3. **Projects** - Projeler
4. **Tasks** - Görevler (parent-child destekli)
5. **Notifications** - Bildirimler
6. **ProjectTeamMembers** - Proje ekip üyeleri
7. **TaskComments** - Görev yorumları
8. **ProjectRisks** - Proje riskleri
9. **AuditLogs** - Audit kayıtları

---

## 🎨 UI Tasarımı

### Dark Theme (Cursor-Inspired)

| Element | Color | Hex |
|---------|-------|-----|
| Background | `#0B0B0B` | 11, 11, 11 |
| Card/Panel | `#151515` | 21, 21, 21 |
| Input Background | `#1A1A1A` | 26, 26, 26 |
| Border | `#2A2A2A` | 42, 42, 42 |
| **Orange Accent** | `#FF4D00` | 255, 77, 0 |
| Text Primary | `#FFFFFF` | 255, 255, 255 |
| Text Secondary | `#A1A1A1` | 161, 161, 161 |

### Status & Priority Colors

**Status:**
- 🟢 Active / Completed: `#00D084`
- 🟡 Planning / In Progress: `#FFB800`
- 🔴 Cancelled / Overdue: `#FF4D4D`
- ⚫ On Hold: `#808080`
- 🔵 Testing: `#0066FF`

**Priority:**
- ⚡ Critical: `#FF4D4D`
- 🟡 High: `#FFB800`
- 🟢 Medium: `#00D084`
- ⚫ Low: `#808080`

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

5. **Projeyi çalıştır:**
   ```bash
   dotnet run --project src/ProjectTracker.UI
   ```

6. **Varsayılan kullanıcı:**
   - Username: `admin`
   - Password: `admin123`

---

## 👥 Kullanıcı Rolleri ve Yetkileri

| Rol | Yetkiler | Kısıtlamalar |
|-----|----------|--------------|
| **Admin** | • Tüm yetkiler<br>• Kullanıcı yönetimi<br>• Sistem ayarları<br>• Audit log görüntüleme | - |
| **Proje Yöneticisi** | • Proje CRUD<br>• Görev atama<br>• Takım yönetimi<br>• Raporlar | Kullanıcı ekleme/silme yapamaz |
| **Takım Lideri** | • Görev yönetimi<br>• Kendi takımının raporları<br>• Yorum yazma | Proje oluşturamaz |
| **Geliştirici** | • Atanan görevleri güncelleme<br>• Yorum yazma<br>• Kendi istatistikleri | Sadece kendi görevlerine erişim |
| **İzleyici** | • Sadece görüntüleme | Hiçbir değişiklik yapamaz |

---

## 📊 Özellikler Detayları

### Phase 4: Tasks Content (Tamamlandı ✅)
- **Grid View:** Filtrelenebilir görev listesi ✅
- **Kanban Board:** Drag & Drop destekli (Pending, In Progress, Completed, Blocked) ✅
- **View Toggle:** Grid ve Kanban görünümleri arası geçiş ✅
- **TaskDetailControl:** Görev ekleme/düzenleme formu ✅
- **Filtering:** Proje ve durum bazlı filtreleme ✅

### Phase 5: Team Management
- **Kullanıcı CRUD:** Ekip üyesi ekleme, düzenleme, silme
- **Rol Yönetimi:** Rol atama ve güncelleme
- **Ekip İstatistikleri:** Atanan görevler, tamamlananlar

### Phase 6: Reports & Analytics ⭐
- **DevExpress Charts:** Pie, Line, Bar charts
- **Export:** PDF ve Excel rapor çıktısı
- **İstatistikler:** Completion rate, velocity, burndown

### Phase 7: Gantt Chart & CPM ⭐⭐⭐
- **Timeline View:** Görsel proje zaman çizelgesi
- **Critical Path Method:** Kritik yol analizi algoritması
- **Task Dependencies:** Görev bağımlılıkları (predecessor/successor)

### Phase 8: Settings & Notifications
- **Kullanıcı Ayarları:** Profil, şifre değiştirme, tercihler
- **Bildirim Sistemi:** Gerçek zamanlı uyarılar
- **Email Integration:** Otomatik email bildirimleri (opsiyonel)

---

## 🧪 Test & Kalite

### Unit Tests
- Service layer testleri
- Repository testleri
- Validation testleri
- Algorithm testleri (CPM, Risk calculation)

### Manuel Test Checklist

**Fonksiyonel:**
- [x] Kullanıcı giriş/çıkış
- [x] Proje CRUD işlemleri
- [x] Görev CRUD işlemleri
- [ ] Yetki kontrolleri
- [x] Dashboard verileri
- [ ] Gantt Chart görüntüleme
- [ ] Bildirimler

**UI/UX:**
- [x] Formlar düzgün açılıyor
- [x] Grid'ler veri gösteriyor
- [x] Butonlar çalışıyor
- [x] Dark theme tutarlı
- [x] Drag & Drop çalışıyor (Kanban Board)

---

## 📚 Dokümantasyon

### Proje Dökümanları

- **[KANBAN_VIEW_README.md](file:///d:/ProjectTracker/KANBAN_VIEW_README.md)** - Kanban Board implementasyon detayları
- **[UI_DASHBOARD_PHASE3.md](file:///d:/ProjectTracker/UI_DASHBOARD_PHASE3.md)** - Phase 3 detayları
- **[UI_DASHBOARD_PHASE4.md](file:///d:/ProjectTracker/UI_DASHBOARD_PHASE4.md)** - Phase 4 detayları
- **[CODING_STANDARDS.md](file:///d:/ProjectTracker/CODING_STANDARDS.md)** - Kod standartları ve convention'lar
- **[TEKNOLOJI_KARARLARI.md](file:///d:/ProjectTracker/TEKNOLOJI_KARARLARI.md)** - Teknoloji stack ve kararlar

### UML Diyagramları (Phase 10)

- Use Case Diagram
- Class Diagram
- Sequence Diagram
- Activity Diagram
- Entity-Relationship Diagram (ERD)

---

## 🎓 Akademik Değer

Bu proje aşağıdaki akademik gereksinimleri karşılamaktadır:

1. **✅ OOP Prensipleri**
   - Encapsulation, Inheritance, Polymorphism
   - SOLID principles

2. **✅ Design Patterns**
   - Repository Pattern
   - Unit of Work Pattern
   - Dependency Injection
   - DTO Pattern

3. **✅ Yazılım Mühendisliği Yöntemleri**
   - Katmanlı Mimari
   - Code-First yaklaşım
   - Migration-based database

4. **⭐ Akıllı Algoritma**
   - Ağırlıklı Risk Skoru Hesaplama
   - Critical Path Method (CPM)
   - Graf teorisi uygulaması

5. **✅ Test & Validation**
   - Unit Tests
   - FluentValidation

6. **📝 Dokümantasyon**
   - XML comments
   - UML diyagramları
   - Proje raporları

---

## 👨‍💻 Geliştirici

**Proje:** YMH 219 Nesne Tabanlı Programlama  
**Dönem:** 2024-2025  
**Geliştirici:** Bilal Abic  
**GitHub:** [@BilalAbic](https://github.com/BilalAbic)

---

## 📄 Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

---

## 🔗 Kaynaklar

- [DevExpress Documentation](https://docs.devexpress.com/)
- [Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [C# Coding Conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [AutoMapper](https://docs.automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/)

---

## 💡 İpuçları

> **"Perfect is the enemy of good!"**  
> Önce MVP (Minimum Viable Product) özelliklerini tamamlayın, ardından ek özelliklere geçin.

### Hızlı Başlangıç Önerileri

1. **Phase 1-3'ü referans alın** - Zaten tamamlanmış örnekler var
2. **Dokümantasyonu takip edin** - Her phase için detaylı guide mevcut
3. **Git commit atın** - Her phase sonunda commit
4. **Test edin** - Her özelliği ekledikten sonra manuel test
5. **Code review yapın** - Kod kalitesine dikkat edin

---

**📌 Güncel Durum:** Phase 4 (Tasks Content) tamamlandı - Phase 5'e hazır 
**📈 İlerleme:** 40% (4/10 phases tamamlandı)  
**⏱️ Kalan Süre:** ~30-35 saat

🚀 **Happy Coding!**
