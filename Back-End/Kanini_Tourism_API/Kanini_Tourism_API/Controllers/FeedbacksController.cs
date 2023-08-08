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
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbacksController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        // GET: api/Feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            try
            {
                var feedbacks = await _feedbackRepository.GetFeedbacks();
                if (!feedbacks.Any())
                    return NotFound();

                return feedbacks.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            try
            {
                var feedback = await _feedbackRepository.GetFeedback(id);
                if (feedback == null)
                    return NotFound();

                return feedback;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/Feedbacks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedback(int id, Feedback feedback)
        {
            try
            {
                if (id != feedback.FeedbackId)
                    return BadRequest();

                var success = await _feedbackRepository.UpdateFeedback(feedback);
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

        // POST: api/Feedbacks
        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
        {
            try
            {
                var createdFeedback = await _feedbackRepository.CreateFeedback(feedback);
                return CreatedAtAction("GetFeedback", new { id = createdFeedback.FeedbackId }, createdFeedback);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/Feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                var success = await _feedbackRepository.DeleteFeedback(id);
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
