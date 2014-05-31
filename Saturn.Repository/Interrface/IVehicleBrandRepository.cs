using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IVehicleBrandRepository
    {
        Task<List<VehicleBrand>> GetAllAsync();
        Task<VehicleBrand> FindAsync(Expression<Func<VehicleBrand, bool>> match);
        Task<List<VehicleBrand>> FindAllAsync(Expression<Func<VehicleBrand, bool>> match);
        Task<int> InsertAsync(VehicleBrand t);
        Task<int> UpdateAsync(VehicleBrand t);
        Task<int> RemoveAsync(VehicleBrand t);
        Task<int> CountAsync();
    }
}
