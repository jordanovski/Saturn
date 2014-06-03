using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Saturn.Model.ViewModels;

namespace Saturn.Interface.Repository
{
    public interface IErrorTypeRepository : IDisposable
    {
        Task<List<ErrorTypeViewModel>> GetAllAsync();
        Task<ErrorType> FindAsync(Expression<Func<ErrorType, bool>> match);
        Task<List<ErrorTypeViewModel>> FindAllAsync(Expression<Func<ErrorTypeViewModel, bool>> match);
        void InsertAsync(ErrorType t);
        void UpdateAsync(ErrorType t);
        void RemoveAsync(ErrorType t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
