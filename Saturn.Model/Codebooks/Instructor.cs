namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Instructor")]
    public partial class Instructor
    {
        public Instructor()
        {
            Registration = new HashSet<Registration>();
            Registration1 = new HashSet<Registration>();
        }

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
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(13, ErrorMessage = "��������� �� ���� �� ���� �������� �� 13 ���������.")]
        public string UniqueNumber { get; set; }

        [Display(Name = "���� �����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public int DrivingSchoolId { get; set; }

        [Display(Name = "������")]
        public bool Practice { get; set; }

        [Display(Name = "������")]
        public bool Theory { get; set; }

        [Display(Name = "�������")]
        public bool IsActive { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return LastName + " " + FirstName; }
            private set { }
        }
       

        public virtual DrivingSchool DrivingSchool { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }

        public virtual ICollection<Registration> Registration1 { get; set; }
    }
}
