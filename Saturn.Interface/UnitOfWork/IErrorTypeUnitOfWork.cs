using Saturn.Interface.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.Interface.UnitOfWork
{
    public interface IErrorTypeUnitOfWork : IDisposable
    {
        IExamTypeRepository ExamTypeRepository { get; }
        IErrorTypeRepository ErrorTypeRepository { get; }

        Task<int> SaveAsync();
    }
}
