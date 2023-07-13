using Shop.API.Entities;

namespace Shop.API.Data.Interfaces
{
    public interface ISaleOrderRepository : IRepository
    {
        public ICollection<SaleOrder> GetAllSaleOrders();
        public SaleOrder? GetSaleOrder(int SaleOrderId);
        public void AddSaleOrder(SaleOrder newSaleOrder);

        //Podria agregar un estado: Pendiente - Finalizada  a la saleOrder 
        public void UpdateSaleOrder(SaleOrder saleOrderToUpdate);

        //Me parece que no se tendrían que poder eliminar 
        public void DeleteSaleOrder(int saleOrderId);
    }
}
