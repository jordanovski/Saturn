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

        [Display(Name = "���")]
        [Required(ErrorMessage = "��� ���� � ������������.")]
        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Type { get; set; }

        public virtual ICollection<ContactPerson> ContactPerson { get; set; }
    }
}
