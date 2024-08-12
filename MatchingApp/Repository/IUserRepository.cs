using System;
namespace MatchingApp.Repository
{
	public interface IUserRepository
	{
        IQueryable<Models.Entities.User> GetAll();

    }
}

