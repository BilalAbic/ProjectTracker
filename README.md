# 📊 PROJECT TRACKER

### Enterprise Project Management System
*C# Windows Forms + DevExpress + Entity Framework Core 8.0 + ASP.NET Core Web API*

---

## 🎯 Proje Özeti

**Project Tracker**, projelerin planlama, yürütme ve izleme süreçlerini tek bir merkezi yapı altında toplayan, akademik gereksinimleri karşılayan bütünleşik bir yazılım çözümüdür. Modern dark theme UI, DevExpress kontrolleri ve akıllı analiz algoritmaları ile profesyonel proje yönetimi deneyimi sunar.

### 🌐 Canlı Demo & Linkler

| Platform | URL | Açıklama |
|----------|-----|----------|
| 🌍 **Web Sitesi** | [pt.bilalabic.com](https://pt.bilalabic.com) | Custom domain ile barındırılan tanıtım sitesi |
| 🔌 **API** | [bilalabic.com/api](https://bilalabic.com/api) | Plesk'te barındırılan ASP.NET Core Web API |
| 📦 **İndirme** | [GitHub Releases](https://github.com/BilalAbic/ProjectTracker/releases/latest) | Windows masaüstü uygulaması |
| 📂 **Kaynak Kod** | [github.com/BilalAbic/ProjectTracker](https://github.com/BilalAbic/ProjectTracker) | Ana repository |
| 🌐 **Web Branch** | [web-github-pages](https://github.com/BilalAbic/ProjectTracker/tree/web-github-pages) | Web sitesi kaynak kodları |

### ✨ Temel Özellikler

| Özellik | Açıklama | Durum |
|---------|----------|-------|
| 📁 **Proje Yönetimi** | Proje oluşturma, düzenleme, durum takibi, takım ataması | ✅ |
| ✅ **Görev Yönetimi** | Alt görevler, atamalar, Kanban board, ilerleme izleme | ✅ |
| 👥 **Takım Yönetimi** | Takım oluşturma, üye yönetimi, davet sistemi, rol atama | ✅ |
| 🔐 **Rol Tabanlı Yetkilendirme** | Admin, ProjectManager, Developer, Pending rolleri | ✅ |
| 📊 **Raporlama & Analytics** | Performans grafikleri, durum raporları, PDF/Excel export | ✅ |
| 📝 **Audit Log Sistemi** | Aktivite takibi, değişiklik geçmişi | ✅ |
| 🎨 **Modern Dashboard** | Anlık KPI'lar, interaktif grafikler, dark theme UI | ✅ |
| 💬 **Özel Mesaj Kutusu** | Dark-themed, hata kodlu mesaj sistemi | ✅ |
| 🐙 **GitHub Entegrasyonu** | Repository bağlama, commit analizi, task-commit eşleştirme | ✅ |
| 📧 **E-posta Davet Sistemi** | Gmail SMTP ile takım daveti, web üzerinden kabul | ✅ |
| 🌐 **Web API** | ASP.NET Core 8.0 Minimal API, davet yönetimi | ✅ |
| 📈 **Gantt Chart** | Görsel zaman çizelgesi, kritik yol analizi (CPM) | 🔄 |

---

## 🏗️ Sistem Mimarisi

### Genel Bakış

```
┌─────────────────────────────────────────────────────────────────────────┐
│                         KULLANICI ARAYÜZÜ                               │
├─────────────────────────────────────────────────────────────────────────┤
│  Windows Forms (WinForms)          │  Web Sitesi (GitHub Pages)         │
│  • DevExpress UI Controls          │  • HTML/CSS/JavaScript             │
│  • Masaüstü Uygulaması            │  • Davet Kabul Sayfası             │
│  • Yerel Veritabanı Bağlantısı    │  • Statik Hosting                  │
└─────────────────────────────────────────────────────────────────────────┘
                    │                              │
                    ▼                              ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                         BACKEND SERVİSLERİ                              │
├─────────────────────────────────────────────────────────────────────────┤
│  Business Layer (Services)         │  Web API (ASP.NET Core 8.0)       │
│  • ProjectService                  │  • InvitationsController          │
│  • TaskService                     │  • /api/invitations/validate      │
│  • TeamService                     │  • /api/invitations/accept        │
│  • InvitationService               │  • /api/invitations/decline       │
│  • EmailService (Gmail SMTP)       │  • /api/invitations/create        │
│  • RemoteInvitationService         │  • /api/invitations/health        │
└─────────────────────────────────────────────────────────────────────────┘
                    │                              │
                    ▼                              ▼
┌─────────────────────────────────────────────────────────────────────────┐
│                         VERİTABANI KATMANI                              │
├─────────────────────────────────────────────────────────────────────────┤
│  Yerel SQL Server                  │  Uzak SQL Server (Plesk)          │
│  • Tüm uygulama verileri          │  • Sadece Invitations tablosu     │
│  • 18 tablo                        │  • EnsureCreated() ile oluşturma  │
│  • Entity Framework Core 8.0       │  • Entity Framework Core 8.0      │
└─────────────────────────────────────────────────────────────────────────┘
```

### Davet Sistemi Akışı

```
┌──────────────┐     ┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│   WinForms   │────▶│  EmailService │────▶│  Gmail SMTP  │────▶│  Kullanıcı   │
│  Davet Oluştur│     │  (E-posta)   │     │              │     │  E-postası   │
└──────────────┘     └──────────────┘     └──────────────┘     └──────────────┘
       │                                                              │
       ▼                                                              ▼
┌──────────────┐                                              ┌──────────────┐
│ RemoteApi    │                                              │ GitHub Pages │
│ Service      │                                              │ Web Sitesi   │
└──────────────┘                                              └──────────────┘
       │                                                              │
       ▼                                                              ▼
┌──────────────┐     ┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│  Plesk API   │◀────│  Invitations │◀────│  JavaScript  │◀────│ accept-invite│
│  (bilalabic  │     │  Controller  │     │  fetch()     │     │    .html     │
│   .com/api)  │     │              │     │              │     │              │
└──────────────┘     └──────────────┘     └──────────────┘     └──────────────┘
```

---

## 💻 Teknoloji Stack

### Framework & Runtime

| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| .NET | 8.0 LTS | Son versiyon framework |
| ASP.NET Core | 8.0 | Web API framework |
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
| SQL Server | 2019+ | RDBMS (Yerel + Plesk) |
| Entity Framework Core | 8.0 | ORM (Code-First) |

### Web & API

| Teknoloji | Versiyon | Açıklama |
|-----------|----------|----------|
| ASP.NET Core Minimal API | 8.0 | Lightweight Web API |
| GitHub Pages | - | Statik web hosting |
| HTML/CSS/JavaScript | ES6+ | Frontend |

### Libraries

| Kütüphane | Versiyon | Kullanım |
|-----------|----------|----------|
| AutoMapper | 12.0.1 | DTO mapping |
| FluentValidation | 12.1.1 | Validation rules |
| Microsoft.Extensions.DependencyInjection | 8.0 | IoC Container |
| iTextSharp | 5.5.13.3 | PDF export |
| BouncyCastle | 1.8.9 | PDF şifreleme |
| Octokit | 13.0.1 | GitHub API client |
| System.Net.Mail | - | E-posta gönderimi |

---

## 🌐 Web API (ProjectTracker.API)

### Genel Bilgiler

| Özellik | Değer |
|---------|-------|
| **Framework** | ASP.NET Core 8.0 Minimal API |
| **Hosting** | Plesk (Windows Server + IIS) |
| **URL** | https://bilalabic.com/api |
| **Veritabanı** | SQL Server (Plesk) |
| **Tablo** | Invitations (tek tablo) |

### API Endpoints

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/invitations/validate?token=xxx` | Davet token'ını doğrula |
| POST | `/api/invitations/create` | Yeni davet oluştur (WinForms'tan) |
| POST | `/api/invitations/accept` | Daveti kabul et (Web'den) |
| POST | `/api/invitations/decline` | Daveti reddet (Web'den) |
| GET | `/api/invitations/health` | API sağlık kontrolü |
| GET | `/` | API bilgi endpoint'i |
| GET | `/ping` | Basit ping (DB gerektirmez) |

### API Response Örnekleri

```json
// GET /api/invitations/validate?token=abc123
{
  "isValid": true,
  "teamName": "Development Team",
  "invitedBy": "Bilal Abiç",
  "proposedRole": "Developer",
  "expiresAt": "2026-01-12T00:00:00",
  "email": "user@example.com"
}

// POST /api/invitations/accept
{
  "success": true,
  "message": "Davet kabul edildi!",
  "email": "user@example.com"
}

// GET /api/invitations/health
{
  "status": "OK",
  "timestamp": "2026-01-05T22:39:52.540Z"
}
```

---

## 🌍 Web Sitesi (GitHub Pages)

### Hosting Bilgileri

| Özellik | Değer |
|---------|-------|
| **Platform** | GitHub Pages |
| **Custom Domain** | https://pt.bilalabic.com |
| **Alternatif URL** | https://bilalabic.github.io/ProjectTracker |
| **Branch** | `web-github-pages` |
| **Kaynak** | `/docs` klasörü |
| **Teknoloji** | HTML, CSS, JavaScript (Vanilla) |

### Sayfa Yapısı

```
docs/
├── index.html          # Ana sayfa (tanıtım, özellikler, indirme)
├── accept-invite.html  # Davet kabul sayfası
├── CNAME               # Custom domain yapılandırması (pt.bilalabic.com)
├── css/
│   ├── style.css       # Ana stil dosyası
│   └── invite.css      # Davet sayfası stilleri
└── js/
    ├── config.js       # API URL yapılandırması
    ├── invite.js       # Davet işlemleri
    └── main.js         # Ana sayfa scriptleri
```

### JavaScript Yapılandırması

```javascript
// config.js
const CONFIG = {
    API_BASE_URL: 'https://bilalabic.com',  // Plesk API
    DOWNLOAD_URL: 'https://github.com/BilalAbic/ProjectTracker/releases/latest',
    DEMO_MODE: false  // true yapılırsa API çağrısı yapmaz
};
```

---

## 📁 Klasör Yapısı

```
ProjectTracker/
│
├── src/
│   ├── ProjectTracker.Core/              [Domain Layer]
│   │   ├── Entities/                     [18 Entity sınıfı]
│   │   ├── Enums/                        [7 Enum tanımı]
│   │   └── Interfaces/                   [Repository & UoW]
│   │
│   ├── ProjectTracker.Data/              [Data Access Layer]
│   │   ├── Context/AppDbContext.cs
│   │   ├── Repositories/
│   │   ├── UnitOfWork.cs
│   │   └── Migrations/
│   │
│   ├── ProjectTracker.Business/          [Business Logic Layer]
│   │   ├── Services/
│   │   │   ├── ProjectService.cs
│   │   │   ├── TaskService.cs
│   │   │   ├── TeamService.cs
│   │   │   ├── InvitationService.cs
│   │   │   ├── EmailService.cs           [Gmail SMTP]
│   │   │   ├── RemoteInvitationService.cs [API çağrısı]
│   │   │   ├── GitHubSyncService.cs
│   │   │   └── ...
│   │   ├── DTOs/
│   │   ├── Interfaces/
│   │   └── Mappings/
│   │
│   ├── ProjectTracker.UI/                [Presentation Layer - WinForms]
│   │   ├── Forms/
│   │   │   ├── Login/
│   │   │   └── Dashboard/
│   │   ├── Helpers/
│   │   ├── appsettings.json
│   │   └── Program.cs
│   │
│   └── ProjectTracker.API/               [Web API Layer]
│       ├── Controllers/
│       │   └── InvitationsController.cs
│       ├── Data/
│       │   └── InvitationDbContext.cs
│       ├── Models/
│       │   └── InvitationModel.cs
│       ├── appsettings.json
│       ├── appsettings.Production.json
│       ├── Program.cs
│       └── web.config
│
├── web/                                  [Web Sitesi - Geliştirme]
│   ├── index.html
│   ├── accept-invite.html
│   ├── css/
│   └── js/
│
├── docs/                                 [Web Sitesi - GitHub Pages + Dokümantasyon]
│   ├── index.html                        (GitHub Pages bu klasörden serve eder)
│   ├── accept-invite.html
│   ├── CNAME                             (pt.bilalabic.com)
│   ├── css/
│   ├── js/
│   ├── UML/
│   ├── Screenshots/
│   └── Reports/
│
├── publish/
│   └── api/                              [API publish çıktısı]
│
└── bank/                                 [Geliştirme notları]
```

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
   ```sql
   CREATE DATABASE DboProjectTracker;
   ```

4. **appsettings.json yapılandır:**
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
       "Password": "your-app-password"
     },
     "RemoteApi": {
       "Enabled": true,
       "BaseUrl": "https://bilalabic.com/api"
     }
   }
   ```

5. **Migration'ları uygula:**
   ```bash
   dotnet ef database update --project src/ProjectTracker.Data --startup-project src/ProjectTracker.UI
   ```

6. **Projeyi çalıştır:**
   ```bash
   dotnet run --project src/ProjectTracker.UI
   ```

### API Deployment (Plesk)

1. **API'yi publish et:**
   ```bash
   dotnet publish src/ProjectTracker.API -c Release -o publish/api
   ```

2. **Plesk'e yükle:**
   - `publish/api/` içeriğini `httpdocs/` klasörüne yükle
   - .NET Core ayarlarını yapılandır
   - `appsettings.Production.json` dosyasını düzenle

3. **Test et:**
   ```
   https://bilalabic.com/api/invitations/health
   ```

---

## 👥 Kullanıcı Rolleri

| Rol | Yetkiler |
|-----|----------|
| **Admin** | Tüm yetkiler, kullanıcı yönetimi, sistem ayarları |
| **ProjectManager** | Proje CRUD, görev atama, takım yönetimi, raporlar |
| **Developer** | Atanan görevleri güncelleme, yorum yazma |
| **Pending** | Onay bekliyor, sisteme erişim yok |

---

## 🚀 Sürüm Notları

### v1.1.0 (5 Ocak 2026) - Web API & Davet Sistemi

#### Yeni Özellikler
- ✅ **ASP.NET Core 8.0 Web API** - Davet yönetimi için RESTful API
- ✅ **GitHub Pages Web Sitesi** - Tanıtım ve davet kabul sayfası
- ✅ **Gmail SMTP Entegrasyonu** - E-posta ile davet gönderimi
- ✅ **Çift Veritabanı Mimarisi** - Yerel + Uzak (Plesk) DB desteği
- ✅ **RemoteInvitationService** - WinForms'tan API'ye davet gönderimi

#### Teknik Detaylar
- Minimal API pattern kullanımı
- CORS desteği (AllowAll policy)
- EnsureCreated() ile otomatik tablo oluşturma
- Fire-and-forget async pattern

### v1.0.0 (3 Ocak 2026) - İlk Sürüm

- Proje, görev, takım yönetimi
- GitHub entegrasyonu
- Rol tabanlı yetkilendirme
- Audit log sistemi
- DevExpress UI

---

## 📚 Dokümantasyon

Detaylı teknik dokümanlar `bank/` klasöründe bulunmaktadır:

| Dosya | Açıklama |
|-------|----------|
| [GITHUB_INTEGRATION_README.md](bank/GITHUB_INTEGRATION_README.md) | GitHub entegrasyonu teknik tasarım |
| [GITHUB_INTEGRATION_ROADMAP.md](bank/GITHUB_INTEGRATION_ROADMAP.md) | GitHub entegrasyonu yol haritası |
| [UI_DASHBOARD_PHASE6_README.md](bank/UI_DASHBOARD_PHASE6_README.md) | Dashboard Phase 6 özellikleri |
| [ROLE_SYSTEM_ROADMAP.md](bank/ROLE_SYSTEM_ROADMAP.md) | Rol sistemi yol haritası |

---

## 👨‍💻 Geliştirici

**Proje:** YMH 219 Nesne Tabanlı Programlama  
**Dönem:** 2024-2025  
**Geliştirici:** Bilal Abiç  
**GitHub:** [@BilalAbic](https://github.com/BilalAbic)

---

**📌 Güncel Durum:** Phase 8 (Web API & Davet Sistemi) tamamlandı  
**📈 İlerleme:** ~85%  
**📅 Son Güncelleme:** 6 Ocak 2026

🚀 **Happy Coding!**
