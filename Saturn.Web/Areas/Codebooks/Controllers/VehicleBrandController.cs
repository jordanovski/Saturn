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
    public class VehicleBrandController : Controller
    {
        readonly Repository<VehicleBrand> repository = new Repository<VehicleBrand>(new SaturnDbContext());

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await repository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VehicleBrand vehiclebrand = await repository.FindAsync(p => p.Id == id);
            if (vehiclebrand == null)
            {
                return HttpNotFound();
            }
            return View(vehiclebrand);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Brand")] VehicleBrand vehiclebrand)
        {
            if (ModelState.IsValid)
            {
                await repository.AddAsync(vehiclebrand);
                return RedirectToAction("Index");
            }

            return View(vehiclebrand);
        }


        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBrand vehiclebrand = await repository.FindAsync(p => p.Id == id);
            if (vehiclebrand == null)
            {
                return HttpNotFound();
            }
            return View(vehiclebrand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Brand")] VehicleBrand vehiclebrand)
        {
            if (ModelState.IsValid)
            {               
                await repository.UpdateAsync(vehiclebrand);
                return RedirectToAction("Index");
            }
            return View(vehiclebrand);
        }


        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBrand vehiclebrand = await repository.FindAsync(p => p.Id == id);
            if (vehiclebrand == null)
            {
                return HttpNotFound();
            }
            return View(vehiclebrand);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleBrand vehiclebrand = await repository.FindAsync(p => p.Id == id);
            await repository.RemoveAsync(vehiclebrand);
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}