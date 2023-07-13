using Shop.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Shop.API.Models.ClientDTOs
{
    public class ClientDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public List<SaleOrder> SaleOrders { get; set; }
    }
}
