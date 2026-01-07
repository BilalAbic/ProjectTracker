# ER Diyagramı (Entity-Relationship Diyagramı)

## Project Tracker - Veritabanı Şeması

---

## 1. Genel Bakış

| Kategori | Tablo Sayısı |
|----------|--------------|
| Kullanıcı & Yetki | 4 |
| Proje & Görev | 5 |
| Takım | 3 |
| GitHub Entegrasyonu | 4 |
| Destek | 2 |
| **Toplam** | **18** |

---

## 2. ER Diyagramı (ASCII)

```
┌─────────────────────────────────────────────────────────────────────────────────────────────────────┐
│                                    PROJECT TRACKER - ER DİYAGRAMI                                   │
└─────────────────────────────────────────────────────────────────────────────────────────────────────┘

                                    ┌─────────────────┐
                                    │      Roles      │
                                    ├─────────────────┤
                                    │ PK RoleId       │
                                    │    RoleName     │
                                    │    Description  │
                                    └────────┬────────┘
                                             │
                                             │ 1
                                             │
                                             │ *
                                    ┌────────┴────────┐
                                    │      Users      │
                                    ├─────────────────┤
                                    │ PK UserId       │
                                    │ FK RoleId       │───────────────────────────────────────┐
                                    │    Username     │                                       │
                                    │    PasswordHash │                                       │
                                    │    FullName     │                                       │
                                    │    Email        │                                       │
                                    │    IsActive     │                                       │
                                    │    HourlyCost   │                                       │
                                    │    Department   │                                       │
                                    │    GitHubUser   │                                       │
                                    │    CreatedAt    │                                       │
                                    └────────┬────────┘                                       │
                                             │                                                │
          ┌──────────────────────────────────┼──────────────────────────────────┐             │
          │                                  │                                  │             │
          │ 1                                │ 1                                │ 1           │
          │                                  │                                  │             │
          │ *                                │ *                                │ *           │
┌─────────┴─────────┐              ┌─────────┴─────────┐              ┌─────────┴─────────┐   │
│   Notifications   │              │   GitHubTokens    │              │      Teams        │   │
├───────────────────┤              ├───────────────────┤              ├───────────────────┤   │
│ PK NotificationId │              │ PK GitHubTokenId  │              │ PK TeamId         │   │
│ FK UserId         │              │ FK UserId         │              │ FK OwnerId        │───┘
│    Title          │              │    EncryptedToken │              │    TeamName       │
│    Message        │              │    GitHubUsername │              │    Description    │
│    Type           │              │    RateLimitRem   │              │    IsActive       │
│    IsRead         │              │    RateLimitReset │              │    CreatedAt      │
│    CreatedAt      │              │    IsActive       │              │    UpdatedAt      │
└───────────────────┘              │    LastUsedAt     │              └─────────┬─────────┘
                                   │    CreatedAt      │                        │
                                   └───────────────────┘           ┌────────────┼────────────┐
                                                                   │            │            │
                                                                   │ 1          │ 1          │ 1
                                                                   │            │            │
                                                                   │ *          │ *          │ *
                                                          ┌────────┴────────┐   │   ┌────────┴────────┐
                                                          │   TeamMembers   │   │   │ TeamInvitations │
                                                          ├─────────────────┤   │   ├─────────────────┤
                                                          │ PK TeamMemberId │   │   │ PK InvitationId │
                                                          │ FK TeamId       │   │   │ FK TeamId       │
                                                          │ FK UserId       │   │   │ FK InvitedByUser│
                                                          │    Role         │   │   │    Email        │
                                                          │    JoinedAt     │   │   │    ProposedRole │
                                                          │    IsActive     │   │   │    Status       │
                                                          └─────────────────┘   │   │    Token        │
                                                                                │   │    SentAt       │
                                                                                │   │    ExpiresAt    │
                                                                                │   │    RespondedAt  │
                                                                                │   └─────────────────┘
                                                                                │
                                                                                │ 1
                                                                                │
                                                                                │ *
                                                                       ┌────────┴────────┐
                                                                       │    Projects     │
                                                                       ├─────────────────┤
                                                                       │ PK ProjectId    │
                                                                       │ FK CreatedByUser│
                                                                       │ FK TeamId       │
                                                                       │    ProjectName  │
                                                                       │    Description  │
                                                                       │    StartDate    │
                                                                       │    EndDate      │
                                                                       │    Budget       │
                                                                       │    Status       │
                                                                       │    Priority     │
                                                                       │    Completion%  │
                                                                       │    RiskScore    │
                                                                       │    ActualCost   │
                                                                       │    GitHubRepoUrl│
                                                                       │    CreatedAt    │
                                                                       └────────┬────────┘
                                                                                │
                              ┌──────────────────────────────────────────────────┼──────────────────────────────────────────────────┐
                              │                                                 │                                                  │
                              │ 1                                               │ 1                                                │ 1
                              │                                                 │                                                  │
                              │ *                                               │ *                                                │ 0..1
                     ┌────────┴────────┐                               ┌────────┴────────┐                               ┌─────────┴─────────┐
                     │      Tasks      │                               │  ProjectRisks   │                               │  GitRepositories  │
                     ├─────────────────┤                               ├─────────────────┤                               ├───────────────────┤
                     │ PK TaskId       │                               │ PK RiskId       │                               │ PK GitRepoId      │
                     │ FK ProjectId    │                               │ FK ProjectId    │                               │ FK ProjectId      │
                     │ FK AssignedUser │                               │    RiskScore    │                               │    RepoUrl        │
                     │ FK ParentTaskId │                               │    RiskLevel    │                               │    RepoOwner      │
                     │    TaskName     │                               │    RiskFactors  │                               │    RepoName       │
                     │    Description  │                               │    Recommend.   │                               │    DefaultBranch  │
                     │    Priority     │                               │    AnalyzedAt   │                               │    IsPrivate      │
                     │    Status       │                               └─────────────────┘                               │    LastSyncAt     │
                     │    EstimatedHrs │                                                                                 │    SyncStatus     │
                     │    ActualHours  │                               ┌─────────────────┐                               │    TotalCommits   │
                     │    StartDate    │                               │ProjectSnapshots │                               │    TotalBranches  │
                     │    DueDate      │                               ├─────────────────┤                               │    Contributors   │
                     │    CompletedDate│                               │ PK SnapshotId   │                               │    OpenIssues     │
                     │    IsCritical   │                               │ FK ProjectId    │                               │    CreatedAt      │
                     │    CreatedAt    │                               │    SnapshotDate │                               └─────────┬─────────┘
                     └────────┬────────┘                               │    OpenTasks    │                                         │
                              │                                        │    CompletedTask│                                         │ 1
                              │                                        │    RemainingHrs │                                         │
                 ┌────────────┼────────────┐                           │    BurnedBudget │                                         │ *
                 │            │            │                           │    PlannedValue │                               ┌─────────┴─────────┐
                 │ 1          │ 1          │ 1                         │    EarnedValue  │                               │    GitCommits     │
                 │            │            │                           │    CreatedAt    │                               ├───────────────────┤
                 │ *          │ *          │ *                         └─────────────────┘                               │ PK GitCommitId    │
        ┌────────┴────────┐   │   ┌────────┴────────┐                                                                    │ FK GitRepoId      │
        │  TaskComments   │   │   │   TimeEntries   │                  ┌─────────────────┐                               │ FK LinkedTaskId   │
        ├─────────────────┤   │   ├─────────────────┤                  │ProjectTeamMember│                               │    Sha            │
        │ PK CommentId    │   │   │ PK TimeEntryId  │                  ├─────────────────┤                               │    Message        │
        │ FK TaskId       │   │   │ FK UserId       │                  │ PK TeamMemberId │                               │    AuthorName     │
        │ FK UserId       │   │   │ FK TaskId       │                  │ FK ProjectId    │                               │    AuthorEmail    │
        │    CommentText  │   │   │    WorkDate     │                  │ FK UserId       │                               │    AuthorGHUser   │
        │    CreatedAt    │   │   │    HoursSpent   │                  │    ProjectRole  │                               │    CommitDate     │
        └─────────────────┘   │   │    IsBillable   │                  │    JoinedAt     │                               │    Additions      │
                              │   │    Description  │                  └─────────────────┘                               │    Deletions      │
                              │   │    CreatedAt    │                                                                    │    ChangedFiles   │
                              │   └─────────────────┘                                                                    │    MatchScore     │
                              │                                                                                          │    CreatedAt      │
                              │                                                                                          └─────────┬─────────┘
                              │                                                                                                    │
                              │                                                                                                    │ 1
                              │                                                                                                    │
                              │                                                                                                    │ *
                              │                                                                                          ┌─────────┴─────────┐
                              │                                                                                          │  GitFileChanges   │
                              │                                                                                          ├───────────────────┤
                              │                                                                                          │ PK GitFileChgId   │
                              │                                                                                          │ FK GitCommitId    │
                              │                                                                                          │    FileName       │
                              │                                                                                          │    FileExtension  │
                              │                                                                                          │    Status         │
                              │                                                                                          │    Additions      │
                              │                                                                                          │    Deletions      │
                              │                                                                                          └───────────────────┘
                              │
                              │ *
                              │
                              │ 0..1
                     ┌────────┴────────┐
                     │    AuditLogs    │
                     ├─────────────────┤
                     │ PK LogId        │
                     │    TableName    │
                     │    RecordId     │
                     │    Action       │
                     │    OldValues    │
                     │    NewValues    │
                     │    PerformedBy  │
                     │    PerformedAt  │
                     └─────────────────┘
```


---

## 3. Tablo Detayları

### 3.1 Kullanıcı & Yetki Tabloları

#### Roles
```sql
CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL UNIQUE,
    Description NVARCHAR(200)
);

-- Seed Data:
-- 1: Admin (Sistem yöneticisi)
-- 2: ProjectManager (Proje yöneticisi)
-- 3: Developer (Geliştirici)
-- 4: Pending (Onay bekleyen)
```

#### Users
```sql
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    RoleId INT NOT NULL FOREIGN KEY REFERENCES Roles(RoleId),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    IsActive BIT NOT NULL DEFAULT 1,
    HourlyCost DECIMAL(10,2),
    Department NVARCHAR(100),
    GitHubUsername NVARCHAR(100),
    GitHubAvatarUrl NVARCHAR(500),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

#### Notifications
```sql
CREATE TABLE Notifications (
    NotificationId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    Title NVARCHAR(200) NOT NULL,
    Message NVARCHAR(MAX),
    Type NVARCHAR(50) NOT NULL,
    IsRead BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

#### GitHubTokens
```sql
CREATE TABLE GitHubTokens (
    GitHubTokenId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    EncryptedToken NVARCHAR(500) NOT NULL,
    GitHubUsername NVARCHAR(100),
    RateLimitRemaining INT DEFAULT 5000,
    RateLimitResetAt DATETIME,
    IsActive BIT NOT NULL DEFAULT 1,
    LastUsedAt DATETIME,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

---

### 3.2 Takım Tabloları

#### Teams
```sql
CREATE TABLE Teams (
    TeamId INT PRIMARY KEY IDENTITY(1,1),
    OwnerId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    TeamName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME
);
```

#### TeamMembers
```sql
CREATE TABLE TeamMembers (
    TeamMemberId INT PRIMARY KEY IDENTITY(1,1),
    TeamId INT NOT NULL FOREIGN KEY REFERENCES Teams(TeamId),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    Role INT NOT NULL, -- TeamRole enum (1:Owner, 2:Admin, 3:PM, 4:Developer, 5:Observer)
    JoinedAt DATETIME NOT NULL DEFAULT GETDATE(),
    IsActive BIT NOT NULL DEFAULT 1,
    
    UNIQUE(TeamId, UserId)
);
```

#### TeamInvitations
```sql
CREATE TABLE TeamInvitations (
    InvitationId INT PRIMARY KEY IDENTITY(1,1),
    TeamId INT NOT NULL FOREIGN KEY REFERENCES Teams(TeamId),
    InvitedByUserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    Email NVARCHAR(100) NOT NULL,
    ProposedRole INT NOT NULL, -- TeamRole enum
    Status INT NOT NULL DEFAULT 1, -- InvitationStatus enum (1:Pending, 2:Accepted, 3:Declined, 4:Expired, 5:Cancelled)
    Token NVARCHAR(100) NOT NULL UNIQUE,
    SentAt DATETIME NOT NULL DEFAULT GETDATE(),
    ExpiresAt DATETIME NOT NULL,
    RespondedAt DATETIME
);
```

---

### 3.3 Proje & Görev Tabloları

#### Projects
```sql
CREATE TABLE Projects (
    ProjectId INT PRIMARY KEY IDENTITY(1,1),
    CreatedByUserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    TeamId INT FOREIGN KEY REFERENCES Teams(TeamId),
    ProjectName NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME,
    Budget DECIMAL(18,2),
    Status NVARCHAR(50) NOT NULL DEFAULT 'Planned',
    Priority INT NOT NULL DEFAULT 2, -- Priority enum
    CompletionPercentage DECIMAL(5,2) DEFAULT 0,
    RiskScore DECIMAL(5,2),
    ActualCost DECIMAL(18,2) DEFAULT 0,
    TotalPlannedHours DECIMAL(10,2),
    GitHubRepoUrl NVARCHAR(500),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME
);
```

#### Tasks
```sql
CREATE TABLE Tasks (
    TaskId INT PRIMARY KEY IDENTITY(1,1),
    ProjectId INT NOT NULL FOREIGN KEY REFERENCES Projects(ProjectId),
    AssignedToUserId INT FOREIGN KEY REFERENCES Users(UserId),
    ParentTaskId INT FOREIGN KEY REFERENCES Tasks(TaskId),
    TaskName NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    Priority INT NOT NULL DEFAULT 2, -- Priority enum
    Status INT NOT NULL DEFAULT 1, -- TaskStatus enum
    EstimatedHours DECIMAL(10,2),
    ActualHours DECIMAL(10,2),
    StartDate DATETIME,
    DueDate DATETIME,
    CompletedDate DATETIME,
    IsCriticalPath BIT DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

#### TaskComments
```sql
CREATE TABLE TaskComments (
    CommentId INT PRIMARY KEY IDENTITY(1,1),
    TaskId INT NOT NULL FOREIGN KEY REFERENCES Tasks(TaskId),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    CommentText NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

#### TimeEntries
```sql
CREATE TABLE TimeEntries (
    TimeEntryId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    TaskId INT NOT NULL FOREIGN KEY REFERENCES Tasks(TaskId),
    WorkDate DATE NOT NULL,
    HoursSpent DECIMAL(5,2) NOT NULL,
    IsBillable BIT DEFAULT 1,
    Description NVARCHAR(500),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

#### ProjectRisks
```sql
CREATE TABLE ProjectRisks (
    RiskId INT PRIMARY KEY IDENTITY(1,1),
    ProjectId INT NOT NULL FOREIGN KEY REFERENCES Projects(ProjectId),
    RiskScore DECIMAL(5,2) NOT NULL,
    RiskLevel NVARCHAR(20) NOT NULL, -- Low, Medium, High
    RiskFactors NVARCHAR(MAX),
    Recommendations NVARCHAR(MAX),
    AnalyzedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

#### ProjectSnapshots
```sql
CREATE TABLE ProjectSnapshots (
    SnapshotId INT PRIMARY KEY IDENTITY(1,1),
    ProjectId INT NOT NULL FOREIGN KEY REFERENCES Projects(ProjectId),
    SnapshotDate DATETIME NOT NULL DEFAULT GETDATE(),
    OpenTasksCount INT DEFAULT 0,
    CompletedTasksCount INT DEFAULT 0,
    RemainingHours DECIMAL(10,2),
    IdealRemainingHours DECIMAL(10,2),
    BurnedBudget DECIMAL(18,2),
    PlannedValue DECIMAL(18,2),
    EarnedValue DECIMAL(18,2),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

#### ProjectTeamMembers
```sql
CREATE TABLE ProjectTeamMembers (
    TeamMemberId INT PRIMARY KEY IDENTITY(1,1),
    ProjectId INT NOT NULL FOREIGN KEY REFERENCES Projects(ProjectId),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(UserId),
    ProjectRole NVARCHAR(50),
    JoinedAt DATETIME NOT NULL DEFAULT GETDATE(),
    
    UNIQUE(ProjectId, UserId)
);
```

---

### 3.4 GitHub Entegrasyon Tabloları

#### GitRepositories
```sql
CREATE TABLE GitRepositories (
    GitRepoId INT PRIMARY KEY IDENTITY(1,1),
    ProjectId INT NOT NULL UNIQUE FOREIGN KEY REFERENCES Projects(ProjectId),
    RepoUrl NVARCHAR(500) NOT NULL,
    RepoOwner NVARCHAR(100) NOT NULL,
    RepoName NVARCHAR(100) NOT NULL,
    DefaultBranch NVARCHAR(100) DEFAULT 'main',
    IsPrivate BIT DEFAULT 0,
    LastSyncAt DATETIME,
    SyncStatus NVARCHAR(50) DEFAULT 'NotSynced',
    TotalCommits INT DEFAULT 0,
    TotalBranches INT DEFAULT 0,
    TotalContributors INT DEFAULT 0,
    OpenIssues INT DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

#### GitCommits
```sql
CREATE TABLE GitCommits (
    GitCommitId INT PRIMARY KEY IDENTITY(1,1),
    GitRepoId INT NOT NULL FOREIGN KEY REFERENCES GitRepositories(GitRepoId),
    LinkedTaskId INT FOREIGN KEY REFERENCES Tasks(TaskId),
    Sha NVARCHAR(50) NOT NULL,
    Message NVARCHAR(MAX),
    AuthorName NVARCHAR(100),
    AuthorEmail NVARCHAR(200),
    AuthorGitHubUsername NVARCHAR(100),
    AuthorAvatarUrl NVARCHAR(500),
    CommitDate DATETIME NOT NULL,
    Additions INT DEFAULT 0,
    Deletions INT DEFAULT 0,
    ChangedFilesCount INT DEFAULT 0,
    MatchScore DECIMAL(5,2), -- Task matching confidence
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    
    UNIQUE(GitRepoId, Sha)
);
```

#### GitFileChanges
```sql
CREATE TABLE GitFileChanges (
    GitFileChangeId INT PRIMARY KEY IDENTITY(1,1),
    GitCommitId INT NOT NULL FOREIGN KEY REFERENCES GitCommits(GitCommitId),
    FileName NVARCHAR(500) NOT NULL,
    FileExtension NVARCHAR(20),
    Status NVARCHAR(20), -- added, modified, deleted, renamed
    Additions INT DEFAULT 0,
    Deletions INT DEFAULT 0
);
```

---

### 3.5 Destek Tabloları

#### AuditLogs
```sql
CREATE TABLE AuditLogs (
    LogId INT PRIMARY KEY IDENTITY(1,1),
    TableName NVARCHAR(100) NOT NULL,
    RecordId INT NOT NULL,
    Action NVARCHAR(50) NOT NULL, -- Created, Updated, Deleted
    OldValues NVARCHAR(MAX),
    NewValues NVARCHAR(MAX),
    PerformedByUserId INT,
    PerformedAt DATETIME NOT NULL DEFAULT GETDATE()
);
```

---

## 4. İlişki Özeti

| İlişki | Tür | Açıklama |
|--------|-----|----------|
| Roles → Users | 1:N | Her rol birden fazla kullanıcıya atanabilir |
| Users → Teams (Owner) | 1:N | Kullanıcı birden fazla takım sahibi olabilir |
| Users → TeamMembers | 1:N | Kullanıcı birden fazla takıma üye olabilir |
| Teams → TeamMembers | 1:N | Takımın birden fazla üyesi olabilir |
| Teams → TeamInvitations | 1:N | Takımın birden fazla daveti olabilir |
| Teams → Projects | 1:N | Takımın birden fazla projesi olabilir |
| Projects → Tasks | 1:N | Projenin birden fazla görevi olabilir |
| Tasks → Tasks (Parent) | 1:N | Görev alt görevlere sahip olabilir |
| Tasks → TaskComments | 1:N | Görevin birden fazla yorumu olabilir |
| Tasks → TimeEntries | 1:N | Göreve birden fazla zaman kaydı olabilir |
| Users → Tasks (Assigned) | 1:N | Kullanıcıya birden fazla görev atanabilir |
| Projects → GitRepositories | 1:1 | Projenin bir GitHub reposu olabilir |
| GitRepositories → GitCommits | 1:N | Reponun birden fazla commit'i var |
| GitCommits → GitFileChanges | 1:N | Commit'in birden fazla dosya değişikliği var |
| GitCommits → Tasks | N:1 | Commit bir göreve bağlanabilir |
| Users → GitHubTokens | 1:N | Kullanıcının birden fazla token'ı olabilir |
| Users → Notifications | 1:N | Kullanıcının birden fazla bildirimi olabilir |
| Projects → ProjectRisks | 1:N | Projenin birden fazla risk kaydı olabilir |
| Projects → ProjectSnapshots | 1:N | Projenin birden fazla snapshot'ı olabilir |

---

## 5. Plesk Veritabanı (Remote)

### Invitations (Plesk DB)
```sql
-- Bu tablo Plesk sunucusundaki ayrı veritabanında bulunur
-- Web üzerinden davet kabul/red işlemleri için kullanılır

CREATE TABLE Invitations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Token NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(255) NOT NULL,
    TeamName NVARCHAR(100) NOT NULL,
    InvitedByName NVARCHAR(100) NOT NULL,
    ProposedRole NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    SentAt DATETIME NOT NULL DEFAULT GETDATE(),
    ExpiresAt DATETIME NOT NULL,
    RespondedAt DATETIME NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- Indexes
CREATE INDEX IX_Invitations_Token ON Invitations(Token);
CREATE INDEX IX_Invitations_Email ON Invitations(Email);
CREATE INDEX IX_Invitations_Status ON Invitations(Status);
```

### Dual-Database İlişkisi
```
┌─────────────────────────────────────────────────────────────────────────────┐
│                    LOCAL DB ←──── TOKEN ────→ PLESK DB                      │
└─────────────────────────────────────────────────────────────────────────────┘

┌─────────────────────────┐                    ┌─────────────────────────┐
│   LOCAL SQL SERVER      │                    │      PLESK MySQL        │
│                         │                    │                         │
│   TeamInvitations       │                    │   Invitations           │
│   ├─ InvitationId (PK)  │                    │   ├─ Id (PK)            │
│   ├─ TeamId (FK)        │                    │   ├─ Token ◄────────────┼───┐
│   ├─ Token ─────────────┼────────────────────┼───► Token               │   │
│   ├─ Email              │                    │   ├─ Email              │   │
│   ├─ ProposedRole       │                    │   ├─ TeamName           │   │
│   ├─ Status             │                    │   ├─ InvitedByName      │   │
│   └─ ...                │                    │   ├─ ProposedRole       │   │
│                         │                    │   ├─ Status             │   │
│   (Full entity with     │                    │   └─ ...                │   │
│    foreign keys)        │                    │                         │   │
│                         │                    │   (Denormalized for     │   │
│                         │                    │    web access)          │   │
└─────────────────────────┘                    └─────────────────────────┘   │
                                                                             │
                                               AYNI TOKEN                    │
                                               (Senkronizasyon Anahtarı) ────┘
```

---

## 6. Index Stratejisi

```sql
-- Users
CREATE INDEX IX_Users_Username ON Users(Username);
CREATE INDEX IX_Users_Email ON Users(Email);
CREATE INDEX IX_Users_RoleId ON Users(RoleId);

-- Teams
CREATE INDEX IX_Teams_OwnerId ON Teams(OwnerId);

-- TeamMembers
CREATE INDEX IX_TeamMembers_TeamId ON TeamMembers(TeamId);
CREATE INDEX IX_TeamMembers_UserId ON TeamMembers(UserId);

-- Projects
CREATE INDEX IX_Projects_TeamId ON Projects(TeamId);
CREATE INDEX IX_Projects_CreatedByUserId ON Projects(CreatedByUserId);
CREATE INDEX IX_Projects_Status ON Projects(Status);

-- Tasks
CREATE INDEX IX_Tasks_ProjectId ON Tasks(ProjectId);
CREATE INDEX IX_Tasks_AssignedToUserId ON Tasks(AssignedToUserId);
CREATE INDEX IX_Tasks_Status ON Tasks(Status);
CREATE INDEX IX_Tasks_ParentTaskId ON Tasks(ParentTaskId);

-- GitCommits
CREATE INDEX IX_GitCommits_GitRepoId ON GitCommits(GitRepoId);
CREATE INDEX IX_GitCommits_LinkedTaskId ON GitCommits(LinkedTaskId);
CREATE INDEX IX_GitCommits_CommitDate ON GitCommits(CommitDate);

-- AuditLogs
CREATE INDEX IX_AuditLogs_TableName ON AuditLogs(TableName);
CREATE INDEX IX_AuditLogs_RecordId ON AuditLogs(RecordId);
CREATE INDEX IX_AuditLogs_PerformedAt ON AuditLogs(PerformedAt);
```

---

**Oluşturulma Tarihi:** 6 Ocak 2026  
**Proje:** Project Tracker v1.0  
**Veritabanı:** SQL Server (Local) + MySQL (Plesk Remote)
