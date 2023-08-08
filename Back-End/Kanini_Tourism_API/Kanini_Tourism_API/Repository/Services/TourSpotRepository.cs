using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.Data;

namespace Kanini_Tourism_API.Repositories
{
    public class TourSpotRepository : ITourSpotRepository
    {
        private readonly AppDbContext _context;

        public TourSpotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TourSpot>> GetTourSpots()
        {
            try
            {
                return await _context.tourSpots.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving tour spots.", ex);
            }
        }

        public async Task<TourSpot> GetTourSpot(int id)
        {
            try
            {
                return await _context.tourSpots.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving tour spot.", ex);
            }
        }

        public async Task<TourSpot> CreateTourSpot(TourSpot tourSpot)
        {
            try
            {
                _context.tourSpots.Add(tourSpot);
                await _context.SaveChangesAsync();
                return tourSpot;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while creating tour spot.", ex);
            }
        }

        public async Task<bool> UpdateTourSpot(TourSpot tourSpot)
        {
            try
            {
                _context.Entry(tourSpot).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while updating tour spot.", ex);
            }
        }

        public async Task<bool> DeleteTourSpot(int id)
        {
            try
            {
                var tourSpot = await _context.tourSpots.FindAsync(id);
                if (tourSpot == null)
                    return false;

                _context.tourSpots.Remove(tourSpot);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while deleting tour spot.", ex);
            }
        }
    }
}
