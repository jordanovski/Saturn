using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Model
{
    [Table("Examination")]
    public partial class Examination
    {
        public Examination()
        {
            ExamRegistration = new HashSet<ExamRegistration>();
        }

        public int Id { get; set; }

        [Display(Name = "Испитен центар")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public int ExamCenterId { get; set; }

        [Display(Name = "Датум")]
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public DateTime ExamDate { get; set; }

        [Display(Name = "Време")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public TimeSpan ExamTime { get; set; }

        [Display(Name = "Тип на испит")]
        public int? ExamTypeId { get; set; }

        [Display(Name = "Претседател")]
        public int? PresidentId { get; set; }

        [Display(Name = "Испитувач")]
        public int? ExaminerId { get; set; }

        [Display(Name = "Член")]
        public int? MemberId { get; set; }

        public virtual ExamCenters ExamCenters { get; set; }

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }

        public virtual ExamType ExamType { get; set; }

        public virtual Examiner Examiner { get; set; }

        public virtual Examiner Examiner1 { get; set; }

        public virtual Examiner Examiner2 { get; set; }
    }
}
