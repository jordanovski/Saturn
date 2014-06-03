using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IReqDocDrivingCategoryRepository : IDisposable
    {
        Task<List<ReqDocDrivingCategoryViewModel>> GetAllAsync();
        Task<ReqDocDrivingCategory> FindAsync(Expression<Func<ReqDocDrivingCategory, bool>> match);
        Task<List<ReqDocDrivingCategoryViewModel>> FindAllAsync(Expression<Func<ReqDocDrivingCategoryViewModel, bool>> match);
        void InsertAsync(ReqDocDrivingCategory t);
        void UpdateAsync(ReqDocDrivingCategory t);
        void RemoveAsync(ReqDocDrivingCategory t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
