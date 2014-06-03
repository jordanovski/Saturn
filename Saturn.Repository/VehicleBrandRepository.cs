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
    public class VehicleBrandRepository : IVehicleBrandRepository
    {
        private readonly SaturnDbContext dbContext;

        public VehicleBrandRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<VehicleBrand>> GetAllAsync()
        {
            return await dbContext.VehicleBrand.OrderBy(o => o.Brand).ToListAsync();
        }

        public async Task<VehicleBrand> FindAsync(Expression<Func<VehicleBrand, bool>> match)
        {
            return await dbContext.VehicleBrand.SingleOrDefaultAsync(match);
        }

        public async Task<List<VehicleBrand>> FindAllAsync(Expression<Func<VehicleBrand, bool>> match)
        {
            return await dbContext.VehicleBrand.Where(match).ToListAsync();
        }

        public void InsertAsync(VehicleBrand t)
        {
            dbContext.VehicleBrand.Add(t);
        }

        public void UpdateAsync(VehicleBrand t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(VehicleBrand t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.VehicleBrand.CountAsync();
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
