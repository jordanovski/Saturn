using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Saturn.Model.Codebooks;
using Saturn.Repository.Interrface;
using Saturn.Data;

namespace Saturn.Repository
{
    public class ExamRegistrationStatusRepository : IExamRegistrationStatusRepository
    {
        private readonly SaturnDbContext dbContext;

        public ExamRegistrationStatusRepository(SaturnDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<List<ExamRegistrationStatus>> GetAllAsync()
        {
            return await dbContext.ExamRegistrationStatus.ToListAsync();
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
