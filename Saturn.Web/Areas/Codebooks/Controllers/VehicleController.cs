using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model.Codebooks;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Saturn.UnitOfWork;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class VehicleController : Controller
    {
        readonly VehicleUnitOfWork unitOfWork = new VehicleUnitOfWork(new SaturnDbContext());

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await unitOfWork.VehicleRepository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = await unitOfWork.VehicleRepository.FindAsync(p => p.Id == id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.VehicleTypeId = new SelectList(await unitOfWork.VehicleTypeRepository.GetAllAsync(), "Id", "Type");
            ViewBag.VehicleBrandId = new SelectList(await unitOfWork.VehicleBrandRepository.GetAllAsync(), "Id", "Brand");
            ViewBag.DrivingSchoolId = new SelectList(await unitOfWork.DrivingSchoolRepository.GetAllAsync(), "Id", "Name");

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
                unitOfWork.VehicleRepository.InsertAsync(vehicle);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleTypeId = new SelectList(await unitOfWork.VehicleTypeRepository.GetAllAsync(), "Id", "Type", vehicle.VehicleTypeId);
            ViewBag.VehicleBrandId = new SelectList(await unitOfWork.VehicleBrandRepository.GetAllAsync(), "Id", "Brand", vehicle.VehicleBrandId);
            ViewBag.DrivingSchoolId = new SelectList(await unitOfWork.DrivingSchoolRepository.GetAllAsync(), "Id", "Name", vehicle.DrivingSchoolId);
           
            return View(vehicle);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await unitOfWork.VehicleRepository.FindAsync(p => p.Id == id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleTypeId = new SelectList(await unitOfWork.VehicleTypeRepository.GetAllAsync(), "Id", "Type", vehicle.VehicleTypeId);
            ViewBag.VehicleBrandId = new SelectList(await unitOfWork.VehicleBrandRepository.GetAllAsync(), "Id", "Brand", vehicle.VehicleBrandId);
            ViewBag.DrivingSchoolId = new SelectList(await unitOfWork.DrivingSchoolRepository.GetAllAsync(), "Id", "Name", vehicle.DrivingSchoolId);

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DrivingSchoolId,VehicleTypeId,VehicleBrandId,CommercialMark,RegistrationNumber,IsActive")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.VehicleRepository.UpdateAsync(vehicle);
                await unitOfWork.SaveAsync(); 
                return RedirectToAction("Index");
            }
            ViewBag.VehicleTypeId = new SelectList(await unitOfWork.VehicleTypeRepository.GetAllAsync(), "Id", "Type", vehicle.VehicleTypeId);
            ViewBag.VehicleBrandId = new SelectList(await unitOfWork.VehicleBrandRepository.GetAllAsync(), "Id", "Brand", vehicle.VehicleBrandId);
            ViewBag.DrivingSchoolId = new SelectList(await unitOfWork.DrivingSchoolRepository.GetAllAsync(), "Id", "Name", vehicle.DrivingSchoolId);

            return View(vehicle);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await unitOfWork.VehicleRepository.FindAsync(p => p.Id == id);
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
            Vehicle vehicle = await unitOfWork.VehicleRepository.FindAsync(p => p.Id == id);
            unitOfWork.VehicleRepository.RemoveAsync(vehicle);
            await unitOfWork.SaveAsync(); 
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}