using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Repositories;
using Kanini_Tourism_API.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Kanini_Tourism_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : ControllerBase
    {
        private readonly IGalleryRepository _galleryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GalleriesController(IGalleryRepository galleryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _galleryRepository = galleryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult GetAllImages()
        {
            var images = _galleryRepository.GetAllImages();
            if (images == null)
            {
                return NotFound();
            }

            var imageList = new List<FileContentResult>();
            foreach (var image in images)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Gallery");
                var filePath = Path.Combine(uploadsFolder, image.ImageUrl);

                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                imageList.Add(File(imageBytes, "image/jpeg"));
            }

            return new JsonResult(imageList);
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile imageFile)
        {
            try
            {
                var uploadedImage = await _galleryRepository.ImageUpload(imageFile);
                return CreatedAtAction("Post", uploadedImage);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
