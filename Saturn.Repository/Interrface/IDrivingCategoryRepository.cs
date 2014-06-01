using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IDrivingCategoryRepository : IDisposable
    {
        Task<List<DrivingCategory>> GetAllAsync();
        Task<DrivingCategory> FindAsync(Expression<Func<DrivingCategory, bool>> match);
        Task<List<DrivingCategory>> FindAllAsync(Expression<Func<DrivingCategory, bool>> match);
        void InsertAsync(DrivingCategory t);
        void UpdateAsync(DrivingCategory t);
        void RemoveAsync(DrivingCategory t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
