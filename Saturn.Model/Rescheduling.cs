namespace Saturn.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Rescheduling")]
    public partial class Rescheduling
    {
        public int Id { get; set; }

        public int ExamRegistrationId { get; set; }

        public int ExamIdOld { get; set; }

        public int ExamIdNew { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string ChangedBy { get; set; }

        public DateTime? ChangedOn { get; set; }



        public virtual ExamRegistration ExamRegistration { get; set; }
    }
}
