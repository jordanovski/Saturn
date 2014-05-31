using System.Linq;
using Saturn.Model;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saturn.Repository
{
    public interface ICandidateRepository : IDisposable
    {
        Task<List<CandidateViewModel>> SelectAll();
        Candidate SelectByID(string id);
        void Insert(Candidate obj);
        void Update(Candidate obj);
        void Delete(string id);
        Task Save();
    }
}
