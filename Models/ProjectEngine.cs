using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class ProjectEngine
    {
        public int Id { get; set; }
        
        [Required]
        public string ProjectName { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string SiteLocation { get; set; } = string.Empty;

        // Technical Specs
        public double SystemCapacityKW { get; set; }
        public string ProjectType { get; set; } = "On-Grid"; // Hybrid, Off-Grid
        
        // Survey Telemetry
        public string RoofType { get; set; } = "RRC Slab"; // Tin Shade, Ground Mount
        public int ShadowAnalysisScore { get; set; } // 1-100
        
        // EPC Progress
        public int ExecutionProgress { get; set; } // 0-100%
        public string CurrentPhase { get; set; } = "Site Survey"; // Design, Procurement, Installation, Live
        
        public decimal ContractValue { get; set; }
        public DateTime CommencementDate { get; set; } = DateTime.Now;
    }
}