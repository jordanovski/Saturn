namespace Saturn.Model.Codebooks
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PriceList")]
    public partial class PriceList
    {
        public int Id { get; set; }

        [Display(Name = "���.")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public int DrivingCategoryId { get; set; }

        [Display(Name = "��� �����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public int ExamTypeId { get; set; }

        [Display(Name = "���� ��� ���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public double PriceFirst { get; set; }

        [Display(Name = "����� ��� ���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public double TaxFirst { get; set; }

        [Display(Name = "���� ���.")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public double PriceRepeated { get; set; }

        [Display(Name = "����� ���.")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public double TaxRepeated { get; set; }

        [Display(Name = "���� ����")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public double MaterialCosts { get; set; }

        [Display(Name = "���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        public double VAT { get; set; }

        [Display(Name = "���������")]
        public string Note { get; set; }


        public virtual DrivingCategory DrivingCategory { get; set; }

        public virtual ExamType ExamType { get; set; }
    }
}
