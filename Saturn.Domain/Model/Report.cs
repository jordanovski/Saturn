using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("Report")]
    public partial class Report
    {
        public int Id { get; set; }

        public int ExamRegistrationId { get; set; }

        public double? NegativePoints { get; set; }

        [StringLength(10)]
        public string TestNumber { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(50)]
        public string UserNameCreated { get; set; }

        public virtual ExamRegistration ExamRegistration { get; set; }
    }
}
