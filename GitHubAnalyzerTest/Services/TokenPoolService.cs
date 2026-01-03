using Octokit;
using GitHubAnalyzerTest.Models;

namespace GitHubAnalyzerTest.Services;

/// <summary>
/// Token Havuzu Servisi
/// Birden fazla kullanıcının token'larını yönetir ve en uygun olanı seçer
/// </summary>
public class TokenPoolService
{
    private readonly List<GitHubToken> _tokenPool = new();
    private int _nextTokenId = 1;

    /// <summary>
    /// Havuza yeni token ekler (kullanıcı ayarlarından gelecek)
    /// </summary>
    public async Task<GitHubToken> AddTokenAsync(int userId, string githubUsername, string token)
    {
        var newToken = new GitHubToken
        {
            TokenId = _nextTokenId++,
            UserId = userId,
            GitHubUsername = githubUsername,
            Token = token,
            IsActive = true,
            CreatedAt = DateTime.Now
        };

        // Token'ın geçerliliğini ve rate limit'ini kontrol et
        try
        {
            var client = new GitHubClient(new ProductHeaderValue("ProjectTracker-Test"));
            client.Credentials = new Credentials(token);
            
            var rateLimit = await client.RateLimit.GetRateLimits();
            newToken.RateLimitRemaining = rateLimit.Resources.Core.Remaining;
            newToken.RateLimitResetAt = rateLimit.Resources.Core.Reset.DateTime;
            newToken.IsActive = true;
            
            Console.WriteLine($"   ✅ Token eklendi: {githubUsername} (Limit: {newToken.RateLimitRemaining})");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"   ⚠️ Token doğrulanamadı: {ex.Message}");
            newToken.IsActive = false;
        }

        _tokenPool.Add(newToken);
        return newToken;
    }

    /// <summary>
    /// Token'ı havuzdan kaldırır
    /// </summary>
    public bool RemoveToken(int tokenId)
    {
        var token = _tokenPool.FirstOrDefault(t => t.TokenId == tokenId);
        if (token != null)
        {
            _tokenPool.Remove(token);
            return true;
        }
        return false;
    }

    /// <summary>
    /// En uygun token'ı seçer (en yüksek rate limit)
    /// </summary>
    public GitHubToken? GetBestAvailableToken()
    {
        var now = DateTime.UtcNow;
        
        // Aktif ve rate limit'i olan veya reset olmuş token'ları filtrele
        var availableTokens = _tokenPool
            .Where(t => t.IsActive && 
                       (t.RateLimitRemaining > 10 || 
                        (t.RateLimitResetAt.HasValue && t.RateLimitResetAt.Value < now)))
            .OrderByDescending(t => t.RateLimitRemaining)
            .ThenBy(t => t.LastUsedAt)
            .ToList();

        return availableTokens.FirstOrDefault();
    }

    /// <summary>
    /// Token kullanıldıktan sonra rate limit bilgisini günceller
    /// </summary>
    public void UpdateTokenRateLimit(int tokenId, int remaining, DateTime resetAt)
    {
        var token = _tokenPool.FirstOrDefault(t => t.TokenId == tokenId);
        if (token != null)
        {
            token.RateLimitRemaining = remaining;
            token.RateLimitResetAt = resetAt;
            token.LastUsedAt = DateTime.Now;
        }
    }

    /// <summary>
    /// Havuz durumunu döndürür
    /// </summary>
    public TokenPoolStatus GetPoolStatus()
    {
        return new TokenPoolStatus
        {
            TotalTokens = _tokenPool.Count,
            ActiveTokens = _tokenPool.Count(t => t.IsActive),
            TotalRateLimitRemaining = _tokenPool.Where(t => t.IsActive).Sum(t => t.RateLimitRemaining),
            NextResetAt = _tokenPool.Where(t => t.RateLimitResetAt.HasValue)
                                    .OrderBy(t => t.RateLimitResetAt)
                                    .FirstOrDefault()?.RateLimitResetAt,
            Tokens = _tokenPool.Select(t => new TokenStatus
            {
                GitHubUsername = t.GitHubUsername ?? "unknown",
                RateLimitRemaining = t.RateLimitRemaining,
                ResetAt = t.RateLimitResetAt,
                IsActive = t.IsActive
            }).ToList()
        };
    }

    /// <summary>
    /// Tüm token'ların rate limit'ini günceller
    /// </summary>
    public async Task RefreshAllTokenLimitsAsync()
    {
        foreach (var token in _tokenPool.Where(t => t.IsActive))
        {
            try
            {
                var client = new GitHubClient(new ProductHeaderValue("ProjectTracker-Test"));
                client.Credentials = new Credentials(token.Token);
                
                var rateLimit = await client.RateLimit.GetRateLimits();
                token.RateLimitRemaining = rateLimit.Resources.Core.Remaining;
                token.RateLimitResetAt = rateLimit.Resources.Core.Reset.DateTime;
            }
            catch
            {
                token.IsActive = false;
            }
        }
    }

    /// <summary>
    /// Belirli bir kullanıcının token'ını döndürür
    /// </summary>
    public GitHubToken? GetUserToken(int userId)
    {
        return _tokenPool.FirstOrDefault(t => t.UserId == userId);
    }

    /// <summary>
    /// Tüm token'ları listeler
    /// </summary>
    public List<GitHubToken> GetAllTokens()
    {
        return _tokenPool.ToList();
    }
}
