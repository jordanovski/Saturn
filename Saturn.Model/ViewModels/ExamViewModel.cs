using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Saturn.Model.Views;

namespace Saturn.Model.ViewModels
{
    public class ExamViewModel
    {
        public static Expression<Func<Examination, ExamViewModel>> FromExamination
        {
            get
            {
                return c => new ExamViewModel
                {
                    Id = c.Id,
                    ExamType = c.ExamTypeId.HasValue ? c.ExamType.Type : "",
                    ExamCenter = c.ExamCenters.Name,
                    PresidentName = c.PresidentId.HasValue ? c.Examiner.FullName : "",
                    ExaminerName = c.ExaminerId.HasValue ? c.Examiner1.FullName : "",
                    MemberName = c.MemberId.HasValue ? c.Examiner2.FullName : "",
                    ExamDate = c.ExamDate,
                    ExamTime = c.ExamTime,
                    ExamDateTime = new DateTime(c.ExamDate.Year, c.ExamDate.Month, c.ExamDate.Day, c.ExamTime.Hours, c.ExamTime.Minutes, c.ExamTime.Seconds)
                };
            }
        }

        public static Expression<Func<ViewExaminations, ExamViewModel>> FromViewExaminations
        {
            get
            {
                return c => new ExamViewModel
                {
                    Id = c.ExaminationId,
                    ExamType = c.ExamTypeId.HasValue ? c.ExamType : "",
                    ExamCenter = c.ExamCenter,
                    PresidentName = c.PresidentId.HasValue ? c.PresidentName : "",
                    ExaminerName = c.ExaminerId.HasValue ? c.ExaminerName : "",
                    MemberName = c.MemberId.HasValue ? c.MemberName : "",
                    ExamDate = c.ExamDate,
                    ExamTime = c.ExamTime,
                    ExamDateTime = new DateTime(c.ExamDate.Year, c.ExamDate.Month, c.ExamDate.Day, c.ExamTime.Hours, c.ExamTime.Minutes, c.ExamTime.Seconds)
                };
            }
        }


        public int Id { get; set; }

        [Display(Name = "Тип на испит")]
        public string ExamType { get; set; }

        [Display(Name = "Локација")]
        public string ExamCenter { get; set; }

        [Display(Name = "Претседател")]
        public string PresidentName { get; set; }

        [Display(Name = "Испитувач")]
        public string ExaminerName { get; set; }

        [Display(Name = "Член")]
        public string MemberName { get; set; }

        public DateTime ExamDate { get; set; }

        public TimeSpan ExamTime { get; set; }

        [Display(Name = "Време")]
        public DateTime ExamDateTime { get; set; }
    }
}
