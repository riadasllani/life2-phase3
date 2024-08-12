using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Top-N-Active-Users")]
        public async Task<IActionResult> GetActiveUsers(int n)
        {
            var topNUsers = _context.Users.Where(u => u.IsActive).OrderByDescending(u => u.Credits).Take(n).ToList();

            _logger.LogInformation("Got top n users.");
            return Ok(topNUsers);
        }

        [HttpGet("Youngest-Oldest")]
        public async Task<IActionResult> GetYoungestOldest()
        {
            var youngest = _context.Users.Where(u => u.IsActive).OrderBy(u => u.Age).FirstOrDefault();

            var oldest = _context.Users.Where(u => u.IsActive).OrderByDescending(u => u.Age).FirstOrDefault();

            return Ok(new { youngestUser = youngest, oldestUser = oldest });
        }

        [HttpGet("Credits-By-Age")]
        public async Task<IActionResult> GetCreditsByAge()
        {
            var usersFirst = _context.Users.Where(u => u.Age > 0 && u.Age < 15).GroupBy(u => u.Age).Select(g => g.Sum(u =>  u.Credits)).First();
            var usersSecond = _context.Users.Where(u => u.Age > 15 && u.Age < 30).GroupBy(u => u.Age).Select(g => g.Sum(u => u.Credits)).First();
            var usersThird = _context.Users.Where(u => u.Age > 30 && u.Age < 45).GroupBy(u => u.Age).Select(g => g.Sum(u => u.Credits)).First();
            var usersFourth = _context.Users.Where(u => u.Age > 45 && u.Age < 65).GroupBy(u => u.Age).Select(g => g.Sum(u => u.Credits)).First();
            var usersFifth = _context.Users.Where(u => u.Age > 60 && u.Age < 75).GroupBy(u => u.Age).Select(g => g.Sum(u => u.Credits)).First();
            var usersSixth = _context.Users.Where(u => u.Age > 75 && u.Age < 90).GroupBy(u => u.Age).Select(g => g.Sum(u => u.Credits)).First();
            var usersSeventh = _context.Users.Where(u => u.Age > 90 && u.Age < 105).GroupBy(u => u.Age).Select(g => g.Sum(u => u.Credits)).First();

            var result = $"{usersFirst} {usersSecond} {usersThird} {usersFourth} {usersFifth} {usersSixth} {usersSeventh} ";

            return Ok(new { resultCredit = result});
        }

        [HttpGet("Average-Gender-Based")]
        public async Task<IActionResult> GetAverage()
        {
            var totalAvergage = _context.Users.GroupBy(u => u.Id).Select(g => g.Average(u => u.Credits));
            var averageByGender = _context.Users.GroupBy(u => u.Gender).Select(g => g.Average(u => u.Credits)).ToList();

            return Ok(new { genederBasedAvergae = averageByGender, totalAvergageNoGender = totalAvergage});
        }
    }
}
