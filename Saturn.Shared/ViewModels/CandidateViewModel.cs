using Saturn.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Sasturn.Shared.ViewModels
{
    public class CandidateViewModel
    {
        public static Expression<Func<Candidate, CandidateViewModel>> FromCandidates
        {
            get
            {
                return c => new CandidateViewModel
                {
                    Id = c.Id,
                    FullName = c.FirstName + " " + c.LastName,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    FatherName = c.FatherName,
                    PersonalCardNumber = c.PersonalCardNumber,
                    IssuedBy = c.IssuedBy,
                    UniqueNumber = c.UniqueNumber,
                    Address = c.Address + ", " + c.City.Name,
                    City = c.City.Name,
                    BirthDate = c.BirthDate,
                    BirthPlace = c.BirthPlace,
                    Profession = c.PersonalCardNumber,
                    Note = c.Note,
                    DossierNumber = c.DossierNumber,
                    DossierDate = c.DossierDate,
                    DrivingCategory = c.DrivingCategory.Category,
                    ExistingDrivingCategory = c.ExistingDrivingCategory
                };
            }
        }

        public int Id { get; set; }

        [Display(Name = "Досие")]
        public string DossierNumber { get; set; }


        [Display(Name = "Датум досие")]
        public Nullable<System.DateTime> DossierDate { get; set; }


        [Display(Name = "Име презиме")]
        public string FullName { get; set; }


        [Display(Name = "Име")]
        public string FirstName { get; set; }


        [Display(Name = "Презиме")]
        public string LastName { get; set; }


        [Display(Name = "Татково име")]
        public string FatherName { get; set; }


        [Display(Name = "Број на лична карта")]
        public string PersonalCardNumber { get; set; }


        [Display(Name = "Издадена од")]
        public string IssuedBy { get; set; }


        [Display(Name = "Матичен број")]
        public string UniqueNumber { get; set; }


        [Display(Name = "Адреса")]
        public string Address { get; set; }


        [Display(Name = "Град")]
        public string City { get; set; }


        [Display(Name = "Датум на раѓање")]
        public DateTime? BirthDate { get; set; }


        [Display(Name = "Место на раѓање")]
        public string BirthPlace { get; set; }


        [Display(Name = "Професија")]
        public string Profession { get; set; }


        [Display(Name = "Забелешка")]
        public string Note { get; set; }


        [Display(Name = "Кат.")]
        public string DrivingCategory { get; set; }


        [Display(Name = "Поседува")]
        public string ExistingDrivingCategory { get; set; }
    }
}
