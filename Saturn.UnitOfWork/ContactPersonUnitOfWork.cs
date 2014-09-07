using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Interface.UnitOfWork;
using Saturn.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.UnitOfWork
{
    //public class ContactPersonUnitOfWork : IContactPersonUnitOfWork
    //{
    //    private readonly SaturnDbContext dbContext;
    //    private readonly IContactTypeRepository contactTypeRepository;
    //    private readonly IContactPersonRepository contactPersonRepository;

    //    public ContactPersonUnitOfWork(SaturnDbContext context)
    //    {
    //        dbContext = context;

    //        contactTypeRepository = new ContactTypeRepository(dbContext);
    //        contactPersonRepository = new ContactPersonRepository(dbContext);
    //    }
    //    public IContactTypeRepository ContactTypeRepository
    //    {
    //        get { return contactTypeRepository; }
    //    }

    //    public IContactPersonRepository ContactPersonRepository
    //    {
    //        get { return contactPersonRepository; }
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
