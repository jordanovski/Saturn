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
    public class DrivingSchoolController : Controller
    {
        readonly DrivingSchoolUnitOfWork unitOfWork = new DrivingSchoolUnitOfWork(new SaturnDbContext());

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await unitOfWork.DrivingSchoolRepository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingschool = await unitOfWork.DrivingSchoolRepository.FindAsync(p => p.Id == id);
            if (drivingschool == null)
            {
                return HttpNotFound();
            }
            return View(drivingschool);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.CityId = new SelectList(await unitOfWork.CityRepository.GetAllAsync(), "Id", "Name");

            DrivingSchool drivingschool = new DrivingSchool();
            drivingschool.IsActive = true;

            return View(drivingschool);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CityId,Name,TaxNumber,Address,Note,IsActive")] DrivingSchool drivingschool)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DrivingSchoolRepository.InsertAsync(drivingschool);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(await unitOfWork.CityRepository.GetAllAsync(), "Id", "Name", drivingschool.CityId);
            return View(drivingschool);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingschool = await unitOfWork.DrivingSchoolRepository.FindAsync(p => p.Id == id);
            if (drivingschool == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(await unitOfWork.CityRepository.GetAllAsync(), "Id", "Name", drivingschool.CityId);
            return View(drivingschool);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CityId,Name,TaxNumber,Address,Note,IsActive")] DrivingSchool drivingschool)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.DrivingSchoolRepository.UpdateAsync(drivingschool);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(await unitOfWork.CityRepository.GetAllAsync(), "Id", "Name", drivingschool.CityId);
            return View(drivingschool);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingschool = await unitOfWork.DrivingSchoolRepository.FindAsync(p => p.Id == id);
            if (drivingschool == null)
            {
                return HttpNotFound();
            }
            return View(drivingschool);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DrivingSchool drivingschool = await unitOfWork.DrivingSchoolRepository.FindAsync(p => p.Id == id);
            unitOfWork.DrivingSchoolRepository.RemoveAsync(drivingschool);
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