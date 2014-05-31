namespace Saturn.Model.Views
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ViewExamRegistration")]
    public partial class ViewExamRegistration
    {
        public int RegistrationId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string RegistrationPlace { get; set; }
        public int? OrdinalNumber { get; set; }
        public int CandidateId { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public int? DrivingSchoolId { get; set; }
        public string DrivingSchoolName { get; set; }
        public int? DrivingCategoryId { get; set; }
        public string DrivingCategory { get; set; }
        public int? InstructorPracticeId { get; set; }
        public string InstructorPracticeName { get; set; }
        public int? InstructorTheoryId { get; set; }
        public string InstructorTheoryName { get; set; }
        public int? VehicleTypeId { get; set; }
        public int? VehicleId { get; set; }
        public int? AuxiliaryVehicleId { get; set; }
        public double? RegistrationPrice { get; set; }
        public double? RegistrationTax { get; set; }
        public string RegistrationNote { get; set; }
        public int? RegistrationStatusId { get; set; }
        public string RegistrationStatus { get; set; }
        public string UniqueNumber { get; set; }
        public string DossierNumber { get; set; }

        public int ExaminationId { get; set; }
        public int? ExamTypeId { get; set; }
        public string ExamType { get; set; }
        public int? ExamCenterId { get; set; }
        public string ExamCenter { get; set; }
        public int? PresidentId { get; set; }
        public string PresidentName { get; set; }
        public int? ExaminerId { get; set; }
        public string ExaminerName { get; set; }
        public int? MemberId { get; set; }
        public string MemberName { get; set; }
        
        [Column(Order = 8, TypeName = "date")]
        public DateTime ExamDate { get; set; }
        public TimeSpan ExamTime { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExamRegistrationId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExamRegistrationDate { get; set; }
        public int? WayOfTakingId { get; set; }
        public string WayOfTaking { get; set; }
        public int? LanguageId { get; set; }
        public string Language { get; set; }
        public string LanguageCode { get; set; }
        public string ExamRegistrationPlace { get; set; }
        public double? ExamRegistrationPrice { get; set; }
        public double? ExamRegistrationTax { get; set; }
        public int? UseVehicle { get; set; }
        public double? MaterialCosts { get; set; }
        public double? PDVAmount { get; set; }
        public double? PDVVehicle { get; set; }
        public double? PDVTest { get; set; }
        public int? ExamRegistrationStatusId { get; set; }
        public string ExamRegistrationStatus { get; set; }
        public double? ExamRegistrationResult { get; set; }


        [NotMapped]
        public DateTime ExamDateTime
        {
            get
            {
                return new DateTime(ExamDate.Year, ExamDate.Month, ExamDate.Day, ExamTime.Hours, ExamTime.Minutes, ExamTime.Seconds);
            }
            private set { }
        }
    }
}
