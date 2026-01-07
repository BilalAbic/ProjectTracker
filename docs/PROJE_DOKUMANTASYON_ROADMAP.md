# 📋 Project Tracker - Proje Dokümantasyonu Roadmap

## FIRAT ÜNİVERSİTESİ - YMH219 Nesne Tabanlı Programlama
### Proje Dokümantasyonu Hazırlama Planı

---

## 📌 Genel Bakış

Bu roadmap, YMH219 dersi için gerekli olan proje dokümantasyonunun adım adım hazırlanması için oluşturulmuştur.

**Proje:** Project Tracker - Akıllı Proje Yönetim Sistemi  
**Öğrenci:** 240542031 - Bilal ABİÇ  
**Tarih:** Ocak 2026

---

## 🏗️ Proje Mimarisi Özeti

### Katmanlı Mimari (5 Proje)

```
ProjectTracker.sln
│
├── src/
│   ├── ProjectTracker.Core/          [Domain Layer - 18 Entity, 7 Enum, 8 Interface]
│   ├── ProjectTracker.Data/          [Data Access Layer - 7 Repository, Migrations]
│   ├── ProjectTracker.Business/      [Business Layer - 14 Service, 27 DTO, 3 Validator]
│   ├── ProjectTracker.UI/            [Presentation Layer - 4 Form, 13 UserControl]
│   └── ProjectTracker.API/           [Web API - Invitation Controller]
│
├── tests/
│   └── ProjectTracker.Tests/         [Unit Test Projesi]
│
├── GitHubAnalyzerTest/               [GitHub Entegrasyon Test Projesi]
│
├── web/                              [Web Davet Sayfası]
│
├── SeedDataScript/                   [Veritabanı Seed Script'leri]
│
└── docs/                             [Dokümantasyon]
```

---

## � Proje İstatistikleri

| Kategori | Sayı | Detay |
|----------|------|-------|
| **Toplam Proje** | 7 | Core, Data, Business, UI, API, Tests, GitHubAnalyzerTest |
| **Entity Sınıfları** | 18 | User, Project, Task, Team, TeamMember, vb. |
| **Enum Tanımları** | 7 | ProjectStatus, TaskStatus, Priority, vb. |
| **Repository** | 7 | Generic + 6 özel repository |
| **Service** | 14 | ProjectService, TaskService, TeamService, vb. |
| **DTO** | 27+ | Create, Update, View DTO'ları |
| **Validator** | 3 | Login, Register, Project |
| **Form** | 4 | Login, Register, Dashboard, PendingWaitlist |
| **UserControl** | 13 | Dashboard, Projects, Tasks, Teams, Reports, vb. |
| **Veritabanı Tablosu** | 18+ | Migration'lardan |
| **Ekran Görüntüsü** | 24 | Tüm modüller |

---

## 📁 Hedef Klasör Yapısı

```
docs/
├── Reports/
│   ├── FINAL_RAPOR.md                  # ✅ Ana dokümantasyon
│   └── MALIYET_KESTIRIM.md             # ✅ İşlev nokta analizi
│
├── Screenshots/                         # ✅ Mevcut (24 ekran görüntüsü)
│
└── UML/
    ├── UseCase_Diagram.md              # ✅ Kullanım senaryoları
    ├── Class_Diagram.md                # ✅ Sınıf diyagramı (Entity'ler)
    ├── Activity_Diagram.md             # ✅ İş akışları
    ├── Sequence_Diagram.md             # ✅ Sıralı etkileşimler
    └── ER_Diagram.md                   # ✅ Veritabanı şeması
```

---

## 🗓️ AŞAMA 1: UML Diyagramları ✅ TAMAMLANDI
**Öncelik:** Kritik | **Tahmini Süre:** 2-3 saat | **Durum:** ✅ Tamamlandı

### 1.1 Use Case Diyagramı ✅
**Dosya:** `docs/UML/UseCase_Diagram.md`

İçerik:
- 4 Aktör: Admin, Proje Yöneticisi, Geliştirici, Pending (Onay Bekleyen)
- Kullanıcı Yönetimi Use Case'leri
- Proje Yönetimi Use Case'leri
- Görev Yönetimi Use Case'leri
- Takım Yönetimi Use Case'leri
- Raporlama Use Case'leri
- GitHub Entegrasyonu Use Case'leri

### 1.2 Class Diyagramı ✅
**Dosya:** `docs/UML/Class_Diagram.md`

Entity Sınıfları (18 adet):
| # | Entity | Açıklama |
|---|--------|----------|
| 1 | User | Kullanıcı bilgileri |
| 2 | Role | Sistem rolleri |
| 3 | Project | Proje bilgileri |
| 4 | Task | Görev bilgileri |
| 5 | TaskComment | Görev yorumları |
| 6 | Team | Takım bilgileri |
| 7 | TeamMember | Takım üyelikleri |
| 8 | TeamInvitation | Takım davetleri |
| 9 | ProjectTeamMember | Proje-Kullanıcı ilişkisi |
| 10 | ProjectRisk | Risk kayıtları |
| 11 | ProjectSnapshot | Proje anlık görüntüleri |
| 12 | Notification | Bildirimler |
| 13 | TimeEntry | Zaman kayıtları |
| 14 | AuditLog | Denetim kayıtları |
| 15 | GitRepository | GitHub repo bilgileri |
| 16 | GitCommit | Commit kayıtları |
| 17 | GitFileChange | Dosya değişiklikleri |
| 18 | GitHubToken | GitHub token'ları |

Enum Tanımları (7 adet):
- ProjectStatus, TaskStatus, Priority, TeamRole
- InvitationStatus, NotificationType, ActivityType

### 1.3 Activity Diyagramı ✅
**Dosya:** `docs/UML/Activity_Diagram.md`

İş Akışları (10 adet):
- Kullanıcı Kayıt Akışı (Direkt + Davetli)
- Kullanıcı Giriş Akışı
- Proje Oluşturma Akışı
- Görev Atama Akışı (E-posta bildirimi ile)
- Görev Durumu Değiştirme Akışı
- Takım Daveti Gönderme Akışı (Dual-Database mimarisi)
- Davet Kabul/Red Akışı (Web + Uygulama İçi)
- GitHub Repo Bağlama Akışı
- Risk Hesaplama Akışı

### 1.4 Sequence Diyagramı ✅
**Dosya:** `docs/UML/Sequence_Diagram.md`

Senaryolar (7 adet):
- Kullanıcı Girişi (Login)
- Görev Oluşturma ve E-posta Bildirimi
- Takım Daveti Gönderme (Dual-Database)
- Web Üzerinden Davet Kabul (Plesk DB)
- Davetli Kullanıcı Kayıt (Local DB)
- GitHub Sync İşlemi
- Görev Durumu Değiştirme

### 1.5 ER Diyagramı ✅
**Dosya:** `docs/UML/ER_Diagram.md`

Tablolar ve İlişkiler:
- 18 tablo (Local DB)
- 1 tablo (Plesk Remote DB - Invitations)
- Foreign Key ilişkileri
- Index tanımları
- Dual-Database mimarisi açıklaması

---

## 🗓️ AŞAMA 2: Maliyet Kestirim Dokümanı ✅ TAMAMLANDI
**Öncelik:** Yüksek | **Tahmini Süre:** 30 dakika | **Durum:** ✅ Tamamlandı

**Dosya:** `docs/Reports/MALIYET_KESTIRIM.md`

### İşlev Nokta Analizi Sonuçları

| Parametre | Sayı | Ağırlık | Toplam |
|-----------|------|---------|--------|
| Kullanıcı Girdi (EI) | 21 | 3-6 | 90 |
| Kullanıcı Çıktı (EO) | 22 | 4-7 | 134 |
| Kullanıcı Sorgu (EQ) | 18 | 3-6 | 84 |
| Dahili Mantıksal Dosya (ILF) | 18 | 7-15 | 212 |
| Harici Arayüz Dosya (EIF) | 4 | 5-10 | 31 |
| **AİN (Ayarlanmamış İN)** | | | **551** |

### Hesaplama Sonuçları
- TKF (Teknik Karmaşıklık Faktörü): 1.16
- İN (Ayarlanmış İşlev Noktası): 639
- Tahmini Kod Satır Sayısı: ~18,371
- Proje Karmaşıklık Seviyesi: **ÇOK KARMAŞIK**
- Tahmini Maliyet: 68,650 TL

---

## 🗓️ AŞAMA 3: Final Rapor ✅ TAMAMLANDI
**Öncelik:** Kritik | **Tahmini Süre:** 4-5 saat | **Durum:** ✅ Tamamlandı

**Dosya:** `docs/Reports/FINAL_RAPOR.md`

### İçerik Özeti:
- ✅ Bölüm 1: GİRİŞ (Tanıtım, Amaç, Kapsam, Teknolojiler)
- ✅ Bölüm 2: PROJE PLANI (Kullanıcılar, İş Akışı, İhtiyaçlar, UML)
- ✅ Bölüm 3: PROJE GERÇEKLEŞTİRİLMESİ (24 ekran görüntüsü ile)
- ✅ Bölüm 4: SONUÇ VE DEĞERLENDİRME
- ✅ Bölüm 5: KAYNAKLAR
- ✅ Bölüm 6: EKLER

### Modül Ekran Görüntüleri (24 adet):
| Modül | Ekran Sayısı |
|-------|--------------|
| Login | 3 |
| Dashboard | 1 |
| Proje | 3 |
| Görev | 3 |
| Takım | 6 |
| GitHub | 3 |
| Raporlar | 3 |
| Ayarlar | 1 |
| Hata | 1 |

### Bölüm 6: SONUÇ
- Projenin değerlendirmesi
- Artıları ve eksileri
- Kişisel katkılar

### Bölüm 7: KAYNAKLAR
- Kullanılan teknolojiler
- Referans kaynaklar
- GitHub linkleri

---

## 🗓️ AŞAMA 4: Kurulum Kılavuzu
**Öncelik:** Orta | **Tahmini Süre:** 1 saat

**Dosya:** `docs/Reports/KURULUM_KILAVUZU.md`

İçerik:
- Sistem Gereksinimleri
- .NET 8.0 SDK Kurulumu
- SQL Server Kurulumu
- Veritabanı Oluşturma
- Connection String Ayarları
- İlk Çalıştırma
- Seed Data Yükleme
- Sorun Giderme

---

## 🗓️ AŞAMA 5: Test Dokümanı ✅ TAMAMLANDI
**Öncelik:** Orta | **Tahmini Süre:** 1 saat | **Durum:** ✅ Tamamlandı

**Dosya:** `tests/ProjectTracker.Tests/`

### Test Projesi Yapısı
```
tests/ProjectTracker.Tests/
├── ProjectTracker.Tests.csproj
└── Services/
    ├── UserServiceTests.cs              (17 test)
    ├── ProjectServiceTests.cs           (12 test)
    ├── TaskServiceTests.cs              (12 test)
    ├── TeamServiceTests.cs              (14 test)
    ├── InvitationServiceTests.cs        (18 test)
    ├── AuditLogServiceTests.cs          (9 test)
    ├── ReportServiceTests.cs            (7 test)
    ├── TokenPoolServiceTests.cs         (10 test)
    ├── TaskMatchingServiceTests.cs      (8 test)
    ├── GitHubAnalyticsServiceTests.cs   (14 test)
    ├── GitHubSyncServiceTests.cs        (14 test)
    ├── EmailServiceTests.cs             (12 test)
    ├── AdvancedReportServiceTests.cs    (18 test)
    └── RemoteInvitationServiceTests.cs  (12 test)
```

### Test İstatistikleri
| Servis | Test Sayısı | Kapsam |
|--------|-------------|--------|
| UserService | 17 | Login, Register, GetUser, Deactivate |
| ProjectService | 12 | CRUD, Risk Hesaplama, Completion % |
| TaskService | 12 | CRUD, Status Change, Email Notification |
| TeamService | 14 | CRUD, Member Management, Role Update |
| InvitationService | 18 | Send, Accept, Decline, Cancel |
| AuditLogService | 9 | Log Activity, Get Activities |
| ReportService | 7 | Project/Task Statistics |
| TokenPoolService | 10 | Token CRUD, Pool Status |
| TaskMatchingService | 8 | Commit-Task Matching |
| GitHubAnalyticsService | 14 | Analytics, Leaderboard, Trends |
| GitHubSyncService | 14 | Sync, Link, Unlink Repository |
| EmailService | 12 | Task, Invitation, Status Emails |
| AdvancedReportService | 18 | Burndown, EVM, Velocity, Financial |
| RemoteInvitationService | 12 | Remote API Integration |
| **TOPLAM** | **177** | **%100 Başarılı** |

### Kullanılan Test Teknolojileri
- xUnit 2.5.3 (Test Framework)
- Moq 4.20.70 (Mocking)
- FluentAssertions 6.12.0 (Assertion Library)
- Microsoft.NET.Test.Sdk 17.8.0

### Test Kategorileri
1. **Unit Tests** - Service katmanı testleri
2. **Mock Tests** - Repository ve dependency mocking
3. **Validation Tests** - Input validation testleri
4. **Authorization Tests** - Yetki kontrol testleri

---

## 📸 Mevcut Ekran Görüntüleri (24 adet)

| # | Dosya | Modül |
|---|-------|-------|
| 1 | `ProjectTracker.UI_Login.png` | Giriş |
| 2 | `ProjectTracker.UI_Register.png` | Kayıt |
| 3 | `ProjectTracker.UI_Dashboard.png` | Dashboard |
| 4 | `ProjectTracker.UI_ProjectsList.png` | Projeler |
| 5 | `ProjectTracker.UI_ProjectCreate.png` | Projeler |
| 6 | `ProjectTracker.UI_ProjectEdit.png` | Projeler |
| 7 | `ProjectTracker.UI_TasksList.png` | Görevler |
| 8 | `ProjectTracker.UI_TasksCanban.png` | Görevler |
| 9 | `ProjectTracker.UI_TaskEdit.png` | Görevler |
| 10 | `ProjectTracker.UI_Team.png` | Takımlar |
| 11 | `ProjectTracker.UI_TeamCreate.png` | Takımlar |
| 12 | `ProjectTracker.UI_TeamEdit.png` | Takımlar |
| 13 | `ProjectTracker.UI_TeamMember.png` | Takımlar |
| 14 | `ProjectTracker.UI_TeamInvitations.png` | Takımlar |
| 15 | `ProjectTracker.UI_MyInvitations.png` | Davetler |
| 16 | `ProjectTracker.UI_Reports1.png` | Raporlar |
| 17 | `ProjectTracker.UI_Reports2.png` | Raporlar |
| 18 | `ProjectTracker.UI_Reports3.png` | Raporlar |
| 19 | `ProjectTracker.UI_Settings.png` | Ayarlar |
| 20 | `ProjectTracker.UI_GithubAnalytics1.png` | GitHub |
| 21 | `ProjectTracker.UI_GithubAnalytics2.png` | GitHub |
| 22 | `ProjectTracker.UI_GithubAnalytics3.png` | GitHub |
| 23 | `ProjectTracker.UI_UserPending.png` | Kullanıcı |
| 24 | `ProjectTracker.UI_Error.png` | Hata |

---

## 📊 Değerlendirme Kriterleri Eşleştirmesi

| Kriter | Puan | Karşılayan Doküman |
|--------|------|-------------------|
| Proje Analizi (10p) | ✅ | `FINAL_RAPOR.md` Bölüm 1-2 |
| Dizayn/UML (10p) | ✅ | `docs/UML/` klasörü (6 diyagram) |
| Zamanında Teslim (10p) | ⏳ | - |
| Kullanıcı Arayüzü (10p) | ✅ | 24 Screenshot + Form açıklamaları |
| Kodlama ve Çıktı (30p) | ✅ | Kaynak kod + Demo |
| Test (10p) | ✅ | `tests/ProjectTracker.Tests/` (89 test) |
| Dokümantasyon (10p) | ✅ | Tüm `docs/` klasörü |
| Veritabanı Tasarımı (10p) | ✅ | `ER_Diagram.md` + Tablo açıklamaları |

---

## 🔢 Kod Standartları Kontrolü

Hocanın verdiği standartlara göre kontrol edilecek:

### Naming Convention
- [x] Form isimleri: `Frm` prefix (FrmLogin, FrmDashboard)
- [x] Service isimleri: `S` prefix veya `Service` suffix
- [x] Interface isimleri: `I` prefix (IProjectService)
- [x] DTO isimleri: `Dto` suffix (ProjectDto)
- [x] Repository isimleri: `Repository` suffix

### Namespace Yapısı
```
ProjectTracker.Core.Entities
ProjectTracker.Core.Enums
ProjectTracker.Core.Interfaces.Repositories
ProjectTracker.Data.Context
ProjectTracker.Data.Repositories
ProjectTracker.Business.Services
ProjectTracker.Business.DTOs
ProjectTracker.Business.Validators
ProjectTracker.UI.Forms.Login
ProjectTracker.UI.Forms.Dashboard
ProjectTracker.UI.Helpers
```

---

## 🚀 Uygulama Sırası

1. **AŞAMA 1:** UML Diyagramları (6 dosya)
2. **AŞAMA 2:** Maliyet Kestirim Dokümanı
3. **AŞAMA 3:** Final Rapor (Ana doküman)
4. **AŞAMA 4:** Kurulum Kılavuzu
5. **AŞAMA 5:** Test Dokümanı

---

## ✅ Tamamlanan İşler

- [x] Proje yapısı analizi
- [x] Ekran görüntüleri (24 adet)
- [x] Roadmap oluşturma
- [x] UML Diyagramları (5 adet)
  - [x] Use Case Diagram
  - [x] Class Diagram
  - [x] Activity Diagram (Dual-Database mimarisi dahil)
  - [x] Sequence Diagram
  - [x] ER Diagram
- [x] Maliyet Kestirim (İN: 639, ~18K satır)
- [x] Final Rapor (24 ekran görüntüsü ile)
- [x] Test Projesi (177 unit test, %100 başarılı)
- [ ] Kurulum Kılavuzu (Opsiyonel)

---

## 📊 DOKÜMANTASYON ÖZET TABLOSU

| Doküman | Dosya | Durum | Açıklama |
|---------|-------|-------|----------|
| Use Case Diagram | `docs/UML/UseCase_Diagram.md` | ✅ | 4 aktör, 6 modül |
| Class Diagram | `docs/UML/Class_Diagram.md` | ✅ | 18 entity, 7 enum |
| Activity Diagram | `docs/UML/Activity_Diagram.md` | ✅ | 10 iş akışı, dual-DB |
| Sequence Diagram | `docs/UML/Sequence_Diagram.md` | ✅ | 7 senaryo |
| ER Diagram | `docs/UML/ER_Diagram.md` | ✅ | 18 tablo + Plesk |
| Maliyet Kestirim | `docs/Reports/MALIYET_KESTIRIM.md` | ✅ | İN: 639 |
| Final Rapor | `docs/Reports/FINAL_RAPOR.md` | ✅ | Tam dokümantasyon |
| Screenshots | `docs/Screenshots/` | ✅ | 24 adet |
| Unit Tests | `tests/ProjectTracker.Tests/` | ✅ | 177 test, %100 başarılı |

---

**Son Güncelleme:** 6 Ocak 2026  
**Tamamlanma Oranı:** %100 (Temel Dokümanlar + Test Projesi)
