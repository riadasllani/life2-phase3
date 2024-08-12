using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using MatchingApp.Services;
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetTopUsers(int page = 1, int pageSize = 5)
        {
            var users = _userService.GetTopUsersAsync(page, pageSize);
            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetYoungAndOldUsers(int page = 1, int pageSize = 5)
        {
            var users = _userService.GetYoungAndOldUsersAsync(page, pageSize);
            return Ok(users);
        }


    }
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