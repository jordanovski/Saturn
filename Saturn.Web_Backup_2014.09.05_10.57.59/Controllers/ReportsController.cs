using Microsoft.AspNet.Identity.Owin;
using Saturn.Account;
using Saturn.Account.Utilities;
using Saturn.Model.ViewModels;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Periodic()
        {
            return View();
        }

        public ActionResult Financial()
        {
            var operators = db.Users.ToList().Select(s => new OperatorViewModel()
            {
                UserName = s.UserName,
                FullName = s.FirstName + " " + s.LastName
            });
           
            ViewBag.Operators = new SelectList(operators, "UserName", "FullName");
            return View();
        }

        public ActionResult FinancialByOfficer()
        {
            return View();
        }
    }
}