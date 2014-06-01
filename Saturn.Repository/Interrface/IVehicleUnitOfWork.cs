using System;

namespace Saturn.Repository.Interrface
{
    public interface IVehicleUnitOfWork : IDisposable
    {
        IVehicleRepository VehicleRepository { get; }
        IVehicleBrandRepository VehicleBrandRepository { get; }
        IVehicleTypeRepository VehicleTypeRepository { get; }
        IDrivingSchoolRepository DrivingSchoolRepository { get; }
    }
}
