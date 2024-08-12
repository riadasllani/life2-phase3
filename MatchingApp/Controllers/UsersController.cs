using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("highest-score")]
        public async Task<IActionResult> GetTopActiveUsers(int numberOdUsers)
        {
           var users = _dbContext.Users.ToList();
            var result = users.AsEnumerable().Where(x => x.Active == true).OrderByDescending(x => x.Credits).Take(numberOdUsers).ToList();
            return Ok(result);
        }

        [HttpGet("average")]
        public async Task<IActionResult> AverageCreditsByGender()
        {
            var users = _dbContext.Users.ToList();
            var result = users.AsEnumerable(); //TODO
            return Ok();
        }


        [HttpGet("younges-oldest-active-users")]
        public async Task<IActionResult> YoungestOldestUsers()
        {
            var usersToResult = new List<User>();
            var users = _dbContext.Users.ToList();
            var oldest = users.Where(x => x.Active == true && x.Gender == "Male").OrderByDescending(x => x.Age).FirstOrDefault();
            var oldestFemale = users.Where(x => x.Active == true && x.Gender == "Female").OrderByDescending(x => x.Age).FirstOrDefault();
            var youngestMale = users.Where(x => x.Active == true && x.Gender == "Male").OrderBy(x => x.Age).FirstOrDefault();
            var youngestFemale =  users.Where(x => x.Active == true && x.Gender == "Female").OrderBy(x => x.Age).FirstOrDefault();

            usersToResult.Add(oldest);
            usersToResult.Add(oldestFemale);
            usersToResult.Add(youngestMale);
            usersToResult.Add(youngestFemale);

            //Sorry for this bad code

            return Ok(usersToResult);
        }

        [HttpGet("total-credits-for-age-group")]
        public async Task<IActionResult> CreditsAgeBrackets()
        {
            return Ok();
        }
        // YOUR CODE HERE
        // Here you will have to create 4 endpoints based on these requirements
        /*
         * 
         
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
