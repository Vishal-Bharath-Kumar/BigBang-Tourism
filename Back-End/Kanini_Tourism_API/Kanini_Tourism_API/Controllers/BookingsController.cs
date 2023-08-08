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
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            try
            {
                var bookings = await _bookingRepository.GetBookings();
                if (!bookings.Any())
                    return NotFound();

                return bookings.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            try
            {
                var booking = await _bookingRepository.GetBooking(id);
                if (booking == null)
                    return NotFound();

                return booking;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            try
            {
                if (id != booking.BookingId)
                    return BadRequest();

                var success = await _bookingRepository.UpdateBooking(booking);
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

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            try
            {
                var createdBooking = await _bookingRepository.CreateBooking(booking);
                return CreatedAtAction("GetBooking", new { id = createdBooking.BookingId }, createdBooking);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                var success = await _bookingRepository.DeleteBooking(id);
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
