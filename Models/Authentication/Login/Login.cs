using System.ComponentModel.DataAnnotations;

namespace MediMitra.Models.Authentication.Login
{
    public class LoginUser
    {
        [Required(ErrorMessage = "User name is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        public string? Password { get; set; }
    }
}
