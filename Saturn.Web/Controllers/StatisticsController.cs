using Saturn.Data;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Saturn.Web.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly SaturnDbContext db = new SaturnDbContext();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ExamErrors()
        {
            return View();
        }
        public string GetErrorsStatistic(string type, string fromDate, string toDate)
        {
            DateTime from, to;
            var hasFromDate = DateTime.TryParse(fromDate, out from);
            var hasToDate = DateTime.TryParse(toDate, out to);
            var form = type == "1" ? "бр1" : "бр2";
            var result = "<table class='table table-bordered'> <thead> <tr> <th>Образец</th> <th>Прашање</th> <th>Опис</th> <th>Број на грешки</th> </tr> </thead> <tbody>";

            foreach (var e in db.ErrorType.Where(w => w.Form == form).ToList())
            {
                var countErrors = db.ExamRegistrationError.Where(w => w.ErrorTypeId == e.Id).Count();
                result += "<tr>";
                result += "<th>" + e.Form + "</th>";
                result += "<th>" + e.Question + "</th>";
                result += "<th>" + e.Description + "</th>";
                result += "<th>" + countErrors + "</th>";
                result += "</tr>";
            }

            result += "</tbody>";
            result += "</table>";
            return result;
        }


        public ActionResult Examiner()
        {
            return View();
        }
        public string GetExaminersStatistic(string fromDate, string toDate)
        {
            DateTime from, to;
            var hasFromDate = DateTime.TryParse(fromDate, out from);
            var hasToDate = DateTime.TryParse(toDate, out to);

            var result = "<table class='table table-bordered'> <thead> <tr> <th>Име</th> <th>Презиме</th> <th>Претседател</th> <th>Испитувач</th> <th>Член</th> </tr> </thead> <tbody>";
            foreach (var e in db.Examiner.ToList())
            {
                int countMember = 0, countExaminer = 0, countPresident = 0;
                if (hasFromDate && hasToDate)
                {
                    countMember = db.Examination.Where(w => w.MemberId == e.Id && w.ExamDate >= from && w.ExamDate <= to).Count();
                    countExaminer = db.Examination.Where(w => w.ExaminerId == e.Id && w.ExamDate >= from && w.ExamDate <= to).Count();
                    countPresident = db.Examination.Where(w => w.PresidentId == e.Id && w.ExamDate >= from && w.ExamDate <= to).Count();
                }
                else
                {
                    if (hasFromDate)
                    {
                        countMember = db.Examination.Where(w => w.MemberId == e.Id && w.ExamDate >= from).Count();
                        countExaminer = db.Examination.Where(w => w.ExaminerId == e.Id && w.ExamDate >= from).Count();
                        countPresident = db.Examination.Where(w => w.PresidentId == e.Id && w.ExamDate >= from).Count();
                    }
                    else
                    {
                        if (hasToDate)
                        {
                            countMember = db.Examination.Where(w => w.MemberId == e.Id && w.ExamDate <= to).Count();
                            countExaminer = db.Examination.Where(w => w.ExaminerId == e.Id && w.ExamDate <= to).Count();
                            countPresident = db.Examination.Where(w => w.PresidentId == e.Id && w.ExamDate <= to).Count();
                        }
                        else
                        {
                            countMember = db.Examination.Where(w => w.MemberId == e.Id).Count();
                            countExaminer = db.Examination.Where(w => w.ExaminerId == e.Id).Count();
                            countPresident = db.Examination.Where(w => w.PresidentId == e.Id).Count();
                        }
                    }
                }

                result += "<tr>";
                result += "<th>" + e.FirstName + "</th>";
                result += "<th>" + e.LastName + "</th>";
                result += "<th>" + countPresident + "</th>";
                result += "<th>" + countExaminer + "</th>";
                result += "<th>" + countMember + "</th>";
                result += "</tr>";
            }
            result += "</tbody>";
            result += "</table>";
            return result;
        }


        
    }
}