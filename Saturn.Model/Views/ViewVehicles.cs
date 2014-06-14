namespace Saturn.Model.Views
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ViewVehicles
    {
        [Key]
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
        public int VehicleBrandId { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleCommercialMark { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public bool? VehicleIsActive { get; set; }
        public int? DrivingSchoolId { get; set; }
        public string DrivingSchoolName { get; set; }
        public bool? DrivingSchoolIsActive { get; set; }
        public string DrivingSchoolTaxNumber { get; set; }
        public string DrivingSchoolAddress { get; set; }
        public string DrivingSchoolNote { get; set; }
        public int? DrivingSchoolCityId { get; set; }
        public string DrivingSchoolCityName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return VehicleBrand + " " + VehicleCommercialMark + " / " + VehicleRegistrationNumber; }
            private set { }
        }
    }
}
