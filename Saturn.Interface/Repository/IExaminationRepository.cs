using Saturn.Model;
using Saturn.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IExaminationRepository : IDisposable
    {
        Task<List<ViewExaminations>> GetAllAsync();
        Task<List<ViewExaminations>> GetAllPassedAsync();
        Task<List<ViewExamCandidates>> GetAllExamCandidatesAsync(Expression<Func<ViewExamCandidates, bool>> match);
        Task<Examination> FindAsync(Expression<Func<Examination, bool>> match);
        Task<List<Examination>> FindAllAsync(Expression<Func<Examination, bool>> match);
        void InsertAsync(Examination t);
        void UpdateAsync(Examination t);
        void RemoveAsync(Examination t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
