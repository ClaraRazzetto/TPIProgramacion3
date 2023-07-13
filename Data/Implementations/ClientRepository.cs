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

        public Client? GetClientById(int clientId)
        {
            return _context.Clients.Find(clientId);
        } 
        public ICollection<Client> GetAllClients()
        {
            return _context.Clients.OrderBy(u => u.Name).ToList();
        }
        
        public void AddClient(Client newClient)
        {
            _context.Clients.Add(newClient);
        }

        public void UpdateClient(Client clientToUpdate)
        {
            _context.Entry(clientToUpdate).State = EntityState.Modified;
        }

        public ICollection<SaleOrder> GetClientSaleOrders(int clientId)
        {
            return _context.Clients.Where(c => c.Id == clientId)
                .Select(c => c.SaleOrders).FirstOrDefault() ?? new List<SaleOrder>();
        }

    }
}
