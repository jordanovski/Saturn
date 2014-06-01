using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IPriceListRepository : IDisposable
    {
        Task<List<PriceList>> GetAllAsync();
        Task<PriceList> FindAsync(Expression<Func<PriceList, bool>> match);
        Task<List<PriceList>> FindAllAsync(Expression<Func<PriceList, bool>> match);
        void InsertAsync(PriceList t);
        void UpdateAsync(PriceList t);
        void RemoveAsync(PriceList t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
