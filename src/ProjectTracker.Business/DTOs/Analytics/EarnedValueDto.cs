namespace ProjectTracker.Business.DTOs.Analytics
{
    /// <summary>
    /// Earned Value Management (EVM) metrikleri
    /// Proje maliyet ve takvim performansı analizi
    /// </summary>
    public class EarnedValueDto
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
        /// Planlanan Değer (PV) - Bugüne kadar ne kadar iş planlanmıştı?
        /// Budget × (Elapsed Days / Total Days)
        /// </summary>
        public decimal PlannedValue { get; set; }
        
        /// <summary>
        /// Kazanılan Değer (EV) - Bugüne kadar ne kadar iş tamamlandı?
        /// Budget × (Completion Percentage / 100)
        /// </summary>
        public decimal EarnedValue { get; set; }
        
        /// <summary>
        /// Gerçek Maliyet (AC) - Bugüne kadar ne kadar harcandı?
        /// Sum(TimeEntry.HoursSpent × User.HourlyCost)
        /// </summary>
        public decimal ActualCost { get; set; }
        
        /// <summary>
        /// Maliyet Performans İndeksi (CPI) = EV / AC
        /// CPI > 1: Bütçe altında ✅
        /// CPI < 1: Bütçe üstünde ⚠️
        /// </summary>
        public decimal CPI { get; set; }
        
        /// <summary>
        /// Takvim Performans İndeksi (SPI) = EV / PV
        /// SPI > 1: Öndeyiz ✅
        /// SPI < 1: Gerideyiz ⚠️
        /// </summary>
        public decimal SPI { get; set; }
        
        /// <summary>
        /// Maliyet Varyansı (CV) = EV - AC
        /// CV > 0: İyi (bütçe altında)
        /// CV < 0: Kötü (bütçe üstünde)
        /// </summary>
        public decimal CostVariance { get; set; }
        
        /// <summary>
        /// Takvim Varyansı (SV) = EV - PV
        /// SV > 0: İyi (öndeyiz)
        /// SV < 0: Kötü (gerideyiz)
        /// </summary>
        public decimal ScheduleVariance { get; set; }
        
        /// <summary>
        /// Tahmini Tamamlama Maliyeti (EAC) = Budget / CPI
        /// Proje bu gidişle ne kadar tutacak?
        /// </summary>
        public decimal EstimateAtCompletion { get; set; }
        
        /// <summary>
        /// Proje sağlık durumu
        /// "Good" (CPI >= 0.9 && SPI >= 0.9)
        /// "Warning" (CPI >= 0.8 || SPI >= 0.8)
        /// "Critical" (CPI < 0.8 || SPI < 0.8)
        /// </summary>
        public string Health { get; set; } = "Good";
    }
}
