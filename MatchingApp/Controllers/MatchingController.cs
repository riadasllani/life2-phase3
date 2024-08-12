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
            if (filters == null) return BadRequest();

            var users = await _db.Set<User>().Where(u => u.Age >= filters.FromAge && u.Age <= filters.ToAge && u.Active).ToListAsync();
 


            return Ok(users); // return the users
        }

        [HttpPost("Match")]
        public async Task<IActionResult> Match(int currentUserId, int otherUser, bool like) // true if it likes, false if it dislikes
        {
            // YOUR CODE HERE
            // Add record to the Match table, if the same user has liked the current user then
            // just update the is mutual column and return the message that it is a match
            // note the same endpoint will be used for dislike too, but if a user dislikes an other user which had already liked
            // the current one, than that row in the table should be deleted

            var isCurrentUserLiked = await _db.Set<Match>().Where(m => m.FirstUserId == otherUser && m.SecondUserId == currentUserId).FirstOrDefaultAsync();
            if (isCurrentUserLiked != null)
            {
                if (like)
                {
                    isCurrentUserLiked.IsMutual = true;
                    _db.Set<Match>().Update(isCurrentUserLiked);
                } else
                {
                    _db.Set<Match>().Remove(isCurrentUserLiked);
                }
                await _db.SaveChangesAsync();
                return Ok();
            }

            if (like)
            {

                var newMatch = new Match { FirstUserId = currentUserId, SecondUserId = otherUser, IsMutual = false, MatchDate = DateTime.Now };

                _db.Set<Match>().Add(newMatch);
                await _db.SaveChangesAsync();
            }


            return Ok();




        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(int senderId, int receiverId, string MessageContent)
        {
            // YOUR CODE HERE
            // User can send message only to the users with who it is matched
            // Save message to db
            var isMatched = _db.Set<Match>().Where(m => (m.FirstUserId == senderId && m.SecondUserId == receiverId && m.IsMutual) || (m.FirstUserId == receiverId && m.SecondUserId == senderId && m.IsMutual)).FirstOrDefaultAsync();

            if (isMatched != null)
            {
                var message = new Message
                {
                    MessageContent = MessageContent,
                    SenderId = senderId,
                    ReceiverId = receiverId,
                };

                _db.Set<Message>().Add(message);
                await _db.SaveChangesAsync();
                return Ok("Message Sent!");
            }

            return Ok("You aren't matched");

        }
    }
}
