using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository
{
    public class ContactPersonRepository : IContactPersonRepository
    {
        private readonly SaturnDbContext dbContext;

        public ContactPersonRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<ContactPersonViewModel>> GetAllAsync()
        {
            return await dbContext.ContactPerson.Select(ContactPersonViewModel.FromContactPerson).ToListAsync();
        }

        public async Task<ContactPerson> FindAsync(Expression<Func<ContactPerson, bool>> match)
        {
            return await dbContext.ContactPerson.SingleOrDefaultAsync(match);
        }

        public async Task<List<ContactPersonViewModel>> FindAllAsync(Expression<Func<ContactPersonViewModel, bool>> match)
        {
            return await dbContext.ContactPerson.Select(ContactPersonViewModel.FromContactPerson).Where(match).ToListAsync();
        }

        public void InsertAsync(ContactPerson t)
        {
            dbContext.ContactPerson.Add(t);
        }

        public void UpdateAsync(ContactPerson t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
        }

        public void RemoveAsync(ContactPerson t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.ContactPerson.CountAsync();
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
