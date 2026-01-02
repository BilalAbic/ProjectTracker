using System.Collections.Generic;

namespace ProjectTracker.Business.DTOs.Analytics
{
    /// <summary>
    /// Maliyet breakdown - Proje veya takım bazında detaylı maliyet dağılımı
    /// </summary>
    public class CostBreakdownDto
    {
        /// <summary>
        /// Entity ID (ProjectId veya TeamId)
        /// </summary>
        public int EntityId { get; set; }
        
        /// <summary>
        /// Entity adı (Project Name veya Team Name)
        /// </summary>
        public string EntityName { get; set; } = string.Empty;
        
        /// <summary>
        /// Breakdown türü ("Project" veya "Team")
        /// </summary>
        public string BreakdownType { get; set; } = "Project";
        
        /// <summary>
        /// Toplam maliyet
        /// </summary>
        public decimal TotalCost { get; set; }
        
        /// <summary>
        /// Kullanıcı bazında maliyet dağılımı
        /// Key: UserName, Value: Cost
        /// </summary>
        public Dictionary<string, decimal> CostByUser { get; set; } = new();
        
        /// <summary>
        /// Task bazında maliyet dağılımı
        /// Key: TaskName, Value: Cost
        /// </summary>
        public Dictionary<string, decimal> CostByTask { get; set; } = new();
        
        /// <summary>
        /// Ay bazında maliyet trendi
        /// Key: "2026-01", Value: Cost
        /// </summary>
        public Dictionary<string, decimal> CostByMonth { get; set; } = new();
        
        /// <summary>
        /// Faturalandırılabilir maliyet
        /// </summary>
        public decimal BillableCost { get; set; }
        
        /// <summary>
        /// Faturalandırılamaz maliyet
        /// </summary>
        public decimal NonBillableCost { get; set; }
    }
}
