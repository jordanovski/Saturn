namespace Saturn.Model.Views
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ViewExamCandidates
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CandidateId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegistrationId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExamRegistrationId { get; set; }

        public int? ExamId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string FatherName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string DossierNumber { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Category { get; set; }

        public double? NegativePoints { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string ExamType { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "date")]
        public DateTime ExamDate { get; set; }

        [Key]
        [Column(Order = 8)]
        public TimeSpan ExamTime { get; set; }

        [StringLength(50)]
        public string WayOfTaking { get; set; }

        [StringLength(50)]
        public string Language { get; set; }
    }
}
