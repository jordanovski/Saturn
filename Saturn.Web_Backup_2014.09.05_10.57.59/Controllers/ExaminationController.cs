using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model;
using Saturn.Repository;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class ExaminationController : Controller
    {
        private readonly IExaminationRepository repository;
        private readonly IExamTypeRepository examTypeRepository;
        private readonly IExaminerRepository examinerRepository;
        private readonly IExamCentersRepository examCentersRepository;

        public ExaminationController()
        {
            this.repository = new ExaminationRepository(new SaturnDbContext(), new SaturnDbViewContext());
            this.examTypeRepository = new ExamTypeRepository(new SaturnDbContext());
            this.examinerRepository = new ExaminerRepository(new SaturnDbContext());
            this.examCentersRepository = new ExamCentersRepository(new SaturnDbContext());

        }
        public ExaminationController(IExaminationRepository repository, IExamTypeRepository examTypeRepository, IExaminerRepository examinerRepository, IExamCentersRepository examCentersRepository)
        {
            this.repository = repository;
            this.examTypeRepository = examTypeRepository;
            this.examinerRepository = examinerRepository;
            this.examCentersRepository = examCentersRepository;
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

        public ActionResult PassedExaminations()
        {
            return View();
        }
        public async Task<ActionResult> PassedExaminations_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = await repository.GetAllPassedAsync();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> CandidatesList(int id)
        {
            var exam = await repository.FindAsync(p => p.Id == id);
            var examCenters = await examCentersRepository.GetAllAsync();
            var president = await examinerRepository.FindAsync(f => f.Id == exam.PresidentId);
            var examiner = await examinerRepository.FindAsync(f => f.Id == exam.ExaminerId);
            var member = await examinerRepository.FindAsync(f => f.Id == exam.MemberId);


            ViewBag.ExamId = id;
            ViewBag.ExamLocation = examCenters.First(w => w.Id == exam.ExamCenterId).Name;
            ViewBag.ExamDate = exam.ExamDate.ToShortDateString();
            ViewBag.ExamTime = exam.ExamTime;
            ViewBag.President = exam.PresidentId == null ? "" : president.FullName;
            ViewBag.Examiner = exam.ExaminerId == null ? "" : examiner.FullName;
            ViewBag.Member = exam.MemberId == null ? "" : member.FullName;


            var data = await repository.GetAllExamCandidatesAsync(w => w.ExamId == id);// dbView.ViewExamCandidates.Where(w => w.ExamId == id).ToList();
            return View(data);
        }


        public async Task<ActionResult> ExaminationResult(int id)
        {
            var exam = await repository.FindAsync(p => p.Id == id);
            var examCenters = await examCentersRepository.GetAllAsync();
            var president = await examinerRepository.FindAsync(f => f.Id == exam.PresidentId);
            var examiner = await examinerRepository.FindAsync(f => f.Id == exam.ExaminerId);
            var member = await examinerRepository.FindAsync(f => f.Id == exam.MemberId);

            ViewBag.ExamLocation = examCenters.First(w => w.Id == exam.ExamCenterId).Name;
            ViewBag.ExamDate = exam.ExamDate.ToShortDateString();
            ViewBag.ExamTime = exam.ExamTime;
            ViewBag.President = exam.PresidentId == null ? "" : president.FullName;
            ViewBag.Examiner = exam.ExaminerId == null ? "" : examiner.FullName;
            ViewBag.Member = exam.MemberId == null ? "" : member.FullName;

            var data = await repository.GetAllExamCandidatesAsync(w => w.ExamId == id);// dbView.ViewExamCandidates.Where(w => w.ExamId == id).ToList();
            return View(data);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = await repository.FindAsync(p => p.Id == id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type");
            ViewBag.MemberId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName");
            ViewBag.ExaminerId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName");
            ViewBag.PresidentId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName");
            ViewBag.ExamCenterId = new SelectList(await examCentersRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ExamCenterId,ExamDate,ExamTime,ExamTypeId,PresidentId,ExaminerId,MemberId")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAsync(examination);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type", examination.ExamTypeId);
            ViewBag.MemberId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName", examination.MemberId);
            ViewBag.ExaminerId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName", examination.ExaminerId);
            ViewBag.PresidentId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName", examination.PresidentId);
            ViewBag.ExamCenterId = new SelectList(await examCentersRepository.GetAllAsync(), "Id", "Name", examination.ExamCenterId);

            return View(examination);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = await repository.FindAsync(p => p.Id == id);
            if (examination == null)
            {
                return HttpNotFound();
            }

            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type", examination.ExamTypeId);
            ViewBag.MemberId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName", examination.MemberId);
            ViewBag.ExaminerId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName", examination.ExaminerId);
            ViewBag.PresidentId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName", examination.PresidentId);
            ViewBag.ExamCenterId = new SelectList(await examCentersRepository.GetAllAsync(), "Id", "Name", examination.ExamCenterId);

            return View(examination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ExamCenterId,ExamDate,ExamTime,ExamTypeId,PresidentId,ExaminerId,MemberId")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(examination);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExamTypeId = new SelectList(await examTypeRepository.GetAllAsync(), "Id", "Type", examination.ExamTypeId);
            ViewBag.MemberId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName", examination.MemberId);
            ViewBag.ExaminerId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName", examination.ExaminerId);
            ViewBag.PresidentId = new SelectList(await examinerRepository.GetAllAsync(), "Id", "FullName", examination.PresidentId);
            ViewBag.ExamCenterId = new SelectList(await examCentersRepository.GetAllAsync(), "Id", "Name", examination.ExamCenterId);
            return View(examination);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = await repository.FindAsync(p => p.Id == id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Examination examination = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(examination);
            await repository.SaveAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
                examTypeRepository.Dispose();
                examinerRepository.Dispose();
                examCentersRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}