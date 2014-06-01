using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IContactTypeRepository : IDisposable
    {
        Task<List<ContactType>> GetAllAsync();
        Task<ContactType> FindAsync(Expression<Func<ContactType, bool>> match);
        Task<List<ContactType>> FindAllAsync(Expression<Func<ContactType, bool>> match);
        void InsertAsync(ContactType t);
        void UpdateAsync(ContactType t);
        void RemoveAsync(ContactType t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
