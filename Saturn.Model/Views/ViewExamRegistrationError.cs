namespace Saturn.Model.Views
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ViewExamRegistrationError")]
    public partial class ViewExamRegistrationError
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExamRegistrationId { get; set; }

        public int? RegistrationId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ErrorTypeId { get; set; }

        [StringLength(10)]
        public string Form { get; set; }

        [StringLength(10)]
        public string Question { get; set; }

        public string Description { get; set; }

        public int? PenaltyPoints { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExamRegistrationErrorId { get; set; }
    }
}
