using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model;
using Saturn.Model.ViewModels;
using Saturn.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class CandidatesController : Controller
    {
        private readonly ICandidateRepository repository;
        private readonly ICityRepository cityRepository;
        private readonly IDrivingCategoryRepository drivingCategoryRepository;
        private readonly SaturnDbContext db = new SaturnDbContext();
        private readonly SaturnDbViewContext dbView = new SaturnDbViewContext();
        
        public CandidatesController()
        {
            this.repository = new CandidateRepository(new SaturnDbContext());
            this.cityRepository = new CityRepository(new SaturnDbContext());
            this.drivingCategoryRepository = new DrivingCategoryRepository(new SaturnDbContext());

        }
        public CandidatesController(ICandidateRepository repository, ICityRepository cityRepository, IDrivingCategoryRepository drivingCategoryRepository)
        {
            this.repository = repository;
            this.cityRepository = cityRepository;
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
            Candidate candidate = await repository.FindAsync(f => f.Id == id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            candidate.Address = string.IsNullOrEmpty(candidate.Address) ? "/" : candidate.Address;
            candidate.PersonalCardNumber = string.IsNullOrEmpty(candidate.PersonalCardNumber) ? "/" : candidate.PersonalCardNumber;
            candidate.IssuedBy = string.IsNullOrEmpty(candidate.IssuedBy) ? "/" : candidate.IssuedBy;
            candidate.Profession = string.IsNullOrEmpty(candidate.Profession) ? "/" : candidate.Profession;
            candidate.ExistingDrivingCategory = string.IsNullOrEmpty(candidate.ExistingDrivingCategory) ? "/" : candidate.ExistingDrivingCategory;
            candidate.Note = string.IsNullOrEmpty(candidate.Note) ? "/" : candidate.Note;

            Session["CandidateId"] = id;

            return View(candidate);
        }

        public ActionResult Registration_Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var id = int.Parse(Session["CandidateId"].ToString());
            var data = dbView.ViewRegistrations.Where(w => w.CandidateId == id).OrderByDescending(o => o.RegistrationDate).ToList();
            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ExamRegistrations_Read(int registrationId, [DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var id = int.Parse(Session["CandidateId"].ToString());

            var data = dbView.ViewExamRegistration
                .Where(w => w.CandidateId == id && w.RegistrationId == registrationId)
                .OrderBy(o => o.ExamDate).ThenBy(o => o.ExamTime).ToList();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ExamRegistrationError_Read(int examRegistrationId, [DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = dbView.ViewExamRegistrationError.Where(w => w.ExamRegistrationId == examRegistrationId).ToList();

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ReqDod_Read([DataSourceRequest] DataSourceRequest request)
        {
            db.Configuration.ProxyCreationEnabled = false;

            int candidateId = int.Parse(Session["CandidateId"].ToString());
            //var data = db.ReqDocCandidate.Where(w => w.CandidateId == candidateId).Select(ReqDocCandidateViewModel.FromReqDocCandidate).ToList();
            var pom = dbView.ViewReqDocCandidates.Where(w => w.CandidateId == candidateId).ToList();

            var data = pom.Select(c => new ReqDocCandidateViewModel
            {
                Id = c.ReqDocCandidateId,
                CandidateId = c.CandidateId,
                ReqDocumentId = c.ReqDocumentId,
                ReqDocument = c.ReqDocument,
                DocumentNumber = c.DocumentNumber,
                IssueDate = c.IssueDate,
                ValidTo = c.ValidTo,
            });

            return Json(data.OrderBy(o => o.ReqDocument).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ReqDoc_Update([DataSourceRequest]DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ReqDocCandidateViewModel> reqDocCandidate)
        {
            var entities = new List<ReqDocCandidate>();
            if (ModelState.IsValid)
            {
                foreach (var d in reqDocCandidate)
                {
                    var entity = new ReqDocCandidate
                    {
                        Id = d.Id,
                        CandidateId = d.CandidateId,
                        ReqDocumentId = d.ReqDocumentId,
                        DocumentNumber = d.DocumentNumber,
                        IssueDate = d.IssueDate,
                        ValidTo = d.ValidTo,
                        Note = d.Note
                    };
                    entities.Add(entity);
                    db.ReqDocCandidate.Attach(entity);
                    db.Entry(entity).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            return Json(reqDocCandidate.ToDataSourceResult(request, ModelState));
        }





        public async Task<ActionResult> Create()
        {
            ViewBag.CityId = new SelectList(await cityRepository.GetAllAsync(), "Id", "Name");
            ViewBag.DrivingCategoryId = new SelectList(await drivingCategoryRepository.GetAllAsync(), "Id", "Category");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,FatherName,PersonalCardNumber,IssuedBy,UniqueNumber,Address,CityId,BirthDate,BirthPlace,Profession,Note,DrivingCategoryId,ExistingDrivingCategory,DossierNumber,DossierDate")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                repository.InsertAsync(candidate);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(await cityRepository.GetAllAsync(), "Id", "Name", candidate.CityId);
            ViewBag.DrivingCategoryId = new SelectList(await drivingCategoryRepository.GetAllAsync(), "Id", "Category", candidate.DrivingCategoryId);
            return View(candidate);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = await repository.FindAsync(p => p.Id == id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(await cityRepository.GetAllAsync(), "Id", "Name", candidate.CityId);
            ViewBag.DrivingCategoryId = new SelectList(await drivingCategoryRepository.GetAllAsync(), "Id", "Category", candidate.DrivingCategoryId);
            return View(candidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,FatherName,PersonalCardNumber,IssuedBy,UniqueNumber,Address,CityId,BirthDate,BirthPlace,Profession,Note,DrivingCategoryId,ExistingDrivingCategory,DossierNumber,DossierDate")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateAsync(candidate);
                await repository.SaveAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(await cityRepository.GetAllAsync(), "Id", "Name", candidate.CityId);
            ViewBag.DrivingCategoryId = new SelectList(await drivingCategoryRepository.GetAllAsync(), "Id", "Category", candidate.DrivingCategoryId);
            return View(candidate);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = await repository.FindAsync(p => p.Id == id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Candidate candidate = await repository.FindAsync(p => p.Id == id);
            repository.RemoveAsync(candidate);
            await repository.SaveAsync();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
                cityRepository.Dispose();
                drivingCategoryRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}