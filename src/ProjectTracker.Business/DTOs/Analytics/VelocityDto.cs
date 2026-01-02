using System.Collections.Generic;

namespace ProjectTracker.Business.DTOs.Analytics
{
    /// <summary>
    /// Team velocity DTO - Takımın haftalık üretkenlik trendi
    /// </summary>
    public class VelocityDto
    {
        /// <summary>
        /// Takım ID
        /// </summary>
        public int TeamId { get; set; }
        
        /// <summary>
        /// Takım adı
        /// </summary>
        public string TeamName { get; set; } = string.Empty;
        
        /// <summary>
        /// Haftalık velocity data points
        /// </summary>
        public List<VelocityDataPoint> WeeklyVelocity { get; set; } = new();
        
        /// <summary>
        /// Ortalama velocity (son N hafta)
        /// Average(WeeklyVelocity.CompletedHours)
        /// </summary>
        public decimal AverageVelocity { get; set; }
        
        /// <summary>
        /// Minimum velocity (en düşük hafta)
        /// </summary>
        public decimal MinVelocity { get; set; }
        
        /// <summary>
        /// Maximum velocity (en yüksek hafta)
        /// </summary>
        public decimal MaxVelocity { get; set; }
        
        /// <summary>
        /// Trend analizi
        /// "Increasing" - Son haftalar ortalamanın üstünde
        /// "Decreasing" - Son haftalar ortalamanının altında
        /// "Stable" - Stabil
        /// </summary>
        public string Trend { get; set; } = "Stable";
    }
}
