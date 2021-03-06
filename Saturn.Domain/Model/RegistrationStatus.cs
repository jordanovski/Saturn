using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saturn.Domain.Model
{
    public partial class RegistrationStatus
    {
        public RegistrationStatus()
        {
            Registration = new HashSet<Registration>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
