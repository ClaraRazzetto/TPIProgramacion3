using Microsoft.EntityFrameworkCore;
using Shop.API.Data.Interfaces;
using Shop.API.DBContexts;
using Shop.API.Entities;
using Shop.API.Models;

namespace Shop.API.Data.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
       
        public UserRepository(ShopContext context) : base(context)
        {
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
                _context.Users.Remove(user);
        }

        public User? ValidateUser(AuthenticationRequestBody authenticationRequestBody)
        {
            if(authenticationRequestBody.Role == "Client")
                return _context.Clients.FirstOrDefault(c  => c.UserName == authenticationRequestBody.UserName && c.Password == authenticationRequestBody.Password);
            return _context.Admins.FirstOrDefault(a => a.UserName == authenticationRequestBody.UserName && a.Password == authenticationRequestBody.Password);
        }
    }
}
