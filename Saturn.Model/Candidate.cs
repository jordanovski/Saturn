namespace Saturn.Model
{
    using Saturn.Model.Codebooks;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Candidate")]
    public partial class Candidate
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string LastName { get; set; }

        [Display(Name = "Татково име")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string FatherName { get; set; }

        [Display(Name = "Бр. Лк")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string PersonalCardNumber { get; set; }

        [Display(Name = "Лк издадена од")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string IssuedBy { get; set; }

        [Display(Name = "ЕМБГ")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string UniqueNumber { get; set; }

        [Display(Name = "Адреса")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Address { get; set; }

        [Display(Name = "Град")]
        public int? CityId { get; set; }

        [Display(Name = "Датум на раѓање")]
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Место на раѓање")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string BirthPlace { get; set; }

        [Display(Name = "Занимање")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Profession { get; set; }

        [Display(Name = "Забелешка")]
        public string Note { get; set; }

        [Display(Name = "Полага за")]
        public int? DrivingCategoryId { get; set; }

        [Display(Name = "Поседува категорија")]   
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string ExistingDrivingCategory { get; set; }

        [Display(Name = "Бр. досие")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string DossierNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DossierDate { get; set; }

        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string CreatedBy { get; set; }

        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string ChangedBy { get; set; }


        public virtual City City { get; set; }

        public virtual DrivingCategory DrivingCategory { get; set; }
    }
}
