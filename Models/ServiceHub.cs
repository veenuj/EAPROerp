namespace EaproERP.Models
{
    // --- WARRANTY NODE ---
    public class WarrantyNode
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; } = string.Empty; // Unique Product ID
        public string CustomerName { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public int WarrantyPeriodMonths { get; set; }
        public bool IsRegistered { get; set; }
        
        // Calculated logic: Is currently active?
        public bool IsActive => PurchaseDate.AddMonths(WarrantyPeriodMonths) > DateTime.Now;
    }

    // --- AMC NODE ---
    public class AmcNode
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string ProjectSite { get; set; } = string.Empty;
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractExpiryDate { get; set; }
        public decimal ContractValue { get; set; }
        public string ServiceFrequency { get; set; } = "Quarterly"; // Monthly, Quarterly, Annual
        public DateTime NextScheduledService { get; set; }
    }
}