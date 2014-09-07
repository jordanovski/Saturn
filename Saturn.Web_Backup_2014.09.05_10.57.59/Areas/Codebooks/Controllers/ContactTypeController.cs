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
    public class ContactTypeController : Controller
    {
        private readonly IContactTypeRepository repository;

        public ContactTypeController()
        {
            this.repository = new ContactTypeRepository(new SaturnDbContext());

        }
        public ContactTypeController(IContactTypeRepository repository)
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
            ContactType contacttype = await repository.FindAsync(p => p.Id == id);
            if (contacttype == null)
            {
                return HttpNotFound();
            }
            return View(contacttype);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type")] ContactType contacttype)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAsync(contacttype);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(contacttype);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contacttype = await repository.FindAsync(p => p.Id == id);
            if (contacttype == null)
            {
                return HttpNotFound();
            }
            return View(contacttype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type")] ContactType contacttype)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(contacttype);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(contacttype);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactType contacttype = await repository.FindAsync(p => p.Id == id);
            if (contacttype == null)
            {
                return HttpNotFound();
            }
            return View(contacttype);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactType contacttype = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(contacttype);
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