namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Examiner")]
    public partial class Examiner
    {
        public Examiner()
        {
            Examination = new HashSet<Examination>();
            Examination1 = new HashSet<Examination>();
            Examination2 = new HashSet<Examination>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public bool President { get; set; }

        public bool Practice { get; set; }

        public bool Theory { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return LastName + " " + FirstName; }
            private set { }
        }


        public virtual ICollection<Examination> Examination { get; set; }

        public virtual ICollection<Examination> Examination1 { get; set; }

        public virtual ICollection<Examination> Examination2 { get; set; }
    }
}
