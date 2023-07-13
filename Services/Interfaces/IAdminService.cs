using Shop.API.Entities;
using Shop.API.Models.AdminDTOs;
using Shop.API.Models.ClientDTOs;

namespace Shop.API.Services.Interfaces
{
    public interface IAdminService : IUserService
    {
        AdminDTO GetAdminById(int adminId);
        public ICollection<AdminDTO> GetAllAdmins();
        public AdminDTO AddAdmin(AdminToCreateDTO adminToCreateDTO);
        public void UpdateAdmin(AdminToUpdateDTO adminToUpdateDTO, int adminId);

    }
}
