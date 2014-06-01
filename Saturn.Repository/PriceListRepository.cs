using Saturn.Data;
using Saturn.Model.Codebooks;
using Saturn.Repository.Interrface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository
{
    public class PriceListRepository : IPriceListRepository
    {
        private readonly SaturnDbContext dbContext;

        public PriceListRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<PriceList>> GetAllAsync()
        {
            return await dbContext.PriceList.ToListAsync();
        }

        public async Task<PriceList> FindAsync(Expression<Func<PriceList, bool>> match)
        {
            return await dbContext.PriceList.SingleOrDefaultAsync(match);
        }

        public async Task<List<PriceList>> FindAllAsync(Expression<Func<PriceList, bool>> match)
        {
            return await dbContext.PriceList.Where(match).ToListAsync();
        }

        public void InsertAsync(PriceList t)
        {
            dbContext.PriceList.Add(t);
        }

        public void UpdateAsync(PriceList t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(PriceList t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.PriceList.CountAsync();
        }


        public async Task<int> SaveAsync()
        {
            return await dbContext.SaveChangesAsync();
        }


        #region IDisposable Methods

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
