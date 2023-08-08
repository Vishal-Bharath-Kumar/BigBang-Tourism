using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Tourism_API.Models;

namespace Kanini_Tourism_API.Repositories
{
    public interface ITravelAgentRepository
    {
        Task<IEnumerable<TravelAgent>> GetTravelAgents();
        Task<TravelAgent> GetTravelAgent(int id);
        Task<TravelAgent> CreateTravelAgent(TravelAgent travelAgent);
        Task<bool> UpdateTravelAgent(TravelAgent travelAgent);
        Task<bool> DeleteTravelAgent(int id);
    }
}
