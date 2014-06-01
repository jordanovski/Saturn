﻿using Saturn.Data;
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
    public class DrivingSchoolRepository : IDrivingSchoolRepository
    {
        private readonly SaturnDbContext dbContext;

        public DrivingSchoolRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<DrivingSchool>> GetAllAsync()
        {
            return await dbContext.DrivingSchool.ToListAsync();
        }

        public async Task<DrivingSchool> FindAsync(Expression<Func<DrivingSchool, bool>> match)
        {
            return await dbContext.DrivingSchool.SingleOrDefaultAsync(match);
        }

        public async Task<List<DrivingSchool>> FindAllAsync(Expression<Func<DrivingSchool, bool>> match)
        {
            return await dbContext.DrivingSchool.Where(match).ToListAsync();
        }

        public void InsertAsync(DrivingSchool t)
        {
            dbContext.DrivingSchool.Add(t);
        }

        public void UpdateAsync(DrivingSchool t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(DrivingSchool t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.DrivingSchool.CountAsync();
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
