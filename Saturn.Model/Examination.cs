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

        [Display(Name = "������� ������")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public int ExamCenterId { get; set; }

        [Display(Name = "�����")]
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public DateTime ExamDate { get; set; }

        [Display(Name = "�����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public TimeSpan ExamTime { get; set; }

        [Display(Name = "��� �� �����")]
        public int? ExamTypeId { get; set; }

        [Display(Name = "�����������")]
        public int? PresidentId { get; set; }

        [Display(Name = "���������")]
        public int? ExaminerId { get; set; }

        [Display(Name = "����")]
        public int? MemberId { get; set; }

        public virtual ExamCenters ExamCenters { get; set; }

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }

        public virtual ExamType ExamType { get; set; }

        public virtual Examiner Examiner { get; set; }

        public virtual Examiner Examiner1 { get; set; }

        public virtual Examiner Examiner2 { get; set; }
    }
}
