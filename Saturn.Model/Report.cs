namespace Saturn.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Report")]
    public partial class Report
    {
        public int Id { get; set; }

        public int ExamRegistrationId { get; set; }

        public double? NegativePoints { get; set; }

        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string TestNumber { get; set; }

        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string Status { get; set; }

        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string CreatedBy { get; set; }

        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string ChangedBy { get; set; }


        public virtual ExamRegistration ExamRegistration { get; set; }
    }
}
