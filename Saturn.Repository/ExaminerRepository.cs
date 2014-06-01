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
    public class ExaminerRepository : IExaminerRepository
    {
        private readonly SaturnDbContext dbContext;

        public ExaminerRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<Examiner>> GetAllAsync()
        {
            return await dbContext.Examiner.ToListAsync();
        }

        public async Task<Examiner> FindAsync(Expression<Func<Examiner, bool>> match)
        {
            return await dbContext.Examiner.SingleOrDefaultAsync(match);
        }

        public async Task<List<Examiner>> FindAllAsync(Expression<Func<Examiner, bool>> match)
        {
            return await dbContext.Examiner.Where(match).ToListAsync();
        }

        public void InsertAsync(Examiner t)
        {
            dbContext.Examiner.Add(t);
        }

        public void UpdateAsync(Examiner t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(Examiner t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Examiner.CountAsync();
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
