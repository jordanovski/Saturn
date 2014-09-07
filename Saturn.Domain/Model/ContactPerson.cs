using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("ContactPerson")]
    public partial class ContactPerson
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int DrivingSchoolId { get; set; }

        public int ContactTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactValue { get; set; }

        public virtual ContactType ContactType { get; set; }

        public virtual DrivingSchool DrivingSchool { get; set; }
    }
}
