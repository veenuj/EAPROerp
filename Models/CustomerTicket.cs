using System;
using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class CustomerTicket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RequestType { get; set; } = string.Empty; 

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Email { get; set; }

        [Required]
        public string ProductSerialNumber { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Status { get; set; } = "Open"; // Default status
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}