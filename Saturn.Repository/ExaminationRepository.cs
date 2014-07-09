using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model;
using Saturn.Model.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly SaturnDbContext dbContext;
        private readonly SaturnDbViewContext dbViewContext;

        public ExaminationRepository(SaturnDbContext dbContext, SaturnDbViewContext dbViewContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;

            this.dbViewContext = dbViewContext;
            this.dbViewContext.Configuration.ProxyCreationEnabled = false;
        }

        public async Task<List<ViewExaminations>> GetAllAsync()
        {
            return await dbViewContext.ViewExaminations.Where(w => w.ExamDate >= DateTime.Now).OrderBy(o => o.ExamDate).ThenBy(o => o.ExamTime).ToListAsync();
        }

        public async Task<List<ViewExaminations>> GetAllPassedAsync()
        {
            return await dbViewContext.ViewExaminations.Where(w => w.ExamDate < DateTime.Now).OrderByDescending(o => o.ExamDate).ThenByDescending(o => o.ExamTime).ToListAsync();
        }
        public async Task<List<ViewExamCandidates>> GetAllExamCandidatesAsync(Expression<Func<ViewExamCandidates, bool>> match)
        {
            return await dbViewContext.ViewExamCandidates.Where(match).ToListAsync();
        }

        public async Task<Examination> FindAsync(Expression<Func<Examination, bool>> match)
        {
            return await dbContext.Examination.SingleOrDefaultAsync(match);
        }

        public async Task<List<Examination>> FindAllAsync(Expression<Func<Examination, bool>> match)
        {
            return await dbContext.Examination.Where(match).ToListAsync();
        }

        public void InsertAsync(Examination t)
        {
            dbContext.Examination.Add(t);
        }

        public void UpdateAsync(Examination t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(Examination t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Examination.CountAsync();
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
