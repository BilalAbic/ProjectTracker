# FIRAT ÜNİVERSİTESİ
# TEKNOLOJİ FAKÜLTESİ
## Yazılım Mühendisliği Bölümü

---

# YMH219 – NESNE TABANLI PROGRAMLAMA
## Dersi Proje Uygulaması ve Dokümantasyonu

---

# Project Tracker
## Akıllı Proje Yönetim Sistemi

---

**Geliştiren**
240542031 Bilal ABİÇ

**Proje Yürütücüleri**
Dr. Öğr. Üyesi V. Cem BAYDOĞAN
Arş. Gör. Hüseyin Alperen DAĞDÖGEN

**OCAK – 2026**

---

# ÖNSÖZ VE TEŞEKKÜR

Hayatım boyunca ve bu çalışma süresince desteklerini esirgemeyen ailem ve arkadaşlarıma teşekkürü bir borç bilirim. 

Bu proje, yazılım geliştirme sürecinde karşılaştığım zorlukları aşmamda bana yol gösteren herkese minnettarlığımı ifade etmek istediğim bir çalışma oldu. Özellikle nesne tabanlı programlama dersinde öğrendiğim kavramları gerçek bir projede uygulama fırsatı buldum.

Bu projeyi gerçekleştirme aşamasında yararlandığım her kaynağı kaynaklar kısmında bildirdiğimi taahhüt ederim.

Bilal ABİÇ

---

# İÇİNDEKİLER

1. GİRİŞ
2. ÇÖZÜMLEME
3. TASARIM
   - 3.1 Sistem Tasarımı - Proje Mimarisi
   - 3.2 Veri Tasarımı - Tablo İlişki Sistemi
   - 3.3 Süreç Modeli
   - 3.4 UML Diyagramları
   - 3.5 Arayüz Tasarımı - Modüllerin ve Formların Tanıtımı
4. KODLAMA
5. DOĞRULAMA VE GEÇERLEME
6. SONUÇ
7. KAYNAKLAR

---

# 1. GİRİŞ

## 1.1 Projenin Tanıtılması

Project Tracker, yazılım geliştirme ekiplerinin günlük işlerini kolaylaştırmak için tasarladığım kapsamlı bir proje yönetim sistemi. Aslında bu projeyi geliştirirken kendi ihtiyaçlarımdan yola çıktım - bir projede çalışırken görevlerin takibi, ekip üyeleriyle koordinasyon ve ilerlemenin raporlanması her zaman zorlayıcı olabiliyor.

Bu sistem sayesinde:
- Projelerinizi tek bir yerden yönetebilirsiniz
- Görevleri Kanban board üzerinde sürükle-bırak ile organize edebilirsiniz
- Takım arkadaşlarınızı e-posta ile davet edebilirsiniz
- GitHub repository'nizi bağlayarak commit'lerinizi takip edebilirsiniz
- Detaylı raporlar alarak ilerlemenizi görebilirsiniz

Projenin en ilginç özelliklerinden biri, GitHub'dan çekilen commit mesajlarını analiz ederek hangi görevle ilişkili olduğunu otomatik olarak eşleştiren akıllı algoritma. Ayrıca proje risk skorunu hesaplayan bir algoritma da mevcut.

## 1.2 Projenin Amacı

Bu projeyi geliştirirken birkaç temel amacım vardı:

**Eğitim Açısından:**
- Nesne tabanlı programlama prensiplerini (SOLID) gerçek bir projede uygulamak
- Katmanlı mimari tasarımını öğrenmek ve deneyimlemek
- Design pattern'leri (Repository, Unit of Work, Dependency Injection) kullanmak

**Pratik Açıdan:**
- Yazılım ekiplerinin gerçek ihtiyaçlarına cevap veren bir ürün ortaya koymak
- GitHub API, SMTP gibi harici servislerle entegrasyon deneyimi kazanmak
- Entity Framework Core ile veritabanı yönetimini öğrenmek

## 1.3 Projenin Kapsamı

**Projede Yapılanlar:**
- ✅ Kullanıcı giriş/kayıt sistemi (4 farklı rol: Admin, ProjectManager, Developer, Pending)
- ✅ Proje oluşturma, düzenleme, silme ve takip
- ✅ Görev yönetimi (hem liste hem Kanban görünümü)
- ✅ Takım oluşturma ve üye yönetimi
- ✅ E-posta ile davet gönderme (Gmail SMTP)
- ✅ Web üzerinden davet kabul etme (GitHub Pages'da barındırılan site)
- ✅ GitHub repository bağlama ve commit senkronizasyonu
- ✅ Detaylı raporlama ve PDF/Excel export
- ✅ Risk hesaplama ve audit log sistemi
- ✅ 177 adet unit test ile kod kalitesi güvencesi

**Kapsam Dışında Bırakılanlar:**
- ❌ Mobil uygulama
- ❌ Real-time bildirimler (SignalR)
- ❌ Dosya yükleme özelliği
- ❌ Çoklu dil desteği

## 1.4 Kullanılacak Teknolojiler

### Backend Teknolojileri

| Teknoloji | Versiyon | Ne İçin Kullandım |
|-----------|----------|-------------------|
| .NET | 8.0 LTS | Ana framework - Microsoft'un en güncel ve stabil sürümü |
| C# | 12.0 | Programlama dili - modern syntax özellikleri |
| Entity Framework Core | 8.0 | Veritabanı işlemleri için ORM |
| SQL Server | 2022 | Ana veritabanı |
| ASP.NET Core | 8.0 | Web API için |
| AutoMapper | 12.0 | Entity-DTO dönüşümleri |
| FluentValidation | 11.0 | Kullanıcı girişi doğrulama |
| BCrypt.Net | 4.0 | Şifreleri güvenli şekilde hashlemek için |

### Frontend Teknolojileri

| Teknoloji | Versiyon | Ne İçin Kullandım |
|-----------|----------|-------------------|
| Windows Forms | .NET 8 | Masaüstü uygulaması arayüzü |
| DevExpress WinForms | 25.1.7 | Profesyonel görünümlü UI kontrolleri |
| HTML5/CSS3/JavaScript | - | Web davet sayfası |

### Entegrasyonlar

| Servis | Kullanım Amacı |
|--------|----------------|
| GitHub REST API (Octokit) | Commit ve repository bilgilerini çekmek |
| Gmail SMTP | E-posta bildirimleri göndermek |
| Plesk Remote API | Web üzerinden davet kabul sistemi |

---

# 2. ÇÖZÜMLEME

## 2.1 Mevcut Projelerin Eksiklikleri ve Bizim Farkımız

Piyasadaki mevcut proje yönetim araçlarını incelediğimde bazı eksiklikler dikkatimi çekti:

### Mevcut Araçların Eksiklikleri

| Araç | Eksiklik |
|------|----------|
| **Jira** | Çok karmaşık arayüz, öğrenme eğrisi yüksek, pahalı lisans |
| **Trello** | Sadece Kanban, raporlama yok, GitHub entegrasyonu sınırlı |
| **Asana** | Masaüstü uygulaması yok, offline çalışamıyor |
| **Monday.com** | Pahalı, gereksiz özellik kalabalığı |
| **GitHub Projects** | Sadece GitHub'a bağımlı, bağımsız proje yönetimi yok |

### Project Tracker'ın Farkları

| Özellik | Bizim Çözümümüz |
|---------|-----------------|
| **Basit Arayüz** | DevExpress ile modern ama sade tasarım |
| **Hem Liste Hem Kanban** | Kullanıcı tercihine göre görünüm değiştirme |
| **GitHub Entegrasyonu** | Commit'leri otomatik çekme ve görevlerle eşleştirme |
| **Akıllı Algoritmalar** | Risk hesaplama, commit-task eşleştirme |
| **Offline Çalışma** | Masaüstü uygulaması, yerel veritabanı |
| **Ücretsiz** | Açık kaynak, lisans ücreti yok |
| **Türkçe Destek** | Yerel kullanıcılar için uygun |

## 2.2 Arayüz Gerekliliği

### Neden Windows Forms?

1. **Masaüstü Deneyimi:** Kullanıcılar tarayıcı açmadan doğrudan uygulamayı çalıştırabilir
2. **Performans:** Web uygulamalarına göre daha hızlı yanıt süresi
3. **Offline Çalışma:** İnternet bağlantısı olmadan da çalışabilme
4. **DevExpress Kontrolleri:** Profesyonel görünümlü, zengin özellikli UI bileşenleri
5. **Ders Gereksinimleri:** YMH219 dersi Windows Forms odaklı

### Arayüz Tasarım Prensipleri

| Prensip | Uygulama |
|---------|----------|
| **Tutarlılık** | Tüm ekranlarda aynı renk paleti ve stil |
| **Basitlik** | Gereksiz karmaşıklıktan kaçınma |
| **Geri Bildirim** | Her işlem sonrası kullanıcıya bilgi verme |
| **Erişilebilirlik** | Yüksek kontrast, okunabilir fontlar |
| **Responsive** | Farklı ekran boyutlarına uyum |

## 2.3 Sistemin Kullanıcıları

Sistemi tasarlarken farklı kullanıcı tiplerinin farklı ihtiyaçları olacağını düşündüm. Bu yüzden 4 farklı rol tanımladım:

| Rol | Açıklama | Neler Yapabilir? |
|-----|----------|------------------|
| **Admin** | Sistem yöneticisi | Her şeyi yapabilir - kullanıcı onaylama, rol değiştirme, tüm verilere erişim |
| **ProjectManager** | Proje yöneticisi | Proje ve takım oluşturma, görev atama, raporları görüntüleme |
| **Developer** | Geliştirici | Kendine atanan görevleri görme ve güncelleme, yorum ekleme |
| **Pending** | Onay bekleyen | Sadece bekleme ekranını görür, admin onayı bekler |

### Kullanıcı Kayıt Akışı

İki farklı şekilde sisteme kayıt olunabilir:

1. **Direkt Kayıt:** Kullanıcı kayıt formunu doldurur → Pending rolüyle kaydedilir → Admin onaylar → Developer veya ProjectManager rolü atanır

2. **Davetli Kayıt:** Takım sahibi e-posta ile davet gönderir → Kullanıcı web'den daveti kabul eder → Kayıt formunu doldurur → Davetteki rol otomatik atanır

## 2.4 İşlevsel İhtiyaçlar (Olmazsa Olmazlar)

### Kullanıcı Yönetimi
- ✅ Kullanıcılar sisteme kayıt olabilmeli
- ✅ Kullanıcılar giriş yapabilmeli
- ✅ Admin, bekleyen kullanıcıları onaylayabilmeli
- ✅ Şifreler güvenli şekilde (BCrypt) saklanmalı

### Proje Yönetimi
- ✅ Yeni proje oluşturulabilmeli
- ✅ Proje bilgileri güncellenebilmeli
- ✅ Proje silinebilmeli
- ✅ Proje bir takıma atanabilmeli
- ✅ Projeye GitHub repository bağlanabilmeli
- ✅ Proje risk skoru otomatik hesaplanmalı

### Görev Yönetimi
- ✅ Görev oluşturulabilmeli
- ✅ Görev bir kullanıcıya atanabilmeli
- ✅ Görev durumu değiştirilebilmeli (Pending → InProgress → Completed)
- ✅ Kanban board görünümü olmalı
- ✅ Görev atandığında e-posta bildirimi gitmeli

### Takım Yönetimi
- ✅ Takım oluşturulabilmeli
- ✅ Takıma üye eklenebilmeli
- ✅ E-posta ile davet gönderilebilmeli
- ✅ Davet web üzerinden kabul edilebilmeli

### Raporlama
- ✅ Proje bazlı rapor alınabilmeli
- ✅ PDF ve Excel formatında export yapılabilmeli
- ✅ Tüm işlemler audit log'a kaydedilmeli

## 2.5 İşlevsel Olmayan İhtiyaçlar

| Kategori | Gereksinim | Nasıl Sağladım? |
|----------|------------|-----------------|
| **Performans** | Sayfalar 2 saniyeden kısa sürede yüklenmeli | Async/await kullanımı, lazy loading |
| **Güvenlik** | Şifreler güvenli saklanmalı | BCrypt ile hashleme |
| **Güvenlik** | GitHub token'ları şifreli tutulmalı | AES şifreleme |
| **Kullanılabilirlik** | Modern ve kullanıcı dostu arayüz | DevExpress kontrolleri |
| **Bakım** | Kod kolay bakım yapılabilir olmalı | Katmanlı mimari, SOLID prensipleri |
| **Ölçeklenebilirlik** | Yeni özellikler kolayca eklenebilmeli | Generic repository, DI |
| **Güvenilirlik** | Tüm işlemler kayıt altına alınmalı | Audit log sistemi |

---

# 3. TASARIM

## 3.1 Sistem Tasarımı - Proje Mimarisi

### 3.1.1 Katmanlı Mimari (5 Katman)

Projeyi 5 katmanlı enterprise mimari ile tasarladım. Bu yaklaşımın avantajları:
- Her katmanın tek bir sorumluluğu var (Single Responsibility)
- Katmanlar birbirinden bağımsız test edilebilir
- Değişiklikler sadece ilgili katmanı etkiler
- Kod tekrarı minimize edilir

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
│  • 14 Service (Project, Task, Team, GitHub, etc.)       │
│  • 27+ DTO (Create/Update/View varyantları)            │
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
                          ↓
┌─────────────────────────────────────────────────────────┐
│            API LAYER (Web API)                          │
│        ASP.NET Core Minimal API                         │
│  • Plesk'te barındırılan REST API                      │
│  • Davet kabul/red işlemleri                           │
└─────────────────────────────────────────────────────────┘
```

### 3.1.2 Neden Bu Mimariyi Seçtim?

| Alternatif | Neden Seçmedim |
|------------|----------------|
| **Monolitik** | Bakımı zor, test edilemez, ölçeklenemez |
| **Microservices** | Proje boyutu için fazla karmaşık |
| **MVC** | Windows Forms için uygun değil |
| **MVVM** | WPF için daha uygun, WinForms'ta karmaşık |

**Katmanlı Mimari Avantajları:**
- Separation of Concerns (Kaygıların Ayrılması)
- Dependency Injection ile loose coupling
- Unit test yazılabilirlik
- Kod tekrarının önlenmesi
- Bakım kolaylığı

### 3.1.3 Design Patterns Kullanımı

| Pattern | Kullanım Yeri | Açıklama |
|---------|---------------|----------|
| **Repository Pattern** | Data Layer | Veri erişim soyutlaması |
| **Unit of Work** | Data Layer | Transaction yönetimi |
| **Dependency Injection** | Tüm katmanlar | Loose coupling |
| **DTO Pattern** | Business Layer | Katmanlar arası veri transferi |
| **Service Pattern** | Business Layer | İş mantığı kapsülleme |
| **Singleton** | UI Layer | SessionManager |
| **Factory** | Data Layer | DbContext oluşturma |

## 3.2 Veri Tasarımı - Tablo İlişki Sistemi

### 3.2.1 Veritabanı Mimarisi

Projede ilginç bir mimari kullandım: **Dual-Database** (Çift Veritabanı) mimarisi.

**Neden iki veritabanı?**

Web üzerinden davet kabul özelliği için bir sorunla karşılaştım: Windows Forms uygulaması yerel SQL Server'a bağlanıyor, ama web sitesi (GitHub Pages'da barındırılan) bu veritabanına erişemiyor. Çözüm olarak:

1. **Yerel SQL Server:** Ana veritabanı, 18 tablo, tüm uygulama verileri
2. **Plesk Remote Database:** Sadece davetler için, 1 tablo, web API üzerinden erişim

Token alanı iki veritabanı arasında senkronizasyon anahtarı olarak kullanılıyor.

### 3.2.2 Tablo Listesi (18 Tablo)

| # | Tablo | Açıklama | İlişkiler |
|---|-------|----------|-----------|
| 1 | **Users** | Kullanıcı bilgileri | Roles (N:1) |
| 2 | **Roles** | Sistem rolleri (4 adet) | Users (1:N) |
| 3 | **Teams** | Takım bilgileri | Users (N:1), Projects (1:N) |
| 4 | **TeamMembers** | Takım-Kullanıcı ilişkisi | Teams (N:1), Users (N:1) |
| 5 | **TeamInvitations** | Takım davetleri | Teams (N:1), Users (N:1) |
| 6 | **Projects** | Proje bilgileri | Teams (N:1), Tasks (1:N) |
| 7 | **Tasks** | Görev bilgileri | Projects (N:1), Users (N:1) |
| 8 | **TaskComments** | Görev yorumları | Tasks (N:1), Users (N:1) |
| 9 | **ProjectTeamMembers** | Proje-Kullanıcı ilişkisi | Projects (N:1), Users (N:1) |
| 10 | **ProjectRisks** | Risk kayıtları | Projects (N:1) |
| 11 | **ProjectSnapshots** | Günlük anlık görüntüler | Projects (N:1) |
| 12 | **Notifications** | Bildirimler | Users (N:1) |
| 13 | **TimeEntries** | Zaman kayıtları | Tasks (N:1), Users (N:1) |
| 14 | **AuditLogs** | Denetim kayıtları | - |
| 15 | **GitHubTokens** | GitHub token havuzu | Users (N:1) |
| 16 | **GitRepositories** | GitHub repo bağlantıları | Projects (1:1) |
| 17 | **GitCommits** | Commit cache | GitRepositories (N:1), Tasks (N:1) |
| 18 | **GitFileChanges** | Dosya değişiklikleri | GitCommits (N:1) |

### 3.2.3 ER Diyagramı (Basitleştirilmiş)

```
┌─────────────┐     ┌─────────────┐     ┌─────────────┐
│    Users    │────▶│    Roles    │     │    Teams    │
│             │     │             │     │             │
│ UserId (PK) │     │ RoleId (PK) │     │ TeamId (PK) │
│ RoleId (FK) │     │ RoleName    │     │ OwnerId(FK) │
│ Username    │     └─────────────┘     │ TeamName    │
│ PasswordHash│                         └──────┬──────┘
│ FullName    │◀────────────────────────────────┘
│ Email       │
└──────┬──────┘
       │
       ▼
┌─────────────┐     ┌─────────────┐     ┌─────────────┐
│ TeamMembers │     │  Projects   │     │    Tasks    │
│             │     │             │     │             │
│ TeamId (FK) │     │ ProjectId   │     │ TaskId (PK) │
│ UserId (FK) │     │ TeamId (FK) │     │ ProjectId   │
│ Role        │     │ ProjectName │     │ AssignedTo  │
│ JoinedAt    │     │ Status      │     │ Status      │
└─────────────┘     │ RiskScore   │     │ Priority    │
                    └─────────────┘     └─────────────┘
```

### 3.2.4 Neyi Neden Yaptım?

| Tasarım Kararı | Neden? |
|----------------|--------|
| **Roles tablosu ayrı** | Yeni roller eklenebilir, enum yerine veritabanı |
| **TeamMembers ara tablosu** | Many-to-Many ilişki için |
| **GitCommits cache** | API rate limit'i aşmamak için |
| **AuditLogs** | Tüm değişiklikleri takip etmek için |
| **ProjectSnapshots** | Burndown chart için günlük veri |
| **Token alanı unique** | Dual-database senkronizasyonu için |

### 3.2.5 Enum Tanımları

```csharp
// Proje Durumları
public enum ProjectStatus {
    Planned = 1,      // Planlama aşamasında
    Active = 2,       // Aktif olarak çalışılıyor
    OnHold = 3,       // Beklemede
    Completed = 4,    // Tamamlandı
    Cancelled = 5     // İptal edildi
}

// Görev Durumları
public enum TaskStatus {
    Pending = 1,      // Bekliyor
    InProgress = 2,   // Devam ediyor
    Completed = 3,    // Tamamlandı
    Blocked = 4       // Engellenmiş
}

// Öncelik Seviyeleri
public enum Priority {
    Low = 1,          // Düşük
    Medium = 2,       // Orta
    High = 3,         // Yüksek
    Critical = 4      // Kritik
}

// Takım İçi Roller
public enum TeamRole {
    Owner = 1,        // Takım sahibi
    Admin = 2,        // Yönetici
    Developer = 3     // Geliştirici
}

// Davet Durumları
public enum InvitationStatus {
    Pending = 1,      // Bekliyor
    Accepted = 2,     // Kabul edildi
    Declined = 3,     // Reddedildi
    Expired = 4,      // Süresi doldu
    Cancelled = 5     // İptal edildi
}
```

---

## 3.3 Süreç Modeli - Hangisi ve Neden Seçtim?

### 3.3.1 Seçilen Model: Artırımlı Geliştirme (Incremental Development)

Bu proje için **Artırımlı Geliştirme** modelini seçtim. Her artırımda (increment) çalışan bir ürün ortaya çıkıyor.

**Neden Artırımlı Model?**

| Alternatif Model | Neden Seçmedim |
|------------------|----------------|
| **Şelale (Waterfall)** | Geri dönüş zor, değişikliklere kapalı |
| **Spiral** | Küçük projeler için fazla karmaşık |
| **Agile/Scrum** | Tek kişilik proje için sprint planlaması gereksiz |
| **RAD** | Prototip odaklı, mimari zayıf kalabilir |

**Artırımlı Modelin Avantajları:**
- Her artırımda çalışan bir ürün var
- Erken geri bildirim alınabilir
- Riskler erken tespit edilir
- Değişikliklere açık

### 3.3.2 Artırım Planı

```
Artırım 1 (Hafta 1-4): Temel Altyapı
├── Core katmanı (Entity'ler, Enum'lar)
├── Data katmanı (Repository, UnitOfWork)
├── Veritabanı migration'ları
└── Temel CRUD işlemleri

Artırım 2 (Hafta 5-6): İş Mantığı
├── Business katmanı (Service'ler)
├── DTO'lar ve Mapping
├── Validation kuralları
└── E-posta servisi

Artırım 3 (Hafta 7-10): Kullanıcı Arayüzü
├── Login/Register formları
├── Dashboard ve KPI'lar
├── Proje/Görev/Takım modülleri
├── Kanban board
└── Raporlama ekranları

Artırım 4 (Hafta 11-12): Entegrasyonlar
├── GitHub API entegrasyonu
├── Token pool yönetimi
├── Commit-Task eşleştirme
├── Web API (Plesk)
└── Davet kabul sayfası

Artırım 5 (Hafta 13-14): Test ve Dokümantasyon
├── 177 unit test
├── UML diyagramları
├── Ekran görüntüleri
└── Proje raporu
```

## 3.4 UML Diyagramları

### 3.4.1 Use Case Diyagramı

**Dosya:** `docs/UML/UseCase_Diagram.md`

4 aktör (Admin, ProjectManager, Developer, Pending) ve sistemdeki tüm kullanım senaryoları:

```
                    ┌─────────────────────────────────────┐
                    │         PROJECT TRACKER             │
                    │                                     │
    ┌───────┐       │  ┌─────────────────────────────┐   │
    │ Admin │───────┼──│ Kullanıcı Onaylama          │   │
    └───┬───┘       │  └─────────────────────────────┘   │
        │           │  ┌─────────────────────────────┐   │
        ├───────────┼──│ Rol Değiştirme              │   │
        │           │  └─────────────────────────────┘   │
        │           │  ┌─────────────────────────────┐   │
        └───────────┼──│ Tüm Verilere Erişim         │   │
                    │  └─────────────────────────────┘   │
                    │                                     │
┌───────────────┐   │  ┌─────────────────────────────┐   │
│ProjectManager │───┼──│ Proje Oluşturma/Düzenleme   │   │
└───────┬───────┘   │  └─────────────────────────────┘   │
        │           │  ┌─────────────────────────────┐   │
        ├───────────┼──│ Görev Atama                 │   │
        │           │  └─────────────────────────────┘   │
        │           │  ┌─────────────────────────────┐   │
        └───────────┼──│ Takım Yönetimi              │   │
                    │  └─────────────────────────────┘   │
                    │                                     │
  ┌───────────┐     │  ┌─────────────────────────────┐   │
  │ Developer │─────┼──│ Görev Görüntüleme           │   │
  └─────┬─────┘     │  └─────────────────────────────┘   │
        │           │  ┌─────────────────────────────┐   │
        └───────────┼──│ Görev Durumu Güncelleme     │   │
                    │  └─────────────────────────────┘   │
                    │                                     │
   ┌─────────┐      │  ┌─────────────────────────────┐   │
   │ Pending │──────┼──│ Bekleme Ekranı Görüntüleme  │   │
   └─────────┘      │  └─────────────────────────────┘   │
                    └─────────────────────────────────────┘
```

### 3.4.2 Class Diyagramı

**Dosya:** `docs/UML/Class_Diagram.md`

18 Entity sınıfı ve aralarındaki ilişkiler. Örnek sınıf yapısı:

```csharp
┌──────────────────────────────────────┐
│              User                     │
├──────────────────────────────────────┤
│ - UserId: int [PK]                   │
│ - RoleId: int [FK]                   │
│ - Username: string                   │
│ - PasswordHash: string               │
│ - FullName: string                   │
│ - Email: string                      │
│ - IsActive: bool                     │
│ - GitHubUsername: string?            │
│ - CreatedAt: DateTime                │
├──────────────────────────────────────┤
│ + Role: Role                         │
│ + CreatedProjects: ICollection       │
│ + AssignedTasks: ICollection         │
│ + OwnedTeams: ICollection            │
│ + TeamMemberships: ICollection       │
└──────────────────────────────────────┘
```

### 3.4.3 Activity Diyagramı

**Dosya:** `docs/UML/Activity_Diagram.md`

10 farklı iş akışı. Örnek: Davet Gönderme Akışı

```
    ┌─────────────┐
    │   Başla     │
    └──────┬──────┘
           ▼
    ┌─────────────────┐
    │ E-posta Gir     │
    └────────┬────────┘
             ▼
    ┌─────────────────┐
    │ Rol Seç         │
    └────────┬────────┘
             ▼
    ◇ Kullanıcı Mevcut mu?
   /                    \
  Evet                  Hayır
   │                      │
   ▼                      ▼
┌──────────┐      ┌──────────────┐
│ Direkt   │      │ Davet Oluştur│
│ Ekle     │      └──────┬───────┘
└────┬─────┘             │
     │                   ▼
     │           ┌──────────────┐
     │           │ Plesk API'ye │
     │           │ Gönder       │
     │           └──────┬───────┘
     │                  │
     │                  ▼
     │           ┌──────────────┐
     │           │ E-posta      │
     │           │ Gönder       │
     │           └──────┬───────┘
     │                  │
     └────────┬─────────┘
              ▼
       ┌─────────────┐
       │    Bitir    │
       └─────────────┘
```

### 3.4.4 Sequence Diyagramı

**Dosya:** `docs/UML/Sequence_Diagram.md`

7 farklı senaryo. Örnek: Login İşlemi

```
┌──────┐          ┌──────────┐          ┌───────────┐          ┌────────┐
│ User │          │ FrmLogin │          │UserService│          │Database│
└──┬───┘          └────┬─────┘          └─────┬─────┘          └───┬────┘
   │                   │                      │                    │
   │ Kullanıcı Adı/    │                      │                    │
   │ Şifre Gir         │                      │                    │
   │──────────────────>│                      │                    │
   │                   │                      │                    │
   │                   │ LoginAsync()         │                    │
   │                   │─────────────────────>│                    │
   │                   │                      │                    │
   │                   │                      │ GetByUsername()    │
   │                   │                      │───────────────────>│
   │                   │                      │                    │
   │                   │                      │ User               │
   │                   │                      │<───────────────────│
   │                   │                      │                    │
   │                   │                      │ BCrypt.Verify()    │
   │                   │                      │────────┐           │
   │                   │                      │        │           │
   │                   │                      │<───────┘           │
   │                   │                      │                    │
   │                   │ UserDto              │                    │
   │                   │<─────────────────────│                    │
   │                   │                      │                    │
   │ Dashboard Aç      │                      │                    │
   │<──────────────────│                      │                    │
   │                   │                      │                    │
```

## 3.5 Arayüz Tasarımı - Modüllerin ve Formların Tanıtımı

Uygulamayı geliştirirken kullanıcı deneyimini ön planda tuttum. DevExpress kontrolleri sayesinde profesyonel görünümlü, modern bir arayüz elde ettim. Dark theme tercih ettim çünkü göz yorgunluğunu azaltıyor ve modern bir görünüm sağlıyor.

### 3.5.1 Giriş Modülü

**Giriş Ekranı (FrmLogin)**

[Ekran görüntüsü: ProjectTracker.UI_Login.png]

Bu ekranda kullanıcılar sisteme giriş yapıyor. Sol tarafta projenin logosu ve tanıtımı, sağ tarafta ise giriş formu var. Kullanıcı adı ve şifre girildikten sonra BCrypt ile şifre doğrulaması yapılıyor. Eğer kullanıcı "Pending" rolündeyse bekleme ekranına, değilse ana dashboard'a yönlendiriliyor.

**Kayıt Ekranı (FrmRegister)**

[Ekran görüntüsü: ProjectTracker.UI_Register.png]

Yeni kullanıcılar bu ekrandan kayıt oluyor. Kullanıcı adı, tam ad, e-posta ve şifre alanları var. FluentValidation ile tüm girişler doğrulanıyor. Eğer kullanıcı bir davet linki ile geldiyse, invitation token otomatik olarak algılanıyor ve davetteki rol atanıyor.

**Onay Bekleme Ekranı (FrmPendingWaitlist)**

[Ekran görüntüsü: ProjectTracker.UI_UserPending.png]

Direkt kayıt olan kullanıcılar bu ekranı görüyor. "Admin onayınız bekleniyor" mesajı gösteriliyor. Admin onayladıktan sonra kullanıcı sisteme giriş yapabilir hale geliyor.

### 3.5.2 Dashboard Modülü

**Ana Form (FrmDashboard) - Master Container**

[Ekran görüntüsü: ProjectTracker.UI_FrmDashboard.png]

FrmDashboard, uygulamanın ana çatısını oluşturan master form. Giriş yapıldıktan sonra açılan bu form, tüm içerik panellerini (Content) barındıran bir container görevi görüyor. Yapısı şöyle:

- **Sol Sidebar:** Navigasyon menüsü - tüm modüllere erişim butonları
- **Üst Bar:** Kullanıcı bilgisi, bildirimler, çıkış butonu
- **Ana Panel:** Seçilen content'in yüklendiği alan

Sidebar'dan bir menü öğesine tıklandığında, ilgili UserControl (örn: ProjectsContent, TasksContent) ana panele dinamik olarak yükleniyor. Bu yaklaşım sayesinde:
- Tek bir form üzerinden tüm modüllere erişim sağlanıyor
- Kod tekrarı önleniyor
- Bellek kullanımı optimize ediliyor (sadece aktif content yüklü)

**Dashboard İçeriği (DashboardContent)**

[Ekran görüntüsü: ProjectTracker.UI_Dashboard.png]

Burası uygulamanın kalbi! FrmDashboard açıldığında varsayılan olarak yüklenen content. Üst kısımda KPI kartları var:
- Toplam proje sayısı
- Aktif görev sayısı
- Takım sayısı
- Bekleyen görevler

Alt kısımda ise son aktiviteler listesi (audit log'dan çekiliyor) ve hızlı erişim butonları var.

### 3.5.3 Proje Modülü

**Proje Listesi (ProjectsContent)**

[Ekran görüntüsü: ProjectTracker.UI_ProjectsList.png]

Tüm projeler burada listeleniyor. DevExpress GridControl kullandım - filtreleme, sıralama, gruplama özellikleri mevcut. Her projenin durumu renkli badge'lerle gösteriliyor (Active: yeşil, OnHold: sarı, Completed: mavi).

**Proje Oluşturma**

[Ekran görüntüsü: ProjectTracker.UI_ProjectCreate.png]

Yeni proje oluştururken şu bilgiler giriliyor:
- Proje adı ve açıklaması
- Başlangıç ve bitiş tarihi
- Bütçe
- Öncelik seviyesi (Low, Medium, High, Critical)
- Atanacak takım
- GitHub repository URL (opsiyonel)

**Proje Düzenleme**

[Ekran görüntüsü: ProjectTracker.UI_ProjectEdit.png]

Mevcut projeleri düzenlerken ek olarak şunları görebilirsiniz:
- Tamamlanma yüzdesi (görevlere göre otomatik hesaplanıyor)
- Risk skoru (0-100 arası, algoritma ile hesaplanıyor)
- Proje durumu değiştirme
- Projeye ait görevlerin listesi

### 3.5.4 Görev Modülü

**Görev Listesi - Grid Görünümü**

[Ekran görüntüsü: ProjectTracker.UI_TasksList.png]

Klasik liste görünümü. Proje ve kullanıcıya göre filtreleme yapılabiliyor. Durum ve öncelik kolonları renkli gösteriliyor. Çift tıklama ile görev detayına gidiliyor.

**Görev Listesi - Kanban Görünümü**

[Ekran görüntüsü: ProjectTracker.UI_TasksCanban.png]

Bu benim en sevdiğim özelliklerden biri! 4 kolon var:
- Pending (Bekleyen) - Gri
- InProgress (Devam Eden) - Mavi
- Completed (Tamamlanan) - Yeşil
- Blocked (Engellenen) - Kırmızı

Görevleri sürükle-bırak ile kolonlar arasında taşıyabilirsiniz. Durum otomatik güncelleniyor ve audit log'a kaydediliyor.

**Görev Düzenleme**

[Ekran görüntüsü: ProjectTracker.UI_TaskEdit.png]

Görev detaylarını düzenlerken:
- Görev adı ve açıklaması
- Hangi projeye ait
- Kime atandığı (atama yapıldığında e-posta gidiyor)
- Öncelik ve durum
- Tahmini ve gerçek çalışma saati
- Başlangıç ve bitiş tarihi
- Eşleşen GitHub commit'leri (varsa)

### 3.5.5 Takım Modülü

**Takım Listesi (TeamsContent)**

[Ekran görüntüsü: ProjectTracker.UI_Team.png]

Kullanıcının üye olduğu tüm takımlar listeleniyor. Sahip olduğu takımlar özel bir işaretle belirtiliyor. Takım kartlarında üye sayısı ve proje sayısı gösteriliyor.

**Takım Oluşturma**

[Ekran görüntüsü: ProjectTracker.UI_TeamCreate.png]

Yeni takım oluştururken sadece ad ve açıklama yeterli. Oluşturan kişi otomatik olarak "Owner" rolüyle ekleniyor.

**Takım Düzenleme**

[Ekran görüntüsü: ProjectTracker.UI_TeamEdit.png]

Takım bilgilerini düzenleme, üye listesini görme ve yeni üye davet etme işlemleri bu ekrandan yapılıyor.

**Takım Üyeleri (TeamMembersContent)**

[Ekran görüntüsü: ProjectTracker.UI_TeamMember.png]

Takımdaki tüm üyeler ve rolleri (Owner, Admin, Developer) listeleniyor. Admin yetkisi olanlar:
- Üye rolünü değiştirebilir
- Üyeyi takımdan çıkarabilir
- Pending kullanıcıları onaylayabilir

**Takım Davetleri (InvitationsContent)**

[Ekran görüntüsü: ProjectTracker.UI_TeamInvitations.png]

Gönderilen davetlerin listesi. Her davetin durumu görünüyor:
- Pending: Henüz yanıt verilmedi (Sarı)
- Accepted: Kabul edildi (Yeşil)
- Declined: Reddedildi (Kırmızı)
- Expired: Süresi doldu (Gri)

**Gelen Davetlerim (MyInvitationsContent)**

[Ekran görüntüsü: ProjectTracker.UI_MyInvitations.png]

Kullanıcıya gelen davetler burada listeleniyor. Kabul veya Red butonlarıyla yanıt verilebiliyor.

### 3.5.6 GitHub Modülü

**GitHub Analytics - Commit Listesi**

[Ekran görüntüsü: ProjectTracker.UI_GithubAnalytics1.png]

Projeye bağlı GitHub repository'den çekilen commit'ler burada listeleniyor. Her commit için:
- SHA (kısa)
- Commit mesajı
- Yazar ve avatar
- Tarih
- Eklenen/silinen satır sayısı
- Eşleşen görev (varsa)

"Sync" butonuyla en son commit'ler çekilebiliyor.

**GitHub Analytics - Contributor İstatistikleri**

[Ekran görüntüsü: ProjectTracker.UI_GithubAnalytics2.png]

Pie chart ile her geliştiricinin commit sayısı görselleştiriliyor. En aktif geliştiriciler kolayca görülebiliyor. Ayrıca toplam commit, branch ve contributor sayıları KPI kartlarında gösteriliyor.

**GitHub Analytics - File Hotspots**

[Ekran görüntüsü: ProjectTracker.UI_GithubAnalytics3.png]

En çok değişiklik yapılan dosyalar listeleniyor. Bu özellik, kod tabanındaki "hotspot"ları (sık değişen, potansiyel olarak sorunlu alanları) tespit etmeye yardımcı oluyor.

### 3.5.7 Raporlama Modülü

**Proje Bazlı Rapor**

[Ekran görüntüsü: ProjectTracker.UI_Reports1.png]

Seçilen projenin detaylı raporu:
- Görev dağılımı (durum bazlı pie chart)
- Tamamlanma yüzdesi
- Risk skoru ve risk faktörleri
- Takım üyelerinin performansı

**Kullanıcı Bazlı Rapor**

[Ekran görüntüsü: ProjectTracker.UI_Reports2.png]

Seçilen kullanıcının performans raporu:
- Atanan görev sayısı
- Tamamlanan görev sayısı
- Ortalama tamamlama süresi
- Verimlilik metrikleri

**Takım Bazlı Rapor**

[Ekran görüntüsü: ProjectTracker.UI_Reports3.png]

Takım performans raporu:
- Üye bazlı istatistikler
- Proje ilerlemeleri
- Toplam çalışma saatleri

Tüm raporlar PDF ve Excel formatında export edilebiliyor.

### 3.5.8 Ayarlar Modülü

**Kullanıcı Ayarları (UserSettingsContent)**

[Ekran görüntüsü: ProjectTracker.UI_Settings.png]

Kullanıcı kendi profilini düzenleyebiliyor:
- Ad, e-posta güncelleme
- Şifre değiştirme
- GitHub kullanıcı adı bağlama
- Profil fotoğrafı (GitHub'dan çekiliyor)

### 3.5.9 Hata Yönetimi

**Özel Mesaj Kutusu (FrmMessage)**

[Ekran görüntüsü: ProjectTracker.UI_Error.png]

Bir hata oluştuğunda veya bilgi verilmesi gerektiğinde kullanıcı dostu mesajlar gösteriliyor. Dark-themed özel mesaj kutusu tasarladım. Mesaj türüne göre farklı renkler kullanılıyor:
- Başarı: Yeşil
- Bilgi: Mavi
- Uyarı: Sarı
- Hata: Kırmızı

---

# 4. KODLAMA

## 4.1 Programlama Dili - Neden C#?

### 4.1.1 C# Seçim Nedenleri

| Neden | Açıklama |
|-------|----------|
| **Ders Gereksinimleri** | YMH219 dersi .NET ve C# odaklı |
| **Windows Forms Desteği** | Native Windows UI geliştirme |
| **Modern Syntax** | C# 12.0 ile primary constructors, pattern matching |
| **Güçlü Tip Sistemi** | Compile-time hata yakalama |
| **LINQ Desteği** | Veritabanı sorguları için güçlü araç |
| **Async/Await** | Asenkron programlama kolaylığı |
| **Entity Framework** | ORM desteği |
| **Geniş Ekosistem** | NuGet paketleri, topluluk desteği |

### 4.1.2 C# 12.0 Özellikleri Kullanımı

```csharp
// Primary Constructor (C# 12)
public class UserService(IUnitOfWork unitOfWork, IMapper mapper)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
}

// Pattern Matching
var result = status switch
{
    TaskStatus.Pending => "Bekliyor",
    TaskStatus.InProgress => "Devam Ediyor",
    TaskStatus.Completed => "Tamamlandı",
    _ => "Bilinmiyor"
};

// Null-conditional Operators
var userName = user?.FullName ?? "Anonim";

// Collection Expressions (C# 12)
List<string> roles = ["Admin", "ProjectManager", "Developer", "Pending"];
```

## 4.2 Modüller (Tek Tek)

### 4.2.1 Core Modülü (ProjectTracker.Core)

**Amaç:** Domain entity'leri ve interface'leri barındırır.

**İçerik:**
- 18 Entity sınıfı
- 7 Enum tanımı
- Repository interface'leri
- IUnitOfWork interface'i

```csharp
// Örnek Entity: User.cs
public class User
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public string? GitHubUsername { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    // Navigation Properties
    public virtual Role Role { get; set; } = null!;
    public virtual ICollection<Project> CreatedProjects { get; set; } = new List<Project>();
    public virtual ICollection<Task> AssignedTasks { get; set; } = new List<Task>();
}
```

### 4.2.2 Data Modülü (ProjectTracker.Data)

**Amaç:** Veritabanı erişim katmanı.

**İçerik:**
- AppDbContext (EF Core DbContext)
- Generic Repository<T>
- UnitOfWork
- Migrations

```csharp
// Generic Repository Pattern
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) 
        => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() 
        => await _dbSet.ToListAsync();

    public async Task AddAsync(T entity) 
        => await _dbSet.AddAsync(entity);

    public void Update(T entity) 
        => _dbSet.Update(entity);

    public void Delete(T entity) 
        => _dbSet.Remove(entity);
}
```

### 4.2.3 Business Modülü (ProjectTracker.Business)

**Amaç:** İş mantığı ve servisler.

**İçerik:**
- 14 Service sınıfı
- 27+ DTO sınıfı
- Validator sınıfları
- AutoMapper profilleri

**Service Listesi:**

| # | Service | Açıklama |
|---|---------|----------|
| 1 | UserService | Kullanıcı CRUD, login, rol yönetimi |
| 2 | ProjectService | Proje CRUD, risk hesaplama |
| 3 | TaskService | Görev CRUD, durum değişikliği |
| 4 | TeamService | Takım CRUD, üye yönetimi |
| 5 | InvitationService | Davet gönderme, kabul/red |
| 6 | AuditLogService | Aktivite loglama |
| 7 | ReportService | Temel raporlar |
| 8 | AdvancedReportService | Gelişmiş analitik |
| 9 | EmailService | SMTP e-posta gönderimi |
| 10 | RemoteInvitationService | Plesk API entegrasyonu |
| 11 | TokenPoolService | GitHub token havuzu yönetimi |
| 12 | TaskMatchingService | Commit-Task eşleştirme |
| 13 | GitHubSyncService | Repository senkronizasyonu |
| 14 | GitHubAnalyticsService | GitHub istatistikleri |

```csharp
// Örnek Service: ProjectService.cs
public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuditLogService _auditLogService;

    public async Task<ProjectDto> CreateAsync(CreateProjectDto dto, int userId)
    {
        var project = _mapper.Map<Project>(dto);
        project.CreatedByUserId = userId;
        project.CreatedAt = DateTime.Now;
        
        await _unitOfWork.Projects.AddAsync(project);
        await _unitOfWork.SaveChangesAsync();
        
        await _auditLogService.LogAsync("Projects", project.ProjectId, 
            "Created", null, project, userId);
        
        return _mapper.Map<ProjectDto>(project);
    }
}
```

### 4.2.4 UI Modülü (ProjectTracker.UI)

**Amaç:** Windows Forms kullanıcı arayüzü.

**İçerik:**
- 3 Ana Form (Login, Register, Dashboard)
- 12 UserControl (Content/Detail)
- Helper sınıfları
- DI Container yapılandırması

**Form/Control Listesi:**

| # | Form/Control | Açıklama |
|---|--------------|----------|
| 1 | FrmLogin | Giriş ekranı |
| 2 | FrmRegister | Kayıt ekranı |
| 3 | FrmPendingWaitlist | Onay bekleme ekranı |
| 4 | FrmDashboard | Ana dashboard (sidebar + content) |
| 5 | DashboardContent | KPI kartları, grafikler |
| 6 | ProjectsContent | Proje listesi |
| 7 | ProjectDetailControl | Proje detay/düzenleme |
| 8 | TasksContent | Görev listesi + Kanban |
| 9 | TaskDetailControl | Görev detay/düzenleme |
| 10 | TeamsContent | Takım listesi |
| 11 | TeamDetailControl | Takım detay/düzenleme |
| 12 | TeamMembersContent | Takım üyeleri |
| 13 | InvitationsContent | Davetler |
| 14 | MyInvitationsContent | Gelen davetlerim |
| 15 | GitHubContent | GitHub Analytics |
| 16 | ReportsContent | Raporlar |
| 17 | UserSettingsContent | Kullanıcı ayarları |

### 4.2.5 API Modülü (ProjectTracker.API)

**Amaç:** Web üzerinden davet kabul için REST API.

**İçerik:**
- Minimal API endpoints
- InvitationDbContext
- CORS yapılandırması

```csharp
// Minimal API Endpoints
app.MapGet("/api/invitations/validate", async (string token, InvitationDbContext db) =>
{
    var invitation = await db.Invitations
        .FirstOrDefaultAsync(i => i.Token == token);
    
    if (invitation == null)
        return Results.NotFound(new { isValid = false });
    
    return Results.Ok(new {
        isValid = true,
        teamName = invitation.TeamName,
        invitedBy = invitation.InvitedByName,
        proposedRole = invitation.ProposedRole
    });
});

app.MapPost("/api/invitations/accept", async (AcceptRequest request, InvitationDbContext db) =>
{
    var invitation = await db.Invitations
        .FirstOrDefaultAsync(i => i.Token == request.Token);
    
    if (invitation == null)
        return Results.NotFound();
    
    invitation.Status = "Accepted";
    invitation.RespondedAt = DateTime.Now;
    await db.SaveChangesAsync();
    
    return Results.Ok(new { success = true });
});
```

## 4.3 Kod Stilleri

### 4.3.1 Naming Conventions

| Öğe | Kural | Örnek |
|-----|-------|-------|
| Class | PascalCase | `UserService`, `ProjectDto` |
| Interface | I + PascalCase | `IUserService`, `IRepository` |
| Method | PascalCase | `GetByIdAsync`, `CreateProject` |
| Property | PascalCase | `UserId`, `ProjectName` |
| Private Field | _camelCase | `_unitOfWork`, `_mapper` |
| Parameter | camelCase | `userId`, `projectDto` |
| Constant | UPPER_CASE | `MAX_RETRY_COUNT` |
| Async Method | ...Async | `GetAllAsync`, `SaveChangesAsync` |

### 4.3.2 Kod Organizasyonu

```csharp
// Standart sınıf yapısı
public class UserService : IUserService
{
    // 1. Private fields
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    // 2. Constructor
    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // 3. Public methods
    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        return _mapper.Map<UserDto>(user);
    }

    // 4. Private helper methods
    private bool ValidatePassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
```

### 4.3.3 SOLID Prensipleri Uygulaması

| Prensip | Uygulama |
|---------|----------|
| **S**ingle Responsibility | Her service tek bir entity'den sorumlu |
| **O**pen/Closed | Generic Repository ile genişletilebilir |
| **L**iskov Substitution | Interface'ler ile soyutlama |
| **I**nterface Segregation | Küçük, odaklı interface'ler |
| **D**ependency Inversion | Constructor injection ile DI |

---

## 4.4 Program Karmaşıklığı

### 4.4.1 İşlev Nokta Analizi (Function Point Analysis)

| Parametre | Toplam |
|-----------|--------|
| Kullanıcı Girdi (EI) | 90 |
| Kullanıcı Çıktı (EO) | 134 |
| Kullanıcı Sorgu (EQ) | 84 |
| Dahili Mantıksal Dosya (ILF) | 212 |
| Harici Arayüz Dosya (EIF) | 31 |
| **Ayarlanmamış İşlev Noktası (AİN)** | **551** |

### 4.4.2 Teknik Karmaşıklık Faktörü (TKF)

| # | Soru | Puan (0-5) |
|---|------|------------|
| 1 | Veri iletişimi | 4 |
| 2 | Dağıtık veri işleme | 3 |
| 3 | Performans | 3 |
| 4 | Yoğun kullanılan konfigürasyon | 3 |
| 5 | İşlem hızı | 3 |
| 6 | Online veri girişi | 5 |
| 7 | Son kullanıcı verimliliği | 4 |
| 8 | Online güncelleme | 5 |
| 9 | Karmaşık işleme | 4 |
| 10 | Yeniden kullanılabilirlik | 4 |
| 11 | Kurulum kolaylığı | 3 |
| 12 | İşletim kolaylığı | 4 |
| 13 | Çoklu site | 2 |
| 14 | Değişiklik kolaylığı | 4 |
| **Toplam TKP** | **51** |

```
TKF = 0.65 + (0.01 × 51) = 1.16
```

### 4.4.3 Ayarlanmış İşlev Noktası

```
İN = AİN × TKF
İN = 551 × 1.16
İN = 639
```

### 4.4.4 Kod Satır Sayısı Tahmini

| Dil | Satır/İN | Kullanım Oranı | Tahmini Satır |
|-----|----------|----------------|---------------|
| C# | 30 | %85 | 16,294 |
| JavaScript | 25 | %10 | 1,598 |
| SQL | 15 | %5 | 479 |
| **TOPLAM** | | | **~18,371** |

### 4.4.5 Karmaşıklık Değerlendirmesi

```
İN Değeri: 639

Karmaşıklık Skalası:
- 0-100: Basit
- 100-300: Orta
- 300-600: Karmaşık
- 600+: Çok Karmaşık

Sonuç: ÇOK KARMAŞIK PROJE ✓
```

### 4.4.6 Karmaşıklığı Artıran Faktörler

1. **Dual-Database Mimarisi** - Local SQL Server + Plesk Remote DB
2. **GitHub API Entegrasyonu** - Rate limiting, token pool yönetimi
3. **Akıllı Algoritmalar** - Risk hesaplama, commit-task eşleştirme
4. **E-posta Bildirimleri** - SMTP entegrasyonu
5. **Katmanlı Mimari** - 5 katmanlı enterprise mimari
6. **DevExpress UI** - Profesyonel UI bileşenleri
7. **Kanban Board** - Drag & drop görev yönetimi
8. **Raporlama Sistemi** - Çoklu rapor türleri

## 4.5 Akıllı Algoritmalar

### 4.5.1 Risk Skoru Hesaplama Algoritması

**Amaç:** Projelerin gecikme riskini 0-100 arasında hesaplamak.

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

### 4.5.2 Commit-Task Eşleştirme Algoritması

**Amaç:** GitHub commit'lerini otomatik olarak ilgili görevlere bağlamak.

**Formül:**
```
EşleşmeSkoru = (TaskAdıBenzerliği × 0.4) + 
               (AnahtarKelimeEşleşmesi × 0.3) + 
               (TaskIDEşleşmesi × 0.3)
```

**Algoritma Adımları:**
1. Task ID Pattern Arama (#123, TASK-123, [123])
2. Kelime Benzerliği Hesaplama
3. Levenshtein Distance ile benzerlik
4. Skor > 0.3 ise eşleşme kabul

**Örnek:**
```
Task: "Login Bug Fix"
Commit: "Fixed login validation bug #42"

TaskIDEşleşmesi: 0.0 (ID eşleşmedi)
AnahtarKelimeEşleşmesi: 0.67 ("login", "bug", "fix" kelimelerinden 2'si eşleşti)
TaskAdıBenzerliği: 0.45 (Levenshtein distance)

Toplam Skor: (0.45 × 0.4) + (0.67 × 0.3) + (0.0 × 0.3) = 0.38 ✅ Eşleşme!
```

---

# 5. DOĞRULAMA VE GEÇERLEME

## 5.1 Arayüz Çalışıyor mu? (Fonksiyonel Testler)

Her modül için arayüz testleri yapıldı. Aşağıda test edilen senaryolar ve sonuçları:

### 5.1.1 Giriş Modülü Testleri

| Test Senaryosu | Beklenen Sonuç | Gerçek Sonuç | Durum |
|----------------|----------------|--------------|-------|
| Doğru kullanıcı adı/şifre ile giriş | Dashboard açılır | Dashboard açıldı | ✅ Başarılı |
| Yanlış şifre ile giriş | Hata mesajı gösterilir | Hata mesajı gösterildi | ✅ Başarılı |
| Boş kullanıcı adı ile giriş | Validation hatası | Validation hatası gösterildi | ✅ Başarılı |
| Pending kullanıcı girişi | Bekleme ekranı açılır | Bekleme ekranı açıldı | ✅ Başarılı |
| Kayıt formu doldurma | Kullanıcı oluşturulur | Kullanıcı oluşturuldu | ✅ Başarılı |

### 5.1.2 Dashboard Modülü Testleri

| Test Senaryosu | Beklenen Sonuç | Gerçek Sonuç | Durum |
|----------------|----------------|--------------|-------|
| KPI kartları yükleniyor | Doğru sayılar gösterilir | Doğru sayılar gösterildi | ✅ Başarılı |
| Son aktiviteler listesi | Audit log'dan veri çekilir | Veriler çekildi | ✅ Başarılı |
| Sidebar navigasyonu | İlgili content açılır | Content'ler açıldı | ✅ Başarılı |

### 5.1.3 Proje Modülü Testleri

| Test Senaryosu | Beklenen Sonuç | Gerçek Sonuç | Durum |
|----------------|----------------|--------------|-------|
| Proje listesi yükleniyor | Projeler listelenir | Projeler listelendi | ✅ Başarılı |
| Yeni proje oluşturma | Proje kaydedilir | Proje kaydedildi | ✅ Başarılı |
| Proje düzenleme | Değişiklikler kaydedilir | Değişiklikler kaydedildi | ✅ Başarılı |
| Proje silme | Proje silinir | Proje silindi | ✅ Başarılı |
| GitHub repo bağlama | Repo bağlanır | Repo bağlandı | ✅ Başarılı |

### 5.1.4 Görev Modülü Testleri

| Test Senaryosu | Beklenen Sonuç | Gerçek Sonuç | Durum |
|----------------|----------------|--------------|-------|
| Görev listesi (Grid) | Görevler listelenir | Görevler listelendi | ✅ Başarılı |
| Görev listesi (Kanban) | 4 kolon gösterilir | 4 kolon gösterildi | ✅ Başarılı |
| Kanban sürükle-bırak | Durum güncellenir | Durum güncellendi | ✅ Başarılı |
| Görev oluşturma | Görev kaydedilir | Görev kaydedildi | ✅ Başarılı |
| Görev atama | E-posta gönderilir | E-posta gönderildi | ✅ Başarılı |

### 5.1.5 Takım Modülü Testleri

| Test Senaryosu | Beklenen Sonuç | Gerçek Sonuç | Durum |
|----------------|----------------|--------------|-------|
| Takım listesi | Takımlar listelenir | Takımlar listelendi | ✅ Başarılı |
| Takım oluşturma | Takım kaydedilir | Takım kaydedildi | ✅ Başarılı |
| Üye ekleme | Üye eklenir | Üye eklendi | ✅ Başarılı |
| Davet gönderme | E-posta gönderilir | E-posta gönderildi | ✅ Başarılı |
| Web'den davet kabul | Davet kabul edilir | Davet kabul edildi | ✅ Başarılı |

### 5.1.6 GitHub Modülü Testleri

| Test Senaryosu | Beklenen Sonuç | Gerçek Sonuç | Durum |
|----------------|----------------|--------------|-------|
| Commit listesi | Commit'ler çekilir | Commit'ler çekildi | ✅ Başarılı |
| Sync butonu | Yeni commit'ler çekilir | Yeni commit'ler çekildi | ✅ Başarılı |
| Contributor istatistikleri | Pie chart gösterilir | Pie chart gösterildi | ✅ Başarılı |
| File hotspots | En çok değişen dosyalar | Dosyalar listelendi | ✅ Başarılı |

### 5.1.7 Raporlama Modülü Testleri

| Test Senaryosu | Beklenen Sonuç | Gerçek Sonuç | Durum |
|----------------|----------------|--------------|-------|
| Proje raporu | Rapor gösterilir | Rapor gösterildi | ✅ Başarılı |
| PDF export | PDF dosyası oluşur | PDF oluşturuldu | ✅ Başarılı |
| Excel export | Excel dosyası oluşur | Excel oluşturuldu | ✅ Başarılı |

## 5.2 Unit Test Sonuçları

### 5.2.1 Test Özeti

| Metrik | Değer |
|--------|-------|
| Toplam Test Sayısı | 177 |
| Başarılı | 177 |
| Başarısız | 0 |
| Başarı Oranı | %100 |

### 5.2.2 Servis Bazlı Test Dağılımı

| # | Servis | Test Sayısı | Durum |
|---|--------|-------------|-------|
| 1 | UserService | 17 | ✅ Başarılı |
| 2 | ProjectService | 12 | ✅ Başarılı |
| 3 | TaskService | 12 | ✅ Başarılı |
| 4 | TeamService | 14 | ✅ Başarılı |
| 5 | InvitationService | 18 | ✅ Başarılı |
| 6 | AuditLogService | 9 | ✅ Başarılı |
| 7 | ReportService | 7 | ✅ Başarılı |
| 8 | TokenPoolService | 10 | ✅ Başarılı |
| 9 | TaskMatchingService | 8 | ✅ Başarılı |
| 10 | GitHubAnalyticsService | 14 | ✅ Başarılı |
| 11 | GitHubSyncService | 14 | ✅ Başarılı |
| 12 | EmailService | 12 | ✅ Başarılı |
| 13 | AdvancedReportService | 18 | ✅ Başarılı |
| 14 | RemoteInvitationService | 12 | ✅ Başarılı |
| **TOPLAM** | | **177** | **%100 Başarı** |

### 5.2.3 Test Teknolojileri

| Teknoloji | Versiyon | Kullanım |
|-----------|----------|----------|
| xUnit | 2.5.3 | Test framework |
| Moq | 4.20.70 | Mocking library |
| FluentAssertions | 6.12.0 | Assertion library |
| InMemory DB | 8.0.0 | Test veritabanı |

### 5.2.4 Örnek Test Kodu

```csharp
public class UserServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _userService = new UserService(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ExistingUser_ReturnsUserDto()
    {
        // Arrange
        var user = new User { UserId = 1, Username = "testuser" };
        var userDto = new UserDto { UserId = 1, Username = "testuser" };
        
        _mockUnitOfWork.Setup(u => u.Users.GetByIdAsync(1))
            .ReturnsAsync(user);
        _mockMapper.Setup(m => m.Map<UserDto>(user))
            .Returns(userDto);

        // Act
        var result = await _userService.GetByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.UserId.Should().Be(1);
        result.Username.Should().Be("testuser");
    }

    [Fact]
    public async Task LoginAsync_ValidCredentials_ReturnsUser()
    {
        // Arrange
        var passwordHash = BCrypt.Net.BCrypt.HashPassword("password123");
        var user = new User { Username = "testuser", PasswordHash = passwordHash };
        
        _mockUnitOfWork.Setup(u => u.Users.GetByUsernameAsync("testuser"))
            .ReturnsAsync(user);

        // Act
        var result = await _userService.LoginAsync("testuser", "password123");

        // Assert
        result.Should().NotBeNull();
    }
}
```

## 5.3 Kod Kalitesi - SonarQube Analizi

### 5.3.1 SonarQube Metrikleri

| Metrik | Değer | Durum |
|--------|-------|-------|
| Bugs | 0 | ✅ A |
| Vulnerabilities | 0 | ✅ A |
| Code Smells | 12 | ✅ A |
| Coverage | %85 | ✅ A |
| Duplications | %2.3 | ✅ A |
| Technical Debt | 2h | ✅ A |

### 5.3.2 Kod Kalitesi Özellikleri

| Özellik | Uygulama |
|---------|----------|
| **Null Safety** | Nullable reference types aktif |
| **Exception Handling** | Try-catch blokları, custom exceptions |
| **Logging** | Audit log sistemi |
| **Validation** | FluentValidation ile input doğrulama |
| **Security** | BCrypt şifreleme, AES token şifreleme |
| **Performance** | Async/await, lazy loading |

---

# 6. SONUÇ

## 6.1 Projenin Genel Değerlendirmesi

### 6.1.1 Başarılar

| Başarı | Açıklama |
|--------|----------|
| ✅ **Sağlam Mimari** | 5 katmanlı enterprise mimari, SOLID prensipleri |
| ✅ **Modern Teknolojiler** | .NET 8.0, EF Core 8.0, C# 12.0 |
| ✅ **Profesyonel UI** | DevExpress kontrolleri, dark theme |
| ✅ **GitHub Entegrasyonu** | Commit senkronizasyonu, akıllı eşleştirme |
| ✅ **Kapsamlı Test** | 177 unit test, %100 başarı |
| ✅ **Dual-Database** | Yaratıcı çözüm, web entegrasyonu |
| ✅ **E-posta Sistemi** | Gmail SMTP, davet bildirimleri |
| ✅ **Raporlama** | PDF/Excel export, analitik |

### 6.1.2 Eksiklikler

| Eksiklik | Neden? | Öncelik |
|----------|--------|---------|
| ❌ Real-time Bildirimler | SignalR karmaşık, zaman yetmedi | Yüksek |
| ❌ Mobil Uygulama | Kapsam dışı | Orta |
| ❌ Dosya Yükleme | Depolama altyapısı gerekli | Orta |
| ❌ Gantt Chart | DevExpress lisans gerekli | Düşük |

## 6.2 Projenin Bana Katkısı

### 6.2.1 Teknik Beceriler

| Beceri | Öğrenilen |
|--------|-----------|
| **Mimari** | Katmanlı mimari, SOLID, Design Patterns |
| **ORM** | Entity Framework Core, Code-First, Migrations |
| **API** | REST API, Minimal API, CORS |
| **Entegrasyon** | GitHub API, SMTP, Remote Database |
| **Test** | Unit testing, Mocking, TDD |
| **UI** | DevExpress, Windows Forms, Dark Theme |
| **Güvenlik** | BCrypt, AES şifreleme |

### 6.2.2 Soft Skills

| Beceri | Gelişim |
|--------|---------|
| **Proje Yönetimi** | Artırımlı geliştirme, zaman planlaması |
| **Problem Çözme** | Dual-database mimarisi çözümü |
| **Dokümantasyon** | UML, teknik dokümantasyon |
| **Araştırma** | Yeni teknolojileri öğrenme |

## 6.3 Proje Metrikleri Özeti

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
| Form/UserControl | 17 |
| DTO Sınıfı | 27+ |

## 6.4 Gelecek Planları

| Özellik | Açıklama | Tahmini Süre |
|---------|----------|--------------|
| **SignalR** | Real-time bildirimler | 2-3 hafta |
| **Mobil App** | .NET MAUI ile iOS/Android | 2-3 ay |
| **Gantt Chart** | Proje zaman çizelgesi | 1-2 hafta |
| **Dosya Yönetimi** | Proje dosyaları | 2-3 hafta |
| **Takvim** | Görev takvimi | 1 hafta |

---

# 7. KAYNAKLAR

## 7.1 Kitaplar

1. Albahari, J. (2022). *C# 10 in a Nutshell*. O'Reilly Media.
2. Freeman, A. (2022). *Pro ASP.NET Core 6*. Apress.
3. Smith, J. (2021). *Entity Framework Core in Action*. Manning.
4. Martin, R. C. (2017). *Clean Architecture*. Prentice Hall.

## 7.2 Online Dokümantasyon

1. Microsoft Docs - .NET Documentation: https://docs.microsoft.com/dotnet
2. Entity Framework Core Documentation: https://docs.microsoft.com/ef/core
3. DevExpress Documentation: https://docs.devexpress.com
4. GitHub REST API Documentation: https://docs.github.com/rest
5. FluentValidation Documentation: https://docs.fluentvalidation.net
6. AutoMapper Documentation: https://docs.automapper.org
7. xUnit Documentation: https://xunit.net/docs

## 7.3 GitHub Linkleri

1. Proje Repository: https://github.com/BilalAbic/ProjectTracker
2. Web Sitesi: https://pt.bilalabic.com
3. API: https://bilalabic.com/api

## 7.4 Eğitim Videoları

1. .NET 8 Tutorial Series - Microsoft Learn
2. Entity Framework Core Tutorial - Tim Corey (YouTube)
3. DevExpress WinForms Tutorial - DevExpress YouTube Channel
4. Clean Architecture - Jason Taylor (YouTube)
5. Unit Testing in C# - Nick Chapsas (YouTube)

## 7.5 Kullanılan NuGet Paketleri

| Paket | Versiyon | Kullanım |
|-------|----------|----------|
| Microsoft.EntityFrameworkCore | 8.0.0 | ORM |
| Microsoft.EntityFrameworkCore.SqlServer | 8.0.0 | SQL Server provider |
| AutoMapper | 12.0.1 | Object mapping |
| FluentValidation | 11.9.0 | Validation |
| BCrypt.Net-Next | 4.0.3 | Password hashing |
| Octokit | 9.1.2 | GitHub API client |
| EPPlus | 6.2.4 | Excel export |
| iTextSharp | 5.5.13.3 | PDF export |
| DevExpress.WindowsForms | 25.1.7 | UI controls |
| xUnit | 2.5.3 | Test framework |
| Moq | 4.20.70 | Mocking |
| FluentAssertions | 6.12.0 | Assertions |

---

**Rapor Tarihi:** Ocak 2026
**Proje:** Project Tracker - Akıllı Proje Yönetim Sistemi
**Öğrenci:** 240542031 - Bilal ABİÇ
**Ders:** YMH219 - Nesne Tabanlı Programlama
**Danışman:** Dr. Öğr. Üyesi V. Cem BAYDOĞAN
