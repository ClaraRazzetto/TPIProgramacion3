using Shop.API.Entities;

namespace Shop.API.Data.Interfaces
{
    public interface IClientRepository: IRepository
    {
        Client? GetClientById(int clientId);
        public ICollection<Client> GetAllClients();
        public void AddClient(Client newClient);
        public void UpdateClient(Client clientToUpdate);
        public ICollection<SaleOrder> GetClientSaleOrders(int clientId);
    }
}
