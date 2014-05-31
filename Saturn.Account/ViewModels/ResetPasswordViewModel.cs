using System.ComponentModel.DataAnnotations;

namespace Saturn.Account.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "е-маил")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} треба да има повеќе од {2} катактери.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Лозинка")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потврди лозинка")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Лозинките не се софпаѓаат.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
