namespace Saturn.Model.Codebooks
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        public int Id { get; set; }

        public int? DrivingSchoolId { get; set; }

        public int? VehicleTypeId { get; set; }

        public int? VehicleBrandId { get; set; }

        [Required]
        [StringLength(50)]
        public string CommercialMark { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        public bool IsActive { get; set; }

        public virtual VehicleBrand VehicleBrand { get; set; }

        public virtual VehicleType VehicleType { get; set; }
    }
}
