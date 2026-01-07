# Use Case Diyagramı

## Project Tracker - Kullanım Senaryoları

---

## 1. Aktörler (Actors)

| Aktör | RoleId | Açıklama | Yetki Seviyesi |
|-------|--------|----------|----------------|
| **Admin** | 1 | Sistem yöneticisi, tüm yetkilere sahip | En yüksek |
| **ProjectManager** | 2 | Proje ve takım yönetimi yapabilir | Yüksek |
| **Developer** | 3 | Görev üzerinde çalışabilir | Orta |
| **Pending** | 4 | Onay bekleyen kullanıcı (sınırlı erişim) | Çok düşük |
| **Misafir (Guest)** | - | Kayıt olmamış kullanıcı | Yok |

> **Not:** Sistem 4 rol içermektedir. "Pending" rolü yeni kayıt olan kullanıcılara atanır ve Admin onayı bekler.

---

## 2. Use Case Diyagramı (ASCII)

```
┌─────────────────────────────────────────────────────────────────────────────────┐
│                           PROJECT TRACKER SİSTEMİ                               │
├─────────────────────────────────────────────────────────────────────────────────┤
│                                                                                 │
│  ┌─────────┐                                                                    │
│  │ Misafir │                                                                    │
│  └────┬────┘                                                                    │
│       │                                                                         │
│       ├──────────────────► [Kayıt Ol] ──► Pending rolü atanır                  │
│       │                                                                         │
│       └──────────────────► [Giriş Yap]                                         │
│                                                                                 │
│  ┌─────────┐                                                                    │
│  │ Pending │  (Onay Bekleyen Kullanıcı - RoleId: 4)                            │
│  └────┬────┘                                                                    │
│       │                                                                         │
│       └──► [Bekleme Ekranı Görüntüle] (Admin onayı bekleniyor)                 │
│                                                                                 │
│  ┌───────────┐                                                                  │
│  │ Developer │  (RoleId: 3)                                                     │
│  └─────┬─────┘                                                                  │
│        │                                                                        │
│        ├──► [Dashboard Görüntüle]                                              │
│        ├──► [Proje Listesi Görüntüle]                                          │
│        ├──► [Görev Listesi Görüntüle]                                          │
│        ├──► [Görev Durumu Güncelle] ──► 📧 E-posta bildirimi                   │
│        ├──► [Görev Yorumu Ekle]                                                │
│        ├──► [Zaman Kaydı Ekle]                                                 │
│        ├──► [Profil Düzenle]                                                   │
│        ├──► [GitHub Token Ekle]                                                │
│        ├──► [Rapor Görüntüle]                                                  │
│        └──► [Davet Kabul/Reddet]                                               │
│                                                                                 │
│  ┌────────────────┐                                                             │
│  │ ProjectManager │  (RoleId: 2)                                                │
│  └───────┬────────┘                                                             │
│          │                                                                      │
│          ├──► [Proje Oluştur]                                                  │
│          ├──► [Proje Düzenle]                                                  │
│          ├──► [Proje Sil]                                                      │
│          ├──► [Görev Oluştur]                                                  │
│          ├──► [Görev Ata] ──► 📧 E-posta bildirimi (atanan kişiye)             │
│          ├──► [Görev Düzenle]                                                  │
│          ├──► [Görev Sil]                                                      │
│          ├──► [Takım Oluştur]                                                  │
│          ├──► [Takım Düzenle]                                                  │
│          ├──► [Üye Davet Et] ──► 📧 E-posta bildirimi (davet linki)            │
│          ├──► [Üye Rolü Değiştir]                                              │
│          ├──► [GitHub Repo Bağla]                                              │
│          ├──► [Risk Analizi Görüntüle]                                         │
│          └──► [Rapor Dışa Aktar (PDF/Excel)]                                   │
│                                                                                 │
│  ┌─────────┐                                                                    │
│  │  Admin  │  (RoleId: 1)                                                       │
│  └────┬────┘                                                                    │
│       │                                                                         │
│       ├──► [Kullanıcı Yönetimi]                                                │
│       │       ├── Kullanıcı Listele                                            │
│       │       ├── Pending Kullanıcıları Onayla                                 │
│       │       ├── Kullanıcı Aktif/Pasif Yap                                    │
│       │       └── Kullanıcı Rolü Değiştir                                      │
│       │                                                                         │
│       ├──► [Tüm ProjectManager Yetkileri]                                      │
│       │                                                                         │
│       └──► [Audit Log Görüntüle]                                               │
│               ├── Tüm İşlemleri Listele                                        │
│               └── Filtreleme/Arama                                             │
│                                                                                 │
└─────────────────────────────────────────────────────────────────────────────────┘
```

### 📧 E-posta Bildirim Sistemi

Sistem aşağıdaki durumlarda otomatik e-posta gönderir:

| Olay | Alıcı | E-posta İçeriği |
|------|-------|-----------------|
| Görev Atama | Atanan kullanıcı | Görev detayları, proje adı, bitiş tarihi |
| Görev Durumu Değişikliği | Atanan kullanıcı | Eski durum → Yeni durum |
| Takım Daveti | Davet edilen e-posta | Takım adı, rol, kabul linki |

---

## 3. Use Case Detayları

### 3.1 Kimlik Doğrulama Modülü

| Use Case | Aktör | Açıklama | Önkoşul |
|----------|-------|----------|---------|
| UC-01: Kayıt Ol | Misafir | Yeni kullanıcı hesabı oluşturma | - |
| UC-02: Giriş Yap | Misafir | Sisteme giriş yapma | Kayıtlı kullanıcı |
| UC-03: Çıkış Yap | Tüm Kullanıcılar | Oturumu sonlandırma | Giriş yapmış |
| UC-04: Şifre Değiştir | Tüm Kullanıcılar | Şifre güncelleme | Giriş yapmış |

### 3.2 Proje Yönetimi Modülü

| Use Case | Aktör | Açıklama | Önkoşul |
|----------|-------|----------|---------|
| UC-05: Proje Listele | Observer+ | Projeleri görüntüleme | Giriş yapmış |
| UC-06: Proje Oluştur | ProjectManager+ | Yeni proje oluşturma | Takım üyesi |
| UC-07: Proje Düzenle | ProjectManager+ | Proje bilgilerini güncelleme | Proje sahibi/admin |
| UC-08: Proje Sil | ProjectManager+ | Projeyi silme (soft delete) | Proje sahibi |
| UC-09: Proje Detay | Observer+ | Proje detaylarını görüntüleme | Takım üyesi |

### 3.3 Görev Yönetimi Modülü

| Use Case | Aktör | Açıklama | Önkoşul |
|----------|-------|----------|---------|
| UC-10: Görev Listele | Observer+ | Görevleri görüntüleme (Grid/Kanban) | Proje erişimi |
| UC-11: Görev Oluştur | ProjectManager+ | Yeni görev oluşturma | Proje erişimi |
| UC-12: Görev Ata | ProjectManager+ | Görevi kullanıcıya atama | Görev mevcut |
| UC-13: Görev Düzenle | Developer+ | Görev bilgilerini güncelleme | Atanmış/yetkili |
| UC-14: Görev Durumu Değiştir | Developer+ | Pending→InProgress→Completed | Atanmış |
| UC-15: Görev Sil | ProjectManager+ | Görevi silme | Görev sahibi |
| UC-16: Yorum Ekle | Developer+ | Göreve yorum ekleme | Proje erişimi |
| UC-17: Zaman Kaydı Ekle | Developer+ | Çalışma saati kaydetme | Görev atanmış |

### 3.4 Takım Yönetimi Modülü

| Use Case | Aktör | Açıklama | Önkoşul |
|----------|-------|----------|---------|
| UC-18: Takım Listele | Observer+ | Takımları görüntüleme | Giriş yapmış |
| UC-19: Takım Oluştur | ProjectManager+ | Yeni takım oluşturma | Giriş yapmış |
| UC-20: Takım Düzenle | Admin/Owner | Takım bilgilerini güncelleme | Takım sahibi |
| UC-21: Üye Davet Et | Admin/Owner | E-posta ile davet gönderme | Takım sahibi |
| UC-22: Davet Kabul/Red | Developer+ | Daveti yanıtlama | Davet almış |
| UC-23: Üye Çıkar | Admin/Owner | Üyeyi takımdan çıkarma | Takım sahibi |
| UC-24: Rol Değiştir | Admin/Owner | Üye rolünü değiştirme | Takım sahibi |

### 3.5 Raporlama Modülü

| Use Case | Aktör | Açıklama | Önkoşul |
|----------|-------|----------|---------|
| UC-25: Dashboard Görüntüle | Observer+ | KPI'ları görüntüleme | Giriş yapmış |
| UC-26: Rapor Görüntüle | Observer+ | Detaylı raporları görüntüleme | Proje erişimi |
| UC-27: PDF Dışa Aktar | ProjectManager+ | Raporu PDF olarak indirme | Rapor erişimi |
| UC-28: Excel Dışa Aktar | ProjectManager+ | Veriyi Excel olarak indirme | Rapor erişimi |
| UC-29: Risk Analizi | ProjectManager+ | Proje risk skorunu görüntüleme | Proje erişimi |

### 3.6 GitHub Entegrasyonu Modülü

| Use Case | Aktör | Açıklama | Önkoşul |
|----------|-------|----------|---------|
| UC-30: GitHub Token Ekle | Developer+ | Personal Access Token kaydetme | Giriş yapmış |
| UC-31: Repo Bağla | ProjectManager+ | Projeye GitHub repo bağlama | Proje sahibi |
| UC-32: Commit Görüntüle | Observer+ | Commit geçmişini görüntüleme | Repo bağlı |
| UC-33: Analitik Görüntüle | Observer+ | GitHub istatistiklerini görüntüleme | Repo bağlı |

### 3.7 Yönetim Modülü (Admin)

| Use Case | Aktör | Açıklama | Önkoşul |
|----------|-------|----------|---------|
| UC-34: Kullanıcı Listele | Admin | Tüm kullanıcıları görüntüleme | Admin rolü |
| UC-35: Kullanıcı Aktif/Pasif | Admin | Hesabı aktif/pasif yapma | Admin rolü |
| UC-36: Rol Atama | Admin | Kullanıcıya sistem rolü atama | Admin rolü |
| UC-37: Audit Log Görüntüle | Admin | Sistem loglarını görüntüleme | Admin rolü |

---

## 4. Use Case İlişkileri

### Include İlişkileri
```
[Proje Oluştur] ──include──► [Yetki Kontrolü]
[Görev Ata] ──include──► [Bildirim Gönder]
[Üye Davet Et] ──include──► [E-posta Gönder]
[Görev Durumu Değiştir] ──include──► [Audit Log Kaydet]
```

### Extend İlişkileri
```
[Proje Görüntüle] ◄──extend── [Risk Analizi Görüntüle]
[Görev Listele] ◄──extend── [Kanban Görünümü]
[Rapor Görüntüle] ◄──extend── [PDF Dışa Aktar]
```

### Generalization (Kalıtım)
```
         ┌─────────────┐
         │   Misafir   │
         └──────┬──────┘
                │
       ┌────────┴────────┐
       │                 │
       ▼                 ▼
┌─────────────┐   ┌─────────────┐
│ Direkt Kayıt│   │ Takım Daveti│
└──────┬──────┘   └──────┬──────┘
       │                 │
       ▼                 │
┌─────────────┐          │
│   Pending   │          │ (Davette belirtilen
│  (RoleId:4) │          │  rol atanır)
└──────┬──────┘          │
       │ (Admin onayı)   │
       ▼                 ▼
┌─────────────────────────────┐
│  Developer (RoleId: 3)      │
│  veya                       │
│  ProjectManager (RoleId: 2) │
└──────────────┬──────────────┘
               │
        ┌──────▼──────┐
        │    Admin    │  (RoleId: 1)
        └─────────────┘
```

> **Kullanıcı Kayıt Akışı:**
> - **Direkt Kayıt:** Misafir → Pending → (Admin Onayı) → Developer/ProjectManager
> - **Takım Daveti:** Misafir → E-posta daveti kabul → Davetteki rol atanır (Developer/ProjectManager)

---

## 5. Senaryo Örnekleri

### Senaryo 1: Yeni Proje Oluşturma
```
Aktör: Proje Yöneticisi
Önkoşul: Kullanıcı giriş yapmış ve bir takıma üye

1. Kullanıcı "Projeler" menüsüne tıklar
2. "Yeni Proje" butonuna tıklar
3. Proje bilgilerini girer:
   - Proje Adı
   - Açıklama
   - Başlangıç/Bitiş Tarihi
   - Bütçe
   - Öncelik
   - Takım Seçimi
4. "Kaydet" butonuna tıklar
5. Sistem projeyi kaydeder ve Audit Log oluşturur
6. Kullanıcı proje listesine yönlendirilir

Alternatif Akış:
4a. Validasyon hatası varsa hata mesajı gösterilir
```

### Senaryo 2: Görev Durumu Değiştirme (Kanban)
```
Aktör: Geliştirici
Önkoşul: Kullanıcıya görev atanmış

1. Kullanıcı "Görevler" menüsüne tıklar
2. "Kanban" görünümünü seçer
3. Kendi görevini "Pending" sütunundan sürükler
4. "InProgress" sütununa bırakır
5. Sistem durumu günceller
6. Audit Log kaydedilir
7. Proje tamamlanma yüzdesi güncellenir
```

### Senaryo 3: Takıma Üye Davet Etme
```
Aktör: Takım Sahibi
Önkoşul: Kullanıcı takım sahibi

1. Kullanıcı "Takımlar" menüsüne tıklar
2. Takımı seçer ve "Davet Gönder" butonuna tıklar
3. Davet edilecek e-posta adresini girer
4. Rol seçer (Developer/Observer)
5. "Gönder" butonuna tıklar
6. Sistem davet e-postası gönderir
7. Davet listesinde "Bekliyor" olarak görünür

Alternatif Akış:
3a. E-posta zaten kayıtlıysa uyarı gösterilir
```

---

**Oluşturulma Tarihi:** 6 Ocak 2026  
**Proje:** Project Tracker v1.0
