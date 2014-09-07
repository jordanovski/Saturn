using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saturn.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Корисничко име")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Презиме")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "е-маил")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} треба да има повеќе од {2} карактера.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Лозинка")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Потврди лозинка")]
        [Compare("Password", ErrorMessage = "Лозинките не се софпаѓаат.")]
        public string ConfirmPassword { get; set; }
    }
}