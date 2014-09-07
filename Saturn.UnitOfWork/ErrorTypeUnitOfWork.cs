using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Interface.UnitOfWork;
using Saturn.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.UnitOfWork
{
    //public class ErrorTypeUnitOfWork : IErrorTypeUnitOfWork
    //{
    //    private readonly SaturnDbContext dbContext;
    //    private readonly IExamTypeRepository examTypeRepository;
    //    private readonly IErrorTypeRepository errorTypeRepository;
        
    //    public ErrorTypeUnitOfWork(SaturnDbContext context)
    //    {
    //        dbContext = context;

    //        examTypeRepository = new ExamTypeRepository(dbContext);
    //        errorTypeRepository = new ErrorTypeRepository(dbContext);
    //    }


    //    public IExamTypeRepository ExamTypeRepository
    //    {
    //        get { return examTypeRepository; }
    //    }

    //    public IErrorTypeRepository ErrorTypeRepository
    //    {
    //        get { return errorTypeRepository; }
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
