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
    public class ReqDocDrivingCategoryController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index(int id = 0)
        {
            Session["DrivingCategoryId"] = id;
            Session["Category"] = db.DrivingCategory.Find(id).Category;
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;

            int drivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());

            var data = db.ReqDocDrivingCategory
                .Include(r => r.DrivingCategory)
                .Include(r => r.RequiredDocument)
                .Where(w => w.DrivingCategoryId == drivingCategoryId)
                .OrderBy(o => o.DrivingCategory.Category)
                .ToList()
                .Select(s => new ReqDocDrivingCategoryViewModel
                {
                    Id = s.Id,
                    ReqDocument = s.RequiredDocument.ReqDocument,
                    DrivingCategory = s.DrivingCategory.Category
                });
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocDrivingCategory reqdocdrivingcategory = await db.ReqDocDrivingCategory.FindAsync(id);
            if (reqdocdrivingcategory == null)
            {
                return HttpNotFound();
            }
            return View(reqdocdrivingcategory);
        }


        public ActionResult Create()
        {
            ViewBag.ReqDocumentId = new SelectList(db.RequiredDocument, "Id", "ReqDocument");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ReqDocumentId,DrivingCategoryId")] ReqDocDrivingCategory reqdocdrivingcategory)
        {
            reqdocdrivingcategory.DrivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());
            if (ModelState.IsValid)
            {
                db.ReqDocDrivingCategory.Add(reqdocdrivingcategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingCategoryId"] });
            }

            ViewBag.ReqDocumentId = new SelectList(db.RequiredDocument, "Id", "ReqDocument", reqdocdrivingcategory.ReqDocumentId);
            return View(reqdocdrivingcategory);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocDrivingCategory reqdocdrivingcategory = await db.ReqDocDrivingCategory.FindAsync(id);
            if (reqdocdrivingcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReqDocumentId = new SelectList(db.RequiredDocument, "Id", "ReqDocument", reqdocdrivingcategory.ReqDocumentId);
            return View(reqdocdrivingcategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ReqDocumentId,DrivingCategoryId")] ReqDocDrivingCategory reqdocdrivingcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reqdocdrivingcategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingCategoryId"] });
            }
            ViewBag.ReqDocumentId = new SelectList(db.RequiredDocument, "Id", "ReqDocument", reqdocdrivingcategory.ReqDocumentId);
            return View(reqdocdrivingcategory);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocDrivingCategory reqdocdrivingcategory = await db.ReqDocDrivingCategory.FindAsync(id);
            if (reqdocdrivingcategory == null)
            {
                return HttpNotFound();
            }
            return View(reqdocdrivingcategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReqDocDrivingCategory reqdocdrivingcategory = await db.ReqDocDrivingCategory.FindAsync(id);
            db.ReqDocDrivingCategory.Remove(reqdocdrivingcategory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", new { Id = Session["DrivingCategoryId"] });
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