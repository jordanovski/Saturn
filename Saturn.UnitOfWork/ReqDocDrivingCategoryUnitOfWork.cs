using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Interface.UnitOfWork;
using Saturn.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.UnitOfWork
{
    //public class ReqDocDrivingCategoryUnitOfWork : IReqDocDrivingCategoryUnitOfWork
    //{
    //    private readonly SaturnDbContext dbContext;
    //    private readonly IRequiredDocumentRepository requiredDocumentRepository;
    //    private readonly IDrivingCategoryRepository drivingCategoryRepository;
    //    private readonly IReqDocDrivingCategoryRepository reqDocDrivingCategoryRepository;

    //    public ReqDocDrivingCategoryUnitOfWork(SaturnDbContext context)
    //    {
    //        dbContext = context;

    //        requiredDocumentRepository = new RequiredDocumentRepository(dbContext);
    //        drivingCategoryRepository = new DrivingCategoryRepository(dbContext);
    //        reqDocDrivingCategoryRepository = new ReqDocDrivingCategoryRepository(dbContext);
    //    }

    //    public IRequiredDocumentRepository RequiredDocumentRepository
    //    {
    //        get { return requiredDocumentRepository; }
    //    }

    //    public IDrivingCategoryRepository DrivingCategoryRepository
    //    {
    //        get { return drivingCategoryRepository; }
    //    }

    //    public IReqDocDrivingCategoryRepository ReqDocDrivingCategoryRepository
    //    {
    //        get { return reqDocDrivingCategoryRepository; }
    //    }


    //    public async Task<int> SaveAsync()
    //    {
    //        return await dbContext.SaveChangesAsync();
    //    }

    //    #region IDisposable Methods

    //    private bool disposed = false;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                dbContext.Dispose();
    //            }
    //        }
    //        this.disposed = true;
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }

    //    #endregion

    //}
}
