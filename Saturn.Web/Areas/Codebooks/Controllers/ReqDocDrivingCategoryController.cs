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
    public class ReqDocDrivingCategoryController : Controller
    {
        private readonly ReqDocDrivingCategoryUnitOfWork unitOfWork = new ReqDocDrivingCategoryUnitOfWork(new SaturnDbContext());

        public ActionResult Index(int id = 0)
        {
            Session["DrivingCategoryId"] = id;
            Session["Category"] = unitOfWork.DrivingCategoryRepository.FindAllAsync(p => p.Id == id);
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            int drivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());
            var data = await unitOfWork.ReqDocDrivingCategoryRepository.FindAllAsync(f => f.DrivingCategoryId == drivingCategoryId);
                       
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocDrivingCategory reqdocdrivingcategory = await unitOfWork.ReqDocDrivingCategoryRepository.FindAsync(p => p.Id == id);
            if (reqdocdrivingcategory == null)
            {
                return HttpNotFound();
            }
            return View(reqdocdrivingcategory);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.ReqDocumentId = new SelectList(await unitOfWork.RequiredDocumentRepository.GetAllAsync(), "Id", "ReqDocument");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ReqDocumentId,DrivingCategoryId")] ReqDocDrivingCategory reqdocdrivingcategory)
        {
            reqdocdrivingcategory.DrivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());
            if (ModelState.IsValid)
            {
                unitOfWork.ReqDocDrivingCategoryRepository.InsertAsync(reqdocdrivingcategory);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingCategoryId"] });
            }

            ViewBag.ReqDocumentId = new SelectList(await unitOfWork.RequiredDocumentRepository.GetAllAsync(), "Id", "ReqDocument", reqdocdrivingcategory.ReqDocumentId);
            return View(reqdocdrivingcategory);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocDrivingCategory reqdocdrivingcategory = await unitOfWork.ReqDocDrivingCategoryRepository.FindAsync(p => p.Id == id);
            if (reqdocdrivingcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReqDocumentId = new SelectList(await unitOfWork.RequiredDocumentRepository.GetAllAsync(), "Id", "ReqDocument", reqdocdrivingcategory.ReqDocumentId);
            return View(reqdocdrivingcategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ReqDocumentId,DrivingCategoryId")] ReqDocDrivingCategory reqdocdrivingcategory)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ReqDocDrivingCategoryRepository.UpdateAsync(reqdocdrivingcategory);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingCategoryId"] });
            }
            ViewBag.ReqDocumentId = new SelectList(await unitOfWork.RequiredDocumentRepository.GetAllAsync(), "Id", "ReqDocument", reqdocdrivingcategory.ReqDocumentId);
            return View(reqdocdrivingcategory);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocDrivingCategory reqdocdrivingcategory = await unitOfWork.ReqDocDrivingCategoryRepository.FindAsync(p => p.Id == id);
            if (reqdocdrivingcategory == null)
            {
                return HttpNotFound();
            }
            return View(reqdocdrivingcategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReqDocDrivingCategory reqdocdrivingcategory = await unitOfWork.ReqDocDrivingCategoryRepository.FindAsync(p => p.Id == id);
            unitOfWork.ReqDocDrivingCategoryRepository.RemoveAsync(reqdocdrivingcategory);
            await unitOfWork.SaveAsync();
            return RedirectToAction("Index", new { Id = Session["DrivingCategoryId"] });
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