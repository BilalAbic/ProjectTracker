namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Her gün proje durumunun anlık görüntüsünü saklar
    /// Burndown/Burnup chart ve trend analysis için kullanılır
    /// </summary>
    public class ProjectSnapshot
    {
        /// <summary>
        /// Primary key - Unique identifier
        /// </summary>
        public int SnapshotId { get; set; }
        
        /// <summary>
        /// Foreign key - Snapshot alınan proje
        /// </summary>
        public int ProjectId { get; set; }
        
        /// <summary>
        /// Snapshot tarihi (gün sonu, 23:59)
        /// </summary>
        public DateTime SnapshotDate { get; set; }
        
        /// <summary>
        /// O gün açık olan (incomplete) task sayısı
        /// </summary>
        public int OpenTasksCount { get; set; }
        
        /// <summary>
        /// O gün kapatılan task sayısı (kümülatif - başlangıçtan itibaren)
        /// </summary>
        public int CompletedTasksCount { get; set; }
        
        /// <summary>
        /// Kalan planlı saat (Burndown chart için)
        /// Tüm incomplete task'ların EstimatedHours toplamı
        /// </summary>
        public decimal RemainingHours { get; set; }
        
        /// <summary>
        /// İdeal kalan saat (Linear burndown trend)
        /// Başlangıç hours / toplam gün sayısı * kalan gün
        /// </summary>
        public decimal IdealRemainingHours { get; set; }
        
        /// <summary>
        /// O güne kadar harcanan toplam bütçe (kümülatif)
        /// TimeEntry bazlı hesaplama: Sum(HoursSpent * UserHourlyCost)
        /// </summary>
        public decimal BurnedBudget { get; set; }
        
        /// <summary>
        /// Planlanan değer - Planned Value (EVM)
        /// O güne kadar planlanmış iş miktarı
        /// </summary>
        public decimal PlannedValue { get; set; }
        
        /// <summary>
        /// Kazanılan değer - Earned Value (EVM)
        /// O güne kadar tamamlanan işin değeri
        /// </summary>
        public decimal EarnedValue { get; set; }
        
        /// <summary>
        /// Snapshot oluşturulma zamanı
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // Navigation Property
        
        /// <summary>
        /// Navigation property - Snapshot alınan proje
        /// </summary>
        public virtual Project Project { get; set; } = null!;
    }
}
