using AutoMapper;
using Shop.API.Data.Interfaces;
using Shop.API.Entities;
using Shop.API.Enums;
using Shop.API.Models.SaleOrderDTOs;
using Shop.API.Services.Interfaces;

namespace Shop.API.Services.Implementations
{
    public class SaleOrderService : ISaleOrderService
    {
        private readonly ISaleOrderRepository _saleOrderRepository;
        private readonly IMapper _mapper;

        public SaleOrderService(ISaleOrderRepository saleOrderRepository, IMapper mapper)
        {
            _saleOrderRepository = saleOrderRepository;
            _mapper = mapper;
        }
        public SaleOrderDTO? GetSaleOrder(int SaleOrderId)
        {
            var saleOrder = _saleOrderRepository.GetSaleOrder(SaleOrderId);
            return _mapper.Map<SaleOrderDTO>(saleOrder);
        }
        public ICollection<SaleOrderDTO> GetAllSaleOrders()
        {
            var saleOrders = _saleOrderRepository.GetAllSaleOrders();
            return _mapper.Map<ICollection<SaleOrderDTO>>(saleOrders);
        }
        public SaleOrderDTO AddSaleOrder(SaleOrderToCreateDTO SaleOrderToCreateDTO)
        {
            var newSaleOrder = _mapper.Map<SaleOrder>(SaleOrderToCreateDTO);
            _saleOrderRepository.AddSaleOrder(newSaleOrder);
            _saleOrderRepository.SaveChanges();
            return _mapper.Map<SaleOrderDTO>(newSaleOrder);
        }

        public void DeleteSaleOrder(int saleOrderId)
        {
            _saleOrderRepository.DeleteSaleOrder(saleOrderId);
            _saleOrderRepository.SaveChanges();
        }

        public void UpdateSaleOrderStatus(SaleOrderStatus saleOrderStatus, int saleOrderId)
        {
            var saleOrderToUpdate = _saleOrderRepository.GetSaleOrder(saleOrderId);
            _saleOrderRepository.UpdateSaleOrder(saleOrderToUpdate);
            _saleOrderRepository.SaveChanges();
        }
    }
}
