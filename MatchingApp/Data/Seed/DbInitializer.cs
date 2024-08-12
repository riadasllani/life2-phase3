using System.Globalization;
using CsvHelper;
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
                var dataToBeSeed = ReadData("C:\\Users\\Admin\\Documents\\GitHub\\life2-phase3\\MatchingApp\\User_Data.csv"); //Send the right path for ApplicationData.csv within Data folder 

                _applicationDbContext.Users.AddRange(dataToBeSeed);
                _applicationDbContext.SaveChanges();
            }
        }

        public List<User> ReadData(string path)
        {
            List<User> records = new();

            if (File.Exists(path))
            {
                using var reader = new StreamReader(path);
                var csvConfig = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ","
                };
                using var csv = new CsvReader(reader, csvConfig);
                
                csv.Read();
                csv.ReadHeader();
                
                while (csv.Read())
                {
                    var record = new User()
                    {
                        //Id = csv.GetField<int>(0),
                        Gender = csv.GetField<string>(1),
                        Age = csv.GetField<int>(2),
                        Credits = csv.GetField<string>(3),
                        IsActive = csv.GetField<bool>(4)
                    };

                    records.Add(record);
                }
            }

            return records;
        }
    }
}