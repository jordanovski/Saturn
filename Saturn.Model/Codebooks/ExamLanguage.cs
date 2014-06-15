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

        [Display(Name = "Јазик")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Language { get; set; }

        [Display(Name = "Код")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(10, ErrorMessage = "Вредноста не може да биде поголема од 10 катактери.")]
        public string LanguageCode { get; set; }

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }
    }
}
