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
│   ├── FINAL_RAPOR.md                  # Ana dokümantasyon (Hocanın şablonuna göre)
│   ├── MALIYET_KESTIRIM.md             # İşlev nokta analizi
│   ├── KURULUM_KILAVUZU.md             # Setup ve kurulum adımları
│   └── TEST_DOKUMANI.md                # Test senaryoları ve sonuçları
│
├── Screenshots/                         # ✅ Mevcut (24 ekran görüntüsü)
│
└── UML/
    ├── UseCase_Diagram.md              # Kullanım senaryoları
    ├── Class_Diagram.md                # Sınıf diyagramı (Entity'ler)
    ├── Activity_Diagram.md             # İş akışları
    ├── Sequence_Diagram.md             # Sıralı etkileşimler
    ├── Interaction_Diagram.md          # Bileşen etkileşimleri
    └── ER_Diagram.md                   # Veritabanı şeması
```

---

## 🗓️ AŞAMA 1: UML Diyagramları
**Öncelik:** Kritik | **Tahmini Süre:** 2-3 saat

### 1.1 Use Case Diyagramı
**Dosya:** `docs/UML/UseCase_Diagram.md`

İçerik:
- 5 Aktör: Admin, Proje Yöneticisi, Takım Lideri, Geliştirici, İzleyici
- Kullanıcı Yönetimi Use Case'leri
- Proje Yönetimi Use Case'leri
- Görev Yönetimi Use Case'leri
- Takım Yönetimi Use Case'leri
- Raporlama Use Case'leri
- GitHub Entegrasyonu Use Case'leri

### 1.2 Class Diyagramı
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

### 1.3 Activity Diyagramı
**Dosya:** `docs/UML/Activity_Diagram.md`

İş Akışları:
- Kullanıcı Giriş Akışı
- Proje Oluşturma Akışı
- Görev Atama Akışı
- Takım Davet Akışı
- Risk Hesaplama Akışı

### 1.4 Sequence Diyagramı
**Dosya:** `docs/UML/Sequence_Diagram.md`

Senaryolar:
- Login İşlemi
- Proje CRUD İşlemleri
- Görev Durum Değişikliği
- Takım Davet Kabul/Red

### 1.5 Interaction Diyagramı
**Dosya:** `docs/UML/Interaction_Diagram.md`

Katman Etkileşimleri:
- UI → Business → Data → Database
- Service'ler arası iletişim

### 1.6 ER Diyagramı
**Dosya:** `docs/UML/ER_Diagram.md`

Tablolar ve İlişkiler:
- 18+ tablo
- Foreign Key ilişkileri
- Index tanımları

---

## 🗓️ AŞAMA 2: Maliyet Kestirim Dokümanı
**Öncelik:** Yüksek | **Tahmini Süre:** 30 dakika

**Dosya:** `docs/Reports/MALIYET_KESTIRIM.md`

### İşlev Nokta Analizi Parametreleri

| Parametre | Sayı | Ağırlık | Toplam |
|-----------|------|---------|--------|
| Kullanıcı Girdi Sayısı | ? | 3 | ? |
| Kullanıcı Çıktı Sayısı | ? | 4 | ? |
| Kullanıcı Sorgu Sayısı | ? | 3 | ? |
| Veritabanı Tablo Sayısı | 18 | 7 | 126 |
| Arayüz Sayısı | 17 | 5 | 85 |

### Teknik Karmaşıklık Soruları (14 soru)
- Her soru 0-5 arası puanlanacak
- TKF (Teknik Karmaşıklık Faktörü) hesaplanacak

### Formül
```
İN = AİN × (0.65 + 0.01 × TKF)
Satır Sayısı = İN × 30
```

---

## 🗓️ AŞAMA 3: Final Rapor
**Öncelik:** Kritik | **Tahmini Süre:** 4-5 saat

**Dosya:** `docs/Reports/FINAL_RAPOR.md`

### Bölüm 1: GİRİŞ
- 1.1 Projenin Tanıtılması
- 1.2 Projenin Amacı
- 1.3 Projenin Kapsamı
- 1.4 Kullanılacak Teknolojiler

### Bölüm 2: PROJE PLANI
- 2.1 Sistemin Kullanıcıları (5 rol)
- 2.2 GANTT İş Akış Diyagramı
- 2.3 İşlevsel İhtiyaçlar
- 2.4 İşlevsel Olmayan İhtiyaçlar
- 2.5 UML Diyagramları (referans)

### Bölüm 3: PROJE GERÇEKLEŞTİRİLMESİ

#### 3.1 Modüllerin ve Formların Tasarımı

**Login Modülü:**
| Ekran | Screenshot | Açıklama |
|-------|------------|----------|
| Giriş | `ProjectTracker.UI_Login.png` | Kullanıcı giriş formu |
| Kayıt | `ProjectTracker.UI_Register.png` | Yeni kullanıcı kaydı |
| Bekleyen | `ProjectTracker.UI_UserPending.png` | Onay bekleyen kullanıcı |

**Dashboard Modülü:**
| Ekran | Screenshot | Açıklama |
|-------|------------|----------|
| Ana Panel | `ProjectTracker.UI_Dashboard.png` | KPI'lar ve özet |

**Proje Modülü:**
| Ekran | Screenshot | Açıklama |
|-------|------------|----------|
| Liste | `ProjectTracker.UI_ProjectsList.png` | Proje listesi |
| Oluştur | `ProjectTracker.UI_ProjectCreate.png` | Yeni proje |
| Düzenle | `ProjectTracker.UI_ProjectEdit.png` | Proje düzenleme |

**Görev Modülü:**
| Ekran | Screenshot | Açıklama |
|-------|------------|----------|
| Liste | `ProjectTracker.UI_TasksList.png` | Grid görünümü |
| Kanban | `ProjectTracker.UI_TasksCanban.png` | Kanban board |
| Düzenle | `ProjectTracker.UI_TaskEdit.png` | Görev düzenleme |

**Takım Modülü:**
| Ekran | Screenshot | Açıklama |
|-------|------------|----------|
| Liste | `ProjectTracker.UI_Team.png` | Takım listesi |
| Oluştur | `ProjectTracker.UI_TeamCreate.png` | Yeni takım |
| Düzenle | `ProjectTracker.UI_TeamEdit.png` | Takım düzenleme |
| Üyeler | `ProjectTracker.UI_TeamMember.png` | Takım üyeleri |
| Davetler | `ProjectTracker.UI_TeamInvitations.png` | Takım davetleri |
| Davetlerim | `ProjectTracker.UI_MyInvitations.png` | Kullanıcı davetleri |

**Rapor Modülü:**
| Ekran | Screenshot | Açıklama |
|-------|------------|----------|
| Rapor 1 | `ProjectTracker.UI_Reports1.png` | Genel raporlar |
| Rapor 2 | `ProjectTracker.UI_Reports2.png` | Detay raporlar |
| Rapor 3 | `ProjectTracker.UI_Reports3.png` | Grafikler |

**GitHub Modülü:**
| Ekran | Screenshot | Açıklama |
|-------|------------|----------|
| Analitik 1 | `ProjectTracker.UI_GithubAnalytics1.png` | GitHub istatistikleri |
| Analitik 2 | `ProjectTracker.UI_GithubAnalytics2.png` | Commit analizi |
| Analitik 3 | `ProjectTracker.UI_GithubAnalytics3.png` | Repo detayları |

**Ayarlar Modülü:**
| Ekran | Screenshot | Açıklama |
|-------|------------|----------|
| Ayarlar | `ProjectTracker.UI_Settings.png` | Kullanıcı ayarları |

**Hata Yönetimi:**
| Ekran | Screenshot | Açıklama |
|-------|------------|----------|
| Hata | `ProjectTracker.UI_Error.png` | Hata mesajı |

#### 3.2 Veritabanı Tasarımı (ER Diyagramı)
- 18+ tablo şeması
- İlişki diyagramı
- Veri tipleri

#### 3.3 Çıktılar & Raporlar
- PDF export özelliği
- Excel export özelliği
- Dashboard grafikleri

### Bölüm 4: ÖNGÖRÜLEN EKSİKLİKLER
- 4.1 Eksik Kalan Modüller
  - Gantt Chart (Planlandı)
  - E-posta Bildirimleri (Planlandı)
  - Çoklu Dil Desteği (Planlandı)
- 4.2 Eklenebilecek Modüller
  - Mobil uygulama
  - Real-time bildirimler
  - AI destekli tahminler

### Bölüm 5: PROJE TESLİM
- Kurulum adımları (resimli)
- Sistem gereksinimleri
- Veritabanı kurulumu

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

## 🗓️ AŞAMA 5: Test Dokümanı
**Öncelik:** Orta | **Tahmini Süre:** 1 saat

**Dosya:** `docs/Reports/TEST_DOKUMANI.md`

İçerik:
- Test Stratejisi
- Unit Test Senaryoları
- Entegrasyon Testleri
- Kullanıcı Kabul Testleri
- Test Sonuçları

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
| Test (10p) | ✅ | `TEST_DOKUMANI.md` |
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
- [ ] UML Diyagramları
- [ ] Maliyet Kestirim
- [ ] Final Rapor
- [ ] Kurulum Kılavuzu
- [ ] Test Dokümanı

---

**Son Güncelleme:** 6 Ocak 2026
