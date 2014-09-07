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
    public class ErrorTypeController : Controller
    {
        private readonly IErrorTypeRepository repository;
        private readonly IExamTypeRepository examTypeRepository;

        public ErrorTypeController()
        {
            this.repository = new ErrorTypeRepository(new SaturnDbContext());
            this.examTypeRepository = new ExamTypeRepository(new SaturnDbContext());

        }
        public ErrorTypeController(IErrorTypeRepository repository, IExamTypeRepository examTypeRepository)
        {
            this.repository = repository;
            this.examTypeRepository = examTypeRepository;
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
            ErrorType errortype = await repository.FindAsync(p => p.Id == id);
            if (errortype == null)
            {
                return HttpNotFound();
            }
            return View(errortype);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Form,Question,Description,PenaltyPoints,DrivingCategory,ExamTypeId")] ErrorType errortype)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAsync(errortype);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type", errortype.ExamTypeId);
            return View(errortype);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorType errortype = await repository.FindAsync(p => p.Id == id);
            if (errortype == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type", errortype.ExamTypeId);
            return View(errortype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Form,Question,Description,PenaltyPoints,DrivingCategory,ExamTypeId")] ErrorType errortype)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(errortype);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type", errortype.ExamTypeId);
            return View(errortype);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ErrorType errortype = await repository.FindAsync(p => p.Id == id);
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
            ErrorType errortype = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(errortype);
            await repository.SaveAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}