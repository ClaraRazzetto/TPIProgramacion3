using AutoMapper;
using Shop.API.Data.Interfaces;
using Shop.API.Entities;
using Shop.API.Models.AdminDTOs;
using Shop.API.Services.Interfaces;

namespace Shop.API.Services.Implementations
{
    public class AdminService : UserService, IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IUserRepository userRepository, IMapper mapper, IAdminRepository adminRepository) : base(userRepository, mapper)
        {
            _adminRepository = adminRepository;
        }
        public AdminDTO GetAdminById(int adminId)
        {
            var admin = _adminRepository.GetAdminById(adminId);
            return _mapper.Map<AdminDTO>(admin);
        }

        public ICollection<AdminDTO> GetAllAdmins()
        {
            var admins = _adminRepository.GetAllAdmins();
            return _mapper.Map<ICollection<AdminDTO>>(admins);
        }

        public AdminDTO AddAdmin(AdminToCreateDTO adminToCreateDTO)
        {
            var newAdmin = _mapper.Map<Admin>(adminToCreateDTO);
            _adminRepository.AddAdmin(newAdmin);
            _adminRepository.SaveChanges();
            return _mapper.Map<AdminDTO>(newAdmin);
        }

        public void UpdateAdmin(AdminToUpdateDTO adminToUpdateDTO, int adminId)
        {
            var adminToUpdate = _adminRepository.GetAdminById(adminId);
            _mapper.Map(adminToUpdateDTO, adminToUpdate);
            _adminRepository.UpdateAdmin(adminToUpdate);
            _adminRepository.SaveChanges();
        }

    }
}
