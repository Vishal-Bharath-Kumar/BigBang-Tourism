using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.Data;

namespace Kanini_Tourism_API.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            try
            {
                return await _context.Bookings.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving bookings.", ex);
            }
        }

        public async Task<Booking> GetBooking(int id)
        {
            try
            {
                return await _context.Bookings.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving booking.", ex);
            }
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            try
            {
                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();
                return booking;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while creating booking.", ex);
            }
        }

        public async Task<bool> UpdateBooking(Booking booking)
        {
            try
            {
                _context.Entry(booking).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while updating booking.", ex);
            }
        }

        public async Task<bool> DeleteBooking(int id)
        {
            try
            {
                var booking = await _context.Bookings.FindAsync(id);
                if (booking == null)
                    return false;

                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while deleting booking.", ex);
            }
        }
    }
}
