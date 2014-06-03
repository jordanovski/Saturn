using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model.Codebooks;
using Saturn.UnitOfWork;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class InstructorController : Controller
    {
        private readonly InstructorUnitOfWork unitOfWork = new InstructorUnitOfWork(new SaturnDbContext());

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await unitOfWork.InstructorRepository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await unitOfWork.InstructorRepository.FindAsync(p => p.Id == id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.DrivingSchoolId = new SelectList(await unitOfWork.DrivingSchoolRepository.GetAllAsync(), "Id", "Name");

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
                unitOfWork.InstructorRepository.InsertAsync(instructor);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DrivingSchoolId = new SelectList(await unitOfWork.DrivingSchoolRepository.GetAllAsync(), "Id", "Name", instructor.DrivingSchoolId);
            return View(instructor);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await unitOfWork.InstructorRepository.FindAsync(p => p.Id == id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrivingSchoolId = new SelectList(await unitOfWork.DrivingSchoolRepository.GetAllAsync(), "Id", "Name", instructor.DrivingSchoolId);
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,UniqueNumber,DrivingSchoolId,Practice,Theory,IsActive")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.InstructorRepository.UpdateAsync(instructor);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DrivingSchoolId = new SelectList(await unitOfWork.DrivingSchoolRepository.GetAllAsync(), "Id", "Name", instructor.DrivingSchoolId);
            return View(instructor);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await unitOfWork.InstructorRepository.FindAsync(p => p.Id == id);
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
            Instructor instructor = await unitOfWork.InstructorRepository.FindAsync(p => p.Id == id);
            unitOfWork.InstructorRepository.RemoveAsync(instructor);
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