using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("VehicleBrand")]
    public partial class VehicleBrand
    {
        public VehicleBrand()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
