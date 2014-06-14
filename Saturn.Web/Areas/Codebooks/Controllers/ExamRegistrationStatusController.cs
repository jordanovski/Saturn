using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Repository;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class ExamRegistrationStatusController : Controller
    {
        private readonly IExamRegistrationStatusRepository repository;

        public ExamRegistrationStatusController()
        {
            this.repository = new ExamRegistrationStatusRepository(new SaturnDbContext());

        }
        public ExamRegistrationStatusController(IExamRegistrationStatusRepository repository)
        {
            this.repository = repository;

        }

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await repository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}