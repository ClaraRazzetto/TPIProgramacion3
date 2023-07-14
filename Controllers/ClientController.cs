using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Entities;
using Shop.API.Models.ClientDTOs;
using Shop.API.Models.SaleOrderDTOs;
using Shop.API.Services.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/client")]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;

        public ClientController(IClientService clientService, IUserService userService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<ICollection<ClientDTO>> GetAllClients()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int id))
                return Unauthorized();

            var clients = _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}", Name = "GetClient")]
        public ActionResult<ClientDTO> GetClientById(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userid))
                return Unauthorized();

            var client = _clientService.GetClientById(id);
             if (client == null)
                return NotFound();

            if (userRole != "Admin" && int.Parse(client.Id) != userid)
                return Forbid();
         
            return Ok(client);
        }

        [HttpGet("{id}/GetSaleOrders")]
        public ActionResult<ICollection<SaleOrderDTO>> GetClientSaleOrders (int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userid))
                return Unauthorized();

            if (userid != id && userRole != "Admin")
                return Forbid();
            
            var saleOrders = _clientService.GetClientSaleOrders(id);
            return Ok(saleOrders);
  
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<ClientDTO> AddClient(ClientToCreateDTO clientToCreate)
        {
            var createdClient = _clientService.AddClient(clientToCreate);
            return CreatedAtRoute("GetClient", new { id = createdClient.Id }, createdClient);
        }

        [HttpPut]
        public ActionResult UpdateClient(ClientToUpdateDTO clientToUpdate)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Client")
                return Forbid();

            _clientService.UpdateClient(clientToUpdate, int.Parse(userId));
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteClient()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Client")
                return Forbid();

            _userService.DeleteUser(int.Parse(userId));
            return NoContent();
        }

    }
}
