using Saturn.Model.Codebooks;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IDrivingSchoolRepository : IDisposable
    {
        Task<List<DrivingSchoolViewModel>> GetAllAsync();
        Task<DrivingSchool> FindAsync(Expression<Func<DrivingSchool, bool>> match);
        Task<List<DrivingSchoolViewModel>> FindAllAsync(Expression<Func<DrivingSchoolViewModel, bool>> match);
        void InsertAsync(DrivingSchool t);
        void UpdateAsync(DrivingSchool t);
        void RemoveAsync(DrivingSchool t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
