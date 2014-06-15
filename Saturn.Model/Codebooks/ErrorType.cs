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

        [Display(Name = "Форма")]
        [StringLength(10, ErrorMessage = "Вредноста не може да биде поголема од 10 катактери.")]
        public string Form { get; set; }

        [Display(Name = "Прашање")]
        [StringLength(10, ErrorMessage = "Вредноста не може да биде поголема од 10 катактери.")]
        public string Question { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Негативни поени")]
        public int? PenaltyPoints { get; set; }

        [Display(Name = "Категорија")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string DrivingCategory { get; set; }

        [Display(Name = "Тип на испит")]
        public int? ExamTypeId { get; set; }

        public virtual ExamType ExamType { get; set; }

        public virtual ICollection<ExamRegistrationError> ExamRegistrationError { get; set; }
    }
}
