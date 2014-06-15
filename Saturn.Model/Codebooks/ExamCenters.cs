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

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Name { get; set; }

        [Display(Name = "Даночен број")]
        [StringLength(13, ErrorMessage = "Вредноста не може да биде поголема од 13 катактери.")]
        public string TaxNumber { get; set; }

        [Display(Name = "Адреса")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Address { get; set; }

        [Display(Name = "Град")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public int CityId { get; set; }


        public virtual City City { get; set; }

        public virtual ICollection<Examination> Examination { get; set; }
    }
}
