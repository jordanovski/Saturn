using Saturn.Interface.Repository;
using System;
using System.Threading.Tasks;

namespace Saturn.Interface.UnitOfWork
{
    public interface IPriceListUnitOfWork : IDisposable
    {
        IDrivingCategoryRepository DrivingCategoryRepository { get; }
        IExamTypeRepository ExamTypeRepository { get; }
        IPriceListRepository PriceListRepository { get; }
        
        Task<int> SaveAsync();
    }
}
