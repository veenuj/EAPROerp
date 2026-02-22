namespace EaproERP.Models
{
    public class PayrollViewModel 
    {
        public Employee Employee { get; set; } = null!;
        public int DaysPresent { get; set; }
        public decimal NetPay { get; set; }
        public string Month { get; set; } = string.Empty;
    }
}