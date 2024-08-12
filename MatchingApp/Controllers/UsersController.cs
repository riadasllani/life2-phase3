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
        private readonly ApplicationDbContext _applicationDbContext;

        public UsersController(ILogger<UsersController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet("GetUsersByCredits/{n}")]
        public async Task<ActionResult> GetUsersByCredits(int n)
        {
            var users = await _applicationDbContext.Users.Where(x => x.Active == true).OrderByDescending(x => x.Credits).Take(n).ToListAsync();

            return Ok(users);
        }

        [HttpGet("GetUsersByGender")]
        public async Task<ActionResult> GetUsersByGender()
        {
            var femaleAverage = _applicationDbContext.Users.Where(x => x.Gender == "Female").Average(x => x.Credits);
            var maleAverage = _applicationDbContext.Users.Where(x => x.Gender == "Male").Average(x => x.Credits);

            List<double> users = new();

            users.Add(femaleAverage);
            users.Add(maleAverage);

            return Ok(users);
        }

        [HttpGet("GetUsersByAge")]
        public async Task<ActionResult> GetUsersByAge()
        {
            List<User> users = new();

            var youngest = await _applicationDbContext.Users.Where(x => x.Active == true).OrderBy(x => x.Age).Take(1).FirstOrDefaultAsync();
            var oldest = await _applicationDbContext.Users.Where(x => x.Active == true).OrderByDescending(x => x.Age).Take(1).FirstOrDefaultAsync();

            users.Add(youngest);
            users.Add(oldest);

            return Ok(users);
        }

        /*[HttpGet("GetUsersByAgeGroup")]
        public async Task<ActionResult> GetUsersByAgeGroup()
        {
            var users1 = await _applicationDbContext.Users.Where(x => x.Age >= 0 && x.Age <= 15).GroupBy(x => x.Age).ToListAsync();
            var users2 = await _applicationDbContext.Users.Where(x => x.Age >=15 && x.Age <= 30).GroupBy(x => x.Age).ToListAsync();
            var users3 = await _applicationDbContext.Users.Where(x => x.Age >= 30 && x.Age <= 45).GroupBy(x => x.Age).ToListAsync();
            var users4 = await _applicationDbContext.Users.Where(x => x.Age >= 45 && x.Age <= 60).GroupBy(x => x.Age).ToListAsync();
            var users5 = await _applicationDbContext.Users.Where(x => x.Age >= 60 && x.Age <= 75).GroupBy(x => x.Age).ToListAsync();
            var users6 = await _applicationDbContext.Users.Where(x => x.Age >= 75 && x.Age <= 90).GroupBy(x => x.Age).ToListAsync();
            var users7 = await _applicationDbContext.Users.Where(x => x.Age >= 90 && x.Age <= 105).GroupBy(x => x.Age).ToListAsync();

            var avg = _applicationDbContext.Users.

        }*/

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
    }
}
