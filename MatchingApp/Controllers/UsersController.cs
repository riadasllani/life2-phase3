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

        [HttpGet("TopActiveUserWithHighestCredit/{numberOfResponses}")]
        public async Task<IActionResult> GetTopActiveUserWithHighestCredits(int numberOfResponses = 5)
        {
            var users = _context.Users.
                Where(user => user.Active)
                .OrderByDescending(user => user.Credits)
                .Take(numberOfResponses)
                .ToList();

            return Ok(users);
        }

        [HttpGet("CreditsByGender")]
        public async Task<IActionResult> GetCreditsByGenders()
        {

        }

        [HttpGet("YoungestAndOldestActiveUsers")]
        public async Task<IActionResult> GetYoungestAndOldestActiveUsers()
        {
            var oldestUser = _context.Users.OrderByDescending(user => user.Age).FirstOrDefault;
            var youngestUser = _context.Users.OrderBy(user => user.Age).FirstOrDefault;

            var users = new {Olser}
            return Ok();
        }

        [HttpGet("TotalCreditsByAgeGroup")]
        public async Task<IActionResult> GetTotalCreditsByAgeGroup()
        {

        }
    }
}
