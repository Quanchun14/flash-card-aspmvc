using System.ComponentModel.DataAnnotations;

namespace flash_card.Areas.Identity.Models.AccountViewModels
{
  public class ExternalLoginConfirmationViewModel
  {
    [Required(ErrorMessage = "{0} must not be empty")]
    [EmailAddress(ErrorMessage="{0} must at the correct format")]
    public string? Email { get; set; }
  }
}