using Saturn.Model.Codebooks;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Saturn.Model.ViewModels
{
    public class ExamCenterViewModel
    {
        public static Expression<Func<ExamCenters, ExamCenterViewModel>> FromExamCenter
        {
            get
            {
                return s => new ExamCenterViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    TaxNumber = s.TaxNumber,
                    Address = s.Address,
                    City = s.City.Name
                };
            }
        }

        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Даночен број")]
        public string TaxNumber { get; set; }

        [Display(Name = "Адреса")]
        public string Address { get; set; }

        [Display(Name = "Град")]
        public string City { get; set; }
    }
}
