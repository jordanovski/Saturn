using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("ExamRegistrationError")]
    public partial class ExamRegistrationError
    {
        public int Id { get; set; }

        public int ExamRegistrationId { get; set; }

        public int ErrorTypeId { get; set; }

        public int Quantity { get; set; }

        public virtual ErrorType ErrorType { get; set; }

        public virtual ExamRegistration ExamRegistration { get; set; }
    }
}
