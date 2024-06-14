using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace AuctionWebApplication.ViewModel
{
    public class RegisterViewModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password special characters, uppercase")]
        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name= "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password special characters, uppercase")]
        [System.ComponentModel.DataAnnotations.Required]
        [Compare("Password", ErrorMessage= "Passwords do not match")]
        [Display(Name = "Password confirmation")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
