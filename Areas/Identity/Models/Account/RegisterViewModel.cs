// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel.DataAnnotations;

namespace flash_card.Areas.Identity.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} must not be empty")]
        [EmailAddress(ErrorMessage="{0} must at the correct format")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "{0} must not be empty")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm PassWord")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "UserName")]
         [Required(ErrorMessage = "{0} must not be empty")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} must be at least {2} and at max {1} characters long.")]
        public string? UserName { get; set; }

    }
}
