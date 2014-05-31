using System.ComponentModel.DataAnnotations;

namespace Saturn.Model.ViewModels
{
    public class ContactPersonViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name = "Авто школа")]
        public string DrivingSchool { get; set; }

        [Display(Name = "Контант")]
        public string ContactType { get; set; }

        [Display(Name = "Вредност")]
        public string ContactValue { get; set; }
    }
}
