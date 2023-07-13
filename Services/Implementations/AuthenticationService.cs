using Shop.API.Data.Interfaces;
using Shop.API.Entities;
using Shop.API.Models;
using Shop.API.Services.Interfaces;

namespace Shop.API.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User? ValidateUser(AuthenticationRequestBody authenticationRequestBody)
        {
            if (string.IsNullOrEmpty(authenticationRequestBody.UserName) || string.IsNullOrEmpty(authenticationRequestBody.Password))
                return null;

            return _userRepository.ValidateUser(authenticationRequestBody);
        }
    }
}
