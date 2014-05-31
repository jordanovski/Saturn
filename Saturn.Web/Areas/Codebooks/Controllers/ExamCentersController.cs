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
    public class ExamCentersController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.ExamCenters.Include(d => d.City).OrderBy(o => o.Name).ToList().Select(s => new ExamCenterViewModel
            {
                Id = s.Id,
                Name = s.Name,
                TaxNumber = s.TaxNumber,
                Address = s.Address,
                City = s.City.Name
            });
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamCenters examcenters = await db.ExamCenters.FindAsync(id);
            if (examcenters == null)
            {
                return HttpNotFound();
            }
            return View(examcenters);
        }


        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.City, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,TaxNumber,Address,CityId")] ExamCenters examcenters)
        {
            if (ModelState.IsValid)
            {
                db.ExamCenters.Add(examcenters);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.City, "Id", "Name", examcenters.CityId);
            return View(examcenters);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamCenters examcenters = await db.ExamCenters.FindAsync(id);
            if (examcenters == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.City, "Id", "Name", examcenters.CityId);
            return View(examcenters);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,TaxNumber,Address,CityId")] ExamCenters examcenters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examcenters).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.City, "Id", "Name", examcenters.CityId);
            return View(examcenters);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamCenters examcenters = await db.ExamCenters.FindAsync(id);
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
            ExamCenters examcenters = await db.ExamCenters.FindAsync(id);
            db.ExamCenters.Remove(examcenters);
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