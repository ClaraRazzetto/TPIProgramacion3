using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.SaleOrderDTOs;
using Shop.API.Services.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/saleOrder")]
    [Authorize]
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
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            var saleOrders = _saleOrderService.GetAllSaleOrders();
            return Ok(saleOrders);
        }

        [HttpGet("{saleOrderId}", Name = "GetSaleOrder")]
        public ActionResult<SaleOrderDTO> GetSaleOrder(int saleOrderId)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            var saleOrder = _saleOrderService.GetSaleOrder(saleOrderId);
            if (saleOrder == null)
                return NotFound();
            return Ok(saleOrder);
        }

        [HttpPost]
        [Route("/create")]
        public ActionResult<SaleOrderDTO> AddSaleOrder(SaleOrderToCreateDTO saleOrderToCreateDTO)
        { 
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int id))
                return Unauthorized();
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Client")
                return Forbid();
            var createdSaleOrder = _saleOrderService.AddSaleOrder(saleOrderToCreateDTO, id);
            return CreatedAtRoute("GetSaleOrder", new { saleOrderId = createdSaleOrder.Id }, createdSaleOrder);
 
        }

        [HttpPut("{saleOrderId}")]
        public ActionResult<SaleOrderDTO> ChangeSaleOrderStatus(int saleOrderId, SaleOrderStatusDTO newStatus) 
        {
           
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            _saleOrderService.UpdateSaleOrderStatus(newStatus.Status, saleOrderId);
            return NoContent();
        }

        [HttpDelete("{saleOrderId}")]
        public ActionResult DeleteSaleOrder(int saleOrderId) 
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            _saleOrderService.DeleteSaleOrder(saleOrderId);
            return NoContent();
        }

    }
}
