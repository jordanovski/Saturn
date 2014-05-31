using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class DrivingSchoolController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var data = db.DrivingSchool.Include(d => d.City).OrderBy(o => o.Name).ToList().Select(c => new DrivingSchoolViewModel
            {
                Id = c.Id,
                Name = c.Name,
                TaxNumber = c.TaxNumber,
                Address = c.Address,
                City = c.City.Name,
                Note = c.Note,
                IsActive = c.IsActive
            });
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingschool = await db.DrivingSchool.FindAsync(id);
            if (drivingschool == null)
            {
                return HttpNotFound();
            }
            return View(drivingschool);
        }


        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.City, "Id", "Name");

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
                db.DrivingSchool.Add(drivingschool);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.City, "Id", "Name", drivingschool.CityId);
            return View(drivingschool);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingschool = await db.DrivingSchool.FindAsync(id);
            if (drivingschool == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.City, "Id", "Name", drivingschool.CityId);
            return View(drivingschool);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CityId,Name,TaxNumber,Address,Note,IsActive")] DrivingSchool drivingschool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drivingschool).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.City, "Id", "Name", drivingschool.CityId);
            return View(drivingschool);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingschool = await db.DrivingSchool.FindAsync(id);
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
            DrivingSchool drivingschool = await db.DrivingSchool.FindAsync(id);
            db.DrivingSchool.Remove(drivingschool);
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