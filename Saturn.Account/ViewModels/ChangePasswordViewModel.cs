using System.ComponentModel.DataAnnotations;

namespace Saturn.Account.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Актуелна лозинка")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} мора да има повеќе од {2} карактери.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова лозинка")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потврди нова лозинка")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Лозинките не се софпаѓаат.")]
        public string ConfirmPassword { get; set; }
    }
}
