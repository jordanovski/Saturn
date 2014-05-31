namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RequiredDocument")]
    public partial class RequiredDocument
    {
        public RequiredDocument()
        {
            ReqDocCandidate = new HashSet<ReqDocCandidate>();
            ReqDocDrivingCategory = new HashSet<ReqDocDrivingCategory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string ReqDocument { get; set; }

        public virtual ICollection<ReqDocCandidate> ReqDocCandidate { get; set; }

        public virtual ICollection<ReqDocDrivingCategory> ReqDocDrivingCategory { get; set; }
    }
}
