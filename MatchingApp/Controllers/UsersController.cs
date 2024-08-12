using MatchingApp.Data;
using MatchingApp.Models.Dtos;
using MatchingApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace MatchingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ApplicationDbContext _context;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }


        [HttpGet("GetUsers")]
        public Task<IActionResult> GetTopFive(Filters filters)
        {
            // YOUR CODE HERE
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)



            return (Task<IActionResult>)_context.Users.Where(nd => nd.Active)
                .GroupBy(nd => nd.Credits)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(5);




            // return the users
        }

        [HttpGet("Get")]
        public Task<IActionResult> GetAverageCredits(Filters filters)
        {
            // YOUR CODE HERE
            // be sure to return only active users and apply filters
            // return all users as we have only around 400 users,
            // but the top 100 first users should contain the users who liked the current user
            // be sure for them not to be in queue (so shuffle them)



            return (Task<IActionResult>)_context.Users.GroupBy(g => g.Gender);
                //.Average(g => g.Credits);





            // return the users
        }

        //[HttpGet("Get")]
        //public Task<IActionResult> GetOldest(Filters filters)
        //{
        //    // YOUR CODE HERE
        //    // be sure to return only active users and apply filters
        //    // return all users as we have only around 400 users,
        //    // but the top 100 first users should contain the users who liked the current user
        //    // be sure for them not to be in queue (so shuffle them)



        //    return (Task<IActionResult>)_context.Users.Select(g => g.Key).OrderByDescending(g => )
        //        //.Average(g => g.Credits);

        //         return await _context.NetflixData
        //        .Where(nd => nd.type == "Movie")
        //        .GroupBy(nd => nd.date_added.Value.Month)
        //        .OrderByDescending(g => g.Count())
        //        .Select(g => g.Key)
        //        .FirstOrDefaultAsync();





        //    // return the users
        //}
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
