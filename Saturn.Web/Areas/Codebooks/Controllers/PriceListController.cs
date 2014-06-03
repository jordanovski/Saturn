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
    public class PriceListController : Controller
    {
        private readonly PriceListUnitOfWork unitOfWork = new PriceListUnitOfWork(new SaturnDbContext());

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await unitOfWork.PriceListRepository.GetAllAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceList pricelist = await unitOfWork.PriceListRepository.FindAsync(p => p.Id == id);
            if (pricelist == null)
            {
                return HttpNotFound();
            }
            return View(pricelist);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.DrivingCategoryId = new SelectList(await unitOfWork.DrivingCategoryRepository.GetAllAsync(), "Id", "Category");
            ViewBag.ExamTypeId = new SelectList(await unitOfWork.ExamTypeRepository.GetAllAsync(), "Id", "Type");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,DrivingCategoryId,ExamTypeId,PriceFirst,TaxFirst,PriceRepeated,TaxRepeated,MaterialCosts,VAT,Note")] PriceList pricelist)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PriceListRepository.InsertAsync(pricelist);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DrivingCategoryId = new SelectList(await unitOfWork.DrivingCategoryRepository.GetAllAsync(), "Id", "Category", pricelist.DrivingCategoryId);
            ViewBag.ExamTypeId = new SelectList(await unitOfWork.ExamTypeRepository.GetAllAsync(), "Id", "Type", pricelist.ExamTypeId);
            return View(pricelist);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceList pricelist = await unitOfWork.PriceListRepository.FindAsync(p => p.Id == id);
            if (pricelist == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrivingCategoryId = new SelectList(await unitOfWork.DrivingCategoryRepository.GetAllAsync(), "Id", "Category", pricelist.DrivingCategoryId);
            ViewBag.ExamTypeId = new SelectList(await unitOfWork.ExamTypeRepository.GetAllAsync(), "Id", "Type", pricelist.ExamTypeId);
            return View(pricelist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DrivingCategoryId,ExamTypeId,PriceFirst,TaxFirst,PriceRepeated,TaxRepeated,MaterialCosts,VAT,Note")] PriceList pricelist)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PriceListRepository.UpdateAsync(pricelist);
                await unitOfWork.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DrivingCategoryId = new SelectList(await unitOfWork.DrivingCategoryRepository.GetAllAsync(), "Id", "Category", pricelist.DrivingCategoryId);
            ViewBag.ExamTypeId = new SelectList(await unitOfWork.ExamTypeRepository.GetAllAsync(), "Id", "Type", pricelist.ExamTypeId);
            return View(pricelist);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceList pricelist = await unitOfWork.PriceListRepository.FindAsync(p => p.Id == id);
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
            PriceList pricelist = await unitOfWork.PriceListRepository.FindAsync(p => p.Id == id);
            unitOfWork.PriceListRepository.RemoveAsync(pricelist);
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