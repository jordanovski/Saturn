namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VehicleBrand")]
    public partial class VehicleBrand
    {
        public VehicleBrand()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }

        [Display(Name = "�����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Brand { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
