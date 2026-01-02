using System.Collections.Generic;

namespace ProjectTracker.Business.DTOs.Analytics
{
    /// <summary>
    /// Burndown chart DTO - Proje için ideal vs actual burndown trendi
    /// </summary>
    public class BurndownChartDto
    {
        /// <summary>
        /// Proje ID
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// Proje adı
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;
        
        /// <summary>
        /// Günlük data points (Date, Actual, Ideal)
        /// </summary>
        public List<BurndownDataPoint> DataPoints { get; set; } = new();
        
        /// <summary>
        /// Proje başlangıç tarihi
        /// </summary>
        public DateTime ProjectStartDate { get; set; }
        
        /// <summary>
        /// Proje bitiş tarihi (planlanan)
        /// </summary>
        public DateTime ProjectEndDate { get; set; }
        
        /// <summary>
        /// Başlangıçta toplam planlı saat
        /// </summary>
        public decimal InitialPlannedHours { get; set; }
        
        /// <summary>
        /// Şu anki kalan saat
        /// </summary>
        public decimal CurrentRemainingHours { get; set; }
    }
}
