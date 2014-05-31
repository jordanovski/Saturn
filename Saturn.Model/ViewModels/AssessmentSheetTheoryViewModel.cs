using System.ComponentModel.DataAnnotations;

namespace Saturn.Model.ViewModels
{
    public class AssessmentSheetTheoryViewModel
    {
        [Display(Name = "Негативни поени")]
        public int NegativePoints { get; set; }

    }
}
