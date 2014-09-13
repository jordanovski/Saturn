using Saturn.Data;
using Saturn.Interface.Repository;
using Saturn.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Saturn.Repository
{
    public class PublicRepository : IPublicRepository
    {
        private readonly SaturnDbContext dbContext;
        private readonly SaturnDbViewContext dbViewContext;

        public PublicRepository(SaturnDbContext dbContext, SaturnDbViewContext dbViewContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;

            this.dbViewContext = dbViewContext;
            this.dbViewContext.Configuration.ProxyCreationEnabled = false;
        }


        public async Task<IList<ExamViewModel>> GetFinishedExamsAsync()
        {
            return await dbViewContext.ViewExaminations
                .Where(w => w.ExamDate < DateTime.Now)
                .OrderByDescending(o => o.ExamDate)
                .ThenByDescending(o => o.ExamTime)
                .Select(ExamViewModel.FromViewExaminations)
                .ToListAsync();
        }

        public async Task<IList<ExamViewModel>> GetUpcomingExamAsync()
        {
            return await dbViewContext.ViewExaminations
                .Where(w => w.ExamDate >= DateTime.Now)
                .OrderByDescending(o => o.ExamDate)
                .ThenByDescending(o => o.ExamTime)
                .Select(ExamViewModel.FromViewExaminations)
                .ToListAsync();
        }


        public async Task<IList<ExamResultsViewModel>> GetAllCandidatesAsync(int id)
        {
            return await dbViewContext.ViewExamCandidates
                .Select(ExamResultsViewModel.FromViewExamCandidates)
                .ToListAsync();
        }

        public async Task<IList<ExamResultsViewModel>> GetPassedCandiddatesAsync(int id)
        {
            return await dbViewContext.ViewExamCandidates
                .Where(w => w.Status.ToLower().Equals("положил"))
                .Select(ExamResultsViewModel.FromViewExamCandidates)
                .ToListAsync();
        }

        public async Task<IList<ExamResultsViewModel>> GetFailedCandidatesAsync(int id)
        {
            return await dbViewContext.ViewExamCandidates
                .Where(w => w.Status.ToLower().Equals("не положил"))
                .Select(ExamResultsViewModel.FromViewExamCandidates)
                .ToListAsync();
        }

        public async Task<IList<ExamResultsViewModel>> GetDidNotAppearCandidatesAsync(int id)
        {
            return await dbViewContext.ViewExamCandidates
                .Where(w => w.Status.ToLower().Equals("не се појавил"))
                .Select(ExamResultsViewModel.FromViewExamCandidates)
                .ToListAsync();
        }
    }
}
