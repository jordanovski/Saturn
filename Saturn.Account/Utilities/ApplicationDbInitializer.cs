using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Saturn.Account.Model;
using System.Data.Entity;
using System.Web;

namespace Saturn.Account.Utilities
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string Name = "admin@admin.com";
            const string Password = "Admin@123456";
            const string RoleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(RoleName);
            if (role == null)
            {
                role = new IdentityRole(RoleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(Name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = Name, Email = Name };
                var result = userManager.Create(user, Password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
