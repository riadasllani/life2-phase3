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

        private readonly ApplicationDbContext _context;
        public UsersController(ILogger<UsersController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet]

        public async Task<IActionResult> UsersWithHighestCredits()
        {
            var highestCredits = await _context.Users.Select(u => new GetUsersDto
            {
                Id = u.Id,
                Credits = u.Credits,
                IsActive = u.IsActive
            }).Where(u => u.IsActive == 1)
            .OrderByDescending(u => u.Credits)
            .Take(5)
            .ToListAsync();
            
            return Ok(highestCredits);
        }

        [HttpGet("gender")]

        public async Task<IActionResult> AverageCreditsbyGender()
        {
            var highestCredits = await _context.Users.Select(u => new GetUsersDto
            {
                Id = u.Id,
                Credits = u.Credits,
                IsActive = u.IsActive,
                Gender = u.Gender
            })
            .GroupBy(u => u.Gender)
            .Select(g => new AverageDto { Gender = g.Key, Credits = g.Average(s => s.Credits) })
            .ToListAsync();

            return Ok(highestCredits);
        }

        [HttpGet("youngest")]

        public async Task<IActionResult> Youngest()
        {
            var youngest = await _context.Users.Select(u => new GetUsersDto
            {
                Id = u.Id,
                Credits = u.Credits,
                IsActive = u.IsActive,
                Gender = u.Gender
            })
            .Where(u => u.IsActive == 1)
            .OrderBy(x=>x.Age)
            .ToListAsync();

            return Ok(youngest);
        }

        [HttpGet("oldest")]

        public async Task<IActionResult> Oldest()
        {
            var oldest = await _context.Users.Select(u => new GetUsersDto
            {
                Id = u.Id,
                Credits = u.Credits,
                IsActive = u.IsActive,
                Gender = u.Gender
            })
            .OrderByDescending(x => x.Age)
            .Where(u => u.IsActive == 1)
            .ToListAsync();

            return Ok(oldest);
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
