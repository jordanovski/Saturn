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

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string LastName { get; set; }

        [Display(Name = "Претседател")]
        public bool President { get; set; }

        [Display(Name = "Пракса")]
        public bool Practice { get; set; }

        [Display(Name = "Теорија")]
        public bool Theory { get; set; }

        [Display(Name = "Активен")]
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
