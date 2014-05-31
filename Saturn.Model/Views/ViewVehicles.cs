namespace Saturn.Model.Views
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ViewVehicles
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VehicleTypeId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string VehicleType { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VehicleBrandId { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string VehicleBrand { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string CommercialMark { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        public bool? VehicleIsActive { get; set; }

        public int? DrivingSchoolId { get; set; }

        public string DrivingSchool { get; set; }

        public bool? DrivingSchoolIsActive { get; set; }



        [NotMapped]
        public string FullName
        {
            get { return VehicleBrand + " " + CommercialMark + " / " + RegistrationNumber; }
            private set { }
        }
    }
}
