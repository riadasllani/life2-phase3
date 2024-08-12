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
        private readonly ApplicationDbContext _applicationDbContext;

        public MatchingController(ILogger<MatchingController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(Filters filters)
        {
            // YOUR CODE HERE
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)

            var users = _applicationDbContext.Users.Where(e => e.Active);

            

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
            var currentUserId = "2"; //get from http context

          

            return Ok();
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(int userId)
        {
            // YOUR CODE HERE
            // User can send message only to the users with who it is matched
            // Save message to db
            var sender = "1";

            var isMatched = _applicationDbContext.Matches.Where(e => e.UserWhoLiked == userId.ToString() && e.UserWhoWasLiked == sender && e.IsMutual).Any();
            if (isMatched)
            {
                // get from http context
                var message = new Message
                {
                    Sender = sender,
                    Receiver = userId.ToString(),
                    MessageContent = "http",
                    DateCreated = DateTime.Now
                };

                _applicationDbContext.Messages.Add(message);
                _applicationDbContext.SaveChanges();
                return Ok("Mesage sent");
            }
            return BadRequest("Message could not be send");      
        }
    }
}
