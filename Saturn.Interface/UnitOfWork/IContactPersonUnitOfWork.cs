using Saturn.Interface.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.Interface.UnitOfWork
{
    public interface IContactPersonUnitOfWork : IDisposable
    {
        IContactTypeRepository ContactTypeRepository { get; }
        IContactPersonRepository ContactPersonRepository { get; }

        Task<int> SaveAsync();
    }
}
