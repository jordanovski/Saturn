namespace Saturn.Shared.ViewModels
{
    public class AssessmentSheetPolygonCityViewModel
    {
        public int questionId { get; set; }

        public bool isChecked { get; set; }
        public int points { get; set; }
        public string questionNumber { get; set; }
        public string question { get; set; }
        public string PenaltyPointsString { get; set; }
        public int PenaltyPoints { get; set; }
    }
}
