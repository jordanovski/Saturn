namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ExamCenters
    {
        public ExamCenters()
        {
            Examination = new HashSet<Examination>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(13)]
        public string TaxNumber { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Examination> Examination { get; set; }
    }
}
