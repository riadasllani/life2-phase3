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

        private readonly ApplicationDbContext _dbContext;

        public MatchingController(ILogger<MatchingController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost("GetUsers")]
        public async Task<IActionResult> GetUsers(Filters filters)
        {
            // YOUR CODE HERE
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)

            var users = await _dbContext.Users.Where(x => x.Age < filters.ToAge && x.Age > filters.FromAge).ToListAsync();

            return Ok(users); // return the users
        }

        [HttpPost("Match/{currentUserId}/{userToLikeId}")]
        public async Task<IActionResult> Match(bool like, long currentUserId, long userToLikeId) // true if it likes, false if it dislikes
        {
            // YOUR CODE HERE
            // Add record to the Match table, if the same user has liked the current user then
            // just update the is mutual column and return the message that it is a match
            // note the same endpoint will be used for dislike too, but if a user dislikes an other user which had already liked
            // the current one, than that row in the table should be deleted

            var currentUser = await _dbContext.Users.Where(x => x.Id == currentUserId).FirstOrDefaultAsync();

            var userToLike = await _dbContext.Users.Where(x => x.Id == userToLikeId).FirstOrDefaultAsync();

            //var match = await _dbContext.Matches.Where(x => x.UserLikeId == currentUserId && x.LikedUserId == userToLikeId).FirstOrDefaultAsync();

            var match = await _dbContext.Matches.Where(x => x.UserLikeId == userToLikeId && x.LikedUserId == currentUserId).FirstOrDefaultAsync();

            if(match != null && like)
            {
                match.IsMutual = true;

                await _dbContext.SaveChangesAsync();
            }

            else if (match == null && like) 
            {
                var newMatch = new Match
                {
                    IsMutual = false,
                    Date = DateTime.UtcNow,
                    UserLike = currentUser,
                    UserLikeId = currentUser.Id,
                    LikedUser = userToLike,
                    LikedUserId = userToLike.Id
                };

                _dbContext.Matches.Add(newMatch);
            }else
            {
                if(match != null)
                    _dbContext.Matches.Remove(match);
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("SendMessage/{currentUserId}")]
        public async Task<IActionResult> SendMessage(long userId, long currentUserId)
        {
            // YOUR CODE HERE
            // User can send message only to the users with who it is matched
            // Save message to db

            return Ok();
        }
    }
}
