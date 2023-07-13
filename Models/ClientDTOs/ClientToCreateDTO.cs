using Shop.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Shop.API.Models.ClientDTOs
{
    public class ClientToCreateDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Adress { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
