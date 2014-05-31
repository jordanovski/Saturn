using System.ComponentModel.DataAnnotations;

namespace Saturn.Account.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "е-маил")]
        public string Email { get; set; }
    }
}
