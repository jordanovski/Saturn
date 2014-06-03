using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Interface.UnitOfWork;
using Saturn.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.UnitOfWork
{
    public class PriceListUnitOfWork : IPriceListUnitOfWork
    {
        private readonly SaturnDbContext dbContext;
        private readonly IDrivingCategoryRepository drivingCategoryRepository;
        private readonly IExamTypeRepository examTypeRepository;
        private readonly IPriceListRepository priceListRepository;

        public PriceListUnitOfWork(SaturnDbContext context)
        {
            dbContext = context;

            drivingCategoryRepository = new DrivingCategoryRepository(dbContext);
            examTypeRepository = new ExamTypeRepository(dbContext);
            priceListRepository = new PriceListRepository(dbContext);
        }

        public IDrivingCategoryRepository DrivingCategoryRepository
        {
            get { return drivingCategoryRepository; }
        }

        public IExamTypeRepository ExamTypeRepository
        {
            get { return examTypeRepository; }
        }

        public IPriceListRepository PriceListRepository
        {
            get { return priceListRepository; }
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
