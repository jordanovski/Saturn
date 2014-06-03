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
    public class ErrorTypeController : Controller
    {
        private readonly ErrorTypeUnitOfWork unitOfWork = new ErrorTypeUnitOfWork(new SaturnDbContext());

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await unitOfWork.ErrorTypeRepository.GetAllAsync();
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorType errortype = await unitOfWork.ErrorTypeRepository.FindAsync(p => p.Id == id);
            if (errortype == null)
            {
                return HttpNotFound();
            }
            return View(errortype);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.ExamTypeId = new SelectList(await unitOfWork.ExamTypeRepository.GetAllAsync(), "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Form,Question,Description,PenaltyPoints,DrivingCategory,ExamTypeId")] ErrorType errortype)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ErrorTypeRepository.InsertAsync(errortype);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExamTypeId = new SelectList(await unitOfWork.ExamTypeRepository.GetAllAsync(), "Id", "Type", errortype.ExamTypeId);
            return View(errortype);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorType errortype = await unitOfWork.ErrorTypeRepository.FindAsync(p => p.Id == id);
            if (errortype == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamTypeId = new SelectList(await unitOfWork.ExamTypeRepository.GetAllAsync(), "Id", "Type", errortype.ExamTypeId);
            return View(errortype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Form,Question,Description,PenaltyPoints,DrivingCategory,ExamTypeId")] ErrorType errortype)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ErrorTypeRepository.UpdateAsync(errortype);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExamTypeId = new SelectList(await unitOfWork.ExamTypeRepository.GetAllAsync(), "Id", "Type", errortype.ExamTypeId);
            return View(errortype);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorType errortype = await unitOfWork.ErrorTypeRepository.FindAsync(p => p.Id == id);
            if (errortype == null)
            {
                return HttpNotFound();
            }
            return View(errortype);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ErrorType errortype = await unitOfWork.ErrorTypeRepository.FindAsync(p => p.Id == id);
            unitOfWork.ErrorTypeRepository.RemoveAsync(errortype);
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