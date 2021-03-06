﻿using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
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
        private readonly VehiclesContext dbContext;

        public VehicleRepository(VehiclesContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<VehicleViewModel>> GetAllAsync()
        {
            var data = await dbContext.Vehicles.Include(i => i.VehicleBrand).Include(i => i.VehicleType).Select(VehicleViewModel.FromVehicle).ToListAsync();
            foreach (var v in data)
            {
                if (v.DrivingSchoolId != null)
                {
                    var drivingSchool = dbContext.DrivingSchools.Find((int)v.DrivingSchoolId);
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
            var data = await dbContext.Vehicles.Include(i => i.VehicleBrand).Include(i => i.VehicleType).SingleOrDefaultAsync(match);
           
            return data;
        }

        public async Task<List<VehicleViewModel>> FindAllAsync(Expression<Func<VehicleViewModel, bool>> match)
        {
            var data=await dbContext.Vehicles.Include(i => i.VehicleBrand).Include(i => i.VehicleType).Select(VehicleViewModel.FromVehicle).Where(match).ToListAsync();
            foreach (var v in data)
            {
                if (v.DrivingSchoolId != null)
                {
                    var drivingSchool = dbContext.DrivingSchools.Find((int)v.DrivingSchoolId);
                    if (drivingSchool != null)
                    {
                        v.DrivingSchool = drivingSchool.Name;
                        v.DrivingSchoolIsActive = drivingSchool.IsActive;
                    }
                }
            }
            return data;
        }

        public void InsertAsync(Vehicle t)
        {
            dbContext.Vehicles.Add(t);
        }

        public void UpdateAsync(Vehicle t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(Vehicle t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Vehicles.CountAsync();
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
