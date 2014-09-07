using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Saturn.Domain.Model;

namespace Saturn.Shared.ViewModels
{
    public class InstructorViewModel
    {
        public static Expression<Func<Instructor, InstructorViewModel>> FromInstructor
        {
            get
            {
                return s => new InstructorViewModel
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    UniqueNumber = s.UniqueNumber,
                    DrivingSchool = s.DrivingSchool.Name,
                    Practice = s.Practice,
                    Theory = s.Theory,
                    IsActive = s.IsActive
                };
            }
        }
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        public string LastName { get; set; }

        [Display(Name = "Матичен број")]
        public string UniqueNumber { get; set; }

        [Display(Name = "Авто школа")]
        public string DrivingSchool { get; set; }

        [Display(Name = "Пракса")]
        public bool Practice { get; set; }

        [Display(Name = "Теорија")]
        public bool Theory { get; set; }

        [Display(Name = "Активен")]
        public bool IsActive { get; set; }
    }
}
