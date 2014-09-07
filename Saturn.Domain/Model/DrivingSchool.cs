using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("DrivingSchool")]
    public partial class DrivingSchool
    {
        public DrivingSchool()
        {
            ContactPerson = new HashSet<ContactPerson>();
            Instructor = new HashSet<Instructor>();
        }

        public int Id { get; set; }

        public int? CityId { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(13)]
        public string TaxNumber { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public string Note { get; set; }

        public bool IsActive { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<ContactPerson> ContactPerson { get; set; }

        public virtual ICollection<Instructor> Instructor { get; set; }
    }
}
