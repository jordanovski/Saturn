using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository
{
    public class ErrorTypeRepository : IErrorTypeRepository
    {
        private readonly SaturnDbContext dbContext;

        public ErrorTypeRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<ErrorType>> GetAllAsync()
        {
            return await dbContext.ErrorType.ToListAsync();
        }

        public async Task<ErrorType> FindAsync(Expression<Func<ErrorType, bool>> match)
        {
            return await dbContext.ErrorType.SingleOrDefaultAsync(match);
        }

        public async Task<List<ErrorType>> FindAllAsync(Expression<Func<ErrorType, bool>> match)
        {
            return await dbContext.ErrorType.Where(match).ToListAsync();
        }

        public void InsertAsync(ErrorType t)
        {
            dbContext.ErrorType.Add(t);
        }

        public void UpdateAsync(ErrorType t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(ErrorType t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.ErrorType.CountAsync();
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
