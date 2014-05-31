using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class ExaminationController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();
        private readonly SaturnDbViewContext dbView = new SaturnDbViewContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            dbView.Configuration.ProxyCreationEnabled = false;
            var data = dbView.ViewExaminations.Where(w => w.ExamDate >= DateTime.Now).OrderBy(o => o.ExamDate).ThenBy(o => o.ExamTime).ToList();
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PassedExaminations()
        {
            return View();
        }
        public ActionResult PassedExaminations_Read([DataSourceRequest] DataSourceRequest request)
        {
            dbView.Configuration.ProxyCreationEnabled = false;
            var data = dbView.ViewExaminations.Where(w => w.ExamDate < DateTime.Now).OrderByDescending(o => o.ExamDate).ThenByDescending(o => o.ExamTime).ToList();
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CandidatesList(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            dbView.Configuration.ProxyCreationEnabled = false;

            var exam = db.Examination.Find(id);

            ViewBag.ExamId = id;
            ViewBag.ExamLocation = db.ExamCenters.First(w => w.Id == exam.ExamCenterId).Name;
            ViewBag.ExamDate = exam.ExamDate.ToShortDateString();
            ViewBag.ExamTime = exam.ExamTime;
            ViewBag.President = exam.PresidentId == null ? "" : db.Examiner.Find(exam.PresidentId).FullName;
            ViewBag.Examiner = exam.ExaminerId == null ? "" : db.Examiner.Find(exam.ExaminerId).FullName;
            ViewBag.Member = exam.MemberId == null ? "" : db.Examiner.Find(exam.MemberId).FullName;


            var data = dbView.ViewExamCandidates.Where(w => w.ExamId == id).ToList();
            return View(data);
        }


        public ActionResult ExaminationResult(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            dbView.Configuration.ProxyCreationEnabled = false;

            var exam = db.Examination.Find(id);

            ViewBag.ExamId = id;
            ViewBag.ExamLocation = db.ExamCenters.First(w => w.Id == exam.ExamCenterId).Name;
            ViewBag.ExamDate = exam.ExamDate.ToShortDateString();
            ViewBag.ExamTime = exam.ExamTime;
            ViewBag.President = exam.PresidentId == null ? "" : db.Examiner.Find(exam.PresidentId).FullName;
            ViewBag.Examiner = exam.ExaminerId == null ? "" : db.Examiner.Find(exam.ExaminerId).FullName;
            ViewBag.Member = exam.MemberId == null ? "" : db.Examiner.Find(exam.MemberId).FullName;

            var data = dbView.ViewExamCandidates.Where(w => w.ExamId == id).ToList();
            return View(data);
        }


        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = await db.Examination.FindAsync(id);
            if (examination == null)
            {
                return HttpNotFound();
            }
            return View(examination);
        }


        public ActionResult Create()
        {
            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type");
            ViewBag.MemberId = new SelectList(db.Examiner, "Id", "FullName");
            ViewBag.ExaminerId = new SelectList(db.Examiner, "Id", "FullName");
            ViewBag.PresidentId = new SelectList(db.Examiner, "Id", "FullName");
            ViewBag.ExamCenterId = new SelectList(db.ExamCenters, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ExamCenterId,ExamDate,ExamTime,ExamTypeId,PresidentId,ExaminerId,MemberId")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                db.Examination.Add(examination);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type", examination.ExamTypeId);
            ViewBag.MemberId = new SelectList(db.Examiner, "Id", "FullName", examination.MemberId);
            ViewBag.ExaminerId = new SelectList(db.Examiner, "Id", "FullName", examination.ExaminerId);
            ViewBag.PresidentId = new SelectList(db.Examiner, "Id", "FullName", examination.PresidentId);
            ViewBag.ExamCenterId = new SelectList(db.ExamCenters, "Id", "Name", examination.ExamCenterId);

            return View(examination);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = await db.Examination.FindAsync(id);
            if (examination == null)
            {
                return HttpNotFound();
            }

            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type", examination.ExamTypeId);
            ViewBag.MemberId = new SelectList(db.Examiner, "Id", "FullName", examination.MemberId);
            ViewBag.ExaminerId = new SelectList(db.Examiner, "Id", "FullName", examination.ExaminerId);
            ViewBag.PresidentId = new SelectList(db.Examiner, "Id", "FullName", examination.PresidentId);
            ViewBag.ExamCenterId = new SelectList(db.ExamCenters, "Id", "Name", examination.ExamCenterId);

            return View(examination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ExamCenterId,ExamDate,ExamTime,ExamTypeId,PresidentId,ExaminerId,MemberId")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examination).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExamTypeId = new SelectList(db.ExamType, "Id", "Type", examination.ExamTypeId);
            ViewBag.MemberId = new SelectList(db.Examiner, "Id", "FullName", examination.MemberId);
            ViewBag.ExaminerId = new SelectList(db.Examiner, "Id", "FullName", examination.ExaminerId);
            ViewBag.PresidentId = new SelectList(db.Examiner, "Id", "FullName", examination.PresidentId);
            ViewBag.ExamCenterId = new SelectList(db.ExamCenters, "Id", "Name", examination.ExamCenterId);
            return View(examination);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examination examination = await db.Examination.FindAsync(id);
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
            Examination examination = await db.Examination.FindAsync(id);
            db.Examination.Remove(examination);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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