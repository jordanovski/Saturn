using System.ComponentModel.DataAnnotations;

namespace Saturn.Model.ViewModels
{
    public class ReqDocDrivingCategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Документ")]
        public string ReqDocument { get; set; }

        [Display(Name = "Категорија")]
        public string DrivingCategory { get; set; }
    }
}
