using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("Examination")]
    public partial class Examination
    {
        public Examination()
        {
            ExamRegistration = new HashSet<ExamRegistration>();
        }

        public int Id { get; set; }

        public int ExamCenterId { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExamDate { get; set; }

        public TimeSpan ExamTime { get; set; }

        public int? ExamTypeId { get; set; }

        public int? PresidentId { get; set; }

        public int? ExaminerId { get; set; }

        public int? MemberId { get; set; }

        public virtual ExamCenters ExamCenters { get; set; }

        public virtual ICollection<ExamRegistration> ExamRegistration { get; set; }

        public virtual ExamType ExamType { get; set; }

        public virtual Examiner Examiner { get; set; }

        public virtual Examiner Examiner1 { get; set; }

        public virtual Examiner Examiner2 { get; set; }
    }
}
