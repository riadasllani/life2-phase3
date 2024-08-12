using System;
using System.Security.Principal;
using System.Text.RegularExpressions;
using MatchingApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Service
{
	public class UserService : IUserService
	{

        private readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
		{
            _userRepository = userRepository;
		}

        public async Task<int> AverageCredits()
        { //2.Average Credits by Gender:
          //            You should calculate the average Credits first for both male and female users, then group the data by gender and compute the average.

            var average = await _userRepository
                .GetAll()
                 .Where(r => r.Credits == credits).Average(r => r.Credits)
                .GroupBy(d => d.Gender)
                .Select(g => new { Gender = g.Key, Count = g.Count() })
                .ToDictonaryAsync();

            return average;
        }

        public async Task<IDictionary<int, int>> CreditsByAge()
        {
            //4.Total Credits by Age Group:
            //            Group users into age brackets (0-15, 15-30, 30-45, 45-60, 60-75, 75-90, 90-105). Then, calculate the total Credits for each age group.
            var credits = await _userRepository
                .GetAll()
                .GroupBy(x => x.Age)
                .Select(g => g.Key)
                .ToListAsync();

            return credits;

        }

        public async Task<int> HighestCredits()
        {
            var test = await _userRepository
                .GetAll()
                .GroupBy(x => x.Credits)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .FirstOrDefaultAsync();

            return test;

        }

        public Task<string> YoungestAndOldest()
        {
            throw new NotImplementedException();
        }
    }
}

//1
//          

//          

//          