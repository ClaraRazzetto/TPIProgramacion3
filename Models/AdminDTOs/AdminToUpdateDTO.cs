using System.ComponentModel.DataAnnotations;

namespace Shop.API.Models.AdminDTOs
{
    public class AdminToUpdateDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
