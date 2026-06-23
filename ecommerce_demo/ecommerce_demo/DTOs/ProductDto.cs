using System.ComponentModel.DataAnnotations;

namespace ecommerce_demo.DTOs
{
    public class ProductDto
    {
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [Range(10,100000)]
        public decimal Price { get; set; }
        [Range(0,int.MaxValue)]
        public int StockQuantity { get; set; }
        [Url]
        public string ImageUrl { get; set; } = string.Empty;
        [Range(1,int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
