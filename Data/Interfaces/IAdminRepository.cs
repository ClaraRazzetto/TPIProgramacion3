using Shop.API.Entities;

namespace Shop.API.Data.Interfaces
{
    public interface IAdminRepository : IRepository
    {
        public Admin? GetAdminById(int adminId);
        public ICollection<Admin> GetAllAdmins();
        public void AddAdmin (Admin newAdmin);
        public void UpdateAdmin(Admin adminToUpdate);
    }
}
