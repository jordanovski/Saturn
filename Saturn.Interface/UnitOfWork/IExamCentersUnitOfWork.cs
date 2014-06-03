using Saturn.Interface.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.Interface.UnitOfWork
{
    public interface IExamCentersUnitOfWork : IDisposable
    {
        ICityRepository CityRepository { get; }
        IExamCentersRepository ExamCentersRepository { get; }

        Task<int> SaveAsync();
    }
}
