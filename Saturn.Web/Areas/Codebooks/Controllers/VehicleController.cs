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
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly IVehicleTypeRepository vehicleTypeRepository;
        private readonly IVehicleBrandRepository vehicleBrandRepository;
        private readonly IDrivingSchoolRepository drivingSchoolRepository;
       
        public VehicleController()
        {
            this.vehicleRepository = new VehicleRepository(new VehiclesContext());
            this.vehicleTypeRepository = new VehicleTypeRepository(new VehiclesContext());
            this.vehicleBrandRepository = new VehicleBrandRepository(new VehiclesContext());
            this.drivingSchoolRepository= new DrivingSchoolRepository(new SaturnDbContext());
        }
        public VehicleController(IVehicleRepository vehicleRepository, IVehicleTypeRepository vehicleTypeRepository, IVehicleBrandRepository vehicleBrandRepository, IDrivingSchoolRepository drivingSchoolRepository)
        {
            this.vehicleRepository = vehicleRepository;
            this.vehicleTypeRepository = vehicleTypeRepository;
            this.vehicleBrandRepository = vehicleBrandRepository;
            this.drivingSchoolRepository = drivingSchoolRepository;
        }


        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await vehicleRepository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = await vehicleRepository.FindAsync(p => p.Id == id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.VehicleTypeId = new SelectList(await vehicleTypeRepository.GetAllAsync(), "Id", "Type");
            ViewBag.VehicleBrandId = new SelectList(await vehicleBrandRepository.GetAllAsync(), "Id", "Brand");
            ViewBag.DrivingSchoolId = new SelectList(await drivingSchoolRepository.GetAllAsync(), "Id", "Name");

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
                vehicleRepository.InsertAsync(vehicle);
                await vehicleRepository.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleTypeId = new SelectList(await vehicleTypeRepository.GetAllAsync(), "Id", "Type", vehicle.VehicleTypeId);
            ViewBag.VehicleBrandId = new SelectList(await vehicleBrandRepository.GetAllAsync(), "Id", "Brand", vehicle.VehicleBrandId);
            ViewBag.DrivingSchoolId = new SelectList(await drivingSchoolRepository.GetAllAsync(), "Id", "Name", vehicle.DrivingSchoolId);
           
            return View(vehicle);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await vehicleRepository.FindAsync(p => p.Id == id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleTypeId = new SelectList(await vehicleTypeRepository.GetAllAsync(), "Id", "Type", vehicle.VehicleTypeId);
            ViewBag.VehicleBrandId = new SelectList(await vehicleBrandRepository.GetAllAsync(), "Id", "Brand", vehicle.VehicleBrandId);
            ViewBag.DrivingSchoolId = new SelectList(await drivingSchoolRepository.GetAllAsync(), "Id", "Name", vehicle.DrivingSchoolId);

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DrivingSchoolId,VehicleTypeId,VehicleBrandId,CommercialMark,RegistrationNumber,IsActive")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicleRepository.UpdateAsync(vehicle);
                await vehicleRepository.SaveAsync(); 
                return RedirectToAction("Index");
            }
            ViewBag.VehicleTypeId = new SelectList(await vehicleTypeRepository.GetAllAsync(), "Id", "Type", vehicle.VehicleTypeId);
            ViewBag.VehicleBrandId = new SelectList(await vehicleBrandRepository.GetAllAsync(), "Id", "Brand", vehicle.VehicleBrandId);
            ViewBag.DrivingSchoolId = new SelectList(await drivingSchoolRepository.GetAllAsync(), "Id", "Name", vehicle.DrivingSchoolId);

            return View(vehicle);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await vehicleRepository.FindAsync(p => p.Id == id);
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
            Vehicle vehicle = await vehicleRepository.FindAsync(p => p.Id == id);
            vehicleRepository.RemoveAsync(vehicle);
            await vehicleRepository.SaveAsync(); 
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                vehicleRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}