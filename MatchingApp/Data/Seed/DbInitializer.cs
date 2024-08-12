using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

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
                var dataToBeSeed = ReadData("C:\\Users\\Valzon\\Source\\Repos\\life2-phase3\\MatchingApp\\User_Data.csv"); //Send the right path for ApplicationData.csv within Data folder 

                _applicationDbContext.Users.AddRange(dataToBeSeed);
                _applicationDbContext.SaveChanges();
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The CSV file was not found.", path);
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                BadDataFound = null
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                while (csv.Read())
                {
                    var record = new User
                    {
                        Id = csv.GetField(0),
                        Gender = csv.GetField(1),
                        Age = csv.GetField(2),
                        Credits = csv.GetField(3),
                        Active = csv.GetField(4),
                    };

                    records.Add(record);
                }
            }

            return records;
        }
    }
}
