using Shop.API.Entities;
using Shop.API.Models;

namespace Shop.API.Data.Interfaces
{
    public interface IUserRepository : IRepository
    {
        public ICollection<User> GetAllUsers(string role);
        public User? GetUserById(int userId);
        public void AddUser(User newUser);
        public void UpdateUser(User userToUpdate);
        public void DeleteUser(int userId);
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);

    }
}
