using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("ReqDocCandidate")]
    public partial class ReqDocCandidate
    {
        public int Id { get; set; }

        public int ReqDocumentId { get; set; }

        public int CandidateId { get; set; }

        [StringLength(50)]
        public string DocumentNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IssueDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ValidTo { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public virtual RequiredDocument RequiredDocument { get; set; }
    }
}
