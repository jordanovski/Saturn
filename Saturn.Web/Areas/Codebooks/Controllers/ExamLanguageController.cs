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
    public class ExamLanguageController : Controller
    {
        readonly ExamLanguageRepository repository = new ExamLanguageRepository(new SaturnDbContext());

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
            ExamLanguage examlanguage = await repository.FindAsync(p => p.Id == id);
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
                repository.InsertAsync(examlanguage);
                await repository.SaveAsync();
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
            ExamLanguage examlanguage = await repository.FindAsync(p => p.Id == id);
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
                repository.UpdateAsync(examlanguage);
                await repository.SaveAsync();
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
            ExamLanguage examlanguage = await repository.FindAsync(p => p.Id == id);
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
            ExamLanguage examlanguage = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(examlanguage);
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