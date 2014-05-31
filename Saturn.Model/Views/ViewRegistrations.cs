namespace Saturn.Model.Views
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ViewRegistrations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegistrationId { get; set; }


        [Display(Name = "Кат.")]
        public string DrivingCategory { get; set; }

        [Display(Name = "Бр.досие")]
        public string DossierNumber { get; set; }

        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        public string LastName { get; set; }

        [Display(Name = "ЕМБГ")]
        public string UniqueNumber { get; set; }

        [Display(Name = "Датум")]
        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Статус")]
        public string RegistrationStatus { get; set; }

        [Display(Name = "Цена")]
        public double? Price { get; set; }

        [Display(Name = "Автошкола")]
        public string DrivingSchoolName { get; set; }


        public string RegistrationNumber { get; set; }

        public string Place { get; set; }

        public int? OrdinalNumber { get; set; }

        public int CandidateId { get; set; }

        public int? DrivingSchoolId { get; set; }

        public int? DrivingCategoryId { get; set; }

        public int? InstructorPracticeId { get; set; }

        public string InstructorPracticeName { get; set; }

        public int? InstructorTheoryId { get; set; }

        public string InstructorTheoryName { get; set; }

        public int? VehicleTypeId { get; set; }

        public int? VehicleId { get; set; }

        public int? AuxiliaryVehicleId { get; set; }

        public double? Tax { get; set; }

        public string Note { get; set; }

        public int? RegistrationStatusId { get; set; }
        
        public string ExistingDrivingCategory { get; set; }
    }
}
