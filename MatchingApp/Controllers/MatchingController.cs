using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchingController : ControllerBase
    {
        private readonly ILogger<MatchingController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public MatchingController(ILogger<MatchingController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(Filters filters)
        {
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
            // YOUR CODE HERE
            // User can send message only to the users with who it is matched
            // Save message to db
            var senderId = 1232;
            var isMatched = _dbContext.Matches.Where(x => x.UserLikedId == senderId && x.UserGotLikedId == userId).Select(x => x.IsMutual);
            if (isMatched)
            {
                var message = new Message
                {
                    RecieverId = userId,
                    SenderId = senderId,
                    Content = "Message",
                    SentTime = DateTime.Now
                };

                _dbContext.Add(message);
            }

            return Ok();
        }
    }
}
