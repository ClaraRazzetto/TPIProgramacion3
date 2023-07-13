using Shop.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shop.API.Models.ProductDTOs
{
    public class ProductStockDTO
    {
        [Required]
        public int Stock { get; set; }
    }
}
