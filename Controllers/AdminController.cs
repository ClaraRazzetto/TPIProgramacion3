﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.AdminDTOs;
using Shop.API.Services.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<ICollection<AdminDTO>> GetAllAdmins()
        {
            var admins = _adminService.GetAllAdmins();
            return Ok(admins);
        }

        [HttpGet("/GetAdminById")]
        public ActionResult<AdminDTO> GetAdminById()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized();

            var admin = _adminService.GetAdminById(userId);
            if (admin == null)
                return NotFound();

            return Ok(admin);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddAdmin(AdminToCreateDTO admin)
        {
            var createdAdmin = _adminService.AddAdmin(admin);
            return NoContent();
        }

        [HttpPut]
        public ActionResult UpdateAdmin(AdminToUpdateDTO admin)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            
            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized();

            _adminService.UpdateAdmin(admin, userId);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteAdmin () 
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            
            if (!int.TryParse(userIdClaim, out int userid))
                return Unauthorized();
            
            _userService.DeleteUser(userid);
            return NoContent();
        }
    }
}
