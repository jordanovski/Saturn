using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model.Codebooks;
using Saturn.UnitOfWork;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class ExamCentersController : Controller
    {
        private readonly ExamCentersUnitOfWork unitOfWork = new ExamCentersUnitOfWork(new SaturnDbContext());

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await unitOfWork.ExamCentersRepository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamCenters examcenters = await unitOfWork.ExamCentersRepository.FindAsync(p => p.Id == id);
            if (examcenters == null)
            {
                return HttpNotFound();
            }
            return View(examcenters);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.CityId = new SelectList(await unitOfWork.CityRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,TaxNumber,Address,CityId")] ExamCenters examcenters)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ExamCentersRepository.InsertAsync(examcenters);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(await unitOfWork.CityRepository.GetAllAsync(), "Id", "Name", examcenters.CityId);
            return View(examcenters);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamCenters examcenters = await unitOfWork.ExamCentersRepository.FindAsync(p => p.Id == id);
            if (examcenters == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(await unitOfWork.CityRepository.GetAllAsync(), "Id", "Name", examcenters.CityId);
            return View(examcenters);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,TaxNumber,Address,CityId")] ExamCenters examcenters)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ExamCentersRepository.UpdateAsync(examcenters);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(await unitOfWork.CityRepository.GetAllAsync(), "Id", "Name", examcenters.CityId);
            return View(examcenters);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamCenters examcenters = await unitOfWork.ExamCentersRepository.FindAsync(p => p.Id == id);
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
            ExamCenters examcenters = await unitOfWork.ExamCentersRepository.FindAsync(p => p.Id == id);
            unitOfWork.ExamCentersRepository.RemoveAsync(examcenters);
            await unitOfWork.SaveAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}