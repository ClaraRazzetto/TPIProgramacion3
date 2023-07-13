using Shop.API.Entities;
using Shop.API.Enums;
using Shop.API.Models.SaleOrderDTOs;

namespace Shop.API.Services.Interfaces
{
    public interface ISaleOrderService
    {
        public SaleOrderDTO? GetSaleOrder(int SaleOrderId);
        public ICollection<SaleOrderDTO> GetAllSaleOrders();
        public SaleOrderDTO AddSaleOrder(SaleOrderToCreateDTO SaleOrderToCreateDTO);

        //Podria agregar un estado: Pendiente - Finalizada  a la saleOrder 
        public void UpdateSaleOrderStatus(SaleOrderStatus saleOrderStatus, int saleOrderId);

        //Me parece que no se tendrían que poder eliminar 
        public void DeleteSaleOrder(int saleOrderId);
    }
}
