# 📘 PHASE 5: ADVANCED TEAM MANAGEMENT SYSTEM - COMPLETE GUIDE

**Multi-Team Workspace, Invitation System, Role Management**

Bu README, Phase 5'in (Advanced Team Management) nasıl implement edileceğini **adım adım** ve **hiçbir detayı atlamadan** açıklar.

---

## 📋 İÇİNDEKİLER

1. [Genel Bakış](#genel-bakış)
2. [Modül Mimarisi](#modül-mimarisi)
3. [Implementation Sırası](#implementation-sırası)
4. [Entity Layer](#entity-layer)
5. [Service Layer](#service-layer)
6. [UI Layer](#ui-layer)
7. [Test Senaryoları](#test-senaryoları)
8. [Troubleshooting](#troubleshooting)

---

## 🎯 GENEL BAKIŞ

### **Ne Yapacağız?**

Phase 5'te **Advanced Team Management System** oluşturacağız:

✅ **Multi-Team Support:** Birden fazla takım oluşturma  
✅ **Davet Sistemi:** Email ile takıma davet gönderme  
✅ **Role Management:** Granular rol yönetimi (Owner, Admin, PM, Dev, Observer)  
✅ **Team Switching:** Aktif takım değiştirme  
✅ **Team-Project İlişkisi:** Projeler takımlara ait  
✅ **Invitation Tracking:** Davet durumu izleme  

---

## 🏗️ MODÜL MİMARİSİ

```
Phase 5: Advanced Team Management
│
├── Entity Layer (ProjectTracker.Core)
│   ├── Entities/
│   │   ├── Team.cs                    [YENİ]
│   │   ├── TeamMember.cs              [YENİ]
│   │   ├── TeamInvitation.cs          [YENİ]
│   │   ├── Project.cs                 [GÜNCELLE - TeamId ekle]
│   │   └── User.cs                    [GÜNCELLE - Team navigation]
│   └── Enums/
│       ├── TeamRole.cs                [YENİ]
│       └── InvitationStatus.cs        [YENİ]
│
├── Data Layer (ProjectTracker.Data)
│   ├── Context/
│   │   └── AppDbContext.cs            [GÜNCELLE]
│   ├── Repositories/
│   │   ├── TeamRepository.cs          [YENİ]
│   │   └── InvitationRepository.cs    [YENİ]
│   └── Migrations/
│       └── AddTeamManagement.cs       [YENİ]
│
├── Business Layer (ProjectTracker.Business)
│   ├── DTOs/
│   │   ├── TeamDto.cs                 [YENİ]
│   │   ├── TeamMemberDto.cs           [YENİ]
│   │   └── TeamInvitationDto.cs       [YENİ]
│   ├── Interfaces/
│   │   ├── ITeamService.cs            [YENİ]
│   │   └── IInvitationService.cs      [YENİ]
│   └── Services/
│       ├── TeamService.cs             [YENİ]
│       └── InvitationService.cs       [YENİ]
│
└── UI Layer (ProjectTracker.UI)
    └── Forms/Dashboard/Content/
        ├── TeamsContent.cs            [Phase 5.1]
        ├── TeamDetailControl.cs       [Phase 5.2]
        ├── InvitationsContent.cs      [Phase 5.3]
        └── TeamMembersContent.cs      [Phase 5.4]
```

---

## 🚀 IMPLEMENTATION SIRASI

### **1. Entity Layer (1-2 saat)**

#### **Adım 1.1: Yeni Entity'leri Oluştur**

**PHASE5_ENTITIES.md** dosyasını aç ve şu entity'leri oluştur:

1. **Team.cs** → `Core/Entities/Team.cs`
2. **TeamMember.cs** → `Core/Entities/TeamMember.cs`
3. **TeamInvitation.cs** → `Core/Entities/TeamInvitation.cs`
4. **TeamRole.cs** → `Core/Enums/TeamRole.cs`
5. **InvitationStatus.cs** → `Core/Enums/InvitationStatus.cs`

#### **Adım 1.2: Mevcut Entity'leri Güncelle**

**Project.cs:**
```csharp
public int TeamId { get; set; }  // EKLE
public virtual Team Team { get; set; } = null!;  // EKLE
```

**User.cs:**
```csharp
public virtual ICollection<Team> OwnedTeams { get; set; } = new List<Team>();  // EKLE
public virtual ICollection<TeamMember> TeamMemberships { get; set; } = new List<TeamMember>();  // EKLE
public virtual ICollection<TeamInvitation> SentInvitations { get; set; } = new List<TeamInvitation>();  // EKLE
```

---

### **2. Data Layer (1 saat)**

#### **Adım 2.1: DbContext Güncelle**

**AppDbContext.cs:**

```csharp
public DbSet<Team> Teams { get; set; }
public DbSet<TeamMember> TeamMembers { get; set; }
public DbSet<TeamInvitation> TeamInvitations { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    
    // Team configurations
    modelBuilder.Entity<Team>()
        .HasMany(t => t.Members)
        .WithOne(m => m.Team)
        .HasForeignKey(m => m.TeamId)
        .OnDelete(DeleteBehavior.Cascade);
    
    modelBuilder.Entity<Team>()
        .HasMany(t => t.Projects)
        .WithOne(p => p.Team)
        .HasForeignKey(p => p.TeamId)
        .OnDelete(DeleteBehavior.Restrict);
    
    // Indexes
    modelBuilder.Entity<TeamInvitation>()
        .HasIndex(i => i.Token)
        .IsUnique();
    
    modelBuilder.Entity<TeamInvitation>()
        .HasIndex(i => i.Email);
}
```

#### **Adım 2.2: Migration Oluştur**

```bash
Add-Migration AddTeamManagementSystem
Update-Database
```

---

### **3. Business Layer (2-3 saat)**

#### **Adım 3.1: DTO'ları Oluştur**

PHASE5_ENTITIES.md'den kopyala:
- `TeamDto.cs`
- `TeamMemberDto.cs`
- `TeamInvitationDto.cs`

#### **Adım 3.2: Service Interface'leri Oluştur**

**ITeamService.cs:**

```csharp
public interface ITeamService
{
    Task<IEnumerable<TeamDto>> GetUserTeamsAsync();
    Task<TeamDto?> GetActiveTeamAsync();
    Task<TeamDto?> GetTeamByIdAsync(int teamId);
    Task<TeamDto> CreateTeamAsync(TeamDto teamDto);
    Task<TeamDto> UpdateTeamAsync(TeamDto teamDto);
    Task<bool> DeleteTeamAsync(int teamId);
    Task SetActiveTeamAsync(int teamId);
    Task<IEnumerable<TeamMemberDto>> GetTeamMembersAsync(int teamId);
    Task<bool> UpdateMemberRoleAsync(int teamMemberId, TeamRole newRole);
    Task<bool> RemoveMemberAsync(int teamMemberId);
}
```

**IInvitationService.cs:**

```csharp
public interface IInvitationService
{
    Task<TeamInvitationDto> SendInvitationAsync(TeamInvitationDto invitationDto);
    Task<IEnumerable<TeamInvitationDto>> GetTeamInvitationsAsync(int teamId);
    Task<bool> ResendInvitationAsync(int invitationId);
    Task<bool> CancelInvitationAsync(int invitationId);
    Task<bool> AcceptInvitationAsync(string token);
    Task<bool> DeclineInvitationAsync(string token);
}
```

#### **Adım 3.3: Service Implementation**

**TeamService.cs** ve **InvitationService.cs** oluştur (business logic).

---

### **4. UI Layer (8-10 saat)**

#### **Phase 5.1: TeamsContent (2 saat)**

**UI_DASHBOARD_PHASE5.1.md** açve adım adım takip et:

1. ✅ UserControl oluştur: `TeamsContent.cs`
2. ✅ Header (Title, Subtitle, Create Button)
3. ✅ Active Team Switcher (LookUpEdit)
4. ✅ Search bar
5. ✅ Team cards (FlowLayoutPanel ile dinamik)
6. ✅ Footer (Record count, Refresh)
7. ✅ Code-behind (650+ satır)

**Test:** Teams listesi görünüyor mu, switching çalışıyor mu?

---

#### **Phase 5.2: TeamDetailControl (1.5 saat)**

**UI_DASHBOARD_PHASE5.2.md** açveriyle devam et:

1. ✅ UserControl: `TeamDetailControl.cs`
2. ✅ Header (Back, Title)
3. ✅ Team Info Group (Name, Description)
4. ✅ Statistics Group (edit modda)
5. ✅ Save/Cancel/Delete buttons
6. ✅ Code-behind (validation, CRUD)

**Test:** Create/Edit/Delete çalışıyor mu?

---

#### **Phase 5.3: InvitationsContent (2 saat)**

**UI_DASHBOARD_PHASE5.3.md** açıp implement et:

1. ✅ UserControl: `InvitationsContent.cs`
2. ✅ Header
3. ✅ Send Invitation Form (Email, Role, Send button)
4. ✅ Invitations List (FlowLayout)
5. ✅ Invitation cards (Pending, Accepted, Declined, Expired)
6. ✅ Actions (Copy Link, Resend, Cancel)
7. ✅ Code-behind (email sending, token generation)

**Test:** Davet gönderme, copy link, resend, cancel çalışıyor mu?

---

#### **Phase 5.4: TeamMembersContent (1.5 saat)**

**UI_DASHBOARD_PHASE5.4.md** açınve finalize et:

1. ✅ UserControl: `TeamMembersContent.cs`
2. ✅ Header, Filter Bar
3. ✅ GridControl (Members grid)
4. ✅ Inline Role Editor (ComboBoxEdit column)
5. ✅ Actions (Edit, Remove)
6. ✅ Code-behind (role update, custom drawing)

**Test:** Member listesi, role değiştirme, filtreleme çalışıyor mu?

---

## ✅ TEST SENARYOLARI

### **Test Group 1: Team Creation & Management**

| # | Test | Beklenen | ✓ |
|---|------|----------|---|
| 1 | "+ Create Team" butonuna tıkla | TeamDetailControl açılıyor | ☐ |
| 2 | Team adı boş bırak, kaydet | "Team name is required" hatası | ☐ |
| 3 | Geçerli team oluştur | "Team created successfully" | ☐ |
| 4 | Teams listesinde yeni team görünsün | Görünüyor | ☐ |
| 5 | Team kartında "Settings" tıkla | Edit mode açılıyor | ☐ |
| 6 | Team adını güncelle | "Team updated successfully" | ☐ |
| 7 | "Delete Team" tıkla | Confirmation dialog gösteriliyor | ☐ |
| 8 | Delete onaylama sonucu | Team silindi, listeye döndü | ☐ |

---

### **Test Group 2: Team Switching**

| # | Test | Beklenen | ✓ |
|---|------|----------|---|
| 1 | Active Team dropdown'ını aç | Tüm teamler listeleniyor | ☐ |
| 2 | Farklı team seç | "Team switched successfully" | ☐ |
| 3 | Dashboard reload oldu mu | Yeni team context'i yüklendi | ☐ |
| 4 | Projeler yeni team'e ait mi | Sadece yeni team projeleri görünüyor | ☐ |
| 5 | Team kartında "Switch" | Aynı sonuç | ☐ |

---

### **Test Group 3: Invitations**

| # | Test | Beklenen | ✓ |
|---|------|----------|---|
| 1 | Invitations sayfasını aç | Pending invitations yüklendi | ☐ |
| 2 | Email boş bırak, send tıkla | "Email is required" | ☐ |
| 3 | Geçersiz email gir | "Invalid email format" | ☐ |
| 4 | Geçerli email + role, send | "Invitation sent" | ☐ |
| 5 | Invitation kartı göründü mü | Pending status ile görünüyor | ☐ |
| 6 | "Copy Link" tıkla | Link clipboard'a kopyalandı | ☐ |
| 7 | "Resend" tıkla | "Invitation resent successfully" | ☐ |
| 8 | "Cancel" tıkla → Yes | "Invitation cancelled" | ☐ |

---

### **Test Group 4: Team Members**

| # | Test | Beklenen | ✓ |
|---|------|----------|---|
| 1 | Team Members sayfası aç | Member listesi yüklendi | ☐ |
| 2 | Search box'a isim yaz | Filtreleme çalışıyor | ☐ |
| 3 | Role filter'da "Developer" seç | Sadece Developer'lar görünüyor | ☐ |
| 4 | Bir member'ın role dropdown'ını değiştir | "Role updated successfully" | ☐ |
| 5 | Initials badge'leri görünüyor mu | Her member için renkli badge var | ☐ |
| 6 | Role renkleri doğru mu | Owner=Blue, Admin=Purple vb. | ☐ |

---

## 🐛 TROUBLESHOOTING

### **Hata 1: "Cannot add or update a child row: foreign key constraint fails"**

**Sebep:** TeamId foreign key eksik veya yanlış.

**Çözüm:**
1. Migration doğru çalıştı mı kontrol et
2. `Update-Database` tekrar çalıştır
3. Project entity'de TeamId var mı kontrol et

---

### **Hata 2: "Object reference not set to an instance of an object" (Active Team null)**

**Sebep:** Kullanıcının hiç team'i yok veya aktif team set edilmemiş.

**Çözüm:**
```csharp
var activeTeam = await _teamService.GetActiveTeamAsync();
if (activeTeam == null)
{
    // Kullanıcının ilk team'ini aktif yap
    var firstTeam = (await _teamService.GetUserTeamsAsync()).FirstOrDefault();
    if (firstTeam != null)
        await _teamService.SetActiveTeamAsync(firstTeam.TeamId);
}
```

---

### **Hata 3: Invitation email gönderilmiyor**

**Sebep:** Email service yapılandırması eksik.

**Çözüm:**
appsettings.json'a SMTP ayarlarını ekle:
```json
{
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "SenderEmail": "noreply@yourapp.com",
    "SenderPassword": "your-app-password",
    "UseSsl": true
  }
}
```

---

### **Hata 4: Team kartları grid'de overlap oluyor**

**Sebep:** FlowLayoutPanel padding/margin ayarları yanlış.

**Çözüm:**
```csharp
flowTeamCards.Padding = new Padding(0);
// Her kart oluştururken:
card.Margin = new Padding(0, 0, 15, 15);
```

---

### **Hata 5: "Team deleted but projects still exist"**

**Sebep:** Cascade delete yapılandırması yanlış.

**Çözüm:**
```csharp
// DbContext'te:
modelBuilder.Entity<Team>()
    .HasMany(t => t.Projects)
    .WithOne(p => p.Team)
    .OnDelete(DeleteBehavior.Cascade);  // Restrict yerine Cascade
```

---

## 📚 İLGİLİ DOKÜMANTASYON

- **[PHASE5_ENTITIES.md](./PHASE5_ENTITIES.md)** - Entity architecture
- **[UI_DASHBOARD_PHASE5.1.md](./UI_DASHBOARD_PHASE5.1.md)** - Teams List
- **[UI_DASHBOARD_PHASE5.2.md](./UI_DASHBOARD_PHASE5.2.md)** - Team Detail
- **[UI_DASHBOARD_PHASE5.3.md](./UI_DASHBOARD_PHASE5.3.md)** - Invitations
- **[UI_DASHBOARD_PHASE5.4.md](./UI_DASHBOARD_PHASE5.4.md)** - Team Members
- **[CODING_STANDARDS.md](./CODING_STANDARDS.md)** - Kod standartları

---

## 🎯 CHECKPOINT: PHASE 5 TAMAMLANDI MI?

### **Entity Layer**
- [ ] Team.cs oluşturuldu
- [ ] TeamMember.cs oluşturuldu
- [ ] TeamInvitation.cs oluşturuldu
- [ ] TeamRole enum oluşturuldu
- [ ] InvitationStatus enum oluşturuldu
- [ ] Project.cs güncellendi (TeamId)
- [ ] User.cs güncellendi (Team navigation)

### **Data Layer**
- [ ] AppDbContext güncellendi
- [ ] Migration oluşturuldu ve çalıştırıldı
- [ ] Foreign key constraints doğru
- [ ] Indexes eklendi

### **Business Layer**
- [ ] TeamDto oluşturuldu
- [ ] TeamMemberDto oluşturuldu
- [ ] TeamInvitationDto oluşturuldu
- [ ] ITeamService interface oluşturuldu
- [ ] IInvitationService interface oluşturuldu
- [ ] TeamService implementasyonu tamamlandı
- [ ] InvitationService implementasyonu tamamlandı

### **UI Layer**
- [ ] TeamsContent oluşturuldu (Phase 5.1)
- [ ] TeamDetailControl oluşturuldu (Phase 5.2)
- [ ] InvitationsContent oluşturuldu (Phase 5.3)
- [ ] TeamMembersContent oluşturuldu (Phase 5.4)
- [ ] Tüm kontroller DI'a kaydedildi
- [ ] FrmDashboard entegrasyonu yapıldı

### **Fonksiyonellik**
- [ ] Team oluşturma çalışıyor
- [ ] Team düzenleme çalışıyor
- [ ] Team silme çalışıyor
- [ ] Team switching çalışıyor
- [ ] Invitation gönderme çalışıyor
- [ ] Invitation resend/cancel çalışıyor
- [ ] Member role güncelleme çalışıyor
- [ ] Tüm validationlar çalışıyor

### **Test**
- [ ] 32 test senaryosu başarılı
- [ ] Build başarılı (0 error)
- [ ] Runtime'da crash yok
- [ ] Database migration başarılı

---

## 🎉 TEBRİKLER!

Phase 5'i başarıyla tamamladınız! Artık:

✅ Multi-team workspace sistemi  
✅ Email davet sistemi  
✅ Granular role management  
✅ Team switching  
✅ Team-project isolation  

özellikleri çalışır durumda!

**Sırada:** Reports modülü (Phase 6) veya Dashboard enhancements 🚀

---

**Prepared by:** AI Assistant  
**Date:** 29 Aralık 2024  
**Project:** ProjectTracker - Advanced Team Management System  
**Phase:** 5 - Complete Implementation Guide
