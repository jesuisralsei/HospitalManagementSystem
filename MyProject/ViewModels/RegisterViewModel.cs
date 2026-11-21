using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(40, MinimumLength = 8 , ErrorMessage ="the {0} must be at least {2} and max {1} characters long")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword" , ErrorMessage = "Password does not match")]
        
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType (DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
