using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IDrivingSchoolRepository : IDisposable
    {
        Task<List<DrivingSchool>> GetAllAsync();
        Task<DrivingSchool> FindAsync(Expression<Func<DrivingSchool, bool>> match);
        Task<List<DrivingSchool>> FindAllAsync(Expression<Func<DrivingSchool, bool>> match);
        void InsertAsync(DrivingSchool t);
        void UpdateAsync(DrivingSchool t);
        void RemoveAsync(DrivingSchool t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
