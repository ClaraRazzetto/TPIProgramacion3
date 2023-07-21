using Microsoft.EntityFrameworkCore;
using Shop.API.Data.Interfaces;
using Shop.API.DBContexts;
using Shop.API.Entities;

namespace Shop.API.Data.Implementations
{
    public class ClientRepository : Repository, IClientRepository
    {
        public ClientRepository(ShopContext context) : base(context)
        {
        }
        public ICollection<SaleOrder> GetClientSaleOrders(int clientId)
        {
            return _context.Clients
                 .Where(c => c.Id == clientId)
                 .SelectMany(c => c.SaleOrders)
                 .Include(s => s.Product)
                 .ToList();
        }

    }
}
