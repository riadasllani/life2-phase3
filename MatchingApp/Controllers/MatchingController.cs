using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using MatchingApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchingController : ControllerBase
    {
        private readonly ILogger<MatchingController> _logger;
        private readonly IUserService _userService;
        private readonly IMatchingService _matchingService;

        public MatchingController(ILogger<MatchingController> logger, IUserService userService, IMatchingService matchingService)
        {
            _logger = logger;
            _userService = userService;
            _matchingService = matchingService;
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(Filters filters)
        {
            var data = await _matchingService.GetAllAsync(filters);
            return Ok(data);
            // YOUR CODE HERE
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)

            return Ok(); // return the users
        }

        [HttpPost("Match")]
        public async Task<IActionResult> Match(bool like) // true if it likes, false if it dislikes
        {

            // YOUR CODE HERE
            // Add record to the Match table, if the same user has liked the current user then
            // just update the is mutual column and return the message that it is a match
            // note the same endpoint will be used for dislike too, but if a user dislikes an other user which had already liked
            // the current one, than that row in the table should be deleted

            return Ok();
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(int userId)
        {
           // var message = _userService.AddAsync();

            return Ok();
        }
    }
}
