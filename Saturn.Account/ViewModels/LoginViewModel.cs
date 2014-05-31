using System.ComponentModel.DataAnnotations;

namespace Saturn.Account.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Корисничко име")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Лозинка")]
        public string Password { get; set; }

        [Display(Name = "Запамти ме?")]
        public bool RememberMe { get; set; }
    }
}
