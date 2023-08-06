// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;

namespace flash_card.Areas.Identity.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
            [Required(ErrorMessage = "{0} must not be empty")]
            [EmailAddress(ErrorMessage="{0} must at the correct format")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "{0} must not be empty")]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "{0} must be at least {2} and at max {1} characters long.")]
            [DataType(DataType.Password)]
            [Display(Name = "Enter New Password")]
            public string? Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm New Password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }

              public string? Code { get; set; }

    }
}
