using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Saturn.Model.ViewModels
{
    public class ReqDocCandidateViewModel
    {
        public static Expression<Func<ReqDocCandidate, ReqDocCandidateViewModel>> FromReqDocCandidate
        {
            get
            {
                return c => new ReqDocCandidateViewModel
                {
                    Id = c.Id,
                    CandidateId = c.CandidateId,
                    ReqDocumentId = c.ReqDocumentId,
                    ReqDocument = c.RequiredDocument.ReqDocument,
                    DocumentNumber = c.DocumentNumber,
                    IssueDate = c.IssueDate,
                    ValidTo = c.ValidTo,
                };
            }
        }

        public int Id { get; set; }

        [Display(Name = "Документ")]
        public string ReqDocument { get; set; }

        [Display(Name = "Кнадидат")]
        public int CandidateId { get; set; }

        [Display(Name = "Број на документ")]
        public string DocumentNumber { get; set; }

        [Display(Name = "Издаден на")]
        [UIHint("Date")]
        public Nullable<System.DateTime> IssueDate { get; set; }

        [Display(Name = "Валидане до")]
        [UIHint("DateTime")]
        public Nullable<System.DateTime> ValidTo { get; set; }

        [Display(Name = "Забелешка")]
        public string Note { get; set; }

        public int ReqDocumentId { get; set; }
    }
}
