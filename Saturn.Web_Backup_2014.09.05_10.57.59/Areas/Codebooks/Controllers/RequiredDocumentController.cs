using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model.Codebooks;
using Saturn.Repository;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class RequiredDocumentController : Controller
    {
        private readonly IRequiredDocumentRepository repository;

        public RequiredDocumentController()
        {
            this.repository = new RequiredDocumentRepository(new SaturnDbContext());

        }
        public RequiredDocumentController(IRequiredDocumentRepository repository)
        {
            this.repository = repository;

        }


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
            RequiredDocument requireddocument = await repository.FindAsync(p => p.Id == id);
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
                repository.InsertAsync(requireddocument);
                await repository.SaveAsync();
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
            RequiredDocument requireddocument = await repository.FindAsync(p => p.Id == id);
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
                repository.UpdateAsync(requireddocument);
                await repository.SaveAsync();
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
            RequiredDocument requireddocument = await repository.FindAsync(p => p.Id == id);
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
            RequiredDocument requireddocument = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(requireddocument);
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