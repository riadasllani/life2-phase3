using MatchingApp.Models.Entities;

namespace MatchingApp.Data
{
    public class MatchingAppRepository : IMatchingAppRepository
    {
        public ApplicationDbContext _context { get; set; }

        public MatchingAppRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> TopUsersWithHighestCredit()
        {
            var topUsers = _context.Users
                .Where(x => x.Active == true)
               .OrderByDescending(c => c.Credits)
               .Take(5)
               .FirstOrDefault();

            return topUsers;
        }
    }
}
