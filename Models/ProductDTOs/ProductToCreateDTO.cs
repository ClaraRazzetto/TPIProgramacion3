using Shop.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shop.API.Models.ProductDTOs
{
    public class ProductToCreateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public ProductCategories Category { get; set; }
        [Required]
        public ProductSizes Size { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
