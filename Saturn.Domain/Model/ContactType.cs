using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("ContactType")]
    public partial class ContactType
    {
        public ContactType()
        {
            ContactPerson = new HashSet<ContactPerson>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public virtual ICollection<ContactPerson> ContactPerson { get; set; }
    }
}
