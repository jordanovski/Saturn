using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saturn.Model.ViewModels
{
    public class AssessmentSheetViewModel
    {
        public int? ExamTypeId { get; set; }
        public int ExamRegistrationId { get; set; }
        public int AllowedNegativePoints { get; set; }

        [Display(Name = "Не се повави на испит")]
        public bool NotAppearOnTheExam { get; set; }

        public AssessmentSheetTheoryViewModel Theory { get; set; }

        public List<AssessmentSheetPolygonCityViewModel> Polygon { get; set; }

        public List<AssessmentSheetPolygonCityViewModel> City { get; set; }
    }
}
