namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Examiner")]
    public partial class Examiner
    {
        public Examiner()
        {
            Examination = new HashSet<Examination>();
            Examination1 = new HashSet<Examination>();
            Examination2 = new HashSet<Examination>();
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

        [Display(Name = "�����������")]
        public bool President { get; set; }

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


        public virtual ICollection<Examination> Examination { get; set; }

        public virtual ICollection<Examination> Examination1 { get; set; }

        public virtual ICollection<Examination> Examination2 { get; set; }
    }
}
