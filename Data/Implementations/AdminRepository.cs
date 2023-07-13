using Microsoft.EntityFrameworkCore;
using Shop.API.Data.Interfaces;
using Shop.API.DBContexts;
using Shop.API.Entities;
using System.Net;

namespace Shop.API.Data.Implementations
{
    public class AdminRepository : Repository, IAdminRepository
    {
        public AdminRepository(ShopContext context) : base(context)
        {

        }
        public Admin? GetAdminById(int adminId)
        {
            return _context.Admins.Find(adminId);
        }
        public ICollection<Admin> GetAllAdmins() 
        {
            return _context.Admins.ToList();
        }
        public void AddAdmin(Admin newAdmin) 
        {
            _context.Admins.Add(newAdmin);
        }
        public void UpdateAdmin(Admin adminToUpdate) 
        {
            _context.Entry(adminToUpdate).State = EntityState.Modified;
        }

    }
}
