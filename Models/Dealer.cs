namespace EaproERP.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Tier { get; set; } = "Silver"; // Silver, Gold, Platinum
        public decimal AnnualTurnover { get; set; }
        public bool IsServiceCenter { get; set; } // Based on EAPRO's "Service Center Locator"
    }
}