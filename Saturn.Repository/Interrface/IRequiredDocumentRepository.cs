using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IRequiredDocumentRepository : IDisposable
    {
        Task<List<RequiredDocument>> GetAllAsync();
        Task<RequiredDocument> FindAsync(Expression<Func<RequiredDocument, bool>> match);
        Task<List<RequiredDocument>> FindAllAsync(Expression<Func<RequiredDocument, bool>> match);
        void InsertAsync(RequiredDocument t);
        void UpdateAsync(RequiredDocument t);
        void RemoveAsync(RequiredDocument t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
