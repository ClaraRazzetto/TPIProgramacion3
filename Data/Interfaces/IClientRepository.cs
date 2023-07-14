using Shop.API.Entities;

namespace Shop.API.Data.Interfaces
{
    public interface IClientRepository: IRepository
    {
        public ICollection<SaleOrder> GetClientSaleOrders(int clientId);
    }
}
