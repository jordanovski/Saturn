namespace Saturn.Model.Views
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ViewExaminations
    {
        [Key]
        public int ExaminationId { get; set; }

        [Display(Name = "��� �� �����")]
        public string ExamType { get; set; }

        [Display(Name = "�������")]
        public string ExamCenter { get; set; }

        [Display(Name = "�����������")]
        public string PresidentName { get; set; }

        [Display(Name = "���������")]
        public string ExaminerName { get; set; }

        [Display(Name = "����")]
        public string MemberName { get; set; }



        public int? ExamTypeId { get; set; }

        public int ExamCenterId { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExamDate { get; set; }

        public TimeSpan ExamTime { get; set; }

        public int? PresidentId { get; set; }

        public int? ExaminerId { get; set; }

        public int? MemberId { get; set; }

                
        [NotMapped]
        public DateTime ExamDateTime
        {
            get
            {
                return new DateTime(ExamDate.Year, ExamDate.Month, ExamDate.Day, ExamTime.Hours, ExamTime.Minutes, ExamTime.Seconds);
            }
            private set { }
        }
    }
}
