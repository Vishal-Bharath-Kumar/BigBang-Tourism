using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Tourism_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kanini_Tourism_API.Repositories
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetHotels();
        Task<Hotel> GetHotel(int id);
        Task<Hotel> CreateHotel([FromForm] Hotel tour, IFormFile imageFile);
        Task<bool> UpdateHotel(Hotel hotel);
        Task<bool> DeleteHotel(int id);
    }
}
