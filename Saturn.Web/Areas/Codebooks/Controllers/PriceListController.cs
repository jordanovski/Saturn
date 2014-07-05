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
    public class PriceListController : Controller
    {
        private readonly IPriceListRepository repository;
        private readonly IExamTypeRepository examTypeRepository;
        private readonly IDrivingCategoryRepository drivingCategoryRepository;
        
        public PriceListController()
        {
            this.repository = new PriceListRepository(new SaturnDbContext());
            this.examTypeRepository = new ExamTypeRepository(new SaturnDbContext());
            this.drivingCategoryRepository = new DrivingCategoryRepository(new SaturnDbContext());

        }
        public PriceListController(IPriceListRepository repository, IExamTypeRepository examTypeRepository, IDrivingCategoryRepository drivingCategoryRepository)
        {
            this.repository = repository;
            this.examTypeRepository = examTypeRepository;
            this.drivingCategoryRepository = drivingCategoryRepository;
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
            PriceList pricelist = await repository.FindAsync(p => p.Id == id);
            if (pricelist == null)
            {
                return HttpNotFound();
            }
            return View(pricelist);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.DrivingCategoryId = new SelectList(await drivingCategoryRepository.GetAllAsync(), "Id", "Category");
            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DrivingCategoryId,ExamTypeId,PriceFirst,TaxFirst,PriceRepeated,TaxRepeated,MaterialCosts,VAT,Note")] PriceList pricelist)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAsync(pricelist);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DrivingCategoryId = new SelectList(await drivingCategoryRepository.GetAllAsync(), "Id", "Category", pricelist.DrivingCategoryId);
            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type", pricelist.ExamTypeId);
            return View(pricelist);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceList pricelist = await repository.FindAsync(p => p.Id == id);
            if (pricelist == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrivingCategoryId = new SelectList(await drivingCategoryRepository.GetAllAsync(), "Id", "Category", pricelist.DrivingCategoryId);
            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type", pricelist.ExamTypeId);
            return View(pricelist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DrivingCategoryId,ExamTypeId,PriceFirst,TaxFirst,PriceRepeated,TaxRepeated,MaterialCosts,VAT,Note")] PriceList pricelist)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(pricelist);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DrivingCategoryId = new SelectList(await drivingCategoryRepository.GetAllAsync(), "Id", "Category", pricelist.DrivingCategoryId);
            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type", pricelist.ExamTypeId);
            return View(pricelist);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceList pricelist = await repository.FindAsync(p => p.Id == id);
            if (pricelist == null)
            {
                return HttpNotFound();
            }
            return View(pricelist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PriceList pricelist = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(pricelist);
            await repository.SaveAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
                examTypeRepository.Dispose();
                drivingCategoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}