using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Tourism_API.Models;

namespace Kanini_Tourism_API.Repositories
{
    public interface ITourSpotRepository
    {
        Task<IEnumerable<TourSpot>> GetTourSpots();
        Task<TourSpot> GetTourSpot(int id);
        Task<TourSpot> CreateTourSpot(TourSpot tourSpot);
        Task<bool> UpdateTourSpot(TourSpot tourSpot);
        Task<bool> DeleteTourSpot(int id);
    }
}
