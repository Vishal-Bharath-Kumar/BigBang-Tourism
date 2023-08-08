using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Kanini_Tourism_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
            private readonly ITour _user;
            private readonly IWebHostEnvironment _webHostEnvironment;
            public TourController(ITour user, IWebHostEnvironment webHostEnvironment)
            {
                _user = user;
                _webHostEnvironment = webHostEnvironment;
            }


            [HttpGet]
            public IActionResult GetAllImages()
            {
                var images = _user.GetAllTours();
                if (images == null)
                {
                    return NotFound();
                }

                var imageList = new List<Tour>();
                foreach (var image in images)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Tour");
                    var filePath = Path.Combine(uploadsFolder, image.TourImageUrl);

                    var imageBytes = System.IO.File.ReadAllBytes(filePath);

                    var tourPackageData = new Tour
                    {
                        TourId = image.TourId,
                        TourName = image.TourName,
                        TourPrice = image.TourPrice,
                        TourLocation = image.TourLocation,
                        Description = image.Description,
                        TourImageUrl = Convert.ToBase64String(imageBytes)
                    };

                    imageList.Add(tourPackageData);
                }

                return new JsonResult(imageList);
            }


            [HttpGet("{id}")]
            public IActionResult GetTourById(int id)
            {
                var tourPackage = _user.GetTourById(id);
                if (tourPackage == null)
                {
                    return NotFound();
                }

                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Packages");
                var filePath = Path.Combine(uploadsFolder, tourPackage.TourImageUrl);

                var imageBytes = System.IO.File.ReadAllBytes(filePath);

                var tourPackageData = new Tour
                {
                    TourId = tourPackage.TourId,
                    TourName = tourPackage.TourName,
                    TourPrice = tourPackage.TourPrice,
                    TourLocation = tourPackage.Description,
                    TourImageUrl = Convert.ToBase64String(imageBytes)
                };

                return new JsonResult(tourPackageData);
            }


            [HttpPost]
            public async Task<IActionResult> Post([FromForm] Tour tour, IFormFile imageFile)
            {
                try
                {
                    var uploadedImage = await _user.CreateTour(tour, imageFile);
                    return CreatedAtAction("Post", uploadedImage);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Tour>> Put(int id, [FromForm] Tour tour, IFormFile imageFile)
            {
                try
                {
                    tour.TourId = id;
                    var updatedTour = await _user.UpdateTour(id,tour, imageFile);
                    return Ok(updatedTour);
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return BadRequest(ModelState);
                }
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<List<Tour>>> DeleteTourById(int id)
            {
                var users = await _user.DeleteTourById(id);
                if (users is null)
                {
                    return NotFound("package not matching");
                }
                return Ok(users);
            }

        }
    }
