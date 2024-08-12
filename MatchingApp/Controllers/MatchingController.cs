using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Cache;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchingController : ControllerBase
    {
        private readonly ILogger<MatchingController> _logger;
        private readonly ApplicationDbContext _db;

        public MatchingController(ILogger<MatchingController> logger, ApplicationDbContext db )
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(Filters filters)
        {


           

            var result = await _db.Set<User>().Where(x => x.Active == true && (x.Age >= filters.FromAge && x.Age <= filters.ToAge)).ToListAsync();



            // YOUR CODE HERE
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)

            return Ok(result); // return the users
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
        public async Task<IActionResult> SendMessage(int userIdSender, int userIdReciever)
        {

            var result = await _db.Set<Match>().Where(x => x.FirstUserId == userIdSender && x.SecondUserId == userIdReciever).FirstOrDefaultAsync();

            if (result.IsMutual == true) {
                return Ok(result);
            }

            // YOUR CODE HERE
            // User can send message only to the users with who it is matched
            // Save message to db

            return Ok("Not Found");
        }
    }
}
