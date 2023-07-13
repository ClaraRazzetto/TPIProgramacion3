using Shop.API.Enums;
using System.Text.Json.Serialization;

namespace Shop.API.Models.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductCategories Category { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ProductSizes Size { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
    }
}
