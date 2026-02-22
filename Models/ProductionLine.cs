using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class ProductionLine
    {
        public int Id { get; set; }

        [Required]
        public string LineName { get; set; } = string.Empty; // e.g. "Alpha-1 Inverter Assembly"

        [Required]
        public string CurrentProduct { get; set; } = string.Empty; // e.g. "TRON-3200"

        public int DailyTarget { get; set; }
        public int UnitsCompleted { get; set; }
        
        // Active, Maintenance, Offline
        public string Status { get; set; } = "Active"; 

        // e.g. 99.8 for 99.8% pass rate
        public decimal QualityScore { get; set; } 
    }
}