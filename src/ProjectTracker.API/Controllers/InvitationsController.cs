using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTracker.API.Data;
using ProjectTracker.API.Models;

namespace ProjectTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationsController : ControllerBase
    {
        private readonly InvitationDbContext _context;

        public InvitationsController(InvitationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Validate invitation token and get details (Web sitesi için)
        /// </summary>
        [HttpGet("validate")]
        public async Task<IActionResult> ValidateInvitation([FromQuery] string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new { isValid = false, message = "Token gerekli." });
            }

            try
            {
                var invitation = await _context.Invitations
                    .FirstOrDefaultAsync(i => i.Token == token);

                if (invitation == null)
                {
                    return Ok(new { isValid = false, message = "Davet bulunamadı." });
                }

                if (invitation.Status != "Pending")
                {
                    return Ok(new { isValid = false, message = "Bu davet zaten kullanılmış veya iptal edilmiş." });
                }

                if (invitation.ExpiresAt < DateTime.Now)
                {
                    return Ok(new { isValid = false, message = "Bu davetin süresi dolmuş." });
                }

                return Ok(new
                {
                    isValid = true,
                    teamName = invitation.TeamName,
                    invitedBy = invitation.InvitedByName,
                    proposedRole = invitation.ProposedRole,
                    expiresAt = invitation.ExpiresAt,
                    email = invitation.Email
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { isValid = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        /// <summary>
        /// Create invitation (WinForms'tan çağrılır)
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> CreateInvitation([FromBody] CreateInvitationRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Token))
            {
                return BadRequest(new { success = false, message = "Geçersiz istek." });
            }

            try
            {
                // Check if token already exists
                var existing = await _context.Invitations
                    .FirstOrDefaultAsync(i => i.Token == request.Token);

                if (existing != null)
                {
                    return Ok(new { success = true, message = "Davet zaten mevcut." });
                }

                var invitation = new InvitationModel
                {
                    Token = request.Token,
                    Email = request.Email,
                    TeamName = request.TeamName,
                    InvitedByName = request.InvitedByName,
                    ProposedRole = request.ProposedRole,
                    Status = "Pending",
                    SentAt = DateTime.Now,
                    ExpiresAt = request.ExpiresAt
                };

                _context.Invitations.Add(invitation);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Davet oluşturuldu.", id = invitation.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        /// <summary>
        /// Accept invitation (Web sitesinden çağrılır)
        /// </summary>
        [HttpPost("accept")]
        public async Task<IActionResult> AcceptInvitation([FromBody] TokenRequest request)
        {
            if (string.IsNullOrEmpty(request?.Token))
            {
                return BadRequest(new { success = false, message = "Token gerekli." });
            }

            try
            {
                var invitation = await _context.Invitations
                    .FirstOrDefaultAsync(i => i.Token == request.Token);

                if (invitation == null)
                {
                    return Ok(new { success = false, message = "Davet bulunamadı." });
                }

                if (invitation.Status != "Pending")
                {
                    return Ok(new { success = false, message = "Bu davet zaten kullanılmış." });
                }

                if (invitation.ExpiresAt < DateTime.Now)
                {
                    return Ok(new { success = false, message = "Bu davetin süresi dolmuş." });
                }

                invitation.Status = "Accepted";
                invitation.RespondedAt = DateTime.Now;
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Davet kabul edildi! Uygulamayı indirip giriş yapabilirsiniz.",
                    email = invitation.Email
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        /// <summary>
        /// Decline invitation (Web sitesinden çağrılır)
        /// </summary>
        [HttpPost("decline")]
        public async Task<IActionResult> DeclineInvitation([FromBody] TokenRequest request)
        {
            if (string.IsNullOrEmpty(request?.Token))
            {
                return BadRequest(new { success = false, message = "Token gerekli." });
            }

            try
            {
                var invitation = await _context.Invitations
                    .FirstOrDefaultAsync(i => i.Token == request.Token);

                if (invitation == null)
                {
                    return Ok(new { success = false, message = "Davet bulunamadı." });
                }

                invitation.Status = "Declined";
                invitation.RespondedAt = DateTime.Now;
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Davet reddedildi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        /// <summary>
        /// Health check endpoint
        /// </summary>
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok(new { status = "OK", timestamp = DateTime.Now });
        }
    }

    public class TokenRequest
    {
        public string? Token { get; set; }
    }
}
