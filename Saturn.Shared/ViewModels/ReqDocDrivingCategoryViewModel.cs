using Saturn.Domain.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Saturn.Shared.ViewModels
{
    public class ReqDocDrivingCategoryViewModel
    {
        public static Expression<Func<ReqDocDrivingCategory, ReqDocDrivingCategoryViewModel>> FromReqDocDriving
        {
            get
            {
                return s => new ReqDocDrivingCategoryViewModel
                {
                    Id = s.Id,
                    ReqDocument = s.RequiredDocument.ReqDocument,
                    DrivingCategory = s.DrivingCategory.Category,
                    DrivingCategoryId = s.DrivingCategoryId
                };
            }
        }

        public int Id { get; set; }

        [Display(Name = "Документ")]
        public string ReqDocument { get; set; }

        [Display(Name = "Категорија")]
        public string DrivingCategory { get; set; }

        public int DrivingCategoryId { get; set; }
    }
}
