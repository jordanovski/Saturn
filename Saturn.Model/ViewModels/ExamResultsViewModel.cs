using Saturn.Model.Views;
using System;
using System.Linq.Expressions;

namespace Saturn.Model.ViewModels
{
    public class ExamResultsViewModel
    {
        public static Expression<Func<ViewExamCandidates, ExamResultsViewModel>> FromViewExamCandidates
        {
            get
            {
                return c => new ExamResultsViewModel
                {
                    ExamId = c.ExamId,
                    CandidateFullName = c.FirstName + " " + c.LastName,
                    DossierNumber = c.DossierNumber,
                    Category = c.Category,
                    NegativePoints = c.NegativePoints,
                    Status = c.Status,
                    ExamType = c.ExamType
                };
            }
        }

        public int? ExamId { get; set; }

        public string CandidateFullName { get; set; }
        public string DossierNumber { get; set; }
        public string Category { get; set; }
        public double? NegativePoints { get; set; }
        public string Status { get; set; }
        public string ExamType { get; set; }
        
    }
}
