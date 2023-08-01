using Shop.API.Entities;
using Shop.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shop.API.Models.SaleOrderDTOs
{
    public class SaleOrderToCreateDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
    }
}
