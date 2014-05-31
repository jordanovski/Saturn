namespace Saturn.Model.Views
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ViewCandidates
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CandidateId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 2)]
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

        [StringLength(50)]
        public string City { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [StringLength(50)]
        public string BirthPlace { get; set; }

        [StringLength(50)]
        public string Profession { get; set; }

        public string Note { get; set; }

        public int? DrivingCategoryId { get; set; }

        [StringLength(50)]
        public string DrivingCategory { get; set; }

        [StringLength(50)]
        public string DossierNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DossierDate { get; set; }

        [StringLength(50)]
        public string ExistingDrivingCategory { get; set; }
    }
}
