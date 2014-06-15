namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ExamCenters
    {
        public ExamCenters()
        {
            Examination = new HashSet<Examination>();
        }

        public int Id { get; set; }

        [Display(Name = "���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Name { get; set; }

        [Display(Name = "������� ���")]
        [StringLength(13, ErrorMessage = "��������� �� ���� �� ���� �������� �� 13 ���������.")]
        public string TaxNumber { get; set; }

        [Display(Name = "������")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Address { get; set; }

        [Display(Name = "����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public int CityId { get; set; }


        public virtual City City { get; set; }

        public virtual ICollection<Examination> Examination { get; set; }
    }
}
