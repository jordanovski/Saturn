namespace Saturn.Model.Codebooks
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ReqDocDrivingCategory")]
    public partial class ReqDocDrivingCategory
    {
        public int Id { get; set; }

        public int ReqDocumentId { get; set; }

        public int DrivingCategoryId { get; set; }

        public virtual DrivingCategory DrivingCategory { get; set; }

        public virtual RequiredDocument RequiredDocument { get; set; }
    }
}
