using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Saturn.Data;
using Saturn.Model.Codebooks;
using Saturn.Repository.Interrface;

namespace Saturn.Repository
{
    public class RegistrationStatusRepository : IRegistrationStatusRepository
    {
        private readonly SaturnDbContext dbContext;

        public RegistrationStatusRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<RegistrationStatus>> GetAllAsync()
        {
            return await dbContext.RegistrationStatus.ToListAsync();
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
