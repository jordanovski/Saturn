using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IExamLanguageRepository : IDisposable
    {
        Task<List<ExamLanguage>> GetAllAsync();
        Task<ExamLanguage> FindAsync(Expression<Func<ExamLanguage, bool>> match);
        Task<List<ExamLanguage>> FindAllAsync(Expression<Func<ExamLanguage, bool>> match);
        void InsertAsync(ExamLanguage t);
        void UpdateAsync(ExamLanguage t);
        void RemoveAsync(ExamLanguage t);
        Task<int> CountAsync();

        Task<int> SaveAsync();
    }
}
