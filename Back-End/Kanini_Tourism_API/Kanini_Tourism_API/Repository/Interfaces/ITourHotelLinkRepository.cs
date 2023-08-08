using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Tourism_API.Models;

namespace Kanini_Tourism_API.Repositories
{
    public interface ITourHotelLinkRepository
    {
        Task<IEnumerable<TourHotelLink>> GetTourHotelLinks();
        Task<TourHotelLink> GetTourHotelLink(int id);
        Task<TourHotelLink> CreateTourHotelLink(TourHotelLink tourHotelLink);
        Task<bool> UpdateTourHotelLink(TourHotelLink tourHotelLink);
        Task<bool> DeleteTourHotelLink(int id);
    }
}
