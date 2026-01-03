using GitHubAnalyzerTest.Models;
using GitHubAnalyzerTest.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║     🔗 GitHub Analytics Integration Test - ProjectTracker Simülasyonu     ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");

// ═══════════════════════════════════════════════════════════════════════════════
// 1. SERVİSLERİ OLUŞTUR
// ═══════════════════════════════════════════════════════════════════════════════

var tokenPool = new TokenPoolService();
var taskMatcher = new TaskMatchingService();
var syncService = new GitHubSyncService(tokenPool, taskMatcher);

// ═══════════════════════════════════════════════════════════════════════════════
// 2. KULLANICI SİMÜLASYONU (Kullanıcı ayarlarından gelecek)
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n📋 KULLANICI AYARLARI SİMÜLASYONU");
Console.WriteLine("─────────────────────────────────────────────────────────────────────────────");

var user = new User
{
    UserId = 1,
    Username = "bilal",
    FullName = "Bilal Abic",
    Email = "bilal@example.com",
    GitHubUsername = "BilalAbic",
    GitHubToken = "github_token"
};

Console.WriteLine($"👤 Kullanıcı: {user.FullName} ({user.Username})");
Console.WriteLine($"🔗 GitHub: {user.GitHubUsername}");

// Token'ı havuza ekle
Console.WriteLine("\n🔑 TOKEN HAVUZUNA EKLEME");
await tokenPool.AddTokenAsync(user.UserId, user.GitHubUsername!, user.GitHubToken!);

// Havuz durumunu göster
var poolStatus = tokenPool.GetPoolStatus();
Console.WriteLine($"\n📊 Havuz Durumu: {poolStatus.ActiveTokens}/{poolStatus.TotalTokens} aktif token");
Console.WriteLine($"   Toplam API Limit: {poolStatus.TotalRateLimitRemaining}");

// ═══════════════════════════════════════════════════════════════════════════════
// 3. PROJE SİMÜLASYONU
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n📁 PROJE SİMÜLASYONU");
Console.WriteLine("─────────────────────────────────────────────────────────────────────────────");

var project = new Project
{
    ProjectId = 1,
    ProjectName = "ProjectTracker",
    Description = "Smart Project Management System",
    GitHubRepoUrl = "https://github.com/BilalAbic/ProjectTracker"
};

Console.WriteLine($"📂 Proje: {project.ProjectName}");
Console.WriteLine($"🔗 GitHub: {project.GitHubRepoUrl}");

// ═══════════════════════════════════════════════════════════════════════════════
// 4. GÖREV SİMÜLASYONU (ProjectTracker'daki görevler)
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n📋 GÖREV SİMÜLASYONU (Task-Commit eşleştirme için)");
Console.WriteLine("─────────────────────────────────────────────────────────────────────────────");

var tasks = new List<ProjectTask>
{
    new() { TaskId = 1, ProjectId = 1, TaskName = "Login form tasarımı", Description = "FrmLogin ekranı tasarlanacak", Status = "Done" },
    new() { TaskId = 2, ProjectId = 1, TaskName = "Dashboard layout", Description = "Ana dashboard ekranı oluşturulacak", Status = "Done" },
    new() { TaskId = 3, ProjectId = 1, TaskName = "Proje CRUD işlemleri", Description = "Proje ekleme, düzenleme, silme", Status = "Done" },
    new() { TaskId = 4, ProjectId = 1, TaskName = "Görev yönetimi", Description = "Task ekleme ve Kanban board", Status = "Done" },
    new() { TaskId = 5, ProjectId = 1, TaskName = "Takım yönetimi", Description = "Team ve member işlemleri", Status = "Done" },
    new() { TaskId = 6, ProjectId = 1, TaskName = "Raporlama sistemi", Description = "Report form ve PDF export", Status = "Done" },
    new() { TaskId = 7, ProjectId = 1, TaskName = "Rol sistemi iyileştirmeleri", Description = "Pending rol ve yetki kontrolleri", Status = "Done" },
    new() { TaskId = 8, ProjectId = 1, TaskName = "Audit log sistemi", Description = "Aktivite loglama", Status = "Done" },
    new() { TaskId = 9, ProjectId = 1, TaskName = "UI tasarım iyileştirmeleri", Description = "ColorPalette ve FrmMessage", Status = "Done" },
    new() { TaskId = 10, ProjectId = 1, TaskName = "Veritabanı yapısı", Description = "Entity ve migration işlemleri", Status = "Done" },
    new() { TaskId = 11, ProjectId = 1, TaskName = "GitHub entegrasyonu", Description = "GitHub analytics sistemi", Status = "InProgress" },
    new() { TaskId = 12, ProjectId = 1, TaskName = "Davet sistemi", Description = "Team invitation işlemleri", Status = "InProgress" }
};

project.Tasks = tasks;

Console.WriteLine($"📝 Toplam {tasks.Count} görev tanımlı:");
foreach (var task in tasks.Take(5))
{
    Console.WriteLine($"   • [{task.TaskId}] {task.TaskName}");
}
Console.WriteLine($"   ... ve {tasks.Count - 5} görev daha");

// ═══════════════════════════════════════════════════════════════════════════════
// 5. REPOSITORY BAĞLAMA VE SENKRONİZASYON
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n🔄 REPOSITORY SENKRONİZASYONU");
Console.WriteLine("─────────────────────────────────────────────────────────────────────────────");

var parsed = syncService.ParseRepoUrl(project.GitHubRepoUrl!);
if (parsed == null)
{
    Console.WriteLine("❌ Geçersiz repository URL'si!");
    return;
}

var gitRepo = new GitRepository
{
    GitRepoId = 1,
    ProjectId = project.ProjectId,
    RepoUrl = project.GitHubRepoUrl!,
    RepoOwner = parsed.Value.owner,
    RepoName = parsed.Value.repo
};

project.GitRepository = gitRepo;

// Senkronizasyonu başlat
var syncResult = await syncService.SyncRepositoryAsync(gitRepo, tasks);

if (!syncResult.Success)
{
    Console.WriteLine($"\n❌ Senkronizasyon başarısız: {syncResult.ErrorMessage}");
    return;
}

// ═══════════════════════════════════════════════════════════════════════════════
// 6. DASHBOARD WIDGET'LARI (Repository Sağlığı)
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                         📊 DASHBOARD WIDGET'LARI                           ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");

var health = syncService.GetRepositoryHealth(gitRepo);

Console.WriteLine($@"
┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐
│    COMMITS      │  │  SON GÜNCELLEME │  │     ISSUES      │  │    BRANCHES     │
│                 │  │                 │  │                 │  │                 │
│      {health.TotalCommits,4}       │  │  {health.LastCommitAgo,-13} │  │       {health.OpenIssues,3}       │  │       {health.ActiveBranches,3}       │
└─────────────────┘  └─────────────────┘  └─────────────────┘  └─────────────────┘

┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐
│  CONTRIBUTORS   │  │    EKLENEN      │  │    SİLİNEN      │
│                 │  │                 │  │                 │
│       {health.TotalContributors,3}       │  │   +{health.TotalAdditions,6}      │  │   -{health.TotalDeletions,6}      │
└─────────────────┘  └─────────────────┘  └─────────────────┘
");

// ═══════════════════════════════════════════════════════════════════════════════
// 7. GELİŞTİRİCİ LEADERBOARD
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                      👥 GELİŞTİRİCİ LEADERBOARD                            ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");

var leaderboard = syncService.GetDeveloperLeaderboard(gitRepo);

Console.WriteLine("\n┌──────┬────────────────────────┬─────────┬───────────┬───────────┬──────────┐");
Console.WriteLine("│ Sıra │ Geliştirici            │ Commit  │ Eklenen   │ Silinen   │ Katkı %  │");
Console.WriteLine("├──────┼────────────────────────┼─────────┼───────────┼───────────┼──────────┤");

foreach (var dev in leaderboard.Take(10))
{
    var medal = dev.Rank switch { 1 => "🥇", 2 => "🥈", 3 => "🥉", _ => "  " };
    var username = dev.GitHubUsername.Length > 18 ? dev.GitHubUsername[..15] + "..." : dev.GitHubUsername;
    Console.WriteLine($"│ {medal}{dev.Rank,2} │ {username,-22} │ {dev.TotalCommits,7} │ +{dev.TotalAdditions,8} │ -{dev.TotalDeletions,8} │ {dev.ContributionPercentage,6:F1}%  │");
}

Console.WriteLine("└──────┴────────────────────────┴─────────┴───────────┴───────────┴──────────┘");

// ═══════════════════════════════════════════════════════════════════════════════
// 8. TASK-COMMIT EŞLEŞTİRME SONUÇLARI
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                      🔗 TASK-COMMIT EŞLEŞTİRME                             ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");

var (matched, unmatched, avgScore) = taskMatcher.GetMatchingStats(gitRepo.Commits);

Console.WriteLine($"\n📊 Eşleştirme İstatistikleri:");
Console.WriteLine($"   ✅ Eşleşen commit: {matched}");
Console.WriteLine($"   ❌ Eşleşmeyen commit: {unmatched}");
Console.WriteLine($"   📈 Ortalama skor: {avgScore:F1}%");

// Eşleşen commit'leri göster
var matchedCommits = gitRepo.Commits.Where(c => c.LinkedTaskId.HasValue).Take(10).ToList();

if (matchedCommits.Any())
{
    Console.WriteLine("\n┌─────────┬────────────────────────────────────┬────────────────────────────┬────────┐");
    Console.WriteLine("│ Commit  │ Mesaj                              │ Eşleşen Task               │ Skor   │");
    Console.WriteLine("├─────────┼────────────────────────────────────┼────────────────────────────┼────────┤");

    foreach (var commit in matchedCommits)
    {
        var msg = (commit.MessageFirstLine ?? "").Length > 32 
            ? commit.MessageFirstLine![..29] + "..." 
            : commit.MessageFirstLine ?? "";
        var taskName = (commit.LinkedTaskName ?? "").Length > 24 
            ? commit.LinkedTaskName![..21] + "..." 
            : commit.LinkedTaskName ?? "";
        
        Console.WriteLine($"│ {commit.ShortSha} │ {msg,-34} │ {taskName,-26} │ {commit.MatchScore,5:F1}% │");
    }

    Console.WriteLine("└─────────┴────────────────────────────────────┴────────────────────────────┴────────┘");
}

// Task bazlı commit özeti
Console.WriteLine("\n📋 Task Bazlı Commit Özeti:");
foreach (var task in tasks.Where(t => t.LinkedCommits.Any()).Take(5))
{
    Console.WriteLine($"   [{task.TaskId}] {task.TaskName}");
    Console.WriteLine($"       └─ {task.LinkedCommits.Count} commit bağlı");
}

// ═══════════════════════════════════════════════════════════════════════════════
// 9. PUNCH CARD (HEATMAP)
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                         🕐 PUNCH CARD (Aktivite Haritası)                  ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");

var punchCard = syncService.GetPunchCard(gitRepo);
var days = new[] { "Paz", "Pzt", "Sal", "Çar", "Per", "Cum", "Cmt" };

Console.WriteLine("\n         00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23");
Console.WriteLine("        ┌────────────────────────────────────────────────────────────────────────┐");

foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
{
    Console.Write($"   {days[(int)day]} │ ");
    for (int hour = 0; hour < 24; hour++)
    {
        var cell = punchCard.FirstOrDefault(c => c.Day == day && c.Hour == hour);
        var intensity = cell?.Intensity ?? 0;
        var symbol = intensity switch
        {
            0 => "░░",
            < 0.25 => "▒▒",
            < 0.5 => "▓▓",
            < 0.75 => "██",
            _ => "██"
        };
        Console.Write(symbol + " ");
    }
    Console.WriteLine("│");
}

Console.WriteLine("        └────────────────────────────────────────────────────────────────────────┘");
Console.WriteLine("         ░░ Yok  ▒▒ Az  ▓▓ Orta  ██ Yoğun");

// ═══════════════════════════════════════════════════════════════════════════════
// 10. HOTSPOTS (SIK DEĞİŞEN DOSYALAR)
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                         🔥 HOTSPOTS (Sık Değişen Dosyalar)                 ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");

var hotspots = syncService.GetHotspots(gitRepo, 10);

if (hotspots.Any())
{
    Console.WriteLine("\n┌────────────────────────────────────────────────────┬────────┬───────────┬────────┐");
    Console.WriteLine("│ Dosya                                              │ Değişim│ +/-       │ Risk   │");
    Console.WriteLine("├────────────────────────────────────────────────────┼────────┼───────────┼────────┤");

    foreach (var hotspot in hotspots)
    {
        var fileName = hotspot.FileName.Length > 46 
            ? "..." + hotspot.FileName[^43..] 
            : hotspot.FileName;
        var riskIcon = hotspot.RiskLevel switch { "High" => "🔴", "Medium" => "🟡", _ => "🟢" };
        
        Console.WriteLine($"│ {fileName,-50} │ {hotspot.ChangeCount,6} │ +{hotspot.TotalAdditions,-4}/-{hotspot.TotalDeletions,-3} │ {riskIcon}     │");
    }

    Console.WriteLine("└────────────────────────────────────────────────────┴────────┴───────────┴────────┘");
}
else
{
    Console.WriteLine("\n   Dosya değişikliği bilgisi bulunamadı.");
}

// ═══════════════════════════════════════════════════════════════════════════════
// 11. SON COMMIT'LER
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                              📝 SON COMMIT'LER                             ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");

Console.WriteLine("\n┌─────────┬────────────────────────────────────────────────┬──────────────────┐");
Console.WriteLine("│ SHA     │ Mesaj                                          │ Tarih            │");
Console.WriteLine("├─────────┼────────────────────────────────────────────────┼──────────────────┤");

foreach (var commit in gitRepo.Commits.Take(10))
{
    var msg = (commit.MessageFirstLine ?? "").Length > 44 
        ? commit.MessageFirstLine![..41] + "..." 
        : commit.MessageFirstLine ?? "";
    var date = commit.CommitDate.ToString("dd.MM.yy HH:mm");
    
    Console.WriteLine($"│ {commit.ShortSha} │ {msg,-46} │ {date,-16} │");
}

Console.WriteLine("└─────────┴────────────────────────────────────────────────┴──────────────────┘");

// ═══════════════════════════════════════════════════════════════════════════════
// 12. TOKEN HAVUZU DURUMU
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                           🔑 TOKEN HAVUZU DURUMU                           ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");

var finalPoolStatus = tokenPool.GetPoolStatus();

Console.WriteLine($"\n   Toplam Token: {finalPoolStatus.TotalTokens}");
Console.WriteLine($"   Aktif Token: {finalPoolStatus.ActiveTokens}");
Console.WriteLine($"   Kalan API Limit: {finalPoolStatus.TotalRateLimitRemaining}");

if (finalPoolStatus.Tokens.Any())
{
    Console.WriteLine("\n   Token Detayları:");
    foreach (var token in finalPoolStatus.Tokens)
    {
        var status = token.IsActive ? "✅" : "❌";
        Console.WriteLine($"   {status} {token.GitHubUsername}: {token.RateLimitRemaining} kalan");
    }
}

// ═══════════════════════════════════════════════════════════════════════════════
// ÖZET
// ═══════════════════════════════════════════════════════════════════════════════

Console.WriteLine("\n╔════════════════════════════════════════════════════════════════════════════╗");
Console.WriteLine("║                              ✅ TEST TAMAMLANDI                            ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════╝");

Console.WriteLine($@"
📊 Özet:
   • Repository: {gitRepo.RepoOwner}/{gitRepo.RepoName}
   • Toplam Commit: {gitRepo.TotalCommits}
   • Contributor: {gitRepo.TotalContributors}
   • Eşleşen Task: {matched}/{gitRepo.Commits.Count} commit
   • Senkronizasyon Süresi: {syncResult.Duration.TotalSeconds:F1}s

🎯 Bu yapı ProjectTracker'a entegre edilmeye hazır!
   • Token havuzu sistemi çalışıyor
   • Task-Commit eşleştirme (isim benzerliği) çalışıyor
   • Dashboard widget verileri hazır
   • Leaderboard ve analytics hazır
");
