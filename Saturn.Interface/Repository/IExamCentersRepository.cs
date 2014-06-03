using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IExamCentersRepository : IDisposable
    {
        Task<List<ExamCenters>> GetAllAsync();
        Task<ExamCenters> FindAsync(Expression<Func<ExamCenters, bool>> match);
        Task<List<ExamCenters>> FindAllAsync(Expression<Func<ExamCenters, bool>> match);
        void InsertAsync(ExamCenters t);
        void UpdateAsync(ExamCenters t);
        void RemoveAsync(ExamCenters t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
