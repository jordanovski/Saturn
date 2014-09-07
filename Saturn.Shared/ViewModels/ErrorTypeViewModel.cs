using Saturn.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Saturn.Shared.ViewModels
{
    public class ErrorTypeViewModel
    {
        public static Expression<Func<ErrorType, ErrorTypeViewModel>> FromErrorType
        {
            get
            {
                return s => new ErrorTypeViewModel
                {
                    Id = s.Id,
                    Form = s.Form,
                    Question = s.Question,
                    Description = s.Description,
                    DrivingCategory = s.DrivingCategory,
                    PenaltyPoints = s.PenaltyPoints
                };
            }
        }

        public int Id { get; set; }

        [Display(Name = "Форма")]
        public string Form { get; set; }

        [Display(Name = "Прашање")]
        public string Question { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Категорија")]
        public string DrivingCategory { get; set; }

        [Display(Name = "Тип на испит")]
        public string ExaminationType { get; set; }

        [Display(Name = "Поени")]
        public int? PenaltyPoints { get; set; }

    }
}
