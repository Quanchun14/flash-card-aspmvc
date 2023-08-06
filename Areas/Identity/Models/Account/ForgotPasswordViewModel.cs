using System.ComponentModel.DataAnnotations;

namespace flash_card.Areas.Identity.Models.AccountViewModels
{
  public class ForgotPasswordViewModel
  {
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
  }
}