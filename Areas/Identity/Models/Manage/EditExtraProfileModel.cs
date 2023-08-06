using System;
using System.ComponentModel.DataAnnotations;

namespace flash_card.Areas.Identity.Models.ManageViewModels
{
  public class EditExtraProfileModel
  {
      [Display(Name = "UserName")]
      public string? UserName { get; set; }

      [Display(Name = "Email Address")]
      public string? UserEmail { get; set; }

  }
}