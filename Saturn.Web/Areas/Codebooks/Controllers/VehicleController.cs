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
    public class VehicleController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();
        private readonly SaturnDbViewContext dbView = new SaturnDbViewContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            dbView.Configuration.ProxyCreationEnabled = false;
            var data = dbView.ViewVehicles.OrderBy(o => o.DrivingSchool).ThenBy(o => o.VehicleBrand).ToList();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }


        public ActionResult Create()
        {
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType.OrderBy(o => o.Type), "Id", "Type");
            ViewBag.VehicleBrandId = new SelectList(db.VehicleBrand.OrderBy(o => o.Brand), "Id", "Brand");
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchool.OrderBy(o => o.Name), "Id", "Name");

            Vehicle vehicle = new Vehicle();
            vehicle.IsActive = true;

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DrivingSchoolId,VehicleTypeId,VehicleBrandId,CommercialMark,RegistrationNumber,IsActive")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicle.Add(vehicle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleTypeId = new SelectList(db.VehicleType.OrderBy(o => o.Type), "Id", "Type", vehicle.VehicleTypeId);
            ViewBag.VehicleBrandId = new SelectList(db.VehicleBrand.OrderBy(o => o.Brand), "Id", "Brand", vehicle.VehicleBrandId);
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchool.OrderBy(o => o.Name), "Id", "Name", vehicle.DrivingSchoolId);
            return View(vehicle);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType.OrderBy(o => o.Type), "Id", "Type", vehicle.VehicleTypeId);
            ViewBag.VehicleBrandId = new SelectList(db.VehicleBrand.OrderBy(o => o.Brand), "Id", "Brand", vehicle.VehicleBrandId);
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchool.OrderBy(o => o.Name), "Id", "Name", vehicle.DrivingSchoolId);
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DrivingSchoolId,VehicleTypeId,VehicleBrandId,CommercialMark,RegistrationNumber,IsActive")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleTypeId = new SelectList(db.VehicleType.OrderBy(o => o.Type), "Id", "Type", vehicle.VehicleTypeId);
            ViewBag.VehicleBrandId = new SelectList(db.VehicleBrand.OrderBy(o => o.Brand), "Id", "Brand", vehicle.VehicleBrandId);
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchool.OrderBy(o => o.Name), "Id", "Name", vehicle.DrivingSchoolId);
            return View(vehicle);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vehicle vehicle = await db.Vehicle.FindAsync(id);
            db.Vehicle.Remove(vehicle);
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