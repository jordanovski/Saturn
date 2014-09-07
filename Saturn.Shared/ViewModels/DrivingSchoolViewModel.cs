using Saturn.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Saturn.Shared.ViewModels
{
    public class DrivingSchoolViewModel
    {
        public static Expression<Func<DrivingSchool, DrivingSchoolViewModel>> FromDrivingSchool
        {
            get
            {
                return c => new DrivingSchoolViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    TaxNumber = c.TaxNumber,
                    Address = c.Address,
                    City = c.City.Name,
                    Note = c.Note,
                    IsActive = c.IsActive
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

        [Display(Name = "Забелешка")]
        public string Note { get; set; }

        [Display(Name = "Активна")]
        public bool? IsActive { get; set; }
    }
}
