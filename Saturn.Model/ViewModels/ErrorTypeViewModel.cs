using System.ComponentModel.DataAnnotations;

namespace Saturn.Model.ViewModels
{
    public class ErrorTypeViewModel
    {
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
