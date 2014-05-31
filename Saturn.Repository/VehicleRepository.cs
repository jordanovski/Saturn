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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly SaturnDbContext dbContext;

        public VehicleRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await dbContext.Vehicle.ToListAsync();
        }

        public async Task<Vehicle> FindAsync(Expression<Func<Vehicle, bool>> match)
        {
            return await dbContext.Vehicle.SingleOrDefaultAsync(match);
        }

        public async Task<List<Vehicle>> FindAllAsync(Expression<Func<Vehicle, bool>> match)
        {
            return await dbContext.Vehicle.Where(match).ToListAsync();
        }

        public async Task<int> InsertAsync(Vehicle t)
        {
            dbContext.Vehicle.Add(t);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Vehicle t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(Vehicle t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Vehicle.CountAsync();
        }
    }
}
