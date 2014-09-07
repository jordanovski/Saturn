using Saturn.Data;
using Saturn.Model;
using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using Saturn.Model.Views;
using Saturn.Web.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class AssessmentSheetController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();
        private readonly SaturnDbViewContext dbView = new SaturnDbViewContext();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ExamRegistrationId</param>
        /// <returns></returns>
        public ActionResult Create(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Session["ExamRegistrationId"] = id;

            var examRegistration = dbView.ViewExamRegistration.First(w => w.ExamRegistrationId == id);
            var drivingCategory = db.DrivingCategory.First(f => f.Id == examRegistration.DrivingCategoryId);
            var candidate = dbView.ViewCandidates.First(w => w.CandidateId == examRegistration.CandidateId);

            ViewBag.Candidate = candidate;

            AssessmentSheetViewModel data = new AssessmentSheetViewModel();
            data.ExamTypeId = (int)examRegistration.ExamTypeId;
            data.ExamRegistrationId = (int)id;

            data.Theory = new AssessmentSheetTheoryViewModel();
            data.Polygon = new List<AssessmentSheetPolygonCityViewModel>();
            data.City = new List<AssessmentSheetPolygonCityViewModel>();

            switch ((int)examRegistration.ExamTypeId)
            {
                case 1:
                    ViewBag.Title = "Оценувачки лист - теорија";
                    GetAssessmentSheetTheory(data, drivingCategory, examRegistration, (int)id);
                    break;
                case 2:
                    ViewBag.Title = "Оценувачки лист - полигон";
                    GetAssessmentSheetPolygon(data, drivingCategory, examRegistration, (int)id);
                    break;
                case 3:
                    ViewBag.Title = "Оценувачки лист - град";
                    GetAssessmentSheetCity(data, drivingCategory, examRegistration, (int)id);
                    break;
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AssessmentSheetViewModel assessmentSheet)
        {
            var id = int.Parse(Session["ExamRegistrationId"].ToString());

            if (ModelState.IsValid)
            {
                switch (assessmentSheet.ExamTypeId)
                {
                    case 1:
                        SaveAssessmentSheetTheory(id, assessmentSheet);
                        break;
                    case 2:
                        SaveAssessmentSheetPolygon(id, assessmentSheet);
                        break;
                    case 3:
                        SaveAssessmentSheetCity(id, assessmentSheet);
                        break;
                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index", "ExamRegistration");
            }

            var examRegistration = dbView.ViewExamRegistration.First(w => w.ExamRegistrationId == id);

            var candidate = dbView.ViewCandidates.First(w => w.CandidateId == examRegistration.CandidateId);

            ViewBag.Candidate = candidate;


            return View(assessmentSheet);
        }



        public void GetAssessmentSheetTheory(AssessmentSheetViewModel data, DrivingCategory drivingCategory, ViewExamRegistration examRegistration, int id)
        {
            data.AllowedNegativePoints = drivingCategory.AllowedNegativeTheory;
            data.NotAppearOnTheExam = examRegistration.ExamRegistrationStatusId == 4;
            data.Theory = new AssessmentSheetTheoryViewModel();

            if (db.Report.Any(a => a.ExamRegistrationId == id))
            {
                var existingReport = db.Report.First(f => f.ExamRegistrationId == id);
                data.Theory.NegativePoints = (int)existingReport.NegativePoints;
            }
            else
            {
                data.Theory.NegativePoints = 0;
            }
        }
        public void GetAssessmentSheetPolygon(AssessmentSheetViewModel data, DrivingCategory drivingCategory, ViewExamRegistration examRegistration, int id)
        {
            data.AllowedNegativePoints = drivingCategory.AllowedNegativePolygon;
            data.NotAppearOnTheExam = examRegistration.ExamRegistrationStatusId == 4;
            data.Polygon = new List<AssessmentSheetPolygonCityViewModel>();

            if (drivingCategory.Category.Trim().Equals("А") || drivingCategory.Category.Trim().Equals("A1"))
            {
                CreateQuestionListPolygonCity(id, "А кат", data.Polygon);
            }
            else
            {
                CreateQuestionListPolygonCity(id, "бр1", data.Polygon);
            }
        }
        public void GetAssessmentSheetCity(AssessmentSheetViewModel data, DrivingCategory drivingCategory, ViewExamRegistration examRegistration, int id)
        {
            data.AllowedNegativePoints = drivingCategory.AllowedNegativePracticle;
            data.NotAppearOnTheExam = examRegistration.ExamRegistrationStatusId == 4;
            data.City = new List<AssessmentSheetPolygonCityViewModel>();

            if (drivingCategory.Category.Trim().Equals("А") || drivingCategory.Category.Trim().Equals("A1"))
            {
                CreateQuestionListPolygonCity(id, "А кат", data.City);
            }
            else
            {
                CreateQuestionListPolygonCity(id, "бр2", data.City);
            }
        }


        private void CreateQuestionListPolygonCity(int examRegId, string form, List<AssessmentSheetPolygonCityViewModel> data)
        {
            var errorTypesCity = db.ErrorType.Where(w => w.Form == form).ToList();
            var examRegistrationErrors = db.ExamRegistrationError.Where(w => w.ExamRegistrationId == examRegId);

            foreach (var e in errorTypesCity)
            {
                var item = new AssessmentSheetPolygonCityViewModel()
                {
                    questionId = e.Id,
                    isChecked = false,
                    points = 1,
                    questionNumber = e.Form + " " + e.Question,
                    question = e.Description,
                    PenaltyPoints = (int)e.PenaltyPoints,
                    PenaltyPointsString = "(" + e.PenaltyPoints + ")"
                };
                if (examRegistrationErrors.Any(a => a.ErrorTypeId == e.Id))
                {
                    item.isChecked = true;
                    item.points = examRegistrationErrors.First(a => a.ErrorTypeId == e.Id).Quantity;
                }
                data.Add(item);
            }
        }



        public void SaveAssessmentSheetTheory(int id, AssessmentSheetViewModel assessmentSheet)
        {
            if (assessmentSheet.NotAppearOnTheExam)
            {
                //Не се појави на испит
                NotAppearOnTheExam(id, assessmentSheet);
            }
            else
            {
                // Се појавил на испит
                AppearOnTheExamTheory(id, assessmentSheet);
            }
        }
        public void SaveAssessmentSheetPolygon(int id, AssessmentSheetViewModel assessmentSheet)
        {
            if (assessmentSheet.NotAppearOnTheExam)
            {
                //Не се појави на испит
                NotAppearOnTheExam(id, assessmentSheet);
            }
            else
            {
                // Се појавил на испит
                AppearOnTheExamPolygon(id, assessmentSheet);
            }
        }
        public void SaveAssessmentSheetCity(int id, AssessmentSheetViewModel assessmentSheet)
        {
            if (assessmentSheet.NotAppearOnTheExam)
            {
                //Не се појави на испит
                NotAppearOnTheExam(id, assessmentSheet);
            }
            else
            {
                // Се појавил на испит
                AppearOnTheExamCity(id, assessmentSheet);
            }
        }




        private void NotAppearOnTheExam(int id, AssessmentSheetViewModel assessmentSheet)
        {
            var examRegistration = db.ExamRegistration.First(f => f.Id == assessmentSheet.ExamRegistrationId);
            examRegistration.StatusId = (int)ExamRegStatusEnum.NotAppear;
            db.Entry(examRegistration).State = EntityState.Modified;

            var examRegistrationErrors = db.ExamRegistrationError.Where(w => w.ExamRegistrationId == id);
            if (examRegistrationErrors.Any())
            {
                foreach (var e in examRegistrationErrors)
                {
                    db.ExamRegistrationError.Remove(e);
                }
            }

            RemoveReport(id);
        }



        private void AppearOnTheExamTheory(int id, AssessmentSheetViewModel assessmentSheet)
        {
            var examRegistration = db.ExamRegistration.First(f => f.Id == assessmentSheet.ExamRegistrationId);

            if (assessmentSheet.Theory.NegativePoints > assessmentSheet.AllowedNegativePoints)
            {
                //Не положил
                examRegistration.StatusId = (int)ExamRegStatusEnum.NotPassed;
                db.Entry(examRegistration).State = EntityState.Modified;

                GenerateReport(id, assessmentSheet.Theory.NegativePoints, false);
            }
            else
            {
                //Положил
                examRegistration.StatusId = (int)ExamRegStatusEnum.Passed;
                db.Entry(examRegistration).State = EntityState.Modified;

                GenerateReport(id, assessmentSheet.Theory.NegativePoints, true);
            }
        }
        private void AppearOnTheExamPolygon(int id, AssessmentSheetViewModel assessmentSheet)
        {
            var examRegistrationErrors = db.ExamRegistrationError.Where(w => w.ExamRegistrationId == id);

            if (examRegistrationErrors.Any())
            {
                // Има претходни записи со грешки од испитот во базата
                var examRegistrationErrorsIds = examRegistrationErrors.Select(s => s.ErrorTypeId);

                CreateExamRegistrationError(id, assessmentSheet.Polygon.Where(w => w.isChecked && !examRegistrationErrorsIds.Contains(w.questionId)).ToList());
                CleanExamRegistrationError(assessmentSheet.Polygon, examRegistrationErrors);
            }
            else
            {
                //Нема претходни записи во грешки од испит во базата
                CreateExamRegistrationError(id, assessmentSheet.Polygon.Where(w => w.isChecked).ToList());
            }

            CheckNegativePoints(id, assessmentSheet.Polygon, assessmentSheet.AllowedNegativePoints, assessmentSheet.ExamRegistrationId);
        }
        private void AppearOnTheExamCity(int id, AssessmentSheetViewModel assessmentSheet)
        {
            var examRegistrationErrors = db.ExamRegistrationError.Where(w => w.ExamRegistrationId == id);

            if (examRegistrationErrors.Any())
            {
                // Има претходни записи со грешки од испитото во базата
                var examRegistrationErrorsIds = examRegistrationErrors.Select(s => s.ErrorTypeId);

                CreateExamRegistrationError(id, assessmentSheet.City.Where(w => w.isChecked && !examRegistrationErrorsIds.Contains(w.questionId)).ToList());
                CleanExamRegistrationError(assessmentSheet.City, examRegistrationErrors);
            }
            else
            {
                //Нема претходни записи во грешки од испит во базата
                CreateExamRegistrationError(id, assessmentSheet.City.Where(w => w.isChecked).ToList());
            }

            CheckNegativePoints(id, assessmentSheet.City, assessmentSheet.AllowedNegativePoints, assessmentSheet.ExamRegistrationId);
        }



        private void GenerateReport(int id, int negativePoints, bool passed)
        {
            if (db.Report.Any(a => a.ExamRegistrationId == id))
            {
                ModifyReport(id, negativePoints, passed);
            }
            else
            {
                CreateReport(id, negativePoints, passed);
            }
        }
        private void CreateReport(int examRegId, int negativePoints, bool passed)
        {
            var report = new Report()
            {
                ExamRegistrationId = examRegId,
                NegativePoints = negativePoints,
            };
            report.Status = passed ? ((int)ReportStatusEnum.Passed).ToString() : ((int)ReportStatusEnum.NotPassed).ToString();

            db.Report.Add(report);
        }
        private void ModifyReport(int examRegId, int negativePoints, bool passed)
        {
            var report = db.Report.First(f => f.ExamRegistrationId == examRegId);
            report.NegativePoints = negativePoints;
            report.Status = passed ? ((int)ReportStatusEnum.Passed).ToString() : ((int)ReportStatusEnum.NotPassed).ToString();

            db.Entry(report).State = EntityState.Modified;
        }
        private void RemoveReport(int id)
        {
            if (db.Report.Any(a => a.ExamRegistrationId == id))
            {
                var report = db.Report.First(f => f.ExamRegistrationId == id);
                db.Report.Remove(report);
            }
        }



        private void CreateExamRegistrationError(int id, List<AssessmentSheetPolygonCityViewModel> data)
        {
            foreach (var r in data.Where(w => w.isChecked))
            {
                var error = new ExamRegistrationError()
                {
                    ExamRegistrationId = id,
                    ErrorTypeId = r.questionId,
                    Quantity = r.points
                };
                db.ExamRegistrationError.Add(error);
            }
        }
        /// <summary>
        /// Доколку во базата има записи кој се променети ги менува а доклку има записи кој се избришени ги брише од база.
        /// </summary>
        /// <param name="assessmentSheet"></param>
        /// <param name="examRegistrationErrors"></param>
        private void CleanExamRegistrationError(List<AssessmentSheetPolygonCityViewModel> assessmentSheet, IQueryable<ExamRegistrationError> examRegistrationErrors)
        {
            var questionIds = assessmentSheet.Where(w => w.isChecked).Select(s => s.questionId);
            foreach (var e in examRegistrationErrors)
            {
                if (questionIds.Contains(e.ErrorTypeId))
                {
                    e.Quantity = assessmentSheet.First(w => w.questionId == e.ErrorTypeId).points;
                    db.Entry(e).State = EntityState.Modified;
                }
                else
                {
                    db.ExamRegistrationError.Remove(e);
                }
            }
        }




        private void CheckNegativePoints(int id, List<AssessmentSheetPolygonCityViewModel> questions, int allowedNegativePoints, int examRegId)
        {
            var examRegistration = db.ExamRegistration.First(f => f.Id == examRegId);

            int totalNegativPoints = CalculateNegatiPoints(questions);
            if (totalNegativPoints > allowedNegativePoints)
            {
                examRegistration.StatusId = (int)ExamRegStatusEnum.NotPassed;
                GenerateReport(id, totalNegativPoints, false);
            }
            else
            {
                examRegistration.StatusId = (int)ExamRegStatusEnum.Passed;
                GenerateReport(id, totalNegativPoints, true);
            }

            db.Entry(examRegistration).State = EntityState.Modified;
        }


        private int CalculateNegatiPoints(List<AssessmentSheetPolygonCityViewModel> assessmentSheet)
        {
            var totalNegativePoints = 0;
            foreach (var e in assessmentSheet.Where(w => w.isChecked))
            {
                totalNegativePoints = totalNegativePoints + (e.points * e.PenaltyPoints);
            }

            return totalNegativePoints;
        }

    }
}