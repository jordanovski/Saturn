﻿using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IVehicleRepository : IDisposable
    {
        Task<List<VehicleViewModel>> GetAllAsync();
        Task<Vehicle> FindAsync(Expression<Func<Vehicle, bool>> match);
        Task<List<Vehicle>> FindAllAsync(Expression<Func<Vehicle, bool>> match);
        Task<int> InsertAsync(Vehicle t);
        Task<int> UpdateAsync(Vehicle t);
        Task<int> RemoveAsync(Vehicle t);
        Task<int> CountAsync();
    }
}
