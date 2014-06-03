using Saturn.Model.Codebooks;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Saturn.Model.ViewModels
{
    public class ContactPersonViewModel
    {
        public static Expression<Func<ContactPerson, ContactPersonViewModel>> FromContactPerson
        {
            get
            {
                return s => new ContactPersonViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    DrivingSchool = s.DrivingSchool.Name,
                    ContactType = s.ContactType.Type,
                    ContactValue = s.ContactValue,
                    DrivingSchoolId = s.DrivingSchoolId
                };
            }
        }

        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Авто школа")]
        public string DrivingSchool { get; set; }

        [Display(Name = "Контант")]
        public string ContactType { get; set; }

        [Display(Name = "Вредност")]
        public string ContactValue { get; set; }

        public int DrivingSchoolId { get; set; }
    }
}
