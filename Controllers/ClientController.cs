﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.ClientDTOs;
using Shop.API.Models.SaleOrderDTOs;
using Shop.API.Services.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;

        public ClientController(IClientService clientService, IUserService userService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        [HttpGet("GetAllClients")]
        [Authorize(Roles = "Admin, Client")]
        public ActionResult<ICollection<ClientDTO>> GetAllClients()
        {
            var clients = _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}", Name = "GetClient")]
        [Authorize(Roles = "Admin, Client")]
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
        [Authorize(Roles = "Admin, Client")]
        public ActionResult<ICollection<SaleOrderDTO>> GetClientSaleOrders (int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized();

            if (userId != id && userRole != "Admin")
                return Forbid();
            
            var saleOrders = _clientService.GetClientSaleOrders(id);
            return Ok(saleOrders);
  
        }

        [HttpPost("SingIn")]
        [AllowAnonymous]
        public ActionResult<ClientDTO> AddClient(ClientToCreateDTO clientToCreate)
        {
            var createdClient = _clientService.AddClient(clientToCreate);
            return CreatedAtRoute("GetClient", new { id = createdClient.Id }, createdClient);
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Client")]
        public ActionResult UpdateClient([FromBody] ClientToUpdateDTO clientToUpdate)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            
            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized();

            _clientService.UpdateClient(clientToUpdate, userId);
            return NoContent();
        }

        [HttpDelete("Delete")]
        [Authorize(Roles = "Client")]
        public ActionResult DeleteClient()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized();

            _userService.DeleteUser(userId);
            return NoContent();
        }

    }
}
