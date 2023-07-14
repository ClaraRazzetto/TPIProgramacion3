using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.API.Entities
{
    //Client hereda de User
    public class Client : User
    {   
        public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    }
}
