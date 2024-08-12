using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchingController : ControllerBase
    {
        private readonly ILogger<MatchingController> _logger;
        private readonly ApplicationDbContext _context;

        public MatchingController(ILogger<MatchingController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers( [FromQuery] Filters filters)
        {
            var users = _context.Users
                .Select(x => x.IsActive == true && x.Age >= filters.FromAge && x.Age <= filters.ToAge).ToListAsync();
            
            
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)

            return Ok(users); // return the users
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
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto sendMessageDto)
        {
            var userIsMutual = _context.Matches.Where(x => x.LikedUser == sendMessageDto.SenderId && x.UserId == sendMessageDto.ReceiverId)
                .Select(x => x.UserId == sendMessageDto.SenderId).FirstOrDefault();
            if (userIsMutual)
            {
                var message = new Message()
                {
                    SenderId = sendMessageDto.SenderId,
                    ReceiverId = sendMessageDto.ReceiverId,
                    Content = sendMessageDto.Content,
                };
                _context.Messages.Add(message);
                
                return Ok("sent");
            }
            return BadRequest("Not Mutual friends");

        }
    }
}
