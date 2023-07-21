using Shop.API.Enums;
using Shop.API.Models.SaleOrderDTOs;

namespace Shop.API.Services.Interfaces
{
    public interface ISaleOrderService
    {
        public SaleOrderDTO? GetSaleOrder(int SaleOrderId);
        public ICollection<SaleOrderDTO> GetAllSaleOrders();
        public SaleOrderDTO? AddSaleOrder(SaleOrderToCreateDTO SaleOrderToCreateDTO, int clientId);
        public SaleOrderStatusDTO? UpdateSaleOrderStatus(int saleOrderId);
        public void DeleteSaleOrder(int saleOrderId);
    }
}
