using Shop.API.Entities;
using Shop.API.Models;

namespace Shop.API.Services.Interfaces
{
    public interface IAuthenticationService
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}
