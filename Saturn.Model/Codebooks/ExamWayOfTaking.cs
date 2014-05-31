namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ExamWayOfTaking")]
    public partial class ExamWayOfTaking
    {
        public ExamWayOfTaking()
        {
            ExamRegistration = new HashSet<ExamRegistration>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string WayOfTaking { get; set; }

        [Required]
        [StringLength(50)]
        public string WayOfTakingCode { get; set; }

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }
    }
}
