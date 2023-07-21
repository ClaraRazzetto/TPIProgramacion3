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
        private readonly IProductService _productService;

        public SaleOrderService(ISaleOrderRepository saleOrderRepository, IMapper mapper, IProductService productService)
        {
            _saleOrderRepository = saleOrderRepository;
            _mapper = mapper;
            _productService = productService;
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
        public SaleOrderDTO? AddSaleOrder(SaleOrderToCreateDTO SaleOrderToCreateDTO, int clientId)
        {
            var newSaleOrder = _mapper.Map<SaleOrder>(SaleOrderToCreateDTO);

            if(_productService.VerificateProduct(newSaleOrder.ProductId, newSaleOrder.ProductQuantity))
            { 
                newSaleOrder.ClientId = clientId;

                newSaleOrder.Status = SaleOrderStatus.Pendiente;
                
                _saleOrderRepository.AddSaleOrder(newSaleOrder);
            
                _saleOrderRepository.SaveChanges();
                
                return _mapper.Map<SaleOrderDTO>(newSaleOrder);
            }

            return null;

            
        }

        public void DeleteSaleOrder(int saleOrderId)
        {
            var saleOrder = _saleOrderRepository.GetSaleOrder(saleOrderId);
            _saleOrderRepository.DeleteSaleOrder(saleOrderId);
            _saleOrderRepository.SaveChanges();
        }

        public SaleOrderStatusDTO? UpdateSaleOrderStatus(int saleOrderId)
        {
            var saleOrderToUpdate = _saleOrderRepository.GetSaleOrder(saleOrderId);
            if (saleOrderToUpdate != null)
            {
                if(saleOrderToUpdate.Status == SaleOrderStatus.Pendiente)
                     saleOrderToUpdate.Status = SaleOrderStatus.Finalizado;
                else 
                    saleOrderToUpdate.Status = SaleOrderStatus.Pendiente;
                
                _saleOrderRepository.SaveChanges();

                return _mapper.Map<SaleOrderStatusDTO>(saleOrderToUpdate);
            }

            return null;
        }


    }
}
