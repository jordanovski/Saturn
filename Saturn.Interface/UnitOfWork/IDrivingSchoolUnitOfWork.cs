using Saturn.Interface.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.Interface.UnitOfWork
{
    public interface IDrivingSchoolUnitOfWork : IDisposable
    {
        ICityRepository CityRepository { get; }
        IDrivingSchoolRepository DrivingSchoolRepository { get; }

        Task<int> SaveAsync();
    }
}
