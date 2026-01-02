namespace ProjectTracker.Business.DTOs.Analytics
{
    /// <summary>
    /// Finansal genel bakış - Tüm projeler için maliyet özeti
    /// </summary>
    public class FinancialOverviewDto
    {
        /// <summary>
        /// Toplam planlanan bütçe (tüm projeler)
        /// Sum(Projects.Budget)
        /// </summary>
        public decimal TotalPlannedBudget { get; set; }
        
        /// <summary>
        /// Toplam harcanan maliyet (tüm projeler)
        /// Sum(Projects.ActualCost)
        /// </summary>
        public decimal TotalActualCost { get; set; }
        
        /// <summary>
        /// Kalan bütçe
        /// TotalPlannedBudget - TotalActualCost
        /// </summary>
        public decimal RemainingBudget { get; set; }
        
        /// <summary>
        /// Bütçe kullanım yüzdesi
        /// (TotalActualCost / TotalPlannedBudget) × 100
        /// </summary>
        public decimal BudgetUtilizationPercentage { get; set; }
        
        /// <summary>
        /// Faturalandırılabilir saat toplamı
        /// Sum(TimeEntries where IsBillable = true)
        /// </summary>
        public decimal TotalBillableHours { get; set; }
        
        /// <summary>
        /// Faturalandırılamaz saat toplamı
        /// Sum(TimeEntries where IsBillable = false)
        /// </summary>
        public decimal TotalNonBillableHours { get; set; }
        
        /// <summary>
        /// Ortalama saatlik maliyet
        /// TotalActualCost / (TotalBillableHours + TotalNonBillableHours)
        /// </summary>
        public decimal AverageHourlyCost { get; set; }
        
        /// <summary>
        /// Analiz tarihi aralığı (başlangıç)
        /// </summary>
        public DateTime? StartDate { get; set; }
        
        /// <summary>
        /// Analiz tarihi aralığı (bitiş)
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
