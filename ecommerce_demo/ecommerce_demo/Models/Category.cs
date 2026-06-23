using System.Text.Json.Serialization;

namespace ecommerce_demo.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description {  get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }=new List<Product>();
    }
}
