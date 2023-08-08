using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Repositories;

namespace Kanini_Tourism_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourSpotsController : ControllerBase
    {
        private readonly ITourSpotRepository _tourSpotRepository;

        public TourSpotsController(ITourSpotRepository tourSpotRepository)
        {
            _tourSpotRepository = tourSpotRepository;
        }

        // GET: api/TourSpots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourSpot>>> GetTourSpots()
        {
            try
            {
                var tourSpots = await _tourSpotRepository.GetTourSpots();
                if (!tourSpots.Any())
                    return NotFound();

                return tourSpots.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/TourSpots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourSpot>> GetTourSpot(int id)
        {
            try
            {
                var tourSpot = await _tourSpotRepository.GetTourSpot(id);
                if (tourSpot == null)
                    return NotFound();

                return tourSpot;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/TourSpots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourSpot(int id, TourSpot tourSpot)
        {
            try
            {
                if (id != tourSpot.SpotId)
                    return BadRequest();

                var success = await _tourSpotRepository.UpdateTourSpot(tourSpot);
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

        // POST: api/TourSpots
        [HttpPost]
        public async Task<ActionResult<TourSpot>> PostTourSpot(TourSpot tourSpot)
        {
            try
            {
                var createdTourSpot = await _tourSpotRepository.CreateTourSpot(tourSpot);
                return CreatedAtAction("GetTourSpot", new { id = createdTourSpot.SpotId }, createdTourSpot);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/TourSpots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourSpot(int id)
        {
            try
            {
                var success = await _tourSpotRepository.DeleteTourSpot(id);
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
