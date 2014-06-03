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
    public class ReqDocDrivingCategoryRepository : IReqDocDrivingCategoryRepository
    {
        private readonly SaturnDbContext dbContext;

        public ReqDocDrivingCategoryRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<ReqDocDrivingCategory>> GetAllAsync()
        {
            return await dbContext.ReqDocDrivingCategory.ToListAsync();
        }

        public async Task<ReqDocDrivingCategory> FindAsync(Expression<Func<ReqDocDrivingCategory, bool>> match)
        {
            return await dbContext.ReqDocDrivingCategory.SingleOrDefaultAsync(match);
        }

        public async Task<List<ReqDocDrivingCategory>> FindAllAsync(Expression<Func<ReqDocDrivingCategory, bool>> match)
        {
            return await dbContext.ReqDocDrivingCategory.Where(match).ToListAsync();
        }

        public void InsertAsync(ReqDocDrivingCategory t)
        {
            dbContext.ReqDocDrivingCategory.Add(t);
        }

        public void UpdateAsync(ReqDocDrivingCategory t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(ReqDocDrivingCategory t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.ReqDocDrivingCategory.CountAsync();
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
