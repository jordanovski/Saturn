namespace Saturn.Model.Codebooks
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("ContactPerson")]
    public partial class ContactPerson
    {
        public int Id { get; set; }

        [Display(Name = "���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Name { get; set; }

        public int DrivingSchoolId { get; set; }

        [Display(Name = "�������")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public int ContactTypeId { get; set; }

        [Display(Name = "��������")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string ContactValue { get; set; }

        public virtual ContactType ContactType { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
