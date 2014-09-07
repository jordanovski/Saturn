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
    public class CityRepository : ICityRepository
    {
        private readonly SaturnDbContext dbContext;

        public CityRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }

        public List<City> GetAll()
        {
            return dbContext.City.OrderBy(o => o.Name).ToList();
        }
        public async Task<List<City>> GetAllAsync()
        {
            return await dbContext.City.OrderBy(o => o.Name).ToListAsync();
        }

        public async Task<City> FindAsync(Expression<Func<City, bool>> match)
        {
            return await dbContext.City.SingleOrDefaultAsync(match);
        }

        public async Task<List<City>> FindAllAsync(Expression<Func<City, bool>> match)
        {
            return await dbContext.City.Where(match).ToListAsync();
        }

        public void InsertAsync(City t)
        {
            dbContext.City.Add(t);
        }

        public void UpdateAsync(City t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(City t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.City.CountAsync();
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
