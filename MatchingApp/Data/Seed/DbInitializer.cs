using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MatchingApp.Data.Seed
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DbInitializer(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Initialize()
        {
            try
            {
                if (_applicationDbContext.Database.GetPendingMigrations().Count() > 0)
                {
                    _applicationDbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
            }

            var dataExisting = _applicationDbContext.Users.Any();
            if (!dataExisting)
            {
                var dataToBeSeed = ReadData("/home/flamurih/Documents/projects/life2-phase3/MatchingApp/User_Data.csv"); //Send the right path for ApplicationData.csv within Data folder 

                /*
                 * Your code here ...
                 */
                _applicationDbContext.AddRange(dataToBeSeed);
                _applicationDbContext.SaveChanges();
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            /*
             * Your code here ...
             * You MUST use csv helper
             */
            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var value = line.Split(",");
                if (value[0] != "Id")
                {
                    var userToCreate = new User()
                    {
                        Id = int.Parse(value[0]),
                        Gender = value[1],
                        Age = int.Parse(value[2]),
                        Credits = int.Parse(value[3]),
                        Active = int.Parse(value[4])
                    };
                    records.Add(userToCreate);
                }
            }

            return records;
        }
    }
}
