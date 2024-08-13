using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ApplicationDbContext _context;

        public UsersController(ILogger<UsersController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet("TopActiveUsersWithHighestCredits")]
        public async Task<IActionResult> TopUsers(int n)
        {
            var users = await _context.Users
                .Where(u => u.Active)
                .OrderByDescending(u => u.Credits)
                .Take(n)
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("AverageCreditsByGender")]
        public async Task<IActionResult> AverageCreditsByGender()
        {
            var males = await _context.Users.Where(u => u.Gender == "Male").ToListAsync();
            var females = await _context.Users.Where(u => u.Gender == "Female").ToListAsync();

            var averageMaleCredits = 0.0;
            var averageFemaleCredits = 0.0;
            for (int i = 0; i < males.Count; i++)
            {
                averageMaleCredits += males[i].Credits;
            }
            
            for (int i = 0; i < females.Count; i++)
            {
                averageFemaleCredits += females[i].Credits;
            }

            averageMaleCredits = averageMaleCredits / males.Count;
            averageFemaleCredits = averageFemaleCredits / females.Count;
            
            return Ok(new {averageMaleCredits, averageFemaleCredits});
        }
        
        [HttpGet("YoungestAndOldestActiveUsers")]
        public async Task<IActionResult> YoungestAndOldestActiveUsers()
        {
            var users = await _context.Users.Where(u => u.Active).ToListAsync();
            var youngest = users[0];
            var oldest = users[0];
            for (int i = 1; i < users.Count; i++)
            {
                if (users[i].Age > youngest.Age)
                {
                    youngest = users[i];
                }

                if (users[i].Age < oldest.Age)
                {
                    oldest = users[i];
                }
            }

            return Ok(new {youngest, oldest});
        }
        
        [HttpGet("TotalCreditsByAgeGroup")]
        public async Task<IActionResult> TotalCreditsByAgeGroup()
        {
            var users = await _context.Users.ToListAsync();
            var ageGroups = new List<int> {0, 0, 0, 0, 0, 0, 0};
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Age <= 15)
                {
                    ageGroups[0] += users[i].Credits;
                }
                else if (users[i].Age <= 30)
                {
                    ageGroups[1] += users[i].Credits;
                }
                else if (users[i].Age <= 45)
                {
                    ageGroups[2] += users[i].Credits;
                }
                else if (users[i].Age <= 60)
                {
                    ageGroups[3] += users[i].Credits;
                }
                else if (users[i].Age <= 75)
                {
                    ageGroups[4] += users[i].Credits;
                }
                else if (users[i].Age <= 90)
                {
                    ageGroups[5] += users[i].Credits;
                }
                else
                {
                    ageGroups[6] += users[i].Credits;
                }
            }

            return Ok(ageGroups);
        }
    }
    
}
