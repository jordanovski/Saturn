namespace Saturn.Model
{
    using Saturn.Model.Codebooks;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Candidate")]
    public partial class Candidate
    {
        public int Id { get; set; }

        [Display(Name = "���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string FirstName { get; set; }

        [Display(Name = "�������")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string LastName { get; set; }

        [Display(Name = "������� ���")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string FatherName { get; set; }

        [Display(Name = "��. ��")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string PersonalCardNumber { get; set; }

        [Display(Name = "�� �������� ��")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string IssuedBy { get; set; }

        [Display(Name = "����")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string UniqueNumber { get; set; }

        [Display(Name = "������")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Address { get; set; }

        [Display(Name = "����")]
        public int? CityId { get; set; }

        [Display(Name = "����� �� ������")]
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "����� �� ������")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string BirthPlace { get; set; }

        [Display(Name = "��������")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Profession { get; set; }

        [Display(Name = "���������")]
        public string Note { get; set; }

        [Display(Name = "������ ��")]
        public int? DrivingCategoryId { get; set; }

        [Display(Name = "�������� ���������")]   
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string ExistingDrivingCategory { get; set; }

        [Display(Name = "��. �����")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string DossierNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DossierDate { get; set; }

        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string CreatedBy { get; set; }

        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string ChangedBy { get; set; }


        public virtual City City { get; set; }

        public virtual DrivingCategory DrivingCategory { get; set; }
    }
}
