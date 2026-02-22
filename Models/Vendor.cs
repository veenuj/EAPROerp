namespace EaproERP.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // e.g., Raw Materials, Logistics, Electronics
        public string ContactPerson { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal OutstandingBalance { get; set; }
        public int ReliabilityScore { get; set; } // 1-100 based on delivery speed
        public string Status { get; set; } = "Active"; // Active, Under Review, Blacklisted
    }
}