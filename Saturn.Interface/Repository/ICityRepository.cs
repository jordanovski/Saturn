using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface ICityRepository : IDisposable
    {
        Task<List<City>> GetAllAsync();
        Task<City> FindAsync(Expression<Func<City, bool>> match);
        Task<List<City>> FindAllAsync(Expression<Func<City, bool>> match);
        void InsertAsync(City t);
        void UpdateAsync(City t);
        void RemoveAsync(City t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
