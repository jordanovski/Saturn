using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IPriceListRepository : IDisposable
    {
        Task<List<PriceListViewModel>> GetAllAsync();
        Task<PriceList> FindAsync(Expression<Func<PriceList, bool>> match);
        Task<List<PriceList>> FindAllAsync(Expression<Func<PriceList, bool>> match);
        void InsertAsync(PriceList t);
        void UpdateAsync(PriceList t);
        void RemoveAsync(PriceList t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
