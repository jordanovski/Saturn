namespace Saturn.Model.Codebooks
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "���� �����")]
        public int? DrivingSchoolId { get; set; }

        [Display(Name = "���")]
        public int? VehicleTypeId { get; set; }

        [Display(Name = "������������")]
        public int? VehicleBrandId { get; set; }

        [Display(Name = "�����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string CommercialMark { get; set; }

        [Display(Name = "����������� ���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "�������")]
        public bool IsActive { get; set; }

        public virtual VehicleBrand VehicleBrand { get; set; }

        public virtual VehicleType VehicleType { get; set; }
    }
}
