using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EaproERP.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        // Added '?' to make it nullable so ModelState doesn't block the save
        public string? InvoiceNumber { get; set; } 

        [Required(ErrorMessage = "Customer Name is essential for billing")]
        public string CustomerName { get; set; } = string.Empty;

        public string? CustomerGSTIN { get; set; } // Optional for Non-GST
        
        public DateTime BillingDate { get; set; } = DateTime.Now;

        public bool IsGstInvoice { get; set; } 
        
        public decimal BaseAmount { get; set; }
        
        public decimal TaxRate { get; set; } = 18.00m;

        // [NotMapped] tells EF Core these are calculated on-the-fly, not stored in columns
        [NotMapped]
        public decimal TaxAmount => IsGstInvoice ? (BaseAmount * TaxRate / 100) : 0;

        [NotMapped]
        public decimal TotalAmount => BaseAmount + TaxAmount;

        public string? Status { get; set; } = "Unpaid"; 

        public string? PaymentMethod { get; set; } // Cash, UPI, Bank Transfer, Cheque
        public DateTime? PaymentDate { get; set; }
        public string? TransactionId { get; set; } // Reference number for the bank/UPI
    }
}