using System.ComponentModel.DataAnnotations;

namespace Saturn.Shared.ViewModels
{
    public class AssessmentSheetTheoryViewModel
    {
        [Display(Name = "Негативни поени")]
        public int NegativePoints { get; set; }

    }
}
