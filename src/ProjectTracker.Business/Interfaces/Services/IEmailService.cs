namespace ProjectTracker.Business.Interfaces
{
    /// <summary>
    /// Email service interface for sending notifications
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Send task assignment notification
        /// </summary>
        Task SendTaskAssignmentEmailAsync(string toEmail, string toName, string taskName, string projectName, string assignedBy, DateTime? dueDate, string? description);
        
        /// <summary>
        /// Send team invitation email
        /// </summary>
        Task SendTeamInvitationEmailAsync(string toEmail, string teamName, string invitedByName, string role, string invitationToken, DateTime expiresAt);
        
        /// <summary>
        /// Send task status update notification
        /// </summary>
        Task SendTaskStatusUpdateEmailAsync(string toEmail, string toName, string taskName, string projectName, string oldStatus, string newStatus);
        
        /// <summary>
        /// Send generic email
        /// </summary>
        Task SendEmailAsync(string toEmail, string subject, string htmlBody);
    }
}
