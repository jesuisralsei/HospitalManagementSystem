using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "the {0} must be at least {2} and max {1} characters long")]
        [DataType(DataType.Password)]
        [Display(Name ="New Password")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password does not match")]

        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]

        public string ConfirmNewPassword { get; set; }

    }
}
