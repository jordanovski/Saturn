namespace Saturn.Model
{
    using Saturn.Model.Codebooks;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Registration")]
    public partial class Registration
    {
        public Registration()
        {
            ExamRegistration = new HashSet<ExamRegistration>();
        }

        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string RegistrationNumber { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Датум")]
        public DateTime? RegistrationDate { get; set; }
        
        [Display(Name = "Место")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Place { get; set; }

        public int? OrdinalNumber { get; set; }

        public int CandidateId { get; set; }

        [Display(Name = "Автошкола")]
        public int? DrivingSchoolId { get; set; }

        public int? DrivingCategoryId { get; set; }

        [Display(Name = "Инструктор")]
        public int? InstructorPracticeId { get; set; }

        [Display(Name = "Предавач")]
        public int? InstructorTheoryId { get; set; }

        public int? VehicleTypeId { get; set; }

        [Display(Name = "Тип на возило")]
        public int? VehicleId { get; set; }

        [Display(Name = "Приклучно возило")]
        public int? AuxiliaryVehicleId { get; set; }

        [Display(Name = "Цена")]
        public double? Price { get; set; }

        [Display(Name = "Такса")]
        public double? Tax { get; set; }

        [Display(Name = "Забелешка")]
        public string Note { get; set; }

        public int? StatusId { get; set; }


        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string CreatedBy { get; set; }

        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string ChangedBy { get; set; }

        

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual Instructor Instructor1 { get; set; }

        public virtual RegistrationStatus RegistrationStatus { get; set; }
    }
}
