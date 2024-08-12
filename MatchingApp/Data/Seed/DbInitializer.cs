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
                var dataToBeSeed = ReadData(@"C:\\Users\\OEM\\Source\\Repos\\life2-phase3\\MatchingApp\\User_Data.csv"); //Send the right path for ApplicationData.csv within Data folder 

                _applicationDbContext.Users.AddRange(dataToBeSeed);
                _applicationDbContext.SaveChangesAsync();
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            var list = File.ReadAllLines(path);
            foreach (var line in list)
            {
                var parts = line.Split(',');

                records.Add(new User
                {
                    Id = int.Parse(parts[0]),
                    Gender = parts[1],
                    Age = int.Parse(parts[2]),
                    Credits = int.Parse(parts[3]),
                    Active = bool.Parse(parts[4]),
                });
            }

            return records;
        }
    }
}
