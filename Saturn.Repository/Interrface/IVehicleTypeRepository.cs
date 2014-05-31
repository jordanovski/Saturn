using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IVehicleTypeRepository : IDisposable
    {
        Task<List<VehicleType>> GetAllAsync();
        Task<VehicleType> FindAsync(Expression<Func<VehicleType, bool>> match);
        Task<List<VehicleType>> FindAllAsync(Expression<Func<VehicleType, bool>> match);
        Task<int> InsertAsync(VehicleType t);
        Task<int> UpdateAsync(VehicleType t);
        Task<int> RemoveAsync(VehicleType t);
        Task<int> CountAsync();
    }
}
