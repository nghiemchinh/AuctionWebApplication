using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AuctionWebApplication.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Email can not black")]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not black")]
        [Display(Name = "Password")]
        public string Password { get; set; }

       
        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
