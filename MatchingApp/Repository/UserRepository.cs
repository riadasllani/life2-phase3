using System;
using MatchingApp.Data;
using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Repository
{
	public class UserRepository :IUserRepository
	{

        private readonly ApplicationDbContext _dbContext;

		public UserRepository(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
		}


        public IQueryable<User> GetAll()
        {
            var result = _dbContext.Set<User>();

            return result;
        }
    }
}

