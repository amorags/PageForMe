using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PageForMe.Models
{
     public class Sale
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string Category { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        public int Quantity { get; set; }
        
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalAmount { get; set; }
        
        public DateTime SaleDate { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string Region { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string SalesRep { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; }
    }
}