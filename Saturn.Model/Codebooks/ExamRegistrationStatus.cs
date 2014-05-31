namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ExamRegistrationStatus
    {
        public ExamRegistrationStatus()
        {
            ExamRegistration = new HashSet<ExamRegistration>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }
    }
}
