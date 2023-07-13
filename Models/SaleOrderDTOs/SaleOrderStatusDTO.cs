using Shop.API.Entities;
using Shop.API.Enums;
using System.Text.Json.Serialization;

namespace Shop.API.Models.SaleOrderDTOs
{
    public class SaleOrderStatusDTO
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SaleOrderStatus Status { get; set; }
    }
}
