# TEKNOLOJİ KARARLARI VE PROJE AYRINTILARI

## ✅ Kesinleşmiş Kararlar

### Teknoloji Stack
- **Framework**: .NET 8.0
- **UI**: Windows Forms (WinForms)
- **Veritabanı**: SQL Server 2019+ (Microsoft SQL Server)
- **ORM**: Entity Framework Core 8.0 (SqlServer provider)
- **UI Kütüphanesi**: DevExpress (kurulu)

### Mimari Yaklaşım
- **Mimari Tipi**: Katmanlı Mimari (4 Katman)
- **Katmanlar**:
  1. **UI Layer** (Presentation) - Windows Forms
  2. **Business Layer** (İş Mantığı) - Services + Algoritmalar
  3. **Data Layer** (Veri Erişimi) - Repository Pattern + EF Core
  4. **Core Layer** (Domain) - Entity'ler + Interface'ler

### Akıllı Algoritmalar (Akademik Gereksinim)

#### 1. Ağırlıklı Risk Skoru Hesaplama
**Amaç**: Projelerin gecikme riskini hesaplamak

**Formül**:
```
RiskSkoru = (GörevSayısı × 0.3) + 
            ((100 - TamamlanmaOranı) × 0.4) + 
            ((1 / TakımBüyüklüğü) × 0.2) + 
            (BütçeKullanımOranı × 0.3)

Sonuç: 0-100 arası risk puanı
- 0-40: Düşük Risk (Yeşil)
- 41-70: Orta Risk (Sarı)
- 71-100: Yüksek Risk (Kırmızı)
```

**Örnekler**:
- Görev sayısı çok → Risk artar
- Tamamlanma oranı düşük → Risk artar
- Takım büyük → Risk azalır
- Bütçe aşımı var → Risk artar

#### 2. Kritik Yol Analizi (CPM - Critical Path Method)
**Amaç**: Hangi görevlerin projenin süresini doğrudan etkilediğini bulmak

**Algoritma Adımları**:
1. Forward Pass: Her görev için en erken başlangıç/bitiş zamanını hesapla
2. Backward Pass: Her görev için en geç başlangıç/bitiş zamanını hesapla
3. Slack Time (Gevşeklik): `Slack = En Geç Başlangıç - En Erken Başlangıç`
4. Kritik Görevler: Slack = 0 olan görevler
5. Kritik Yol: Kritik görevlerin zinciri

**Çıktılar**:
- Projenin minimum tamamlanma süresi
- Hangi görevlerin kesinlikle zamanında bitmesi gerektiği
- Gantt Chart'ta kritik görevleri kırmızı renkte gösterme

#### 3. Akıllı Öneri Sistemi
**Amaç**: Kullanıcıya proaktif öneriler sunmak

**Öneriler**:
- "Bu projedeki en riskli 3 görev: ..."
- "Ahmet'in iş yükü %150, görevleri yeniden dağıtın"
- "Proje %75 olasılıkla 15 gün gecikecek"
- "Kritik yolda 2 görev var, öncelik verin"

---

## 📁 Proje Yapısı

```
ProjectTracker/
│
├── src/
│   ├── ProjectTracker.Core/              [Domain Layer]
│   │   ├── Entities/                     [Entity sınıfları]
│   │   ├── Enums/                        [Enum tanımları]
│   │   └── Interfaces/                   [Repository & UoW arayüzleri]
│   │
│   ├── ProjectTracker.Data/              [Data Access Layer]
│   │   ├── Context/                      [DbContext]
│   │   ├── Repositories/                 [Repository implementasyonları]
│   │   └── Migrations/                   [EF Core Migrations]
│   │
│   ├── ProjectTracker.Business/          [Business Logic Layer]
│   │   ├── Services/                     [İş mantığı servisleri]
│   │   ├── DTOs/                         [Data Transfer Objects]
│   │   ├── Validators/                   [FluentValidation kuralları]
│   │   └── Mappings/                     [AutoMapper profilleri]
│   │
│   └── ProjectTracker.UI/                [Presentation Layer]
│       └── Forms/                        [Windows Forms]
│           ├── Login/                    [FrmLogin]
│           └── Dashboard/                [FrmDashboard + Content]
│
├── tests/
│   └── ProjectTracker.Tests/             [Unit Tests]
│
└── docs/
    ├── UML/                              [UML Diyagramları]
    ├── Screenshots/                      [Ekran Görüntüleri]
    └── Reports/                          [Ara ve Final Raporlar]
```

> **Not**: Veritabanı yönetimi için SQL Server ve EF Core Migrations kullanılmaktadır.

---

## 🎯 Proje Hedefleri

### Fonksiyonel Gereksinimler
1. ✅ Kullanıcı yönetimi (Rol tabanlı)
2. ✅ Proje CRUD işlemleri
3. ✅ Görev yönetimi (alt görev desteği)
4. ✅ Gantt Chart görselleştirme
5. ✅ Risk analizi (Akıllı algoritma)
6. ✅ Kritik yol analizi (Akıllı algoritma)
7. ✅ Dashboard (KPI'lar ve grafikler)
8. ✅ Bildirim sistemi
9. ✅ Raporlama (PDF çıktısı)

### Akademik Gereksinimler
1. ✅ OOP prensipleri (Encapsulation, Inheritance, Polymorphism)
2. ✅ Design Patterns (Repository, Unit of Work, Dependency Injection)
3. ✅ UML Diyagramları (Use Case, Class, Activity, Sequence, ER)
4. ✅ Yazılım mühendisliği yöntemleri
5. ✅ Akıllı algoritma (Risk analizi + CPM)
6. ✅ Test (Unit Tests)
7. ✅ Dokümantasyon (XML comments, raporlar)

---

## 👥 Kullanıcı Rolleri

| Rol | Yetkiler |
|-----|----------|
| **Admin** | Tüm yetkiler, kullanıcı yönetimi, sistem ayarları |
| **Proje Yöneticisi** | Proje CRUD, görev atama, takım yönetimi, raporlar |
| **Takım Lideri** | Görev yönetimi, kendi takımının raporları |
| **Geliştirici** | Atanan görevleri güncelleme, yorum yazma |
| **İzleyici** | Sadece görüntüleme |

---

## 📊 Veritabanı Tabloları (İngilizce İsimlendirme)

1. **roles** - User roles
2. **users** - System users
3. **projects** - Project information
4. **tasks** - Task information (with subtask and dependency support)
5. **task_comments** - Comments on tasks
6. **notifications** - System notifications
7. **project_team_members** - Project-User relationships
8. **project_risks** - Risk records (AI algorithm outputs)
9. **audit_logs** - System activity logs

---

## 🔐 Güvenlik

- SHA256 ile şifre hashleme
- Session yönetimi
- Rol tabanlı yetkilendirme
- SQL Injection koruması (EF Core Parametreli sorgular)
- Audit logging (kim ne yaptı)

---

## 📅 Geliştirme Takvimi

### Hafta 1: Temel Altyapı
- Gün 1-2: Proje kurulumu, veritabanı
- Gün 3-4: Entity'ler, Repository Pattern
- Gün 5: Service Layer
- Gün 6-7: Temel UI formları

### Hafta 2: Özellikler ve Tamamlama
- Gün 8-9: Görev yönetimi, Gantt Chart
- Gün 10: Kullanıcı/Rol yönetimi
- Gün 11: Dashboard, Akıllı algoritmalar
- Gün 12: Raporlar, Bildirimler
- Gün 13-14: Test, dokümantasyon, son rötuşlar

---

## 📦 NuGet Paketleri

### Core Projesi
- (Paket gerekmez - sadece POCO sınıflar)

### Data Projesi
- Microsoft.EntityFrameworkCore.SqlServer 8.0.0
- Microsoft.EntityFrameworkCore.Tools 8.0.0
- Microsoft.EntityFrameworkCore.Design 8.0.0

### Business Projesi
- AutoMapper 12.0.1
- FluentValidation 12.1.1

### UI Projesi
- Microsoft.Extensions.DependencyInjection 8.0.0
- Microsoft.Extensions.Configuration 8.0.0
- Microsoft.Extensions.Configuration.Json 8.0.0
- DevExpress 25.1.7 (lisanslı):
  - DevExpress.Data (25.1.7)
  - DevExpress.Utils (25.1.7)
  - DevExpress.XtraEditors (25.1.7)
  - DevExpress.XtraGrid (25.1.7)
  - DevExpress.XtraCharts (25.1.7)

### Test Projesi
- xUnit
- Moq (mocking için)
- FluentAssertions (assertion için)

---

## 🎨 UI Standartları (DevExpress)

### Form Naming Convention
- **FrmLogin** - Login ekranı
- **FrmDashboard** - Ana dashboard (FrmAnaEkran yerine)
- **FrmProjeListe** - Proje listesi
- **FrmProjeDetay** - Proje detay/düzenleme
- **FrmGorevListe** - Görev listesi
- vb...

### UserControl Naming Convention
> **Not:** Proje içinde ana içerik alanları için UserControl kullanılmaktadır.

- **DashboardContent** - Dashboard ana içerik kontrolü
- **ProjectsContent** - Projeler listesi ve yönetim kontrolü
- **TasksContent** - Görevler listesi ve Kanban board kontrolü
- **ProjectDetailControl** - Proje detay/düzenleme formu kontrolü
- **TaskDetailControl** - Görev detay/düzenleme formu kontrolü

### Kontrol Naming Convention
- Button: **btnKaydet**, **btnSil**, **btnKapat**
- TextEdit: **txtProjeAdi**, **txtAciklama**
- GridControl: **grdProje**, **grdGorev**
- GridView: **grdwProje**, **grdwGorev**
- DateEdit: **dateBaslangic**, **dateBitis**
- ComboBox: **cmbDurum**, **cmbOncelik**
- Label: **lblBaslik**, **lblAciklama**

---

## 🧪 Test Stratejisi

### Unit Tests
- Service katmanı metodları
- Algoritma metodları (Risk hesaplama, CPM)
- Repository metodları
- Validation kuralları

### Test Senaryoları
1. Proje oluşturma (başarılı/başarısız)
2. Görev atama (geçerli/geçersiz)
3. Risk skoru hesaplama (farklı senaryolar)
4. Kritik yol analizi (basit/karmaşık proje)
5. Kullanıcı girişi (doğru/yanlış şifre)

---

## 📚 Dokümantasyon Gereksinimleri

### Ara Rapor (Hafta 1 Sonu)
1. Proje tanıtımı ve amaç
2. Use Case Diagram
3. Class Diagram (temel)
4. ER Diagram
5. İlk ekran görüntüleri
6. Geliştirme süreci

### Final Rapor (Hafta 2 Sonu)
1. Tüm UML diyagramları (Use Case, Class, Activity, Sequence)
2. Modül açıklamaları
3. Tüm form ekran görüntüleri
4. Algoritma açıklamaları (Risk + CPM)
5. Test sonuçları
6. Kurulum kılavuzu
7. Kullanım kılavuzu
8. Kaynak kodlar (GitHub linki veya ZIP)

---

## 🚀 Kurulum Gereksinimleri

### Geliştirme Ortamı
- Windows 10/11
- Visual Studio 2022 (17.8+)
- .NET 8 SDK
- SQL Server 2019+ (or SQL Server Express)
- SQL Server Management Studio (SSMS 20)
- DevExpress 25.1.7 lisansı

### Üretim Ortamı
- Windows Server veya Windows 10/11
- .NET 8 Runtime
- SQL Server 2019+
- Minimum 4GB RAM

---

Son Güncelleme: 29 Aralık 2024
Proje: YMH 219 Nesne Tabanlı Programlama

