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

        public MatchingController(ILogger<MatchingController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(int userId, Filters filters)
        {
            // YOUR CODE HERE
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)
            var matchingUsers = _context.Matches
                .Where(match => match.FirstUserId == userId)
                .Select(match => new {UserId = match.FirstUserId})
                .ToList();

            var users = _context.Users
                .Where(user => (user.Age > filters.FromAge && user.Age < filters.ToAge)
                && user.Active)
                .OrderBy(user => matchingUsers)
                .ToListAsync();

            return Ok(users); // return the users
        }

        [HttpPost("Match")]
        public async Task<IActionResult> Match([FromBody] int currentUserId, int receiverId, bool like) // true if it likes, false if it dislikes
        {
            // YOUR CODE HERE
            // Add record to the Match table, if the same user has liked the current user then
            // just update the is mutual column and return the message that it is a match
            // note the same endpoint will be used for dislike too, but if a user dislikes an other user which had already liked
            // the current one, than that row in the table should be deleted

            var existingMatch = _context.Matches.
                Where(match => match.FirstUserId == currentUserId
                || match.SecondUserId == currentUserId).FirstOrDefault();

            if (existingMatch == null)
            {
                _context.Matches.Add(new Match { FirstUserId = currentUserId, SecondUserId = receiverId});
                _context.SaveChanges();

                return Ok("A new match was added!");
            }
            
            if(existingMatch.IsMatch && like)
            {
                existingMatch.IsMatch = like;
                _context.SaveChanges();
                return Ok("Is a match!");
            }

            _context.Remove(existingMatch);
            return Ok("You removed a match!");
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] int senderId, int receiverId, string messageContent)
        {
            // YOUR CODE HERE
            // User can send message only to the users with who it is matched
            // Save message to db
            var isMatch = _context.Matches
                .Where(match => match.SecondUserId == senderId && match.SecondUserId == receiverId && match.IsMatch ||
                match.SecondUserId == senderId && match.FirstUserId == receiverId && match.IsMatch).FirstOrDefault();

            if(isMatch == null)
            {
                return BadRequest("You are not match with the user!");
            }

            _context.Messages.Add(new Message()
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                MessageContent = messageContent,

            });
            _context.SaveChanges();

            return Ok();
        }
    }
}
