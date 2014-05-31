using System.ComponentModel.DataAnnotations;

namespace Saturn.Model.ViewModels
{
    public class InstructorViewModel
    {
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
