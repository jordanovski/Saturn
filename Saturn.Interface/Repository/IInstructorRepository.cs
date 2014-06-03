using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IInstructorRepository : IDisposable
    {
        Task<List<InstructorViewModel>> GetAllAsync();
        Task<Instructor> FindAsync(Expression<Func<Instructor, bool>> match);
        Task<List<Instructor>> FindAllAsync(Expression<Func<Instructor, bool>> match);
        void InsertAsync(Instructor t);
        void UpdateAsync(Instructor t);
        void RemoveAsync(Instructor t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
