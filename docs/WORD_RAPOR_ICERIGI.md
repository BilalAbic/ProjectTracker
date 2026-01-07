# FIRAT ÜNİVERSİTESİ
## TEKNOLOJİ FAKÜLTESİ
### Yazılım Mühendisliği Bölümü

---

## YMH219 – NESNE TABANLI PROGRAMLAMA
### Dersi Proje Uygulaması ve Dokümantasyonu

---

# Project Tracker
## Akıllı Proje Yönetim Sistemi

---

**Geliştiren:** 240542031 Bilal ABİÇ

**Proje Yürütücüleri:**
- Dr. Öğr. Üyesi V. Cem BAYDOĞAN
- Arş. Gör. Hüseyin Alperen DAĞDÖGEN

**OCAK – 2026**

---

## ÖNSÖZ VE TEŞEKKÜR

Hayatım boyunca ve bu çalışma süresince desteklerini esirgemeyen ailem ve arkadaşlarıma teşekkürü bir borç bilirim. Bu projeyi gerçekleştirme aşamasında yararlandığım her kaynağı kaynaklar kısmında bildirdiğimi taahhüt ederim.

Bilal ABİÇ

---

## İÇİNDEKİLER

1. GİRİŞ
   - 1.1 Projenin Tanıtılması
   - 1.2 Projenin Amacı
   - 1.3 Projenin Kapsamı
   - 1.4 Kullanılacak Teknolojiler
2. PROJE PLANI
   - 2.1 Sistemin Kullanıcıları
   - 2.2 GANT İş Akış Diyagramı
   - 2.3 İşlevsel İhtiyaçlar
   - 2.4 İşlevsel Olmayan İhtiyaçlar
   - 2.5 UML Diyagramları
3. PROJE GERÇEKLEŞTİRİLMESİ
   - 3.1 Modüllerin ve Tüm Formların Tasarımı
   - 3.2 Veritabanı Tasarımı (ER Diyagramı)
   - 3.3 Çıktılar & Raporlar
4. PROJEDE ÖNGÖRÜLEN EKSİKLİKLER
5. PROJE TESLİM
6. SONUÇ
7. KAYNAKLAR

---

## 1. GİRİŞ

### 1.1 Projenin Tanıtılması

Project Tracker, yazılım geliştirme ekiplerinin projelerini, görevlerini ve takımlarını yönetmelerini sağlayan kapsamlı bir kurumsal proje yönetim sistemidir. Sistem, modern yazılım geliştirme pratiklerini destekleyen özellikler sunmaktadır:

**Temel Özellikler:**
- **Proje Yönetimi:** Proje oluşturma, takip, bütçe ve zaman yönetimi
- **Görev Yönetimi:** Kanban board, görev atama, durum takibi
- **Takım Yönetimi:** Takım oluşturma, üye yönetimi, e-posta davet sistemi
- **GitHub Entegrasyonu:** Commit takibi, dosya değişiklikleri, geliştirici analytics
- **Raporlama:** Proje, kullanıcı ve takım bazlı detaylı raporlar
- **Risk Analizi:** Akıllı algoritma ile proje risk hesaplama (0-100 skor)

**Mimari Özellikler:**
- 5 Katmanlı Mimari (Core, Data, Business, UI, API)
- Repository & Unit of Work Pattern
- Dependency Injection
- SOLID Prensipleri

### 1.2 Projenin Amacı

Bu projenin temel amaçları:

1. **Eğitim Amaçlı:** Nesne tabanlı programlama prensiplerinin uygulamalı öğrenilmesi
2. **Pratik Uygulama:** Katmanlı mimari, design pattern'ler ve best practice'lerin uygulanması
3. **Gerçek Dünya Problemi:** Yazılım ekiplerinin karşılaştığı proje yönetimi sorunlarına çözüm
4. **Entegrasyon Deneyimi:** Harici API'ler (GitHub REST API, SMTP) ile entegrasyon tecrübesi
5. **Veritabanı Yönetimi:** Entity Framework Core ile ORM kullanımı
6. **Akıllı Algoritmalar:** Risk hesaplama ve commit-task eşleştirme algoritmaları

### 1.3 Projenin Kapsamı

**Kapsam İçi:**
- ✅ Kullanıcı kimlik doğrulama ve yetkilendirme (4 rol: Admin, ProjectManager, Developer, Pending)
- ✅ Proje CRUD işlemleri ve takibi
- ✅ Görev yönetimi (Grid + Kanban görünümü)
- ✅ Takım ve üye yönetimi
- ✅ E-posta davet sistemi (Gmail SMTP)
- ✅ Web üzerinden davet kabul (GitHub Pages)
- ✅ GitHub repository entegrasyonu
- ✅ Raporlama ve analytics
- ✅ Risk hesaplama algoritması
- ✅ Audit log sistemi
- ✅ PDF/Excel rapor export

**Kapsam Dışı:**
- ❌ Mobil uygulama
- ❌ Real-time collaboration (SignalR)
- ❌ Dosya yükleme/paylaşım
- ❌ Takvim entegrasyonu
- ❌ Çoklu dil desteği

### 1.4 Kullanılacak Teknolojiler

**Backend Teknolojileri:**

| Teknoloji | Versiyon | Kullanım Amacı |
|-----------|----------|----------------|
| .NET | 8.0 LTS | Ana framework |
| C# | 12.0 | Programlama dili |
| Entity Framework Core | 8.0 | ORM (Code-First) |
| SQL Server | 2022 | Veritabanı |
| ASP.NET Core | 8.0 | Web API |
| AutoMapper | 12.0 | DTO mapping |
| FluentValidation | 11.0 | Validasyon |
| BCrypt.Net | 4.0 | Şifre hashleme |

**Frontend Teknolojileri:**

| Teknoloji | Versiyon | Kullanım Amacı |
|-----------|----------|----------------|
| Windows Forms | .NET 8 | Desktop UI |
| DevExpress WinForms | 25.1.7 | Profesyonel UI bileşenleri |
| HTML5/CSS3/JavaScript | - | Web davet sayfası |

**Entegrasyonlar:**

| Servis | Kullanım Amacı |
|--------|----------------|
| GitHub REST API (Octokit) | Commit ve repo bilgileri |
| SMTP (Gmail) | E-posta bildirimleri |
| Plesk Remote API | Web davet sistemi |

**Geliştirme Araçları:**

| Araç | Kullanım Amacı |
|------|----------------|
| Visual Studio 2022 | IDE |
| Git/GitHub | Versiyon kontrolü |
| SQL Server Management Studio | Veritabanı yönetimi |
| Postman | API testing |
| Plesk | Web hosting |

---

## 2. PROJE PLANI

### 2.1 Sistemin Kullanıcıları

Sistemde 4 farklı kullanıcı rolü bulunmaktadır:

| Rol | RoleId | Açıklama | Yetkiler |
|-----|--------|----------|----------|
| **Admin** | 1 | Sistem yöneticisi | Tüm yetkiler, kullanıcı onaylama, rol değiştirme |
| **ProjectManager** | 2 | Proje yöneticisi | Proje/görev/takım oluşturma ve yönetimi |
| **Developer** | 3 | Geliştirici | Görev görüntüleme, güncelleme, yorum ekleme |
| **Pending** | 4 | Onay bekleyen | Sadece bekleme ekranı görüntüleme |

**Kullanıcı Kayıt Akışları:**

```
1. Direkt Kayıt:
   Yeni Kullanıcı → Kayıt Formu → Pending Rolü → Admin Onayı → Developer/ProjectManager

2. Davetli Kayıt:
   Davet E-postası → Web'de Kabul → Kayıt Formu → Davetteki Rol (Developer/Admin)
```

### 2.2 GANT İş Akış Diyagramı

```
Hafta 1-2: Analiz ve Tasarım
├── Gereksinim analizi
├── Veritabanı tasarımı (18 tablo)
├── Mimari tasarım (5 katman)
└── UML diyagramları (5 diyagram)

Hafta 3-4: Core ve Data Katmanı
├── 18 Entity sınıfı
├── 7 Enum tanımı
├── Repository pattern implementasyonu
├── DbContext ve migrations
└── Seed data scriptleri

Hafta 5-6: Business Katmanı
├── 14 Service sınıfı
├── 27+ DTO sınıfı
├── 3 Validator sınıfı
├── AutoMapper profilleri
└── E-posta servisi (Gmail SMTP)

Hafta 7-10: UI Katmanı
├── Login/Register formları
├── Dashboard (KPI'lar, grafikler)
├── Proje modülü (CRUD, risk analizi)
├── Görev modülü (Grid + Kanban)
├── Takım modülü (üye yönetimi, davetler)
└── Raporlama modülü (PDF/Excel export)

Hafta 11-12: Entegrasyonlar
├── GitHub API entegrasyonu (Octokit)
├── Token pool yönetimi
├── Commit-Task eşleştirme algoritması
├── Remote invitation API (ASP.NET Core)
└── Web davet sayfası (GitHub Pages)

Hafta 13-14: Test ve Dokümantasyon
├── 177 Unit test (xUnit + Moq)
├── Integration testler
├── Bug fixing
├── UML diyagramları
└── Final rapor
```

### 2.3 İşlevsel İhtiyaçlar (Olmazsa Olmazlar)

**Kullanıcı Yönetimi:**
| ID | İhtiyaç | Öncelik | Durum |
|----|---------|---------|-------|
| FR-01 | Kullanıcı kayıt olabilmeli | Yüksek | ✅ |
| FR-02 | Kullanıcı giriş yapabilmeli | Yüksek | ✅ |
| FR-03 | Admin kullanıcıları onaylayabilmeli | Yüksek | ✅ |
| FR-04 | Kullanıcı profil güncelleyebilmeli | Orta | ✅ |
| FR-05 | Şifre BCrypt ile hashlenebilmeli | Yüksek | ✅ |

**Proje Yönetimi:**
| ID | İhtiyaç | Öncelik | Durum |
|----|---------|---------|-------|
| FR-06 | Proje oluşturulabilmeli | Yüksek | ✅ |
| FR-07 | Proje güncellenebilmeli | Yüksek | ✅ |
| FR-08 | Proje silinebilmeli | Orta | ✅ |
| FR-09 | Proje takıma atanabilmeli | Yüksek | ✅ |
| FR-10 | Proje GitHub'a bağlanabilmeli | Orta | ✅ |
| FR-11 | Risk skoru hesaplanabilmeli | Orta | ✅ |

**Görev Yönetimi:**
| ID | İhtiyaç | Öncelik | Durum |
|----|---------|---------|-------|
| FR-12 | Görev oluşturulabilmeli | Yüksek | ✅ |
| FR-13 | Görev kullanıcıya atanabilmeli | Yüksek | ✅ |
| FR-14 | Görev durumu değiştirilebilmeli | Yüksek | ✅ |
| FR-15 | Kanban board görünümü olmalı | Orta | ✅ |
| FR-16 | Görev atandığında e-posta gitmeli | Orta | ✅ |

**Takım Yönetimi:**
| ID | İhtiyaç | Öncelik | Durum |
|----|---------|---------|-------|
| FR-17 | Takım oluşturulabilmeli | Yüksek | ✅ |
| FR-18 | Takıma üye eklenebilmeli | Yüksek | ✅ |
| FR-19 | E-posta ile davet gönderilebilmeli | Orta | ✅ |
| FR-20 | Davet web üzerinden kabul edilebilmeli | Orta | ✅ |

**Raporlama:**
| ID | İhtiyaç | Öncelik | Durum |
|----|---------|---------|-------|
| FR-21 | Proje bazlı rapor alınabilmeli | Orta | ✅ |
| FR-22 | PDF/Excel export yapılabilmeli | Orta | ✅ |
| FR-23 | Audit log tutulabilmeli | Orta | ✅ |

### 2.4 İşlevsel Olmayan İhtiyaçlar (İlave Özellikler)

| ID | Kategori | İhtiyaç | Durum |
|----|----------|---------|-------|
| NFR-01 | Performans | Sayfa yüklenme < 2 saniye | ✅ |
| NFR-02 | Güvenlik | Şifreler BCrypt ile hashlenecek | ✅ |
| NFR-03 | Güvenlik | GitHub token'ları şifrelenecek | ✅ |
| NFR-04 | Kullanılabilirlik | DevExpress ile modern UI | ✅ |
| NFR-05 | Bakım | Katmanlı mimari kullanılacak | ✅ |
| NFR-06 | Ölçeklenebilirlik | Generic repository pattern | ✅ |
| NFR-07 | Güvenilirlik | Audit log tutulacak | ✅ |
| NFR-08 | Entegrasyon | GitHub API rate limiting yönetimi | ✅ |
| NFR-09 | Erişilebilirlik | WCAG 2.1 uyumlu UI | ✅ |

### 2.5 UML Diyagramları

Projede 5 farklı UML diyagramı hazırlanmıştır:

| Diyagram | Dosya | İçerik |
|----------|-------|--------|
| Use Case | `docs/UML/UseCase_Diagram.md` | 4 aktör, 6 modül, 30+ use case |
| Class | `docs/UML/Class_Diagram.md` | 18 entity, 7 enum, ilişkiler |
| Activity | `docs/UML/Activity_Diagram.md` | 10 iş akışı, dual-database |
| Sequence | `docs/UML/Sequence_Diagram.md` | 7 senaryo |
| ER | `docs/UML/ER_Diagram.md` | 18 tablo + Plesk DB |

---

## 3. PROJE GERÇEKLEŞTİRİLMESİ

### 3.1 Modüllerin ve Tüm Formların Tasarımı

#### 3.1.1 Login Modülü

**Giriş Ekranı (FrmLogin)**
- Dosya: `docs/Screenshots/ProjectTracker.UI_Login.png`
- Username ve password girişi
- BCrypt ile şifre doğrulama
- "Kayıt Ol" butonu ile FrmRegister'a yönlendirme
- Başarılı girişte rol kontrolü:
  - Pending → FrmPendingWaitlist
  - Diğer → FrmDashboard

**Kayıt Ekranı (FrmRegister)**
- Dosya: `docs/Screenshots/ProjectTracker.UI_Register.png`
- Username, FullName, Email, Password alanları
- FluentValidation ile doğrulama
- Opsiyonel invitation token desteği
- Direkt kayıtta RoleId = 4 (Pending)

**Onay Bekleme Ekranı (FrmPendingWaitlist)**
- Dosya: `docs/Screenshots/ProjectTracker.UI_UserPending.png`
- Pending rolündeki kullanıcılar için
- Admin onayı bekleniyor mesajı

#### 3.1.2 Dashboard Modülü

**Ana Panel (DashboardContent)**
- Dosya: `docs/Screenshots/ProjectTracker.UI_Dashboard.png`
- Toplam proje, görev, takım sayıları (KPI kartları)
- Aktif/Tamamlanan proje istatistikleri
- Bekleyen görev sayısı
- Son aktiviteler listesi (Audit Log)
- Hızlı erişim butonları

#### 3.1.3 Proje Modülü

**Proje Listesi (ProjectsContent)**
- Dosya: `docs/Screenshots/ProjectTracker.UI_ProjectsList.png`
- DevExpress GridControl ile liste görünümü
- Filtreleme ve sıralama
- Durum bazlı renklendirme
- Çift tıklama ile detay

**Proje Oluşturma**
- Dosya: `docs/Screenshots/ProjectTracker.UI_ProjectCreate.png`
- Proje adı, açıklama
- Başlangıç/bitiş tarihi
- Bütçe, öncelik
- Takım seçimi
- GitHub repo URL (opsiyonel)

**Proje Düzenleme**
- Dosya: `docs/Screenshots/ProjectTracker.UI_ProjectEdit.png`
- Mevcut bilgilerin düzenlenmesi
- Durum değişikliği
- Tamamlanma yüzdesi (otomatik hesaplama)
- Risk skoru görüntüleme (0-100)

#### 3.1.4 Görev Modülü

**Görev Listesi - Grid Görünümü**
- Dosya: `docs/Screenshots/ProjectTracker.UI_TasksList.png`
- DevExpress GridControl
- Proje ve kullanıcı filtreleme
- Durum ve öncelik filtreleri

**Görev Listesi - Kanban Görünümü**
- Dosya: `docs/Screenshots/ProjectTracker.UI_TasksCanban.png`
- Sürükle-bırak ile durum değişikliği
- Pending, InProgress, Completed, Blocked kolonları
- Görsel görev kartları

**Görev Düzenleme**
- Dosya: `docs/Screenshots/ProjectTracker.UI_TaskEdit.png`
- Görev adı, açıklama
- Proje ve kullanıcı atama
- Öncelik ve durum
- Tahmini/gerçek saat

#### 3.1.5 Takım Modülü

**Takım Listesi**
- Dosya: `docs/Screenshots/ProjectTracker.UI_Team.png`
- Kullanıcının üye olduğu takımlar
- Takım adı, açıklama, üye sayısı

**Takım Oluşturma**
- Dosya: `docs/Screenshots/ProjectTracker.UI_TeamCreate.png`
- Takım adı ve açıklama
- Otomatik olarak oluşturan kişi Owner olur

**Takım Düzenleme**
- Dosya: `docs/Screenshots/ProjectTracker.UI_TeamEdit.png`
- Takım bilgileri düzenleme
- Üye listesi görüntüleme

**Takım Üyeleri**
- Dosya: `docs/Screenshots/ProjectTracker.UI_TeamMember.png`
- Üye listesi ve rolleri (Owner, Admin, Developer)
- Rol değiştirme (Admin için)
- Üye çıkarma

**Takım Davetleri**
- Dosya: `docs/Screenshots/ProjectTracker.UI_TeamInvitations.png`
- Gönderilen davetler listesi
- Davet durumu (Pending, Accepted, Declined, Expired)

**Davetlerim**
- Dosya: `docs/Screenshots/ProjectTracker.UI_MyInvitations.png`
- Kullanıcıya gelen davetler
- Kabul/Red butonları

#### 3.1.6 GitHub Modülü

**GitHub Analytics - Commit Listesi**
- Dosya: `docs/Screenshots/ProjectTracker.UI_GithubAnalytics1.png`
- Proje seçimi ve Sync butonu
- Commit listesi (SHA, mesaj, yazar, tarih)
- Additions/Deletions istatistikleri

**GitHub Analytics - Contributor İstatistikleri**
- Dosya: `docs/Screenshots/ProjectTracker.UI_GithubAnalytics2.png`
- Contributor bazlı commit sayıları
- Pie chart görselleştirme

**GitHub Analytics - File Hotspots**
- Dosya: `docs/Screenshots/ProjectTracker.UI_GithubAnalytics3.png`
- En çok değişen dosyalar
- Dosya uzantısı bazlı analiz

#### 3.1.7 Raporlama Modülü

**Proje Bazlı Rapor**
- Dosya: `docs/Screenshots/ProjectTracker.UI_Reports1.png`
- Görev dağılımı (durum bazlı)
- Tamamlanma yüzdesi

**Kullanıcı Bazlı Rapor**
- Dosya: `docs/Screenshots/ProjectTracker.UI_Reports2.png`
- Atanan/tamamlanan görevler

**Takım Bazlı Rapor**
- Dosya: `docs/Screenshots/ProjectTracker.UI_Reports3.png`
- Üye performansları

#### 3.1.8 Ayarlar Modülü

**Kullanıcı Ayarları**
- Dosya: `docs/Screenshots/ProjectTracker.UI_Settings.png`
- Profil bilgileri güncelleme
- Şifre değiştirme
- GitHub username bağlama

#### 3.1.9 Hata Yönetimi

**Hata Mesajı**
- Dosya: `docs/Screenshots/ProjectTracker.UI_Error.png`
- Kullanıcı dostu hata mesajları
- Dark-themed özel mesaj kutusu

---

### 3.2 Veritabanı Tasarımı (ER Diyagramı)

#### 3.2.1 Veritabanı Mimarisi

Sistem **Dual-Database** mimarisi kullanmaktadır:

**1. Local SQL Server (Ana Veritabanı)**
- 18 tablo
- Entity Framework Core ile yönetim
- Code-First yaklaşımı
- Lazy Loading (Proxies)

**2. Plesk Remote Database (Davet Sistemi)**
- 1 tablo (Invitations)
- Web üzerinden davet kabul için
- REST API ile erişim

#### 3.2.2 Tablo Listesi (18 Tablo)

| # | Tablo | Açıklama | İlişkiler |
|---|-------|----------|-----------|
| 1 | Users | Kullanıcı bilgileri | → Roles, Teams, Tasks |
| 2 | Roles | Sistem rolleri (4 adet) | ← Users |
| 3 | Teams | Takım/workspace bilgileri | → Users, Projects |
| 4 | TeamMembers | Takım üyelikleri (M:N) | → Teams, Users |
| 5 | TeamInvitations | Takım davetleri | → Teams, Users |
| 6 | Projects | Proje bilgileri | → Teams, Users, Tasks |
| 7 | Tasks | Görev bilgileri | → Projects, Users |
| 8 | TaskComments | Görev yorumları | → Tasks, Users |
| 9 | ProjectTeamMembers | Proje-Kullanıcı ilişkileri | → Projects, Users |
| 10 | ProjectRisks | Risk kayıtları | → Projects |
| 11 | ProjectSnapshots | Günlük anlık görüntüler | → Projects |
| 12 | Notifications | Bildirimler | → Users |
| 13 | TimeEntries | Zaman kayıtları | → Tasks, Users |
| 14 | AuditLogs | Denetim kayıtları | → Users, Teams |
| 15 | GitHubTokens | GitHub token havuzu | → Users |
| 16 | GitRepositories | GitHub repo bağlantıları | → Projects |
| 17 | GitCommits | Commit cache | → GitRepositories, Tasks |
| 18 | GitFileChanges | Dosya değişiklikleri | → GitCommits |

#### 3.2.3 ER Diyagramı (Özet)

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

#### 3.2.4 Enum Tanımları (7 Enum)

```csharp
// ProjectStatus
Planned = 0, Active = 1, OnHold = 2, Completed = 3, Cancelled = 4

// TaskStatus
Pending = 0, InProgress = 1, Completed = 2, Blocked = 3

// Priority
Low = 0, Medium = 1, High = 2, Critical = 3

// TeamRole
Owner = 0, Admin = 1, Developer = 2

// InvitationStatus
Pending = 0, Accepted = 1, Declined = 2, Expired = 3, Cancelled = 4

// ActivityType
ProjectCreated, ProjectUpdated, TaskCreated, TaskAssigned, TeamCreated, MemberAdded, ...

// NotificationType
TaskAssigned, TaskStatusChanged, TeamInvitation, ...
```

### 3.3 Çıktılar & Raporlar

#### 3.3.1 PDF Rapor Çıktıları

Sistem iTextSharp kütüphanesi ile PDF rapor üretmektedir:
- Proje Özet Raporu
- Görev Durum Raporu
- Takım Performans Raporu

#### 3.3.2 Excel Rapor Çıktıları

Sistem EPPlus kütüphanesi ile Excel export yapmaktadır:
- Proje Listesi Export
- Görev Listesi Export
- Audit Log Export

---

## 4. PROJEDE ÖNGÖRÜLEN EKSİKLİKLER

### 4.1 Proje Planında Yapılması Planlanmış Ancak Eksik Kalan Modüller

| Modül | Planlanan | Durum | Açıklama |
|-------|-----------|-------|----------|
| Real-time Bildirimler | SignalR entegrasyonu | ❌ | Zaman kısıtı nedeniyle ertelendi |
| Dosya Yükleme | Proje dosyaları | ❌ | Kapsam dışı bırakıldı |
| Takvim Entegrasyonu | Görev takvimi | ❌ | Gelecek sürüm için planlandı |
| Çoklu Dil Desteği | i18n | ❌ | Gelecek sürüm için planlandı |

### 4.2 Projeye Eklenmesi İçeriği Zenginleştirecek Modüller

| Modül | Öncelik | Açıklama |
|-------|---------|----------|
| Mobil Uygulama | Yüksek | .NET MAUI ile cross-platform mobil |
| SignalR | Yüksek | Real-time bildirimler ve güncellemeler |
| Gantt Chart | Orta | Proje zaman çizelgesi görselleştirme |
| Dosya Yönetimi | Orta | Proje dosyaları yükleme/paylaşım |
| Takvim Görünümü | Orta | Görev takvimi entegrasyonu |
| Dashboard Özelleştirme | Düşük | Kullanıcı bazlı widget düzenleme |
| Çoklu Dil | Düşük | Türkçe/İngilizce dil desteği |

---

## 5. PROJE TESLİM

### 5.1 Kurulum Gereksinimleri

| Gereksinim | Minimum Versiyon |
|------------|------------------|
| Windows | 10/11 (64-bit) |
| .NET Runtime | 8.0 |
| SQL Server | 2019+ |
| RAM | 4 GB |
| Disk | 500 MB |

### 5.2 Kurulum Adımları

**Adım 1: .NET 8.0 Runtime Kurulumu**
- https://dotnet.microsoft.com/download/dotnet/8.0 adresinden indirin
- .NET Desktop Runtime 8.0.x kurulumunu yapın

**Adım 2: SQL Server Kurulumu**
- SQL Server 2019+ Express Edition kurulumu
- SQL Server Management Studio (SSMS) kurulumu

**Adım 3: Veritabanı Oluşturma**
```sql
CREATE DATABASE ProjectTrackerDB;
```

**Adım 4: Connection String Ayarı**
- `appsettings.json` dosyasını düzenleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ProjectTrackerDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**Adım 5: Uygulamayı Çalıştırma**
- `ProjectTracker.UI.exe` dosyasını çalıştırın
- İlk çalıştırmada veritabanı tabloları otomatik oluşturulur
- Seed data ile varsayılan admin kullanıcısı oluşturulur

### 5.3 Varsayılan Kullanıcı Bilgileri

| Kullanıcı | Şifre | Rol |
|-----------|-------|-----|
| admin | admin123 | Admin |

---

## 6. SONUÇ

### 6.1 Projenin Genel Değerlendirmesi

**Artıları:**
- ✅ 5 katmanlı enterprise mimari başarıyla uygulandı
- ✅ SOLID prensipleri ve design pattern'ler kullanıldı
- ✅ GitHub API ve SMTP entegrasyonları çalışır durumda
- ✅ DevExpress ile profesyonel arayüz tasarlandı
- ✅ BCrypt şifreleme, token şifreleme ile güvenlik sağlandı
- ✅ Dual-Database mimarisi (Local + Remote) çalışıyor
- ✅ 177 unit test ile %100 test coverage
- ✅ Kanban board ile modern görev yönetimi
- ✅ Akıllı algoritmalar (Risk hesaplama, Commit-Task eşleştirme)

**Eksileri:**
- ❌ Real-time bildirimler henüz eklenmedi
- ❌ Mobil uygulama yok
- ❌ Dosya yükleme özelliği yok
- ❌ Çoklu dil desteği yok

**Tercih Edilme Sebebi:**
- Gerçek dünya problemi çözümü
- Kapsamlı özellik seti
- Modern teknoloji stack
- GitHub entegrasyonu ile geliştirici odaklı

### 6.2 Projenin Geliştirme Süresi Boyunca Katkısı

Bu proje süresince öğrenilen konular:

1. **Nesne Tabanlı Programlama:** SOLID prensipleri, inheritance, polymorphism
2. **Katmanlı Mimari:** Separation of concerns, loose coupling
3. **Design Patterns:** Repository, Unit of Work, Dependency Injection, DTO
4. **Entity Framework Core:** Code-First, migrations, lazy loading
5. **Asenkron Programlama:** async/await, Task-based programming
6. **REST API Entegrasyonu:** GitHub API, rate limiting yönetimi
7. **E-posta Servisleri:** SMTP, HTML template'ler
8. **Windows Forms:** DevExpress kontrolleri, modern UI tasarımı
9. **Test Driven Development:** xUnit, Moq, FluentAssertions
10. **Versiyon Kontrolü:** Git, GitHub, branching stratejileri

### 6.3 Proje Metrikleri

| Metrik | Değer |
|--------|-------|
| İşlev Noktası (İN) | 639 |
| Tahmini Kod Satırı | ~18,371 |
| Karmaşıklık Seviyesi | Çok Karmaşık |
| Geliştirme Süresi | ~4-5 Ay |
| Unit Test Sayısı | 177 |
| Test Başarı Oranı | %100 |
| Ekran Görüntüsü | 24 |
| Entity Sınıfı | 18 |
| Service Sınıfı | 14 |
| Veritabanı Tablosu | 18 + 1 (Remote) |

---

## 7. KAYNAKLAR

### 7.1 Kitaplar
1. Albahari, J. (2022). *C# 10 in a Nutshell*. O'Reilly Media.
2. Freeman, A. (2022). *Pro ASP.NET Core 6*. Apress.
3. Smith, J. (2021). *Entity Framework Core in Action*. Manning.

### 7.2 Online Kaynaklar
1. Microsoft Docs - .NET Documentation: https://docs.microsoft.com/dotnet
2. Entity Framework Core Documentation: https://docs.microsoft.com/ef/core
3. DevExpress Documentation: https://docs.devexpress.com
4. GitHub REST API Documentation: https://docs.github.com/rest
5. FluentValidation Documentation: https://docs.fluentvalidation.net
6. AutoMapper Documentation: https://docs.automapper.org

### 7.3 GitHub Linkleri
1. Proje Repository: https://github.com/BilalAbic/ProjectTracker
2. Web Sitesi: https://pt.bilalabic.com
3. API: https://bilalabic.com/api

### 7.4 Eğitim Videoları
1. .NET 8 Tutorial Series - Microsoft Learn
2. Entity Framework Core Tutorial - Tim Corey
3. DevExpress WinForms Tutorial - DevExpress YouTube

---

**Rapor Tarihi:** 6 Ocak 2026  
**Versiyon:** 1.0  
**Proje:** Project Tracker - Akıllı Proje Yönetim Sistemi  
**Öğrenci:** 240542031 - Bilal ABİÇ

---

## EKLER

### Ek-1: UML Diyagramları
- `docs/UML/UseCase_Diagram.md`
- `docs/UML/Class_Diagram.md`
- `docs/UML/Activity_Diagram.md`
- `docs/UML/Sequence_Diagram.md`
- `docs/UML/ER_Diagram.md`

### Ek-2: Maliyet Analizi
- `docs/Reports/MALIYET_KESTIRIM.md`

### Ek-3: Test Dokümanı
- `docs/Reports/TEST_DOKUMANI.md`

### Ek-4: Ekran Görüntüleri (24 adet)
- `docs/Screenshots/` klasörü

### Ek-5: Kaynak Kod
- GitHub Repository: https://github.com/BilalAbic/ProjectTracker
