using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Interface.UnitOfWork;
using Saturn.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.UnitOfWork
{
    //public class VehicleUnitOfWork : IVehicleUnitOfWork
    //{
    //    private readonly VehiclesContext dbContext;
    //    private readonly IVehicleRepository vehicleRepository;
    //    private readonly IVehicleTypeRepository vehicleTypeRepository;
    //    private readonly IVehicleBrandRepository vehicleBrandRepository;
    //    private readonly IDrivingSchoolRepository drivingSchoolRepository;

    //    public VehicleUnitOfWork(VehiclesContext context)
    //    {
    //        dbContext = context;

    //        vehicleRepository = new VehicleRepository(dbContext);
    //        vehicleTypeRepository = new VehicleTypeRepository(dbContext);
    //        vehicleBrandRepository = new VehicleBrandRepository(dbContext);
    //        //drivingSchoolRepository = new DrivingSchoolRepository(dbContext);
    //    }


    //    public IVehicleRepository VehicleRepository
    //    {
    //        get { return vehicleRepository; }
    //    }

    //    public IVehicleTypeRepository VehicleTypeRepository
    //    {
    //        get { return vehicleTypeRepository; }
    //    }

    //    public IVehicleBrandRepository VehicleBrandRepository
    //    {
    //        get { return vehicleBrandRepository; }
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
