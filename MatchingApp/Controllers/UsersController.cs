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
        private readonly ApplicationDbContext _db;

        public UsersController(ILogger<UsersController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
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

        [HttpGet("TopActiveUsers")]
        public async Task<IActionResult> TopActiveUsers(int n) {

            var result = await _db.Set<User>().Where(x => x.Active == true).GroupBy(x => x.Credits).Select(x => new { User = x.Key , Count = x.Count()}).OrderByDescending(x => x.Count).Take(n).ToListAsync();

            return Ok(result);
        }



        /*Active Users from youngest to oldest*/
        [HttpGet("YoungestAndOldestActiveUsers")]

        public async Task<IActionResult> YoungestAndOldestActiveUsers()
        {

            var result = await _db.Set<User>().Where(x => x.Active == true).OrderBy(x => x.Age).ToListAsync();

            return Ok(result);
        }

        [HttpGet("AverageCreditsbyGender")]

        public async Task<IActionResult> AverageCreditsbyGender()
        {
            /*Average of credits for all users*/
            var average = _db.Set<User>().Average(x => x.Credits);

            var result = await _db.Set<User>().GroupBy(x => x.Gender).Select(x => new { Gender = x.Key, Average = x.Average(c => c.Credits) }).ToListAsync();

            return Ok(result);
        }



    }
}
