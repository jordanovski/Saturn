using Saturn.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saturn.Interface.Repository
{
    public interface IPublicRepository
    {
        Task<IList<ExamViewModel>> GetFinishedExamsAsync();
        Task<IList<ExamViewModel>> GetUpcomingExamAsync();

        Task<IList<ExamResultsViewModel>> GetAllCandidatesAsync(int id);
        Task<IList<ExamResultsViewModel>> GetPassedCandiddatesAsync(int id);
        Task<IList<ExamResultsViewModel>> GetFailedCandidatesAsync(int id);
        Task<IList<ExamResultsViewModel>> GetDidNotAppearCandidatesAsync(int id);
    }
}
