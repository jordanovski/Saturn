using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly SaturnDbContext dbContext;

        public CandidateRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }

        public async Task<List<CandidateViewModel>> GetAllAsync()
        {
            return await dbContext.Candidate
               .Include(c => c.City)
               .Include(c => c.DrivingCategory)
               .Include(c => c.ExistingDrivingCategory)
               .OrderByDescending(o => o.Id)
               .Select(CandidateViewModel.FromCandidates).ToListAsync();
        }

        public async Task<Candidate> FindAsync(Expression<Func<Candidate, bool>> match)
        {
            return await dbContext.Candidate.SingleOrDefaultAsync(match);
        }

        public async Task<List<Candidate>> FindAllAsync(Expression<Func<Candidate, bool>> match)
        {
            return await dbContext.Candidate.Where(match).ToListAsync();
        }

        public void InsertAsync(Candidate t)
        {
            dbContext.Candidate.Add(t);
        }

        public void UpdateAsync(Candidate t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(Candidate t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Candidate.CountAsync();
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
