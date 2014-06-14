using Saturn.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IRegistrationRepository : IDisposable
    {
        Task<List<Registration>> GetAllAsync();
        Task<Registration> FindAsync(Expression<Func<Registration, bool>> match);
        Task<List<Registration>> FindAllAsync(Expression<Func<Registration, bool>> match);
        void InsertAsync(Registration t);
        void UpdateAsync(Registration t);
        void RemoveAsync(Registration t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
