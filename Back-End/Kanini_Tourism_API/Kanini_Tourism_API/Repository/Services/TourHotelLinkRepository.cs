using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.Data;

namespace Kanini_Tourism_API.Repositories
{
    public class TourHotelLinkRepository : ITourHotelLinkRepository
    {
        private readonly AppDbContext _context;

        public TourHotelLinkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TourHotelLink>> GetTourHotelLinks()
        {
            try
            {
                return await _context.tourHotelLinks.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving tour hotel links.", ex);
            }
        }

        public async Task<TourHotelLink> GetTourHotelLink(int id)
        {
            try
            {
                return await _context.tourHotelLinks.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving tour hotel link.", ex);
            }
        }

        public async Task<TourHotelLink> CreateTourHotelLink(TourHotelLink tourHotelLink)
        {
            try
            {
                _context.tourHotelLinks.Add(tourHotelLink);
                await _context.SaveChangesAsync();
                return tourHotelLink;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while creating tour hotel link.", ex);
            }
        }

        public async Task<bool> UpdateTourHotelLink(TourHotelLink tourHotelLink)
        {
            try
            {
                _context.Entry(tourHotelLink).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while updating tour hotel link.", ex);
            }
        }

        public async Task<bool> DeleteTourHotelLink(int id)
        {
            try
            {
                var tourHotelLink = await _context.tourHotelLinks.FindAsync(id);
                if (tourHotelLink == null)
                    return false;

                _context.tourHotelLinks.Remove(tourHotelLink);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while deleting tour hotel link.", ex);
            }
        }
    }
}
