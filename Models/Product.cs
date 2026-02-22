using System.ComponentModel.DataAnnotations;

namespace EaproERP.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Category { get; set; } = string.Empty; 
        
        [Required]
        public int StockLevel { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        public string AIStockPrediction { get; set; } = string.Empty;
    }
}