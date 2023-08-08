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
    public class TravelAgentsController : ControllerBase
    {
        private readonly ITravelAgentRepository _travelAgentRepository;

        public TravelAgentsController(ITravelAgentRepository travelAgentRepository)
        {
            _travelAgentRepository = travelAgentRepository;
        }

        // GET: api/TravelAgents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelAgent>>> GetTravelAgents()
        {
            try
            {
                var travelAgents = await _travelAgentRepository.GetTravelAgents();
                if (!travelAgents.Any())
                    return NotFound();

                return travelAgents.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/TravelAgents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelAgent>> GetTravelAgent(int id)
        {
            try
            {
                var travelAgent = await _travelAgentRepository.GetTravelAgent(id);
                if (travelAgent == null)
                    return NotFound();

                return travelAgent;
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT: api/TravelAgents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelAgent(int id, TravelAgent travelAgent)
        {
            try
            {
                if (id != travelAgent.AgentId)
                    return BadRequest();

                var success = await _travelAgentRepository.UpdateTravelAgent(travelAgent);
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

        // POST: api/TravelAgents
        [HttpPost]
        public async Task<ActionResult<TravelAgent>> PostTravelAgent(TravelAgent travelAgent)
        {
            try
            {
                var createdTravelAgent = await _travelAgentRepository.CreateTravelAgent(travelAgent);
                return CreatedAtAction("GetTravelAgent", new { id = createdTravelAgent.AgentId }, createdTravelAgent);
            }
            catch (Exception ex)
            {
                // Handle exception here or log the error
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE: api/TravelAgents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelAgent(int id)
        {
            try
            {
                var success = await _travelAgentRepository.DeleteTravelAgent(id);
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
