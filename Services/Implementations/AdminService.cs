using AutoMapper;
using Shop.API.Data.Interfaces;
using Shop.API.Entities;
using Shop.API.Models.AdminDTOs;
using Shop.API.Services.Interfaces;

namespace Shop.API.Services.Implementations
{
    public class AdminService : UserService, IAdminService
    {
        public AdminService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {

        }

        public ICollection<AdminDTO> GetAllAdmins()
        {
            var admins = _userRepository.GetAllUsers("Admin");
            return _mapper.Map<ICollection<AdminDTO>>(admins);
        }
        public AdminDTO GetAdminById(int adminId)
        {
            var admin2 = _userRepository.GetUserById(adminId);
            return _mapper.Map<AdminDTO>(admin2);
        }

        public AdminDTO AddAdmin(AdminToCreateDTO adminToCreateDTO)
        {
            var newAdmin = _mapper.Map<Admin>(adminToCreateDTO);
            _userRepository.AddUser(newAdmin);
            _userRepository.SaveChanges();
            return _mapper.Map<AdminDTO>(newAdmin);
        }

        public void UpdateAdmin(AdminToUpdateDTO adminToUpdateDTO, int adminId)
        {
            var adminToUpdate = _userRepository.GetUserById(adminId);

            _mapper.Map(adminToUpdateDTO, adminToUpdate);
            _userRepository.UpdateUser(adminToUpdate);
            _userRepository.SaveChanges();
        }

    }
}
