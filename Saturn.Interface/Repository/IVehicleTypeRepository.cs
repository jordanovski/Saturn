using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IVehicleTypeRepository : IDisposable
    {
        Task<List<VehicleType>> GetAllAsync();
        Task<VehicleType> FindAsync(Expression<Func<VehicleType, bool>> match);
        Task<List<VehicleType>> FindAllAsync(Expression<Func<VehicleType, bool>> match);
        void InsertAsync(VehicleType t);
        void UpdateAsync(VehicleType t);
        void RemoveAsync(VehicleType t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
