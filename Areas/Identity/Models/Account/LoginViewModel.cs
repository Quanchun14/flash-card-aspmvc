

using System.ComponentModel.DataAnnotations;

namespace flash_card.Areas.Identity.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} must not be empty")]
        [Display(Name = "UserName or Email Address")]
        public string? UserNameOrEmail { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Display(Name = "Remember Account?")]
        public bool RememberMe { get; set; }
    }
}
