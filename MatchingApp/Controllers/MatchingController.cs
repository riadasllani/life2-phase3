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
        private readonly ApplicationDbContext  _context;

        public MatchingController(ILogger<MatchingController> logger,ApplicationDbContext context )
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(Filters filters)
        {
            var allUsers = await _context.Users.Where(u => u.Active && u.Age >= filters.FromAge && u.Age <= filters.ToAge)
                .ToListAsync();
            
            for(int i = 0; i < allUsers.Count && allUsers.Count < 100; i++)
            {
                
                var likedUsers = _context.Matches.Where(m => m.FirstUserId == allUsers[i].Id && m.IsMutual).ToList();
                if (likedUsers.Count > 0)
                {
                    allUsers[i].Matches = likedUsers;
                }
            }
            
            allUsers = allUsers.OrderBy(x => Guid.NewGuid()).ToList();

            return Ok(allUsers);
        }

        [HttpPost("Match")]
        public async Task<IActionResult> Match(int user1, int user2, bool like, bool mutal) // true if it likes, false if it dislikes
        {
            
            if (!like)
            {
                var match = _context.Matches.FirstOrDefault(m => m.FirstUserId == user2 && m.SecondUserId == user1);
                if (match != null)
                {
                    _context.Matches.Remove(match);
                    await _context.SaveChangesAsync();
                }
            }
            
            _context.Matches.Add(new Match
            {
                FirstUserId = user1,
                SecondUserId = user2,
                IsMutual = mutal,
                MatchDate = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(int user1, int user2, string message)
        {
            _context.Messages.Add(new Message
            {
                SenderId = user1,
                RecieverId = user2,
                Content = message,
                Date = DateTime.Now
            });

            return Ok();
        }
    }
}
