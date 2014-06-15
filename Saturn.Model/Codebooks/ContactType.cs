namespace Saturn.Model.Codebooks
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ContactType")]
    public partial class ContactType
    {
        public ContactType()
        {
            ContactPerson = new HashSet<ContactPerson>();
        }

        public int Id { get; set; }

        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Type { get; set; }

        public virtual ICollection<ContactPerson> ContactPerson { get; set; }
    }
}
