using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Components.Forms;
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

        public UsersController(ILogger<UsersController> logger,ApplicationDbContext dbContext)
        {
            _logger = logger;

            _dbContext = dbContext;
        }



        public async Task<IActionResult> HighestCreditUsers()
        {
            var users = await _dbContext.Users.OrderByDescending(u => u.Credits).Where(u => u.IsActive == true).FirstOrDefaultAsync();

            return Ok(users);

        }

        public async Task<IActionResult> Youngest_Oldest()
        {
            var oldest = await _dbContext.Users.OrderByDescending(u => u.Age).Where(u => u.IsActive == true).Take(1).FirstOrDefaultAsync();
            var youngest = await _dbContext.Users.OrderBy(u => u.Age).Where(u => u.IsActive == true).Take(1).FirstOrDefaultAsync();

            List<User> users = new List<User>();

            users.Add(oldest);
            users.Add(youngest);

            return Ok(users);

           
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
    }
}
