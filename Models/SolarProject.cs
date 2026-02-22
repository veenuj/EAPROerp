using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class SolarProject
    {
        public int Id { get; set; }
        [Required]
        public string ClientName { get; set; } = string.Empty;
        [Required]
        public string ProjectType { get; set; } = string.Empty; // On-Grid, Off-Grid, Hybrid
        public decimal CapacityKW { get; set; }
        public string Status { get; set; } = "Survey Pending"; // Survey, Installation, Commissioned
        public string Location { get; set; } = string.Empty;
        public decimal ContractValue { get; set; }
    }
}