using Kanini_Tourism_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kanini_Tourism_API.Repository.Interfaces
{
    public interface ITour
    {
        IEnumerable<Tour> GetAllTours();
        Tour GetTourById(int User_Id);
        Task<Tour> CreateTour([FromForm] Tour tour, IFormFile imageFile);
        Task<Tour> UpdateTour(int id,Tour tour, IFormFile imageFile);
        Task<List<Tour>?> DeleteTourById(int id);
    }
}
