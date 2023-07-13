using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.API.Entities
{
    //Client hereda de User
    public class Client : User
    {
        //Maxima longitud
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        public string? Adress { get; set; }
        public ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    }
}
