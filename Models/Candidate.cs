using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty; // e.g., AI Developer, Sales Manager
        public string ResumeUrl { get; set; } = string.Empty;

        // Progress Tracking (Steps 1 to 5)
        // 1: Applied, 2: Technical Round, 3: HR Round, 4: Management, 5: Offered
        public int CurrentStep { get; set; } = 1;
        public string Status { get; set; } = "Active"; // Active, Hired, Rejected
        public DateTime AppliedDate { get; set; } = DateTime.Now;
        public string? Notes { get; set; }
    }
}