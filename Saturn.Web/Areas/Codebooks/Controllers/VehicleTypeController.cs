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
    public class VehicleTypeController : Controller
    {
        private readonly IVehicleTypeRepository repository;

        public VehicleTypeController()
        {
            this.repository = new VehicleTypeRepository(new VehiclesContext());

        }
        public VehicleTypeController(IVehicleTypeRepository repository)
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
            VehicleType vehicletype = await repository.FindAsync(p => p.Id == id);
            if (vehicletype == null)
            {
                return HttpNotFound();
            }
            return View(vehicletype);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type")] VehicleType vehicletype)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAsync(vehicletype);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(vehicletype);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicletype = await repository.FindAsync(p => p.Id == id);
            if (vehicletype == null)
            {
                return HttpNotFound();
            }
            return View(vehicletype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type")] VehicleType vehicletype)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(vehicletype);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(vehicletype);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleType vehicletype = await repository.FindAsync(p => p.Id == id);
            if (vehicletype == null)
            {
                return HttpNotFound();
            }
            return View(vehicletype);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleType vehicletype = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(vehicletype);
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