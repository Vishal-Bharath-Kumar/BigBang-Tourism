using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Kanini_Tourism_API.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelRepository(AppDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment= webHostEnvironment;
        }

        public IEnumerable<Hotel> GetHotels()
        {
            var hotels = _context.Hotels
                   .ToList();
            return hotels;
        }

        public async Task<Hotel> GetHotel(int id)
        {
            try
            {
                return await _context.Hotels.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving hotel.", ex);
            }
        }

        //Post
        public async Task<Hotel> CreateHotel([FromForm] Hotel tour, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Hotel");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            tour.HotelImageUrl = fileName;

            _context.Hotels.Add(tour);
            await _context.SaveChangesAsync();


            return tour;
        }


        public async Task<bool> UpdateHotel(Hotel hotel)
        {
            try
            {
                _context.Entry(hotel).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while updating hotel.", ex);
            }
        }

        public async Task<bool> DeleteHotel(int id)
        {
            try
            {
                var hotel = await _context.Hotels.FindAsync(id);
                if (hotel == null)
                    return false;

                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while deleting hotel.", ex);
            }
        }
    }
}
