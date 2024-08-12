using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using MatchingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest("ID mismatch");

            await _userService.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _userService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task TopNActiveUsers()
        {

        }
        [HttpGet]
        public async Task AverageCreditsByGenderAsync()
        {

        }
        [HttpGet]
        public async Task YoungestOldestActiveUsersAsync()
        {

        }
        [HttpGet]
        public async Task TotalCreditsByAgeGroup()
        {

        }
    }
}

