using Microsoft.EntityFrameworkCore;
using Shop.API.Data.Interfaces;
using Shop.API.DBContexts;
using Shop.API.Entities;

namespace Shop.API.Data.Implementations
{
    public class SaleOrderRepository : Repository, ISaleOrderRepository 
    {
        public SaleOrderRepository(ShopContext context) : base(context)
        {
        }
   
        public ICollection<SaleOrder> GetAllSaleOrders()
        {
            return _context.SaleOrders
                .OrderBy(s => s.Status)
                .ToList();    
        }

        public SaleOrder? GetSaleOrder(int SaleOrderId)
        {
            return _context.SaleOrders.FirstOrDefault(s => s.Id == SaleOrderId);
        }
        public void AddSaleOrder(SaleOrder newSaleOrder)
        {
            _context.SaleOrders.Add(newSaleOrder);
        }
        public void DeleteSaleOrder(int saleOrderId)
        {
            var saleOrder = _context.SaleOrders.Find(saleOrderId);
            if (saleOrder != null)
                _context.SaleOrders.Remove(saleOrder);
        }

    }
}
