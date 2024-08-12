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

        // 1.Top N Active Users with Highest Credits:
        [HttpGet("GetActiveUsers")]
        public async Task<IActionResult> GetActiveUsers(int numberOfUsers)
        {
            try
            {
                var usersToReturn = await _db.Users.Where(x => x.Active == 1)
                    .OrderByDescending(x => x.Credits)
                    .Take(numberOfUsers)
                    .ToListAsync();

                return Ok(usersToReturn);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        //2. Average Credits by Gender:
        //You should calculate the average Credits first for both male and female users, then group the data by gender and compute the average.

        [HttpGet("AverageCreditsByGender")]
        public async Task<IActionResult> GetAverageCreditsByGender()
        {
            try
            {
                var averageForBothGenders = await _db.Users.AverageAsync(x => x.Credits);
                // var groupedData = await _db.Users.GroupBy(x => x.Gender).AverageAsync(x);
                
                // return Ok(new{averageForBothGenders, groupedData});
                return Ok();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        //3. Youngest and Oldest Active Users:
        // Identify the youngest and oldest Active users.
        [HttpGet("YoungestAndOldestActiveUsers")]
        public async Task<IActionResult> GetYoungestAndOldestActiveUsers()
        {
            try
            {
                var oldestActiveUser = await _db.Users.OrderByDescending(x => x.Age).FirstOrDefaultAsync();
                var youngestActiveUser = await _db.Users.OrderBy(x => x.Age).FirstOrDefaultAsync();

                return Ok($"Youngest Active User age: {youngestActiveUser.Age} and oldest active user age: {oldestActiveUser.Age}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        //4. Total Credits by Age Group:
        // Group users into age brackets (0-15, 15-30, 30-45, 45-60, 60-75, 75-90, 90-105). Then, calculate the total Credits for each age group.

        [HttpGet("TotalCreditsByAge")]
        public async Task<IActionResult> GetTotalCreditsByAge()
        {
            try
            {
                var groupedUsers = _db.Users.GroupBy(x => x.Age)
                    .ToDictionary(x => x.Key, x => x.Select(x => x.Credits)
                        .ToList())
                    .ToList();
                
               return Ok(groupedUsers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
