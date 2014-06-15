namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DrivingCategory")]
    public partial class DrivingCategory
    {
        public DrivingCategory()
        {
            Candidate = new HashSet<Candidate>();
            PriceList = new HashSet<PriceList>();
            ReqDocDrivingCategory = new HashSet<ReqDocDrivingCategory>();
        }

        public int Id { get; set; }

        [Display(Name = "���������")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Category { get; set; }

        [Display(Name = "����")]
        public string Description { get; set; }

        [Display(Name = "������ ���. �����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public int AllowedNegativeTheory { get; set; }

        [Display(Name = "������� ���. �����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public int AllowedNegativePolygon { get; set; }

        [Display(Name = "���� ���. �����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public int AllowedNegativePracticle { get; set; }

        [Display(Name = "����")]
        [NotMapped]
        public string DescriptionShort
        {
            get
            {
                if (Description.Length > 30)
                {
                    return Description.Substring(0, 30) + "...";
                }
                else
                {
                    return Description;
                }
            }
            private set { }
        }

        public virtual ICollection<Candidate> Candidate { get; set; }

        public virtual ICollection<PriceList> PriceList { get; set; }

        public virtual ICollection<ReqDocDrivingCategory> ReqDocDrivingCategory { get; set; }
    }
}
