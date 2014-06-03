using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model.Codebooks;
using Saturn.Repository;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class DrivingCategoryController : Controller
    {
        readonly DrivingCategoryRepository repository = new DrivingCategoryRepository(new SaturnDbContext());

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await repository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingCategory drivingcategory = await repository.FindAsync(p => p.Id == id);
            if (drivingcategory == null)
            {
                return HttpNotFound();
            }
            return View(drivingcategory);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Category,Description,AllowedNegativeTheory,AllowedNegativePolygon,AllowedNegativePracticle")] DrivingCategory drivingcategory)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAsync(drivingcategory);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(drivingcategory);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingCategory drivingcategory = await repository.FindAsync(p => p.Id == id);
            if (drivingcategory == null)
            {
                return HttpNotFound();
            }
            return View(drivingcategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Category,Description,AllowedNegativeTheory,AllowedNegativePolygon,AllowedNegativePracticle")] DrivingCategory drivingcategory)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(drivingcategory);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(drivingcategory);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingCategory drivingcategory = await repository.FindAsync(p => p.Id == id);
            if (drivingcategory == null)
            {
                return HttpNotFound();
            }
            return View(drivingcategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DrivingCategory drivingcategory = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(drivingcategory);
            await repository.SaveAsync();
            return RedirectToAction("Index");
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