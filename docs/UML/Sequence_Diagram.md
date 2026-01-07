# Sequence Diyagramı (Sıralı Diyagram)

## Project Tracker - Nesne Etkileşimleri

---

## 1. Genel Bakış

Bu dokümanda sistemdeki temel senaryolar için nesneler arası mesaj akışları gösterilmektedir.

| # | Senaryo | Katılımcılar |
|---|---------|--------------|
| 1 | Kullanıcı Girişi | UI, AuthService, UserRepository, DB |
| 2 | Görev Oluşturma | UI, TaskService, EmailService, DB |
| 3 | Takım Daveti Gönderme | UI, InvitationService, EmailService, RemoteAPI, DB |
| 4 | Davet Kabul (Web) | WebPage, RemoteAPI, PleskDB |
| 5 | GitHub Sync | UI, GitHubSyncService, TokenPoolService, GitHubAPI, DB |
| 6 | Proje Risk Hesaplama | UI, ProjectService, RiskCalculator, DB |

---

## 2. Kullanıcı Girişi (Login)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                         KULLANICI GİRİŞ SEQUENCE                            │
└─────────────────────────────────────────────────────────────────────────────┘

┌─────────┐     ┌─────────────┐     ┌─────────────┐     ┌──────────────┐     ┌────────┐
│FrmLogin │     │ AuthService │     │UserRepository│    │SessionManager│     │   DB   │
└────┬────┘     └──────┬──────┘     └──────┬──────┘     └──────┬───────┘     └───┬────┘
     │                 │                   │                   │                 │
     │ 1. LoginAsync(username, password)   │                   │                 │
     │────────────────>│                   │                   │                 │
     │                 │                   │                   │                 │
     │                 │ 2. GetByUsernameAsync(username)       │                 │
     │                 │──────────────────>│                   │                 │
     │                 │                   │                   │                 │
     │                 │                   │ 3. SELECT * FROM Users              │
     │                 │                   │   WHERE Username = @username        │
     │                 │                   │──────────────────────────────────────>
     │                 │                   │                   │                 │
     │                 │                   │ 4. User Entity    │                 │
     │                 │                   │<──────────────────────────────────────
     │                 │                   │                   │                 │
     │                 │ 5. User (or null) │                   │                 │
     │                 │<──────────────────│                   │                 │
     │                 │                   │                   │                 │
     │                 │ ┌─────────────────────────────────┐   │                 │
     │                 │ │ ALT [User == null]              │   │                 │
     │                 │ │   return null                   │   │                 │
     │                 │ └─────────────────────────────────┘   │                 │
     │                 │                   │                   │                 │
     │                 │ 6. BCrypt.Verify(password, hash)      │                 │
     │                 │──────┐            │                   │                 │
     │                 │      │            │                   │                 │
     │                 │<─────┘            │                   │                 │
     │                 │                   │                   │                 │
     │                 │ ┌─────────────────────────────────┐   │                 │
     │                 │ │ ALT [Password Invalid]          │   │                 │
     │                 │ │   return null                   │   │                 │
     │                 │ └─────────────────────────────────┘   │                 │
     │                 │                   │                   │                 │
     │                 │ ┌─────────────────────────────────┐   │                 │
     │                 │ │ ALT [User.IsActive == false]    │   │                 │
     │                 │ │   return null                   │   │                 │
     │                 │ └─────────────────────────────────┘   │                 │
     │                 │                   │                   │                 │
     │                 │ 7. Login(user)    │                   │                 │
     │                 │───────────────────────────────────────>                 │
     │                 │                   │                   │                 │
     │                 │                   │    8. CurrentUser = user            │
     │                 │                   │                   │──────┐          │
     │                 │                   │                   │      │          │
     │                 │                   │                   │<─────┘          │
     │                 │                   │                   │                 │
     │ 9. UserDto      │                   │                   │                 │
     │<────────────────│                   │                   │                 │
     │                 │                   │                   │                 │
     │ ┌─────────────────────────────────────────────────────────────────────┐  │
     │ │ ALT [RoleId == 4 (Pending)]                                         │  │
     │ │   Show FrmPendingWaitlist                                           │  │
     │ │ ELSE                                                                │  │
     │ │   Show FrmDashboard                                                 │  │
     │ └─────────────────────────────────────────────────────────────────────┘  │
     │                 │                   │                   │                 │
┌────┴────┐     ┌──────┴──────┐     ┌──────┴──────┐     ┌──────┴───────┐     ┌───┴────┐
│FrmLogin │     │ AuthService │     │UserRepository│    │SessionManager│     │   DB   │
└─────────┘     └─────────────┘     └─────────────┘     └──────────────┘     └────────┘
```

---

## 3. Görev Oluşturma ve E-posta Bildirimi

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                      GÖREV OLUŞTURMA SEQUENCE                               │
└─────────────────────────────────────────────────────────────────────────────┘

┌───────────┐   ┌───────────┐   ┌──────────────┐   ┌────────────┐   ┌────────┐
│TaskDetail │   │TaskService│   │TaskRepository│   │EmailService│   │   DB   │
└─────┬─────┘   └─────┬─────┘   └──────┬───────┘   └─────┬──────┘   └───┬────┘
      │               │                │                 │              │
      │ 1. CreateTaskAsync(dto)        │                 │              │
      │──────────────>│                │                 │              │
      │               │                │                 │              │
      │               │ 2. Map DTO → Entity              │              │
      │               │──────┐         │                 │              │
      │               │      │         │                 │              │
      │               │<─────┘         │                 │              │
      │               │                │                 │              │
      │               │ 3. AddAsync(task)                │              │
      │               │───────────────>│                 │              │
      │               │                │                 │              │
      │               │                │ 4. INSERT INTO Tasks           │
      │               │                │────────────────────────────────>
      │               │                │                 │              │
      │               │                │ 5. TaskId       │              │
      │               │                │<────────────────────────────────
      │               │                │                 │              │
      │               │ 6. Task Entity │                 │              │
      │               │<───────────────│                 │              │
      │               │                │                 │              │
      │               │ ┌─────────────────────────────────────────────┐ │
      │               │ │ OPT [AssignedUserId != null]                │ │
      │               │ │                │                 │          │ │
      │               │ │ 7. GetUserAsync(assignedUserId)  │          │ │
      │               │ │───────────────>│                 │          │ │
      │               │ │                │                 │          │ │
      │               │ │ 8. User        │                 │          │ │
      │               │ │<───────────────│                 │          │ │
      │               │ │                │                 │          │ │
      │               │ │ 9. SendTaskAssignmentEmailAsync()│          │ │
      │               │ │ (Fire-and-Forget)                │          │ │
      │               │ │─────────────────────────────────>│          │ │
      │               │ │                │                 │          │ │
      │               │ │                │    10. SMTP Send│          │ │
      │               │ │                │                 │──────┐   │ │
      │               │ │                │                 │      │   │ │
      │               │ │                │                 │<─────┘   │ │
      │               │ └─────────────────────────────────────────────┘ │
      │               │                │                 │              │
      │               │ 11. AuditLog (Fire-and-Forget)    │              │
      │               │───────────────>│                 │              │
      │               │                │                 │              │
      │               │                │ 12. INSERT INTO AuditLog       │
      │               │                │────────────────────────────────>
      │               │                │                 │              │
      │ 13. TaskDto   │                │                 │              │
      │<──────────────│                │                 │              │
      │               │                │                 │              │
┌─────┴─────┐   ┌─────┴─────┐   ┌──────┴───────┐   ┌─────┴──────┐   ┌───┴────┐
│TaskDetail │   │TaskService│   │TaskRepository│   │EmailService│   │   DB   │
└───────────┘   └───────────┘   └──────────────┘   └────────────┘   └────────┘
```

---

## 4. Takım Daveti Gönderme (Dual-Database)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                   TAKIM DAVETİ GÖNDERME SEQUENCE                            │
└─────────────────────────────────────────────────────────────────────────────┘

┌──────────┐  ┌─────────────────┐  ┌────────────┐  ┌─────────────────┐  ┌────────┐  ┌─────────┐
│TeamDetail│  │InvitationService│  │EmailService│  │RemoteInvitation │  │Local DB│  │Plesk DB │
└────┬─────┘  └───────┬─────────┘  └─────┬──────┘  │    Service      │  └───┬────┘  └────┬────┘
     │                │                  │         └────────┬────────┘      │            │
     │ 1. SendInvitationAsync(dto)       │                  │               │            │
     │───────────────>│                  │                  │               │            │
     │                │                  │                  │               │            │
     │                │ 2. Yetki Kontrolü (Owner/Admin/SysAdmin)            │            │
     │                │──────┐           │                  │               │            │
     │                │      │           │                  │               │            │
     │                │<─────┘           │                  │               │            │
     │                │                  │                  │               │            │
     │                │ 3. Mevcut Üye/Davet Kontrolü        │               │            │
     │                │─────────────────────────────────────────────────────>            │
     │                │                  │                  │               │            │
     │                │ 4. Kontrol Sonucu│                  │               │            │
     │                │<─────────────────────────────────────────────────────            │
     │                │                  │                  │               │            │
     │                │ 5. Token = GUID + Ticks             │               │            │
     │                │──────┐           │                  │               │            │
     │                │      │           │                  │               │            │
     │                │<─────┘           │                  │               │            │
     │                │                  │                  │               │            │
     │                │ 6. TeamInvitation Entity Oluştur    │               │            │
     │                │──────┐           │                  │               │            │
     │                │      │           │                  │               │            │
     │                │<─────┘           │                  │               │            │
     │                │                  │                  │               │            │
     │                │ 7. INSERT INTO TeamInvitations      │               │            │
     │                │─────────────────────────────────────────────────────>            │
     │                │                  │                  │               │            │
     │                │ 8. InvitationId  │                  │               │            │
     │                │<─────────────────────────────────────────────────────            │
     │                │                  │                  │               │            │
     │                │ ════════════════════════════════════════════════════════════════ │
     │                │ ║              PARALEL İŞLEMLER (Fire-and-Forget)              ║ │
     │                │ ════════════════════════════════════════════════════════════════ │
     │                │                  │                  │               │            │
     │                │ 9a. SendTeamInvitationEmailAsync()  │               │            │
     │                │─────────────────>│                  │               │            │
     │                │                  │                  │               │            │
     │                │                  │ 10a. SMTP Send   │               │            │
     │                │                  │ (Davet Linki:    │               │            │
     │                │                  │  bilalabic.com/  │               │            │
     │                │                  │  accept-invite   │               │            │
     │                │                  │  ?token=xxx)     │               │            │
     │                │                  │──────┐           │               │            │
     │                │                  │      │           │               │            │
     │                │                  │<─────┘           │               │            │
     │                │                  │                  │               │            │
     │                │ 9b. SendInvitationToRemoteAsync()   │               │            │
     │                │─────────────────────────────────────>               │            │
     │                │                  │                  │               │            │
     │                │                  │    10b. POST /api/invitations/create          │
     │                │                  │                  │───────────────────────────>│
     │                │                  │                  │               │            │
     │                │                  │                  │    11b. INSERT INTO        │
     │                │                  │                  │         Invitations        │
     │                │                  │                  │               │            │
     │                │                  │    12b. { success: true }        │            │
     │                │                  │                  │<───────────────────────────│
     │                │                  │                  │               │            │
     │                │ ════════════════════════════════════════════════════════════════ │
     │                │                  │                  │               │            │
     │ 13. InvitationDto                 │                  │               │            │
     │<───────────────│                  │                  │               │            │
     │                │                  │                  │               │            │
┌────┴─────┐  ┌───────┴─────────┐  ┌─────┴──────┐  ┌────────┴────────┐  ┌───┴────┐  ┌────┴────┐
│TeamDetail│  │InvitationService│  │EmailService│  │RemoteInvitation │  │Local DB│  │Plesk DB │
└──────────┘  └─────────────────┘  └────────────┘  │    Service      │  └────────┘  └─────────┘
                                                   └─────────────────┘
```

---

## 5. Web Üzerinden Davet Kabul (Plesk DB)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                    WEB DAVET KABUL SEQUENCE                                 │
└─────────────────────────────────────────────────────────────────────────────┘

┌───────────────┐     ┌─────────────────────┐     ┌─────────────────┐
│ accept-invite │     │ InvitationsController│    │    Plesk DB     │
│    .html      │     │   (Remote API)       │    │   Invitations   │
└───────┬───────┘     └──────────┬───────────┘    └────────┬────────┘
        │                        │                         │
        │ 1. URL'den token al    │                         │
        │ (URLSearchParams)      │                         │
        │──────┐                 │                         │
        │      │                 │                         │
        │<─────┘                 │                         │
        │                        │                         │
        │ 2. GET /api/invitations/validate?token=xxx       │
        │───────────────────────>│                         │
        │                        │                         │
        │                        │ 3. SELECT * FROM Invitations
        │                        │    WHERE Token = @token │
        │                        │────────────────────────>│
        │                        │                         │
        │                        │ 4. Invitation Record    │
        │                        │<────────────────────────│
        │                        │                         │
        │                        │ 5. Validate:            │
        │                        │    - Status == Pending? │
        │                        │    - ExpiresAt > Now?   │
        │                        │──────┐                  │
        │                        │      │                  │
        │                        │<─────┘                  │
        │                        │                         │
        │ 6. { isValid, teamName, invitedBy, role, expiresAt }
        │<───────────────────────│                         │
        │                        │                         │
        │ 7. Davet Detaylarını   │                         │
        │    Göster              │                         │
        │──────┐                 │                         │
        │      │                 │                         │
        │<─────┘                 │                         │
        │                        │                         │
        │ ┌─────────────────────────────────────────────────────────────────┐
        │ │ ALT [Kullanıcı "Kabul Et" tıklar]                               │
        │ │                      │                         │                │
        │ │ 8. POST /api/invitations/accept                │                │
        │ │    { token: "xxx" }  │                         │                │
        │ │─────────────────────>│                         │                │
        │ │                      │                         │                │
        │ │                      │ 9. UPDATE Invitations   │                │
        │ │                      │    SET Status='Accepted'│                │
        │ │                      │    WHERE Token=@token   │                │
        │ │                      │────────────────────────>│                │
        │ │                      │                         │                │
        │ │                      │ 10. Rows Affected       │                │
        │ │                      │<────────────────────────│                │
        │ │                      │                         │                │
        │ │ 11. { success: true, message: "Davet kabul edildi!" }          │
        │ │<─────────────────────│                         │                │
        │ │                      │                         │                │
        │ │ 12. Başarı Mesajı    │                         │                │
        │ │     Göster           │                         │                │
        │ │     "Uygulamayı      │                         │                │
        │ │     indirip giriş    │                         │                │
        │ │     yapabilirsiniz"  │                         │                │
        │ └─────────────────────────────────────────────────────────────────┘
        │                        │                         │
        │ ┌─────────────────────────────────────────────────────────────────┐
        │ │ ALT [Kullanıcı "Reddet" tıklar]                                 │
        │ │                      │                         │                │
        │ │ 8. POST /api/invitations/decline               │                │
        │ │─────────────────────>│                         │                │
        │ │                      │                         │                │
        │ │                      │ 9. UPDATE Status='Declined'              │
        │ │                      │────────────────────────>│                │
        │ │                      │                         │                │
        │ │ 10. { success: true }│                         │                │
        │ │<─────────────────────│                         │                │
        │ └─────────────────────────────────────────────────────────────────┘
        │                        │                         │
┌───────┴───────┐     ┌──────────┴───────────┐    ┌────────┴────────┐
│ accept-invite │     │ InvitationsController│    │    Plesk DB     │
│    .html      │     │   (Remote API)       │    │   Invitations   │
└───────────────┘     └──────────────────────┘    └─────────────────┘
```


---

## 6. Davetli Kullanıcı Kayıt (Local DB)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                   DAVETLİ KULLANICI KAYIT SEQUENCE                          │
└─────────────────────────────────────────────────────────────────────────────┘

┌───────────┐   ┌───────────┐   ┌──────────────────┐   ┌──────────────┐   ┌────────┐
│FrmRegister│   │AuthService│   │InvitationRepository│  │UserRepository│   │Local DB│
└─────┬─────┘   └─────┬─────┘   └─────────┬────────┘   └──────┬───────┘   └───┬────┘
      │               │                   │                   │               │
      │ 1. RegisterAsync(dto, invitationToken)                │               │
      │──────────────>│                   │                   │               │
      │               │                   │                   │               │
      │               │ 2. Validate (FluentValidation)        │               │
      │               │──────┐            │                   │               │
      │               │      │            │                   │               │
      │               │<─────┘            │                   │               │
      │               │                   │                   │               │
      │               │ 3. Check Username/Email Exists        │               │
      │               │────────────────────────────────────────>               │
      │               │                   │                   │               │
      │               │ 4. null (not exists)                  │               │
      │               │<────────────────────────────────────────               │
      │               │                   │                   │               │
      │               │ ┌─────────────────────────────────────────────────────────────┐
      │               │ │ OPT [invitationToken != null]                               │
      │               │ │                 │                   │               │       │
      │               │ │ 5. GetByTokenAsync(token)           │               │       │
      │               │ │────────────────>│                   │               │       │
      │               │ │                 │                   │               │       │
      │               │ │                 │ 6. SELECT * FROM TeamInvitations  │       │
      │               │ │                 │    WHERE Token = @token           │       │
      │               │ │                 │───────────────────────────────────>       │
      │               │ │                 │                   │               │       │
      │               │ │                 │ 7. TeamInvitation │               │       │
      │               │ │                 │<───────────────────────────────────       │
      │               │ │                 │                   │               │       │
      │               │ │ 8. TeamInvitation                   │               │       │
      │               │ │<────────────────│                   │               │       │
      │               │ │                 │                   │               │       │
      │               │ │ 9. Determine RoleId from ProposedRole:              │       │
      │               │ │    Owner/Admin/PM → RoleId=2 (ProjectManager)       │       │
      │               │ │    Developer     → RoleId=3 (Developer)             │       │
      │               │ │──────┐          │                   │               │       │
      │               │ │      │          │                   │               │       │
      │               │ │<─────┘          │                   │               │       │
      │               │ └─────────────────────────────────────────────────────────────┘
      │               │                   │                   │               │
      │               │ ┌─────────────────────────────────────────────────────────────┐
      │               │ │ ALT [invitationToken == null]                               │
      │               │ │    RoleId = 4 (Pending)             │               │       │
      │               │ └─────────────────────────────────────────────────────────────┘
      │               │                   │                   │               │
      │               │ 10. BCrypt.HashPassword(password)     │               │
      │               │──────┐            │                   │               │
      │               │      │            │                   │               │
      │               │<─────┘            │                   │               │
      │               │                   │                   │               │
      │               │ 11. Create User Entity                │               │
      │               │──────┐            │                   │               │
      │               │      │            │                   │               │
      │               │<─────┘            │                   │               │
      │               │                   │                   │               │
      │               │ 12. AddAsync(user)│                   │               │
      │               │────────────────────────────────────────>               │
      │               │                   │                   │               │
      │               │                   │    13. INSERT INTO Users          │
      │               │                   │                   │───────────────>
      │               │                   │                   │               │
      │               │                   │    14. UserId     │               │
      │               │                   │                   │<───────────────
      │               │                   │                   │               │
      │               │ 15. User Entity   │                   │               │
      │               │<────────────────────────────────────────               │
      │               │                   │                   │               │
      │               │ ┌─────────────────────────────────────────────────────────────┐
      │               │ │ OPT [invitation != null]                                    │
      │               │ │                 │                   │               │       │
      │               │ │ 16. Create TeamMember Entity        │               │       │
      │               │ │     TeamId = invitation.TeamId      │               │       │
      │               │ │     UserId = user.UserId            │               │       │
      │               │ │     Role = invitation.ProposedRole  │               │       │
      │               │ │──────┐          │                   │               │       │
      │               │ │      │          │                   │               │       │
      │               │ │<─────┘          │                   │               │       │
      │               │ │                 │                   │               │       │
      │               │ │ 17. INSERT INTO TeamMembers         │               │       │
      │               │ │─────────────────────────────────────────────────────>       │
      │               │ │                 │                   │               │       │
      │               │ │ 18. Update invitation.Status = Accepted             │       │
      │               │ │────────────────>│                   │               │       │
      │               │ │                 │                   │               │       │
      │               │ │                 │ 19. UPDATE TeamInvitations        │       │
      │               │ │                 │───────────────────────────────────>       │
      │               │ └─────────────────────────────────────────────────────────────┘
      │               │                   │                   │               │
      │ 20. UserDto   │                   │                   │               │
      │<──────────────│                   │                   │               │
      │               │                   │                   │               │
      │ 21. Show "Kayıt Başarılı"         │                   │               │
      │     Navigate to FrmLogin          │                   │               │
      │──────┐        │                   │                   │               │
      │      │        │                   │                   │               │
      │<─────┘        │                   │                   │               │
      │               │                   │                   │               │
┌─────┴─────┐   ┌─────┴─────┐   ┌─────────┴────────┐   ┌──────┴───────┐   ┌───┴────┐
│FrmRegister│   │AuthService│   │InvitationRepository│  │UserRepository│   │Local DB│
└───────────┘   └───────────┘   └──────────────────┘   └──────────────┘   └────────┘
```

---

## 7. GitHub Sync İşlemi

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                        GITHUB SYNC SEQUENCE                                 │
└─────────────────────────────────────────────────────────────────────────────┘

┌─────────────┐  ┌───────────────┐  ┌────────────────┐  ┌──────────┐  ┌────────┐
│GitHubContent│  │GitHubSyncSvc  │  │TokenPoolService│  │GitHub API│  │Local DB│
└──────┬──────┘  └───────┬───────┘  └───────┬────────┘  └────┬─────┘  └───┬────┘
       │                 │                  │                │            │
       │ 1. SyncRepositoryAsync(projectId)  │                │            │
       │────────────────>│                  │                │            │
       │                 │                  │                │            │
       │                 │ 2. GetProject(projectId)          │            │
       │                 │───────────────────────────────────────────────>│
       │                 │                  │                │            │
       │                 │ 3. Project (with GitHubRepoUrl)   │            │
       │                 │<───────────────────────────────────────────────│
       │                 │                  │                │            │
       │                 │ 4. Parse owner/repo from URL      │            │
       │                 │──────┐           │                │            │
       │                 │      │           │                │            │
       │                 │<─────┘           │                │            │
       │                 │                  │                │            │
       │                 │ 5. GetBestTokenAsync()            │            │
       │                 │─────────────────>│                │            │
       │                 │                  │                │            │
       │                 │                  │ 6. SELECT * FROM GitHubTokens
       │                 │                  │    WHERE IsActive = 1       │
       │                 │                  │    ORDER BY RateLimitRemaining DESC
       │                 │                  │────────────────────────────>│
       │                 │                  │                │            │
       │                 │                  │ 7. GitHubToken │            │
       │                 │                  │<────────────────────────────│
       │                 │                  │                │            │
       │                 │                  │ 8. Decrypt Token            │
       │                 │                  │──────┐         │            │
       │                 │                  │      │         │            │
       │                 │                  │<─────┘         │            │
       │                 │                  │                │            │
       │                 │ 9. DecryptedToken│                │            │
       │                 │<─────────────────│                │            │
       │                 │                  │                │            │
       │                 │ 10. GET /repos/{owner}/{repo}/commits          │
       │                 │     Authorization: Bearer {token} │            │
       │                 │──────────────────────────────────>│            │
       │                 │                  │                │            │
       │                 │ 11. Commits[]    │                │            │
       │                 │<──────────────────────────────────│            │
       │                 │                  │                │            │
       │                 │ ┌─────────────────────────────────────────────────────────┐
       │                 │ │ LOOP [for each commit]                                  │
       │                 │ │                │                │            │          │
       │                 │ │ 12. GET /repos/{owner}/{repo}/commits/{sha}  │          │
       │                 │ │──────────────────────────────────>           │          │
       │                 │ │                │                │            │          │
       │                 │ │ 13. CommitDetail (files, stats) │            │          │
       │                 │ │<──────────────────────────────────           │          │
       │                 │ │                │                │            │          │
       │                 │ │ 14. Create GitCommit Entity     │            │          │
       │                 │ │──────┐         │                │            │          │
       │                 │ │      │         │                │            │          │
       │                 │ │<─────┘         │                │            │          │
       │                 │ │                │                │            │          │
       │                 │ │ 15. TaskMatchingService.MatchCommitToTask()  │          │
       │                 │ │     (Commit message → Task matching)         │          │
       │                 │ │──────┐         │                │            │          │
       │                 │ │      │         │                │            │          │
       │                 │ │<─────┘         │                │            │          │
       │                 │ │                │                │            │          │
       │                 │ │ 16. Create GitFileChange Entities            │          │
       │                 │ │──────┐         │                │            │          │
       │                 │ │      │         │                │            │          │
       │                 │ │<─────┘         │                │            │          │
       │                 │ └─────────────────────────────────────────────────────────┘
       │                 │                  │                │            │
       │                 │ 17. Update GitRepository Entity   │            │
       │                 │     (LastSyncAt, TotalCommits, etc.)           │
       │                 │──────┐           │                │            │
       │                 │      │           │                │            │
       │                 │<─────┘           │                │            │
       │                 │                  │                │            │
       │                 │ 18. SaveChangesAsync()            │            │
       │                 │───────────────────────────────────────────────>│
       │                 │                  │                │            │
       │                 │ 19. UpdateTokenRateLimit()        │            │
       │                 │─────────────────>│                │            │
       │                 │                  │                │            │
       │                 │                  │ 20. UPDATE GitHubTokens     │
       │                 │                  │     SET RateLimitRemaining  │
       │                 │                  │────────────────────────────>│
       │                 │                  │                │            │
       │ 21. SyncResult  │                  │                │            │
       │<────────────────│                  │                │            │
       │                 │                  │                │            │
       │ 22. Refresh UI  │                  │                │            │
       │     (Commits, Analytics)           │                │            │
       │──────┐          │                  │                │            │
       │      │          │                  │                │            │
       │<─────┘          │                  │                │            │
       │                 │                  │                │            │
┌──────┴──────┐  ┌───────┴───────┐  ┌───────┴────────┐  ┌────┴─────┐  ┌───┴────┐
│GitHubContent│  │GitHubSyncSvc  │  │TokenPoolService│  │GitHub API│  │Local DB│
└─────────────┘  └───────────────┘  └────────────────┘  └──────────┘  └────────┘
```

---

## 8. Görev Durumu Değiştirme (E-posta ile)

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                   GÖREV DURUMU DEĞİŞTİRME SEQUENCE                          │
└─────────────────────────────────────────────────────────────────────────────┘

┌───────────┐   ┌───────────┐   ┌──────────────┐   ┌────────────┐   ┌────────┐
│KanbanView │   │TaskService│   │TaskRepository│   │EmailService│   │   DB   │
└─────┬─────┘   └─────┬─────┘   └──────┬───────┘   └─────┬──────┘   └───┬────┘
      │               │                │                 │              │
      │ 1. Drag & Drop Task            │                 │              │
      │    (Pending → InProgress)      │                 │              │
      │──────┐        │                │                 │              │
      │      │        │                │                 │              │
      │<─────┘        │                │                 │              │
      │               │                │                 │              │
      │ 2. UpdateTaskStatusAsync(taskId, newStatus)      │              │
      │──────────────>│                │                 │              │
      │               │                │                 │              │
      │               │ 3. GetByIdAsync(taskId)          │              │
      │               │───────────────>│                 │              │
      │               │                │                 │              │
      │               │                │ 4. SELECT * FROM Tasks         │
      │               │                │────────────────────────────────>
      │               │                │                 │              │
      │               │                │ 5. Task Entity  │              │
      │               │                │<────────────────────────────────
      │               │                │                 │              │
      │               │ 6. Task        │                 │              │
      │               │<───────────────│                 │              │
      │               │                │                 │              │
      │               │ 7. oldStatus = task.Status       │              │
      │               │──────┐         │                 │              │
      │               │      │         │                 │              │
      │               │<─────┘         │                 │              │
      │               │                │                 │              │
      │               │ 8. task.Status = newStatus       │              │
      │               │──────┐         │                 │              │
      │               │      │         │                 │              │
      │               │<─────┘         │                 │              │
      │               │                │                 │              │
      │               │ 9. Update(task)│                 │              │
      │               │───────────────>│                 │              │
      │               │                │                 │              │
      │               │                │ 10. UPDATE Tasks                │
      │               │                │────────────────────────────────>
      │               │                │                 │              │
      │               │ ┌─────────────────────────────────────────────┐ │
      │               │ │ OPT [oldStatus != newStatus && AssignedUser]│ │
      │               │ │              │                 │            │ │
      │               │ │ 11. SendTaskStatusUpdateEmailAsync()        │ │
      │               │ │ (Fire-and-Forget)              │            │ │
      │               │ │─────────────────────────────────>           │ │
      │               │ │              │                 │            │ │
      │               │ │              │    12. SMTP Send│            │ │
      │               │ │              │    Subject: "Görev Durumu    │ │
      │               │ │              │    Değişti"     │            │ │
      │               │ │              │    Body:        │            │ │
      │               │ │              │    - Task Name  │            │ │
      │               │ │              │    - Old Status │            │ │
      │               │ │              │    - New Status │            │ │
      │               │ │              │                 │──────┐     │ │
      │               │ │              │                 │      │     │ │
      │               │ │              │                 │<─────┘     │ │
      │               │ └─────────────────────────────────────────────┘ │
      │               │                │                 │              │
      │               │ 13. AuditLog (TaskStatusChanged) │              │
      │               │───────────────>│                 │              │
      │               │                │                 │              │
      │               │                │ 14. INSERT INTO AuditLog       │
      │               │                │────────────────────────────────>
      │               │                │                 │              │
      │ 15. Success   │                │                 │              │
      │<──────────────│                │                 │              │
      │               │                │                 │              │
      │ 16. Refresh Kanban Board       │                 │              │
      │──────┐        │                │                 │              │
      │      │        │                │                 │              │
      │<─────┘        │                │                 │              │
      │               │                │                 │              │
┌─────┴─────┐   ┌─────┴─────┐   ┌──────┴───────┐   ┌─────┴──────┐   ┌───┴────┐
│KanbanView │   │TaskService│   │TaskRepository│   │EmailService│   │   DB   │
└───────────┘   └───────────┘   └──────────────┘   └────────────┘   └────────┘
```

---

## 9. Özet Tablo

| # | Senaryo | Katılımcı Sayısı | Asenkron İşlem | E-posta |
|---|---------|------------------|----------------|---------|
| 1 | Kullanıcı Girişi | 5 | ❌ | ❌ |
| 2 | Görev Oluşturma | 5 | ✅ (Email, AuditLog) | ✅ |
| 3 | Takım Daveti Gönderme | 6 | ✅ (Email, RemoteAPI) | ✅ |
| 4 | Web Davet Kabul | 3 | ❌ | ❌ |
| 5 | Davetli Kayıt | 5 | ❌ | ❌ |
| 6 | GitHub Sync | 5 | ❌ | ❌ |
| 7 | Görev Durumu Değiştirme | 5 | ✅ (Email, AuditLog) | ✅ |

---

## 10. Notasyon Açıklaması

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                         SEQUENCE DİYAGRAM NOTASYONU                         │
└─────────────────────────────────────────────────────────────────────────────┘

Sembol          Açıklama
──────          ────────
─────────>      Senkron mesaj (çağrı)
<─────────      Dönüş mesajı
──────┐         Self-call (kendi kendine çağrı)
      │
<─────┘

┌─────────────────────────────────────────────────────────────────────────────┐
│ ALT [koşul]                                                                 │
│   Alternatif akış (if-else)                                                 │
└─────────────────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────────────────┐
│ OPT [koşul]                                                                 │
│   Opsiyonel akış (if)                                                       │
└─────────────────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────────────────┐
│ LOOP [koşul]                                                                │
│   Döngü                                                                     │
└─────────────────────────────────────────────────────────────────────────────┘

════════════════════════════════════════════════════════════════════════════════
║ PARALEL İŞLEMLER                                                            ║
════════════════════════════════════════════════════════════════════════════════
  Eş zamanlı çalışan işlemler (Fire-and-Forget)
```

---

**Oluşturulma Tarihi:** 6 Ocak 2026  
**Proje:** Project Tracker v1.0
