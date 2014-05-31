using System.ComponentModel.DataAnnotations;

namespace Saturn.Model.ViewModels
{
    public class ExamCenterViewModel
    {
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
