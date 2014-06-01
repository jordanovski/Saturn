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
    public class ExamCentersRepository : IExamCentersRepository
    {
         private readonly SaturnDbContext dbContext;

         public ExamCentersRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


         public async Task<List<ExamCenters>> GetAllAsync()
        {
            return await dbContext.ExamCenters.ToListAsync();
        }

         public async Task<ExamCenters> FindAsync(Expression<Func<ExamCenters, bool>> match)
        {
            return await dbContext.ExamCenters.SingleOrDefaultAsync(match);
        }

         public async Task<List<ExamCenters>> FindAllAsync(Expression<Func<ExamCenters, bool>> match)
        {
            return await dbContext.ExamCenters.Where(match).ToListAsync();
        }

         public void InsertAsync(ExamCenters t)
        {
            dbContext.ExamCenters.Add(t);
        }

         public void UpdateAsync(ExamCenters t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

         public void RemoveAsync(ExamCenters t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.ExamCenters.CountAsync();
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
