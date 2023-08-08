using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Tourism_API.Models;

namespace Kanini_Tourism_API.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task<Booking> GetBooking(int id);
        Task<Booking> CreateBooking(Booking booking);
        Task<bool> UpdateBooking(Booking booking);
        Task<bool> DeleteBooking(int id);
    }
}
