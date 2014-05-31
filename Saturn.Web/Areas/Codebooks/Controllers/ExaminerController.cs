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
    public class ExaminerController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Examiner.OrderBy(o => o.LastName).ToList();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examiner examiner = await db.Examiner.FindAsync(id);
            if (examiner == null)
            {
                return HttpNotFound();
            }
            return View(examiner);
        }


        public ActionResult Create()
        {
            Examiner examiner = new Examiner();
            examiner.IsActive = true;

            return View(examiner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,President,Practice,Theory,IsActive")] Examiner examiner)
        {
            if (ModelState.IsValid)
            {
                db.Examiner.Add(examiner);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(examiner);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examiner examiner = await db.Examiner.FindAsync(id);
            if (examiner == null)
            {
                return HttpNotFound();
            }
            return View(examiner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,President,Practice,Theory,IsActive")] Examiner examiner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examiner).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(examiner);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examiner examiner = await db.Examiner.FindAsync(id);
            if (examiner == null)
            {
                return HttpNotFound();
            }
            return View(examiner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Examiner examiner = await db.Examiner.FindAsync(id);
            db.Examiner.Remove(examiner);
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