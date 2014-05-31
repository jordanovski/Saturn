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
    public class ContactPersonController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index(int id = 0)
        {
            Session["DrivingSchoolId"] = id;
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;

            int drivingSchoolId = int.Parse(Session["DrivingSchoolId"].ToString());

            var data = db.ContactPerson
                .Include(c => c.ContactType)
                .Include(c => c.DrivingSchool)
                .Where(w => w.DrivingSchoolId == drivingSchoolId)
                .Select(s => new ContactPersonViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    DrivingSchool = s.DrivingSchool.Name,
                    ContactType = s.ContactType.Type,
                    ContactValue = s.ContactValue
                });
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactperson = await db.ContactPerson.FindAsync(id);
            if (contactperson == null)
            {
                return HttpNotFound();
            }
            return View(contactperson);
        }


        public ActionResult Create()
        {
            ViewBag.ContactTypeId = new SelectList(db.ContactType, "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DrivingSchoolId,ContactTypeId,ContactValue")] ContactPerson contactperson)
        {
            contactperson.DrivingSchoolId = int.Parse(Session["DrivingSchoolId"].ToString());
            if (ModelState.IsValid)
            {
                db.ContactPerson.Add(contactperson);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingSchoolId"] });
            }

            ViewBag.ContactTypeId = new SelectList(db.ContactType, "Id", "Type", contactperson.ContactTypeId);
            return View(contactperson);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactperson = await db.ContactPerson.FindAsync(id);
            if (contactperson == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactTypeId = new SelectList(db.ContactType, "Id", "Type", contactperson.ContactTypeId);
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchool, "Id", "Name", contactperson.DrivingSchoolId);
            return View(contactperson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DrivingSchoolId,ContactTypeId,ContactValue")] ContactPerson contactperson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactperson).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingSchoolId"] });
            }
            ViewBag.ContactTypeId = new SelectList(db.ContactType, "Id", "Type", contactperson.ContactTypeId);
            return View(contactperson);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactperson = await db.ContactPerson.FindAsync(id);
            if (contactperson == null)
            {
                return HttpNotFound();
            }
            return View(contactperson);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactPerson contactperson = await db.ContactPerson.FindAsync(id);
            db.ContactPerson.Remove(contactperson);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", new { Id = Session["DrivingSchoolId"] });
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