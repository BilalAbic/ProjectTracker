using GitHubAnalyzerTest.Models;

namespace GitHubAnalyzerTest.Services;

/// <summary>
/// Task-Commit Eşleştirme Servisi
/// Commit mesajları ile Task isimleri arasında benzerlik analizi yapar
/// </summary>
public class TaskMatchingService
{
    private const double MinMatchScore = 30.0;  // Minimum eşleşme skoru

    /// <summary>
    /// Commit'leri Task'larla eşleştirir
    /// </summary>
    public List<TaskCommitMatchDto> MatchCommitsToTasks(List<GitCommit> commits, List<ProjectTask> tasks)
    {
        var matches = new List<TaskCommitMatchDto>();

        foreach (var commit in commits)
        {
            if (string.IsNullOrEmpty(commit.Message)) continue;

            var bestMatch = FindBestTaskMatch(commit, tasks);
            if (bestMatch != null)
            {
                matches.Add(bestMatch);
                
                // Commit'e eşleşmeyi kaydet
                commit.LinkedTaskId = bestMatch.TaskId;
                commit.LinkedTaskName = bestMatch.TaskName;
                commit.MatchScore = bestMatch.MatchScore;
            }
        }

        return matches;
    }

    /// <summary>
    /// Bir commit için en iyi task eşleşmesini bulur
    /// </summary>
    private TaskCommitMatchDto? FindBestTaskMatch(GitCommit commit, List<ProjectTask> tasks)
    {
        TaskCommitMatchDto? bestMatch = null;
        double bestScore = 0;

        foreach (var task in tasks)
        {
            var (score, reason) = CalculateMatchScore(commit.Message!, task.TaskName, task.Description);
            
            if (score > bestScore && score >= MinMatchScore)
            {
                bestScore = score;
                bestMatch = new TaskCommitMatchDto
                {
                    TaskId = task.TaskId,
                    TaskName = task.TaskName,
                    CommitSha = commit.ShortSha,
                    CommitMessage = commit.MessageFirstLine ?? "",
                    MatchScore = score,
                    MatchReason = reason
                };
            }
        }

        return bestMatch;
    }

    /// <summary>
    /// Commit mesajı ile Task arasındaki benzerlik skorunu hesaplar
    /// </summary>
    private (double score, string reason) CalculateMatchScore(string commitMessage, string taskName, string? taskDescription)
    {
        var reasons = new List<string>();
        double totalScore = 0;

        // Commit mesajını normalize et
        var normalizedCommit = NormalizeText(commitMessage);
        var normalizedTaskName = NormalizeText(taskName);
        var normalizedTaskDesc = NormalizeText(taskDescription ?? "");

        // 1. Tam eşleşme kontrolü (Task adı commit'te geçiyor mu?)
        if (normalizedCommit.Contains(normalizedTaskName))
        {
            totalScore += 50;
            reasons.Add("Task adı commit'te geçiyor");
        }

        // 2. Kelime bazlı eşleşme
        var commitWords = GetSignificantWords(normalizedCommit);
        var taskWords = GetSignificantWords(normalizedTaskName);
        var descWords = GetSignificantWords(normalizedTaskDesc);

        var matchingTaskWords = commitWords.Intersect(taskWords).Count();
        var matchingDescWords = commitWords.Intersect(descWords).Count();

        if (matchingTaskWords > 0)
        {
            var wordScore = (double)matchingTaskWords / taskWords.Count * 30;
            totalScore += wordScore;
            reasons.Add($"{matchingTaskWords} kelime eşleşti (task adı)");
        }

        if (matchingDescWords > 0)
        {
            var descScore = (double)matchingDescWords / Math.Max(descWords.Count, 1) * 15;
            totalScore += descScore;
            reasons.Add($"{matchingDescWords} kelime eşleşti (açıklama)");
        }

        // 3. Anahtar kelime eşleşmesi
        var keywordScore = CheckKeywordMatch(normalizedCommit, normalizedTaskName);
        if (keywordScore > 0)
        {
            totalScore += keywordScore;
            reasons.Add("Anahtar kelime eşleşmesi");
        }

        // 4. Levenshtein benzerliği (fuzzy matching)
        var similarity = CalculateSimilarity(normalizedCommit, normalizedTaskName);
        if (similarity > 0.5)
        {
            var simScore = similarity * 20;
            totalScore += simScore;
            reasons.Add($"Metin benzerliği: %{similarity * 100:F0}");
        }

        return (Math.Min(totalScore, 100), string.Join(", ", reasons));
    }

    /// <summary>
    /// Metni normalize eder (küçük harf, özel karakterleri kaldır)
    /// </summary>
    private string NormalizeText(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        
        return text.ToLowerInvariant()
                   .Replace("-", " ")
                   .Replace("_", " ")
                   .Replace(".", " ")
                   .Replace(",", " ")
                   .Replace(":", " ")
                   .Replace(";", " ")
                   .Replace("(", " ")
                   .Replace(")", " ")
                   .Replace("[", " ")
                   .Replace("]", " ")
                   .Replace("#", " ");
    }

    /// <summary>
    /// Anlamlı kelimeleri çıkarır (stop words hariç)
    /// </summary>
    private HashSet<string> GetSignificantWords(string text)
    {
        var stopWords = new HashSet<string> 
        { 
            "the", "a", "an", "is", "are", "was", "were", "be", "been", "being",
            "have", "has", "had", "do", "does", "did", "will", "would", "could", "should",
            "may", "might", "must", "shall", "can", "need", "dare", "ought", "used",
            "to", "of", "in", "for", "on", "with", "at", "by", "from", "as", "into",
            "through", "during", "before", "after", "above", "below", "between",
            "and", "but", "or", "nor", "so", "yet", "both", "either", "neither",
            "not", "only", "own", "same", "than", "too", "very", "just",
            "this", "that", "these", "those", "it", "its",
            // Türkçe stop words
            "ve", "ile", "için", "bir", "bu", "şu", "o", "da", "de", "mi", "mu",
            "olan", "olarak", "gibi", "kadar", "daha", "en", "çok", "az"
        };

        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Where(w => w.Length > 2 && !stopWords.Contains(w))
                   .ToHashSet();
    }

    /// <summary>
    /// Anahtar kelime eşleşmesi kontrol eder
    /// </summary>
    private double CheckKeywordMatch(string commit, string task)
    {
        var keywords = new Dictionary<string, string[]>
        {
            { "fix", new[] { "bug", "hata", "düzelt", "fix", "repair", "solve" } },
            { "add", new[] { "ekle", "add", "create", "oluştur", "yeni", "new" } },
            { "update", new[] { "güncelle", "update", "modify", "değiştir", "change" } },
            { "delete", new[] { "sil", "delete", "remove", "kaldır" } },
            { "refactor", new[] { "refactor", "düzenle", "iyileştir", "improve", "optimize" } },
            { "test", new[] { "test", "testing", "unit", "integration" } },
            { "ui", new[] { "ui", "arayüz", "form", "ekran", "screen", "design", "tasarım" } },
            { "api", new[] { "api", "endpoint", "service", "servis" } },
            { "auth", new[] { "login", "giriş", "auth", "authentication", "yetki", "permission" } },
            { "database", new[] { "database", "db", "veritabanı", "migration", "entity" } }
        };

        double score = 0;
        foreach (var category in keywords)
        {
            var commitHas = category.Value.Any(k => commit.Contains(k));
            var taskHas = category.Value.Any(k => task.Contains(k));
            
            if (commitHas && taskHas)
            {
                score += 10;
            }
        }

        return Math.Min(score, 20);
    }

    /// <summary>
    /// İki metin arasındaki benzerliği hesaplar (Jaccard similarity)
    /// </summary>
    private double CalculateSimilarity(string text1, string text2)
    {
        var words1 = GetSignificantWords(text1);
        var words2 = GetSignificantWords(text2);

        if (words1.Count == 0 || words2.Count == 0) return 0;

        var intersection = words1.Intersect(words2).Count();
        var union = words1.Union(words2).Count();

        return union > 0 ? (double)intersection / union : 0;
    }

    /// <summary>
    /// Task'a bağlı commit'leri gruplar
    /// </summary>
    public Dictionary<int, List<GitCommit>> GroupCommitsByTask(List<GitCommit> commits)
    {
        return commits
            .Where(c => c.LinkedTaskId.HasValue)
            .GroupBy(c => c.LinkedTaskId!.Value)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    /// <summary>
    /// Eşleşme istatistiklerini hesaplar
    /// </summary>
    public (int matched, int unmatched, double avgScore) GetMatchingStats(List<GitCommit> commits)
    {
        var matched = commits.Count(c => c.LinkedTaskId.HasValue);
        var unmatched = commits.Count - matched;
        var avgScore = commits.Where(c => c.LinkedTaskId.HasValue)
                              .Select(c => c.MatchScore)
                              .DefaultIfEmpty(0)
                              .Average();

        return (matched, unmatched, avgScore);
    }
}
