using Shop.API.Entities;
using Shop.API.Models;

namespace Shop.API.Data.Interfaces
{
    public interface IUserRepository : IRepository
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
        public void DeleteUser(int userId);
    }
}
