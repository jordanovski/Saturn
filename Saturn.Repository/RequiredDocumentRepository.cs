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
    public class RequiredDocumentRepository : IRequiredDocumentRepository
    {
        private readonly SaturnDbContext dbContext;

        public RequiredDocumentRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<RequiredDocument>> GetAllAsync()
        {
            return await dbContext.RequiredDocument.ToListAsync();
        }

        public async Task<RequiredDocument> FindAsync(Expression<Func<RequiredDocument, bool>> match)
        {
            return await dbContext.RequiredDocument.SingleOrDefaultAsync(match);
        }

        public async Task<List<RequiredDocument>> FindAllAsync(Expression<Func<RequiredDocument, bool>> match)
        {
            return await dbContext.RequiredDocument.Where(match).ToListAsync();
        }

        public void InsertAsync(RequiredDocument t)
        {
            dbContext.RequiredDocument.Add(t);
        }

        public void UpdateAsync(RequiredDocument t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(RequiredDocument t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.RequiredDocument.CountAsync();
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
