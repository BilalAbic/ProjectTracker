using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using ProjectTracker.Business.Interfaces;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// Email service implementation using SMTP
    /// Sends beautifully formatted HTML emails for notifications
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _fromEmail;
        private readonly string _fromName;
        private readonly bool _enableSsl;
        private readonly bool _isEnabled;
        private readonly string _invitationBaseUrl;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            
            // Load SMTP settings from configuration
            _smtpHost = _configuration["Email:SmtpHost"] ?? "smtp.gmail.com";
            _smtpPort = int.Parse(_configuration["Email:SmtpPort"] ?? "587");
            _smtpUsername = _configuration["Email:Username"] ?? "";
            _smtpPassword = _configuration["Email:Password"] ?? "";
            _fromEmail = _configuration["Email:FromEmail"] ?? "noreply@projecttracker.com";
            _fromName = _configuration["Email:FromName"] ?? "ProjectTracker";
            _enableSsl = bool.Parse(_configuration["Email:EnableSsl"] ?? "true");
            _isEnabled = bool.Parse(_configuration["Email:Enabled"] ?? "false");
            _invitationBaseUrl = _configuration["AppSettings:InvitationBaseUrl"] ?? "https://projecttracker.com/accept-invite.html";
        }

        /// <summary>
        /// Send task assignment notification email
        /// </summary>
        public async Task SendTaskAssignmentEmailAsync(
            string toEmail, 
            string toName, 
            string taskName, 
            string projectName, 
            string assignedBy, 
            DateTime? dueDate, 
            string? description)
        {
            var subject = $"📋 New Task Assigned: {taskName}";
            var dueDateText = dueDate.HasValue ? dueDate.Value.ToString("dd MMM yyyy") : "No due date";
            
            var htmlBody = GetEmailTemplate(
                title: "New Task Assigned",
                emoji: "📋",
                accentColor: "#5B8DEF",
                content: $@"
                    <p style='font-size: 16px; color: #374151; margin-bottom: 20px;'>
                        Hi <strong>{toName}</strong>,
                    </p>
                    <p style='font-size: 16px; color: #374151; margin-bottom: 24px;'>
                        You have been assigned a new task by <strong>{assignedBy}</strong>.
                    </p>
                    
                    <div style='background: linear-gradient(135deg, #f0f9ff 0%, #e0f2fe 100%); border-radius: 12px; padding: 24px; margin-bottom: 24px; border-left: 4px solid #5B8DEF;'>
                        <h2 style='margin: 0 0 16px 0; color: #1e40af; font-size: 20px;'>📌 {taskName}</h2>
                        
                        <table style='width: 100%; border-collapse: collapse;'>
                            <tr>
                                <td style='padding: 8px 0; color: #6b7280; width: 120px;'>📁 Project:</td>
                                <td style='padding: 8px 0; color: #1f2937; font-weight: 600;'>{projectName}</td>
                            </tr>
                            <tr>
                                <td style='padding: 8px 0; color: #6b7280;'>📅 Due Date:</td>
                                <td style='padding: 8px 0; color: #1f2937; font-weight: 600;'>{dueDateText}</td>
                            </tr>
                            <tr>
                                <td style='padding: 8px 0; color: #6b7280;'>👤 Assigned By:</td>
                                <td style='padding: 8px 0; color: #1f2937; font-weight: 600;'>{assignedBy}</td>
                            </tr>
                        </table>
                        
                        {(string.IsNullOrEmpty(description) ? "" : $@"
                        <div style='margin-top: 16px; padding-top: 16px; border-top: 1px solid #bfdbfe;'>
                            <p style='color: #6b7280; margin: 0 0 8px 0; font-size: 14px;'>📝 Description:</p>
                            <p style='color: #374151; margin: 0; line-height: 1.6;'>{description}</p>
                        </div>")}
                    </div>
                    
                    <div style='text-align: center;'>
                        <a href='#' style='display: inline-block; background: linear-gradient(135deg, #5B8DEF 0%, #4A6FD4 100%); color: white; padding: 14px 32px; border-radius: 8px; text-decoration: none; font-weight: 600; font-size: 16px; box-shadow: 0 4px 14px rgba(91, 141, 239, 0.4);'>
                            View Task Details →
                        </a>
                    </div>",
                footerText: "You received this email because a task was assigned to you."
            );

            await SendEmailAsync(toEmail, subject, htmlBody);
        }

        /// <summary>
        /// Send team invitation email
        /// </summary>
        public async Task SendTeamInvitationEmailAsync(
            string toEmail, 
            string teamName, 
            string invitedByName, 
            string role, 
            string invitationToken, 
            DateTime expiresAt)
        {
            var subject = $"🎉 You're Invited to Join {teamName}!";
            var expiresIn = (expiresAt - DateTime.Now).Days;
            var inviteLink = $"{_invitationBaseUrl}?token={invitationToken}";
            
            var htmlBody = GetEmailTemplate(
                title: "Team Invitation",
                emoji: "🎉",
                accentColor: "#10B981",
                content: $@"
                    <p style='font-size: 16px; color: #374151; margin-bottom: 20px;'>
                        Hello,
                    </p>
                    <p style='font-size: 16px; color: #374151; margin-bottom: 24px;'>
                        <strong>{invitedByName}</strong> has invited you to join their team on ProjectTracker!
                    </p>
                    
                    <div style='background: linear-gradient(135deg, #ecfdf5 0%, #d1fae5 100%); border-radius: 12px; padding: 24px; margin-bottom: 24px; border-left: 4px solid #10B981; text-align: center;'>
                        <div style='font-size: 48px; margin-bottom: 12px;'>👥</div>
                        <h2 style='margin: 0 0 8px 0; color: #065f46; font-size: 24px;'>{teamName}</h2>
                        <p style='margin: 0; color: #047857; font-size: 16px;'>
                            Your Role: <span style='background: #10B981; color: white; padding: 4px 12px; border-radius: 20px; font-weight: 600;'>{role}</span>
                        </p>
                    </div>
                    
                    <div style='text-align: center; margin-bottom: 24px;'>
                        <a href='{inviteLink}' style='display: inline-block; background: linear-gradient(135deg, #10B981 0%, #059669 100%); color: white; padding: 16px 40px; border-radius: 8px; text-decoration: none; font-weight: 600; font-size: 18px; box-shadow: 0 4px 14px rgba(16, 185, 129, 0.4);'>
                            ✨ Accept Invitation
                        </a>
                    </div>
                    
                    <div style='background: #fef3c7; border-radius: 8px; padding: 16px; text-align: center;'>
                        <p style='margin: 0; color: #92400e; font-size: 14px;'>
                            ⏰ This invitation expires in <strong>{expiresIn} days</strong> ({expiresAt:dd MMM yyyy})
                        </p>
                    </div>
                    
                    <p style='font-size: 14px; color: #6b7280; margin-top: 24px; text-align: center;'>
                        If the button doesn't work, copy and paste this link:<br/>
                        <span style='color: #5B8DEF; word-break: break-all;'>{inviteLink}</span>
                    </p>",
                footerText: "You received this email because someone invited you to join their team."
            );

            await SendEmailAsync(toEmail, subject, htmlBody);
        }

        /// <summary>
        /// Send task status update notification
        /// </summary>
        public async Task SendTaskStatusUpdateEmailAsync(
            string toEmail, 
            string toName, 
            string taskName, 
            string projectName, 
            string oldStatus, 
            string newStatus)
        {
            var subject = $"📊 Task Status Updated: {taskName}";
            var (statusEmoji, statusColor) = GetStatusStyle(newStatus);
            
            var htmlBody = GetEmailTemplate(
                title: "Task Status Updated",
                emoji: "📊",
                accentColor: statusColor,
                content: $@"
                    <p style='font-size: 16px; color: #374151; margin-bottom: 20px;'>
                        Hi <strong>{toName}</strong>,
                    </p>
                    <p style='font-size: 16px; color: #374151; margin-bottom: 24px;'>
                        The status of your task has been updated.
                    </p>
                    
                    <div style='background: #f9fafb; border-radius: 12px; padding: 24px; margin-bottom: 24px;'>
                        <h2 style='margin: 0 0 16px 0; color: #1f2937; font-size: 18px;'>📌 {taskName}</h2>
                        <p style='margin: 0 0 16px 0; color: #6b7280;'>Project: <strong>{projectName}</strong></p>
                        
                        <div style='display: flex; align-items: center; justify-content: center; gap: 20px;'>
                            <div style='text-align: center;'>
                                <p style='margin: 0 0 8px 0; color: #9ca3af; font-size: 12px; text-transform: uppercase;'>Previous</p>
                                <span style='background: #e5e7eb; color: #374151; padding: 8px 16px; border-radius: 20px; font-weight: 600;'>{oldStatus}</span>
                            </div>
                            <div style='font-size: 24px;'>→</div>
                            <div style='text-align: center;'>
                                <p style='margin: 0 0 8px 0; color: #9ca3af; font-size: 12px; text-transform: uppercase;'>Current</p>
                                <span style='background: {statusColor}; color: white; padding: 8px 16px; border-radius: 20px; font-weight: 600;'>{statusEmoji} {newStatus}</span>
                            </div>
                        </div>
                    </div>
                    
                    <div style='text-align: center;'>
                        <a href='#' style='display: inline-block; background: linear-gradient(135deg, #5B8DEF 0%, #4A6FD4 100%); color: white; padding: 14px 32px; border-radius: 8px; text-decoration: none; font-weight: 600; font-size: 16px;'>
                            View Task →
                        </a>
                    </div>",
                footerText: "You received this email because you are assigned to this task."
            );

            await SendEmailAsync(toEmail, subject, htmlBody);
        }

        /// <summary>
        /// Send generic email
        /// </summary>
        public async Task SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            if (!_isEnabled)
            {
                System.Diagnostics.Debug.WriteLine($"📧 EMAIL (Disabled): To={toEmail}, Subject={subject}");
                return;
            }

            if (string.IsNullOrEmpty(_smtpUsername) || string.IsNullOrEmpty(_smtpPassword))
            {
                System.Diagnostics.Debug.WriteLine($"📧 EMAIL (No credentials): To={toEmail}, Subject={subject}");
                return;
            }

            try
            {
                using var client = new SmtpClient(_smtpHost, _smtpPort)
                {
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = _enableSsl
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_fromEmail, _fromName),
                    Subject = subject,
                    Body = htmlBody,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
                System.Diagnostics.Debug.WriteLine($"✅ EMAIL SENT: To={toEmail}, Subject={subject}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ EMAIL ERROR: {ex.Message}");
                // Don't throw - email failures shouldn't break the application
            }
        }

        /// <summary>
        /// Get beautiful HTML email template
        /// </summary>
        private string GetEmailTemplate(string title, string emoji, string accentColor, string content, string footerText)
        {
            return $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>{title}</title>
</head>
<body style='margin: 0; padding: 0; font-family: -apple-system, BlinkMacSystemFont, ""Segoe UI"", Roboto, ""Helvetica Neue"", Arial, sans-serif; background-color: #f3f4f6;'>
    <table role='presentation' style='width: 100%; border-collapse: collapse;'>
        <tr>
            <td style='padding: 40px 20px;'>
                <table role='presentation' style='max-width: 600px; margin: 0 auto; background: white; border-radius: 16px; overflow: hidden; box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);'>
                    
                    <!-- Header -->
                    <tr>
                        <td style='background: linear-gradient(135deg, {accentColor} 0%, {DarkenColor(accentColor)} 100%); padding: 32px 40px; text-align: center;'>
                            <div style='font-size: 48px; margin-bottom: 12px;'>{emoji}</div>
                            <h1 style='margin: 0; color: white; font-size: 24px; font-weight: 700;'>{title}</h1>
                        </td>
                    </tr>
                    
                    <!-- Content -->
                    <tr>
                        <td style='padding: 40px;'>
                            {content}
                        </td>
                    </tr>
                    
                    <!-- Footer -->
                    <tr>
                        <td style='background: #f9fafb; padding: 24px 40px; border-top: 1px solid #e5e7eb;'>
                            <table role='presentation' style='width: 100%;'>
                                <tr>
                                    <td style='text-align: center;'>
                                        <p style='margin: 0 0 12px 0; color: #6b7280; font-size: 14px;'>{footerText}</p>
                                        <p style='margin: 0; color: #9ca3af; font-size: 12px;'>
                                            © {DateTime.Now.Year} ProjectTracker. All rights reserved.
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                </table>
                
                <!-- Unsubscribe -->
                <table role='presentation' style='max-width: 600px; margin: 20px auto 0;'>
                    <tr>
                        <td style='text-align: center;'>
                            <p style='margin: 0; color: #9ca3af; font-size: 12px;'>
                                <a href='#' style='color: #6b7280; text-decoration: underline;'>Unsubscribe</a> · 
                                <a href='#' style='color: #6b7280; text-decoration: underline;'>Email Preferences</a>
                            </p>
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
</body>
</html>";
        }

        /// <summary>
        /// Darken a hex color for gradient effect
        /// </summary>
        private string DarkenColor(string hexColor)
        {
            // Simple darkening - reduce each RGB component by 20%
            if (hexColor.StartsWith("#") && hexColor.Length == 7)
            {
                var r = Convert.ToInt32(hexColor.Substring(1, 2), 16);
                var g = Convert.ToInt32(hexColor.Substring(3, 2), 16);
                var b = Convert.ToInt32(hexColor.Substring(5, 2), 16);
                
                r = (int)(r * 0.8);
                g = (int)(g * 0.8);
                b = (int)(b * 0.8);
                
                return $"#{r:X2}{g:X2}{b:X2}";
            }
            return hexColor;
        }

        /// <summary>
        /// Get status emoji and color
        /// </summary>
        private (string emoji, string color) GetStatusStyle(string status)
        {
            return status.ToLower() switch
            {
                "completed" => ("✅", "#10B981"),
                "inprogress" => ("🔄", "#F59E0B"),
                "pending" => ("⏳", "#6B7280"),
                "blocked" => ("🚫", "#EF4444"),
                "cancelled" => ("❌", "#EF4444"),
                _ => ("📋", "#5B8DEF")
            };
        }
    }
}
