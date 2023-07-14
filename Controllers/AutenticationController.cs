using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.API.Entities;
using Shop.API.Models;
using Shop.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AutenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticationService _authenticationService;

        public AutenticationController(IConfiguration config, IAuthenticationService authenticationService)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")] //Vamos a usar un POST ya que debemos enviar los datos para hacer el login
        public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            //Validar credenciales
            var user = ValidateCredentials(authenticationRequestBody);

            if(user is null)
                return Unauthorized();

            //Creo el Token
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));
            
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString()));
            claimsForToken.Add(new Claim("given_name", user.UserName));
            claimsForToken.Add(new Claim("Roles", authenticationRequestBody.Role ?? "Client"));

            var jwtSecurityToken = new JwtSecurityToken(
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private User? ValidateCredentials(AuthenticationRequestBody authenticationRequestBody) 
        {
            return _authenticationService.ValidateUser(authenticationRequestBody);
        }
    }
}
