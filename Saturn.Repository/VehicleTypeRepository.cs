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
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly SaturnDbContext dbContext;

        public VehicleTypeRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<VehicleType>> GetAllAsync()
        {
            return await dbContext.VehicleType.OrderBy(o => o.Type).ToListAsync();
        }

        public async Task<VehicleType> FindAsync(Expression<Func<VehicleType, bool>> match)
        {
            return await dbContext.VehicleType.SingleOrDefaultAsync(match);
        }

        public async Task<List<VehicleType>> FindAllAsync(Expression<Func<VehicleType, bool>> match)
        {
            return await dbContext.VehicleType.Where(match).ToListAsync();
        }

        public void InsertAsync(VehicleType t)
        {
            dbContext.VehicleType.Add(t);
        }

        public void UpdateAsync(VehicleType t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(VehicleType t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.VehicleType.CountAsync();
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
