using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IExaminerRepository : IDisposable
    {
        Task<List<Examiner>> GetAllAsync();
        Task<Examiner> FindAsync(Expression<Func<Examiner, bool>> match);
        Task<List<Examiner>> FindAllAsync(Expression<Func<Examiner, bool>> match);
        void InsertAsync(Examiner t);
        void UpdateAsync(Examiner t);
        void RemoveAsync(Examiner t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
