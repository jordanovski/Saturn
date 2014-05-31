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

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public virtual ICollection<ErrorType> ErrorType { get; set; }

        public virtual ICollection<Examination> Examination { get; set; }

        public virtual ICollection<PriceList> PriceList { get; set; }
    }
}
