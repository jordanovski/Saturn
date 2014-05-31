using Saturn.Model.Codebooks;
using System;
using System.Linq.Expressions;

namespace Saturn.Model.ViewModels
{
    public class StatusViewModel
    {
        public static Expression<Func<RegistrationStatus, StatusViewModel>> FromRegistrationStatus
        {
            get
            {
                return c => new StatusViewModel
                {
                    Id = c.Id,
                    Status = c.Status
                };
            }
        }
        public static Expression<Func<ExamRegistrationStatus, StatusViewModel>> FromExamRegistrationStatus
        {
            get
            {
                return c => new StatusViewModel
                {
                    Id = c.Id,
                    Status = c.Status
                };
            }
        }

        public int Id { get; set; }
        public string Status { get; set; }
    }
}
