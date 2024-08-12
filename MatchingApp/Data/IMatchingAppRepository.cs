using MatchingApp.Models.Entities;

namespace MatchingApp.Data
{
    public interface IMatchingAppRepository
    {
        Task<User> TopUsersWithHighestCredit();
    }
}
