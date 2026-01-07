# Activity Diyagramı (Aktivite Diyagramı)

## Project Tracker - İş Akışları

---

## 1. Genel Bakış

Bu dokümanda sistemdeki temel iş akışları Activity Diyagramları ile gösterilmektedir.

| # | İş Akışı | Açıklama |
|---|----------|----------|
| 1 | Kullanıcı Kayıt | Direkt kayıt ve davetli kayıt |
| 2 | Kullanıcı Giriş | Login ve rol bazlı yönlendirme |
| 3 | Proje Oluşturma | Yeni proje ekleme |
| 4 | Görev Atama | Görev oluşturma ve e-posta bildirimi |
| 5 | Görev Durumu Değiştirme | Kanban/Grid üzerinden durum güncelleme |
| 6 | Takım Daveti Gönderme | E-posta ile davet |
| 7 | Davet Kabul/Red | Davet yanıtlama akışı |
| 8 | GitHub Repo Bağlama | Proje-GitHub entegrasyonu |

---

## 2. Kullanıcı Kayıt Akışı

### 2.1 Direkt Kayıt (Pending Rol)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                        KULLANICI KAYIT AKIŞI (DİREKT)                       │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │  Kayıt Formunu  │
                    │     Aç          │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Bilgileri Gir:  │
                    │ - Username      │
                    │ - Full Name     │
                    │ - Email         │
                    │ - Password      │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │   Kaydet'e      │
                    │     Tıkla       │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   FluentValidation      ╲
               ╱      Doğrulama            ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
              [Geçersiz]          [Geçerli]
                   │                   │
                   ▼                   ▼
          ┌──────────────┐   ┌─────────────────┐
          │ Hata Mesajı  │   │ Username/Email  │
          │   Göster     │   │ Kontrolü        │
          └──────┬───────┘   └────────┬────────┘
                 │                    │
                 │                    ▼
                 │          ◇─────────────────◇
                 │         ╱                   ╲
                 │        ╱   Mevcut mu?        ╲
                 │        ╲                     ╱
                 │         ╲                   ╱
                 │          ◇─────────────────◇
                 │           │               │
                 │      [Evet]           [Hayır]
                 │           │               │
                 │           ▼               ▼
                 │   ┌──────────────┐ ┌─────────────────┐
                 │   │ "Username/   │ │ BCrypt ile      │
                 │   │ Email exists"│ │ Şifre Hashle    │
                 │   └──────┬───────┘ └────────┬────────┘
                 │          │                  │
                 │          │                  ▼
                 │          │         ┌─────────────────┐
                 │          │         │ User Entity     │
                 │          │         │ Oluştur         │
                 │          │         │ RoleId = 4      │
                 │          │         │ (Pending)       │
                 │          │         └────────┬────────┘
                 │          │                  │
                 │          │                  ▼
                 │          │         ┌─────────────────┐
                 │          │         │ Veritabanına    │
                 │          │         │ Kaydet          │
                 │          │         └────────┬────────┘
                 │          │                  │
                 │          │                  ▼
                 │          │         ┌─────────────────┐
                 │          │         │ "Kayıt Başarılı"│
                 │          │         │ Mesajı Göster   │
                 │          │         └────────┬────────┘
                 │          │                  │
                 │          │                  ▼
                 │          │         ┌─────────────────┐
                 │          │         │ Login Formuna   │
                 │          │         │ Yönlendir       │
                 │          │         └────────┬────────┘
                 │          │                  │
                 └──────────┴──────────────────┘
                              │
                              ▼
                              ◉
```

### 2.2 Davetli Kayıt (Takım Daveti ile)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                      KULLANICI KAYIT AKIŞI (DAVETLİ)                        │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │ E-posta'daki    │
                    │ Davet Linkine   │
                    │ Tıkla           │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Web Sayfası     │
                    │ Token'ı Doğrula │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   Token Geçerli mi?     ╲
               ╱    (Süresi dolmamış)      ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
              [Geçersiz]          [Geçerli]
                   │                   │
                   ▼                   ▼
          ┌──────────────┐   ┌─────────────────┐
          │ "Davet süresi│   │ Kayıt Formunu   │
          │ dolmuş" Hata │   │ Göster          │
          └──────────────┘   │ (Token ile)     │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Bilgileri Gir   │
                             │ + InvitationToken│
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ RegisterAsync() │
                             │ Çağrılır        │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Token ile       │
                             │ TeamInvitation  │
                             │ Bul             │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ ProposedRole'e  │
                             │ Göre RoleId     │
                             │ Belirle:        │
                             │ Owner/Admin/PM  │
                             │   → RoleId=2    │
                             │ Developer/Obs   │
                             │   → RoleId=3    │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ User Oluştur    │
                             │ (Belirlenen Rol)│
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ TeamMember      │
                             │ Kaydı Oluştur   │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Invitation      │
                             │ Status=Accepted │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Login Formuna   │
                             │ Yönlendir       │
                             └────────┬────────┘
                                      │
                                      ▼
                                      ◉
```

---

## 3. Kullanıcı Giriş Akışı

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                          KULLANICI GİRİŞ AKIŞI                              │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │  FrmLogin       │
                    │  Formu Açılır   │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Username ve     │
                    │ Password Gir    │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ "Giriş" Butonuna│
                    │ Tıkla           │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ LoginAsync()    │
                    │ Çağrılır        │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   Username Mevcut mu?   ╲
               ╱                           ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
               [Hayır]             [Evet]
                   │                   │
                   ▼                   ▼
          ┌──────────────┐   ┌─────────────────┐
          │ return null  │   │ BCrypt.Verify() │
          │              │   │ Şifre Kontrolü  │
          └──────┬───────┘   └────────┬────────┘
                 │                    │
                 │                    ▼
                 │          ◇─────────────────◇
                 │         ╱                   ╲
                 │        ╱   Şifre Doğru mu?   ╲
                 │        ╲                     ╱
                 │         ╲                   ╱
                 │          ◇─────────────────◇
                 │           │               │
                 │      [Hayır]          [Evet]
                 │           │               │
                 │           ▼               ▼
                 │   ┌──────────────┐ ┌─────────────────┐
                 │   │ return null  │ │ IsActive        │
                 │   │              │ │ Kontrolü        │
                 │   └──────┬───────┘ └────────┬────────┘
                 │          │                  │
                 │          │                  ▼
                 │          │        ◇─────────────────◇
                 │          │       ╱                   ╲
                 │          │      ╱   Aktif mi?         ╲
                 │          │      ╲                     ╱
                 │          │       ╲                   ╱
                 │          │        ◇─────────────────◇
                 │          │         │               │
                 │          │    [Hayır]          [Evet]
                 │          │         │               │
                 │          │         ▼               ▼
                 │          │ ┌──────────────┐ ┌─────────────────┐
                 │          │ │ return null  │ │ SessionManager  │
                 │          │ │              │ │ .Login(user)    │
                 │          │ └──────┬───────┘ └────────┬────────┘
                 │          │        │                  │
                 └──────────┴────────┘                  │
                            │                          │
                            ▼                          ▼
                   ┌──────────────┐          ◇─────────────────◇
                   │ "Geçersiz    │         ╱                   ╲
                   │ kullanıcı    │        ╱   RoleId = 4        ╲
                   │ veya şifre"  │       ╱    (Pending) mi?      ╲
                   └──────────────┘       ╲                       ╱
                                           ╲                     ╱
                                            ◇─────────────────◇
                                             │               │
                                         [Evet]          [Hayır]
                                             │               │
                                             ▼               ▼
                                    ┌──────────────┐ ┌─────────────────┐
                                    │FrmPending    │ │ FrmDashboard    │
                                    │Waitlist      │ │ Aç              │
                                    │Formu Aç     │ └────────┬────────┘
                                    └──────┬───────┘          │
                                           │                  │
                                           ▼                  ▼
                                    ┌──────────────┐          │
                                    │ "Admin onayı │          │
                                    │ bekleniyor"  │          │
                                    │ Mesajı       │          │
                                    └──────────────┘          │
                                                              │
                                                              ▼
                                                              ◉
```

---

## 4. Proje Oluşturma Akışı

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                         PROJE OLUŞTURMA AKIŞI                               │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │ ProjectsContent │
                    │ "Yeni Proje"    │
                    │ Butonuna Tıkla  │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ ProjectDetail   │
                    │ Control Aç      │
                    │ (Create Mode)   │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Proje Bilgileri │
                    │ Gir:            │
                    │ - Proje Adı     │
                    │ - Açıklama      │
                    │ - Başlangıç     │
                    │ - Bitiş Tarihi  │
                    │ - Bütçe         │
                    │ - Öncelik       │
                    │ - Takım Seç     │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ "Kaydet"        │
                    │ Butonuna Tıkla  │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   FluentValidation      ╲
               ╱      Doğrulama            ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
              [Geçersiz]          [Geçerli]
                   │                   │
                   ▼                   ▼
          ┌──────────────┐   ┌─────────────────┐
          │ Hata Mesajı  │   │ CreateProjectDto│
          │ Göster       │   │ Oluştur         │
          └──────────────┘   └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Project Entity  │
                             │ Oluştur:        │
                             │ Status="Planned"│
                             │ Completion=0    │
                             │ CreatedAt=Now   │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Veritabanına    │
                             │ Kaydet          │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ AuditLog        │
                             │ Kaydet          │
                             │ (Fire-and-Forget)│
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ "Proje          │
                             │ Oluşturuldu"    │
                             │ Mesajı          │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Proje Listesine │
                             │ Dön             │
                             └────────┬────────┘
                                      │
                                      ▼
                                      ◉
```

---

## 5. Görev Atama Akışı (E-posta Bildirimi ile)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                    GÖREV ATAMA AKIŞI (E-POSTA BİLDİRİMİ)                    │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │ TasksContent    │
                    │ "Yeni Görev"    │
                    │ Butonuna Tıkla  │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ TaskDetail      │
                    │ Control Aç      │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Görev Bilgileri │
                    │ Gir:            │
                    │ - Görev Adı     │
                    │ - Açıklama      │
                    │ - Proje Seç     │
                    │ - Kullanıcı Ata │◄─── AssignedUserId
                    │ - Öncelik       │
                    │ - Başlangıç     │
                    │ - Bitiş Tarihi  │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ "Kaydet"        │
                    │ Butonuna Tıkla  │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ CreateTaskAsync │
                    │ Çağrılır        │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Task Entity     │
                    │ Oluştur         │
                    │ Status=Pending  │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Veritabanına    │
                    │ Kaydet          │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   AssignedUserId       ╲
               ╱      var mı?             ╲
               ╲                          ╱
                ╲                        ╱
                 ╲                      ╱
                  ◇────────────────────◇
                   │                  │
               [Hayır]            [Evet]
                   │                  │
                   │                  ▼
                   │         ┌─────────────────┐
                   │         │ 📧 E-POSTA      │
                   │         │ GÖNDERİMİ       │
                   │         │ (Fire-and-Forget)│
                   │         └────────┬────────┘
                   │                  │
                   │                  ▼
                   │         ┌─────────────────┐
                   │         │ Atanan Kullanıcı│
                   │         │ Bilgilerini Al  │
                   │         └────────┬────────┘
                   │                  │
                   │                  ▼
                   │         ┌─────────────────┐
                   │         │ SendTaskAssign- │
                   │         │ mentEmailAsync()│
                   │         │                 │
                   │         │ İçerik:         │
                   │         │ - Görev Adı     │
                   │         │ - Proje Adı     │
                   │         │ - Atayan Kişi   │
                   │         │ - Bitiş Tarihi  │
                   │         │ - Açıklama      │
                   │         └────────┬────────┘
                   │                  │
                   └──────────────────┤
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ AuditLog        │
                             │ TaskCreated     │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Görev Listesine │
                             │ Dön             │
                             └────────┬────────┘
                                      │
                                      ▼
                                      ◉
```

---

## 6. Görev Durumu Değiştirme Akışı

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                    GÖREV DURUMU DEĞİŞTİRME AKIŞI                            │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   Görünüm Modu?         ╲
               ╱                           ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
              [Kanban]            [Grid]
                   │                   │
                   ▼                   ▼
          ┌──────────────┐   ┌─────────────────┐
          │ Görevi       │   │ Göreve Çift     │
          │ Sürükle-Bırak│   │ Tıkla           │
          │ (Drag&Drop)  │   └────────┬────────┘
          └──────┬───────┘            │
                 │                    ▼
                 │           ┌─────────────────┐
                 │           │ TaskDetail      │
                 │           │ Control Aç      │
                 │           └────────┬────────┘
                 │                    │
                 │                    ▼
                 │           ┌─────────────────┐
                 │           │ Status ComboBox │
                 │           │ Değiştir        │
                 │           └────────┬────────┘
                 │                    │
                 │                    ▼
                 │           ┌─────────────────┐
                 │           │ "Kaydet"        │
                 │           │ Butonuna Tıkla  │
                 │           └────────┬────────┘
                 │                    │
                 └────────────────────┤
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ UpdateTaskAsync │
                             │ Çağrılır        │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ oldStatus =     │
                             │ task.Status     │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ task.Status =   │
                             │ newStatus       │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Veritabanına    │
                             │ Kaydet          │
                             └────────┬────────┘
                                      │
                                      ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   oldStatus !=          ╲
               ╱      newStatus?           ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
               [Hayır]            [Evet]
                   │                   │
                   │                   ▼
                   │         ┌─────────────────┐
                   │         │ 📧 E-POSTA      │
                   │         │ GÖNDERİMİ       │
                   │         │ (Fire-and-Forget)│
                   │         └────────┬────────┘
                   │                  │
                   │                  ▼
                   │         ┌─────────────────┐
                   │         │ SendTaskStatus- │
                   │         │ UpdateEmailAsync│
                   │         │                 │
                   │         │ İçerik:         │
                   │         │ - Görev Adı     │
                   │         │ - Proje Adı     │
                   │         │ - Eski Durum    │
                   │         │ - Yeni Durum    │
                   │         └────────┬────────┘
                   │                  │
                   └──────────────────┤
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ AuditLog        │
                             │ TaskStatusChanged│
                             │ veya            │
                             │ TaskCompleted   │
                             └────────┬────────┘
                                      │
                                      ▼
                                      ◉
```

---

## 7. Takım Daveti Gönderme Akışı (Dual-Database Mimarisi)

### 7.1 Mimari Açıklama

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                    DAVET SİSTEMİ MİMARİSİ (DUAL-DATABASE)                   │
└─────────────────────────────────────────────────────────────────────────────┘

┌─────────────────┐                              ┌─────────────────┐
│   WinForms UI   │                              │   Web Sayfası   │
│  (Masaüstü App) │                              │ accept-invite   │
└────────┬────────┘                              └────────┬────────┘
         │                                                │
         │ 1. Davet Oluştur                               │ 4. Token ile
         │                                                │    Doğrula/Kabul
         ▼                                                ▼
┌─────────────────┐                              ┌─────────────────┐
│  LOCAL SQL DB   │                              │   REMOTE API    │
│ (SQL Server)    │                              │ (bilalabic.com) │
│                 │                              │                 │
│ TeamInvitations │                              │ /api/invitations│
│ - InvitationId  │                              │ - validate      │
│ - Token         │◄─── 2. Aynı Token ──────────▶│ - accept        │
│ - TeamId        │                              │ - decline       │
│ - Email         │                              │ - create        │
│ - Status        │                              └────────┬────────┘
└─────────────────┘                                       │
                                                          │
                                                          ▼
                                                 ┌─────────────────┐
                                                 │   PLESK DB      │
                                                 │ (Remote MySQL)  │
                                                 │                 │
                                                 │ Invitations     │
                                                 │ - Token         │
                                                 │ - Email         │
                                                 │ - TeamName      │
                                                 │ - Status        │
                                                 └─────────────────┘

📌 NOTLAR:
- WinForms hem Local DB'ye hem Remote API'ye yazar (paralel)
- Web sayfası SADECE Remote API/Plesk DB ile çalışır
- Kullanıcı kayıt olurken Local DB'deki TeamInvitations kontrol edilir
- Token her iki veritabanında da aynıdır (senkronizasyon anahtarı)
```

### 7.2 Davet Gönderme Akışı

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                      TAKIM DAVETİ GÖNDERME AKIŞI                            │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │ TeamsContent    │
                    │ Takım Seç       │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ TeamDetail      │
                    │ "Davet Gönder"  │
                    │ Butonuna Tıkla  │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Davet Bilgileri │
                    │ Gir:            │
                    │ - E-posta       │
                    │ - Rol Seç       │
                    │   (TeamRole)    │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ "Gönder"        │
                    │ Butonuna Tıkla  │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ SendInvitation- │
                    │ Async() Çağrılır│
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   Yetki Kontrolü        ╲
               ╱   (Owner/Admin/SysAdmin)  ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
              [Yetkisiz]          [Yetkili]
                   │                   │
                   ▼                   ▼
          ┌──────────────┐   ┌─────────────────┐
          │ "Yetkiniz    │   │ E-posta Zaten   │
          │ yok" Hatası  │   │ Üye mi?         │
          └──────────────┘   └────────┬────────┘
                                      │
                                      ▼
                            ◇─────────────────◇
                           ╱                   ╲
                          ╱   Zaten Üye mi?     ╲
                          ╲                     ╱
                           ╲                   ╱
                            ◇─────────────────◇
                             │               │
                         [Evet]          [Hayır]
                             │               │
                             ▼               ▼
                    ┌──────────────┐ ┌─────────────────┐
                    │ "Zaten üye"  │ │ Bekleyen Davet  │
                    │ Hatası       │ │ Var mı?         │
                    └──────────────┘ └────────┬────────┘
                                              │
                                              ▼
                                    ◇─────────────────◇
                                   ╱                   ╲
                                  ╱   Pending Davet?    ╲
                                  ╲                     ╱
                                   ╲                   ╱
                                    ◇─────────────────◇
                                     │               │
                                 [Evet]          [Hayır]
                                     │               │
                                     ▼               ▼
                            ┌──────────────┐ ┌─────────────────┐
                            │ "Zaten davet │ │ TeamInvitation  │
                            │ gönderilmiş" │ │ Entity Oluştur  │
                            └──────────────┘ │ Token=GUID+Ticks│
                                             │ ExpiresAt=+7gün │
                                             └────────┬────────┘
                                                      │
                                                      ▼
                                             ┌─────────────────┐
                                             │ 🗄️ LOCAL DB'YE  │
                                             │ KAYDET          │
                                             │ (TeamInvitations│
                                             │  tablosu)       │
                                             └────────┬────────┘
                                                      │
                                                      ▼
                                    ┌─────────────────────────────────┐
                                    │     PARALEL İŞLEMLER            │
                                    │     (Fire-and-Forget)           │
                                    └─────────────┬───────────────────┘
                                                  │
                              ┌────────────────────┴────────────────────┐
                              │                                        │
                              ▼                                        ▼
                    ┌─────────────────┐                      ┌─────────────────┐
                    │ 📧 E-POSTA      │                      │ 🌐 REMOTE API   │
                    │ GÖNDERİMİ       │                      │ ÇAĞRISI         │
                    └────────┬────────┘                      └────────┬────────┘
                             │                                        │
                             ▼                                        ▼
                    ┌─────────────────┐                      ┌─────────────────┐
                    │ SendTeamInvita- │                      │ RemoteInvitation│
                    │ tionEmailAsync()│                      │ Service         │
                    │                 │                      │ .SendToRemote() │
                    │ İçerik:         │                      └────────┬────────┘
                    │ - Takım Adı     │                               │
                    │ - Davet Eden    │                               ▼
                    │ - Rol           │                      ┌─────────────────┐
                    │ - Kabul Linki   │                      │ POST /api/      │
                    │   (Token'lı)    │                      │ invitations/    │
                    │ - Son Tarih     │                      │ create          │
                    └────────┬────────┘                      │                 │
                             │                               │ Payload:        │
                             │                               │ - token         │
                             │                               │ - email         │
                             │                               │ - teamName      │
                             │                               │ - invitedByName │
                             │                               │ - proposedRole  │
                             │                               │ - expiresAt     │
                             │                               └────────┬────────┘
                             │                                        │
                             │                                        ▼
                             │                               ┌─────────────────┐
                             │                               │ 🗄️ PLESK DB'YE │
                             │                               │ KAYDET          │
                             │                               │ (Invitations    │
                             │                               │  tablosu)       │
                             │                               └────────┬────────┘
                             │                                        │
                             └────────────────────┬───────────────────┘
                                                  │
                                                  ▼
                                         ┌─────────────────┐
                                         │ "Davet          │
                                         │ Gönderildi"     │
                                         │ Mesajı          │
                                         └────────┬────────┘
                                                  │
                                                  ▼
                                                  ◉
```

---

## 8. Davet Kabul/Red Akışı (Dual-Database)

### 8.1 Web Üzerinden Davet Kabul (Plesk DB)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                  WEB ÜZERİNDEN DAVET KABUL AKIŞI (PLESK DB)                 │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │ 📧 E-postadaki  │
                    │ Davet Linkine   │
                    │ Tıkla           │
                    │                 │
                    │ bilalabic.com/  │
                    │ accept-invite   │
                    │ ?token=xxx      │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ 🌐 Web Sayfası  │
                    │ accept-invite   │
                    │ .html Açılır    │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ URL'den Token   │
                    │ Alınır          │
                    │ (URLSearchParams)│
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ 🌐 REMOTE API   │
                    │ GET /api/       │
                    │ invitations/    │
                    │ validate?token= │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ 🗄️ PLESK DB    │
                    │ Invitations     │
                    │ Tablosunda      │
                    │ Token Ara       │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   Token Geçerli mi?     ╲
               ╱   - Mevcut mu?           ╲
               ╱   - Status=Pending mi?   ╲
               ╲   - Süresi dolmamış mı?  ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
              [Geçersiz]          [Geçerli]
                   │                   │
                   ▼                   ▼
          ┌──────────────┐   ┌─────────────────┐
          │ Hata Mesajı  │   │ Davet Detayları │
          │ Göster:      │   │ Göster:         │
          │ - Bulunamadı │   │ - Takım Adı     │
          │ - Kullanılmış│   │ - Davet Eden    │
          │ - Süresi Dolmuş│ │ - Rol           │
          └──────────────┘   │ - Son Tarih     │
                             └────────┬────────┘
                                      │
                                      ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   Kullanıcı Kararı?     ╲
               ╱                           ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
              [Reddet]            [Kabul Et]
                   │                   │
                   ▼                   ▼
          ┌──────────────┐   ┌─────────────────┐
          │ 🌐 POST /api/│   │ 🌐 POST /api/   │
          │ invitations/ │   │ invitations/    │
          │ decline      │   │ accept          │
          └──────┬───────┘   └────────┬────────┘
                 │                    │
                 ▼                    ▼
          ┌──────────────┐   ┌─────────────────┐
          │ 🗄️ PLESK DB │   │ 🗄️ PLESK DB    │
          │ Status =     │   │ Status =        │
          │ "Declined"   │   │ "Accepted"      │
          │ RespondedAt  │   │ RespondedAt     │
          │ = Now        │   │ = Now           │
          └──────┬───────┘   └────────┬────────┘
                 │                    │
                 ▼                    ▼
          ┌──────────────┐   ┌─────────────────┐
          │ "Daveti      │   │ ✅ Başarı Mesajı│
          │ reddettiniz" │   │ "Davet kabul    │
          │ Mesajı       │   │ edildi!         │
          └──────────────┘   │ Uygulamayı      │
                             │ indirip giriş   │
                             │ yapabilirsiniz" │
                             └────────┬────────┘
                                      │
                                      ▼
                                      ◉

📌 NOT: Web üzerinden kabul SADECE Plesk DB'yi günceller!
        Kullanıcı henüz sisteme kayıtlı değildir.
```

### 8.2 Davetli Kullanıcı Kayıt Akışı (Local DB)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                 DAVETLİ KULLANICI KAYIT AKIŞI (LOCAL DB)                    │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │ 🖥️ WinForms    │
                    │ FrmRegister     │
                    │ Formu Aç        │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Bilgileri Gir:  │
                    │ - Username      │
                    │ - Full Name     │
                    │ - Email         │
                    │ - Password      │
                    │ - Invitation    │
                    │   Token (opt)   │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ RegisterAsync() │
                    │ Çağrılır        │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   InvitationToken      ╲
               ╱      Var mı?             ╲
               ╲                          ╱
                ╲                        ╱
                 ╲                      ╱
                  ◇────────────────────◇
                   │                  │
               [Hayır]            [Evet]
                   │                  │
                   ▼                  ▼
          ┌──────────────┐   ┌─────────────────┐
          │ DİREKT KAYIT │   │ 🗄️ LOCAL DB    │
          │ RoleId = 4   │   │ TeamInvitations │
          │ (Pending)    │   │ Token ile Ara   │
          └──────┬───────┘   └────────┬────────┘
                 │                    │
                 │                    ▼
                 │          ◇─────────────────◇
                 │         ╱                   ╲
                 │        ╱   Token Geçerli mi? ╲
                 │       ╱    (Local DB'de)      ╲
                 │       ╲                       ╱
                 │        ╲                     ╱
                 │         ◇─────────────────◇
                 │          │               │
                 │     [Geçersiz]       [Geçerli]
                 │          │               │
                 │          ▼               ▼
                 │  ┌──────────────┐ ┌─────────────────┐
                 │  │ DİREKT KAYIT │ │ ProposedRole'e  │
                 │  │ RoleId = 4   │ │ Göre RoleId     │
                 │  │ (Pending)    │ │ Belirle:        │
                 │  └──────┬───────┘ │                 │
                 │         │         │ Owner/Admin/PM  │
                 │         │         │   → RoleId=2    │
                 │         │         │   (ProjectMgr)  │
                 │         │         │                 │
                 │         │         │ Developer       │
                 │         │         │   → RoleId=3    │
                 │         │         │   (Developer)   │
                 │         │         └────────┬────────┘
                 │         │                  │
                 └─────────┤                  │
                           │                  ▼
                           │         ┌─────────────────┐
                           │         │ User Entity     │
                           │         │ Oluştur         │
                           │         │ (Belirlenen Rol)│
                           │         └────────┬────────┘
                           │                  │
                           │                  ▼
                           │         ┌─────────────────┐
                           │         │ TeamMember      │
                           │         │ Entity Oluştur  │
                           │         │ Role=Proposed   │
                           │         │ TeamId=Davet'ten│
                           │         └────────┬────────┘
                           │                  │
                           │                  ▼
                           │         ┌─────────────────┐
                           │         │ 🗄️ LOCAL DB    │
                           │         │ TeamInvitation  │
                           │         │ Status=Accepted │
                           │         └────────┬────────┘
                           │                  │
                           └──────────────────┤
                                              │
                                              ▼
                                     ┌─────────────────┐
                                     │ 🗄️ LOCAL DB    │
                                     │ Kaydet:         │
                                     │ - User          │
                                     │ - TeamMember    │
                                     │ - Invitation    │
                                     └────────┬────────┘
                                              │
                                              ▼
                                     ┌─────────────────┐
                                     │ "Kayıt Başarılı"│
                                     │ Login Formuna   │
                                     │ Yönlendir       │
                                     └────────┬────────┘
                                              │
                                              ▼
                                              ◉

📌 NOTLAR:
- Davetli kayıt LOCAL DB'deki TeamInvitations tablosunu kontrol eder
- Web'de kabul edilen davet Plesk DB'de "Accepted" olur
- Kullanıcı kayıt olurken Local DB'deki davet de "Accepted" olur
- İki veritabanı arasında senkronizasyon TOKEN üzerinden sağlanır
```

### 8.3 Uygulama İçi Davet Kabul (Mevcut Kullanıcı)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│              UYGULAMA İÇİ DAVET KABUL AKIŞI (MEVCUT KULLANICI)              │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │ 🖥️ WinForms    │
                    │ MyInvitations   │
                    │ Content         │
                    │ (Davetlerim)    │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ 🗄️ LOCAL DB    │
                    │ GetUserPending- │
                    │ InvitationsAsync│
                    │ (email)         │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Bekleyen        │
                    │ Davetleri       │
                    │ Listele         │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Davet Seç       │
                    │ "Kabul Et"      │
                    │ Butonuna Tıkla  │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ AcceptInvita-   │
                    │ tionAsync()     │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   Zaten Takım Üyesi mi? ╲
               ╱                           ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
               [Evet]             [Hayır]
                   │                   │
                   ▼                   ▼
          ┌──────────────┐   ┌─────────────────┐
          │ "Zaten üye"  │   │ TeamMember      │
          │ Hatası       │   │ Entity Oluştur  │
          └──────────────┘   │ Role=Proposed   │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ 🗄️ LOCAL DB    │
                             │ TeamInvitation  │
                             │ Status=Accepted │
                             │ RespondedAt=Now │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Veritabanına    │
                             │ Kaydet          │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ "Takıma         │
                             │ katıldınız!"    │
                             │ Mesajı          │
                             └────────┬────────┘
                                      │
                                      ▼
                                      ◉
```

---

## 9. GitHub Repo Bağlama Akışı

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                       GITHUB REPO BAĞLAMA AKIŞI                             │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │ GitHubContent   │
                    │ Paneli Aç       │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   GitHub Token          ╲
               ╱      Kayıtlı mı?          ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
               [Hayır]            [Evet]
                   │                   │
                   ▼                   │
          ┌──────────────┐            │
          │ "Token Ekle" │            │
          │ Butonuna     │            │
          │ Tıkla        │            │
          └──────┬───────┘            │
                 │                    │
                 ▼                    │
          ┌──────────────┐            │
          │ GitHub PAT   │            │
          │ Gir          │            │
          └──────┬───────┘            │
                 │                    │
                 ▼                    │
          ┌──────────────┐            │
          │ Token        │            │
          │ Şifrele ve   │            │
          │ Kaydet       │            │
          └──────┬───────┘            │
                 │                    │
                 └────────────────────┤
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Proje Seç       │
                             │ (GitHub URL'si  │
                             │ olan)           │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ "Sync" Butonuna │
                             │ Tıkla           │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ TokenPoolService│
                             │ En uygun token  │
                             │ seç (Rate Limit)│
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ GitHub API      │
                             │ Çağrısı         │
                             │ (Commits, Files)│
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ GitRepository   │
                             │ Entity Oluştur/ │
                             │ Güncelle        │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ GitCommit       │
                             │ Kayıtları       │
                             │ Oluştur         │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ GitFileChange   │
                             │ Kayıtları       │
                             │ Oluştur         │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ TaskMatching    │
                             │ Service         │
                             │ (Commit-Task    │
                             │ Eşleştirme)     │
                             └────────┬────────┘
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ Analytics       │
                             │ Göster:         │
                             │ - Commit Sayısı │
                             │ - Contributor   │
                             │ - File Changes  │
                             │ - Hotspots      │
                             └────────┬────────┘
                                      │
                                      ▼
                                      ◉
```

---

## 10. Risk Hesaplama Akışı (Akıllı Algoritma)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                    RİSK HESAPLAMA AKIŞI (AKILLI ALGORİTMA)                  │
└─────────────────────────────────────────────────────────────────────────────┘

                              ●
                              │
                              ▼
                    ┌─────────────────┐
                    │ CalculateProject│
                    │ RiskAsync()     │
                    │ Çağrılır        │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ Proje Bilgileri │
                    │ Al:             │
                    │ - StartDate     │
                    │ - EndDate       │
                    │ - Completion%   │
                    └────────┬────────┘
                             │
                             ▼
                    ┌─────────────────┐
                    │ FAKTÖR 1:       │
                    │ Zaman vs        │
                    │ Tamamlanma      │
                    │                 │
                    │ expectedComp =  │
                    │ (elapsed/total) │
                    │ × 100           │
                    └────────┬────────┘
                             │
                             ▼
                  ◇─────────────────────◇
                 ╱                       ╲
                ╱   Completion <          ╲
               ╱      expectedCompletion?  ╲
               ╲                           ╱
                ╲                         ╱
                 ╲                       ╱
                  ◇─────────────────────◇
                   │                   │
               [Hayır]            [Evet]
                   │                   │
                   │                   ▼
                   │         ┌─────────────────┐
                   │         │ riskScore +=    │
                   │         │ (expected -     │
                   │         │  actual)        │
                   │         └────────┬────────┘
                   │                  │
                   └──────────────────┤
                                      │
                                      ▼
                             ┌─────────────────┐
                             │ FAKTÖR 2:       │
                             │ Görev Tamamlanma│
                             │ Oranı           │
                             │                 │
                             │ taskRate =      │
                             │ completed/total │
                             │ × 100           │
                             └────────┬────────┘
                                      │
                                      ▼
                            ◇─────────────────◇
                           ╱                   ╲
                          ╱   taskRate < 50%?   ╲
                          ╲                     ╱
                           ╲                   ╱
                            ◇─────────────────◇
                             │               │
                         [Hayır]         [Evet]
                             │               │
                             │               ▼
                             │      ┌─────────────────┐
                             │      │ riskScore += 20 │
                             │      └────────┬────────┘
                             │               │
                             └───────────────┤
                                             │
                                             ▼
                                    ┌─────────────────┐
                                    │ Normalize:      │
                                    │ riskScore =     │
                                    │ Min(score, 100) │
                                    └────────┬────────┘
                                             │
                                             ▼
                                    ┌─────────────────┐
                                    │ Project.Risk-   │
                                    │ Score = score   │
                                    └────────┬────────┘
                                             │
                                             ▼
                                    ┌─────────────────┐
                                    │ Veritabanına    │
                                    │ Kaydet          │
                                    └────────┬────────┘
                                             │
                                             ▼
                                    ┌─────────────────┐
                                    │ Risk Seviyesi:  │
                                    │ 0-40: Düşük 🟢  │
                                    │ 41-70: Orta 🟡  │
                                    │ 71-100: Yüksek🔴│
                                    └────────┬────────┘
                                             │
                                             ▼
                                             ◉
```

---

## 11. Özet Tablo

| # | İş Akışı | Tetikleyici | Sonuç | E-posta | Veritabanı |
|---|----------|-------------|-------|---------|------------|
| 1 | Direkt Kayıt | Kayıt Formu | Pending Rol | ❌ | Local DB |
| 2 | Davetli Kayıt | Token ile Kayıt | Belirlenen Rol + Takım Üyeliği | ❌ | Local DB |
| 3 | Giriş | Login Formu | Dashboard veya Waitlist | ❌ | Local DB |
| 4 | Proje Oluştur | Yeni Proje Butonu | Proje Kaydı + AuditLog | ❌ | Local DB |
| 5 | Görev Ata | Yeni Görev Butonu | Görev Kaydı + AuditLog | ✅ | Local DB |
| 6 | Durum Değiştir | Kanban/Grid | Görev Güncelleme + AuditLog | ✅ | Local DB |
| 7 | Davet Gönder | Davet Butonu | Invitation Kaydı | ✅ | Local DB + Plesk DB |
| 8a | Web'de Kabul | E-posta Link | Plesk'te Status=Accepted | ❌ | Plesk DB |
| 8b | Davetli Kayıt | WinForms Kayıt | User + TeamMember | ❌ | Local DB |
| 8c | Uygulama İçi Kabul | Davetlerim | TeamMember Kaydı | ❌ | Local DB |
| 9 | GitHub Sync | Sync Butonu | Commit/File Kayıtları | ❌ | Local DB |
| 10 | Risk Hesapla | Otomatik/Manuel | RiskScore Güncelleme | ❌ | Local DB |

---

## 12. Dual-Database Senkronizasyon Özeti

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                    DUAL-DATABASE SENKRONİZASYON AKIŞI                       │
└─────────────────────────────────────────────────────────────────────────────┘

                    ┌─────────────────────────────────────┐
                    │         DAVET OLUŞTURMA             │
                    │         (WinForms)                  │
                    └─────────────────┬───────────────────┘
                                      │
                    ┌─────────────────┴───────────────────┐
                    │                                     │
                    ▼                                     ▼
           ┌─────────────────┐                   ┌─────────────────┐
           │   LOCAL DB      │                   │   PLESK DB      │
           │ TeamInvitations │                   │  Invitations    │
           │                 │                   │                 │
           │ Token: ABC123   │◄── AYNI TOKEN ──►│ Token: ABC123   │
           │ Status: Pending │                   │ Status: Pending │
           └─────────────────┘                   └─────────────────┘
                    │                                     │
                    │                                     │
                    │                                     ▼
                    │                            ┌─────────────────┐
                    │                            │ WEB KABUL       │
                    │                            │ Status: Accepted│
                    │                            └─────────────────┘
                    │
                    ▼
           ┌─────────────────┐
           │ KULLANICI KAYIT │
           │ (Token ile)     │
           │                 │
           │ Status: Accepted│
           │ + User oluştur  │
           │ + TeamMember    │
           └─────────────────┘

📌 NOTLAR:
1. Token her iki veritabanında da aynıdır (senkronizasyon anahtarı)
2. Web kabul SADECE Plesk DB'yi günceller
3. Kullanıcı kayıt SADECE Local DB'yi günceller
4. İki veritabanı bağımsız çalışır, token üzerinden ilişkilendirilir
5. Kullanıcı web'de kabul etmese bile, token ile kayıt olabilir
```

---

**Oluşturulma Tarihi:** 6 Ocak 2026  
**Son Güncelleme:** 6 Ocak 2026 (Dual-Database mimarisi eklendi)  
**Proje:** Project Tracker v1.0
