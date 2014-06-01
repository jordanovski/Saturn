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
    public class InstructorRepository : IInstructorRepository
    {
        private readonly SaturnDbContext dbContext;

        public InstructorRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<Instructor>> GetAllAsync()
        {
            return await dbContext.Instructor.ToListAsync();
        }

        public async Task<Instructor> FindAsync(Expression<Func<Instructor, bool>> match)
        {
            return await dbContext.Instructor.SingleOrDefaultAsync(match);
        }

        public async Task<List<Instructor>> FindAllAsync(Expression<Func<Instructor, bool>> match)
        {
            return await dbContext.Instructor.Where(match).ToListAsync();
        }

        public void InsertAsync(Instructor t)
        {
            dbContext.Instructor.Add(t);
        }

        public void UpdateAsync(Instructor t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(Instructor t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Instructor.CountAsync();
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
