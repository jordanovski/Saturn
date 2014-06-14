namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ExamType")]
    public partial class ExamType
    {
        public ExamType()
        {
            ErrorType = new HashSet<ErrorType>();
            Examination = new HashSet<Examination>();
            PriceList = new HashSet<PriceList>();
        }

        public int Id { get; set; }

        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Type { get; set; }

        public virtual ICollection<ErrorType> ErrorType { get; set; }

        public virtual ICollection<Examination> Examination { get; set; }

        public virtual ICollection<PriceList> PriceList { get; set; }
    }
}
