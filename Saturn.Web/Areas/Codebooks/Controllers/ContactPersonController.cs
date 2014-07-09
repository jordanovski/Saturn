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
    public class ContactPersonController : Controller
    {
        private readonly IContactPersonRepository repository;
        private readonly IContactTypeRepository contactTypeRepository;

        public ContactPersonController()
        {
            this.repository = new ContactPersonRepository(new SaturnDbContext());
            this.contactTypeRepository = new ContactTypeRepository(new SaturnDbContext());

        }
        public ContactPersonController(IContactPersonRepository repository, IContactTypeRepository contactTypeRepository)
        {
            this.repository = repository;
            this.contactTypeRepository = contactTypeRepository;
        }
        

        public ActionResult Index(int id = 0)
        {
            Session["DrivingSchoolId"] = id;
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            int drivingSchoolId = int.Parse(Session["DrivingSchoolId"].ToString());
            var data = await repository.FindAllAsync(f => f.DrivingSchoolId == drivingSchoolId);
            
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactperson = await repository.FindAsync(p => p.Id == id);
            if (contactperson == null)
            {
                return HttpNotFound();
            }
            return View(contactperson);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.ContactTypeId = new SelectList(await contactTypeRepository.GetAllAsync(), "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DrivingSchoolId,ContactTypeId,ContactValue")] ContactPerson contactperson)
        {
            contactperson.DrivingSchoolId = int.Parse(Session["DrivingSchoolId"].ToString());
            if (ModelState.IsValid)
            {
                repository.InsertAsync(contactperson);
                await repository.SaveAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingSchoolId"] });
            }

            ViewBag.ContactTypeId = new SelectList(await contactTypeRepository.GetAllAsync(), "Id", "Type", contactperson.ContactTypeId);

            return View(contactperson);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactperson = await repository.FindAsync(p => p.Id == id);
            if (contactperson == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactTypeId = new SelectList(await contactTypeRepository.GetAllAsync(), "Id", "Type", contactperson.ContactTypeId);
            
            return View(contactperson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DrivingSchoolId,ContactTypeId,ContactValue")] ContactPerson contactperson)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(contactperson);
                await repository.SaveAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingSchoolId"] });
            }
            ViewBag.ContactTypeId = new SelectList(await contactTypeRepository.GetAllAsync(), "Id", "Type", contactperson.ContactTypeId);
            return View(contactperson);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactperson = await repository.FindAsync(p => p.Id == id);
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
            ContactPerson contactperson = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(contactperson);
            await repository.SaveAsync();
            return RedirectToAction("Index", new { Id = Session["DrivingSchoolId"] });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
                contactTypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}