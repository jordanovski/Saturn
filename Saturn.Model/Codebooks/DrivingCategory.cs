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

        [Display(Name = "Категорија")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Category { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Display(Name = "Теорија нег. поени")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public int AllowedNegativeTheory { get; set; }

        [Display(Name = "Полигон нег. поени")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public int AllowedNegativePolygon { get; set; }

        [Display(Name = "Град нег. поени")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public int AllowedNegativePracticle { get; set; }

        [Display(Name = "Опис")]
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
