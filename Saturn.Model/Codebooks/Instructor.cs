namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Instructor")]
    public partial class Instructor
    {
        public Instructor()
        {
            Registration = new HashSet<Registration>();
            Registration1 = new HashSet<Registration>();
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

        [Display(Name = "Матичен број")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(13, ErrorMessage = "Вредноста не може да биде поголема од 13 катактери.")]
        public string UniqueNumber { get; set; }

        [Display(Name = "Авто школа")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public int DrivingSchoolId { get; set; }

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
       

        public virtual DrivingSchool DrivingSchool { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }

        public virtual ICollection<Registration> Registration1 { get; set; }
    }
}
