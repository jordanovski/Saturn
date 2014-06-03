using Saturn.Model.Codebooks;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Saturn.Model.ViewModels
{
    public class PriceListViewModel
    {
        public static Expression<Func<PriceList, PriceListViewModel>> FromPriceLists
        {
            get
            {
                return s => new PriceListViewModel
                {
                    Id = s.Id,
                    DrivingCategory = s.DrivingCategory.Category,
                    ExaminationType = s.ExamType.Type,
                    PriceFirst = s.PriceFirst,
                    TaxFirst = s.TaxFirst,
                    PriceRepeated = s.PriceRepeated,
                    TaxRepeated = s.TaxRepeated,
                    MaterialCosts = s.MaterialCosts,
                    VAT = s.VAT,
                    Note = s.Note
                };
            }
        }

        public int Id { get; set; }

        [Display(Name = "Кат.")]
        public string DrivingCategory { get; set; }

        [Display(Name = "Тип испит")]
        public string ExaminationType { get; set; }

        [Display(Name = "Цена прв пат")]
        public double PriceFirst { get; set; }

        [Display(Name = "Такса прв пат")]
        public double TaxFirst { get; set; }

        [Display(Name = "Цена пов.")]
        public double PriceRepeated { get; set; }

        [Display(Name = "Такса пов.")]
        public double TaxRepeated { get; set; }

        [Display(Name = "Цена тест")]
        public double MaterialCosts { get; set; }

        [Display(Name = "ДДВ")]
        public double VAT { get; set; }

        [Display(Name = "Забелешка")]
        public string Note { get; set; }
    }
}
