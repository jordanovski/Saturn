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
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository repository;
        private readonly IDrivingSchoolRepository drivingSchoolRepository;

        public InstructorController()
        {
            this.repository = new InstructorRepository(new SaturnDbContext());
            this.drivingSchoolRepository = new DrivingSchoolRepository(new SaturnDbContext());

        }
        public InstructorController(IInstructorRepository repository, IDrivingSchoolRepository drivingSchoolRepository)
        {
            this.repository = repository;
            this.drivingSchoolRepository = drivingSchoolRepository;
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
            Instructor instructor = await repository.FindAsync(p => p.Id == id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.DrivingSchoolId = new SelectList(await drivingSchoolRepository.GetAllAsync(), "Id", "Name");

            Instructor instructor = new Instructor();
            instructor.IsActive = true;

            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,UniqueNumber,DrivingSchoolId,Practice,Theory,IsActive")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAsync(instructor);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DrivingSchoolId = new SelectList(await drivingSchoolRepository.GetAllAsync(), "Id", "Name", instructor.DrivingSchoolId);
            return View(instructor);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await repository.FindAsync(p => p.Id == id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrivingSchoolId = new SelectList(await drivingSchoolRepository.GetAllAsync(), "Id", "Name", instructor.DrivingSchoolId);
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,UniqueNumber,DrivingSchoolId,Practice,Theory,IsActive")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(instructor);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DrivingSchoolId = new SelectList(await drivingSchoolRepository.GetAllAsync(), "Id", "Name", instructor.DrivingSchoolId);
            return View(instructor);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await repository.FindAsync(p => p.Id == id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Instructor instructor = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(instructor);
            await repository.SaveAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
                drivingSchoolRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}