# 🏗️ PHASE 5: ENTITY ARCHITECTURE

**Advanced Team Management System - Database Schema**

---

## 📊 YENİ ENTITY'LER

### **1. Team.cs**

```csharp
namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a team/workspace in the system
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Team name
        /// </summary>
        public string TeamName { get; set; } = string.Empty;

        /// <summary>
        /// Team description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// User who created this team (Team Owner)
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        /// Is team active
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Team creation date
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Last update date
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        // Navigation Properties
        public virtual User Owner { get; set; } = null!;
        public virtual ICollection<TeamMember> Members { get; set; } = new List<TeamMember>();
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        public virtual ICollection<TeamInvitation> Invitations { get; set; } = new List<TeamInvitation>();
    }
}
```

---

### **2. TeamMember.cs**

```csharp
namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a user's membership in a team
    /// </summary>
    public class TeamMember
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int TeamMemberId { get; set; }

        /// <summary>
        /// Team ID
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Role in this team (Owner, Admin, Member, Observer)
        /// </summary>
        public TeamRole Role { get; set; } = TeamRole.Member;

        /// <summary>
        /// Join date
        /// </summary>
        public DateTime JoinedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Is active member
        /// </summary>
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual Team Team { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
```

---

### **3. TeamInvitation.cs**

```csharp
namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents an invitation to join a team
    /// </summary>
    public class TeamInvitation
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int InvitationId { get; set; }

        /// <summary>
        /// Team ID
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Invitee email address
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// User who sent the invitation
        /// </summary>
        public int InvitedByUserId { get; set; }

        /// <summary>
        /// Proposed role for invitee
        /// </summary>
        public TeamRole ProposedRole { get; set; } = TeamRole.Member;

        /// <summary>
        /// Invitation status
        /// </summary>
        public InvitationStatus Status { get; set; } = InvitationStatus.Pending;

        /// <summary>
        /// Unique invitation token (for security)
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Invitation sent date
        /// </summary>
        public DateTime SentAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Invitation expiration date
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Response date (accepted/declined)
        /// </summary>
        public DateTime? RespondedAt { get; set; }

        // Navigation Properties
        public virtual Team Team { get; set; } = null!;
        public virtual User InvitedBy { get; set; } = null!;
    }
}
```

---

## 🔢 YENİ ENUM'LAR

### **TeamRole.cs**

```csharp
namespace ProjectTracker.Core.Enums
{
    /// <summary>
    /// Team member roles
    /// </summary>
    public enum TeamRole
    {
        /// <summary>
        /// Team owner - full control
        /// </summary>
        Owner = 1,

        /// <summary>
        /// Team admin - can manage members and settings
        /// </summary>
        Admin = 2,

        /// <summary>
        /// Project manager - can create and manage projects
        /// </summary>
        ProjectManager = 3,

        /// <summary>
        /// Developer - can work on assigned tasks
        /// </summary>
        Developer = 4,

        /// <summary>
        /// Observer - read-only access
        /// </summary>
        Observer = 5
    }
}
```

---

### **InvitationStatus.cs**

```csharp
namespace ProjectTracker.Core.Enums
{
    /// <summary>
    /// Team invitation status
    /// </summary>
    public enum InvitationStatus
    {
        /// <summary>
        /// Invitation sent, waiting for response
        /// </summary>
        Pending = 1,

        /// <summary>
        /// Invitation accepted
        /// </summary>
        Accepted = 2,

        /// <summary>
        /// Invitation declined
        /// </summary>
        Declined = 3,

        /// <summary>
        /// Invitation expired
        /// </summary>
        Expired = 4,

        /// <summary>
        /// Invitation cancelled by sender
        /// </summary>
        Cancelled = 5
    }
}
```

---

## 🔄 MEVCUT ENTITY GÜNCELLEMELERİ

### **Project.cs - TeamId Ekleme**

```csharp
public class Project
{
    // ... existing properties ...

    /// <summary>
    /// Team that owns this project
    /// </summary>
    public int TeamId { get; set; }

    // ... existing properties ...

    // Navigation Properties
    public virtual Team Team { get; set; } = null!;
    // ... existing navigation properties ...
}
```

---

### **User.cs - Team İlişkileri Ekleme**

```csharp
public class User
{
    // ... existing properties ...

    // Navigation Properties
    // ... existing navigation properties ...
    
    public virtual ICollection<Team> OwnedTeams { get; set; } = new List<Team>();
    public virtual ICollection<TeamMember> TeamMemberships { get; set; } = new List<TeamMember>();
    public virtual ICollection<TeamInvitation> SentInvitations { get; set; } = new List<TeamInvitation>();
}
```

---

## 📋 DATABASE MIGRATION

### **Migration Adımları:**

1. **Team tablosu oluştur**
2. **TeamMember tablosu oluştur**
3. **TeamInvitation tablosu oluştur**
4. **Project tablosuna TeamId kolonu ekle**
5. **Foreign key constraints ekle**
6. **Indexes oluştur** (TeamId, UserId, Email, Token)

### **Migration Command:**

```bash
Add-Migration AddTeamManagementSystem
Update-Database
```

---

## 🎯 İLİŞKİ DİYAGRAMI

```
User (1) ──owns──> (M) Team
User (1) ──member of──> (M) TeamMember (M) <──belongs to── (1) Team
User (1) ──invites──> (M) TeamInvitation (M) <──for── (1) Team
Team (1) ──has──> (M) Project
Team (1) ──has──> (M) TeamMember
Team (1) ──has──> (M) TeamInvitation
```

---

## 📚 DTO TANIMLARI

### **TeamDto.cs**

```csharp
public class TeamDto
{
    public int TeamId { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int OwnerId { get; set; }
    public string OwnerName { get; set; } = string.Empty;
    public int MemberCount { get; set; }
    public int ProjectCount { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
```

### **TeamMemberDto.cs**

```csharp
public class TeamMemberDto
{
    public int TeamMemberId { get; set; }
    public int TeamId { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public TeamRole Role { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public DateTime JoinedAt { get; set; }
    public bool IsActive { get; set; }
}
```

### **TeamInvitationDto.cs**

```csharp
public class TeamInvitationDto
{
    public int InvitationId { get; set; }
    public int TeamId { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int InvitedByUserId { get; set; }
    public string InvitedByName { get; set; } = string.Empty;
    public TeamRole ProposedRole { get; set; }
    public InvitationStatus Status { get; set; }
    public string StatusName { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsExpired => DateTime.Now > ExpiresAt;
}
```

---

**Created:** 29 Aralık 2024  
**Project:** ProjectTracker - Advanced Team Management System  
**Phase:** 5 - Entity Architecture Design
