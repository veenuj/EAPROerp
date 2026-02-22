using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public byte[]? BiometricCredentialId { get; set; }
        public byte[]? BiometricPublicKey { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
        // --- NEW: Barcode/RFID Identifier ---
        public string EmployeeCode { get; set; } = string.Empty; // e.g. EAP-1001

        public string Designation { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        
        public decimal BaseSalary { get; set; }
        public decimal? Bonus { get; set; }
        public string? AIPerformanceInsight { get; set; }

        // --- NEW: Onboarding Compliance Data ---
        public DateTime DateOfJoining { get; set; } = DateTime.Now;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EmergencyContact { get; set; } = string.Empty;
        
        // Financial & Government Info
        public string BankAccountNumber { get; set; } = string.Empty;
        public string IFSCCode { get; set; } = string.Empty;
        public string GovernmentId { get; set; } = string.Empty; // Aadhar/PAN

        public string JobLocation { get; set; } = "Roorkee";
    }
}