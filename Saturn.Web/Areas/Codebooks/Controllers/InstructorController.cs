using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Areas.Codebooks.Controllers
{
    public class InstructorController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.Instructor.Include(d => d.DrivingSchool).OrderBy(o => o.DrivingSchool.Name).ThenBy(o => o.LastName).ToList().Select(s => new InstructorViewModel
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                UniqueNumber = s.UniqueNumber,
                DrivingSchool = s.DrivingSchool.Name,
                Practice = s.Practice,
                Theory = s.Theory,
                IsActive = s.IsActive
            });
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await db.Instructor.FindAsync(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }


        public ActionResult Create()
        {
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchool, "Id", "Name");

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
                db.Instructor.Add(instructor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchool, "Id", "Name", instructor.DrivingSchoolId);
            return View(instructor);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await db.Instructor.FindAsync(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchool, "Id", "Name", instructor.DrivingSchoolId);
            return View(instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,UniqueNumber,DrivingSchoolId,Practice,Theory,IsActive")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instructor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchool, "Id", "Name", instructor.DrivingSchoolId);
            return View(instructor);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = await db.Instructor.FindAsync(id);
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
            Instructor instructor = await db.Instructor.FindAsync(id);
            db.Instructor.Remove(instructor);
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