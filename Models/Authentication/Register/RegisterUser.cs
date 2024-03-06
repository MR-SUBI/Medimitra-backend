using System.ComponentModel.DataAnnotations;

namespace MediMitra.Models.Authentication.Register
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User name is required")]
        public String? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public String? Email{ get; set; }

        [Required(ErrorMessage = "Password is required")]
        public String? Password{ get; set; }


    }

}
