using System.Security.Claims;
using MatchingApp.Models.Dtos;
using MatchingApp.Services.Matching;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [Authorize]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(Filters filters)
        {
            // YOUR CODE HERE
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var users = await _matchingService.GetUsers(filters, userId);
            return Ok(users); // return the users
        }

        [Authorize]
        [HttpPost("Match")]
        public async Task<IActionResult> Match(string userId, bool like) // true if it likes, false if it dislikes
        {
            // Add record to the Match table, if the same user has liked the current user then
            // just update the is mutual column and return the message that it is a match
            // note the same endpoint will be used for dislike too, but if a user dislikes an other user which had already liked
            // the current one, than that row in the table should be deleted
            var loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await _matchingService.Match(userId, loggedUserId, like);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }

        [Authorize]
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(string userId, string content)
        {
            // User can send message only to the users with who it is matched
            // Save message to db

            var loggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await _matchingService.Message(userId, loggedUserId, content);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
