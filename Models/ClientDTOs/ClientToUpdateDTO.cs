using System.ComponentModel.DataAnnotations;

namespace Shop.API.Models.ClientDTOs
{
    public class ClientToUpdateDTO
    {
    
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
    }
}
