namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DrivingCategory")]
    public partial class DrivingCategory
    {
        public DrivingCategory()
        {
            Candidate = new HashSet<Candidate>();
            PriceList = new HashSet<PriceList>();
            ReqDocDrivingCategory = new HashSet<ReqDocDrivingCategory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        public string Description { get; set; }

        public int AllowedNegativeTheory { get; set; }

        public int AllowedNegativePolygon { get; set; }

        public int AllowedNegativePracticle { get; set; }

        [Display(Name = "Опис")]
        [NotMapped]
        public string DescriptionShort
        {
            get
            {
                if (Description.Length > 80)
                {
                    return Description.Substring(0, 80) + "...";
                }
                else
                {
                    return Description;
                }
            }
            private set { }
        }

        public virtual ICollection<Candidate> Candidate { get; set; }

        public virtual ICollection<PriceList> PriceList { get; set; }

        public virtual ICollection<ReqDocDrivingCategory> ReqDocDrivingCategory { get; set; }
    }
}
