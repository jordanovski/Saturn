using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IContactPersonRepository : IDisposable
    {
        Task<List<ContactPerson>> GetAllAsync();
        Task<ContactPerson> FindAsync(Expression<Func<ContactPerson, bool>> match);
        Task<List<ContactPerson>> FindAllAsync(Expression<Func<ContactPerson, bool>> match);
        void InsertAsync(ContactPerson t);
        void UpdateAsync(ContactPerson t);
        void RemoveAsync(ContactPerson t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
