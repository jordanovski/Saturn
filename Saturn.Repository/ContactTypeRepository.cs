using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Saturn.Data;
using Saturn.Model.Codebooks;
using Saturn.Repository.Interrface;
using System.Data.Entity;

namespace Saturn.Repository
{
    public class ContactTypeRepository : IContactTypeRepository
    {
        private readonly SaturnDbContext dbContext;

        public ContactTypeRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<ContactType>> GetAllAsync()
        {
            return await dbContext.ContactType.ToListAsync();
        }

        public async Task<ContactType> FindAsync(Expression<Func<ContactType, bool>> match)
        {
            return await dbContext.ContactType.SingleOrDefaultAsync(match);
        }

        public async Task<List<ContactType>> FindAllAsync(Expression<Func<ContactType, bool>> match)
        {
            return await dbContext.ContactType.Where(match).ToListAsync();
        }

        public void InsertAsync(ContactType t)
        {
            dbContext.ContactType.Add(t);
        }

        public void UpdateAsync(ContactType t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(ContactType t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.ContactType.CountAsync();
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
