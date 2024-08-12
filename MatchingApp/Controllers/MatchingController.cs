using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using MatchingApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchingController : ControllerBase
    {
        private readonly ILogger<MatchingController> _logger;
        private readonly IMatchingService _matchingService;

        public MatchingController(ILogger<MatchingController> logger, IMatchingService matchingService)
        {
            _logger = logger;
            _matchingService = matchingService;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await _matchingService.GetAllUsersAsync();
            return Ok(result); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _matchingService.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Entities.Match match)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _matchingService.AddAsync(match);
            return CreatedAtAction(nameof(GetById), new { id = match.Id }, match);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Models.Entities.Match match)
        {
            if (id != match.Id)
                return BadRequest("ID mismatch");

            await _matchingService.UpdateAsync(match);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _matchingService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _matchingService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("Match")]
        public async Task<IActionResult> Match(bool like, [FromBody] Models.Entities.Match match) // true if it likes, false if it dislikes
        {
            await _matchingService.AddAsync(match);

            return Ok();
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(int userId, Models.Entities.Match match)
        {
            await _matchingService.AddAsync(match);

            return Ok();
        }
    }
}
