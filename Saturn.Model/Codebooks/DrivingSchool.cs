namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DrivingSchool")]
    public partial class DrivingSchool
    {
        public DrivingSchool()
        {
            ContactPerson = new HashSet<ContactPerson>();
            Instructor = new HashSet<Instructor>();
        }

        public int Id { get; set; }

        [Display(Name = "Град")]
        public int? CityId { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public string Name { get; set; }

        [Display(Name = "Даночен број")]
        [StringLength(13, ErrorMessage = "Вредноста не може да биде поголема од 13 катактери.")]
        public string TaxNumber { get; set; }

        [Display(Name = "Адреса")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Address { get; set; }

        [Display(Name = "Забелешка")]
        public string Note { get; set; }

        [Display(Name = "Активна")]
        public bool IsActive { get; set; }


        public virtual City City { get; set; }
        public virtual ICollection<ContactPerson> ContactPerson { get; set; }
        public virtual ICollection<Instructor> Instructor { get; set; }
    }
}
