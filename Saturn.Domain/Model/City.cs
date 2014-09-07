using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain.Model
{
    [Table("City")]
    public partial class City
    {
        public City()
        {
            Candidate = new HashSet<Candidate>();
            DrivingSchool = new HashSet<DrivingSchool>();
            ExamCenters = new HashSet<ExamCenters>();
        }

        public int Id { get; set; }

        [Display(Name = "Град")]
        [Required(ErrorMessage = "Ова поле е задолжително.")]
        [StringLength(50, ErrorMessage = "Вредноста не може да биде поголема од 50 катактери.")]
        public string Name { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }

        public virtual ICollection<DrivingSchool> DrivingSchool { get; set; }

        public virtual ICollection<ExamCenters> ExamCenters { get; set; }
    }
}
