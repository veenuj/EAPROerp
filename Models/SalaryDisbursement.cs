using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class SalaryDisbursement
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public string MonthYear { get; set; } = string.Empty; // e.g., "February 2026"
        public int TotalWorkingDays { get; set; }
        public int DaysPresent { get; set; }
        
        public decimal CalculatedGross { get; set; }
        public decimal BonusAmount { get; set; }
        public decimal NetPayout { get; set; }
        
        public DateTime DisbursedOn { get; set; } = DateTime.Now;
        public string TransactionId { get; set; } = string.Empty;
    }
}