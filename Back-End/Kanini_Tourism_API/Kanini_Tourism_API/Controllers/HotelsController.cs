using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Repositories;
using Kanini_Tourism_API.Repository.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Kanini_Tourism_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelsController(IHotelRepository hotelRepository, IWebHostEnvironment webHostEnvironment)
        {
            _hotelRepository = hotelRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Hotels
        [HttpGet]
        public IActionResult GetHotels()
        {
            var images = _hotelRepository.GetHotels();
            if (images == null)
            {
                return NotFound();
            }

            var imageList = new List<Hotel>();
            foreach (var image in images)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Hotel");
                var filePath = Path.Combine(uploadsFolder, image.HotelImageUrl);

                var imageBytes = System.IO.File.ReadAllBytes(filePath);
                var Data = new Hotel
                {
                     

                    HotelName = image.HotelName,
                    HotelLocation = image.HotelLocation,
                    HotelId = image.HotelId,
                    Description= image.Description,
                    Address= image.Address,
                    ContactInfo= image.ContactInfo,

                    HotelImageUrl = Convert.ToBase64String(imageBytes)
                };

                imageList.Add(Data);
            }

            return new JsonResult(imageList);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            try
            {
                var hotel = await _hotelRepository.GetHotel(id);
                if (hotel == null)
                    return NotFound();

                return hotel;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            try
            {
                if (id != hotel.HotelId)
                    return BadRequest();

                var success = await _hotelRepository.UpdateHotel(hotel);
                if (!success)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //// POST: api/Hotels
        //[HttpPost]
        //public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel,IFormFile imageFile)
        //{
        //    try
        //    {
        //        var createdHotel = await _hotelRepository. CreateHotel(hotel,imageFile);
        //        return CreatedAtAction("GetHotel", new { id = createdHotel.HotelId }, createdHotel);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception here or log the error
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Hotel tour, IFormFile imageFile)
        {
            try
            {
                var uploadedImage = await _hotelRepository.CreateHotel(tour, imageFile);
                return CreatedAtAction("Post", uploadedImage);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

                // DELETE: api/Hotels/5
                [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            try
            {
                var success = await _hotelRepository.DeleteHotel(id);
                if (!success)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
