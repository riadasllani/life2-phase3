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
        [HttpGet("Top-N-Users")]
        public async Task<IActionResult> GetTopNUsers(int N)
        {

            var users =  _db.Set<User>().Where( u => u.Active).OrderByDescending(u => u.Credits).Take(N);
            return Ok(users);
        }

        [HttpGet("AverageCredits")]
         public async Task<IActionResult> GetAverageCreditsByGender()
        {
            var users = _db.Set<User>().GroupBy(u => u.Gender).Select(g => new
            {
                gender = g.Key,
                avgCredits = g.Average(u => u.Credits)
            });

            return Ok(users);
        }


        [HttpGet("YoungOld")]
        public async Task<IActionResult> GetYoungOld()
        {
            var oldUser = await _db.Set<User>().Where(u => u.Active).OrderByDescending(u => u.Age).FirstOrDefaultAsync();

            var youngUser = await  _db.Set<User>().Where(u => u.Active).OrderByDescending(u => u.Age).LastOrDefaultAsync();

            return Ok($"Oldest user is: {oldUser.Id} with age: {oldUser.Age}, youngest one is: {youngUser.Id} with age: {youngUser.Age}");
        }

        /*[HttpGet("TotalCredits")]
        public async Task<IActionResult> GetTotalcredits()
        {
            var oldUser = await _db.Set<User>().Where(u => u.Active).GroupBy(x => x.Age < 50).Select(g => new
            {
                age = g.Key,
                avg = g.Sum(u => u.Credits)
            }).ToListAsync();

            return Ok(oldUser);
        }*/


    }
}
