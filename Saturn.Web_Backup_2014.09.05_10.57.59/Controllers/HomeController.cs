using Saturn.Web.Logging;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger _logger;
        //public HomeController(ILogger logger)
        //{
        //    _logger = logger;
        //}

        //public ILogger Logger
        //{
        //    get
        //    {
        //        return this._logger;
        //    }
        //}

        public ActionResult Index()
        {
            //_logger.Info("Home page visited");
            return View();
        }
        
    }
}