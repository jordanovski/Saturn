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
    public class ReqDocDrivingCategoryController : Controller
    {
        private readonly IReqDocDrivingCategoryRepository repository;
        private readonly IDrivingCategoryRepository drivingCategoryRepository;
        private readonly IRequiredDocumentRepository requiredDocumentRepository;

        public ReqDocDrivingCategoryController()
        {
            this.repository = new ReqDocDrivingCategoryRepository(new SaturnDbContext());
            this.drivingCategoryRepository = new DrivingCategoryRepository(new SaturnDbContext());
            this.requiredDocumentRepository = new RequiredDocumentRepository(new SaturnDbContext());

        }
        public ReqDocDrivingCategoryController(IReqDocDrivingCategoryRepository repository, IDrivingCategoryRepository drivingCategoryRepository, IRequiredDocumentRepository requiredDocumentRepository)
        {
            this.repository = repository;
            this.drivingCategoryRepository = drivingCategoryRepository;
            this.requiredDocumentRepository = requiredDocumentRepository;

        }

        public async Task<ActionResult> Index(int id = 0)
        {
            Session["DrivingCategoryId"] = id;
            var category = await drivingCategoryRepository.FindAsync(p => p.Id == id);
            Session["Category"] = category.Category;
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            int drivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());
            var data = await repository.FindAllAsync(f => f.DrivingCategoryId == drivingCategoryId);

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocDrivingCategory reqdocdrivingcategory = await repository.FindAsync(p => p.Id == id);
            if (reqdocdrivingcategory == null)
            {
                return HttpNotFound();
            }
            return View(reqdocdrivingcategory);
        }


        public async Task<ActionResult> Create()
        {
            var drivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());
            var category = await drivingCategoryRepository.FindAsync(p => p.Id == drivingCategoryId);
            Session["Category"] = category.Category;
            ViewBag.ReqDocumentId = new SelectList(await requiredDocumentRepository.GetAllAsync(), "Id", "ReqDocument");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ReqDocumentId,DrivingCategoryId")] ReqDocDrivingCategory reqdocdrivingcategory)
        {
            var drivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());
            reqdocdrivingcategory.DrivingCategoryId = drivingCategoryId;
            if (ModelState.IsValid)
            {
                repository.InsertAsync(reqdocdrivingcategory);
                await repository.SaveAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingCategoryId"] });
            }
            var category = await drivingCategoryRepository.FindAsync(p => p.Id == drivingCategoryId);
            Session["Category"] = category.Category;
            ViewBag.ReqDocumentId = new SelectList(await requiredDocumentRepository.GetAllAsync(), "Id", "ReqDocument", reqdocdrivingcategory.ReqDocumentId);
            return View(reqdocdrivingcategory);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocDrivingCategory reqdocdrivingcategory = await repository.FindAsync(p => p.Id == id);
            if (reqdocdrivingcategory == null)
            {
                return HttpNotFound();
            }
            var drivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());
            var category = await drivingCategoryRepository.FindAsync(p => p.Id == drivingCategoryId);
            Session["Category"] = category.Category;
            ViewBag.ReqDocumentId = new SelectList(await requiredDocumentRepository.GetAllAsync(), "Id", "ReqDocument", reqdocdrivingcategory.ReqDocumentId);
            return View(reqdocdrivingcategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ReqDocumentId,DrivingCategoryId")] ReqDocDrivingCategory reqdocdrivingcategory)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(reqdocdrivingcategory);
                await repository.SaveAsync();
                return RedirectToAction("Index", new { Id = Session["DrivingCategoryId"] });
            }
            var drivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());
            var category = await drivingCategoryRepository.FindAsync(p => p.Id == drivingCategoryId);
            Session["Category"] = category.Category;
            ViewBag.ReqDocumentId = new SelectList(await requiredDocumentRepository.GetAllAsync(), "Id", "ReqDocument", reqdocdrivingcategory.ReqDocumentId);
            return View(reqdocdrivingcategory);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqDocDrivingCategory reqdocdrivingcategory = await repository.FindAsync(p => p.Id == id);
            if (reqdocdrivingcategory == null)
            {
                return HttpNotFound();
            }
            var drivingCategoryId = int.Parse(Session["DrivingCategoryId"].ToString());
            var category = await drivingCategoryRepository.FindAsync(p => p.Id == drivingCategoryId);
            Session["Category"] = category.Category;
            return View(reqdocdrivingcategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReqDocDrivingCategory reqdocdrivingcategory = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(reqdocdrivingcategory);
            await repository.SaveAsync();
            return RedirectToAction("Index", new { Id = Session["DrivingCategoryId"] });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
                requiredDocumentRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}