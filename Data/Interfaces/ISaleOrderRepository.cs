﻿using Shop.API.Entities;

namespace Shop.API.Data.Interfaces
{
    public interface ISaleOrderRepository : IRepository
    {
        public ICollection<SaleOrder> GetAllSaleOrders();
        public SaleOrder? GetSaleOrder(int SaleOrderId);
        public void AddSaleOrder(SaleOrder newSaleOrder);
        public void DeleteSaleOrder(int saleOrderId);
    }
}
