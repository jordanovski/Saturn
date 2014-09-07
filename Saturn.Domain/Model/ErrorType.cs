using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("ErrorType")]
    public partial class ErrorType
    {
        public ErrorType()
        {
            ExamRegistrationError = new HashSet<ExamRegistrationError>();
        }

        public int Id { get; set; }

        [StringLength(10)]
        public string Form { get; set; }

        [StringLength(10)]
        public string Question { get; set; }

        public string Description { get; set; }

        public int? PenaltyPoints { get; set; }

        [StringLength(50)]
        public string DrivingCategory { get; set; }

        public int? ExamTypeId { get; set; }

        public virtual ExamType ExamType { get; set; }

        public virtual ICollection<ExamRegistrationError> ExamRegistrationError { get; set; }
    }
}
