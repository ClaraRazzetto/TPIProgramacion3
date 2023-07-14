using Shop.API.Entities;
using Shop.API.Enums;
using System.Text.Json.Serialization;

namespace Shop.API.Models.SaleOrderDTOs
{
    public class SaleOrderToCreateDTO
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SaleOrderStatus Status { get; set; } = SaleOrderStatus.Pendiente;
    }
}
