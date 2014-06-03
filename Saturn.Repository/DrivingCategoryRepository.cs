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
    public class DrivingCategoryRepository : IDrivingCategoryRepository
    {
        private readonly SaturnDbContext dbContext;

        public DrivingCategoryRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<DrivingCategory>> GetAllAsync()
        {
            return await dbContext.DrivingCategory.ToListAsync();
        }

        public async Task<DrivingCategory> FindAsync(Expression<Func<DrivingCategory, bool>> match)
        {
            return await dbContext.DrivingCategory.SingleOrDefaultAsync(match);
        }

        public async Task<List<DrivingCategory>> FindAllAsync(Expression<Func<DrivingCategory, bool>> match)
        {
            return await dbContext.DrivingCategory.Where(match).ToListAsync();
        }

        public void InsertAsync(DrivingCategory t)
        {
            dbContext.DrivingCategory.Add(t);
        }

        public void UpdateAsync(DrivingCategory t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(DrivingCategory t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.DrivingCategory.CountAsync();
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
