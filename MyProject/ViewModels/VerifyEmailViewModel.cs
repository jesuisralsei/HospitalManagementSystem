using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required]
        [EmailAddress]
       public string Email { get; set; }

    }
}
