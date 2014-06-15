namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ErrorType")]
    public partial class ErrorType
    {
        public ErrorType()
        {
            ExamRegistrationError = new HashSet<ExamRegistrationError>();
        }

        public int Id { get; set; }

        [Display(Name = "�����")]
        [StringLength(10, ErrorMessage = "��������� �� ���� �� ���� �������� �� 10 ���������.")]
        public string Form { get; set; }

        [Display(Name = "�������")]
        [StringLength(10, ErrorMessage = "��������� �� ���� �� ���� �������� �� 10 ���������.")]
        public string Question { get; set; }

        [Display(Name = "����")]
        public string Description { get; set; }

        [Display(Name = "��������� �����")]
        public int? PenaltyPoints { get; set; }

        [Display(Name = "���������")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string DrivingCategory { get; set; }

        [Display(Name = "��� �� �����")]
        public int? ExamTypeId { get; set; }

        public virtual ExamType ExamType { get; set; }

        public virtual ICollection<ExamRegistrationError> ExamRegistrationError { get; set; }
    }
}
