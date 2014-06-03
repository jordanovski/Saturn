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
    public class ContactPersonController : Controller
    {
        readonly ContactPersonUnitOfWork unitOfWork = new ContactPersonUnitOfWork(new SaturnDbContext());

        public ActionResult Index(int id = 0)
        {
            Session["DrivingSchoolId"] = id;
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            int drivingSchoolId = int.Parse(Session["DrivingSchoolId"].ToString());
            var data = await unitOfWork.ContactPersonRepository.FindAllAsync(f => f.DrivingSchoolId == drivingSchoolId);
            
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactperson = await unitOfWork.ContactPersonRepository.FindAsync(p => p.Id == id);
            if (contactperson == null)
            {
                return HttpNotFound();
            }
            return View(contactperson);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.ContactTypeId = new SelectList(await unitOfWork.ContactTypeRepository.GetAllAsync(), "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DrivingSchoolId,ContactTypeId,ContactValue")] ContactPerson contactperson)
        {
            contactperson.DrivingSchoolId = int.Parse(Session["DrivingSchoolId"].ToString());
            if (ModelState.IsValid)
            {
                unitOfWork.ContactPersonRepository.InsertAsync(contactperson);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingSchoolId"] });
            }

            ViewBag.ContactTypeId = new SelectList(await unitOfWork.ContactTypeRepository.GetAllAsync(), "Id", "Type", contactperson.ContactTypeId);

            return View(contactperson);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactperson = await unitOfWork.ContactPersonRepository.FindAsync(p => p.Id == id);
            if (contactperson == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactTypeId = new SelectList(await unitOfWork.ContactTypeRepository.GetAllAsync(), "Id", "Type", contactperson.ContactTypeId);
            
            return View(contactperson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DrivingSchoolId,ContactTypeId,ContactValue")] ContactPerson contactperson)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ContactPersonRepository.UpdateAsync(contactperson);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingSchoolId"] });
            }
            ViewBag.ContactTypeId = new SelectList(await unitOfWork.ContactTypeRepository.GetAllAsync(), "Id", "Type", contactperson.ContactTypeId);
            return View(contactperson);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactPerson contactperson = await unitOfWork.ContactPersonRepository.FindAsync(p => p.Id == id);
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
            ContactPerson contactperson = await unitOfWork.ContactPersonRepository.FindAsync(p => p.Id == id);
            unitOfWork.ContactPersonRepository.RemoveAsync(contactperson);
            await unitOfWork.SaveAsync();
            return RedirectToAction("Index", new { Id = Session["DrivingSchoolId"] });
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