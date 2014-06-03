using Saturn.Interface.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.Interface.UnitOfWork
{
    public interface IVehicleUnitOfWork : IDisposable
    {
        IVehicleRepository VehicleRepository { get; }
        IVehicleBrandRepository VehicleBrandRepository { get; }
        IVehicleTypeRepository VehicleTypeRepository { get; }
        IDrivingSchoolRepository DrivingSchoolRepository { get; }

        Task<int> SaveAsync();
    }
}
