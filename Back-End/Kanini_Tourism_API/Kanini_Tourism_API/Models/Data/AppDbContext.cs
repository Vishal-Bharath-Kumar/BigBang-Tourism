using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace Kanini_Tourism_API.Models.Data
{


    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TravelAgent> TravelAgents { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        public DbSet<TourHotelLink> tourHotelLinks { get; set; }
        public DbSet<TourSpot> tourSpots { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // In the OnModelCreating method of AppDbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Other configurations...


        }


    }

}
