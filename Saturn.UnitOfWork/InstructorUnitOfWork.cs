using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Interface.UnitOfWork;
using Saturn.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.UnitOfWork
{
    //public class InstructorUnitOfWork : IInstructorUnitOfWork
    //{
    //    private readonly SaturnDbContext dbContext;
    //    private readonly IDrivingSchoolRepository drivingSchoolRepository;
    //    private readonly IInstructorRepository instructorRepository;

    //    public InstructorUnitOfWork(SaturnDbContext context)
    //    {
    //        dbContext = context;

    //        drivingSchoolRepository = new DrivingSchoolRepository(dbContext);
    //        instructorRepository = new InstructorRepository(dbContext);
    //    }


    //    public IDrivingSchoolRepository DrivingSchoolRepository
    //    {
    //        get { return drivingSchoolRepository; }
    //    }

    //    public IInstructorRepository InstructorRepository
    //    {
    //        get { return instructorRepository; }
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
