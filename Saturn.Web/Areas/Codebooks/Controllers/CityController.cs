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
    public class CityController : Controller
    {
        private readonly ICityRepository repository;

        public CityController()
        {
            this.repository = new CityRepository(new SaturnDbContext());

        }
        public CityController(ICityRepository repository)
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
            City city = await repository.FindAsync(p => p.Id == id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] City city)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAsync(city);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(city);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = await repository.FindAsync(p => p.Id == id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] City city)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(city);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(city);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = await repository.FindAsync(p => p.Id == id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            City city = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(city);
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