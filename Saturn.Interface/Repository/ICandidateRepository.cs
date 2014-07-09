using Saturn.Model;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface ICandidateRepository : IDisposable
    {
        Task<List<CandidateViewModel>> GetAllAsync();
        Task<Candidate> FindAsync(Expression<Func<Candidate, bool>> match);
        Task<List<Candidate>> FindAllAsync(Expression<Func<Candidate, bool>> match);
        void InsertAsync(Candidate t);
        void UpdateAsync(Candidate t);
        void RemoveAsync(Candidate t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
