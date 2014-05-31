namespace Saturn.Model
{
    using Saturn.Model.Codebooks;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ReqDocCandidate")]
    public partial class ReqDocCandidate
    {
        public int Id { get; set; }

        public int ReqDocumentId { get; set; }

        public int CandidateId { get; set; }

        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string DocumentNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IssueDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ValidTo { get; set; }

        [StringLength(255, ErrorMessage = "Вредноста не може да биде поголема од 255 катактери.")]
        public string Note { get; set; }


        public virtual RequiredDocument RequiredDocument { get; set; }
    }
}
