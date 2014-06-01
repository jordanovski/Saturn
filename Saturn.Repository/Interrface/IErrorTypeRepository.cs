using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IErrorTypeRepository : IDisposable
    {
        Task<List<ErrorType>> GetAllAsync();
        Task<ErrorType> FindAsync(Expression<Func<ErrorType, bool>> match);
        Task<List<ErrorType>> FindAllAsync(Expression<Func<ErrorType, bool>> match);
        void InsertAsync(ErrorType t);
        void UpdateAsync(ErrorType t);
        void RemoveAsync(ErrorType t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
