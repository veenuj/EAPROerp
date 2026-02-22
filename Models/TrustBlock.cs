using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class TrustBlock
    {
        [Key] // 👈 This line fixes the error
        public int Index { get; set; }
        
        public DateTime Timestamp { get; set; }
        
        [Required]
        public string ProductId { get; set; } = string.Empty;
        
        [Required]
        public string Data { get; set; } = string.Empty;
        
        public string PreviousHash { get; set; } = string.Empty;
        
        public string Hash { get; set; } = string.Empty;
    }
}