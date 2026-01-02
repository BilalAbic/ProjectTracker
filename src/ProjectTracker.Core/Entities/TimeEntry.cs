namespace ProjectTracker.Core.Entities
{
    /// <summary>
    /// Kullanıcının bir task'a harcadığı zamanı detaylı olarak kaydeder
    /// Advanced Analytics için zaman tracking
    /// </summary>
    public class TimeEntry
    {
        /// <summary>
        /// Primary key - Unique identifier
        /// </summary>
        public int TimeEntryId { get; set; }
        
        /// <summary>
        /// Foreign key - Zamanı harcayan kullanıcı
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Foreign key - Zaman harcanan task
        /// </summary>
        public int TaskId { get; set; }
        
        /// <summary>
        /// Çalışma tarihi (hangi gün çalışıldı)
        /// </summary>
        public DateTime WorkDate { get; set; }
        
        /// <summary>
        /// Harcanan saat miktarı (0.5, 1.25, 8.0 gibi decimal değerler)
        /// </summary>
        public decimal HoursSpent { get; set; }
        
        /// <summary>
        /// Bu zaman faturalandırılabilir mi? (billable hours)
        /// </summary>
        public bool IsBillable { get; set; } = true;
        
        /// <summary>
        /// Çalışma açıklaması - ne yapıldı?
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Kayıt oluşturulma zamanı
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // Navigation Properties
        
        /// <summary>
        /// Navigation property - Zamanı harcayan kullanıcı
        /// </summary>
        public virtual User User { get; set; } = null!;
        
        /// <summary>
        /// Navigation property - Zaman harcanan task
        /// </summary>
        public virtual Task Task { get; set; } = null!;
    }
}
