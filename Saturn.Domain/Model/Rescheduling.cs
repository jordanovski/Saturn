using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("Rescheduling")]
    public partial class Rescheduling
    {
        public int Id { get; set; }

        public int ExamRegistrationId { get; set; }

        public int ExamIdOld { get; set; }

        public int ExamIdNew { get; set; }

        [Required]
        [StringLength(50)]
        public string UserNameCreated { get; set; }

        public DateTime? DateTimeCreated { get; set; }

        public virtual ExamRegistration ExamRegistration { get; set; }
    }
}
