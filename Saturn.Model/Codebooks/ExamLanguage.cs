namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExamLanguage")]
    public partial class ExamLanguage
    {
        public ExamLanguage()
        {
            ExamRegistration = new HashSet<ExamRegistration>();
        }

        public int Id { get; set; }

        [Display(Name = "�����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Language { get; set; }

        [Display(Name = "���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(10, ErrorMessage = "��������� �� ���� �� ���� �������� �� 10 ���������.")]
        public string LanguageCode { get; set; }

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }
    }
}
