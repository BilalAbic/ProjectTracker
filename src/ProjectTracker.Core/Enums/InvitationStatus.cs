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
