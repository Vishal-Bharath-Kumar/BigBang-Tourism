using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Tourism_API.Models;

namespace Kanini_Tourism_API.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetFeedbacks();
        Task<Feedback> GetFeedback(int id);
        Task<Feedback> CreateFeedback(Feedback feedback);
        Task<bool> UpdateFeedback(Feedback feedback);
        Task<bool> DeleteFeedback(int id);
    }
}
