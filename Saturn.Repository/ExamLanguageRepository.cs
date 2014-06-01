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
    public class ExamLanguageRepository : IExamLanguageRepository
    {
        private readonly SaturnDbContext dbContext;

        public ExamLanguageRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<ExamLanguage>> GetAllAsync()
        {
            return await dbContext.ExamLanguage.ToListAsync();
        }

        public async Task<ExamLanguage> FindAsync(Expression<Func<ExamLanguage, bool>> match)
        {
            return await dbContext.ExamLanguage.SingleOrDefaultAsync(match);
        }

        public async Task<List<ExamLanguage>> FindAllAsync(Expression<Func<ExamLanguage, bool>> match)
        {
            return await dbContext.ExamLanguage.Where(match).ToListAsync();
        }

        public void InsertAsync(ExamLanguage t)
        {
            dbContext.ExamLanguage.Add(t);
        }

        public void UpdateAsync(ExamLanguage t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(ExamLanguage t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.ExamLanguage.CountAsync();
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
