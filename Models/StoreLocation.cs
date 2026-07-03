using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class StoreLocation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DealerName { get; set; } = string.Empty;

        public string ContactPerson { get; set; } = string.Empty;

        [Required]
        public string Mobile { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
        
        public string State { get; set; } = string.Empty;

        public string Pincode { get; set; } = string.Empty;
    }
}