using MatchingApp.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        
        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        [HttpGet("highest-credits")]
        public async Task<IActionResult> HighestCredits(int count)
        {
            var users = await _userService.HighestCredits(count);
            
            return Ok(users);
        }
        
        [HttpGet("average-credits")]
        public async Task<IActionResult> AverageCreditsByGender()
        {
            var average  = await _userService.AverageCreditsByGender();
            
            return Ok(average);
        }
        
        [HttpGet("youngest-oldest-users")]
        public async Task<IActionResult> YoungestOldestUsers()
        {
            var youngestOldest = await _userService.YoungestOldestUsers();
            
            return Ok(youngestOldest);
        }
        
        [HttpGet("total-credits")]
        public async Task<IActionResult> TotalCreditsByAgeGroup()
        {
            var totalByAge = _userService.TotalCreditsByAgeGroup();
            
            return Ok(totalByAge);
        }
        
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
