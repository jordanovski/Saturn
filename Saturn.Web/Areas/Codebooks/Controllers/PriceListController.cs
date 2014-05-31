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
    public class PriceListController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.PriceList
                .Include(p => p.DrivingCategory)
                .Include(p => p.ExamType)
                .OrderBy(o => o.DrivingCategory.Category)
                .Select(s => new PriceListViewModel
                {
                    Id = s.Id,
                    DrivingCategory = s.DrivingCategory.Category,
                    ExaminationType = s.ExamType.Type,
                    PriceFirst = s.PriceFirst,
                    TaxFirst = s.TaxFirst,
                    PriceRepeated = s.PriceRepeated,
                    TaxRepeated = s.TaxRepeated,
                    MaterialCosts = s.MaterialCosts,
                    VAT = s.VAT,
                    Note = s.Note
                });
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceList pricelist = await db.PriceList.FindAsync(id);
            if (pricelist == null)
            {
                return HttpNotFound();
            }
            return View(pricelist);
        }


        public ActionResult Create()
        {
            ViewBag.DrivingCategoryId = new SelectList(db.DrivingCategory, "Id", "Category");
            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DrivingCategoryId,ExamTypeId,PriceFirst,TaxFirst,PriceRepeated,TaxRepeated,MaterialCosts,VAT,Note")] PriceList pricelist)
        {
            if (ModelState.IsValid)
            {
                db.PriceList.Add(pricelist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DrivingCategoryId = new SelectList(db.DrivingCategory, "Id", "Category", pricelist.DrivingCategoryId);
            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type", pricelist.ExamTypeId);
            return View(pricelist);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceList pricelist = await db.PriceList.FindAsync(id);
            if (pricelist == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrivingCategoryId = new SelectList(db.DrivingCategory, "Id", "Category", pricelist.DrivingCategoryId);
            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type", pricelist.ExamTypeId);
            return View(pricelist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DrivingCategoryId,ExamTypeId,PriceFirst,TaxFirst,PriceRepeated,TaxRepeated,MaterialCosts,VAT,Note")] PriceList pricelist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pricelist).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DrivingCategoryId = new SelectList(db.DrivingCategory, "Id", "Category", pricelist.DrivingCategoryId);
            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type", pricelist.ExamTypeId);
            return View(pricelist);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceList pricelist = await db.PriceList.FindAsync(id);
            if (pricelist == null)
            {
                return HttpNotFound();
            }
            return View(pricelist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PriceList pricelist = await db.PriceList.FindAsync(id);
            db.PriceList.Remove(pricelist);
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