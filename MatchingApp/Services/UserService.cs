using Interfaces.IUnitOfWork;
using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserService> _logger;
        public UserService(IUnitOfWork unitOfWork,ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
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

        public async Task<IEnumerable<User>> GetUsersWithHighestCreditsActive()
        {
            var users = await _unitOfWork.Repository<User>()
                .GetByCondition(a => a.Active == true)
                .OrderByDescending(pl => pl.Credits)
                .Take(5)
                .ToListAsync();

            return users;
        }

        public async Task<IEnumerable<User>> GetOldestUser()
        {
            var users = await _unitOfWork.Repository<User>().GetAll().OrderByDescending(pl => pl.Age).Take(1).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<User>> GetYoungestUser()
        {
            var users = await _unitOfWork.Repository<User>().GetAll().OrderBy(pl => pl.Age).Take(1).ToListAsync();
            return users;
        }

        public async Task<double> GetTheAverageUser()
        {
            var users = await _unitOfWork.Repository<User>().GetAll().ToListAsync();

            var credits = 0;
            int a = 0;
            foreach(var user in users)
            {
                user.Credits += credits;
                a++;
            }
            var average = credits / a;
            return average;
        }

        public async Task<double> GetTheAverageFemale()
        {
            var users = await _unitOfWork.Repository<User>().GetByCondition(pl => pl.Gender == "Female").ToListAsync();

            var credits = 0;
            int a = 0;
            foreach (var user in users)
            {
                user.Credits += credits;
                a++;
            }
            var average = credits / a;
            return average;
        }

        public async Task<double> GetTheAverageMale()
        {
            var users = await _unitOfWork.Repository<User>().GetByCondition(pl => pl.Gender == "Male").ToListAsync();

            var credits = 0;
            int a = 0;
            foreach (var user in users)
            {
                user.Credits += credits;
                a++;
            }
            var average = credits / a;
            return average;
        }



    }
}
