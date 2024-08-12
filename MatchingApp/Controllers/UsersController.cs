using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public UsersController(ILogger<UsersController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        // YOUR CODE HERE
        // Here you will have to create 4 endpoints based on these requirements
        /*
            1. Top N Active Users with Highest Credits:
            You should find the top N users (e.g., N = 5) with the highest Credits who are also Active. You should sort the data by Credits in descending order using LINQ.

            2. Average Credits by Gender:
            You should calculate the average Credits first for both male and female users, then group the data by gender and compute the average.

            3. Youngest and Oldest Active Users:
            Identify the youngest and oldest Active users.

            4. Total Credits by Age Group:
            Group users into age brackets (0-15, 15-30, 30-45, 45-60, 60-75, 75-90, 90-105). Then, calculate the total Credits for each age group.
         */

        [HttpGet("HighestCredit")]
        public async Task<IActionResult> GetUsersWithHighestCredit(int n)
        {
            var users = await _dbContext.Users.Where(x => x.Active).OrderByDescending(x => x.Credits).Take(n).ToListAsync();


            return Ok(users);
        }

        [HttpGet("average-credits-by-gender")]
        public async Task<IActionResult> GetAverageCreditsByGender()
        {
            var users = await _dbContext.Users
                .GroupBy(x => x.Gender)
                .Select(g => new
                {
                    Gender = g.Key,
                    Average = g.Average(x => x.Credits)
                }).ToListAsync();


            return Ok(users);
        }

        [HttpGet("youngest-oldest")]
        public async Task<IActionResult> GetYoungestAndOldest()
        {
            var youngestUser = await _dbContext.Users.Where(x => x.Active).OrderBy(x => x.Age).FirstOrDefaultAsync();

            var oldestUser = await _dbContext.Users.Where(x => x.Active).OrderByDescending(x => x.Age).FirstOrDefaultAsync();

            var response = new OldYoungDto
            {
                OldestUser = oldestUser,
                YoungestUser = youngestUser
            };

            return Ok(response);
        }

        [HttpGet("GroupByAge")]
        public async Task<IActionResult> GroupByAge()
        {

            var byAge = await _dbContext.Users.Where(x => x.Active).GroupBy(x => 15 * (x.Age / 15))
                .Select(s => new
                {
                    AgeGroup = $"{s.Key - 15} - {s.Key}",
                    TotalCreadit = s.Sum(x => x.Credits),
                }).ToListAsync();

            return Ok(byAge);
        }
    }
}
