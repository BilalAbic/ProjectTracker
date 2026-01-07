# Class Diyagramı (Sınıf Diyagramı)

## Project Tracker - Entity Sınıfları

---

## 1. Genel Bakış

| Kategori | Sınıf Sayısı |
|----------|--------------|
| Ana Entity'ler | 10 |
| GitHub Entity'leri | 4 |
| Destek Entity'leri | 4 |
| Enum'lar | 7 |
| **Toplam** | **25** |

---

## 2. Class Diyagramı (ASCII)

```
┌─────────────────────────────────────────────────────────────────────────────────────┐
│                              CORE LAYER - ENTITIES                                   │
└─────────────────────────────────────────────────────────────────────────────────────┘

┌──────────────────────────┐         ┌──────────────────────────┐
│          Role            │         │          User            │
├──────────────────────────┤         ├──────────────────────────┤
│ - RoleId: int [PK]       │    1    │ - UserId: int [PK]       │
│ - RoleName: string       │◄────────│ - RoleId: int [FK]       │
│ - Description: string?   │    *    │ - Username: string       │
├──────────────────────────┤         │ - PasswordHash: string   │
│ + Users: ICollection     │         │ - FullName: string       │
└──────────────────────────┘         │ - Email: string          │
                                     │ - IsActive: bool         │
                                     │ - HourlyCost: decimal?   │
                                     │ - Department: string?    │
                                     │ - GitHubUsername: string?│
                                     │ - GitHubAvatarUrl: string?│
                                     │ - CreatedAt: DateTime    │
                                     ├──────────────────────────┤
                                     │ + Role: Role             │
                                     │ + CreatedProjects: ICol  │
                                     │ + AssignedTasks: ICol    │
                                     │ + OwnedTeams: ICol       │
                                     │ + TeamMemberships: ICol  │
                                     │ + Notifications: ICol    │
                                     │ + GitHubTokens: ICol     │
                                     └────────────┬─────────────┘
                                                  │
                    ┌─────────────────────────────┼─────────────────────────────┐
                    │                             │                             │
                    ▼                             ▼                             ▼
┌──────────────────────────┐   ┌──────────────────────────┐   ┌──────────────────────────┐
│          Team            │   │       GitHubToken        │   │      Notification        │
├──────────────────────────┤   ├──────────────────────────┤   ├──────────────────────────┤
│ - TeamId: int [PK]       │   │ - GitHubTokenId: int [PK]│   │ - NotificationId: int[PK]│
│ - TeamName: string       │   │ - UserId: int [FK]       │   │ - UserId: int [FK]       │
│ - Description: string?   │   │ - EncryptedToken: string │   │ - Title: string          │
│ - OwnerId: int [FK]      │   │ - GitHubUsername: string?│   │ - Message: string        │
│ - IsActive: bool         │   │ - RateLimitRemaining: int│   │ - Type: string           │
│ - CreatedAt: DateTime    │   │ - RateLimitResetAt: DT?  │   │ - IsRead: bool           │
│ - UpdatedAt: DateTime?   │   │ - IsActive: bool         │   │ - CreatedAt: DateTime    │
├──────────────────────────┤   │ - LastUsedAt: DateTime?  │   ├──────────────────────────┤
│ + Owner: User            │   │ - CreatedAt: DateTime    │   │ + User: User             │
│ + Members: ICollection   │   ├──────────────────────────┤   └──────────────────────────┘
│ + Projects: ICollection  │   │ + User: User             │
│ + Invitations: ICol      │   └──────────────────────────┘
└────────────┬─────────────┘
             │
    ┌────────┴────────┐
    │                 │
    ▼                 ▼
┌──────────────────────────┐   ┌──────────────────────────┐
│       TeamMember         │   │     TeamInvitation       │
├──────────────────────────┤   ├──────────────────────────┤
│ - TeamMemberId: int [PK] │   │ - InvitationId: int [PK] │
│ - TeamId: int [FK]       │   │ - TeamId: int [FK]       │
│ - UserId: int [FK]       │   │ - Email: string          │
│ - Role: TeamRole         │   │ - InvitedByUserId: int   │
│ - JoinedAt: DateTime     │   │ - ProposedRole: TeamRole │
│ - IsActive: bool         │   │ - Status: InvitationStat │
├──────────────────────────┤   │ - Token: string          │
│ + Team: Team             │   │ - SentAt: DateTime       │
│ + User: User             │   │ - ExpiresAt: DateTime    │
└──────────────────────────┘   │ - RespondedAt: DateTime? │
                               ├──────────────────────────┤
                               │ + Team: Team             │
                               │ + InvitedBy: User        │
                               └──────────────────────────┘

┌──────────────────────────┐
│         Project          │
├──────────────────────────┤
│ - ProjectId: int [PK]    │
│ - CreatedByUserId: int   │
│ - TeamId: int [FK]       │
│ - ProjectName: string    │
│ - Description: string?   │
│ - StartDate: DateTime    │
│ - EndDate: DateTime?     │
│ - Budget: decimal?       │
│ - Status: string         │
│ - Priority: Priority     │
│ - CompletionPercentage   │
│ - RiskScore: decimal?    │
│ - ActualCost: decimal    │
│ - TotalPlannedHours: dec?│
│ - GitHubRepoUrl: string? │
│ - CreatedAt: DateTime    │
│ - UpdatedAt: DateTime?   │
├──────────────────────────┤
│ + CreatedByUser: User    │
│ + Team: Team             │
│ + Tasks: ICollection     │
│ + TeamMembers: ICol      │
│ + Risks: ICollection     │
│ + Snapshots: ICollection │
│ + GitRepository: GitRepo?│
└────────────┬─────────────┘
             │
    ┌────────┼────────┬─────────────────┐
    │        │        │                 │
    ▼        ▼        ▼                 ▼
┌────────────────┐ ┌────────────────┐ ┌────────────────┐ ┌────────────────┐
│     Task       │ │  ProjectRisk   │ │ProjectSnapshot │ │ GitRepository  │
├────────────────┤ ├────────────────┤ ├────────────────┤ ├────────────────┤
│-TaskId [PK]    │ │-RiskId [PK]    │ │-SnapshotId [PK]│ │-GitRepoId [PK] │
│-ProjectId [FK] │ │-ProjectId [FK] │ │-ProjectId [FK] │ │-ProjectId [FK] │
│-AssignedToUser │ │-RiskScore      │ │-SnapshotDate   │ │-RepoUrl        │
│-ParentTaskId?  │ │-RiskLevel      │ │-OpenTasksCount │ │-RepoOwner      │
│-TaskName       │ │-RiskFactors?   │ │-CompletedTasks │ │-RepoName       │
│-Description?   │ │-Recommendations│ │-RemainingHours │ │-DefaultBranch  │
│-Priority       │ │-AnalyzedAt     │ │-IdealRemaining │ │-IsPrivate      │
│-Status         │ ├────────────────┤ │-BurnedBudget   │ │-LastSyncAt?    │
│-EstimatedHours?│ │+Project        │ │-PlannedValue   │ │-SyncStatus     │
│-ActualHours?   │ └────────────────┘ │-EarnedValue    │ │-TotalCommits   │
│-StartDate?     │                    │-CreatedAt      │ │-TotalBranches  │
│-DueDate?       │                    ├────────────────┤ │-TotalContrib   │
│-CompletedDate? │                    │+Project        │ │-OpenIssues     │
│-IsCriticalPath │                    └────────────────┘ │-CreatedAt      │
│-CreatedAt      │                                       ├────────────────┤
├────────────────┤                                       │+Project        │
│+Project        │                                       │+Commits: ICol  │
│+AssignedToUser?│                                       └───────┬────────┘
│+Comments: ICol │                                               │
│+TimeEntries    │                                               ▼
│+LinkedCommits  │                                       ┌────────────────┐
└───────┬────────┘                                       │   GitCommit    │
        │                                                ├────────────────┤
   ┌────┴────┐                                           │-GitCommitId[PK]│
   │         │                                           │-GitRepoId [FK] │
   ▼         ▼                                           │-Sha            │
┌────────────────┐ ┌────────────────┐                    │-Message?       │
│  TaskComment   │ │   TimeEntry    │                    │-AuthorName?    │
├────────────────┤ ├────────────────┤                    │-AuthorEmail?   │
│-CommentId [PK] │ │-TimeEntryId[PK]│                    │-AuthorGHUser?  │
│-TaskId [FK]    │ │-UserId [FK]    │                    │-AuthorAvatar?  │
│-UserId [FK]    │ │-TaskId [FK]    │                    │-CommitDate     │
│-CommentText    │ │-WorkDate       │                    │-Additions      │
│-CreatedAt      │ │-HoursSpent     │                    │-Deletions      │
├────────────────┤ │-IsBillable     │                    │-ChangedFiles   │
│+Task           │ │-Description?   │                    │-LinkedTaskId?  │
│+User           │ │-CreatedAt      │                    │-MatchScore     │
└────────────────┘ ├────────────────┤                    │-CreatedAt      │
                   │+User           │                    ├────────────────┤
                   │+Task           │                    │+Repository     │
                   └────────────────┘                    │+LinkedTask?    │
                                                         │+FileChanges    │
┌────────────────┐                                       └───────┬────────┘
│    AuditLog    │                                               │
├────────────────┤                                               ▼
│-LogId [PK]     │                                       ┌────────────────┐
│-TableName      │                                       │ GitFileChange  │
│-RecordId       │                                       ├────────────────┤
│-Action         │                                       │-GitFileChgId   │
│-OldValues?     │                                       │-GitCommitId[FK]│
│-NewValues?     │                                       │-FileName       │
│-PerformedByUser│                                       │-FileExtension? │
│-PerformedAt    │                                       │-Status?        │
└────────────────┘                                       │-Additions      │
                                                         │-Deletions      │
┌────────────────┐                                       ├────────────────┤
│ProjectTeamMember│                                      │+Commit         │
├────────────────┤                                       └────────────────┘
│-TeamMemberId[PK]│
│-ProjectId [FK] │
│-UserId [FK]    │
│-ProjectRole?   │
│-JoinedAt       │
├────────────────┤
│+Project        │
│+User           │
└────────────────┘
```

---

## 3. Enum Tanımları

### 3.1 ProjectStatus
```csharp
public enum ProjectStatus
{
    Planned = 1,      // Planlama aşamasında
    Active = 2,       // Aktif olarak çalışılıyor
    OnHold = 3,       // Beklemede
    Completed = 4,    // Tamamlandı
    Cancelled = 5     // İptal edildi
}
```

### 3.2 TaskStatus
```csharp
public enum TaskStatus
{
    Pending = 1,      // Bekliyor
    InProgress = 2,   // Devam ediyor
    Completed = 3,    // Tamamlandı
    Cancelled = 4,    // İptal edildi
    Blocked = 5       // Engellenmiş
}
```

### 3.3 Priority
```csharp
public enum Priority
{
    Low = 1,          // Düşük öncelik
    Medium = 2,       // Orta öncelik
    High = 3,         // Yüksek öncelik
    Critical = 4      // Kritik öncelik
}
```

### 3.4 TeamRole (Takım İçi Roller)
```csharp
public enum TeamRole
{
    Owner = 1,           // Takım sahibi
    Admin = 2,           // Yönetici
    ProjectManager = 3,  // Proje yöneticisi
    Developer = 4,       // Geliştirici
    Observer = 5         // Gözlemci
}
```
> **Not:** Bu enum takım içi rolleri tanımlar. Sistem rolleri (Admin, ProjectManager, Developer, Pending) farklıdır ve `Roles` tablosunda tutulur.

### 3.5 Sistem Rolleri (Roles Tablosu)
```sql
-- Veritabanındaki gerçek roller:
RoleId: 1 → Admin          (Sistem yöneticisi)
RoleId: 2 → ProjectManager (Proje yöneticisi)
RoleId: 3 → Developer      (Geliştirici)
RoleId: 4 → Pending        (Onay bekleyen)
```

### 3.6 InvitationStatus
```csharp
public enum InvitationStatus
{
    Pending = 1,      // Bekliyor
    Accepted = 2,     // Kabul edildi
    Declined = 3,     // Reddedildi
    Expired = 4,      // Süresi doldu
    Cancelled = 5     // İptal edildi
}
```

### 3.7 NotificationType
```csharp
public enum NotificationType
{
    Info = 1,         // Bilgi
    Warning = 2,      // Uyarı
    Error = 3,        // Hata
    Success = 4       // Başarı
}
```

### 3.8 ActivityType
```csharp
public enum ActivityType
{
    // Task Activities
    TaskCreated, TaskUpdated, TaskCompleted,
    TaskAssigned, TaskUnassigned, TaskDeleted,
    TaskStatusChanged, TaskPriorityChanged,
    
    // Project Activities
    ProjectCreated, ProjectUpdated, ProjectCompleted,
    ProjectDeleted, ProjectStatusChanged,
    
    // Team Activities
    TeamCreated, TeamUpdated, TeamDeleted,
    MemberAdded, MemberRemoved, MemberRoleChanged,
    
    // Comment Activities
    CommentAdded, CommentDeleted
}
```

---

## 4. İlişki Özeti

| İlişki | Tür | Açıklama |
|--------|-----|----------|
| User → Role | N:1 | Her kullanıcının bir rolü var |
| User → Team (Owner) | 1:N | Kullanıcı birden fazla takım sahibi olabilir |
| User → TeamMember | 1:N | Kullanıcı birden fazla takıma üye olabilir |
| Team → Project | 1:N | Takımın birden fazla projesi olabilir |
| Project → Task | 1:N | Projenin birden fazla görevi olabilir |
| Task → TaskComment | 1:N | Görevin birden fazla yorumu olabilir |
| Task → TimeEntry | 1:N | Göreve birden fazla zaman kaydı olabilir |
| User → Task (Assigned) | 1:N | Kullanıcıya birden fazla görev atanabilir |
| Project → GitRepository | 1:1 | Projenin bir GitHub reposu olabilir |
| GitRepository → GitCommit | 1:N | Reponun birden fazla commit'i var |
| GitCommit → GitFileChange | 1:N | Commit'in birden fazla dosya değişikliği var |
| GitCommit → Task | N:1 | Commit bir göreve bağlanabilir |

---

## 5. Namespace Yapısı

```
ProjectTracker.Core/
├── Entities/
│   ├── User.cs
│   ├── Role.cs
│   ├── Project.cs
│   ├── Task.cs
│   ├── TaskComment.cs
│   ├── Team.cs
│   ├── TeamMember.cs
│   ├── TeamInvitation.cs
│   ├── ProjectTeamMember.cs
│   ├── ProjectRisk.cs
│   ├── ProjectSnapshot.cs
│   ├── Notification.cs
│   ├── TimeEntry.cs
│   ├── AuditLog.cs
│   ├── GitRepository.cs
│   ├── GitCommit.cs
│   ├── GitFileChange.cs
│   └── GitHubToken.cs
│
├── Enums/
│   ├── ProjectStatus.cs
│   ├── TaskStatus.cs
│   ├── Priority.cs
│   ├── TeamRole.cs
│   ├── InvitationStatus.cs
│   ├── NotificationType.cs
│   └── ActivityType.cs
│
└── Interfaces/
    └── Repositories/
        ├── IRepository.cs
        ├── IUnitOfWork.cs
        ├── IProjectRepository.cs
        ├── ITaskRepository.cs
        ├── IGitRepositoryRepository.cs
        ├── IGitCommitRepository.cs
        ├── IGitFileChangeRepository.cs
        └── IGitHubTokenRepository.cs
```

---

**Oluşturulma Tarihi:** 6 Ocak 2026  
**Proje:** Project Tracker v1.0
