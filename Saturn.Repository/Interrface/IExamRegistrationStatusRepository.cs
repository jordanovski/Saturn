using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saturn.Repository.Interrface
{
    public interface IExamRegistrationStatusRepository : IDisposable
    {
        Task<List<ExamRegistrationStatus>> GetAllAsync();
    }
}
