using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.AdminDTOs;
using Shop.API.Services.Interfaces;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize]
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
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();

            var admins = _adminService.GetAllAdmins();
            return Ok(admins);
        }

        [HttpGet("{id}", Name = "GetAdmin")]
        public ActionResult<AdminDTO> GetAdminById(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (int.Parse(userIdClaim) != id || userRole != "Admin")
                return Forbid();

            var admin = _adminService.GetAdminById(id);
            if (admin == null)
                return NotFound();
            return Ok(admin);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<AdminDTO> AddAdmin(AdminToCreateDTO admin)
        {
            var createdAdmin = _adminService.AddAdmin(admin);
            return CreatedAtRoute("GetAdmin", new { id = createdAdmin.Id }, createdAdmin);
        }

        [HttpPut]
        public ActionResult UpdateAdmin(AdminToUpdateDTO admin)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            _adminService.UpdateAdmin(admin, int.Parse(userIdClaim));
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteAdmin () 
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            _userService.DeleteUser(int.Parse(userIdClaim));
            return NoContent();
        }
    }
}
