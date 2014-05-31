namespace Saturn.Model.Codebooks
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("ContactPerson")]
    public partial class ContactPerson
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Name { get; set; }

        public int DrivingSchoolId { get; set; }

        [Display(Name = "Контакт")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        public int ContactTypeId { get; set; }

        [Display(Name = "Вредност")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string ContactValue { get; set; }

        public virtual ContactType ContactType { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
