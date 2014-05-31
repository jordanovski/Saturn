using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model.Codebooks;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class DrivingCategoryController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.DrivingCategory.OrderBy(o => o.Category).ToList();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingCategory drivingcategory = await db.DrivingCategory.FindAsync(id);
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
                db.DrivingCategory.Add(drivingcategory);
                await db.SaveChangesAsync();
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
            DrivingCategory drivingcategory = await db.DrivingCategory.FindAsync(id);
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
                db.Entry(drivingcategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
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
            DrivingCategory drivingcategory = await db.DrivingCategory.FindAsync(id);
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
            DrivingCategory drivingcategory = await db.DrivingCategory.FindAsync(id);
            db.DrivingCategory.Remove(drivingcategory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}