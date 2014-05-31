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
    public class RequiredDocumentController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.RequiredDocument.OrderBy(o => o.ReqDocument).ToList();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequiredDocument requireddocument = await db.RequiredDocument.FindAsync(id);
            if (requireddocument == null)
            {
                return HttpNotFound();
            }
            return View(requireddocument);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ReqDocument")] RequiredDocument requireddocument)
        {
            if (ModelState.IsValid)
            {
                db.RequiredDocument.Add(requireddocument);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(requireddocument);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequiredDocument requireddocument = await db.RequiredDocument.FindAsync(id);
            if (requireddocument == null)
            {
                return HttpNotFound();
            }
            return View(requireddocument);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ReqDocument")] RequiredDocument requireddocument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requireddocument).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(requireddocument);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequiredDocument requireddocument = await db.RequiredDocument.FindAsync(id);
            if (requireddocument == null)
            {
                return HttpNotFound();
            }
            return View(requireddocument);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RequiredDocument requireddocument = await db.RequiredDocument.FindAsync(id);
            db.RequiredDocument.Remove(requireddocument);
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