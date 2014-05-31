namespace Saturn.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Saturn.Model.Codebooks;
    using System.ComponentModel.DataAnnotations;

    [Table("ExamRegistrationError")]
    public partial class ExamRegistrationError
    {
        public int Id { get; set; }

        public int ExamRegistrationId { get; set; }

        public int ErrorTypeId { get; set; }

        public int Quantity { get; set; }


        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string CreatedBy { get; set; }

        [StringLength(50, ErrorMessage = "��������� �� ���� �� ���� �������� �� 50 ���������.")]
        public string ChangedBy { get; set; }


        public virtual ErrorType ErrorType { get; set; }

        public virtual ExamRegistration ExamRegistration { get; set; }
    }
}
