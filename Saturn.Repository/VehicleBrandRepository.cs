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
            return await dbContext.VehicleBrand.ToListAsync();
        }

        public async Task<VehicleBrand> FindAsync(Expression<Func<VehicleBrand, bool>> match)
        {
            return await dbContext.VehicleBrand.SingleOrDefaultAsync(match);
        }

        public async Task<List<VehicleBrand>> FindAllAsync(Expression<Func<VehicleBrand, bool>> match)
        {
            return await dbContext.VehicleBrand.Where(match).ToListAsync();
        }

        public async Task<int> InsertAsync(VehicleBrand t)
        {
            dbContext.VehicleBrand.Add(t);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(VehicleBrand t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(VehicleBrand t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.VehicleBrand.CountAsync();
        }
    }
}
