namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Represents a risk analysis record for a project (Smart Algorithm output)
    /// </summary>
    public class ProjectRisk
    {
        /// <summary>
        /// Primary key - Unique identifier
        /// </summary>
        public int RiskId { get; set; }

        /// <summary>
        /// Foreign key - Project being analyzed
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Calculated risk score (0-100) by Smart Algorithm
        /// </summary>
        public decimal RiskScore { get; set; }

        /// <summary>
        /// Risk level (Low, Medium, High)
        /// </summary>
        public string RiskLevel { get; set; } = "Medium";

        /// <summary>
        /// Factors contributing to risk (JSON or text)
        /// </summary>
        public string? RiskFactors { get; set; }

        /// <summary>
        /// Recommended actions to mitigate risk
        /// </summary>
        public string? Recommendations { get; set; }

        /// <summary>
        /// When was this risk analysis performed?
        /// </summary>
        public DateTime AnalyzedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Navigation property - Project
        /// </summary>
        public virtual Project Project { get; set; } = null!;
    }
}