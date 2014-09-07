using Saturn.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Saturn.Shared.ViewModels
{
    public class VehicleViewModel
    {
        public static Expression<Func<Vehicle, VehicleViewModel>> FromVehicle
        {
            get
            {
                return c => new VehicleViewModel
                {
                    Id = c.Id,
                    VehicleTypeId = c.VehicleTypeId,
                    VehicleType = c.VehicleType.Type,
                    VehicleBrandId = c.VehicleBrandId,
                    VehicleBrand = c.VehicleBrand.Brand,
                    CommercialMark = c.CommercialMark,
                    RegistrationNumber = c.RegistrationNumber,
                    VehicleIsActive = c.IsActive,
                    DrivingSchoolId = c.DrivingSchoolId
                };
            }
        }

        public int Id { get; set; }

        public int? VehicleTypeId { get; set; }

        [Display(Name = "Тип")]
        public string VehicleType { get; set; }

        public int? VehicleBrandId { get; set; }

        [Display(Name = "Производител")]
        public string VehicleBrand { get; set; }

        [Display(Name = "Модел")]
        public string CommercialMark { get; set; }

        [Display(Name = "Регистарски број")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Активно")]
        public bool? VehicleIsActive { get; set; }

        public int? DrivingSchoolId { get; set; }

        [Display(Name = "Авто школа")]
        public string DrivingSchool { get; set; }

        public bool? DrivingSchoolIsActive { get; set; }

    }
}
