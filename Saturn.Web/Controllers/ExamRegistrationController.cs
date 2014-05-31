using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Saturn.Data;
using Saturn.Model;
using Saturn.Model.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class ExamRegistrationController : Controller
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
            var data = dbView.ViewExamRegistration.OrderBy(o => o.ExamRegistrationId);

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamRegistration examregistration = await db.ExamRegistration.FindAsync(id);
            if (examregistration == null)
            {
                return HttpNotFound();
            }
            return View(examregistration);
        }


        public ActionResult Create(int id = 0)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var registration = dbView.ViewRegistrations.First(f => f.RegistrationId == id);
            var candidate = dbView.ViewCandidates.First(f => f.CandidateId == registration.CandidateId);

            var data = new ExamRegistration();
            data.StatusId = 2;
            data.RegistrationId = registration.RegistrationId;
            data.Place = registration.Place;

            ViewBag.Candidate = candidate;
            ViewBag.Registration = registration;

            ViewBag.LanguageId = new SelectList(db.ExamLanguage, "Id", "Language");
            ViewBag.ExamWayOfTakingId = new SelectList(db.ExamWayOfTaking, "Id", "WayOfTaking");

            ViewBag.PriceList = db.PriceList.Where(w => w.DrivingCategoryId == registration.DrivingCategoryId);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RegistrationId,ExamId,ExamTypeId,ExamRegistrationDate,ExamCenterId,ExamWayOfTakingId,LanguageId,Place,Price,Tax,UseVehicle,MaterialCosts,PDVAmount,PDVVehicle,PDVTest,Result,StatusId")] ExamRegistration examregistration)
        {
            examregistration.ExamRegistrationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.ExamRegistration.Add(examregistration);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var registration = dbView.ViewRegistrations.First(f => f.RegistrationId == examregistration.RegistrationId);
            var candidate = dbView.ViewCandidates.First(f => f.CandidateId == registration.CandidateId);

            examregistration.ExamRegistrationDate = DateTime.Now;

            ViewBag.Candidate = candidate;
            ViewBag.Registration = registration;

            ViewBag.LanguageId = new SelectList(db.ExamLanguage, "Id", "Language");
            ViewBag.ExamWayOfTakingId = new SelectList(db.ExamWayOfTaking, "Id", "WayOfTaking");
            return View(examregistration);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamRegistration examregistration = await db.ExamRegistration.FindAsync(id);
            if (examregistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamTypeId = new SelectList(db.Examination, "Id", "Id", examregistration.ExamTypeId);
            ViewBag.LanguageId = new SelectList(db.ExamLanguage, "Id", "Language", examregistration.LanguageId);
            ViewBag.StatusId = new SelectList(db.ExamRegistrationStatus, "Id", "Status", examregistration.StatusId);
            ViewBag.ExamWayOfTakingId = new SelectList(db.ExamWayOfTaking, "Id", "WayOfTaking", examregistration.ExamWayOfTakingId);
            ViewBag.RegistrationId = new SelectList(db.Registration, "Id", "Place", examregistration.RegistrationId);
            ViewBag.Id = new SelectList(db.Report, "Id", "UserNameCreated", examregistration.Id);
            return View(examregistration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RegistrationId,ExamId,ExamTypeId,ExamRegistrationDate,ExamCenterId,ExamWayOfTakingId,LanguageId,Place,Price,Tax,UseVehicle,MaterialCosts,PDVAmount,PDVVehicle,PDVTest,Result,StatusId")] ExamRegistration examregistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examregistration).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExamTypeId = new SelectList(db.Examination, "Id", "Id", examregistration.ExamTypeId);
            ViewBag.LanguageId = new SelectList(db.ExamLanguage, "Id", "Language", examregistration.LanguageId);
            ViewBag.StatusId = new SelectList(db.ExamRegistrationStatus, "Id", "Status", examregistration.StatusId);
            ViewBag.ExamWayOfTakingId = new SelectList(db.ExamWayOfTaking, "Id", "WayOfTaking", examregistration.ExamWayOfTakingId);
            ViewBag.RegistrationId = new SelectList(db.Registration, "Id", "Place", examregistration.RegistrationId);
            ViewBag.Id = new SelectList(db.Report, "Id", "UserNameCreated", examregistration.Id);
            return View(examregistration);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamRegistration examregistration = await db.ExamRegistration.FindAsync(id);
            if (examregistration == null)
            {
                return HttpNotFound();
            }
            return View(examregistration);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ExamRegistration examregistration = await db.ExamRegistration.FindAsync(id);
            db.ExamRegistration.Remove(examregistration);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }





        public ActionResult Toolbar_Status()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.ExamRegistrationStatus.Select(StatusViewModel.FromExamRegistrationStatus);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetExamTypes()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.ExamType.Select(c => new { Id = c.Id, Type = c.Type }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetExamCenters(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var data = db.ExamCenters.OrderBy(o => o.Name).ToList();
            return Json(data.Select(p => new { Id = p.Id, Name = p.Name, ExamTypeId = id }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetExams(int? idCenter, int? idType)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var data = dbView.ViewExaminations.Where(w => w.ExamDate >= DateTime.Now && w.ExamTypeId == idType && w.ExamCenterId == idCenter).OrderBy(o => o.ExamDate).ThenBy(o => o.ExamTime).ToList();

            return Json(data.Select(o => new { Id = o.ExaminationId, Date = o.ExamDateTime.ToString("dd.MM.yyyy HH:mm") }), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Registration Id</param>
        /// <param name="typeId">If value is 2 the exam type is theory, value is 3 th exam is polygon and if the value is 4 the exam is city.</param>
        /// <returns></returns>
        public JsonResult GetPrice(int id, int typeId)
        {
            var registration = dbView.ViewRegistrations.First(f => f.RegistrationId == id);
            var drivingCategory = db.DrivingCategory.Find(registration.DrivingCategoryId);

            if (typeId == 3 || typeId == 4)
            {
                if (drivingCategory.Category.Equals("А1") || drivingCategory.Category.Equals("А"))
                {
                    if (string.IsNullOrEmpty(registration.ExistingDrivingCategory))
                    {
                        var price = db.PriceList.First(f => f.ExamTypeId == typeId && f.DrivingCategoryId == drivingCategory.Id && f.Note == "Без возачка од повисока кат.");
                        var data = new { Price = price.PriceFirst, Tax = price.TaxFirst, MaterialCosts = price.MaterialCosts };

                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var price = db.PriceList.First(f => f.ExamTypeId == typeId && f.DrivingCategoryId == drivingCategory.Id && f.Note == "Со возачка од повисока кат.");
                        var data = new { Price = price.PriceFirst, Tax = price.TaxFirst, MaterialCosts = price.MaterialCosts };

                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var price = db.PriceList.First(f => f.ExamTypeId == typeId && f.DrivingCategoryId == drivingCategory.Id);
                    var data = new { Price = price.PriceFirst, Tax = price.TaxFirst, MaterialCosts = price.MaterialCosts };

                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var price = db.PriceList.First(f => f.ExamTypeId == typeId && f.DrivingCategoryId == drivingCategory.Id);
                var data = new { Price = price.PriceFirst, Tax = price.TaxFirst, MaterialCosts = price.MaterialCosts };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult FilterMenuCustomization_Status()
        {
            return Json(db.ExamRegistrationStatus.Select(e => e.Status).Distinct(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult FilterMenuCustomization_ExamType()
        {
            return Json(db.ExamType.Select(e => e.Type).Distinct(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult FilterMenuCustomization_ExamCenter()
        {
            return Json(db.ExamCenters.Select(e => e.Name).Distinct(), JsonRequestBehavior.AllowGet);
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