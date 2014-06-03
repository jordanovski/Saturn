using Saturn.Model.Codebooks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IExamTypeRepository : IDisposable
    {
        Task<List<ExamType>> GetAllAsync();
    }
}
