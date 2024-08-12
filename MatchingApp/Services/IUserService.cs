using MatchingApp.Models.Entities;

namespace MatchingApp.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetUsersWithHighestCreditsActive();
        public Task<IEnumerable<User>> GetOldestUser();
        public Task<IEnumerable<User>> GetYoungestUser();
        public Task<double> GetTheAverageUser();
        public Task<double> GetTheAverageFemale();
        public Task<double> GetTheAverageMale()


    }
}
