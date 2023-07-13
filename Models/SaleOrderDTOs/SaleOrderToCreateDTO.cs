using Shop.API.Entities;
using Shop.API.Enums;
using System.Text.Json.Serialization;

namespace Shop.API.Models.SaleOrderDTOs
{
    public class SaleOrderToCreateDTO
    {
        public int ClientId { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SaleOrderState State { get; set; }
    }
}
