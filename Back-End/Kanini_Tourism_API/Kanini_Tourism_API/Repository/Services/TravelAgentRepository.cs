using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.Data;

namespace Kanini_Tourism_API.Repositories
{
    public class TravelAgentRepository : ITravelAgentRepository
    {
        private readonly AppDbContext _context;

        public TravelAgentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TravelAgent>> GetTravelAgents()
        {
            try
            {
                return await _context.TravelAgents.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving travel agents.", ex);
            }
        }

        public async Task<TravelAgent> GetTravelAgent(int id)
        {
            try
            {
                return await _context.TravelAgents.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving travel agent.", ex);
            }
        }

        public async Task<TravelAgent> CreateTravelAgent(TravelAgent travelAgent)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == travelAgent.User.UserId);
                travelAgent.User = user;
                _context.TravelAgents.Add(travelAgent);
                await _context.SaveChangesAsync();
                return travelAgent;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while creating travel agent.", ex);
            }
        }

        public async Task<bool> UpdateTravelAgent(TravelAgent travelAgent)
        {
            try
            {
                _context.Entry(travelAgent).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while updating travel agent.", ex);
            }
        }

        public async Task<bool> DeleteTravelAgent(int id)
        {
            try
            {
                var travelAgent = await _context.TravelAgents.FindAsync(id);
                if (travelAgent == null)
                    return false;

                _context.TravelAgents.Remove(travelAgent);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while deleting travel agent.", ex);
            }
        }
    }
}
