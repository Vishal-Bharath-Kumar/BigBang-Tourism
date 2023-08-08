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
    public class TourHotelLinksController : ControllerBase
    {
        private readonly ITourHotelLinkRepository _tourHotelLinkRepository;

        public TourHotelLinksController(ITourHotelLinkRepository tourHotelLinkRepository)
        {
            _tourHotelLinkRepository = tourHotelLinkRepository;
        }

        // GET: api/TourHotelLinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourHotelLink>>> GetTourHotelLinks()
        {
            try
            {
                var tourHotelLinks = await _tourHotelLinkRepository.GetTourHotelLinks();
                if (!tourHotelLinks.Any())
                    return NotFound();

                return tourHotelLinks.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/TourHotelLinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourHotelLink>> GetTourHotelLink(int id)
        {
            try
            {
                var tourHotelLink = await _tourHotelLinkRepository.GetTourHotelLink(id);
                if (tourHotelLink == null)
                    return NotFound();

                return tourHotelLink;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/TourHotelLinks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourHotelLink(int id, TourHotelLink tourHotelLink)
        {
            try
            {
                if (id != tourHotelLink.LinkId)
                    return BadRequest();

                var success = await _tourHotelLinkRepository.UpdateTourHotelLink(tourHotelLink);
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

        // POST: api/TourHotelLinks
        [HttpPost]
        public async Task<ActionResult<TourHotelLink>> PostTourHotelLink(TourHotelLink tourHotelLink)
        {
            try
            {
                var createdTourHotelLink = await _tourHotelLinkRepository.CreateTourHotelLink(tourHotelLink);
                return CreatedAtAction("GetTourHotelLink", new { id = createdTourHotelLink.LinkId }, createdTourHotelLink);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/TourHotelLinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourHotelLink(int id)
        {
            try
            {
                var success = await _tourHotelLinkRepository.DeleteTourHotelLink(id);
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
