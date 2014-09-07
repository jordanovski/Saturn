using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model.Codebooks;
using Saturn.Repository;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class ExamCentersController : Controller
    {
        private readonly ICityRepository cityRepository;
        private readonly IExamCentersRepository examCentersRepository;
       
        public ExamCentersController()
        {
            this.cityRepository = new CityRepository(new SaturnDbContext());
            this.examCentersRepository = new ExamCentersRepository(new SaturnDbContext());
        }
        public ExamCentersController(ICityRepository cityRepository, IExamCentersRepository examCentersRepository)
        {
            this.cityRepository = cityRepository;
            this.examCentersRepository = examCentersRepository;
        }
               

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await examCentersRepository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamCenters examcenters = await examCentersRepository.FindAsync(p => p.Id == id);
            if (examcenters == null)
            {
                return HttpNotFound();
            }
            return View(examcenters);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.CityId = new SelectList(await cityRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,TaxNumber,Address,CityId")] ExamCenters examcenters)
        {
            if (ModelState.IsValid)
            {
                examCentersRepository.InsertAsync(examcenters);
                await examCentersRepository.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(await cityRepository.GetAllAsync(), "Id", "Name", examcenters.CityId);
            return View(examcenters);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamCenters examcenters = await examCentersRepository.FindAsync(p => p.Id == id);
            if (examcenters == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(await cityRepository.GetAllAsync(), "Id", "Name", examcenters.CityId);
            return View(examcenters);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,TaxNumber,Address,CityId")] ExamCenters examcenters)
        {
            if (ModelState.IsValid)
            {
                examCentersRepository.UpdateAsync(examcenters);
                await examCentersRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(await cityRepository.GetAllAsync(), "Id", "Name", examcenters.CityId);
            return View(examcenters);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamCenters examcenters = await examCentersRepository.FindAsync(p => p.Id == id);
            if (examcenters == null)
            {
                return HttpNotFound();
            }
            return View(examcenters);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ExamCenters examcenters = await examCentersRepository.FindAsync(p => p.Id == id);
            examCentersRepository.RemoveAsync(examcenters);
            await examCentersRepository.SaveAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cityRepository.Dispose();
                examCentersRepository.Dispose();

            }
            base.Dispose(disposing);
        }
    }
}