using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository  _userRepository;
        private readonly ApplicationDbContext applicationDbContext;

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _userRepository = userRepository;
            this.applicationDbContext = applicationDbContext;
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

        public async Task<IEnumerable<User>> GetTopNActiveUsers()
        {
            var users = applicationDbContext.Users.Where(u => u.Active == true).OrderByDescending(c => c.Credits).Take(5).ToList();
            return users;
        }

        public async Task<IActionResult> GetAverageCredits()
        {
            var result = applicationDbContext.Users.GroupBy(s => s.Gender).Select(g => new { Gender = g.Key, Avg = g.Average(s => s.Credits) });
            return Ok(result);  
        }

        public async Task<IActionResult> GetUsers()
        {
            var users = applicationDbContext.Users.OrderBy(e => e.CreatedAt);
            var user1 = users.First();
            var user2 = users.Last();
            return Ok( (user1, user2));
        }

        public async Task<IActionResult> GetTotal()
        {
            //Needed to convert age to date time
           //  var users = applicationDbContext.Users.GroupBy(x => x.Age.AddYears(15).Date).Select( g => new {g.Key.AddYears(15), Value = g.Sum(e => e.Credits))
            return Ok();
        }

        

    }
}
