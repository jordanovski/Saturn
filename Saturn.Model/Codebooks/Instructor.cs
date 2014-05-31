namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Instructor")]
    public partial class Instructor
    {
        public Instructor()
        {
            Registration = new HashSet<Registration>();
            Registration1 = new HashSet<Registration>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(13)]
        public string UniqueNumber { get; set; }

        public int DrivingSchoolId { get; set; }

        public bool Practice { get; set; }

        public bool Theory { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return LastName + " " + FirstName; }
            private set { }
        }

        public virtual DrivingSchool DrivingSchool { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }

        public virtual ICollection<Registration> Registration1 { get; set; }
    }
}
