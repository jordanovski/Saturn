namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DrivingSchool")]
    public partial class DrivingSchool
    {
        public DrivingSchool()
        {
            ContactPerson = new HashSet<ContactPerson>();
            Instructor = new HashSet<Instructor>();
        }

        public int Id { get; set; }

        [Display(Name = "����")]
        public int? CityId { get; set; }

        [Display(Name = "���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public string Name { get; set; }

        [Display(Name = "������� ���")]
        [StringLength(13, ErrorMessage = "��������� �� ���� �� ���� �������� �� 13 ���������.")]
        public string TaxNumber { get; set; }

        [Display(Name = "������")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Address { get; set; }

        [Display(Name = "���������")]
        public string Note { get; set; }

        [Display(Name = "�������")]
        public bool IsActive { get; set; }


        public virtual City City { get; set; }
        public virtual ICollection<ContactPerson> ContactPerson { get; set; }
        public virtual ICollection<Instructor> Instructor { get; set; }
    }
}
