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
        private readonly ApplicationDbContext _db;

        public MatchingController(ILogger<MatchingController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(Filters filters)
        {
            // YOUR CODE HERE
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)
            var users = await _db.Users
                .Where(x => x.Active == 1 && x.Age >= filters.FromAge && x.Age <= filters.FromAge)
                .Include(x => x.Match)
                .ThenInclude(x => x.Liker)
                .ToListAsync();
            
            return Ok(users); // return the users
        }

        [HttpPost("Match")]
        public async Task<IActionResult> Match(bool like, int userId, int friendId) // true if it likes, false if it dislikes
        {
            // YOUR CODE HERE
            // Add record to the Match table, if the same user has liked the current user then
            // just update the is mutual column and return the message that it is a match
            // note the same endpoint will be used for dislike too, but if a user dislikes an other user which had already liked
            // the current one, than that row in the table should be deleted
            var user = await _db.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            var matchExist = await _db.Matches.Where(x => x.LikedId == userId || x.LikerId == userId)
                .FirstOrDefaultAsync();

            if (matchExist.LikedId == userId && like)
            {
                matchExist.Mutual = true;
                return Ok("Its a match");

            }
            else if (matchExist.LikedId == userId && !like)
            { 
                _db.Matches.Remove(matchExist);
            }
            {
                matchExist.Mutual = like;
            }
            await _db.SaveChangesAsync();
            return BadRequest();
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(int userId, int friendId, string message)
        {
            // YOUR CODE HERE
            // User can send message only to the users with who it is matched
            // Save message to db
            var sender = await _db.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            var match = await _db.Matches.Where(x => (x.LikerId == userId) || (x.LikedId == userId) && x.Mutual)
                .AnyAsync();
            if (match)
            {
                var messageToCreate = new Message()
                {
                    Sender = sender.Id,
                    Receiver = friendId,
                    Date = DateTime.UtcNow,
                    Content = message
                };

                await _db.Messages.AddAsync(messageToCreate);
                await _db.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
