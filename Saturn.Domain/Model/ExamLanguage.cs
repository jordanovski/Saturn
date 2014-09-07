using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("ExamLanguage")]
    public partial class ExamLanguage
    {
        public ExamLanguage()
        {
            ExamRegistration = new HashSet<ExamRegistration>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; }

        [Required]
        [StringLength(10)]
        public string LanguageCode { get; set; }

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }
    }
}
