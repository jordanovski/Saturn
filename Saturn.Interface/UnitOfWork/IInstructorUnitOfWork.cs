using Saturn.Interface.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.Interface.UnitOfWork
{
    public interface IInstructorUnitOfWork : IDisposable
    {
        IDrivingSchoolRepository DrivingSchoolRepository { get; }
        IInstructorRepository InstructorRepository { get; }

        Task<int> SaveAsync();
    }
}
