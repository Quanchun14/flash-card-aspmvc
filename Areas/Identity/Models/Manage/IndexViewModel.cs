using Microsoft.AspNetCore.Identity;

namespace flash_card.Areas.Identity.Models.ManageViewModels
{
  public class IndexViewModel
  {
    public EditExtraProfileModel profile { get; set; }

    public bool HasPassword { get; set; }

    public IList<UserLoginInfo> Logins { get; set; }

    
  }
}