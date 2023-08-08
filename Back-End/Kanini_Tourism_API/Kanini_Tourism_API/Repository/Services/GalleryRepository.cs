using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.Data;
using Microsoft.AspNetCore.Hosting;

namespace Kanini_Tourism_API.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GalleryRepository(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GetAllImages
        public IEnumerable<Gallery> GetAllImages()
        {
            return _context.Galleries.ToList();
        }

        // Post
        public async Task<Gallery> ImageUpload(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Invalid file");
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Gallery");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            var image = new Gallery
            {
                ImageUrl = fileName
            };

            _context.Galleries.Add(image);
            await _context.SaveChangesAsync();

            return image;
        }
    }
}
