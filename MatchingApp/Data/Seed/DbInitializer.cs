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
                if (_applicationDbContext.Database.GetPendingMigrations().Any())
                {
                    _applicationDbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., logging)
            }

            var dataExisting = _applicationDbContext.Users.Any();
            if (!dataExisting)
            {
                var dataToBeSeed = ReadData("C:\\Users\\lisma\\OneDrive\\Desktop\\BackEnd\\TEst\\MatchingApp\\User_Data.csv");

                if (dataToBeSeed != null && dataToBeSeed.Count > 0)
                {
                    _applicationDbContext.Users.AddRange(dataToBeSeed);
                    _applicationDbContext.SaveChanges();
                }
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            var lines = File.ReadAllLines(path);
            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');
                var record = new User
                {
                    Id = int.Parse(values[0]),  
                    Gender = values[1],
                    Age = int.Parse(values[2]),
                    Credits = int.Parse(values[3]),
                    Active = values[4] == "1" 
                };
                records.Add(record);
            }

            return records;
        }

    }
}