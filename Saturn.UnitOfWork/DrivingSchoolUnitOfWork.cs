using Saturn.Domain;
using Saturn.Interface.Repository;
using Saturn.Interface.UnitOfWork;
using Saturn.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.UnitOfWork
{
    //public class DrivingSchoolUnitOfWork : IDrivingSchoolUnitOfWork
    //{
    //    private readonly SaturnDbContext dbContext;
    //    private readonly ICityRepository cityRepository;
    //    private readonly IDrivingSchoolRepository drivingSchoolRepository;
    //    public DrivingSchoolUnitOfWork(SaturnDbContext context)
    //    {
    //        dbContext = context;

    //        cityRepository = new CityRepository(dbContext);
    //        drivingSchoolRepository = new DrivingSchoolRepository(dbContext);
    //    }

    //    public ICityRepository CityRepository
    //    {
    //        get { return cityRepository; }
    //    }

    //    public IDrivingSchoolRepository DrivingSchoolRepository
    //    {
    //        get { return drivingSchoolRepository; }
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
