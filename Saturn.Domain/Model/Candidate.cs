using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("Candidate")]
    public partial class Candidate
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [StringLength(50)]
        public string PersonalCardNumber { get; set; }

        [StringLength(50)]
        public string IssuedBy { get; set; }

        [StringLength(13)]
        public string UniqueNumber { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int? CityId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(50)]
        public string BirthPlace { get; set; }

        [StringLength(50)]
        public string Profession { get; set; }

        public string Note { get; set; }

        public int? DrivingCategoryId { get; set; }

        [StringLength(50)]
        public string ExistingDrivingCategory { get; set; }

        [StringLength(50)]
        public string DossierNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DossierDate { get; set; }

        public virtual City City { get; set; }

        public virtual DrivingCategory DrivingCategory { get; set; }
    }
}
