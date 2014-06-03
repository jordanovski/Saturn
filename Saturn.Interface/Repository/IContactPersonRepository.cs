using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Saturn.Model.ViewModels;

namespace Saturn.Interface.Repository
{
    public interface IContactPersonRepository : IDisposable
    {
        Task<List<ContactPersonViewModel>> GetAllAsync();
        Task<ContactPerson> FindAsync(Expression<Func<ContactPerson, bool>> match);
        Task<List<ContactPersonViewModel>> FindAllAsync(Expression<Func<ContactPersonViewModel, bool>> match);
        void InsertAsync(ContactPerson t);
        void UpdateAsync(ContactPerson t);
        void RemoveAsync(ContactPerson t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
