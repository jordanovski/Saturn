using System.Linq.Expressions;
using Saturn.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saturn.Model;

namespace Saturn.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public void Dispose()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public Task<List<Registration>> GetAllAsync()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public Task<Registration> FindAsync(Expression<Func<Registration, bool>> match)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public Task<List<Registration>> FindAllAsync(Expression<Func<Registration, bool>> match)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void InsertAsync(Registration t)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void UpdateAsync(Registration t)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void RemoveAsync(Registration t)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
