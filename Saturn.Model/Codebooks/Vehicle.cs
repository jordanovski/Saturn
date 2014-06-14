namespace Saturn.Model.Codebooks
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "Авто школа")]
        public int? DrivingSchoolId { get; set; }

        [Display(Name = "Тип")]
        public int? VehicleTypeId { get; set; }

        [Display(Name = "Производител")]
        public int? VehicleBrandId { get; set; }

        [Display(Name = "Модел")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string CommercialMark { get; set; }

        [Display(Name = "Регистарски број")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Активно")]
        public bool IsActive { get; set; }

        public virtual VehicleBrand VehicleBrand { get; set; }

        public virtual VehicleType VehicleType { get; set; }
    }
}
