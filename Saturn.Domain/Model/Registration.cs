using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("Registration")]
    public partial class Registration
    {
        public Registration()
        {
            ExamRegistration = new HashSet<ExamRegistration>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }

        [StringLength(50)]
        public string Place { get; set; }

        public int? OrdinalNumber { get; set; }

        public int CandidateId { get; set; }

        public int? DrivingSchoolId { get; set; }

        public int? DrivingCategoryId { get; set; }

        public int? InstructorPracticeId { get; set; }

        public int? InstructorTheoryId { get; set; }

        public int? VehicleTypeId { get; set; }

        public int? VehicleId { get; set; }

        public int? AuxiliaryVehicleId { get; set; }

        public double? Price { get; set; }

        public double? Tax { get; set; }

        public string Note { get; set; }

        public int? StatusId { get; set; }

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }

        public virtual Instructor Instructor { get; set; }

        public virtual Instructor Instructor1 { get; set; }

        public virtual RegistrationStatus RegistrationStatus { get; set; }
    }
}
