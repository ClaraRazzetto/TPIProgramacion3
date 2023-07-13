using Microsoft.AspNetCore.Mvc;
using Shop.API.Models.AdminDTOs;
using Shop.API.Services.Interfaces;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/admin")]
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

        [HttpGet("{id}", Name = "GetAdmin")]
        public ActionResult<AdminDTO> GetAdminById(int id)
        {
            var admin = _adminService.GetAdminById(id);
            if (admin == null)
                return NotFound();
            return Ok(admin);
        }

        [HttpPost]
        public ActionResult<AdminDTO> AddAdmin(AdminToCreateDTO admin)
        {
            var createdAdmin = _adminService.AddAdmin(admin);
            return CreatedAtRoute("GetAdmin", new { id = createdAdmin.Id }, createdAdmin);
        }

        [HttpPut]
        public ActionResult UpdateAdmin(AdminToUpdateDTO admin, int id)
        {
            _adminService.UpdateAdmin(admin, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAdmin (int id) 
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
