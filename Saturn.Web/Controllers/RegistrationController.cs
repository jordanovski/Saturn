using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model;
using Saturn.Model.Views;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class RegistrationController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();
        private readonly SaturnDbViewContext dbView = new SaturnDbViewContext();
        //private readonly List<VehicleFrom> vehicleFrom = new List<VehicleFrom>() { new VehicleFrom() { Id = 1, Name = "Авто школа" }, new VehicleFrom() { Id = 2, Name = "ИЦ" } };

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = dbView.ViewRegistrations.OrderByDescending(o => o.RegistrationDate).ToList();
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = await db.Registration.FindAsync(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }


        public ActionResult Create(int id = 0)
        {
            Session["CandidateId"] = id;

            var pom = db.Registration.Where(w => w.CandidateId == id);


            var candidate = GetCandidate();
            ViewBag.Candidate = candidate;

            Registration registration = new Registration();
            registration.Place = candidate.City;
            registration.CandidateId = id;
            registration.StatusId = 2;
            registration.DrivingCategoryId = candidate.DrivingCategoryId;
            

            ViewBagDropDown(null);

            return View(registration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RegistrationNumber,RegistrationDate,Place,OrdinalNumber,CandidateId,DrivingSchoolId,DrivingCategoryId,InstructorPracticeId,InstructorTheoryId,VehicleTypeId,VehicleId,AuxiliaryVehicleId,Price,Tax,Note,StatusId")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                //db.Database.Log = Logger;
                db.Registration.Add(registration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var id = int.Parse(Session["CandidateId"].ToString());

            ViewBagDropDown(registration);

            var candidate = dbView.ViewCandidates.Find(id);
            ViewBag.Candidate = candidate;

            return View(registration);
        }
      

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = await db.Registration.FindAsync(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegistrationStatusId = new SelectList(db.RegistrationStatus, "Id", "Status", registration.StatusId);
            ViewBag.InstructorPracticeId = new SelectList(db.Instructor, "Id", "FullName", registration.InstructorPracticeId);
            ViewBag.InstructorTheoryId = new SelectList(db.Instructor, "Id", "FullName", registration.InstructorTheoryId);
            return View(registration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RegistrationNumber,RegistrationDate,Place,OrdinalNumber,CandidateId,DrivingSchoolId,DrivingCategoryId,InstructorPracticeId,InstructorTheoryId,VehicleTypeId,VehicleId,AuxiliaryVehicleId,Price,Tax,Note,RegistrationStatusId")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RegistrationStatusId = new SelectList(db.RegistrationStatus, "Id", "Status", registration.StatusId);
            ViewBag.InstructorPracticeId = new SelectList(db.Instructor, "Id", "FullName", registration.InstructorPracticeId);
            ViewBag.InstructorTheoryId = new SelectList(db.Instructor, "Id", "FullName", registration.InstructorTheoryId);
            return View(registration);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = await db.Registration.FindAsync(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Registration registration = await db.Registration.FindAsync(id);
            db.Registration.Remove(registration);
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


        private ViewCandidates GetCandidate()
        {
            var id = int.Parse(Session["CandidateId"].ToString());

            return dbView.ViewCandidates.First(f => f.CandidateId == id);
        }
        
        private void ViewBagDropDown(Registration registration)
        {
            var vehicles = dbView.ViewVehicles.Where(w => (bool)w.VehicleIsActive).ToList();
            var drivingSchools = db.DrivingSchool.Where(w => w.IsActive).OrderBy(o => o.Name);
            var instructorTheory = db.Instructor.Where(w => w.IsActive).OrderBy(o => o.LastName);
            var auxiliaryVehicles = dbView.ViewVehicles.Where(w => (bool)w.VehicleIsActive);
            var instructorPractice = db.Instructor.Where(w => w.IsActive).OrderBy(o => o.LastName);

            if (registration == null)
            {
                ViewBag.VehicleId = new SelectList(vehicles, "VehicleId", "FullName");
                //ViewBag.VehicleFrom = new SelectList(vehicleFrom, "Id", "Name");
                ViewBag.DrivingSchoolId = new SelectList(drivingSchools, "Id", "Name");
                ViewBag.InstructorTheoryId = new SelectList(instructorTheory, "Id", "FullName");
                ViewBag.AuxiliaryVehicleId = new SelectList(auxiliaryVehicles, "VehicleId", "FullName");
                ViewBag.InstructorPracticeId = new SelectList(instructorPractice, "Id", "FullName");
            }
            else
            {
                ViewBag.VehicleId = new SelectList(vehicles, "VehicleId", "FullName", registration.VehicleId);
                //ViewBag.VehicleFrom = new SelectList(vehicleFrom, "Id", "Name", registration.VehicleFrom);
                ViewBag.DrivingSchoolId = new SelectList(drivingSchools, "Id", "Name", registration.DrivingSchoolId);
                ViewBag.InstructorTheoryId = new SelectList(instructorTheory, "Id", "FirstName", registration.InstructorTheoryId);
                ViewBag.AuxiliaryVehicleId = new SelectList(auxiliaryVehicles, "VehicleId", "FullName", registration.AuxiliaryVehicleId);
                ViewBag.InstructorPracticeId = new SelectList(instructorPractice, "Id", "FirstName", registration.InstructorPracticeId);
            }
        }






        public ActionResult FilterMenuCustomization_Status()
        {
            return Json(db.RegistrationStatus.Select(e => e.Status).Distinct(), JsonRequestBehavior.AllowGet);
        }
    }
}