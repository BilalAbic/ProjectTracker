namespace ProjectTracker.Business.DTOs.Analytics
{
    /// <summary>
    /// Burndown chart için tek bir data point
    /// Her gün için ideal vs actual remaining hours
    /// </summary>
    public class BurndownDataPoint
    {
        /// <summary>
        /// Tarih (X ekseni)
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Gerçekleşen kalan saat (Actual trend)
        /// Incomplete task'ların EstimatedHours toplamı
        /// </summary>
        public decimal ActualRemainingHours { get; set; }
        
        /// <summary>
        /// İdeal kalan saat (Linear burndown trend)
        /// Başlangıç hours - (daily burn rate × elapsed days)
        /// </summary>
        public decimal IdealRemainingHours { get; set; }
        
        /// <summary>
        /// O gün tamamlanan task sayısı
        /// </summary>
        public int TasksCompleted { get; set; }
    }
}
