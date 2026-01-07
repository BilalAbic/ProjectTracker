# 📊 Maliyet Kestirim Dokümanı

## Project Tracker - İşlev Nokta Analizi

---

## FIRAT ÜNİVERSİTESİ - YMH219 Nesne Tabanlı Programlama
**Proje:** Project Tracker - Akıllı Proje Yönetim Sistemi  
**Öğrenci:** 240542031 - Bilal ABİÇ  
**Tarih:** Ocak 2026

---

## 1. İşlev Nokta Analizi (Function Point Analysis)

### 1.1 Kullanıcı Girdi Sayısı (External Inputs - EI)

Kullanıcıdan alınan ve veritabanını güncelleyen girdiler:

| # | Girdi | Form/Control | Karmaşıklık |
|---|-------|--------------|-------------|
| 1 | Kullanıcı Girişi | FrmLogin | Basit |
| 2 | Kullanıcı Kaydı | FrmRegister | Orta |
| 3 | Proje Oluşturma | ProjectDetailControl | Karmaşık |
| 4 | Proje Güncelleme | ProjectDetailControl | Karmaşık |
| 5 | Proje Silme | ProjectsContent | Basit |
| 6 | Görev Oluşturma | TaskDetailControl | Karmaşık |
| 7 | Görev Güncelleme | TaskDetailControl | Karmaşık |
| 8 | Görev Silme | TasksContent | Basit |
| 9 | Görev Durumu Değiştirme (Kanban) | TasksContent | Orta |
| 10 | Takım Oluşturma | TeamDetailControl | Orta |
| 11 | Takım Güncelleme | TeamDetailControl | Orta |
| 12 | Takım Silme | TeamsContent | Basit |
| 13 | Takım Üyesi Ekleme | TeamDetailControl | Orta |
| 14 | Takım Üyesi Çıkarma | TeamMembersContent | Basit |
| 15 | Davet Gönderme | TeamDetailControl | Karmaşık |
| 16 | Davet Kabul/Red | MyInvitationsContent | Orta |
| 17 | GitHub Token Ekleme | GitHubContent | Orta |
| 18 | GitHub Sync Tetikleme | GitHubContent | Karmaşık |
| 19 | Kullanıcı Ayarları Güncelleme | UserSettingsContent | Orta |
| 20 | Kullanıcı Onaylama (Admin) | TeamMembersContent | Basit |
| 21 | Kullanıcı Rol Değiştirme | TeamMembersContent | Orta |

**Ağırlıklı Hesaplama:**
| Karmaşıklık | Sayı | Ağırlık | Toplam |
|-------------|------|---------|--------|
| Basit | 6 | 3 | 18 |
| Orta | 9 | 4 | 36 |
| Karmaşık | 6 | 6 | 36 |
| **TOPLAM EI** | **21** | | **90** |

---

### 1.2 Kullanıcı Çıktı Sayısı (External Outputs - EO)

Sistemden kullanıcıya sunulan çıktılar:

| # | Çıktı | Form/Control | Karmaşıklık |
|---|-------|--------------|-------------|
| 1 | Dashboard İstatistikleri | DashboardContent | Karmaşık |
| 2 | Proje Listesi | ProjectsContent | Orta |
| 3 | Proje Detay Görünümü | ProjectDetailControl | Karmaşık |
| 4 | Görev Listesi (Grid) | TasksContent | Orta |
| 5 | Görev Listesi (Kanban) | TasksContent | Karmaşık |
| 6 | Görev Detay Görünümü | TaskDetailControl | Karmaşık |
| 7 | Takım Listesi | TeamsContent | Orta |
| 8 | Takım Detay Görünümü | TeamDetailControl | Karmaşık |
| 9 | Takım Üyeleri Listesi | TeamMembersContent | Orta |
| 10 | Davet Listesi | InvitationsContent | Orta |
| 11 | Bekleyen Davetlerim | MyInvitationsContent | Orta |
| 12 | GitHub Commit Listesi | GitHubContent | Karmaşık |
| 13 | GitHub Analytics | GitHubContent | Karmaşık |
| 14 | GitHub File Hotspots | GitHubContent | Karmaşık |
| 15 | Proje Bazlı Rapor | ReportsContent | Karmaşık |
| 16 | Kullanıcı Bazlı Rapor | ReportsContent | Karmaşık |
| 17 | Takım Bazlı Rapor | ReportsContent | Karmaşık |
| 18 | Risk Analizi Raporu | ReportsContent | Karmaşık |
| 19 | E-posta Bildirimi (Görev Atama) | EmailService | Orta |
| 20 | E-posta Bildirimi (Durum Değişikliği) | EmailService | Orta |
| 21 | E-posta Bildirimi (Davet) | EmailService | Orta |
| 22 | Audit Log Görünümü | ReportsContent | Orta |

**Ağırlıklı Hesaplama:**
| Karmaşıklık | Sayı | Ağırlık | Toplam |
|-------------|------|---------|--------|
| Basit | 0 | 4 | 0 |
| Orta | 10 | 5 | 50 |
| Karmaşık | 12 | 7 | 84 |
| **TOPLAM EO** | **22** | | **134** |

---

### 1.3 Kullanıcı Sorgu Sayısı (External Inquiries - EQ)

Veritabanından veri çeken sorgular:

| # | Sorgu | Açıklama | Karmaşıklık |
|---|-------|----------|-------------|
| 1 | Kullanıcı Doğrulama | Login kontrolü | Basit |
| 2 | Kullanıcı Bilgisi Getir | Profil bilgileri | Basit |
| 3 | Proje Listesi Getir | Filtreleme ile | Orta |
| 4 | Proje Detay Getir | İlişkili verilerle | Karmaşık |
| 5 | Görev Listesi Getir | Proje/Kullanıcı bazlı | Orta |
| 6 | Görev Detay Getir | İlişkili verilerle | Karmaşık |
| 7 | Takım Listesi Getir | Kullanıcı bazlı | Orta |
| 8 | Takım Üyeleri Getir | Rol bilgisiyle | Orta |
| 9 | Davet Listesi Getir | Takım bazlı | Orta |
| 10 | Bekleyen Davetler Getir | E-posta bazlı | Orta |
| 11 | GitHub Repo Bilgisi Getir | Proje bazlı | Orta |
| 12 | GitHub Commit Listesi Getir | Repo bazlı | Karmaşık |
| 13 | GitHub File Changes Getir | Commit bazlı | Karmaşık |
| 14 | Dashboard İstatistikleri Getir | Aggregation | Karmaşık |
| 15 | Rapor Verileri Getir | Çoklu tablo join | Karmaşık |
| 16 | Risk Skoru Hesapla | Algoritma bazlı | Karmaşık |
| 17 | Token Pool Durumu Getir | Rate limit kontrolü | Orta |
| 18 | Audit Log Getir | Filtreleme ile | Orta |

**Ağırlıklı Hesaplama:**
| Karmaşıklık | Sayı | Ağırlık | Toplam |
|-------------|------|---------|--------|
| Basit | 2 | 3 | 6 |
| Orta | 9 | 4 | 36 |
| Karmaşık | 7 | 6 | 42 |
| **TOPLAM EQ** | **18** | | **84** |

---

### 1.4 Dahili Mantıksal Dosya Sayısı (Internal Logical Files - ILF)

Sistem tarafından yönetilen veritabanı tabloları:

| # | Tablo | Açıklama | Karmaşıklık |
|---|-------|----------|-------------|
| 1 | Users | Kullanıcı bilgileri | Karmaşık |
| 2 | Roles | Sistem rolleri | Basit |
| 3 | Projects | Proje bilgileri | Karmaşık |
| 4 | Tasks | Görev bilgileri | Karmaşık |
| 5 | TaskComments | Görev yorumları | Orta |
| 6 | Teams | Takım bilgileri | Orta |
| 7 | TeamMembers | Takım üyelikleri | Orta |
| 8 | TeamInvitations | Takım davetleri | Orta |
| 9 | ProjectTeamMembers | Proje-Kullanıcı ilişkisi | Orta |
| 10 | ProjectRisks | Risk kayıtları | Orta |
| 11 | ProjectSnapshots | Proje anlık görüntüleri | Karmaşık |
| 12 | Notifications | Bildirimler | Orta |
| 13 | TimeEntries | Zaman kayıtları | Orta |
| 14 | AuditLogs | Denetim kayıtları | Karmaşık |
| 15 | GitRepositories | GitHub repo bilgileri | Karmaşık |
| 16 | GitCommits | Commit kayıtları | Karmaşık |
| 17 | GitFileChanges | Dosya değişiklikleri | Orta |
| 18 | GitHubTokens | GitHub token'ları | Orta |

**Ağırlıklı Hesaplama:**
| Karmaşıklık | Sayı | Ağırlık | Toplam |
|-------------|------|---------|--------|
| Basit | 1 | 7 | 7 |
| Orta | 10 | 10 | 100 |
| Karmaşık | 7 | 15 | 105 |
| **TOPLAM ILF** | **18** | | **212** |

---

### 1.5 Harici Arayüz Dosya Sayısı (External Interface Files - EIF)

Dış sistemlerle entegrasyon:

| # | Arayüz | Açıklama | Karmaşıklık |
|---|--------|----------|-------------|
| 1 | GitHub REST API | Commit, repo, file bilgileri | Karmaşık |
| 2 | SMTP E-posta Servisi | Bildirim gönderimi | Orta |
| 3 | Remote Invitation API | Plesk veritabanı entegrasyonu | Orta |
| 4 | Plesk Invitations DB | Uzak davet veritabanı | Orta |

**Ağırlıklı Hesaplama:**
| Karmaşıklık | Sayı | Ağırlık | Toplam |
|-------------|------|---------|--------|
| Basit | 0 | 5 | 0 |
| Orta | 3 | 7 | 21 |
| Karmaşık | 1 | 10 | 10 |
| **TOPLAM EIF** | **4** | | **31** |

---

## 2. Ayarlanmamış İşlev Noktası (AİN) Hesabı

| Parametre | Toplam |
|-----------|--------|
| Kullanıcı Girdi (EI) | 90 |
| Kullanıcı Çıktı (EO) | 134 |
| Kullanıcı Sorgu (EQ) | 84 |
| Dahili Mantıksal Dosya (ILF) | 212 |
| Harici Arayüz Dosya (EIF) | 31 |
| **AİN (Ayarlanmamış İşlev Noktası)** | **551** |

---

## 3. Teknik Karmaşıklık Faktörü (TKF)

### 3.1 Teknik Karmaşıklık Soruları

| # | Soru | Puan (0-5) | Açıklama |
|---|------|------------|----------|
| 1 | Veri iletişimi | 4 | REST API, SMTP, Remote API |
| 2 | Dağıtık veri işleme | 3 | Dual-database mimarisi |
| 3 | Performans | 3 | Token pool, async işlemler |
| 4 | Yoğun kullanılan konfigürasyon | 3 | appsettings, DI container |
| 5 | İşlem hızı | 3 | Fire-and-forget, paralel işlemler |
| 6 | Online veri girişi | 5 | Tüm işlemler online |
| 7 | Son kullanıcı verimliliği | 4 | DevExpress UI, Kanban, Dashboard |
| 8 | Online güncelleme | 5 | Real-time CRUD işlemleri |
| 9 | Karmaşık işleme | 4 | Risk hesaplama, GitHub sync, task matching |
| 10 | Yeniden kullanılabilirlik | 4 | Generic repository, base services |
| 11 | Kurulum kolaylığı | 3 | Migration, seed data |
| 12 | İşletim kolaylığı | 4 | Audit log, hata yönetimi |
| 13 | Çoklu site | 2 | Web + WinForms |
| 14 | Değişiklik kolaylığı | 4 | Katmanlı mimari, DI, AutoMapper |

**Toplam Teknik Karmaşıklık Puanı (TKP):** 51

### 3.2 TKF Hesabı

```
TKF = 0.65 + (0.01 × TKP)
TKF = 0.65 + (0.01 × 51)
TKF = 0.65 + 0.51
TKF = 1.16
```

---

## 4. Ayarlanmış İşlev Noktası (İN) Hesabı

```
İN = AİN × TKF
İN = 551 × 1.16
İN = 639.16 ≈ 639
```

---

## 5. Kod Satır Sayısı Tahmini

### 5.1 Dil Bazlı Çarpanlar

| Dil | Satır/İN | Kullanım Oranı |
|-----|----------|----------------|
| C# | 30 | %85 |
| JavaScript | 25 | %10 |
| SQL | 15 | %5 |

### 5.2 Hesaplama

```
C# Satır Sayısı = 639 × 30 × 0.85 = 16,294 satır
JavaScript Satır Sayısı = 639 × 25 × 0.10 = 1,598 satır
SQL Satır Sayısı = 639 × 15 × 0.05 = 479 satır

TOPLAM TAHMİNİ SATIR SAYISI = 18,371 satır
```

---

## 6. Efor Tahmini

### 6.1 COCOMO II Modeli

```
Efor (Adam-Ay) = a × (KLOC)^b × EAF

Parametreler:
- a = 2.94 (Organic model)
- b = 1.10
- KLOC = 18.371
- EAF = 1.0 (varsayılan)

Efor = 2.94 × (18.371)^1.10 × 1.0
Efor = 2.94 × 26.89
Efor = 79.06 Adam-Ay
```

### 6.2 Tek Geliştirici için Süre

```
Süre = Efor / Geliştirici Sayısı
Süre = 79.06 / 1
Süre = 79.06 Ay ≈ 6.6 Yıl (Tam zamanlı)
```

### 6.3 Gerçekçi Tahmin (Üniversite Projesi)

Üniversite projesi olarak, yarı zamanlı çalışma ve öğrenme süreci dahil:

```
Gerçek Geliştirme Süresi: ~4-5 Ay (yarı zamanlı)
Tahmini Çalışma Saati: ~400-500 saat
```

---

## 7. Maliyet Tahmini

### 7.1 Geliştirici Maliyeti

| Parametre | Değer |
|-----------|-------|
| Ortalama Saat Ücreti (Jr. Developer) | 150 TL/saat |
| Toplam Çalışma Saati | 450 saat |
| **Geliştirici Maliyeti** | **67,500 TL** |

### 7.2 Altyapı Maliyeti

| Kalem | Aylık | Süre | Toplam |
|-------|-------|------|--------|
| Plesk Hosting | 200 TL | 5 ay | 1,000 TL |
| Domain | - | 1 yıl | 150 TL |
| SQL Server (Local) | 0 TL | - | 0 TL |
| **Altyapı Toplam** | | | **1,150 TL** |

### 7.3 Yazılım/Araç Maliyeti

| Kalem | Maliyet |
|-------|---------|
| Visual Studio Community | 0 TL (Ücretsiz) |
| DevExpress (Eğitim Lisansı) | 0 TL |
| GitHub | 0 TL (Ücretsiz) |
| **Yazılım Toplam** | **0 TL** |

### 7.4 Toplam Proje Maliyeti

| Kategori | Maliyet |
|----------|---------|
| Geliştirici | 67,500 TL |
| Altyapı | 1,150 TL |
| Yazılım | 0 TL |
| **TOPLAM** | **68,650 TL** |

---

## 8. Özet Tablo

| Metrik | Değer |
|--------|-------|
| Ayarlanmamış İşlev Noktası (AİN) | 551 |
| Teknik Karmaşıklık Faktörü (TKF) | 1.16 |
| Ayarlanmış İşlev Noktası (İN) | 639 |
| Tahmini Kod Satır Sayısı | ~18,371 |
| Tahmini Efor (COCOMO II) | 79 Adam-Ay |
| Gerçek Geliştirme Süresi | ~4-5 Ay |
| Tahmini Toplam Maliyet | 68,650 TL |

---

## 9. Karmaşıklık Değerlendirmesi

### 9.1 Proje Karmaşıklık Seviyesi

```
İN Değeri: 639

Karmaşıklık Skalası:
- 0-100: Basit
- 100-300: Orta
- 300-600: Karmaşık
- 600+: Çok Karmaşık

Sonuç: ÇOK KARMAŞIK PROJE
```

### 9.2 Karmaşıklığı Artıran Faktörler

1. **Dual-Database Mimarisi** - Local SQL Server + Plesk Remote DB
2. **GitHub API Entegrasyonu** - Rate limiting, token pool yönetimi
3. **Akıllı Algoritmalar** - Risk hesaplama, commit-task eşleştirme
4. **E-posta Bildirimleri** - SMTP entegrasyonu
5. **Katmanlı Mimari** - 5 katmanlı enterprise mimari
6. **DevExpress UI** - Profesyonel UI bileşenleri
7. **Kanban Board** - Drag & drop görev yönetimi
8. **Raporlama Sistemi** - Çoklu rapor türleri

---

**Oluşturulma Tarihi:** 6 Ocak 2026  
**Proje:** Project Tracker v1.0
