using Saturn.Data;
using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
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


        public async Task<List<VehicleViewModel>> GetAllAsync()
        {
            var data = await dbContext.Vehicle.Include(i => i.VehicleBrand).Include(i => i.VehicleType).Select(VehicleViewModel.FromVehicle).ToListAsync();
            foreach (var v in data)
            {
                if (v.DrivingSchoolId != null)
                {
                    var drivingSchool = dbContext.DrivingSchool.Find((int)v.DrivingSchoolId);
                    if (drivingSchool!=null)
                    {
                        v.DrivingSchool = drivingSchool.Name;
                        v.DrivingSchoolIsActive = drivingSchool.IsActive;
                    }
                }
            }
           
            return data;
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
