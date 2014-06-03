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
    public class ExaminerController : Controller
    {
        readonly ExaminerRepository repository = new ExaminerRepository(new SaturnDbContext());

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
            Examiner examiner = await repository.FindAsync(p => p.Id == id);
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
                repository.InsertAsync(examiner);
                await repository.SaveAsync();
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
            Examiner examiner = await repository.FindAsync(p => p.Id == id);
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
                repository.UpdateAsync(examiner);
                await repository.SaveAsync();
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
            Examiner examiner = await repository.FindAsync(p => p.Id == id);
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
            Examiner examiner = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(examiner);
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