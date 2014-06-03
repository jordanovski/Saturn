using Saturn.Interface.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.Interface.UnitOfWork
{
    public interface IReqDocDrivingCategoryUnitOfWork : IDisposable
    {
        IRequiredDocumentRepository RequiredDocumentRepository { get; }
        IDrivingCategoryRepository DrivingCategoryRepository { get; }
        IReqDocDrivingCategoryRepository ReqDocDrivingCategoryRepository { get; }

        Task<int> SaveAsync();
    }
}
