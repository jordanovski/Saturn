using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Saturn.Account.Model
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [Required]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Презиме")]
        public string LastName { get; set; }

        [Display(Name = "Креиран на")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Последно логирање")]
        public DateTime? LastLoginDate { get; set; }

        [Display(Name = "Последна промена на лозинка")]
        public DateTime? LastPasswordChangeDate { get; set; }

        [Display(Name = "Активен")]
        public bool IsActive { get; set; }
    }
}
