
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.Data;
using Kanini_Tourism_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kanini_Tourism_API.Repository.Service
{
    public class TourService : ITour
    {
        private readonly AppDbContext _UserContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TourService(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _UserContext = context;
            _webHostEnvironment = webHostEnvironment;
        }
        //GetAllTours
        public IEnumerable<Tour> GetAllTours()
        {
            return _UserContext.Tours.ToList();
        }
        //GetTourById
        public Tour GetTourById(int User_Id)
        {
            return _UserContext.Tours.FirstOrDefault(x => x.TourId == User_Id);
        }
        //Post
        public async Task<Tour> CreateTour([FromForm] Tour tour, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Tour");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            tour.TourImageUrl = fileName;

            _UserContext.Tours.Add(tour);
            await _UserContext.SaveChangesAsync();

            return tour;
        }

        //update

        public async Task<Tour> UpdateTour(int id,Tour tour, IFormFile imageFile)
        {

            var existingTour = await _UserContext.Tours.FirstOrDefaultAsync(x=>x.TourId==id);

            if (existingTour == null)
            {
                throw new ArgumentException("Package not found");
            }

            existingTour.TourName = tour.TourName;
            existingTour.TourLocation = tour.TourLocation;

            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Tour");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                existingTour.TourImageUrl = fileName;

            }

            await _UserContext.SaveChangesAsync();

            return existingTour;
        }

        //Delete
        public async Task<List<Tour>?> DeleteTourById(int id)
        {
            var users = await _UserContext.Tours.FindAsync(id);
            if (users is null)
            {
                return null;
            }
            _UserContext.Remove(users);
            await _UserContext.SaveChangesAsync();
            return await _UserContext.Tours.ToListAsync();
        }
        
    }
}