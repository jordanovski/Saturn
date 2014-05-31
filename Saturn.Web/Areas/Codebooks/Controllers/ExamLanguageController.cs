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
    public class ExamLanguageController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.ExamLanguage.ToList();
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamLanguage examlanguage = await db.ExamLanguage.FindAsync(id);
            if (examlanguage == null)
            {
                return HttpNotFound();
            }
            return View(examlanguage);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Language,LanguageCode")] ExamLanguage examlanguage)
        {
            if (ModelState.IsValid)
            {
                db.ExamLanguage.Add(examlanguage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(examlanguage);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamLanguage examlanguage = await db.ExamLanguage.FindAsync(id);
            if (examlanguage == null)
            {
                return HttpNotFound();
            }
            return View(examlanguage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Language,LanguageCode")] ExamLanguage examlanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examlanguage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(examlanguage);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamLanguage examlanguage = await db.ExamLanguage.FindAsync(id);
            if (examlanguage == null)
            {
                return HttpNotFound();
            }
            return View(examlanguage);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ExamLanguage examlanguage = await db.ExamLanguage.FindAsync(id);
            db.ExamLanguage.Remove(examlanguage);
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