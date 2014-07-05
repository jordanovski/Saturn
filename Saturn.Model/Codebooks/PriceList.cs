namespace Saturn.Model.Codebooks
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PriceList")]
    public partial class PriceList
    {
        public int Id { get; set; }

        [Display(Name = "Кат.")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public int DrivingCategoryId { get; set; }

        [Display(Name = "Тип испит")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public int ExamTypeId { get; set; }

        [Display(Name = "Цена прв пат")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public double PriceFirst { get; set; }

        [Display(Name = "Такса прв пат")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public double TaxFirst { get; set; }

        [Display(Name = "Цена пов.")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public double PriceRepeated { get; set; }

        [Display(Name = "Такса пов.")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public double TaxRepeated { get; set; }

        [Display(Name = "Цена тест")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public double MaterialCosts { get; set; }

        [Display(Name = "ДДВ")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public double VAT { get; set; }

        [Display(Name = "Забелешка")]
        public string Note { get; set; }


        public virtual DrivingCategory DrivingCategory { get; set; }

        public virtual ExamType ExamType { get; set; }
    }
}
