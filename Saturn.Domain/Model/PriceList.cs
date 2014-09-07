using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("PriceList")]
    public partial class PriceList
    {
        public int Id { get; set; }

        public int DrivingCategoryId { get; set; }

        public int ExamTypeId { get; set; }

        public double PriceFirst { get; set; }

        public double TaxFirst { get; set; }

        public double PriceRepeated { get; set; }

        public double TaxRepeated { get; set; }

        public double MaterialCosts { get; set; }

        public double VAT { get; set; }

        public string Note { get; set; }

        public virtual DrivingCategory DrivingCategory { get; set; }

        public virtual ExamType ExamType { get; set; }
    }
}
