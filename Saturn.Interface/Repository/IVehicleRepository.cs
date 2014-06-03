using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IVehicleRepository : IDisposable
    {
        Task<List<VehicleViewModel>> GetAllAsync();
        Task<Vehicle> FindAsync(Expression<Func<Vehicle, bool>> match);
        Task<List<VehicleViewModel>> FindAllAsync(Expression<Func<VehicleViewModel, bool>> match);
        void InsertAsync(Vehicle t);
        void UpdateAsync(Vehicle t);
        void RemoveAsync(Vehicle t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
