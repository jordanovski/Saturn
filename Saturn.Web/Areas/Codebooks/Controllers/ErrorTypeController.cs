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
    public class ErrorTypeController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.ErrorType
                .ToList()
                .Select(s => new ErrorTypeViewModel
                {
                    Id = s.Id,
                    Form = s.Form,
                    Question = s.Question,
                    Description = s.Description,
                    DrivingCategory = s.DrivingCategory,
                    PenaltyPoints = s.PenaltyPoints
                });
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorType errortype = await db.ErrorType.FindAsync(id);
            if (errortype == null)
            {
                return HttpNotFound();
            }
            return View(errortype);
        }


        public ActionResult Create()
        {
            ViewBag.DrivingCategoryId = new SelectList(db.DrivingCategory.OrderBy(o => o.Category), "Id", "Category");
            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Form,Question,Description,PenaltyPoints,DrivingCategory,ExamTypeId")] ErrorType errortype)
        {
            if (ModelState.IsValid)
            {
                db.ErrorType.Add(errortype);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type", errortype.ExamTypeId);
            return View(errortype);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorType errortype = await db.ErrorType.FindAsync(id);
            if (errortype == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type", errortype.ExamTypeId);
            return View(errortype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Form,Question,Description,PenaltyPoints,DrivingCategory,ExamTypeId")] ErrorType errortype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(errortype).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type", errortype.ExamTypeId);
            return View(errortype);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorType errortype = await db.ErrorType.FindAsync(id);
            if (errortype == null)
            {
                return HttpNotFound();
            }
            return View(errortype);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ErrorType errortype = await db.ErrorType.FindAsync(id);
            db.ErrorType.Remove(errortype);
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