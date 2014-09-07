using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("ExamRegistration")]
    public partial class ExamRegistration
    {
        public ExamRegistration()
        {
            ExamRegistrationError = new HashSet<ExamRegistrationError>();
            Rescheduling = new HashSet<Rescheduling>();
            Report = new HashSet<Report>();
        }

        public int Id { get; set; }

        public int? RegistrationId { get; set; }

        public int? ExamId { get; set; }

        public int? ExamTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExamRegistrationDate { get; set; }

        public int? ExamCenterId { get; set; }

        public int? ExamWayOfTakingId { get; set; }

        public int? LanguageId { get; set; }

        [StringLength(50)]
        public string Place { get; set; }

        public double? Price { get; set; }

        public double? Tax { get; set; }

        public int? UseVehicle { get; set; }

        public double? MaterialCosts { get; set; }

        public double? PDVAmount { get; set; }

        public double? PDVVehicle { get; set; }

        public double? PDVTest { get; set; }

        [StringLength(50)]
        public string Result { get; set; }

        public int? StatusId { get; set; }

        public virtual Examination Examination { get; set; }

        public virtual ExamLanguage ExamLanguage { get; set; }

        public virtual ICollection<ExamRegistrationError> ExamRegistrationError { get; set; }

        public virtual ICollection<Rescheduling> Rescheduling { get; set; }

        public virtual Registration Registration { get; set; }

        public virtual ExamRegistrationStatus ExamRegistrationStatus { get; set; }

        public virtual ExamWayOfTaking ExamWayOfTaking { get; set; }

        public virtual ICollection<Report> Report { get; set; }
    }
}
