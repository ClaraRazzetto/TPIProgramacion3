using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.SaleOrderDTOs;
using Shop.API.Services.Interfaces;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/saleOrder")]
    public class SaleOrderController : ControllerBase
    {
        private readonly ISaleOrderService _saleOrderService;

        public SaleOrderController(ISaleOrderService saleOrderService)
        {
            _saleOrderService = saleOrderService;
        }

        [HttpGet]
        public ActionResult<SaleOrderDTO> GetAllSaleOrders()
        {
            var saleOrders = _saleOrderService.GetAllSaleOrders();
            return Ok(saleOrders);
        }

        [HttpGet("{saleOrderId}", Name = "GetSaleOrder")]
        public ActionResult<SaleOrderDTO> GetSaleOrder(int saleOrderId)
        {
            var saleOrder = _saleOrderService.GetSaleOrder(saleOrderId);
            if (saleOrder == null)
                return NotFound();
            return Ok(saleOrder);
        }

        [HttpPost]
        public ActionResult<SaleOrderDTO> AddSaleOrder(SaleOrderToCreateDTO saleOrderToCreateDTO)
        {
            var createdSaleOrder = _saleOrderService.AddSaleOrder(saleOrderToCreateDTO);
            return CreatedAtRoute("GetSaleOrder", new { id = createdSaleOrder.Id }, createdSaleOrder);
            
        }

        [HttpPut("{SaleOrderId}/ChangeStatus")]
        public ActionResult<SaleOrderDTO> ChangeSaleOrderStatus(int saleOrderId, SaleOrderStatusDTO newStatus) 
        {
            _saleOrderService.UpdateSaleOrderStatus(newStatus.Status, saleOrderId);
            return NoContent();
        }

        [HttpDelete("{saleOrderId}")]
        public ActionResult DeleteSaleOrder(int saleOrderId) 
        {
            _saleOrderService.DeleteSaleOrder(saleOrderId);
            return NoContent();
        }

    }
}
