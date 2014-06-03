using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IVehicleBrandRepository : IDisposable
    {
        Task<List<VehicleBrand>> GetAllAsync();
        Task<VehicleBrand> FindAsync(Expression<Func<VehicleBrand, bool>> match);
        Task<List<VehicleBrand>> FindAllAsync(Expression<Func<VehicleBrand, bool>> match);
        void InsertAsync(VehicleBrand t);
        void UpdateAsync(VehicleBrand t);
        void RemoveAsync(VehicleBrand t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
