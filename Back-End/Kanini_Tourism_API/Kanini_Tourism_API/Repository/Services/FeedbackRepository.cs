using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kanini_Tourism_API.Models;
using Kanini_Tourism_API.Models.Data;

namespace Kanini_Tourism_API.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacks()
        {
            try
            {
                return await _context.Feedbacks.ToListAsync();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving feedbacks.", ex);
            }
        }

        public async Task<Feedback> GetFeedback(int id)
        {
            try
            {
                return await _context.Feedbacks.FindAsync(id);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while retrieving feedback.", ex);
            }
        }

        public async Task<Feedback> CreateFeedback(Feedback feedback)
        {
            try
            {
                _context.Feedbacks.Add(feedback);
                await _context.SaveChangesAsync();
                return feedback;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while creating feedback.", ex);
            }
        }

        public async Task<bool> UpdateFeedback(Feedback feedback)
        {
            try
            {
                _context.Entry(feedback).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while updating feedback.", ex);
            }
        }

        public async Task<bool> DeleteFeedback(int id)
        {
            try
            {
                var feedback = await _context.Feedbacks.FindAsync(id);
                if (feedback == null)
                    return false;

                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                throw new Exception("Error while deleting feedback.", ex);
            }
        }
    }
}
