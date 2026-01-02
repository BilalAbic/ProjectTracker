namespace ProjectTracker.Business.DTOs.Analytics
{
    /// <summary>
    /// Velocity chart için tek bir haftalık data point
    /// </summary>
    public class VelocityDataPoint
    {
        /// <summary>
        /// Hafta numarası (ISO week number)
        /// </summary>
        public int WeekNumber { get; set; }
        
        /// <summary>
        /// Hafta başlangıç tarihi (Pazartesi)
        /// </summary>
        public DateTime WeekStartDate { get; set; }
        
        /// <summary>
        /// Hafta bitiş tarihi (Pazar)
        /// </summary>
        public DateTime WeekEndDate { get; set; }
        
        /// <summary>
        /// O hafta tamamlanan toplam saat
        /// Sum(CompletedTasks.ActualHours ?? EstimatedHours)
        /// </summary>
        public decimal CompletedHours { get; set; }
        
        /// <summary>
        /// O hafta tamamlanan task sayısı
        /// </summary>
        public int CompletedTasksCount { get; set; }
    }
}
